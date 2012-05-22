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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web;
using System.Windows.Forms;

namespace HelpersLib
{
    public enum DownloaderFormStatus { Waiting, DownloadStarted, DownloadCompleted, InstallStarted }

    public partial class DownloaderForm : Form
    {
        public string URL { get; set; }
        public string FileName { get; set; }
        public string SavePath { get; private set; }
        public IWebProxy Proxy { get; set; }
        public string Changelog { get; set; }
        public bool AutoStartDownload { get; set; }
        public DownloaderFormStatus Status { get; private set; }

        private FileDownloader fileDownloader;
        private FileStream fileStream;
        private Rectangle fillRect;
        private LinearGradientBrush backgroundBrush;

        public DownloaderForm()
        {
            InitializeComponent();
            fillRect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            backgroundBrush = new LinearGradientBrush(fillRect, Color.FromArgb(80, 80, 80), Color.FromArgb(50, 50, 50), LinearGradientMode.Vertical);
            UpdateFormSize();
            ChangeStatus("Waiting.");

            Status = DownloaderFormStatus.Waiting;

            AutoStartDownload = true;
        }

        public DownloaderForm(string url, IWebProxy proxy, string changelog)
            : this()
        {
            URL = url;
            Proxy = proxy;
            Changelog = changelog;
            txtChangelog.Text = changelog;
            FileName = HttpUtility.UrlDecode(URL.Substring(URL.LastIndexOf('/') + 1));
            lblFilename.Text = "Filename: " + FileName;
        }

        private void UpdaterForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(backgroundBrush, fillRect);
        }

        private void DownloaderForm_Shown(object sender, EventArgs e)
        {
            if (AutoStartDownload)
            {
                StartDownload();
            }
        }

        private void ChangeStatus(string status)
        {
            lblStatus.Text = "Status: " + status;
        }

        private void ChangeProgress()
        {
            pbProgress.Value = (int)Math.Round(fileDownloader.DownloadPercentage);
            lblProgress.Text = String.Format(CultureInfo.CurrentCulture,
                "Progress: {0:0.##}%\nDownload speed: {1:0.##} kB/s\nFile size: {2:n0} / {3:n0} kB",
                fileDownloader.DownloadPercentage, fileDownloader.DownloadSpeed / 1024, fileDownloader.DownloadedSize / 1024,
                fileDownloader.FileSize / 1024);
        }

        private void StartDownload()
        {
            if (!string.IsNullOrEmpty(URL) && Status == DownloaderFormStatus.Waiting)
            {
                Status = DownloaderFormStatus.DownloadStarted;
                btnAction.Text = "Cancel";

                SavePath = Path.Combine(Path.GetTempPath(), FileName);
                fileStream = new FileStream(SavePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                fileDownloader = new FileDownloader(URL, fileStream, Proxy);
                fileDownloader.FileSizeReceived += (v1, v2) => ChangeProgress();
                fileDownloader.DownloadStarted += (v1, v2) => ChangeStatus("Download started.");
                fileDownloader.ProgressChanged += (v1, v2) => ChangeProgress();
                fileDownloader.DownloadCompleted += new EventHandler(fileDownloader_DownloadCompleted);
                fileDownloader.ExceptionThrowed += (v1, v2) => ChangeStatus("Exception: " + fileDownloader.LastException.Message);
                fileDownloader.StartDownload();

                ChangeStatus("Getting file size.");
            }
        }

        private void UpdateFormSize()
        {
            if (cbShowChangelog.Checked)
            {
                Size = new Size(Size.Width, 445);
            }
            else
            {
                Size = new Size(Size.Width, 233);
            }
        }

        private void fileDownloader_DownloadCompleted(object sender, EventArgs e)
        {
            Status = DownloaderFormStatus.DownloadCompleted;
            ChangeStatus("Download completed.");
            btnAction.Text = "Install";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case DownloaderFormStatus.Waiting:
                    StartDownload();
                    break;
                default:
                case DownloaderFormStatus.DownloadStarted:
                    Close();
                    break;
                case DownloaderFormStatus.DownloadCompleted:
                    try
                    {
                        btnAction.Enabled = false;
                        ProcessStartInfo psi = new ProcessStartInfo(SavePath);
                        psi.Verb = "runas";
                        psi.UseShellExecute = true;
                        Process.Start(psi);
                        Status = DownloaderFormStatus.InstallStarted;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Updater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Close();
                    break;
            }
        }

        private void cbShowChangelog_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFormSize();
        }

        private void UpdaterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Status == DownloaderFormStatus.DownloadStarted)
            {
                fileDownloader.StopDownload();
            }
        }
    }
}