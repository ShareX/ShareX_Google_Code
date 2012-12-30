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

using HelpersLib;
using HelpersLib.Hotkey;
using HistoryLib;
using ScreenCapture;
using ShareX.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UpdateCheckerLib;
using UploadersLib;

namespace ShareX
{
    public partial class MainForm : HotkeyForm
    {
        public bool IsReady { get; private set; }

        public HotkeyManager HotkeyManager { get; private set; }

        private bool trayClose;
        private UploadInfoManager uim;

        public MainForm()
        {
            InitControls();
            UpdateControls();
        }

        private void AfterLoadJobs()
        {
            LoadSettings();

            if (Program.IsHotkeysAllowed)
            {
                InitHotkeys();
            }

            if (Program.Settings.AutoCheckUpdate)
            {
                new Thread(CheckUpdate).Start();
            }

            IsReady = true;

            Program.MyLogger.WriteLine("Startup time: {0}ms", Program.StartTimer.ElapsedMilliseconds);

            UseCommandLineArgs(Environment.GetCommandLineArgs());
        }

        private void AfterShownJobs()
        {
            ShowActivate();
        }

        private void InitControls()
        {
            InitializeComponent();

            Text = Program.Title;
            Icon = Resources.ShareX;

            AddMultiEnumItems<AfterCaptureTasks>(x => Program.Settings.AfterCaptureTasks = Program.Settings.AfterCaptureTasks.Swap(x),
                tsddbAfterCaptureTasks, tsmiTrayAfterCaptureTasks);
            AddMultiEnumItems<AfterUploadTasks>(x => Program.Settings.AfterUploadTasks = Program.Settings.AfterUploadTasks.Swap(x),
                tsddbAfterUploadTasks, tsmiTrayAfterUploadTasks);
            AddEnumItems<ImageDestination>(x => Program.Settings.ImageUploaderDestination = x, tsmiImageUploaders, tsmiTrayImageUploaders);
            AddEnumItems<TextDestination>(x => Program.Settings.TextUploaderDestination = x, tsmiTextUploaders, tsmiTrayTextUploaders);
            AddEnumItems<FileDestination>(x => Program.Settings.FileUploaderDestination = x, tsmiFileUploaders, tsmiTrayFileUploaders);
            AddEnumItems<UrlShortenerType>(x => Program.Settings.URLShortenerDestination = x, tsmiURLShorteners, tsmiTrayURLShorteners);
            AddEnumItems<SocialNetworkingService>(x => Program.Settings.SocialServiceDestination = x, tsmiSocialServices, tsmiTraySocialServices);

            tsbDebug.Visible = Program.IsDebug;

            ImageList il = new ImageList();
            il.ColorDepth = ColorDepth.Depth32Bit;
            il.Images.Add(Properties.Resources.navigation_090_button);
            il.Images.Add(Properties.Resources.cross_button);
            il.Images.Add(Properties.Resources.tick_button);
            il.Images.Add(Properties.Resources.navigation_000_button);
            lvUploads.SmallImageList = il;
            lvUploads.FillLastColumn();

            TaskManager.ListViewControl = lvUploads;
            uim = new UploadInfoManager(lvUploads);
        }

        private void UpdateDestinationStates()
        {
            if (Program.UploadersConfig != null)
            {
                EnableDisableToolStripMenuItems<ImageDestination>(tsmiImageUploaders, tsmiTrayImageUploaders);
                EnableDisableToolStripMenuItems<TextDestination>(tsmiTextUploaders, tsmiTrayTextUploaders);
                EnableDisableToolStripMenuItems<FileDestination>(tsmiFileUploaders, tsmiTrayFileUploaders);
                EnableDisableToolStripMenuItems<UrlShortenerType>(tsmiURLShorteners, tsmiTrayURLShorteners);
                EnableDisableToolStripMenuItems<SocialNetworkingService>(tsmiSocialServices, tsmiTraySocialServices);
            }
        }

        private void AddEnumItems<T>(Action<T> selectedEnum, params ToolStripDropDownItem[] parents)
        {
            string[] enums = Helpers.GetEnumDescriptions<T>();

            foreach (ToolStripDropDownItem parent in parents)
            {
                for (int i = 0; i < enums.Length; i++)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(enums[i]);

                    int index = i;

                    tsmi.Click += (sender, e) =>
                    {
                        foreach (ToolStripDropDownItem parent2 in parents)
                        {
                            for (int i2 = 0; i2 < enums.Length; i2++)
                            {
                                ToolStripMenuItem tsmi2 = (ToolStripMenuItem)parent2.DropDownItems[i2];
                                tsmi2.Checked = index == i2;
                            }
                        }

                        selectedEnum((T)Enum.ToObject(typeof(T), index));

                        UpdateUploaderMenuNames();
                    };

                    parent.DropDownItems.Add(tsmi);
                }
            }
        }

        private void SetEnumChecked<T>(T value, params ToolStripDropDownItem[] parents)
        {
            int index = Helpers.GetEnumMemberIndex(value);

            foreach (ToolStripDropDownItem parent in parents)
            {
                ((ToolStripMenuItem)parent.DropDownItems[index]).Checked = true;
            }
        }

        private void AddMultiEnumItems<T>(Action<T> selectedEnum, params ToolStripDropDownItem[] parents)
        {
            string[] enums = Enum.GetValues(typeof(T)).Cast<Enum>().Skip(1).Select(x => x.GetDescription()).ToArray();

            foreach (ToolStripDropDownItem parent in parents)
            {
                for (int i = 0; i < enums.Length; i++)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(enums[i]);

                    int index = i;

                    tsmi.Click += (sender, e) =>
                    {
                        foreach (ToolStripDropDownItem parent2 in parents)
                        {
                            ToolStripMenuItem tsmi2 = (ToolStripMenuItem)parent2.DropDownItems[index];
                            tsmi2.Checked = !tsmi2.Checked;
                        }

                        selectedEnum((T)Enum.ToObject(typeof(T), 1 << index));

                        UpdateUploaderMenuNames();
                    };

                    parent.DropDownItems.Add(tsmi);
                }
            }
        }

        private void SetMultiEnumChecked(Enum value, params ToolStripDropDownItem[] parents)
        {
            for (int i = 0; i < parents[0].DropDownItems.Count; i++)
            {
                foreach (ToolStripDropDownItem parent in parents)
                {
                    ToolStripMenuItem tsmi = (ToolStripMenuItem)parent.DropDownItems[i];
                    tsmi.Checked = value.HasFlag(1 << i);
                }
            }
        }

        private void EnableDisableToolStripMenuItems<T>(params ToolStripDropDownItem[] parents)
        {
            foreach (ToolStripDropDownItem parent in parents)
            {
                for (int i = 0; i < parent.DropDownItems.Count; i++)
                {
                    parent.DropDownItems[i].Enabled = Program.UploadersConfig.IsActive<T>(i);
                }
            }
        }

        private void UpdateControls()
        {
            cmsUploadInfo.SuspendLayout();

            tsmiStopUpload.Visible = tsmiOpen.Visible = tsmiCopy.Visible = tsmiShowErrors.Visible = tsmiShowResponse.Visible =
                tsmiUploadSelectedFile.Visible = tsmiClearList.Visible = tssUploadInfo1.Visible = false;
            pbPreview.Reset();
            uim.RefreshSelectedItems();

            if (lvUploads.SelectedItems.Count > 0)
            {
                if (GetCurrentTasks().Any(x => x.IsWorking))
                {
                    tsmiStopUpload.Visible = true;
                }
                else
                {
                    if (uim.IsSelectedItemsValid())
                    {
                        if (uim.SelectedItems[0].Info.Result.IsError)
                        {
                            tsmiShowErrors.Visible = true;
                        }
                        else
                        {
                            // Open
                            tsmiOpen.Visible = true;

                            tsmiOpenURL.Enabled = uim.SelectedItems[0].IsURLExist;
                            tsmiOpenShortenedURL.Enabled = uim.SelectedItems[0].IsShortenedURLExist;
                            tsmiOpenThumbnailURL.Enabled = uim.SelectedItems[0].IsThumbnailURLExist;
                            tsmiOpenDeletionURL.Enabled = uim.SelectedItems[0].IsDeletionURLExist;

                            tsmiOpenFile.Enabled = uim.SelectedItems[0].IsFileExist;
                            tsmiOpenFolder.Enabled = uim.SelectedItems[0].IsFileExist;

                            // Copy
                            tsmiCopy.Visible = true;

                            tsmiCopyURL.Enabled = uim.SelectedItems.Any(x => x.IsURLExist);
                            tsmiCopyShortenedURL.Enabled = uim.SelectedItems.Any(x => x.IsShortenedURLExist);
                            tsmiCopyThumbnailURL.Enabled = uim.SelectedItems.Any(x => x.IsThumbnailURLExist);
                            tsmiCopyDeletionURL.Enabled = uim.SelectedItems.Any(x => x.IsDeletionURLExist);

                            tsmiCopyFile.Enabled = uim.SelectedItems[0].IsFileExist;
                            tsmiCopyImage.Enabled = uim.SelectedItems[0].IsImageFile;
                            tsmiCopyText.Enabled = uim.SelectedItems[0].IsTextFile;

                            tsmiCopyHTMLLink.Enabled = uim.SelectedItems.Any(x => x.IsURLExist);
                            tsmiCopyHTMLImage.Enabled = uim.SelectedItems.Any(x => x.IsImageURL);
                            tsmiCopyHTMLLinkedImage.Enabled = uim.SelectedItems.Any(x => x.IsImageURL && x.IsThumbnailURLExist);

                            tsmiCopyForumLink.Enabled = uim.SelectedItems.Any(x => x.IsURLExist);
                            tsmiCopyForumImage.Enabled = uim.SelectedItems.Any(x => x.IsImageURL && x.IsURLExist);
                            tsmiCopyForumLinkedImage.Enabled = uim.SelectedItems.Any(x => x.IsImageURL && x.IsThumbnailURLExist);

                            tsmiCopyFilePath.Enabled = uim.SelectedItems.Any(x => x.IsFilePathValid);
                            tsmiCopyFileName.Enabled = uim.SelectedItems.Any(x => x.IsFilePathValid);
                            tsmiCopyFileNameWithExtension.Enabled = uim.SelectedItems.Any(x => x.IsFilePathValid);
                            tsmiCopyFolder.Enabled = uim.SelectedItems.Any(x => x.IsFilePathValid);

                            if (!scMain.Panel2Collapsed)
                            {
                                if (uim.SelectedItems[0].IsImageFile)
                                {
                                    pbPreview.LoadImageFromFile(uim.SelectedItems[0].Info.FilePath);
                                }
                                else if (uim.SelectedItems[0].IsImageURL)
                                {
                                    pbPreview.LoadImageFromURL(uim.SelectedItems[0].Info.Result.URL);
                                }
                            }
                        }

                        if ((uim.SelectedItems[0].Info.Result.IsError || Program.IsDebug) && !string.IsNullOrEmpty(uim.SelectedItems[0].Info.Result.Response))
                        {
                            tsmiShowResponse.Visible = true;
                        }

                        tsmiUploadSelectedFile.Visible = uim.SelectedItems[0].IsFileExist;
                    }
                }
            }

            tsmiClearList.Visible = tssUploadInfo1.Visible = lvUploads.Items.Count > 0;

            cmsUploadInfo.ResumeLayout();
        }

        private void LoadSettings()
        {
            niTray.Icon = Resources.sharex_16px_6;
            niTray.Visible = Program.Settings.ShowTray;

            SetMultiEnumChecked(Program.Settings.AfterCaptureTasks, tsddbAfterCaptureTasks, tsmiTrayAfterCaptureTasks);
            SetMultiEnumChecked(Program.Settings.AfterUploadTasks, tsddbAfterUploadTasks, tsmiTrayAfterUploadTasks);
            SetEnumChecked(Program.Settings.ImageUploaderDestination, tsmiImageUploaders, tsmiTrayImageUploaders);
            SetEnumChecked(Program.Settings.TextUploaderDestination, tsmiTextUploaders, tsmiTrayTextUploaders);
            SetEnumChecked(Program.Settings.FileUploaderDestination, tsmiFileUploaders, tsmiTrayFileUploaders);
            SetEnumChecked(Program.Settings.URLShortenerDestination, tsmiURLShorteners, tsmiTrayURLShorteners);
            SetEnumChecked(Program.Settings.SocialServiceDestination, tsmiSocialServices, tsmiTraySocialServices);

            UpdateUploaderMenuNames();

            UploadManager.UpdateProxySettings();

            if (Program.Settings.PreviewSplitterDistance > 0)
            {
                scMain.SplitterDistance = Program.Settings.PreviewSplitterDistance;
            }

            UpdatePreviewSplitter();

            AddDefaultExternalPrograms();

            if (Program.Settings.WatchFolderEnabled)
            {
                foreach (WatchFolder watchFolder in Program.Settings.WatchFolderList)
                {
                    watchFolder.Enable();
                }
            }
        }

        private void AddDefaultExternalPrograms()
        {
            if (Program.Settings.ExternalPrograms == null)
            {
                Program.Settings.ExternalPrograms = new List<ExternalProgram>();
                AddExternalProgram("Paint", "mspaint.exe");
                AddExternalProgram("Paint.NET", "PaintDotNet.exe");
                AddExternalProgram("Adobe Photoshop", "Photoshop.exe");
                AddExternalProgram("IrfanView", "i_view32.exe");
                AddExternalProgram("XnView", "xnview.exe");
            }
        }

        private void AddExternalProgram(string name, string filename)
        {
            ExternalProgram externalProgram = RegistryHelper.FindProgram(name, filename);

            if (externalProgram != null)
            {
                Program.Settings.ExternalPrograms.Add(externalProgram);
            }
        }

        private void UpdateUploaderMenuNames()
        {
            string imageUploader = Program.Settings.ImageUploaderDestination == ImageDestination.FileUploader ?
                Program.Settings.FileUploaderDestination.GetDescription() : Program.Settings.ImageUploaderDestination.GetDescription();
            tsmiImageUploaders.Text = tsmiTrayImageUploaders.Text = "Image uploader: " + imageUploader;

            string textUploader = Program.Settings.TextUploaderDestination == TextDestination.FileUploader ?
                Program.Settings.FileUploaderDestination.GetDescription() : Program.Settings.TextUploaderDestination.GetDescription();
            tsmiTextUploaders.Text = tsmiTrayTextUploaders.Text = "Text uploader: " + textUploader;

            tsmiFileUploaders.Text = tsmiTrayFileUploaders.Text = "File uploader: " + Program.Settings.FileUploaderDestination.GetDescription();

            tsmiURLShorteners.Text = tsmiTrayURLShorteners.Text = "URL shortener: " + Program.Settings.URLShortenerDestination.GetDescription();

            tsmiSocialServices.Text = tsmiTraySocialServices.Text = "Social networking services: " + Program.Settings.SocialServiceDestination.GetDescription();
        }

        private void CheckUpdate()
        {
            UpdateChecker updateChecker = new UpdateChecker(Links.URL_UPDATE, Application.ProductName, Program.AssemblyVersion,
                ReleaseChannelType.Stable, Uploader.ProxySettings.GetWebProxy);
            updateChecker.CheckUpdate();

            if (updateChecker.UpdateInfo != null && updateChecker.UpdateInfo.Status == UpdateStatus.UpdateRequired)
            {
                string updateText = string.Format("Would you like to download the update?\r\n\r\n{0} is current version.\r\n{1} is latest version.",
                    updateChecker.UpdateInfo.CurrentVersion, updateChecker.UpdateInfo.LatestVersion);

                if (MessageBox.Show(updateText, "ShareX update is available", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    DownloaderForm downloader = new DownloaderForm(updateChecker.UpdateInfo.URL, updateChecker.Proxy, updateChecker.UpdateInfo.Summary);
                    downloader.ShowDialog();
                    if (downloader.Status == DownloaderFormStatus.InstallStarted) Application.Exit();
                }
            }
        }

        public void UseCommandLineArgs(string[] args)
        {
            if (args != null && args.Length > 1)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].Equals("-clipboardupload", StringComparison.InvariantCultureIgnoreCase))
                    {
                        UploadManager.ClipboardUpload();
                    }
                    else if (args[i][0] != '-')
                    {
                        UploadManager.UploadFile(args[i]);
                    }
                }
            }
        }

        private Task[] GetCurrentTasks()
        {
            if (lvUploads.SelectedItems.Count > 0)
            {
                return lvUploads.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag as Task).Where(x => x != null).ToArray();
            }

            return null;
        }

        private UploadInfo GetCurrentUploadInfo()
        {
            UploadInfo info = null;
            Task[] tasks = GetCurrentTasks();

            if (tasks != null && tasks.Length > 0)
            {
                info = tasks[0].Info;
            }

            return info;
        }

        private void RemoveSelectedItems()
        {
            lvUploads.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag as Task).Where(x => x != null && !x.IsWorking).ForEach(x => TaskManager.Remove(x));
        }

        private void RemoveAllItems()
        {
            lvUploads.Items.Cast<ListViewItem>().Select(x => x.Tag as Task).Where(x => x != null && !x.IsWorking).ForEach(x => TaskManager.Remove(x));
        }

        private void UpdatePreviewSplitter()
        {
            if (Program.Settings.IsPreviewCollapsed)
            {
                tsmiShowPreview.Text = "Show preview section";
            }
            else
            {
                tsmiShowPreview.Text = "Hide preview section";
            }

            scMain.Panel2Collapsed = Program.Settings.IsPreviewCollapsed;
        }

        public void ShowActivate()
        {
            if (!Visible)
            {
                Show();
            }

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            BringToFront();
            Activate();
        }

        #region Form events

        protected override void SetVisibleCore(bool value)
        {
            if (value && !IsHandleCreated)
            {
                if (Program.IsSilentRun && Program.Settings.ShowTray)
                {
                    CreateHandle();
                    value = false;
                }

                AfterLoadJobs();
            }

            base.SetVisibleCore(value);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            AfterShownJobs();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && Program.Settings.ShowTray && !trayClose)
            {
                e.Cancel = true;
                Hide();
                Program.Settings.SaveAsync();
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) ||
                e.Data.GetDataPresent(DataFormats.Bitmap, false) ||
                e.Data.GetDataPresent(DataFormats.Text, false))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            UploadManager.DragDropUpload(e.Data);
        }

        private void tsbClipboardUpload_Click(object sender, EventArgs e)
        {
            UploadManager.ClipboardUploadWithContentViewer();
        }

        private void tsbFileUpload_Click(object sender, EventArgs e)
        {
            UploadManager.UploadFile();
        }

        private void tsddbDestinations_DropDownOpened(object sender, EventArgs e)
        {
            UpdateDestinationStates();
        }

        private void tsddbUploadersConfig_Click(object sender, EventArgs e)
        {
            if (Program.UploadersConfig == null)
            {
                Program.UploaderSettingsResetEvent.WaitOne();
            }

            UploadersConfigForm uploadersConfigForm = new UploadersConfigForm(Program.UploadersConfig, new UploadersAPIKeys()) { Icon = this.Icon };
            uploadersConfigForm.ShowDialog();
            uploadersConfigForm.Config.SaveAsync(Program.UploadersConfigFilePath);
        }

        private void tsmiTestImageUpload_Click(object sender, EventArgs e)
        {
            UploadManager.RunImageTask(Resources.ShareXLogo);
        }

        private void tsmiTestTextUpload_Click(object sender, EventArgs e)
        {
            UploadManager.UploadText(Program.ApplicationName + " text upload test");
        }

        private void tsmiTestFileUpload_Click(object sender, EventArgs e)
        {
            UploadManager.UploadImage(Resources.ShareXLogo, ImageDestination.FileUploader);
        }

        private void tsmiTestURLShortener_Click(object sender, EventArgs e)
        {
            UploadManager.ShortenURL(Links.URL_WEBSITE);
        }

        private void tsmiTestUploaders_Click(object sender, EventArgs e)
        {
            using (UploadTestForm form = new UploadTestForm())
            {
                form.Icon = Icon;
                form.ShowDialog();
            }
        }

        private void tsmiTestShapeCapture_Click(object sender, EventArgs e)
        {
            new RegionCapturePreview(Program.Settings.SurfaceOptions).Show();
        }

        private void tsmiCursorHelper_Click(object sender, EventArgs e)
        {
            using (DialogColor colorForm = new DialogColor())
            {
                colorForm.Icon = Icon;
                colorForm.ScreenPicker = true;
                colorForm.ShowDialog();
            }
        }

        private void tsmiScreenRecorderGIF_Click(object sender, EventArgs e)
        {
            ScreenRecordForm recordForm = new ScreenRecordForm();
            Screenshot.DrawCursor = Program.Settings.ShowCursor;
            recordForm.GIFQuality = Program.Settings.ImageGIFQuality;
            recordForm.Icon = Icon;
            recordForm.Show();
        }

        private void tsbScreenshotsFolder_Click(object sender, EventArgs e)
        {
            Helpers.OpenFolder(Program.ScreenshotsPath);
        }

        private void tsbHistory_Click(object sender, EventArgs e)
        {
            HistoryManager.ConvertHistoryToNewFormat(Program.HistoryFilePath, Program.OldHistoryFilePath);

            using (HistoryForm historyForm = new HistoryForm(Program.HistoryFilePath))
            {
                Program.Settings.HistoryWindowState.AutoHandleFormState(historyForm);
                historyForm.Icon = Icon;
                historyForm.Text = "ShareX - History: " + Program.HistoryFilePath;
                historyForm.ShowDialog();
            }
        }

        private void tsbImageHistory_Click(object sender, EventArgs e)
        {
            HistoryManager.ConvertHistoryToNewFormat(Program.HistoryFilePath, Program.OldHistoryFilePath);

            using (ImageHistoryForm imageHistoryForm = new ImageHistoryForm(Program.HistoryFilePath,
                Program.Settings.ImageHistoryViewMode, Program.Settings.ImageHistoryThumbnailSize))
            {
                Program.Settings.ImageHistoryWindowState.AutoHandleFormState(imageHistoryForm);
                imageHistoryForm.Icon = Icon;
                imageHistoryForm.Text = "ShareX - Image history: " + Program.HistoryFilePath;
                imageHistoryForm.ShowDialog();

                Program.Settings.ImageHistoryViewMode = imageHistoryForm.ViewMode;
                Program.Settings.ImageHistoryThumbnailSize = imageHistoryForm.ThumbnailSize;
            }
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm() { Icon = this.Icon }.ShowDialog();
            UploadManager.UpdateProxySettings();
            Program.Settings.SaveAsync();
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            new AboutForm() { Icon = this.Icon }.ShowDialog();
        }

        private void lvUploads_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void lvUploads_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                UpdateControls();
                cmsUploadInfo.Show(lvUploads, e.X + 1, e.Y + 1);
            }
        }

        private void lvUploads_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                uim.TryOpen();
            }
        }

        private void scMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Program.Settings.PreviewSplitterDistance = scMain.SplitterDistance;
        }

        private void lvUploads_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                default: return;
                case Keys.Enter:
                    uim.TryOpen();
                    break;
                case Keys.Control | Keys.Enter:
                    uim.OpenFile();
                    break;
                case Keys.Control | Keys.C:
                    uim.CopyURL();
                    break;
                case Keys.Delete:
                    RemoveSelectedItems();
                    break;
            }

            e.Handled = true;
        }

        #region Tray events

        private void niTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowActivate();
            }
        }

        private void niTray_BalloonTipClicked(object sender, EventArgs e)
        {
            string url = niTray.Tag as string;

            if (!string.IsNullOrEmpty(url))
            {
                Helpers.LoadBrowserAsync(url);
            }
        }

        private void tsmiTrayExit_Click(object sender, EventArgs e)
        {
            trayClose = true;
            Close();
        }

        #endregion Tray events

        #region UploadInfoMenu events

        private void tsmiStopUpload_Click(object sender, EventArgs e)
        {
            if (lvUploads.SelectedItems.Count > 0)
            {
                foreach (Task task in GetCurrentTasks())
                {
                    task.Stop();
                }
            }
        }

        private void tsmiOpenURL_Click(object sender, EventArgs e)
        {
            uim.OpenURL();
        }

        private void tsmiOpenShortenedURL_Click(object sender, EventArgs e)
        {
            uim.OpenShortenedURL();
        }

        private void tsmiOpenThumbnailURL_Click(object sender, EventArgs e)
        {
            uim.OpenThumbnailURL();
        }

        private void tsmiOpenDeletionURL_Click(object sender, EventArgs e)
        {
            uim.OpenDeletionURL();
        }

        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            uim.OpenFile();
        }

        private void tsmiOpenFolder_Click(object sender, EventArgs e)
        {
            uim.OpenFolder();
        }

        private void tsmiCopyURL_Click(object sender, EventArgs e)
        {
            uim.CopyURL();
        }

        private void tsmiCopyShortenedURL_Click(object sender, EventArgs e)
        {
            uim.CopyShortenedURL();
        }

        private void tsmiCopyThumbnailURL_Click(object sender, EventArgs e)
        {
            uim.CopyThumbnailURL();
        }

        private void tsmiCopyDeletionURL_Click(object sender, EventArgs e)
        {
            uim.CopyDeletionURL();
        }

        private void tsmiCopyFile_Click(object sender, EventArgs e)
        {
            uim.CopyFile();
        }

        private void tsmiCopyImage_Click(object sender, EventArgs e)
        {
            uim.CopyImage();
        }

        private void tsmiCopyText_Click(object sender, EventArgs e)
        {
            uim.CopyText();
        }

        private void tsmiCopyHTMLLink_Click(object sender, EventArgs e)
        {
            uim.CopyHTMLLink();
        }

        private void tsmiCopyHTMLImage_Click(object sender, EventArgs e)
        {
            uim.CopyHTMLImage();
        }

        private void tsmiCopyHTMLLinkedImage_Click(object sender, EventArgs e)
        {
            uim.CopyHTMLLinkedImage();
        }

        private void tsmiCopyForumLink_Click(object sender, EventArgs e)
        {
            uim.CopyForumLink();
        }

        private void tsmiCopyForumImage_Click(object sender, EventArgs e)
        {
            uim.CopyForumImage();
        }

        private void tsmiCopyForumLinkedImage_Click(object sender, EventArgs e)
        {
            uim.CopyForumLinkedImage();
        }

        private void tsmiCopyFilePath_Click(object sender, EventArgs e)
        {
            uim.CopyFilePath();
        }

        private void tsmiCopyFileName_Click(object sender, EventArgs e)
        {
            uim.CopyFileName();
        }

        private void tsmiCopyFileNameWithExtension_Click(object sender, EventArgs e)
        {
            uim.CopyFileNameWithExtension();
        }

        private void tsmiCopyFolder_Click(object sender, EventArgs e)
        {
            uim.CopyFolder();
        }

        private void tsmiShowErrors_Click(object sender, EventArgs e)
        {
            uim.ShowErrors();
        }

        private void tsmiShowResponse_Click(object sender, EventArgs e)
        {
            uim.ShowResponse();
        }

        private void tsmiUploadSelectedFile_Click(object sender, EventArgs e)
        {
            uim.Upload();
        }

        private void tsmiClearList_Click(object sender, EventArgs e)
        {
            RemoveAllItems();
        }

        private void tsmiUploadFile_Click(object sender, EventArgs e)
        {
            UploadManager.UploadFile();
        }

        private void tsmiShowPreview_Click(object sender, EventArgs e)
        {
            Program.Settings.IsPreviewCollapsed = !Program.Settings.IsPreviewCollapsed;
            UpdatePreviewSplitter();
            UpdateControls();
        }

        #endregion UploadInfoMenu events

        #endregion Form events
    }
}