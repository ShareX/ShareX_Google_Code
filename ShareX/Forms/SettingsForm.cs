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
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using HelpersLib;
using ScreenCapture;

namespace ShareX
{
    public partial class SettingsForm : Form
    {
        private const int MaxBufferSizePower = 12;

        private bool loaded;
        private ContextMenuStrip codesMenu;

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
            hmHotkeys.PrepareHotkeys(Program.mainForm.HotkeyManager);
            loaded = true;
        }

        private void LoadSettings()
        {
            Text = Program.Title + " - Settings";

            // General
            cbShowTray.Checked = Program.Settings.ShowTray;
            cbStartWithWindows.Checked = RegistryHelper.CheckStartWithWindows();
            cbShellContextMenu.Checked = RegistryHelper.CheckShellContextMenu();
            cbCheckUpdates.Checked = Program.Settings.AutoCheckUpdate;
            cbClipboardAutoCopy.Checked = Program.Settings.ClipboardAutoCopy;
            cbURLShortenAfterUpload.Checked = Program.Settings.URLShortenAfterUpload;
            cbAutoPlaySound.Checked = Program.Settings.AutoPlaySound;

            // Upload
            cbUseCustomUploadersConfigPath.Checked = Program.Settings.UseCustomUploadersConfigPath;
            txtCustomUploadersConfigPath.Text = Program.Settings.CustomUploadersConfigPath;
            nudUploadLimit.Value = Program.Settings.UploadLimit;

            for (int i = 0; i < MaxBufferSizePower; i++)
            {
                cbBufferSize.Items.Add(Math.Pow(2, i).ToString("N0"));
            }

            cbBufferSize.SelectedIndex = Program.Settings.BufferSizePower.Between(0, MaxBufferSizePower);

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

            // Clipboard upload
            cbClipboardUploadAutoDetectURL.Checked = Program.Settings.ClipboardUploadAutoDetectURL;
            txtNameFormatPattern.Text = Program.Settings.NameFormatPattern;
            CreateCodesMenu();

            // Capture
            cbShowCursor.Checked = Program.Settings.ShowCursor;
            cbCaptureTransparent.Checked = Program.Settings.CaptureTransparent;
            cbCaptureShadow.Enabled = Program.Settings.CaptureTransparent;
            cbCaptureShadow.Checked = Program.Settings.CaptureShadow;
            cbCaptureCopyImage.Checked = Program.Settings.CaptureCopyImage;
            cbCaptureSaveImage.Checked = Program.Settings.CaptureSaveImage;
            txtSaveImageSubFolderPattern.Text = Program.Settings.SaveImageSubFolderPattern;
            cbCaptureUploadImage.Checked = Program.Settings.CaptureUploadImage;

            if (Program.Settings.SurfaceOptions == null) Program.Settings.SurfaceOptions = new SurfaceOptions();
            cbDrawBorder.Checked = Program.Settings.SurfaceOptions.DrawBorder;
            cbDrawCheckerboard.Checked = Program.Settings.SurfaceOptions.DrawChecker;
            cbQuickCrop.Checked = Program.Settings.SurfaceOptions.QuickCrop;
            cbFixedShapeSize.Checked = Program.Settings.SurfaceOptions.IsFixedSize;
            nudFixedShapeSizeWidth.Value = Program.Settings.SurfaceOptions.FixedSize.Width;
            nudFixedShapeSizeHeight.Value = Program.Settings.SurfaceOptions.FixedSize.Height;
            cbShapeIncludeControls.Checked = Program.Settings.SurfaceOptions.IncludeControls;
            cbShapeForceWindowCapture.Checked = Program.Settings.SurfaceOptions.ForceWindowCapture;

            // History
            cbHistorySave.Checked = Program.Settings.SaveHistory;
            cbUseCustomHistoryPath.Checked = Program.Settings.UseCustomHistoryPath;
            txtCustomHistoryPath.Text = Program.Settings.CustomHistoryPath;
            nudHistoryMaxItemCount.Value = Program.Settings.HistoryMaxItemCount;

            // Proxy
            pgProxy.SelectedObject = Program.Settings.ProxySettings;

            // Debug
            txtDebugLog.Text = Program.MyLogger.Messages.ToString();
            txtDebugLog.ScrollToCaret();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Activate();
        }

        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void CreateCodesMenu()
        {
            codesMenu = new ContextMenuStrip
            {
                Font = new XFont("Lucida Console", 8),
                Opacity = 0.8,
                ShowImageMargin = false
            };

            var variables = Enum.GetValues(typeof(ReplacementVariables)).Cast<ReplacementVariables>().
                Select(x => new
                {
                    Name = ReplacementExtension.Prefix + Enum.GetName(typeof(ReplacementVariables), x),
                    Description = x.GetDescription(),
                    Enum = x
                });

            foreach (var variable in variables)
            {
                switch (variable.Enum)
                {
                    case ReplacementVariables.t:
                    case ReplacementVariables.i:
                    case ReplacementVariables.n:
                    case ReplacementVariables.link:
                    case ReplacementVariables.name:
                    case ReplacementVariables.size:
                        continue;
                }

                ToolStripMenuItem tsi = new ToolStripMenuItem { Text = string.Format("{0} - {1}", variable.Name, variable.Description), Tag = variable.Name };
                tsi.Click += (sender, e) => txtNameFormatPattern.AppendText(((ToolStripMenuItem)sender).Tag.ToString());
                codesMenu.Items.Add(tsi);
            }
        }

        private bool ChooseFolder(string title, TextBox tb)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = title;

                try
                {
                    string path = tb.Text;

                    if (!string.IsNullOrEmpty(path))
                    {
                        path = Path.GetDirectoryName(path);

                        if (Directory.Exists(path))
                        {
                            ofd.InitialDirectory = path;
                        }
                    }
                }
                finally
                {
                    if (string.IsNullOrEmpty(ofd.InitialDirectory))
                    {
                        ofd.InitialDirectory = Program.PersonalPath;
                    }
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tb.Text = ofd.FileName;
                    return true;
                }
            }

            return false;
        }

        #region General

        private void cbShowTray_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ShowTray = cbShowTray.Checked;

            if (loaded)
            {
                Program.mainForm.niTray.Visible = Program.Settings.ShowTray;
            }
        }

        private void cbStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                RegistryHelper.SetStartWithWindows(cbStartWithWindows.Checked);
            }
        }

        private void cbShellContextMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                RegistryHelper.SetShellContextMenu(cbShellContextMenu.Checked);
            }
        }

        private void cbCheckUpdates_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.AutoCheckUpdate = cbCheckUpdates.Checked;
        }

        private void cbClipboardAutoCopy_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ClipboardAutoCopy = cbClipboardAutoCopy.Checked;
        }

        private void cbURLShortenAfterUpload_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.URLShortenAfterUpload = cbURLShortenAfterUpload.Checked;
        }

        private void cbAutoPlaySound_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.AutoPlaySound = cbAutoPlaySound.Checked;
        }

        private void btnOpenZUploaderPath_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Program.PersonalPath) && Directory.Exists(Program.PersonalPath))
            {
                Process.Start(Program.PersonalPath);
            }
        }

        #endregion General

        #region Upload

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
            ChooseFolder("ShareX - Choose uploaders config file path", txtCustomUploadersConfigPath);
            Program.Settings.CustomUploadersConfigPath = txtCustomUploadersConfigPath.Text;
            Program.LoadUploadersConfig();
        }

        private void btnLoadUploadersConfig_Click(object sender, EventArgs e)
        {
            Program.LoadUploadersConfig();
        }

        private void nudUploadLimit_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.UploadLimit = (int)nudUploadLimit.Value;
        }

        private void cbBufferSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Settings.BufferSizePower = cbBufferSize.SelectedIndex;
            string bufferSize = (Math.Pow(2, Program.Settings.BufferSizePower) * 1024 / 1000).ToString("#,0.###");
            lblBufferSizeInfo.Text = string.Format("x {0} KiB = {1} KiB", 1.024, bufferSize);
        }

        #endregion Upload

        #region Image

        #region Quality

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

        #endregion Quality

        #region Resize

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

        #endregion Resize

        #endregion Image

        #region Clipboard upload

        private void cbClipboardUploadAutoDetectURL_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ClipboardUploadAutoDetectURL = cbClipboardUploadAutoDetectURL.Checked;
        }

        private void txtNameFormatPattern_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.NameFormatPattern = txtNameFormatPattern.Text;
            lblNameFormatPatternPreview.Text = "Preview: " + new NameParser().Convert(Program.Settings.NameFormatPattern);
        }

        private void btnNameFormatPatternHelp_Click(object sender, EventArgs e)
        {
            codesMenu.Show(btnNameFormatPatternHelp, new Point(btnNameFormatPatternHelp.Width + 1, 0));
        }

        #endregion Clipboard upload

        #region Capture

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

        private void cbCaptureCopyImage_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.CaptureCopyImage = cbCaptureCopyImage.Checked;
        }

        private void cbCaptureSaveImage_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.CaptureSaveImage = cbCaptureSaveImage.Checked;
        }

        private void txtSaveImageSubFolderPattern_TextChanged(object sender, EventArgs e)
        {
            Program.Settings.SaveImageSubFolderPattern = txtSaveImageSubFolderPattern.Text;
            lblSaveImageSubFolderPatternPreview.Text = Program.ScreenshotsPath;
        }

        private void cbCaptureUploadImage_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.CaptureUploadImage = cbCaptureUploadImage.Checked;
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

        #endregion Capture / Shape capture

        #endregion Capture

        #region History

        private void cbHistorySave_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.SaveHistory = cbHistorySave.Checked;
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
            ChooseFolder("ShareX - Choose history file path", txtCustomHistoryPath);
        }

        private void nudHistoryMaxItemCount_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.HistoryMaxItemCount = (int)nudHistoryMaxItemCount.Value;
        }

        #endregion History

        #region Proxy

        private void btnAutofillProxy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Program.Settings.ProxySettings.UserName))
            {
                Program.Settings.ProxySettings.UserName = Environment.UserName;
            }

            WebProxy proxy = ZAppHelper.GetDefaultWebProxy();
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

            pgProxy.SelectedObject = Program.Settings.ProxySettings;
        }

        #endregion Proxy
    }
}