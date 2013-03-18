#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (C) 2008-2013 ShareX Developers

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
using ScreenCapture;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using UploadersLib;

namespace ShareX
{
    public partial class SettingsForm : Form
    {
        private const int MaxBufferSizePower = 14;

        private bool loaded;
        private ContextMenuStrip cmsNameFormatPattern, cmsNameFormatPatternActiveWindow;

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();

            if (Program.IsHotkeysAllowed && Program.MainForm.HotkeyManager != null)
            {
                hmHotkeys.PrepareHotkeys(Program.MainForm.HotkeyManager);
            }
            else
            {
                tcSettings.TabPages.Remove(tpHotkeys);
            }

            loaded = true;
        }

        private void LoadSettings()
        {
            Text = Program.Title + " - Settings";

            // General
            cbShowTray.Checked = Program.Settings.ShowTray;
            cbStartWithWindows.Checked = ShortcutHelper.CheckShortcut(Environment.SpecialFolder.Startup); //RegistryHelper.CheckStartWithWindows();
            cbShellContextMenu.Checked = ShortcutHelper.CheckShortcut(Environment.SpecialFolder.SendTo); //RegistryHelper.CheckShellContextMenu();
            cbCheckUpdates.Checked = Program.Settings.AutoCheckUpdate;
            cbShowAfterCaptureTasksForm.Checked = Program.Settings.ShowAfterCaptureTasksForm;
            cbPlaySoundAfterCapture.Checked = Program.Settings.PlaySoundAfterCapture;
            cbPlaySoundAfterUpload.Checked = Program.Settings.PlaySoundAfterUpload;
            cbTrayBalloonTipAfterUpload.Checked = Program.Settings.TrayBalloonTipAfterUpload;
            cbHistorySave.Checked = Program.Settings.SaveHistory;

            // Paths
            cbUseCustomUploadersConfigPath.Checked = Program.Settings.UseCustomUploadersConfigPath;
            txtCustomUploadersConfigPath.Text = Program.Settings.CustomUploadersConfigPath;
            cbUseCustomHistoryPath.Checked = Program.Settings.UseCustomHistoryPath;
            txtCustomHistoryPath.Text = Program.Settings.CustomHistoryPath;
            cbUseCustomScreenshotsPath.Checked = Program.Settings.UseCustomScreenshotsPath;
            txtCustomScreenshotsPath.Text = Program.Settings.CustomScreenshotsPath;
            txtSaveImageSubFolderPattern.Text = Program.Settings.SaveImageSubFolderPattern;

            // Image - Quality
            cbImageFormat.SelectedIndex = (int)Program.Settings.ImageFormat;
            nudImageJPEGQuality.Value = Program.Settings.ImageJPEGQuality;
            cbImageGIFQuality.SelectedIndex = (int)Program.Settings.ImageGIFQuality;
            nudUseImageFormat2After.Value = Program.Settings.ImageSizeLimit;
            cbImageFormat2.SelectedIndex = (int)Program.Settings.ImageFormat2;

            // Image - Resize
            cbImageAutoResize.Checked = Program.Settings.ImageAutoResize;
            cbImageKeepAspectRatio.Checked = Program.Settings.ImageKeepAspectRatio;
            cbImageUseSmoothScaling.Checked = Program.Settings.ImageUseSmoothScaling;

            switch (Program.Settings.ImageScaleType)
            {
                case ImageScaleType.Percentage:
                    rbImageScaleTypePercentage.Checked = true;
                    break;
                case ImageScaleType.Width:
                    rbImageScaleTypeToWidth.Checked = true;
                    break;
                case ImageScaleType.Height:
                    rbImageScaleTypeToHeight.Checked = true;
                    break;
                case ImageScaleType.Specific:
                    rbImageScaleTypeSpecific.Checked = true;
                    break;
            }

            nudImageScalePercentageWidth.Value = Program.Settings.ImageScalePercentageWidth;
            nudImageScalePercentageHeight.Value = Program.Settings.ImageScalePercentageHeight;
            nudImageScaleToWidth.Value = Program.Settings.ImageScaleToWidth;
            nudImageScaleToHeight.Value = Program.Settings.ImageScaleToHeight;
            nudImageScaleSpecificWidth.Value = Program.Settings.ImageScaleSpecificWidth;
            nudImageScaleSpecificHeight.Value = Program.Settings.ImageScaleSpecificHeight;

            // Image - Other
            btnBorderColor.BackColor = Program.Settings.BorderColor;
            nudBorderSize.Value = Program.Settings.BorderSize;

            // Capture
            cbShowCursor.Checked = Program.Settings.ShowCursor;
            cbCaptureTransparent.Checked = Program.Settings.CaptureTransparent;
            cbCaptureShadow.Enabled = Program.Settings.CaptureTransparent;
            cbCaptureShadow.Checked = Program.Settings.CaptureShadow;
            nudCaptureShadowOffset.Value = Program.Settings.CaptureShadowOffset;
            cbCaptureClientArea.Checked = Program.Settings.CaptureClientArea;
            cbScreenshotDelay.Checked = Program.Settings.IsDelayScreenshot;
            nudScreenshotDelay.Value = Program.Settings.DelayScreenshot;

            if (Program.Settings.SurfaceOptions == null) Program.Settings.SurfaceOptions = new SurfaceOptions();
            cbDrawBorder.Checked = Program.Settings.SurfaceOptions.DrawBorder;
            cbDrawCheckerboard.Checked = Program.Settings.SurfaceOptions.DrawChecker;
            cbQuickCrop.Checked = Program.Settings.SurfaceOptions.QuickCrop;
            cbFixedShapeSize.Checked = Program.Settings.SurfaceOptions.IsFixedSize;
            nudFixedShapeSizeWidth.Value = Program.Settings.SurfaceOptions.FixedSize.Width;
            nudFixedShapeSizeHeight.Value = Program.Settings.SurfaceOptions.FixedSize.Height;
            cbShapeIncludeControls.Checked = Program.Settings.SurfaceOptions.IncludeControls;
            cbShapeForceWindowCapture.Checked = Program.Settings.SurfaceOptions.ForceWindowCapture;

            // Actions
            if (Program.Settings.ExternalPrograms == null)
            {
                Program.Settings.ExternalPrograms = new List<ExternalProgram>();
            }
            else
            {
                foreach (ExternalProgram fileAction in Program.Settings.ExternalPrograms)
                {
                    AddFileAction(fileAction);
                }
            }

            // Upload / General
            nudUploadLimit.Value = Program.Settings.UploadLimit;

            for (int i = 0; i < MaxBufferSizePower; i++)
            {
                cbBufferSize.Items.Add(Math.Pow(2, i).ToString("N0") + " kB");
            }

            cbBufferSize.SelectedIndex = Program.Settings.BufferSizePower.Between(0, MaxBufferSizePower);
            txtNameFormatPattern.Text = Program.Settings.NameFormatPattern;
            txtNameFormatPatternActiveWindow.Text = Program.Settings.NameFormatPatternActiveWindow;

            cmsNameFormatPattern = NameParser.CreateCodesMenu(txtNameFormatPattern, ReplacementVariables.n);
            cmsNameFormatPatternActiveWindow = NameParser.CreateCodesMenu(txtNameFormatPatternActiveWindow, ReplacementVariables.n);

            // Upload / Clipboard upload
            cbShowClipboardContentViewer.Checked = Program.Settings.ShowClipboardContentViewer;
            cbClipboardUploadAutoDetectURL.Checked = Program.Settings.ClipboardUploadAutoDetectURL;
            cbClipboardUploadUseAfterCaptureTasks.Checked = Program.Settings.ClipboardUploadUseAfterCaptureTasks;
            cbClipboardUploadExcludeImageEffects.Checked = Program.Settings.ClipboardUploadExcludeImageEffects;

            // Upload / Watch folder
            cbWatchFolderEnabled.Checked = Program.Settings.WatchFolderEnabled;

            if (Program.Settings.WatchFolderList == null)
            {
                Program.Settings.WatchFolderList = new List<WatchFolder>();
            }
            else
            {
                foreach (WatchFolder watchFolder in Program.Settings.WatchFolderList)
                {
                    AddWatchFolder(watchFolder);
                }
            }

            // Proxy
            txtProxyUsername.Text = Program.Settings.ProxySettings.UserName;
            txtProxyPassword.Text = Program.Settings.ProxySettings.Password;
            txtProxyHost.Text = Program.Settings.ProxySettings.Host;
            nudProxyPort.Value = Program.Settings.ProxySettings.Port;
            cboProxyType.Items.AddRange(Helpers.GetEnumDescriptions<Proxy>());
            cboProxyType.SelectedIndex = (int)Program.Settings.ProxySettings.ProxyType;

            // Debug
            txtDebugLog.Text = Program.MyLogger.Messages.ToString();
            txtDebugLog.ScrollToCaret();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            BringToFront();
            Activate();
        }

        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void AddFileAction(ExternalProgram fileAction)
        {
            ListViewItem lvi = new ListViewItem(fileAction.Name ?? "");
            lvi.Tag = fileAction;
            lvi.Checked = fileAction.IsActive;
            lvi.SubItems.Add(fileAction.Path ?? "");
            lvi.SubItems.Add(fileAction.Args ?? "");
            lvActions.Items.Add(lvi);
        }

        private void AddWatchFolder(WatchFolder watchFolder)
        {
            ListViewItem lvi = new ListViewItem(watchFolder.FolderPath ?? "");
            lvi.Tag = watchFolder;
            lvi.SubItems.Add(watchFolder.Filter ?? "");
            lvi.SubItems.Add(watchFolder.IncludeSubdirectories.ToString());
            lvWatchFolderList.Items.Add(lvi);
        }

        #region General

        private void cbShowTray_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ShowTray = cbShowTray.Checked;

            if (loaded)
            {
                Program.MainForm.niTray.Visible = Program.Settings.ShowTray;
            }
        }

        private void cbStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                //RegistryHelper.SetStartWithWindows(cbStartWithWindows.Checked);
                ShortcutHelper.SetShortcut(cbStartWithWindows.Checked, Environment.SpecialFolder.Startup, "-silent");
            }
        }

        private void cbShellContextMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                //RegistryHelper.SetShellContextMenu(cbShellContextMenu.Checked);
                ShortcutHelper.SetShortcut(cbShellContextMenu.Checked, Environment.SpecialFolder.SendTo);
            }
        }

        private void cbCheckUpdates_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.AutoCheckUpdate = cbCheckUpdates.Checked;
        }

        private void cbShowAfterCaptureTasksForm_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ShowAfterCaptureTasksForm = cbShowAfterCaptureTasksForm.Checked;
        }

        private void cbPlaySoundAfterCapture_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.PlaySoundAfterCapture = cbPlaySoundAfterCapture.Checked;
        }

        private void cbPlaySoundAfterUpload_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.PlaySoundAfterUpload = cbPlaySoundAfterUpload.Checked;
        }

        private void cbTrayBalloonTipAfterUpload_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.TrayBalloonTipAfterUpload = cbTrayBalloonTipAfterUpload.Checked;
        }

        private void cbHistorySave_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.SaveHistory = cbHistorySave.Checked;
        }

        #endregion General

        #region Paths

        private void btnOpenPersonalFolder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Program.PersonalPath) && Directory.Exists(Program.PersonalPath))
            {
                Process.Start(Program.PersonalPath);
            }
        }

        private void cbUseCustomUploadersConfigPath_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.UseCustomUploadersConfigPath = cbUseCustomUploadersConfigPath.Checked;
        }

        private void txtCustomUploadersConfigPath_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.CustomUploadersConfigPath = txtCustomUploadersConfigPath.Text;
        }

        private void btnBrowseCustomUploadersConfigPath_Click(object sender, EventArgs e)
        {
            Helpers.BrowseFile("ShareX - Choose uploaders config file path", txtCustomUploadersConfigPath, Program.PersonalPath);
            Program.Settings.CustomUploadersConfigPath = txtCustomUploadersConfigPath.Text;
            Program.LoadUploadersConfig();
        }

        private void btnLoadUploadersConfig_Click(object sender, EventArgs e)
        {
            Program.LoadUploadersConfig();
        }

        private void cbUseCustomHistoryPath_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.UseCustomHistoryPath = cbUseCustomHistoryPath.Checked;
        }

        private void txtCustomHistoryPath_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.CustomHistoryPath = txtCustomHistoryPath.Text;
        }

        private void btnBrowseCustomHistoryPath_Click(object sender, EventArgs e)
        {
            Helpers.BrowseFile("ShareX - Choose history file path", txtCustomHistoryPath, Program.PersonalPath);
        }

        private void cbUseCustomScreenshotsPath_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.UseCustomScreenshotsPath = cbUseCustomScreenshotsPath.Checked;
            lblSaveImageSubFolderPatternPreview.Text = Program.ScreenshotsPath;
        }

        private void txtCustomScreenshotsPath_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.CustomScreenshotsPath = txtCustomScreenshotsPath.Text;
            lblSaveImageSubFolderPatternPreview.Text = Program.ScreenshotsPath;
        }

        private void btnBrowseCustomScreenshotsPath_Click(object sender, EventArgs e)
        {
            Helpers.BrowseFolder("Choose screenshots folder path", txtCustomScreenshotsPath, Program.PersonalPath);
        }

        private void txtSaveImageSubFolderPattern_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.SaveImageSubFolderPattern = txtSaveImageSubFolderPattern.Text;
            lblSaveImageSubFolderPatternPreview.Text = Program.ScreenshotsPath;
        }

        #endregion Paths

        #region Image / Quality

        private void cbImageFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageFormat = (EImageFormat)cbImageFormat.SelectedIndex;
        }

        private void nudImageJPEGQuality_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageJPEGQuality = (int)nudImageJPEGQuality.Value;
        }

        private void cbImageGIFQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageGIFQuality = (GIFQuality)cbImageGIFQuality.SelectedIndex;
        }

        private void nudUseImageFormat2After_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageSizeLimit = (int)nudUseImageFormat2After.Value;
        }

        private void cbImageFormat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageFormat2 = (EImageFormat)cbImageFormat2.SelectedIndex;
        }

        #endregion Image / Quality

        #region Image / Resize

        private void cbImageAutoResize_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageAutoResize = cbImageAutoResize.Checked;
        }

        private void cbImageKeepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageKeepAspectRatio = cbImageKeepAspectRatio.Checked;

            if (Program.Settings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageHeight.Value = nudImageScalePercentageWidth.Value;
            }
        }

        private void cbImageUseSmoothScaling_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageUseSmoothScaling = cbImageUseSmoothScaling.Checked;
        }

        private void CheckImageScaleType()
        {
            bool aspectRatioEnabled = true;

            if (rbImageScaleTypePercentage.Checked)
            {
                Program.Settings.ImageScaleType = ImageScaleType.Percentage;
            }
            else if (rbImageScaleTypeToWidth.Checked)
            {
                Program.Settings.ImageScaleType = ImageScaleType.Width;
            }
            else if (rbImageScaleTypeToHeight.Checked)
            {
                Program.Settings.ImageScaleType = ImageScaleType.Height;
            }
            else if (rbImageScaleTypeSpecific.Checked)
            {
                Program.Settings.ImageScaleType = ImageScaleType.Specific;
                aspectRatioEnabled = false;
            }

            cbImageKeepAspectRatio.Enabled = aspectRatioEnabled;
        }

        private void rbImageScaleTypePercentage_CheckedChanged(object sender, EventArgs e)
        {
            CheckImageScaleType();
        }

        private void rbImageScaleTypeToWidth_CheckedChanged(object sender, EventArgs e)
        {
            CheckImageScaleType();
        }

        private void rbImageScaleTypeToHeight_CheckedChanged(object sender, EventArgs e)
        {
            CheckImageScaleType();
        }

        private void rbImageScaleTypeSpecific_CheckedChanged(object sender, EventArgs e)
        {
            CheckImageScaleType();
        }

        private void nudImageScalePercentageWidth_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageScalePercentageWidth = (int)nudImageScalePercentageWidth.Value;

            if (Program.Settings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageHeight.Value = Program.Settings.ImageScalePercentageWidth;
            }
        }

        private void nudImageScalePercentageHeight_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageScalePercentageHeight = (int)nudImageScalePercentageHeight.Value;

            if (Program.Settings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageWidth.Value = Program.Settings.ImageScalePercentageHeight;
            }
        }

        private void nudImageScaleToWidth_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageScaleToWidth = (int)nudImageScaleToWidth.Value;
        }

        private void nudImageScaleToHeight_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageScaleToHeight = (int)nudImageScaleToHeight.Value;
        }

        private void nudImageScaleSpecificWidth_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageScaleSpecificWidth = (int)nudImageScaleSpecificWidth.Value;
        }

        private void nudImageScaleSpecificHeight_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ImageScaleSpecificHeight = (int)nudImageScaleSpecificHeight.Value;
        }

        #endregion Image / Resize

        #region Image / Other

        private void btnWatermarkSettings_Click(object sender, EventArgs e)
        {
            using (WatermarkUI watermarkForm = new WatermarkUI(Program.Settings.WatermarkConfig))
            {
                watermarkForm.Icon = Icon;
                watermarkForm.ShowDialog();
            }
        }

        private void btnBorderColor_Click(object sender, EventArgs e)
        {
            using (DialogColor dColor = new DialogColor(Program.Settings.BorderColor))
            {
                if (dColor.ShowDialog() == DialogResult.OK)
                {
                    Program.Settings.BorderColor = dColor.Color;
                    btnBorderColor.BackColor = dColor.Color;
                }
            }
        }

        private void nudBorderSize_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.BorderSize = (int)nudBorderSize.Value;
        }

        #endregion Image / Other

        #region Capture / General

        private void cbShowCursor_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ShowCursor = cbShowCursor.Checked;
        }

        private void cbCaptureTransparent_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.CaptureTransparent = cbCaptureTransparent.Checked;
            cbCaptureShadow.Enabled = Program.Settings.CaptureTransparent;
        }

        private void cbCaptureShadow_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.CaptureShadow = cbCaptureShadow.Checked;
        }

        private void nudCaptureShadowOffset_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.CaptureShadowOffset = (int)nudCaptureShadowOffset.Value;
        }

        private void cbCaptureClientArea_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.CaptureClientArea = cbCaptureClientArea.Checked;
        }

        private void cbScreenshotDelay_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.IsDelayScreenshot = cbScreenshotDelay.Checked;
        }

        private void nudScreenshotDelay_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.DelayScreenshot = nudScreenshotDelay.Value;
        }

        #endregion Capture / General

        #region Capture / Shape capture

        private void cbDrawBorder_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.SurfaceOptions.DrawBorder = cbDrawBorder.Checked;
        }

        private void cbDrawCheckerboard_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.SurfaceOptions.DrawChecker = cbDrawCheckerboard.Checked;
        }

        private void cbQuickCrop_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.SurfaceOptions.QuickCrop = cbQuickCrop.Checked;
        }

        private void cbFixedShapeSize_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.SurfaceOptions.IsFixedSize = cbFixedShapeSize.Checked;
        }

        private void nudFixedShapeSizeWidth_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.SurfaceOptions.FixedSize = new Size((int)nudFixedShapeSizeWidth.Value, Program.Settings.SurfaceOptions.FixedSize.Height);
        }

        private void nudFixedShapeSizeHeight_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.SurfaceOptions.FixedSize = new Size(Program.Settings.SurfaceOptions.FixedSize.Width, (int)nudFixedShapeSizeHeight.Value);
        }

        private void cbShapeIncludeControls_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.SurfaceOptions.IncludeControls = cbShapeIncludeControls.Checked;
        }

        private void cbShapeForceWindowCapture_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.SurfaceOptions.ForceWindowCapture = cbShapeForceWindowCapture.Checked;
        }

        private void btnOpenCapturingShapesWiki_Click(object sender, EventArgs e)
        {
            Helpers.LoadBrowserAsync(Links.URL_WIKI_CapturingShapes);
        }

        #endregion Capture / Shape capture

        #region Actions

        private void btnActionsAdd_Click(object sender, EventArgs e)
        {
            using (ExternalProgramForm form = new ExternalProgramForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ExternalProgram fileAction = form.FileAction;
                    fileAction.IsActive = true;
                    Program.Settings.ExternalPrograms.Add(fileAction);
                    AddFileAction(fileAction);
                }
            }
        }

        private void btnActionsEdit_Click(object sender, EventArgs e)
        {
            if (lvActions.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvActions.SelectedItems[0];
                ExternalProgram fileAction = lvi.Tag as ExternalProgram;

                using (ExternalProgramForm form = new ExternalProgramForm(fileAction))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        lvi.Text = fileAction.Name ?? "";
                        lvi.SubItems[1].Text = fileAction.Path ?? "";
                        lvi.SubItems[2].Text = fileAction.Args ?? "";
                    }
                }
            }
        }

        private void btnActionsRemove_Click(object sender, EventArgs e)
        {
            if (lvActions.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvActions.SelectedItems[0];
                ExternalProgram fileAction = lvi.Tag as ExternalProgram;

                Program.Settings.ExternalPrograms.Remove(fileAction);
                lvActions.Items.Remove(lvi);
            }
        }

        private void lvActions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ExternalProgram fileAction = e.Item.Tag as ExternalProgram;
            fileAction.IsActive = e.Item.Checked;
        }

        #endregion Actions

        #region Upload / General

        private void nudUploadLimit_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.UploadLimit = (int)nudUploadLimit.Value;
        }

        private void cbBufferSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Settings.BufferSizePower = cbBufferSize.SelectedIndex;
        }

        private void btnResetAutoIncrementNumber_Click(object sender, EventArgs e)
        {
            Program.Settings.AutoIncrementNumber = 0;
        }

        private void txtNameFormatPattern_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.NameFormatPattern = txtNameFormatPattern.Text;
            NameParser nameParser = new NameParser(NameParserType.FileName) { AutoIncrementNumber = Program.Settings.AutoIncrementNumber };
            lblNameFormatPatternPreview.Text = "Preview: " + nameParser.Parse(Program.Settings.NameFormatPattern);
        }

        private void txtNameFormatPatternActiveWindow_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.NameFormatPatternActiveWindow = txtNameFormatPatternActiveWindow.Text;
            NameParser nameParser = new NameParser(NameParserType.FileName) { AutoIncrementNumber = Program.Settings.AutoIncrementNumber, WindowText = Text };
            lblNameFormatPatternPreviewActiveWindow.Text = "Preview: " + nameParser.Parse(Program.Settings.NameFormatPatternActiveWindow);
        }

        #endregion Upload / General

        #region Upload / Clipboard upload

        private void cbShowClipboardContentViewer_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ShowClipboardContentViewer = cbShowClipboardContentViewer.Checked;
        }

        private void cbClipboardUploadAutoDetectURL_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ClipboardUploadAutoDetectURL = cbClipboardUploadAutoDetectURL.Checked;
        }

        private void cbClipboardUploadUseAfterCaptureTasks_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ClipboardUploadUseAfterCaptureTasks = cbClipboardUploadUseAfterCaptureTasks.Checked;
        }

        private void cbClipboardUploadExcludeImageEffects_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ClipboardUploadExcludeImageEffects = cbClipboardUploadExcludeImageEffects.Checked;
        }

        #endregion Upload / Clipboard upload

        #region Upload / Watch folder

        private void cbWatchFolderEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                Program.Settings.WatchFolderEnabled = cbWatchFolderEnabled.Checked;

                foreach (WatchFolder watchFolder in Program.Settings.WatchFolderList)
                {
                    if (Program.Settings.WatchFolderEnabled)
                    {
                        watchFolder.Enable();
                    }
                    else
                    {
                        watchFolder.Dispose();
                    }
                }
            }
        }

        private void btnWatchFolderAdd_Click(object sender, EventArgs e)
        {
            using (WatchFolderForm form = new WatchFolderForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    WatchFolder watchFolder = form.WatchFolder;
                    Program.Settings.WatchFolderList.Add(watchFolder);
                    AddWatchFolder(watchFolder);

                    if (Program.Settings.WatchFolderEnabled)
                    {
                        watchFolder.Enable();
                    }
                }
            }
        }

        private void btnWatchFolderRemove_Click(object sender, EventArgs e)
        {
            if (lvWatchFolderList.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvWatchFolderList.SelectedItems[0];
                WatchFolder watchFolder = lvi.Tag as WatchFolder;

                Program.Settings.WatchFolderList.Remove(watchFolder);
                lvWatchFolderList.Items.Remove(lvi);
                watchFolder.Dispose();
            }
        }

        #endregion Upload / Watch folder

        #region Proxy

        private void txtProxyUsername_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.ProxySettings.UserName = txtProxyUsername.Text;
        }

        private void txtProxyPassword_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.ProxySettings.Password = txtProxyPassword.Text;
        }

        private void txtProxyHost_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.ProxySettings.Host = txtProxyHost.Text;
        }

        private void nudProxyPort_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ProxySettings.Port = (int)nudProxyPort.Value;
        }

        private void cboProxyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Settings.ProxySettings.ProxyType = (UploadersLib.Proxy)cboProxyType.SelectedIndex;
        }

        private void btnAutofillProxy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Program.Settings.ProxySettings.UserName))
            {
                Program.Settings.ProxySettings.UserName = Environment.UserName;
            }

            WebProxy proxy = Helpers.GetDefaultWebProxy();
            if (proxy != null && proxy.Address != null)
            {
                if (string.IsNullOrEmpty(Program.Settings.ProxySettings.Host))
                {
                    Program.Settings.ProxySettings.Host = proxy.Address.Host;
                }

                if (Program.Settings.ProxySettings.Port == 0)
                {
                    Program.Settings.ProxySettings.Port = proxy.Address.Port;
                }
            }

            txtProxyUsername.Text = Program.Settings.ProxySettings.UserName;
            txtProxyPassword.Text = Program.Settings.ProxySettings.Password;
            nudProxyPort.Value = Program.Settings.ProxySettings.Port;
            txtProxyHost.Text = Program.Settings.ProxySettings.Host;
        }

        #endregion Proxy
    }
}