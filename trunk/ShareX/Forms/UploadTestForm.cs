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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HelpersLib;
using ShareX.Properties;
using UploadersLib;

namespace ShareX
{
    public partial class UploadTestForm : Form
    {
        public enum UploaderType
        {
            None,
            ImageUploader,
            TextUploader,
            FileUploader,
            UrlShortener
        }

        public class UploaderInfo
        {
            public UploaderType UploaderType;
            public ImageDestination ImageUploader;
            public TextDestination TextUploader;
            public FileDestination FileUploader;
            public UrlShortenerType UrlShortener;
            public Task Task;
            public int Index;
            public Stopwatch Timer;
        }

        public bool Testing
        {
            get { return isTesting; }
            set
            {
                isTesting = value;
                btnTestAll.Enabled = !value;
                btnTestSelected.Enabled = !value;
                testSelectedUploadersToolStripMenuItem.Enabled = !value;
            }
        }

        public Image TestImage { get; set; }
        public string TestText { get; set; }
        public string TestURL { get; set; }

        private bool isTesting = false;

        public UploadTestForm()
        {
            InitializeComponent();

            ListViewItem lvi;

            ListViewGroup imageUploadersGroup = new ListViewGroup("Image Uploaders", HorizontalAlignment.Left);
            ListViewGroup textUploadersGroup = new ListViewGroup("Text Uploaders", HorizontalAlignment.Left);
            ListViewGroup fileUploadersGroup = new ListViewGroup("File Uploaders", HorizontalAlignment.Left);
            ListViewGroup urlShortenersGroup = new ListViewGroup("URL Shorteners", HorizontalAlignment.Left);
            lvUploaders.Groups.AddRange(new[] { imageUploadersGroup, textUploadersGroup, fileUploadersGroup, urlShortenersGroup });

            foreach (ImageDestination uploader in Enum.GetValues(typeof(ImageDestination)))
            {
                switch (uploader)
                {
                    case ImageDestination.Twitsnaps: // Not possible to upload without post Twitter
                    case ImageDestination.FileUploader: // We are going to test this in File Uploader tests
                        continue;
                }

                lvi = new ListViewItem(uploader.GetDescription());
                lvi.Tag = new UploaderInfo { UploaderType = UploaderType.ImageUploader, ImageUploader = uploader };
                lvi.Group = imageUploadersGroup;
                lvUploaders.Items.Add(lvi);
            }

            foreach (TextDestination uploader in Enum.GetValues(typeof(TextDestination)))
            {
                switch (uploader)
                {
                    case TextDestination.FileUploader:
                        continue;
                }

                lvi = new ListViewItem(uploader.GetDescription());
                lvi.Tag = new UploaderInfo { UploaderType = UploaderType.TextUploader, TextUploader = uploader };
                lvi.Group = textUploadersGroup;
                lvUploaders.Items.Add(lvi);
            }

            foreach (FileDestination uploader in Enum.GetValues(typeof(FileDestination)))
            {
                switch (uploader)
                {
                    case FileDestination.CustomUploader:
                        continue;
                }

                lvi = new ListViewItem(uploader.GetDescription());
                lvi.Tag = new UploaderInfo { UploaderType = UploaderType.FileUploader, FileUploader = uploader };
                lvi.Group = fileUploadersGroup;
                lvUploaders.Items.Add(lvi);
            }

            foreach (UrlShortenerType uploader in Enum.GetValues(typeof(UrlShortenerType)))
            {
                lvi = new ListViewItem(uploader.GetDescription());
                lvi.Tag = new UploaderInfo { UploaderType = UploaderType.UrlShortener, UrlShortener = uploader };
                lvi.Group = urlShortenersGroup;
                lvUploaders.Items.Add(lvi);
            }

            PrepareListItems();
        }

        private void TesterGUI_Load(object sender, EventArgs e)
        {
            CheckPaths();
        }

        private void CheckPaths()
        {
            if (TestImage == null)
            {
                /*using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Image Files (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                    dlg.Title = "Browse for a test image file. It will be used for Image/File upload tests.";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        TestImage = Image.FromFile(dlg.FileName);
                    }
                    else
                    {
                        Close();
                    }
                }*/

                TestImage = Resources.ShareXLogo;
            }

            if (string.IsNullOrEmpty(TestText))
            {
                TestText = Program.ApplicationName + " text upload test";
            }

            if (string.IsNullOrEmpty(TestURL))
            {
                TestURL = Links.URL_WEBSITE;
            }
        }

        private void PrepareListItems()
        {
            for (int i = 0; i < lvUploaders.Items.Count; i++)
            {
                ListViewItem lvi = lvUploaders.Items[i];

                while (lvi.SubItems.Count < 3)
                {
                    lvi.SubItems.Add(string.Empty);
                }

                lvi.SubItems[1].Text = "Waiting";
                lvi.BackColor = Color.LightYellow;

                UploaderInfo uploadInfo = lvi.Tag as UploaderInfo;
                if (uploadInfo != null)
                {
                    uploadInfo.Index = i;
                }
            }
        }

        private void ConsoleWriteLine(string value)
        {
            if (!this.IsDisposed)
            {
                this.Invoke(new MethodInvoker(delegate
                    {
                        txtConsole.AppendText(value + "\r\n");
                    }));
            }
        }

        public void StartTest(UploaderInfo[] uploaders)
        {
            Testing = true;

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += (x, x2) => Testing = false;
            bw.RunWorkerAsync(uploaders);
        }

        public enum UploadStatus
        {
            Uploading,
            Uploaded
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            UploaderInfo[] uploaders = (UploaderInfo[])e.Argument;

            foreach (UploaderInfo uploader in uploaders)
            {
                if (IsDisposed || !isTesting || uploader == null)
                {
                    break;
                }

                uploader.Timer = new Stopwatch();
                uploader.Timer.Start();
                bw.ReportProgress((int)UploadStatus.Uploading, uploader);

                try
                {
                    switch (uploader.UploaderType)
                    {
                        case UploaderType.ImageUploader:
                            uploader.Task = Task.CreateImageUploaderTask((Image)TestImage.Clone());
                            uploader.Task.Info.ImageDestination = uploader.ImageUploader;
                            break;
                        case UploaderType.TextUploader:
                            uploader.Task = Task.CreateTextUploaderTask(TestText);
                            uploader.Task.Info.TextDestination = uploader.TextUploader;
                            break;
                        case UploaderType.FileUploader:
                            uploader.Task = Task.CreateImageUploaderTask((Image)TestImage.Clone());
                            uploader.Task.Info.ImageDestination = ImageDestination.FileUploader;
                            uploader.Task.Info.FileDestination = uploader.FileUploader;
                            break;
                        case UploaderType.UrlShortener:
                            uploader.Task = Task.CreateURLShortenerTask(TestURL);
                            uploader.Task.Info.URLShortenerDestination = uploader.UrlShortener;
                            break;
                        default:
                            throw new Exception("Unknown uploader.");
                    }

                    uploader.Task.StartSync();
                }
                catch (Exception ex)
                {
                    ConsoleWriteLine(ex.ToString());
                }
                finally
                {
                    uploader.Timer.Stop();
                    bw.ReportProgress((int)UploadStatus.Uploaded, uploader);
                }
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!IsDisposed)
            {
                UploaderInfo uploader = e.UserState as UploaderInfo;

                if (uploader != null)
                {
                    lvUploaders.Items[uploader.Index].Tag = uploader;

                    switch ((UploadStatus)e.ProgressPercentage)
                    {
                        case UploadStatus.Uploading:
                            lvUploaders.Items[uploader.Index].BackColor = Color.Gold;
                            lvUploaders.Items[uploader.Index].SubItems[1].Text = "Uploading...";
                            lvUploaders.Items[uploader.Index].SubItems[2].Text = string.Empty;
                            break;
                        case UploadStatus.Uploaded:
                            UploadInfo info = uploader.Task.Info;

                            if (info != null && info.Result != null)
                            {
                                if (!info.Result.IsError && !string.IsNullOrEmpty(info.Result.ToString()))
                                {
                                    lvUploaders.Items[uploader.Index].BackColor = Color.LightGreen;
                                    lvUploaders.Items[uploader.Index].SubItems[1].Text = "Success: " + info.Result.ToString();
                                }
                                else
                                {
                                    lvUploaders.Items[uploader.Index].BackColor = Color.LightCoral;
                                    lvUploaders.Items[uploader.Index].SubItems[1].Text = "Failed: " + info.Result.ErrorsToString();
                                }
                            }

                            lvUploaders.Items[uploader.Index].SubItems[2].Text = uploader.Timer.ElapsedMilliseconds + " ms";
                            break;
                    }
                }
            }
        }

        private void openURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvUploaders.SelectedItems.Count > 0)
            {
                UploaderInfo uploader = lvUploaders.SelectedItems[0].Tag as UploaderInfo;

                if (uploader != null && uploader.Task != null && uploader.Task.Info != null && uploader.Task.Info.Result != null && !string.IsNullOrEmpty(uploader.Task.Info.Result.ToString()))
                {
                    ThreadPool.QueueUserWorkItem(x => Process.Start(uploader.Task.Info.Result.ToString()));
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvUploaders.SelectedItems.Count > 0)
            {
                List<string> urls = new List<string>();
                UploaderInfo uploader;

                foreach (ListViewItem lvi in lvUploaders.SelectedItems)
                {
                    uploader = lvi.Tag as UploaderInfo;

                    if (uploader != null && uploader.Task != null && uploader.Task.Info != null && uploader.Task.Info.Result != null && !string.IsNullOrEmpty(uploader.Task.Info.Result.ToString()))
                    {
                        urls.Add(string.Format("{0}: {1}", lvi.Text, uploader.Task.Info.Result.ToString()));
                    }
                }

                if (urls.Count > 0)
                {
                    Clipboard.SetText(string.Join("\r\n", urls.ToArray()));
                }
            }
        }

        private void TesterGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            isTesting = false;
        }

        private void btnTestAll_Click(object sender, EventArgs e)
        {
            UploaderInfo[] uploaders = lvUploaders.Items.Cast<ListViewItem>().Select(x => x.Tag as UploaderInfo).ToArray();
            StartTest(uploaders);
        }

        private void btnTestSelected_Click(object sender, EventArgs e)
        {
            UploaderInfo[] uploaders = lvUploaders.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag as UploaderInfo).ToArray();
            StartTest(uploaders);
        }
    }
}