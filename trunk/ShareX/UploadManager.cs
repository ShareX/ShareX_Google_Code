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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using HelpersLib;
using HistoryLib;
using ShareX.Properties;
using UploadersLib;
using UploadersLib.HelperClasses;

namespace ShareX
{
    public static class UploadManager
    {
        public static ImageDestination ImageUploader { get; set; }
        public static TextDestination TextUploader { get; set; }
        public static FileDestination FileUploader { get; set; }
        public static UrlShortenerType URLShortener { get; set; }
        public static MyListView ListViewControl { get; set; }
        public static List<Task> Tasks { get; private set; }

        private static object uploadManagerLock = new object();
        private static Icon[] trayIcons;

        static UploadManager()
        {
            Tasks = new List<Task>();
            trayIcons = new Icon[] { Resources.sharex_16px_0, Resources.sharex_16px_1, Resources.sharex_16px_2, Resources.sharex_16px_3,
                Resources.sharex_16px_4, Resources.sharex_16px_5, Resources.sharex_16px_6 };
        }

        public static void UploadFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (File.Exists(path))
                {
                    EDataType type;
                    EDataType destination = EDataType.Default;

                    if (Helpers.IsImageFile(path))
                    {
                        type = EDataType.Image;

                        if (ImageUploader == ImageDestination.FileUploader)
                        {
                            destination = EDataType.File;
                        }
                    }
                    else if (Helpers.IsTextFile(path))
                    {
                        type = EDataType.Text;

                        if (TextUploader == TextDestination.FileUploader)
                        {
                            destination = EDataType.File;
                        }
                    }
                    else
                    {
                        type = EDataType.File;
                    }

                    Task task = Task.CreateFileUploaderTask(type, path, destination);
                    StartUpload(task);
                }
                else if (Directory.Exists(path))
                {
                    string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                    UploadFile(files);
                }
            }
        }

        public static void UploadFile(string[] files)
        {
            if (files != null && files.Length > 0)
            {
                foreach (string file in files)
                {
                    UploadFile(file);
                }
            }
        }

        public static void UploadFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    UploadFile(ofd.FileNames);
                }
            }
        }

        public static void ClipboardUpload()
        {
            if (Clipboard.ContainsImage())
            {
                Image img = Clipboard.GetImage();
                UploadImage(img);
            }
            else if (Clipboard.ContainsFileDropList())
            {
                string[] files = Clipboard.GetFileDropList().Cast<string>().ToArray();
                UploadFile(files);
            }
            else if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();

                if (Program.Settings.ClipboardUploadAutoDetectURL && Helpers.IsValidURL(text))
                {
                    ShortenURL(text.Trim());
                }
                else
                {
                    UploadText(text);
                }
            }
        }

        public static void ClipboardUploadWithContentViewer()
        {
            if (Program.Settings.ShowClipboardContentViewer)
            {
                using (ClipboardContentViewer ccv = new ClipboardContentViewer())
                {
                    if (ccv.ShowDialog() == DialogResult.OK && !ccv.IsClipboardEmpty)
                    {
                        UploadManager.ClipboardUpload();
                    }

                    Program.Settings.ShowClipboardContentViewer = !ccv.DontShowThisWindow;
                }
            }
            else
            {
                UploadManager.ClipboardUpload();
            }
        }

        public static void DragDropUpload(IDataObject data)
        {
            if (data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] files = data.GetData(DataFormats.FileDrop, false) as string[];
                UploadFile(files);
            }
            else if (data.GetDataPresent(DataFormats.Bitmap, false))
            {
                Image img = data.GetData(DataFormats.Bitmap, false) as Image;
                UploadImage(img);
            }
            else if (data.GetDataPresent(DataFormats.Text, false))
            {
                string text = data.GetData(DataFormats.Text, false) as string;
                UploadText(text);
            }
        }

        public static void UploadImage(Image img)
        {
            DoImageWork(img, TaskImageJob.UploadImageToHost);
        }

        public static void DoImageWork(Image img, TaskImageJob imageJob)
        {
            if (img != null)
            {
                EDataType destination = ImageUploader == ImageDestination.FileUploader ? EDataType.File : EDataType.Image;
                Task task = Task.CreateImageUploaderTask(img, destination);
                task.Info.ImageJob = imageJob;
                StartUpload(task);
            }
        }

        public static void UploadText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                EDataType destination = TextUploader == TextDestination.FileUploader ? EDataType.File : EDataType.Text;
                Task task = Task.CreateTextUploaderTask(text, destination);
                StartUpload(task);
            }
        }

        public static void UploadImageStream(Stream stream, string filename)
        {
            if (stream != null && stream.Length > 0 && !string.IsNullOrEmpty(filename))
            {
                EDataType destination = ImageUploader == ImageDestination.FileUploader ? EDataType.File : EDataType.Image;
                Task task = Task.CreateDataUploaderTask(EDataType.Image, stream, filename, destination);
                StartUpload(task);
            }
        }

        public static void ShortenURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Task task = Task.CreateURLShortenerTask(url);
                StartUpload(task);
            }
        }

        private static void StartUpload(Task task)
        {
            Tasks.Add(task);
            task.Info.ID = Tasks.Count - 1;
            task.UploadPreparing += new Task.TaskEventHandler(task_UploadPreparing);
            task.UploadStarted += new Task.TaskEventHandler(task_UploadStarted);
            task.UploadProgressChanged += new Task.TaskEventHandler(task_UploadProgressChanged);
            task.UploadCompleted += new Task.TaskEventHandler(task_UploadCompleted);
            CreateListViewItem(task.Info);
            StartTasks();
        }

        private static void StartTasks()
        {
            int workingTasksCount = Tasks.Count(x => x.IsWorking);
            Task[] inQueueTasks = Tasks.Where(x => x.Status == TaskStatus.InQueue).ToArray();

            if (inQueueTasks.Length > 0)
            {
                int len;

                if (Program.Settings.UploadLimit == 0)
                {
                    len = inQueueTasks.Length;
                }
                else
                {
                    len = (Program.Settings.UploadLimit - workingTasksCount).Between(0, inQueueTasks.Length);
                }

                for (int i = 0; i < len; i++)
                {
                    inQueueTasks[i].Start();
                }
            }
        }

        public static void StopUpload(int index)
        {
            if (Tasks.Count < index)
            {
                Tasks[index].Stop();
            }
        }

        public static void UpdateProxySettings()
        {
            ProxySettings proxy = new ProxySettings();
            if (!string.IsNullOrEmpty(Program.Settings.ProxySettings.Host))
            {
                proxy.ProxyConfig = EProxyConfigType.ManualProxy;
            }
            proxy.ProxyActive = Program.Settings.ProxySettings;
            Uploader.ProxySettings = proxy;
        }

        private static void ChangeListViewItemStatus(UploadInfo info)
        {
            if (ListViewControl != null)
            {
                ListViewItem lvi = ListViewControl.Items[info.ID];
                lvi.SubItems[1].Text = info.Status;
            }
        }

        private static void CreateListViewItem(UploadInfo info)
        {
            if (ListViewControl != null)
            {
                Program.MyLogger.WriteLine("Upload in queue. ID: {0}, Job: {1}, Type: {2}, Host: {3}", info.ID, info.Job, info.UploadDestination, info.UploaderHost);

                ListViewItem lvi = new ListViewItem();
                lvi.Text = info.FileName;
                lvi.SubItems.Add("In queue");
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(info.DataType.ToString());
                lvi.SubItems.Add(info.UploaderHost);
                lvi.SubItems.Add(string.Empty);
                lvi.BackColor = info.ID % 2 == 0 ? Color.White : Color.WhiteSmoke;
                lvi.ImageIndex = 3;
                ListViewControl.Items.Add(lvi);
                lvi.EnsureVisible();
                ListViewControl.FillLastColumn();
            }
        }

        private static void task_UploadPreparing(UploadInfo info)
        {
            Program.MyLogger.WriteLine("Upload preparing. ID: {0}", info.ID);
            ChangeListViewItemStatus(info);
        }

        private static void task_UploadStarted(UploadInfo info)
        {
            string status = string.Format("Upload started. ID: {0}, Filename: {1}", info.ID, info.FileName);
            if (!string.IsNullOrEmpty(info.FilePath)) status += ", Filepath: " + info.FilePath;
            Program.MyLogger.WriteLine(status);

            ListViewItem lvi = ListViewControl.Items[info.ID];
            lvi.Text = info.FileName;
            lvi.SubItems[1].Text = info.Status;
            lvi.ImageIndex = 0;
        }

        private static void task_UploadProgressChanged(UploadInfo info)
        {
            if (ListViewControl != null)
            {
                ListViewItem lvi = ListViewControl.Items[info.ID];
                lvi.SubItems[1].Text = string.Format("{0:0.0}%", info.Progress.Percentage);
                lvi.SubItems[2].Text = string.Format("{0} / {1}", Helpers.ProperFileSize(info.Progress.Position), Helpers.ProperFileSize(info.Progress.Length));

                if (info.Progress.Speed > 0)
                {
                    lvi.SubItems[3].Text = Helpers.ProperFileSize((long)info.Progress.Speed, false, "/s");
                }

                lvi.SubItems[4].Text = Helpers.ProperTimeSpan(info.Progress.Elapsed);
                lvi.SubItems[5].Text = Helpers.ProperTimeSpan(info.Progress.Remaining);
                UpdateTrayIcon();
            }
        }

        private static void task_UploadCompleted(UploadInfo info)
        {
            try
            {
                if (ListViewControl != null && info != null && info.Result != null)
                {
                    ListViewItem lvi = ListViewControl.Items[info.ID];
                    lvi.Tag = info.Result;

                    if (info.Result.IsError)
                    {
                        string errors = string.Join("\r\n\r\n", info.Result.Errors.ToArray());

                        Program.MyLogger.WriteLine("Upload failed. ID: {0}, Filename: {1}, Errors:\r\n{2}", info.ID, info.FileName, errors);

                        lvi.SubItems[1].Text = "Error";
                        lvi.SubItems[8].Text = string.Empty;
                        lvi.ImageIndex = 1;

                        if (Program.Settings.PlaySoundAfterUpload)
                        {
                            SystemSounds.Asterisk.Play();
                        }
                    }
                    else
                    {
                        Program.MyLogger.WriteLine("Upload completed. ID: {0}, Filename: {1}, URL: {2}, Duration: {3}ms", info.ID, info.FileName,
                            info.Result.URL, (int)info.UploadDuration.TotalMilliseconds);

                        lvi.Text = info.FileName;
                        lvi.SubItems[1].Text = info.Status;
                        lvi.ImageIndex = 2;

                        if (!string.IsNullOrEmpty(info.Result.URL))
                        {
                            string url = string.IsNullOrEmpty(info.Result.ShortenedURL) ? info.Result.URL : info.Result.ShortenedURL;

                            lvi.SubItems[8].Text = url;

                            if (Program.Settings.ClipboardAutoCopy)
                            {
                                Helpers.CopyTextSafely(url);
                            }

                            if (Program.Settings.SaveHistory)
                            {
                                HistoryManager.AddHistoryItemAsync(Program.HistoryFilePath, info.GetHistoryItem());
                            }

                            if (Program.mainForm.niTray.Visible)
                            {
                                Program.mainForm.niTray.Tag = url;
                                Program.mainForm.niTray.ShowBalloonTip(5000, "ShareX - Upload completed", url, ToolTipIcon.Info);
                            }
                        }

                        if (Program.Settings.PlaySoundAfterUpload)
                        {
                            SystemSounds.Exclamation.Play();
                        }
                    }

                    lvi.EnsureVisible();
                }
            }
            finally
            {
                StartTasks();
                UpdateTrayIcon();
            }
        }

        public static void UpdateTrayIcon()
        {
            if (Program.mainForm.niTray.Visible)
            {
                IEnumerable<Task> workingTasks = Tasks.Where(x => x != null && x.IsWorking && x.Info != null && x.Info.Progress != null);
                Icon icon = null;

                if (workingTasks.Count() > 0)
                {
                    double averageProgress = workingTasks.Average(x => x.Info.Progress.Percentage);
                    int index = (int)(averageProgress / 100 * (trayIcons.Length - 1));
                    icon = trayIcons.ReturnIfValidIndex(index) ?? trayIcons.Last();
                }
                else
                {
                    icon = trayIcons.Last();
                }

                if (Program.mainForm.niTray.Icon != icon)
                {
                    Program.mainForm.niTray.Icon = icon;
                }
            }
        }
    }
}