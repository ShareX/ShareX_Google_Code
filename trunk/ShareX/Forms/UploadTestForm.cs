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
        public enum UploadStatus { Uploading, Uploaded }

        private bool isTesting;
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

        public UploadTestForm()
        {
            InitializeComponent();

            if (TestImage == null)
            {
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

                Task task = Task.CreateImageUploaderTask((Image)TestImage.Clone());
                task.Info.ImageDestination = uploader;

                lvi.Tag = task;
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

                Task task = Task.CreateTextUploaderTask(TestText);
                task.Info.TextDestination = uploader;

                lvi.Tag = task;
                lvi.Group = textUploadersGroup;
                lvUploaders.Items.Add(lvi);
            }

            foreach (FileDestination uploader in Enum.GetValues(typeof(FileDestination)))
            {
                switch (uploader)
                {
                    case FileDestination.CustomUploader:
                    case FileDestination.SharedFolder:
                    case FileDestination.Email:
                        continue;
                }

                lvi = new ListViewItem(uploader.GetDescription());

                Task task = Task.CreateImageUploaderTask((Image)TestImage.Clone());
                task.Info.ImageDestination = ImageDestination.FileUploader;
                task.Info.FileDestination = uploader;

                lvi.Tag = task;
                lvi.Group = fileUploadersGroup;
                lvUploaders.Items.Add(lvi);
            }

            foreach (UrlShortenerType uploader in Enum.GetValues(typeof(UrlShortenerType)))
            {
                lvi = new ListViewItem(uploader.GetDescription());

                Task task = Task.CreateURLShortenerTask(TestURL);
                task.Info.URLShortenerDestination = uploader;

                lvi.Tag = task;
                lvi.Group = urlShortenersGroup;
                lvUploaders.Items.Add(lvi);
            }

            PrepareListItems();
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
            }
        }

        private void btnTestAll_Click(object sender, EventArgs e)
        {
            Task[] uploaders = lvUploaders.Items.Cast<ListViewItem>().Select(x => x.Tag as Task).ToArray();
            StartTest(uploaders);
        }

        private void btnTestSelected_Click(object sender, EventArgs e)
        {
            Task[] uploaders = lvUploaders.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag as Task).ToArray();
            StartTest(uploaders);
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

        private ListViewItem FindListViewItem(Task task)
        {
            foreach (ListViewItem lvi in lvUploaders.Items)
            {
                Task x = lvi.Tag as Task;
                if (x != null && x == task) return lvi;
            }

            return null;
        }

        public void StartTest(Task[] uploaders)
        {
            Testing = true;

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += (x, x2) => Testing = false;
            bw.RunWorkerAsync(uploaders);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            Task[] uploaders = (Task[])e.Argument;

            foreach (Task task in uploaders)
            {
                if (IsDisposed || !isTesting || task == null)
                {
                    break;
                }

                bw.ReportProgress((int)UploadStatus.Uploading, task);

                try
                {
                    task.StartSync();
                }
                catch (Exception ex)
                {
                    ConsoleWriteLine(ex.ToString());
                }
                finally
                {
                    bw.ReportProgress((int)UploadStatus.Uploaded, task);
                }
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!IsDisposed)
            {
                Task task = e.UserState as Task;

                if (task != null)
                {
                    ListViewItem lvi = FindListViewItem(task);

                    if (lvi != null)
                    {
                        switch ((UploadStatus)e.ProgressPercentage)
                        {
                            case UploadStatus.Uploading:
                                lvi.BackColor = Color.Gold;
                                lvi.SubItems[1].Text = "Uploading...";
                                lvi.SubItems[2].Text = string.Empty;
                                break;
                            case UploadStatus.Uploaded:
                                UploadInfo info = task.Info;

                                if (info != null && info.Result != null)
                                {
                                    if (!info.Result.IsError && !string.IsNullOrEmpty(info.Result.ToString()))
                                    {
                                        lvi.BackColor = Color.LightGreen;
                                        lvi.SubItems[1].Text = "Success: " + info.Result.ToString();
                                    }
                                    else
                                    {
                                        lvi.BackColor = Color.LightCoral;
                                        lvi.SubItems[1].Text = "Failed: " + info.Result.ErrorsToString();
                                        txtConsole.AppendText(info.Result.ErrorsToString());
                                    }
                                }

                                lvi.SubItems[2].Text = (int)info.UploadDuration.TotalMilliseconds + " ms";
                                break;
                        }
                    }
                }
            }
        }

        private void openURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvUploaders.SelectedItems.Count > 0)
            {
                Task task = lvUploaders.SelectedItems[0].Tag as Task;

                if (task != null && task.Info != null && task.Info.Result != null && !string.IsNullOrEmpty(task.Info.Result.ToString()))
                {
                    ThreadPool.QueueUserWorkItem(x => Process.Start(task.Info.Result.ToString()));
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvUploaders.SelectedItems.Count > 0)
            {
                List<string> urls = new List<string>();

                foreach (ListViewItem lvi in lvUploaders.SelectedItems)
                {
                    Task task = lvi.Tag as Task;

                    if (task != null && task.Info != null && task.Info.Result != null && !string.IsNullOrEmpty(task.Info.Result.ToString()))
                    {
                        urls.Add(string.Format("{0}: {1}", lvi.Text, task.Info.Result.ToString()));
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

            if (TestImage != null)
            {
                TestImage.Dispose();
            }
        }
    }
}