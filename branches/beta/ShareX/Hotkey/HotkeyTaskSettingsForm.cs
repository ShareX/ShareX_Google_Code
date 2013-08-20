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
using ShareX.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UploadersLib;

namespace ShareX
{
    public partial class HotkeyTaskSettingsForm : Form
    {
        private ContextMenuStrip cmsNameFormatPattern, cmsNameFormatPatternActiveWindow;
        public HotkeySetting Setting { get; set; }

        public HotkeyTaskSettingsForm(HotkeySetting hotkeySetting)
        {
            InitializeComponent();
            Icon = Resources.ShareX;
            Setting = hotkeySetting;

            if (hotkeySetting.Description == "Default")
            {
                tcHotkeySettings.TabPages.Remove(tpTask);
            }

            tbDescription.Text = hotkeySetting.Description;
            Text = Application.ProductName + " - " + hotkeySetting.Description + " - workflow settings";
            cbUseDefaultAfterCaptureSettings.Checked = hotkeySetting.TaskSettings.UseDefaultAfterCaptureJob;
            cbUseDefaultAfterUploadSettings.Checked = hotkeySetting.TaskSettings.UseDefaultAfterUploadJob;
            cbUseDefaultDestinationSettings.Checked = hotkeySetting.TaskSettings.UseDefaultDestinations;
            chkUseDefaultImageSettings.Checked = Setting.TaskSettings.UseDefaultImageSettings;
            chkUseDefaultCaptureSettings.Checked = Setting.TaskSettings.UseDefaultCaptureSettings;
            chkUseDefaultActions.Checked = Setting.TaskSettings.UseDefaultActions;
            chkUseDefaultUploadSettings.Checked = Setting.TaskSettings.UseDefaultUploadSettings;

            AddEnumItems<EHotkey>(x => Setting.Job = x, cmsTask);
            AddMultiEnumItems<AfterCaptureTasks>(x => Setting.TaskSettings.AfterCaptureJob = Setting.TaskSettings.AfterCaptureJob.Swap(x), cmsAfterCapture);
            AddMultiEnumItems<AfterUploadTasks>(x => Setting.TaskSettings.AfterUploadJob = Setting.TaskSettings.AfterUploadJob.Swap(x), cmsAfterUpload);
            AddEnumItems<ImageDestination>(x => Setting.TaskSettings.ImageDestination = x, cmsImageUploaders);
            AddEnumItems<TextDestination>(x => Setting.TaskSettings.TextDestination = x, cmsTextUploaders);
            AddEnumItems<FileDestination>(x => Setting.TaskSettings.FileDestination = x, cmsFileUploaders);
            AddEnumItems<UrlShortenerType>(x => Setting.TaskSettings.URLShortenerDestination = x, cmsURLShorteners);
            AddEnumItems<SocialNetworkingService>(x => Setting.TaskSettings.SocialNetworkingServiceDestination = x, cmsSocialNetworkingServices);

            SetMultiEnumChecked(Setting.TaskSettings.AfterCaptureJob, cmsAfterCapture);
            SetMultiEnumChecked(Setting.TaskSettings.AfterUploadJob, cmsAfterUpload);
            SetEnumChecked(Setting.TaskSettings.ImageDestination, cmsImageUploaders);
            SetEnumChecked(Setting.TaskSettings.TextDestination, cmsTextUploaders);
            SetEnumChecked(Setting.TaskSettings.FileDestination, cmsFileUploaders);
            SetEnumChecked(Setting.TaskSettings.URLShortenerDestination, cmsURLShorteners);
            SetEnumChecked(Setting.TaskSettings.SocialNetworkingServiceDestination, cmsSocialNetworkingServices);

            UpdateDestinationStates();
            UpdateUploaderMenuNames();

            // Image - Quality
            cbImageFormat.SelectedIndex = (int)Setting.TaskSettings.ImageSettings.ImageFormat;
            nudImageJPEGQuality.Value = Setting.TaskSettings.ImageSettings.ImageJPEGQuality;
            cbImageGIFQuality.SelectedIndex = (int)Setting.TaskSettings.ImageSettings.ImageGIFQuality;
            nudUseImageFormat2After.Value = Setting.TaskSettings.ImageSettings.ImageSizeLimit;
            cbImageFormat2.SelectedIndex = (int)Setting.TaskSettings.ImageSettings.ImageFormat2;
            cbUseImageFormat2FileUpload.Checked = Setting.TaskSettings.ImageSettings.UseImageFormat2FileUpload;

            // Image - Resize
            cbImageAutoResize.Checked = Setting.TaskSettings.ImageSettings.ImageAutoResize;
            cbImageKeepAspectRatio.Checked = Setting.TaskSettings.ImageSettings.ImageKeepAspectRatio;
            cbImageUseSmoothScaling.Checked = Setting.TaskSettings.ImageSettings.ImageUseSmoothScaling;

            switch (Setting.TaskSettings.ImageSettings.ImageScaleType)
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

            nudImageScalePercentageWidth.Value = Setting.TaskSettings.ImageSettings.ImageScalePercentageWidth;
            nudImageScalePercentageHeight.Value = Setting.TaskSettings.ImageSettings.ImageScalePercentageHeight;
            nudImageScaleToWidth.Value = Setting.TaskSettings.ImageSettings.ImageScaleToWidth;
            nudImageScaleToHeight.Value = Setting.TaskSettings.ImageSettings.ImageScaleToHeight;
            nudImageScaleSpecificWidth.Value = Setting.TaskSettings.ImageSettings.ImageScaleSpecificWidth;
            nudImageScaleSpecificHeight.Value = Setting.TaskSettings.ImageSettings.ImageScaleSpecificHeight;

            // Image - Effects
            cbImageEffectOnlyRegionCapture.Checked = Setting.TaskSettings.ImageSettings.ImageEffectOnlyRegionCapture;
            btnBorderColor.BackColor = Setting.TaskSettings.ImageSettings.BorderColor;
            nudBorderSize.Value = Setting.TaskSettings.ImageSettings.BorderSize;
            nudImageShadowDarkness.Value = (decimal)Setting.TaskSettings.ImageSettings.ShadowDarkness;
            nudImageShadowSize.Value = Setting.TaskSettings.ImageSettings.ShadowSize;

            // Capture
            cbShowCursor.Checked = Setting.TaskSettings.CaptureSettings.ShowCursor;
            cbCaptureTransparent.Checked = Setting.TaskSettings.CaptureSettings.CaptureTransparent;
            cbCaptureShadow.Enabled = Setting.TaskSettings.CaptureSettings.CaptureTransparent;
            cbCaptureShadow.Checked = Setting.TaskSettings.CaptureSettings.CaptureShadow;
            nudCaptureShadowOffset.Value = Setting.TaskSettings.CaptureSettings.CaptureShadowOffset;
            cbCaptureClientArea.Checked = Setting.TaskSettings.CaptureSettings.CaptureClientArea;
            cbScreenshotDelay.Checked = Setting.TaskSettings.CaptureSettings.IsDelayScreenshot;
            nudScreenshotDelay.Value = Setting.TaskSettings.CaptureSettings.DelayScreenshot;
            cbCaptureAutoHideTaskbar.Checked = Setting.TaskSettings.CaptureSettings.CaptureAutoHideTaskbar;

            if (Setting.TaskSettings.CaptureSettings.SurfaceOptions == null) Setting.TaskSettings.CaptureSettings.SurfaceOptions = new SurfaceOptions();
            cbDrawBorder.Checked = Setting.TaskSettings.CaptureSettings.SurfaceOptions.DrawBorder;
            cbDrawCheckerboard.Checked = Setting.TaskSettings.CaptureSettings.SurfaceOptions.DrawChecker;
            cbQuickCrop.Checked = Setting.TaskSettings.CaptureSettings.SurfaceOptions.QuickCrop;
            cbFixedShapeSize.Checked = Setting.TaskSettings.CaptureSettings.SurfaceOptions.IsFixedSize;
            nudFixedShapeSizeWidth.Value = Setting.TaskSettings.CaptureSettings.SurfaceOptions.FixedSize.Width;
            nudFixedShapeSizeHeight.Value = Setting.TaskSettings.CaptureSettings.SurfaceOptions.FixedSize.Height;
            cbShapeIncludeControls.Checked = Setting.TaskSettings.CaptureSettings.SurfaceOptions.IncludeControls;
            cbShapeForceWindowCapture.Checked = Setting.TaskSettings.CaptureSettings.SurfaceOptions.ForceWindowCapture;

            cbScreenRecorderHotkeyStartInstantly.Checked = Setting.TaskSettings.CaptureSettings.ScreenRecorderHotkeyStartInstantly;

            // Actions
            TaskHelper.AddDefaultExternalPrograms(Setting.TaskSettings);

            foreach (ExternalProgram fileAction in Setting.TaskSettings.ExternalPrograms)
            {
                AddFileAction(fileAction);
            }

            // Upload / Name pattern
            txtNameFormatPattern.Text = Setting.TaskSettings.UploadSettings.NameFormatPattern;
            txtNameFormatPatternActiveWindow.Text = Setting.TaskSettings.UploadSettings.NameFormatPatternActiveWindow;
            cmsNameFormatPattern = NameParser.CreateCodesMenu(txtNameFormatPattern, ReplacementVariables.n);
            cmsNameFormatPatternActiveWindow = NameParser.CreateCodesMenu(txtNameFormatPatternActiveWindow, ReplacementVariables.n);
            cbFileUploadUseNamePattern.Checked = Setting.TaskSettings.UploadSettings.FileUploadUseNamePattern;

            // Upload / Clipboard upload
            cbShowClipboardContentViewer.Checked = Setting.TaskSettings.UploadSettings.ShowClipboardContentViewer;
            cbClipboardUploadAutoDetectURL.Checked = Setting.TaskSettings.UploadSettings.ClipboardUploadAutoDetectURL;
            cbClipboardUploadUseAfterCaptureTasks.Checked = Setting.TaskSettings.UploadSettings.ClipboardUploadUseAfterCaptureTasks;
            cbClipboardUploadExcludeImageEffects.Checked = Setting.TaskSettings.UploadSettings.ClipboardUploadExcludeImageEffects;

            // Advanced
            pgTaskSettings.SelectedObject = Setting.TaskSettings;
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            Setting.Description = tbDescription.Text;
        }

        private void btnTask_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsTask.Show(btnTask, e.Location);
            }
        }

        private void cbUseDefaultAfterCaptureSettings_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultAfterCaptureJob = cbUseDefaultAfterCaptureSettings.Checked;
            btnAfterCapture.Enabled = !Setting.TaskSettings.UseDefaultAfterCaptureJob;
        }

        private void btnAfterCapture_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsAfterCapture.Show(btnAfterCapture, e.Location);
            }
        }

        private void cbUseDefaultAfterUploadSettings_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultAfterUploadJob = cbUseDefaultAfterUploadSettings.Checked;
            btnAfterUpload.Enabled = !Setting.TaskSettings.UseDefaultAfterUploadJob;
        }

        private void btnAfterUpload_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsAfterUpload.Show(btnAfterUpload, e.Location);
            }
        }

        private void cbUseDefaultDestinationSettings_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultDestinations = cbUseDefaultDestinationSettings.Checked;
            btnImageUploaders.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
            btnTextUploaders.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
            btnFileUploaders.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
            btnURLShorteners.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
            btnSocialNetworkingServices.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
        }

        private void btnImageUploaders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsImageUploaders.Show(btnImageUploaders, e.Location);
            }
        }

        private void btnTextUploaders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsTextUploaders.Show(btnTextUploaders, e.Location);
            }
        }

        private void btnFileUploaders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsFileUploaders.Show(btnFileUploaders, e.Location);
            }
        }

        private void btnURLShorteners_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsURLShorteners.Show(btnURLShorteners, e.Location);
            }
        }

        private void btnSocialNetworkingServices_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsSocialNetworkingServices.Show(btnSocialNetworkingServices, e.Location);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void UpdateDestinationStates()
        {
            if (Program.UploadersConfig != null)
            {
                EnableDisableToolStripMenuItems<ImageDestination>(cmsImageUploaders);
                EnableDisableToolStripMenuItems<TextDestination>(cmsTextUploaders);
                EnableDisableToolStripMenuItems<FileDestination>(cmsFileUploaders);
                EnableDisableToolStripMenuItems<UrlShortenerType>(cmsURLShorteners);
                EnableDisableToolStripMenuItems<SocialNetworkingService>(cmsSocialNetworkingServices);
            }
        }

        private void AddEnumItems<T>(Action<T> selectedEnum, params ToolStripDropDown[] parents)
        {
            string[] enums = Helpers.GetEnumDescriptions<T>();

            foreach (ToolStripDropDown parent in parents)
            {
                for (int i = 0; i < enums.Length; i++)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(enums[i]);

                    int index = i;

                    tsmi.Click += (sender, e) =>
                    {
                        foreach (ToolStripDropDown parent2 in parents)
                        {
                            for (int i2 = 0; i2 < enums.Length; i2++)
                            {
                                ToolStripMenuItem tsmi2 = (ToolStripMenuItem)parent2.Items[i2];
                                tsmi2.Checked = index == i2;
                            }
                        }

                        selectedEnum((T)Enum.ToObject(typeof(T), index));

                        UpdateUploaderMenuNames();
                    };

                    parent.Items.Add(tsmi);
                }
            }
        }

        private void SetEnumChecked(Enum value, params ToolStripDropDown[] parents)
        {
            int index = value.GetIndex();

            foreach (ToolStripDropDown parent in parents)
            {
                ((ToolStripMenuItem)parent.Items[index]).Checked = true;
            }
        }

        private void AddMultiEnumItems<T>(Action<T> selectedEnum, params ToolStripDropDown[] parents)
        {
            string[] enums = Enum.GetValues(typeof(T)).Cast<Enum>().Skip(1).Select(x => x.GetDescription()).ToArray();

            foreach (ToolStripDropDown parent in parents)
            {
                for (int i = 0; i < enums.Length; i++)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(enums[i]);

                    int index = i;

                    tsmi.Click += (sender, e) =>
                    {
                        foreach (ToolStripDropDown parent2 in parents)
                        {
                            ToolStripMenuItem tsmi2 = (ToolStripMenuItem)parent2.Items[index];
                            tsmi2.Checked = !tsmi2.Checked;
                        }

                        selectedEnum((T)Enum.ToObject(typeof(T), 1 << index));

                        UpdateUploaderMenuNames();
                    };

                    parent.Items.Add(tsmi);
                }
            }
        }

        private void SetMultiEnumChecked(Enum value, params ToolStripDropDown[] parents)
        {
            for (int i = 0; i < parents[0].Items.Count; i++)
            {
                foreach (ToolStripDropDown parent in parents)
                {
                    ToolStripMenuItem tsmi = (ToolStripMenuItem)parent.Items[i];
                    tsmi.Checked = value.HasFlag(1 << i);
                }
            }
        }

        private void EnableDisableToolStripMenuItems<T>(params ToolStripDropDown[] parents)
        {
            foreach (ToolStripDropDown parent in parents)
            {
                for (int i = 0; i < parent.Items.Count; i++)
                {
                    parent.Items[i].Enabled = Program.UploadersConfig.IsActive<T>(i);
                }
            }
        }

        private void UpdateUploaderMenuNames()
        {
            btnTask.Text = "Task: " + Setting.Job.GetDescription();

            btnAfterCapture.Text = "After capture: " + string.Join(", ", Setting.TaskSettings.AfterCaptureJob.GetFlags<AfterCaptureTasks>().
                Select(x => x.GetDescription()).ToArray());

            btnAfterUpload.Text = "After upload: " + string.Join(", ", Setting.TaskSettings.AfterUploadJob.GetFlags<AfterUploadTasks>().
                Select(x => x.GetDescription()).ToArray());

            string imageUploader = Setting.TaskSettings.ImageDestination == ImageDestination.FileUploader ?
                Setting.TaskSettings.FileDestination.GetDescription() : Setting.TaskSettings.ImageDestination.GetDescription();
            btnImageUploaders.Text = "Image uploader: " + imageUploader;

            string textUploader = Setting.TaskSettings.TextDestination == TextDestination.FileUploader ?
                Setting.TaskSettings.FileDestination.GetDescription() : Setting.TaskSettings.TextDestination.GetDescription();
            btnTextUploaders.Text = "Text uploader: " + textUploader;

            btnFileUploaders.Text = "File uploader: " + Setting.TaskSettings.FileDestination.GetDescription();

            btnURLShorteners.Text = "URL shortener: " + Setting.TaskSettings.URLShortenerDestination.GetDescription();

            btnSocialNetworkingServices.Text = "Social networking service: " + Setting.TaskSettings.SocialNetworkingServiceDestination.GetDescription();
        }

        private void cbUseImageFormat2FileUpload_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.UseImageFormat2FileUpload = cbUseImageFormat2FileUpload.Checked;
        }

        private void cbImageFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageFormat = (EImageFormat)cbImageFormat.SelectedIndex;
        }

        private void cbImageGIFQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageGIFQuality = (GIFQuality)cbImageGIFQuality.SelectedIndex;
        }

        private void cbImageFormat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageFormat2 = (EImageFormat)cbImageFormat2.SelectedIndex;
        }

        private void nudImageJPEGQuality_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageJPEGQuality = (int)nudImageJPEGQuality.Value;
        }

        private void nudUseImageFormat2After_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageSizeLimit = (int)nudUseImageFormat2After.Value;
        }

        private void cbImageUseSmoothScaling_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageUseSmoothScaling = cbImageUseSmoothScaling.Checked;
        }

        private void cbImageKeepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageKeepAspectRatio = cbImageKeepAspectRatio.Checked;

            if (Setting.TaskSettings.ImageSettings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageHeight.Value = nudImageScalePercentageWidth.Value;
            }
        }

        private void cbImageAutoResize_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageAutoResize = cbImageAutoResize.Checked;
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

        private void CheckImageScaleType()
        {
            bool aspectRatioEnabled = true;

            if (rbImageScaleTypePercentage.Checked)
            {
                Setting.TaskSettings.ImageSettings.ImageScaleType = ImageScaleType.Percentage;
            }
            else if (rbImageScaleTypeToWidth.Checked)
            {
                Setting.TaskSettings.ImageSettings.ImageScaleType = ImageScaleType.Width;
            }
            else if (rbImageScaleTypeToHeight.Checked)
            {
                Setting.TaskSettings.ImageSettings.ImageScaleType = ImageScaleType.Height;
            }
            else if (rbImageScaleTypeSpecific.Checked)
            {
                Setting.TaskSettings.ImageSettings.ImageScaleType = ImageScaleType.Specific;
                aspectRatioEnabled = false;
            }

            cbImageKeepAspectRatio.Enabled = aspectRatioEnabled;
        }

        private void nudImageScalePercentageWidth_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageScalePercentageWidth = (int)nudImageScalePercentageWidth.Value;

            if (Setting.TaskSettings.ImageSettings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageHeight.Value = Setting.TaskSettings.ImageSettings.ImageScalePercentageWidth;
            }
        }

        private void nudImageScaleToHeight_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageScaleToHeight = (int)nudImageScaleToHeight.Value;
        }

        private void nudImageScalePercentageHeight_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageScalePercentageHeight = (int)nudImageScalePercentageHeight.Value;

            if (Setting.TaskSettings.ImageSettings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageWidth.Value = Setting.TaskSettings.ImageSettings.ImageScalePercentageHeight;
            }
        }

        private void nudImageScaleToWidth_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageScaleToWidth = (int)nudImageScaleToWidth.Value;
        }

        private void nudImageScaleSpecificHeight_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageScaleSpecificHeight = (int)nudImageScaleSpecificHeight.Value;
        }

        private void nudImageScaleSpecificWidth_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageScaleSpecificWidth = (int)nudImageScaleSpecificWidth.Value;
        }

        private void nudImageShadowSize_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ShadowSize = (int)nudImageShadowSize.Value;
        }

        private void nudImageShadowDarkness_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ShadowDarkness = (float)nudImageShadowDarkness.Value;
        }

        private void cbImageEffectOnlyRectangleCapture_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.ImageEffectOnlyRegionCapture = cbImageEffectOnlyRegionCapture.Checked;
        }

        private void btnWatermarkSettings_Click(object sender, EventArgs e)
        {
            using (WatermarkUI watermarkForm = new WatermarkUI(Setting.TaskSettings.ImageSettings.WatermarkConfig))
            {
                watermarkForm.Icon = Icon;
                watermarkForm.ShowDialog();
            }
        }

        private void nudBorderSize_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSettings.BorderSize = (int)nudBorderSize.Value;
        }

        private void btnBorderColor_Click(object sender, EventArgs e)
        {
            using (DialogColor dColor = new DialogColor(Setting.TaskSettings.ImageSettings.BorderColor))
            {
                if (dColor.ShowDialog() == DialogResult.OK)
                {
                    Setting.TaskSettings.ImageSettings.BorderColor = dColor.Color;
                    btnBorderColor.BackColor = dColor.Color;
                }
            }
        }

        private void cbCaptureAutoHideTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.CaptureAutoHideTaskbar = cbCaptureAutoHideTaskbar.Checked;
        }

        private void nudScreenshotDelay_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.DelayScreenshot = nudScreenshotDelay.Value;
        }

        private void cbScreenshotDelay_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.IsDelayScreenshot = cbScreenshotDelay.Checked;
        }

        private void nudCaptureShadowOffset_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.CaptureShadowOffset = (int)nudCaptureShadowOffset.Value;
        }

        private void cbCaptureClientArea_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.CaptureClientArea = cbCaptureClientArea.Checked;
        }

        private void cbCaptureShadow_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.CaptureShadow = cbCaptureShadow.Checked;
        }

        private void cbShowCursor_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.ShowCursor = cbShowCursor.Checked;
        }

        private void cbCaptureTransparent_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.CaptureTransparent = cbCaptureTransparent.Checked;
            cbCaptureShadow.Enabled = Setting.TaskSettings.CaptureSettings.CaptureTransparent;
        }

        private void btnOpenCapturingShapesWiki_Click(object sender, EventArgs e)
        {
            Helpers.LoadBrowserAsync(Links.URL_WIKI_CapturingShapes);
        }

        private void cbShapeForceWindowCapture_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.SurfaceOptions.ForceWindowCapture = cbShapeForceWindowCapture.Checked;
        }

        private void cbShapeIncludeControls_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.SurfaceOptions.IncludeControls = cbShapeIncludeControls.Checked;
        }

        private void cbDrawBorder_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.SurfaceOptions.DrawBorder = cbDrawBorder.Checked;
        }

        private void cbQuickCrop_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.SurfaceOptions.QuickCrop = cbQuickCrop.Checked;
        }

        private void nudFixedShapeSizeHeight_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.SurfaceOptions.FixedSize = new Size(Setting.TaskSettings.CaptureSettings.SurfaceOptions.FixedSize.Width, (int)nudFixedShapeSizeHeight.Value);
        }

        private void cbDrawCheckerboard_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.SurfaceOptions.DrawChecker = cbDrawCheckerboard.Checked;
        }

        private void nudFixedShapeSizeWidth_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.SurfaceOptions.FixedSize = new Size((int)nudFixedShapeSizeWidth.Value, Setting.TaskSettings.CaptureSettings.SurfaceOptions.FixedSize.Height);
        }

        private void cbFixedShapeSize_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.SurfaceOptions.IsFixedSize = cbFixedShapeSize.Checked;
        }

        private void cbScreenRecorderHotkeyStartInstantly_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureSettings.ScreenRecorderHotkeyStartInstantly = cbScreenRecorderHotkeyStartInstantly.Checked;
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

                Setting.TaskSettings.ExternalPrograms.Remove(fileAction);
                lvActions.Items.Remove(lvi);
            }
        }

        private void btnActionsAdd_Click(object sender, EventArgs e)
        {
            using (ExternalProgramForm form = new ExternalProgramForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ExternalProgram fileAction = form.FileAction;
                    fileAction.IsActive = true;
                    Setting.TaskSettings.ExternalPrograms.Add(fileAction);
                    AddFileAction(fileAction);
                }
            }
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

        private void lvActions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ExternalProgram fileAction = e.Item.Tag as ExternalProgram;
            fileAction.IsActive = e.Item.Checked;
        }

        private void cbFileUploadUseNamePattern_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UploadSettings.FileUploadUseNamePattern = cbFileUploadUseNamePattern.Checked;
        }

        private void txtNameFormatPatternActiveWindow_TextChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UploadSettings.NameFormatPatternActiveWindow = txtNameFormatPatternActiveWindow.Text;
            NameParser nameParser = new NameParser(NameParserType.FileName) { AutoIncrementNumber = Setting.TaskSettings.UploadSettings.AutoIncrementNumber, WindowText = Text };
            lblNameFormatPatternPreviewActiveWindow.Text = "Preview: " + nameParser.Parse(Setting.TaskSettings.UploadSettings.NameFormatPatternActiveWindow);
        }

        private void btnResetAutoIncrementNumber_Click(object sender, EventArgs e)
        {
            Setting.TaskSettings.UploadSettings.AutoIncrementNumber = 0;
        }

        private void txtNameFormatPattern_TextChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UploadSettings.NameFormatPattern = txtNameFormatPattern.Text;
            NameParser nameParser = new NameParser(NameParserType.FileName) { AutoIncrementNumber = Setting.TaskSettings.UploadSettings.AutoIncrementNumber };
            lblNameFormatPatternPreview.Text = "Preview: " + nameParser.Parse(Setting.TaskSettings.UploadSettings.NameFormatPattern);
        }

        private void cbShowClipboardContentViewer_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UploadSettings.ShowClipboardContentViewer = cbShowClipboardContentViewer.Checked;
        }

        private void cbClipboardUploadUseAfterCaptureTasks_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UploadSettings.ClipboardUploadUseAfterCaptureTasks = cbClipboardUploadUseAfterCaptureTasks.Checked;
        }

        private void cbClipboardUploadAutoDetectURL_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UploadSettings.ClipboardUploadAutoDetectURL = cbClipboardUploadAutoDetectURL.Checked;
        }

        private void cbClipboardUploadExcludeImageEffects_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UploadSettings.ClipboardUploadExcludeImageEffects = cbClipboardUploadExcludeImageEffects.Checked;
        }

        private void chkUseDefaultImageSettings_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultImageSettings = chkUseDefaultImageSettings.Checked;
            tcImage.Enabled = !Setting.TaskSettings.UseDefaultImageSettings;
        }

        private void chkUseDefaultCaptureSettings_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultCaptureSettings = chkUseDefaultCaptureSettings.Checked;
            tcImage.Enabled = !Setting.TaskSettings.UseDefaultCaptureSettings;
        }

        private void chkUseDefaultActions_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultActions = chkUseDefaultActions.Checked;
            tpActions.Enabled = !Setting.TaskSettings.UseDefaultActions;
        }

        private void chkUseDefaultUploadSettings_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultUploadSettings = chkUseDefaultUploadSettings.Checked;
            tcUpload.Enabled = !Setting.TaskSettings.UseDefaultUploadSettings;
        }
    }
}