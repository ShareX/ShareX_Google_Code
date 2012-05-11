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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using HelpersLib;
using Renci.SshNet;
using Renci.SshNet.Common;
using Renci.SshNet.Sftp;
using UploadersLib.HelperClasses;

namespace UploadersLib.FileUploaders
{
    public sealed class SFTP : IDisposable
    {
        public FTPAccount FTPAccount { get; set; }

        public bool IsConnected { get { return client.IsConnected; } }

        public string HomeDir { get; set; }

        public bool IsInstantiated { get; set; }

        public event Uploader.ProgressEventHandler ProgressChanged;

        private ProgressManager progress;

        private SftpClient client;

        public SFTP(FTPAccount account)
        {
            this.FTPAccount = account;

            if (FTPAccount.UserName.Contains("@"))
            {
                FTPAccount.UserName = FTPAccount.UserName.Substring(0, FTPAccount.UserName.IndexOf('@'));
            }
            if (!string.IsNullOrEmpty(FTPAccount.Password) && (string.IsNullOrEmpty(FTPAccount.Keypath)))
            {
                client = new SftpClient(FTPAccount.Host, FTPAccount.Port, FTPAccount.UserName, FTPAccount.Password);
            }
            else if (string.IsNullOrEmpty(FTPAccount.Password) && (File.Exists(FTPAccount.Keypath)) && (string.IsNullOrEmpty(FTPAccount.Passphrase)))
            {
                client = new SftpClient(FTPAccount.Host, FTPAccount.Port, FTPAccount.UserName, new PrivateKeyFile(FTPAccount.Keypath));
            }
            else if (string.IsNullOrEmpty(FTPAccount.Password) && (File.Exists(FTPAccount.Keypath)) && (!string.IsNullOrEmpty(FTPAccount.Passphrase)))
            {
                client = new SftpClient(FTPAccount.Host, FTPAccount.Port, FTPAccount.UserName, new PrivateKeyFile(FTPAccount.Keypath, FTPAccount.Passphrase));
            }
            else
            {
                //Need to do something here...
                DebugHelper.WriteLine("Can't instantiate a SFTP client...");
                IsInstantiated = false;
                return;
            }
            IsInstantiated = true;
        }

        public bool Connect()
        {
            if (!IsConnected)
            {
                client.Connect();
                HomeDir = client.WorkingDirectory;
            }
            return client.IsConnected;
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                client.Disconnect();
                client.Dispose();
            }
        }

        public static void CallBack(IAsyncResult ia)
        {
            DebugHelper.WriteLine("Finished Uploading");
        }

        public void ChangeDirectory(string Path)
        {
            try
            {
                client.ChangeDirectory(Path);
            }
            catch (SftpPathNotFoundException)
            {
                CreateDirectory(Path);
                ChangeDirectory(Path);
            }
        }

        public void CreateDirectory(string Path)
        {
            try
            {
                client.CreateDirectory(Path);
                DebugHelper.WriteLine("Created Directory: " + Path);
            }
            catch (SftpPathNotFoundException)
            {
                DebugHelper.WriteLine("Failed to create directory " + Path);
                DebugHelper.WriteLine("Attempting to fix...");
                CreateMultipleDirectorys(FTPHelpers.GetPaths(Path));
            }
            catch (SftpPermissionDeniedException)
            {
            }
        }

        public bool DirectoryExists(string Dir)
        {
            Connect();
            try
            {
                string cdir = client.WorkingDirectory;
                client.ChangeDirectory(Dir);
                client.ChangeDirectory(cdir);
                return true;
            }
            catch (SftpPathNotFoundException)
            {
                return false;
            }
        }

        public List<string> CreateMultipleDirectorys(List<string> Directories)
        {
            List<string> CreatedList = new List<string>();
            for (int x = 0; x <= Directories.Count - 1; x++)
            {
                Directories[x] = Directories[x].Substring(1);
                if (!DirectoryExists(Directories[x]))
                {
                    CreateDirectory(Directories[x]);
                    CreatedList.Add(Directories[x]);
                }
            }
            return CreatedList;
        }

        public SftpFile[] DirectoryListing(string RootDir)
        {
            Connect();
            IEnumerable<SftpFile> dirlist = client.ListDirectory(RootDir);
            return dirlist.ToArray<SftpFile>();
        }

        private void OnTransferProgressChanged(SftpUploadAsyncResult e)
        {
            if (ProgressChanged != null)
            {
                progress.ChangeProgress((int)e.UploadedBytes, true);
                ProgressChanged(progress);
            }
        }

        public void UploadData(Stream stream, string filePath)
        {
            Connect();

            progress = new ProgressManager(stream.Length);

            ChangeDirectory(FTPAccount.GetSubFolderPath());

            object s = new object();
            AsyncCallback ac = new AsyncCallback(CallBack);

            var result = client.BeginUploadFile(stream, Path.GetFileName(filePath), ac, s);
            SftpUploadAsyncResult sftpresult = result as SftpUploadAsyncResult;

            while (!sftpresult.IsCompleted)
            {
                if (sftpresult.UploadedBytes > 0)
                {
                    OnTransferProgressChanged(sftpresult);
                }
                Thread.Sleep(100);
            }

            client.EndUploadFile(sftpresult);
            Disconnect();
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}