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
        private bool loaded;
        private ContextMenuStrip cmsNameFormatPattern, cmsNameFormatPatternActiveWindow;
        public HotkeySetting Setting { get; set; }

        public HotkeyTaskSettingsForm(HotkeySetting hotkeySetting)
        {
            InitializeComponent();
            Icon = Resources.ShareX;
            Setting = hotkeySetting;

            tbDescription.Text = hotkeySetting.Description;
            Text = Application.ProductName + " - " + hotkeySetting.Description + " - workflow settings";
            cbUseDefaultAfterCaptureSettings.Checked = hotkeySetting.TaskSettings.UseDefaultAfterCaptureJob;
            cbUseDefaultAfterUploadSettings.Checked = hotkeySetting.TaskSettings.UseDefaultAfterUploadJob;
            cbUseDefaultDestinationSettings.Checked = hotkeySetting.TaskSettings.UseDefaultDestinations;

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
            cbImageFormat.SelectedIndex = (int)Setting.TaskSettings.ImageFormat;
            nudImageJPEGQuality.Value = Setting.TaskSettings.ImageJPEGQuality;
            cbImageGIFQuality.SelectedIndex = (int)Setting.TaskSettings.ImageGIFQuality;
            nudUseImageFormat2After.Value = Setting.TaskSettings.ImageSizeLimit;
            cbImageFormat2.SelectedIndex = (int)Setting.TaskSettings.ImageFormat2;
            cbUseImageFormat2FileUpload.Checked = Setting.TaskSettings.UseImageFormat2FileUpload;

            // Image - Resize
            cbImageAutoResize.Checked = Setting.TaskSettings.ImageAutoResize;
            cbImageKeepAspectRatio.Checked = Setting.TaskSettings.ImageKeepAspectRatio;
            cbImageUseSmoothScaling.Checked = Setting.TaskSettings.ImageUseSmoothScaling;

            switch (Setting.TaskSettings.ImageScaleType)
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

            nudImageScalePercentageWidth.Value = Setting.TaskSettings.ImageScalePercentageWidth;
            nudImageScalePercentageHeight.Value = Setting.TaskSettings.ImageScalePercentageHeight;
            nudImageScaleToWidth.Value = Setting.TaskSettings.ImageScaleToWidth;
            nudImageScaleToHeight.Value = Setting.TaskSettings.ImageScaleToHeight;
            nudImageScaleSpecificWidth.Value = Setting.TaskSettings.ImageScaleSpecificWidth;
            nudImageScaleSpecificHeight.Value = Setting.TaskSettings.ImageScaleSpecificHeight;

            // Image - Effects
            cbImageEffectOnlyRegionCapture.Checked = Setting.TaskSettings.ImageEffectOnlyRegionCapture;
            btnBorderColor.BackColor = Setting.TaskSettings.BorderColor;
            nudBorderSize.Value = Setting.TaskSettings.BorderSize;
            nudImageShadowDarkness.Value = (decimal)Setting.TaskSettings.ShadowDarkness;
            nudImageShadowSize.Value = Setting.TaskSettings.ShadowSize;

            // Capture
            cbShowCursor.Checked = Setting.TaskSettings.ShowCursor;
            cbCaptureTransparent.Checked = Setting.TaskSettings.CaptureTransparent;
            cbCaptureShadow.Enabled = Setting.TaskSettings.CaptureTransparent;
            cbCaptureShadow.Checked = Setting.TaskSettings.CaptureShadow;
            nudCaptureShadowOffset.Value = Setting.TaskSettings.CaptureShadowOffset;
            cbCaptureClientArea.Checked = Setting.TaskSettings.CaptureClientArea;
            cbScreenshotDelay.Checked = Setting.TaskSettings.IsDelayScreenshot;
            nudScreenshotDelay.Value = Setting.TaskSettings.DelayScreenshot;
            cbCaptureAutoHideTaskbar.Checked = Setting.TaskSettings.CaptureAutoHideTaskbar;

            if (Setting.TaskSettings.SurfaceOptions == null) Setting.TaskSettings.SurfaceOptions = new SurfaceOptions();
            cbDrawBorder.Checked = Setting.TaskSettings.SurfaceOptions.DrawBorder;
            cbDrawCheckerboard.Checked = Setting.TaskSettings.SurfaceOptions.DrawChecker;
            cbQuickCrop.Checked = Setting.TaskSettings.SurfaceOptions.QuickCrop;
            cbFixedShapeSize.Checked = Setting.TaskSettings.SurfaceOptions.IsFixedSize;
            nudFixedShapeSizeWidth.Value = Setting.TaskSettings.SurfaceOptions.FixedSize.Width;
            nudFixedShapeSizeHeight.Value = Setting.TaskSettings.SurfaceOptions.FixedSize.Height;
            cbShapeIncludeControls.Checked = Setting.TaskSettings.SurfaceOptions.IncludeControls;
            cbShapeForceWindowCapture.Checked = Setting.TaskSettings.SurfaceOptions.ForceWindowCapture;

            cbScreenRecorderHotkeyStartInstantly.Checked = Setting.TaskSettings.ScreenRecorderHotkeyStartInstantly;

            // Actions
            TaskHelper.AddDefaultExternalPrograms(Setting.TaskSettings);

            foreach (ExternalProgram fileAction in Setting.TaskSettings.ExternalPrograms)
            {
                AddFileAction(fileAction);
            }

            // Upload / Name pattern
            txtNameFormatPattern.Text = Setting.TaskSettings.NameFormatPattern;
            txtNameFormatPatternActiveWindow.Text = Setting.TaskSettings.NameFormatPatternActiveWindow;
            cmsNameFormatPattern = NameParser.CreateCodesMenu(txtNameFormatPattern, ReplacementVariables.n);
            cmsNameFormatPatternActiveWindow = NameParser.CreateCodesMenu(txtNameFormatPatternActiveWindow, ReplacementVariables.n);
            cbFileUploadUseNamePattern.Checked = Setting.TaskSettings.FileUploadUseNamePattern;

            // Upload / Clipboard upload
            cbShowClipboardContentViewer.Checked = Setting.TaskSettings.ShowClipboardContentViewer;
            cbClipboardUploadAutoDetectURL.Checked = Setting.TaskSettings.ClipboardUploadAutoDetectURL;
            cbClipboardUploadUseAfterCaptureTasks.Checked = Setting.TaskSettings.ClipboardUploadUseAfterCaptureTasks;
            cbClipboardUploadExcludeImageEffects.Checked = Setting.TaskSettings.ClipboardUploadExcludeImageEffects;

            // Upload / Watch folder
            cbWatchFolderEnabled.Checked = Setting.TaskSettings.WatchFolderEnabled;

            if (Setting.TaskSettings.WatchFolderList == null)
            {
                Setting.TaskSettings.WatchFolderList = new List<WatchFolder>();
            }
            else
            {
                foreach (WatchFolder watchFolder in Setting.TaskSettings.WatchFolderList)
                {
                    AddWatchFolder(watchFolder);
                }
            }

            // Advanced
            pgTaskSettings.SelectedObject = Setting.TaskSettings;

            loaded = true;
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

        private void SetEnumChecked<T>(T value, params ToolStripDropDown[] parents)
        {
            int index = Helpers.GetEnumMemberIndex(value);

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
            Setting.TaskSettings.UseImageFormat2FileUpload = cbUseImageFormat2FileUpload.Checked;
        }

        private void cbImageFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageFormat = (EImageFormat)cbImageFormat.SelectedIndex;
        }

        private void cbImageGIFQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageGIFQuality = (GIFQuality)cbImageGIFQuality.SelectedIndex;
        }

        private void cbImageFormat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageFormat2 = (EImageFormat)cbImageFormat2.SelectedIndex;
        }

        private void nudImageJPEGQuality_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageJPEGQuality = (int)nudImageJPEGQuality.Value;
        }

        private void nudUseImageFormat2After_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageSizeLimit = (int)nudUseImageFormat2After.Value;
        }

        private void cbImageUseSmoothScaling_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageUseSmoothScaling = cbImageUseSmoothScaling.Checked;
        }

        private void cbImageKeepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageKeepAspectRatio = cbImageKeepAspectRatio.Checked;

            if (Setting.TaskSettings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageHeight.Value = nudImageScalePercentageWidth.Value;
            }
        }

        private void cbImageAutoResize_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageAutoResize = cbImageAutoResize.Checked;
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
                Setting.TaskSettings.ImageScaleType = ImageScaleType.Percentage;
            }
            else if (rbImageScaleTypeToWidth.Checked)
            {
                Setting.TaskSettings.ImageScaleType = ImageScaleType.Width;
            }
            else if (rbImageScaleTypeToHeight.Checked)
            {
                Setting.TaskSettings.ImageScaleType = ImageScaleType.Height;
            }
            else if (rbImageScaleTypeSpecific.Checked)
            {
                Setting.TaskSettings.ImageScaleType = ImageScaleType.Specific;
                aspectRatioEnabled = false;
            }

            cbImageKeepAspectRatio.Enabled = aspectRatioEnabled;
        }

        private void nudImageScalePercentageWidth_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageScalePercentageWidth = (int)nudImageScalePercentageWidth.Value;

            if (Setting.TaskSettings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageHeight.Value = Setting.TaskSettings.ImageScalePercentageWidth;
            }
        }

        private void nudImageScaleToHeight_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageScaleToHeight = (int)nudImageScaleToHeight.Value;
        }

        private void nudImageScalePercentageHeight_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageScalePercentageHeight = (int)nudImageScalePercentageHeight.Value;

            if (Setting.TaskSettings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageWidth.Value = Setting.TaskSettings.ImageScalePercentageHeight;
            }
        }

        private void nudImageScaleToWidth_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageScaleToWidth = (int)nudImageScaleToWidth.Value;
        }

        private void nudImageScaleSpecificHeight_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageScaleSpecificHeight = (int)nudImageScaleSpecificHeight.Value;
        }

        private void nudImageScaleSpecificWidth_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageScaleSpecificWidth = (int)nudImageScaleSpecificWidth.Value;
        }

        private void nudImageShadowSize_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ShadowSize = (int)nudImageShadowSize.Value;
        }

        private void nudImageShadowDarkness_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ShadowDarkness = (float)nudImageShadowDarkness.Value;
        }

        private void cbImageEffectOnlyRectangleCapture_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ImageEffectOnlyRegionCapture = cbImageEffectOnlyRegionCapture.Checked;
        }

        private void btnWatermarkSettings_Click(object sender, EventArgs e)
        {
            using (WatermarkUI watermarkForm = new WatermarkUI(Setting.TaskSettings.WatermarkConfig))
            {
                watermarkForm.Icon = Icon;
                watermarkForm.ShowDialog();
            }
        }

        private void nudBorderSize_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.BorderSize = (int)nudBorderSize.Value;
        }

        private void btnBorderColor_Click(object sender, EventArgs e)
        {
            using (DialogColor dColor = new DialogColor(Setting.TaskSettings.BorderColor))
            {
                if (dColor.ShowDialog() == DialogResult.OK)
                {
                    Setting.TaskSettings.BorderColor = dColor.Color;
                    btnBorderColor.BackColor = dColor.Color;
                }
            }
        }

        private void cbCaptureAutoHideTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureAutoHideTaskbar = cbCaptureAutoHideTaskbar.Checked;
        }

        private void nudScreenshotDelay_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.DelayScreenshot = nudScreenshotDelay.Value;
        }

        private void cbScreenshotDelay_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.IsDelayScreenshot = cbScreenshotDelay.Checked;
        }

        private void nudCaptureShadowOffset_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureShadowOffset = (int)nudCaptureShadowOffset.Value;
        }

        private void cbCaptureClientArea_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureClientArea = cbCaptureClientArea.Checked;
        }

        private void cbCaptureShadow_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureShadow = cbCaptureShadow.Checked;
        }

        private void cbShowCursor_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ShowCursor = cbShowCursor.Checked;
        }

        private void cbCaptureTransparent_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.CaptureTransparent = cbCaptureTransparent.Checked;
            cbCaptureShadow.Enabled = Setting.TaskSettings.CaptureTransparent;
        }

        private void btnOpenCapturingShapesWiki_Click(object sender, EventArgs e)
        {
            Helpers.LoadBrowserAsync(Links.URL_WIKI_CapturingShapes);
        }

        private void cbShapeForceWindowCapture_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.SurfaceOptions.ForceWindowCapture = cbShapeForceWindowCapture.Checked;
        }

        private void cbShapeIncludeControls_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.SurfaceOptions.IncludeControls = cbShapeIncludeControls.Checked;
        }

        private void cbDrawBorder_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.SurfaceOptions.DrawBorder = cbDrawBorder.Checked;
        }

        private void cbQuickCrop_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.SurfaceOptions.QuickCrop = cbQuickCrop.Checked;
        }

        private void nudFixedShapeSizeHeight_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.SurfaceOptions.FixedSize = new Size(Setting.TaskSettings.SurfaceOptions.FixedSize.Width, (int)nudFixedShapeSizeHeight.Value);
        }

        private void cbDrawCheckerboard_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.SurfaceOptions.DrawChecker = cbDrawCheckerboard.Checked;
        }

        private void nudFixedShapeSizeWidth_ValueChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.SurfaceOptions.FixedSize = new Size((int)nudFixedShapeSizeWidth.Value, Setting.TaskSettings.SurfaceOptions.FixedSize.Height);
        }

        private void cbFixedShapeSize_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.SurfaceOptions.IsFixedSize = cbFixedShapeSize.Checked;
        }

        private void cbScreenRecorderHotkeyStartInstantly_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ScreenRecorderHotkeyStartInstantly = cbScreenRecorderHotkeyStartInstantly.Checked;
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
            Setting.TaskSettings.FileUploadUseNamePattern = cbFileUploadUseNamePattern.Checked;
        }

        private void txtNameFormatPatternActiveWindow_TextChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.NameFormatPatternActiveWindow = txtNameFormatPatternActiveWindow.Text;
            NameParser nameParser = new NameParser(NameParserType.FileName) { AutoIncrementNumber = Setting.TaskSettings.AutoIncrementNumber, WindowText = Text };
            lblNameFormatPatternPreviewActiveWindow.Text = "Preview: " + nameParser.Parse(Setting.TaskSettings.NameFormatPatternActiveWindow);
        }

        private void btnResetAutoIncrementNumber_Click(object sender, EventArgs e)
        {
            Setting.TaskSettings.AutoIncrementNumber = 0;
        }

        private void txtNameFormatPattern_TextChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.NameFormatPattern = txtNameFormatPattern.Text;
            NameParser nameParser = new NameParser(NameParserType.FileName) { AutoIncrementNumber = Setting.TaskSettings.AutoIncrementNumber };
            lblNameFormatPatternPreview.Text = "Preview: " + nameParser.Parse(Setting.TaskSettings.NameFormatPattern);
        }

        private void cbShowClipboardContentViewer_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ShowClipboardContentViewer = cbShowClipboardContentViewer.Checked;
        }

        private void cbClipboardUploadUseAfterCaptureTasks_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ClipboardUploadUseAfterCaptureTasks = cbClipboardUploadUseAfterCaptureTasks.Checked;
        }

        private void cbClipboardUploadAutoDetectURL_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ClipboardUploadAutoDetectURL = cbClipboardUploadAutoDetectURL.Checked;
        }

        private void cbClipboardUploadExcludeImageEffects_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.ClipboardUploadExcludeImageEffects = cbClipboardUploadExcludeImageEffects.Checked;
        }

        private void cbWatchFolderEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                Setting.TaskSettings.WatchFolderEnabled = cbWatchFolderEnabled.Checked;

                foreach (WatchFolder watchFolder in Setting.TaskSettings.WatchFolderList)
                {
                    if (Setting.TaskSettings.WatchFolderEnabled)
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

        private void btnWatchFolderRemove_Click(object sender, EventArgs e)
        {
            if (lvWatchFolderList.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvWatchFolderList.SelectedItems[0];
                WatchFolder watchFolder = lvi.Tag as WatchFolder;

                Setting.TaskSettings.WatchFolderList.Remove(watchFolder);
                lvWatchFolderList.Items.Remove(lvi);
                watchFolder.Dispose();
            }
        }

        private void btnWatchFolderAdd_Click(object sender, EventArgs e)
        {
            using (WatchFolderForm form = new WatchFolderForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    WatchFolder watchFolder = form.WatchFolder;
                    watchFolder.FileWatcherTrigger += path => UploadManager.UploadFile(path, Program.Settings.DefaultTaskSettings);
                    Setting.TaskSettings.WatchFolderList.Add(watchFolder);
                    AddWatchFolder(watchFolder);

                    if (Setting.TaskSettings.WatchFolderEnabled)
                    {
                        watchFolder.Enable();
                    }
                }
            }
        }

        private void AddWatchFolder(WatchFolder watchFolder)
        {
            ListViewItem lvi = new ListViewItem(watchFolder.FolderPath ?? "");
            lvi.Tag = watchFolder;
            lvi.SubItems.Add(watchFolder.Filter ?? "");
            lvi.SubItems.Add(watchFolder.IncludeSubdirectories.ToString());
            lvWatchFolderList.Items.Add(lvi);
        }
    }
}