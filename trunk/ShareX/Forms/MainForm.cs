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
using System.Threading;
using System.Windows.Forms;
using HelpersLib;
using HelpersLib.Hotkey;
using HistoryLib;
using ScreenCapture;
using ShareX.Properties;
using UpdateCheckerLib;
using UploadersLib;
using UploadersLib.HelperClasses;

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

            this.Text = Program.Title;
            this.Icon = Resources.ShareX;

            AddEnumItems<ImageDestination>(x => Program.Settings.ImageUploaderDestination = (ImageDestination)x, tsmiImageUploaders, tsmiTrayImageUploaders);
            AddEnumItems<TextDestination>(x => Program.Settings.TextUploaderDestination = (TextDestination)x, tsmiTextUploaders, tsmiTrayTextUploaders);
            AddEnumItems<FileDestination>(x => Program.Settings.FileUploaderDestination = (FileDestination)x, tsmiFileUploaders, tsmiTrayFileUploaders);
            AddEnumItems<UrlShortenerType>(x => Program.Settings.URLShortenerDestination = (UrlShortenerType)x, tsmiURLShorteners, tsmiTrayURLShorteners);

            tsbDebug.Visible = Program.IsDebug;

            ImageList il = new ImageList();
            il.ColorDepth = ColorDepth.Depth32Bit;
            il.Images.Add(Properties.Resources.navigation_090_button);
            il.Images.Add(Properties.Resources.cross_button);
            il.Images.Add(Properties.Resources.tick_button);
            il.Images.Add(Properties.Resources.navigation_000_button);
            lvUploads.SmallImageList = il;
            lvUploads.FillLastColumn();

            UploadManager.ListViewControl = lvUploads;
            uim = new UploadInfoManager(lvUploads);
        }

        private void AddEnumItems<T>(Action<int> selectedIndex, params ToolStripMenuItem[] parents)
        {
            int enumLength = Helpers.GetEnumLength<T>();

            foreach (ToolStripMenuItem parent in parents)
            {
                for (int i = 0; i < enumLength; i++)
                {
                    string description = ((Enum)Enum.ToObject(typeof(T), i)).GetDescription();
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(description);

                    int index = i;

                    tsmi.Click += (sender, e) =>
                    {
                        foreach (ToolStripMenuItem parent2 in parents)
                        {
                            for (int i2 = 0; i2 < enumLength; i2++)
                            {
                                ToolStripMenuItem tsmi2 = (ToolStripMenuItem)parent2.DropDownItems[i2];
                                tsmi2.Checked = index == i2;
                            }
                        }

                        selectedIndex(index);

                        UpdateUploaderMenuNames();
                    };

                    parent.DropDownItems.Add(tsmi);
                }
            }
        }

        private void UpdateControls()
        {
            tsmiUploadFile.Visible = tsmiStopUpload.Visible = tsmiOpen.Visible = tsmiCopy.Visible = tsmiShowErrors.Visible = tsmiShowResponse.Visible = false;
            pbPreview.Reset();
            uim.RefreshInfo();

            if (lvUploads.SelectedIndices.Count > 0)
            {
                int index = lvUploads.SelectedIndices[0];

                if (UploadManager.Tasks[index].IsWorking)
                {
                    tsmiStopUpload.Visible = true;
                }
                else
                {
                    if (uim.Info != null)
                    {
                        if (uim.Info.Result.IsError)
                        {
                            tsmiShowErrors.Visible = tsmiShowResponse.Visible = true;
                        }
                        else
                        {
                            cmsUploadInfo.SuspendLayout();

                            if (uim.SelectedItemCount > 1)
                            {
                                tsmiCopyURL.Text = string.Format("URLs ({0})", uim.SelectedItemCount);
                            }
                            else
                            {
                                tsmiCopyURL.Text = "URL";
                            }

                            // Open
                            tsmiOpen.Visible = true;

                            tsmiOpenURL.Enabled = uim.IsURLExist;
                            tsmiOpenShortenedURL.Enabled = uim.IsShortenedURLExist;
                            tsmiOpenThumbnailURL.Enabled = uim.IsThumbnailURLExist;
                            tsmiOpenDeletionURL.Enabled = uim.IsDeletionURLExist;

                            tsmiOpenFile.Enabled = uim.IsFileExist;
                            tsmiOpenFolder.Enabled = uim.IsFileExist;

                            // Copy
                            tsmiCopy.Visible = true;

                            tsmiCopyURL.Enabled = uim.IsURLExist;
                            tsmiCopyShortenedURL.Enabled = uim.IsShortenedURLExist;
                            tsmiCopyThumbnailURL.Enabled = uim.IsThumbnailURLExist;
                            tsmiCopyDeletionURL.Enabled = uim.IsDeletionURLExist;

                            tsmiCopyFile.Enabled = uim.IsFileExist;
                            tsmiCopyImage.Enabled = uim.IsImageFile;
                            tsmiCopyText.Enabled = uim.IsTextFile;

                            tsmiCopyHTMLLink.Enabled = uim.IsURLExist;
                            tsmiCopyHTMLImage.Enabled = uim.IsImageURL;
                            tsmiCopyHTMLLinkedImage.Enabled = uim.IsImageURL && uim.IsThumbnailURLExist;

                            tsmiCopyForumLink.Enabled = uim.IsURLExist;
                            tsmiCopyForumImage.Enabled = uim.IsImageURL && uim.IsURLExist;
                            tsmiCopyForumLinkedImage.Enabled = uim.IsImageURL && uim.IsThumbnailURLExist;

                            tsmiCopyFilePath.Enabled = uim.IsFilePathValid;
                            tsmiCopyFileName.Enabled = uim.IsFilePathValid;
                            tsmiCopyFileNameWithExtension.Enabled = uim.IsFilePathValid;
                            tsmiCopyFolder.Enabled = uim.IsFilePathValid;

                            cmsUploadInfo.ResumeLayout();

                            if (!scMain.Panel2Collapsed)
                            {
                                if (uim.IsImageFile)
                                {
                                    pbPreview.LoadImageFromFile(uim.Info.FilePath);
                                }
                                else if (uim.IsImageURL)
                                {
                                    pbPreview.LoadImageFromURL(uim.Info.Result.URL);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                tsmiUploadFile.Visible = true;
            }
        }

        private void LoadSettings()
        {
            niTray.Icon = Resources.sharex_16px_6;
            niTray.Visible = Program.Settings.ShowTray;

            int imageUploaderIndex = Helpers.GetEnumMemberIndex(Program.Settings.ImageUploaderDestination);
            ((ToolStripMenuItem)tsmiImageUploaders.DropDownItems[imageUploaderIndex]).Checked = true;
            ((ToolStripMenuItem)tsmiTrayImageUploaders.DropDownItems[imageUploaderIndex]).Checked = true;

            int textUploaderIndex = Helpers.GetEnumMemberIndex(Program.Settings.TextUploaderDestination);
            ((ToolStripMenuItem)tsmiTextUploaders.DropDownItems[textUploaderIndex]).Checked = true;
            ((ToolStripMenuItem)tsmiTrayTextUploaders.DropDownItems[textUploaderIndex]).Checked = true;

            int fileUploaderIndex = Helpers.GetEnumMemberIndex(Program.Settings.FileUploaderDestination);
            ((ToolStripMenuItem)tsmiFileUploaders.DropDownItems[fileUploaderIndex]).Checked = true;
            ((ToolStripMenuItem)tsmiTrayFileUploaders.DropDownItems[fileUploaderIndex]).Checked = true;

            int urlShortenerIndex = Helpers.GetEnumMemberIndex(Program.Settings.URLShortenerDestination);
            ((ToolStripMenuItem)tsmiURLShorteners.DropDownItems[urlShortenerIndex]).Checked = true;
            ((ToolStripMenuItem)tsmiTrayURLShorteners.DropDownItems[urlShortenerIndex]).Checked = true;

            UpdateUploaderMenuNames();

            UploadManager.UpdateProxySettings();

            if (Program.Settings.PreviewSplitterDistance > 0)
            {
                scMain.SplitterDistance = Program.Settings.PreviewSplitterDistance;
            }

            UpdatePreviewSplitter();

            AddDefaultExternalPrograms();
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
            tsmiImageUploaders.Text = tsmiTrayImageUploaders.Text = "Image uploader: " + Program.Settings.ImageUploaderDestination.GetDescription();
            tsmiTextUploaders.Text = tsmiTrayTextUploaders.Text = "Text uploader: " + Program.Settings.TextUploaderDestination.GetDescription();
            tsmiFileUploaders.Text = tsmiTrayFileUploaders.Text = "File uploader: " + Program.Settings.FileUploaderDestination.GetDescription();
            tsmiURLShorteners.Text = tsmiTrayURLShorteners.Text = "URL shortener: " + Program.Settings.URLShortenerDestination.GetDescription();
        }

        private void CheckUpdate()
        {
            UpdateChecker updateChecker = new UpdateChecker(Links.URL_UPDATE, Application.ProductName, Program.AssemblyVersion,
                ReleaseChannelType.Stable, Uploader.ProxySettings.GetWebProxy);
            updateChecker.CheckUpdate();

            if (updateChecker.UpdateInfo != null && updateChecker.UpdateInfo.Status == UpdateStatus.UpdateRequired)
            {
                if (MessageBox.Show("Update found. Do you want to download it?", "Update check", MessageBoxButtons.YesNo,
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

        private UploadInfo GetCurrentUploadInfo()
        {
            UploadInfo info = null;

            if (lvUploads.SelectedItems.Count > 0)
            {
                info = lvUploads.SelectedItems[0].Tag as UploadInfo;
            }

            return info;
        }

        private void UpdatePreviewSplitter()
        {
            if (Program.Settings.IsPreviewCollapsed)
            {
                btnSplitterControl.Image = Resources.application_dock_180;
            }
            else
            {
                btnSplitterControl.Image = Resources.application_dock;
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
            UploadManager.UploadImage(Resources.ShareXLogo);
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

        private void tsmiTestShapeCapture_Click(object sender, EventArgs e)
        {
            new RegionCapturePreview(Program.Settings.SurfaceOptions).Show();
        }

        private void tsbHistory_Click(object sender, EventArgs e)
        {
            new HistoryForm(Program.HistoryFilePath, -1, "ShareX - History").ShowDialog();
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

        private void tsbDonate_Click(object sender, EventArgs e)
        {
            Helpers.LoadBrowserAsync(Links.URL_DONATE);
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

        private void lvUploads_DoubleClick(object sender, EventArgs e)
        {
            uim.OpenURL();
        }

        private void btnSplitterControl_Click(object sender, EventArgs e)
        {
            Program.Settings.IsPreviewCollapsed = !Program.Settings.IsPreviewCollapsed;
            UpdatePreviewSplitter();
            UpdateControls();
        }

        private void scMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Program.Settings.PreviewSplitterDistance = scMain.SplitterDistance;
        }

        #region Tray events

        private void niTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowActivate();
        }

        private void niTray_BalloonTipClicked(object sender, EventArgs e)
        {
            string url = niTray.Tag as string;

            if (!string.IsNullOrEmpty(url))
            {
                Helpers.LoadBrowserAsync(url);
            }
        }

        private void tsmiScreenshotsFolder_Click(object sender, EventArgs e)
        {
            Helpers.OpenFolder(Program.ScreenshotsPath);
        }

        private void tsmiTrayExit_Click(object sender, EventArgs e)
        {
            trayClose = true;
            Close();
        }

        #endregion Tray events

        #region UploadInfoMenu events

        private void tsmiUploadFile_Click(object sender, EventArgs e)
        {
            UploadManager.UploadFile();
        }

        private void tsmiStopUpload_Click(object sender, EventArgs e)
        {
            if (lvUploads.SelectedIndices.Count > 0)
            {
                foreach (int index in lvUploads.SelectedIndices)
                {
                    UploadManager.Tasks[index].Stop();
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

        #endregion UploadInfoMenu events

        #endregion Form events
    }
}