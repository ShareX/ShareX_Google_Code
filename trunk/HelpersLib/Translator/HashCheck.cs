#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (C) 2012 ShareX Developers

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace HelpersLib
{
    public class HashCheck
    {
        public string FilePath { get; private set; }
        public HashType HashType { get; private set; }
        public bool IsWorking { get; private set; }

        public delegate void ProgressChanged(float progress);
        public event ProgressChanged FileCheckProgressChanged;

        public delegate void Completed(string result, bool cancelled);
        public event Completed FileCheckCompleted;

        private BackgroundWorker bw;

        public HashCheck()
        {
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(CheckThread);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (FileCheckProgressChanged != null)
            {
                FileCheckProgressChanged((float)e.UserState);
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsWorking = false;

            if (FileCheckCompleted != null)
            {
                string result = string.Empty;

                if (!e.Cancelled)
                {
                    result = (string)e.Result;
                }

                FileCheckCompleted(result, e.Cancelled);
            }
        }

        public bool Start(string filePath, HashType hashType)
        {
            FilePath = filePath;
            HashType = hashType;

            if (!IsWorking && !string.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
            {
                IsWorking = true;
                bw.RunWorkerAsync();
                return true;
            }

            return false;
        }

        public void Stop()
        {
            bw.CancelAsync();
        }

        private void CheckThread(object sender, DoWorkEventArgs e)
        {
            using (FileStream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (HashAlgorithm hash = TranslatorHelper.GetHashAlgorithm(HashType))
            using (CryptoStream cs = new CryptoStream(stream, hash, CryptoStreamMode.Read))
            {
                long bytesRead = 0, totalRead = 0;
                byte[] buffer = new byte[8192];
                Stopwatch timer = Stopwatch.StartNew();

                while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0 && !bw.CancellationPending)
                {
                    totalRead += bytesRead;

                    if (timer.ElapsedMilliseconds > 100)
                    {
                        float progress = (float)totalRead / stream.Length * 100;
                        bw.ReportProgress(0, progress);
                        timer.Reset();
                        timer.Start();
                    }
                }

                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    string[] hex = TranslatorHelper.BytesToHexadecimal(hash.Hash);
                    e.Result = string.Concat(hex);
                }
            }
        }
    }
}