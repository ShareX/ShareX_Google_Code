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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UploadersLib;

namespace ShareX
{
    public partial class TaskSettingsForm : Form
    {
        public TaskSettings TaskSettings { get; private set; }
        public bool IsDefault { get; private set; }

        private ContextMenuStrip cmsNameFormatPattern, cmsNameFormatPatternActiveWindow;
        private bool loaded;

        public TaskSettingsForm(TaskSettings hotkeySetting, bool isDefault = false)
        {
            InitializeComponent();
            Icon = Resources.ShareXIcon;
            TaskSettings = hotkeySetting;
            IsDefault = isDefault;

            if (IsDefault)
            {
                Text = Application.ProductName + " - Task settings";
                tcHotkeySettings.TabPages.Remove(tpTask);
                chkUseDefaultImageSettings.Visible = chkUseDefaultCaptureSettings.Visible = chkUseDefaultActions.Visible =
                    chkUseDefaultUploadSettings.Visible = chkUseDefaultAdvancedSettings.Visible = false;
            }
            else
            {
                Text = Application.ProductName + " - Task settings for " + TaskSettings.Description;
                tbDescription.Text = TaskSettings.Description;
                cbUseDefaultAfterCaptureSettings.Checked = TaskSettings.UseDefaultAfterCaptureJob;
                cbUseDefaultAfterUploadSettings.Checked = TaskSettings.UseDefaultAfterUploadJob;
                cbUseDefaultDestinationSettings.Checked = TaskSettings.UseDefaultDestinations;
                chkUseDefaultImageSettings.Checked = TaskSettings.UseDefaultImageSettings;
                chkUseDefaultCaptureSettings.Checked = TaskSettings.UseDefaultCaptureSettings;
                chkUseDefaultActions.Checked = TaskSettings.UseDefaultActions;
                chkUseDefaultUploadSettings.Checked = TaskSettings.UseDefaultUploadSettings;
                chkUseDefaultAdvancedSettings.Checked = TaskSettings.UseDefaultAdvancedSettings;
            }

            AddEnumItems<HotkeyType>(x => TaskSettings.Job = x, cmsTask);
            AddMultiEnumItems<AfterCaptureTasks>(x => TaskSettings.AfterCaptureJob = TaskSettings.AfterCaptureJob.Swap(x), cmsAfterCapture);
            AddMultiEnumItems<AfterUploadTasks>(x => TaskSettings.AfterUploadJob = TaskSettings.AfterUploadJob.Swap(x), cmsAfterUpload);
            AddEnumItems<ImageDestination>(x => TaskSettings.ImageDestination = x, cmsImageUploaders);
            AddEnumItems<TextDestination>(x => TaskSettings.TextDestination = x, cmsTextUploaders);
            AddEnumItems<FileDestination>(x => TaskSettings.FileDestination = x, cmsFileUploaders);
            AddEnumItems<UrlShortenerType>(x => TaskSettings.URLShortenerDestination = x, cmsURLShorteners);
            AddEnumItems<SocialNetworkingService>(x => TaskSettings.SocialNetworkingServiceDestination = x, cmsSocialNetworkingServices);

            SetEnumChecked(TaskSettings.Job, cmsTask);
            SetMultiEnumChecked(TaskSettings.AfterCaptureJob, cmsAfterCapture);
            SetMultiEnumChecked(TaskSettings.AfterUploadJob, cmsAfterUpload);
            SetEnumChecked(TaskSettings.ImageDestination, cmsImageUploaders);
            SetEnumChecked(TaskSettings.TextDestination, cmsTextUploaders);
            SetEnumChecked(TaskSettings.FileDestination, cmsFileUploaders);
            SetEnumChecked(TaskSettings.URLShortenerDestination, cmsURLShorteners);
            SetEnumChecked(TaskSettings.SocialNetworkingServiceDestination, cmsSocialNetworkingServices);

            UpdateDestinationStates();
            UpdateUploaderMenuNames();

            // Image - Quality
            cbImageFormat.SelectedIndex = (int)TaskSettings.ImageSettings.ImageFormat;
            nudImageJPEGQuality.Value = TaskSettings.ImageSettings.ImageJPEGQuality;
            cbImageGIFQuality.SelectedIndex = (int)TaskSettings.ImageSettings.ImageGIFQuality;
            nudUseImageFormat2After.Value = TaskSettings.ImageSettings.ImageSizeLimit;
            cbImageFormat2.SelectedIndex = (int)TaskSettings.ImageSettings.ImageFormat2;
            chkProcessImagesDuringFileUpload.Checked = TaskSettings.ImageSettings.ProcessImagesDuringFileUpload;

            // Image - Resize
            cbImageAutoResize.Checked = TaskSettings.ImageSettings.ImageAutoResize;
            cbImageKeepAspectRatio.Checked = TaskSettings.ImageSettings.ImageKeepAspectRatio;
            cbImageUseSmoothScaling.Checked = TaskSettings.ImageSettings.ImageUseSmoothScaling;

            switch (TaskSettings.ImageSettings.ImageScaleType)
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

            nudImageScalePercentageWidth.Value = TaskSettings.ImageSettings.ImageScalePercentageWidth;
            nudImageScalePercentageHeight.Value = TaskSettings.ImageSettings.ImageScalePercentageHeight;
            nudImageScaleToWidth.Value = TaskSettings.ImageSettings.ImageScaleToWidth;
            nudImageScaleToHeight.Value = TaskSettings.ImageSettings.ImageScaleToHeight;
            nudImageScaleSpecificWidth.Value = TaskSettings.ImageSettings.ImageScaleSpecificWidth;
            nudImageScaleSpecificHeight.Value = TaskSettings.ImageSettings.ImageScaleSpecificHeight;

            // Image - Effects
            cbImageEffectOnlyRegionCapture.Checked = TaskSettings.ImageSettings.ImageEffectOnlyRegionCapture;
            btnBorderColor.BackColor = TaskSettings.ImageSettings.BorderColor;
            nudBorderSize.Value = TaskSettings.ImageSettings.BorderSize;
            nudImageShadowDarkness.Value = (decimal)TaskSettings.ImageSettings.ShadowDarkness;
            nudImageShadowSize.Value = TaskSettings.ImageSettings.ShadowSize;

            // Capture
            cbShowCursor.Checked = TaskSettings.CaptureSettings.ShowCursor;
            cbCaptureTransparent.Checked = TaskSettings.CaptureSettings.CaptureTransparent;
            cbCaptureShadow.Enabled = TaskSettings.CaptureSettings.CaptureTransparent;
            cbCaptureShadow.Checked = TaskSettings.CaptureSettings.CaptureShadow;
            nudCaptureShadowOffset.Value = TaskSettings.CaptureSettings.CaptureShadowOffset;
            cbCaptureClientArea.Checked = TaskSettings.CaptureSettings.CaptureClientArea;
            cbScreenshotDelay.Checked = TaskSettings.CaptureSettings.IsDelayScreenshot;
            nudScreenshotDelay.Value = TaskSettings.CaptureSettings.DelayScreenshot;
            cbCaptureAutoHideTaskbar.Checked = TaskSettings.CaptureSettings.CaptureAutoHideTaskbar;

            if (TaskSettings.CaptureSettings.SurfaceOptions == null) TaskSettings.CaptureSettings.SurfaceOptions = new SurfaceOptions();
            cbDrawBorder.Checked = TaskSettings.CaptureSettings.SurfaceOptions.DrawBorder;
            cbDrawCheckerboard.Checked = TaskSettings.CaptureSettings.SurfaceOptions.DrawChecker;
            cbCaptureMultipleShapes.Checked = TaskSettings.CaptureSettings.SurfaceOptions.AllowMoveResize;
            cbFixedShapeSize.Checked = TaskSettings.CaptureSettings.SurfaceOptions.IsFixedSize;
            nudFixedShapeSizeWidth.Value = TaskSettings.CaptureSettings.SurfaceOptions.FixedSize.Width;
            nudFixedShapeSizeHeight.Value = TaskSettings.CaptureSettings.SurfaceOptions.FixedSize.Height;
            cbShapeIncludeControls.Checked = TaskSettings.CaptureSettings.SurfaceOptions.IncludeControls;
            cbShapeForceWindowCapture.Checked = TaskSettings.CaptureSettings.SurfaceOptions.ForceWindowCapture;

            // Capture / Screencast

            nudFPS.Value = TaskSettings.CaptureSettings.ScreenRecordFPS;
            cbFixedDuration.Checked = TaskSettings.CaptureSettings.ScreenRecordFixedDuration;
            nudDuration.Enabled = TaskSettings.CaptureSettings.ScreenRecordFixedDuration;
            nudDuration.Value = (decimal)TaskSettings.CaptureSettings.ScreenRecordDuration;

            cbFixedDuration.Checked = TaskSettings.CaptureSettings.ScreenRecordFixedDuration;
            cbOutput.Items.AddRange(Helpers.GetEnumDescriptions<ScreenRecordOutput>());
            cbOutput.SelectedIndex = (int)TaskSettings.CaptureSettings.ScreenRecordOutput;
            tbCommandLinePath.Text = TaskSettings.CaptureSettings.ScreenRecordCommandLinePath;
            tbCommandLineArgs.Text = TaskSettings.CaptureSettings.ScreenRecordCommandLineArgs;
            tbCommandLineOutputExtension.Text = TaskSettings.CaptureSettings.ScreenRecordCommandLineOutputExtension;

            // Actions
            TaskHelper.AddDefaultExternalPrograms(TaskSettings);

            foreach (ExternalProgram fileAction in TaskSettings.ExternalPrograms)
            {
                AddFileAction(fileAction);
            }

            // Upload / Name pattern
            txtNameFormatPattern.Text = TaskSettings.UploadSettings.NameFormatPattern;
            txtNameFormatPatternActiveWindow.Text = TaskSettings.UploadSettings.NameFormatPatternActiveWindow;
            cmsNameFormatPattern = NameParser.CreateCodesMenu(txtNameFormatPattern, ReplacementVariables.n);
            cmsNameFormatPatternActiveWindow = NameParser.CreateCodesMenu(txtNameFormatPatternActiveWindow, ReplacementVariables.n);
            cbFileUploadUseNamePattern.Checked = TaskSettings.UploadSettings.FileUploadUseNamePattern;

            // Upload / Clipboard upload
            cbShowClipboardContentViewer.Checked = TaskSettings.UploadSettings.ShowClipboardContentViewer;
            cbClipboardUploadAutoDetectURL.Checked = TaskSettings.UploadSettings.ClipboardUploadAutoDetectURL;

            // Watch folders
            cbWatchFolderEnabled.Checked = TaskSettings.WatchFolderEnabled;

            if (TaskSettings.WatchFolderList == null)
            {
                TaskSettings.WatchFolderList = new List<WatchFolderSettings>();
            }
            else
            {
                foreach (WatchFolderSettings watchFolder in TaskSettings.WatchFolderList)
                {
                    AddWatchFolder(watchFolder);
                }
            }

            // Advanced
            pgTaskSettings.SelectedObject = TaskSettings.AdvancedSettings;

            UpdateDefaultSettingVisibility();
            loaded = true;
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            TaskSettings.Description = tbDescription.Text;
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
            TaskSettings.UseDefaultAfterCaptureJob = cbUseDefaultAfterCaptureSettings.Checked;
            btnAfterCapture.Enabled = !TaskSettings.UseDefaultAfterCaptureJob;
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
            TaskSettings.UseDefaultAfterUploadJob = cbUseDefaultAfterUploadSettings.Checked;
            btnAfterUpload.Enabled = !TaskSettings.UseDefaultAfterUploadJob;
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
            TaskSettings.UseDefaultDestinations = cbUseDefaultDestinationSettings.Checked;
            btnImageUploaders.Enabled = !TaskSettings.UseDefaultDestinations;
            btnTextUploaders.Enabled = !TaskSettings.UseDefaultDestinations;
            btnFileUploaders.Enabled = !TaskSettings.UseDefaultDestinations;
            btnURLShorteners.Enabled = !TaskSettings.UseDefaultDestinations;
            btnSocialNetworkingServices.Enabled = !TaskSettings.UseDefaultDestinations;
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
            string[] enums = Helpers.GetEnumDescriptions<T>().Select(x => x.Replace("&", "&&")).ToArray();

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
            string[] enums = Enum.GetValues(typeof(T)).Cast<Enum>().Skip(1).Select(x => x.GetDescription().Replace("&", "&&")).ToArray();

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
            btnTask.Text = "Task: " + TaskSettings.Job.GetDescription();

            btnAfterCapture.Text = "After capture: " + string.Join(", ", TaskSettings.AfterCaptureJob.GetFlags<AfterCaptureTasks>().
                Select(x => x.GetDescription()).ToArray());

            btnAfterUpload.Text = "After upload: " + string.Join(", ", TaskSettings.AfterUploadJob.GetFlags<AfterUploadTasks>().
                Select(x => x.GetDescription()).ToArray());

            string imageUploader = TaskSettings.ImageDestination == ImageDestination.FileUploader ?
                TaskSettings.FileDestination.GetDescription() : TaskSettings.ImageDestination.GetDescription();
            btnImageUploaders.Text = "Image uploader: " + imageUploader;

            string textUploader = TaskSettings.TextDestination == TextDestination.FileUploader ?
                TaskSettings.FileDestination.GetDescription() : TaskSettings.TextDestination.GetDescription();
            btnTextUploaders.Text = "Text uploader: " + textUploader;

            btnFileUploaders.Text = "File uploader: " + TaskSettings.FileDestination.GetDescription();

            btnURLShorteners.Text = "URL shortener: " + TaskSettings.URLShortenerDestination.GetDescription();

            btnSocialNetworkingServices.Text = "Social networking service: " + TaskSettings.SocialNetworkingServiceDestination.GetDescription();
        }

        private void cbUseImageFormat2FileUpload_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ProcessImagesDuringFileUpload = chkProcessImagesDuringFileUpload.Checked;
        }

        private void cbImageFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageFormat = (EImageFormat)cbImageFormat.SelectedIndex;
        }

        private void cbImageGIFQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageGIFQuality = (GIFQuality)cbImageGIFQuality.SelectedIndex;
        }

        private void cbImageFormat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageFormat2 = (EImageFormat)cbImageFormat2.SelectedIndex;
        }

        private void nudImageJPEGQuality_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageJPEGQuality = (int)nudImageJPEGQuality.Value;
        }

        private void nudUseImageFormat2After_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageSizeLimit = (int)nudUseImageFormat2After.Value;
        }

        private void cbImageUseSmoothScaling_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageUseSmoothScaling = cbImageUseSmoothScaling.Checked;
        }

        private void cbImageKeepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageKeepAspectRatio = cbImageKeepAspectRatio.Checked;

            if (TaskSettings.ImageSettings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageHeight.Value = nudImageScalePercentageWidth.Value;
            }
        }

        private void cbImageAutoResize_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageAutoResize = cbImageAutoResize.Checked;
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
                TaskSettings.ImageSettings.ImageScaleType = ImageScaleType.Percentage;
            }
            else if (rbImageScaleTypeToWidth.Checked)
            {
                TaskSettings.ImageSettings.ImageScaleType = ImageScaleType.Width;
            }
            else if (rbImageScaleTypeToHeight.Checked)
            {
                TaskSettings.ImageSettings.ImageScaleType = ImageScaleType.Height;
            }
            else if (rbImageScaleTypeSpecific.Checked)
            {
                TaskSettings.ImageSettings.ImageScaleType = ImageScaleType.Specific;
                aspectRatioEnabled = false;
            }

            cbImageKeepAspectRatio.Enabled = aspectRatioEnabled;
        }

        private void nudImageScalePercentageWidth_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageScalePercentageWidth = (int)nudImageScalePercentageWidth.Value;

            if (TaskSettings.ImageSettings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageHeight.Value = TaskSettings.ImageSettings.ImageScalePercentageWidth;
            }
        }

        private void nudImageScaleToHeight_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageScaleToHeight = (int)nudImageScaleToHeight.Value;
        }

        private void nudImageScalePercentageHeight_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageScalePercentageHeight = (int)nudImageScalePercentageHeight.Value;

            if (TaskSettings.ImageSettings.ImageKeepAspectRatio)
            {
                nudImageScalePercentageWidth.Value = TaskSettings.ImageSettings.ImageScalePercentageHeight;
            }
        }

        private void nudImageScaleToWidth_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageScaleToWidth = (int)nudImageScaleToWidth.Value;
        }

        private void nudImageScaleSpecificHeight_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageScaleSpecificHeight = (int)nudImageScaleSpecificHeight.Value;
        }

        private void nudImageScaleSpecificWidth_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageScaleSpecificWidth = (int)nudImageScaleSpecificWidth.Value;
        }

        private void nudImageShadowSize_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ShadowSize = (int)nudImageShadowSize.Value;
        }

        private void nudImageShadowDarkness_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ShadowDarkness = (float)nudImageShadowDarkness.Value;
        }

        private void cbImageEffectOnlyRectangleCapture_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.ImageEffectOnlyRegionCapture = cbImageEffectOnlyRegionCapture.Checked;
        }

        private void btnWatermarkSettings_Click(object sender, EventArgs e)
        {
            using (WatermarkUI watermarkForm = new WatermarkUI(TaskSettings.ImageSettings.WatermarkConfig))
            {
                watermarkForm.ShowDialog();
            }
        }

        private void nudBorderSize_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.ImageSettings.BorderSize = (int)nudBorderSize.Value;
        }

        private void btnBorderColor_Click(object sender, EventArgs e)
        {
            using (DialogColor dColor = new DialogColor(TaskSettings.ImageSettings.BorderColor))
            {
                if (dColor.ShowDialog() == DialogResult.OK)
                {
                    TaskSettings.ImageSettings.BorderColor = dColor.Color;
                    btnBorderColor.BackColor = dColor.Color;
                }
            }
        }

        private void cbCaptureAutoHideTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.CaptureAutoHideTaskbar = cbCaptureAutoHideTaskbar.Checked;
        }

        private void nudScreenshotDelay_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.DelayScreenshot = nudScreenshotDelay.Value;
        }

        private void cbScreenshotDelay_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.IsDelayScreenshot = cbScreenshotDelay.Checked;
        }

        private void nudCaptureShadowOffset_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.CaptureShadowOffset = (int)nudCaptureShadowOffset.Value;
        }

        private void cbCaptureClientArea_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.CaptureClientArea = cbCaptureClientArea.Checked;
        }

        private void cbCaptureShadow_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.CaptureShadow = cbCaptureShadow.Checked;
        }

        private void cbShowCursor_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.ShowCursor = cbShowCursor.Checked;
        }

        private void cbCaptureTransparent_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.CaptureTransparent = cbCaptureTransparent.Checked;
            cbCaptureShadow.Enabled = TaskSettings.CaptureSettings.CaptureTransparent;
        }

        private void btnOpenCapturingShapesWiki_Click(object sender, EventArgs e)
        {
            Helpers.LoadBrowserAsync(Links.URL_WIKI_CapturingShapes);
        }

        private void cbShapeForceWindowCapture_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.SurfaceOptions.ForceWindowCapture = cbShapeForceWindowCapture.Checked;
        }

        private void cbShapeIncludeControls_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.SurfaceOptions.IncludeControls = cbShapeIncludeControls.Checked;
        }

        private void cbDrawBorder_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.SurfaceOptions.DrawBorder = cbDrawBorder.Checked;
        }

        private void cbQuickCrop_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.SurfaceOptions.AllowMoveResize = cbCaptureMultipleShapes.Checked;
        }

        private void nudFixedShapeSizeHeight_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.SurfaceOptions.FixedSize = new Size(TaskSettings.CaptureSettings.SurfaceOptions.FixedSize.Width, (int)nudFixedShapeSizeHeight.Value);
        }

        private void cbDrawCheckerboard_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.SurfaceOptions.DrawChecker = cbDrawCheckerboard.Checked;
        }

        private void nudFixedShapeSizeWidth_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.SurfaceOptions.FixedSize = new Size((int)nudFixedShapeSizeWidth.Value, TaskSettings.CaptureSettings.SurfaceOptions.FixedSize.Height);
        }

        private void cbFixedShapeSize_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.SurfaceOptions.IsFixedSize = cbFixedShapeSize.Checked;
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

                TaskSettings.ExternalPrograms.Remove(fileAction);
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
                    TaskSettings.ExternalPrograms.Add(fileAction);
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
            TaskSettings.UploadSettings.FileUploadUseNamePattern = cbFileUploadUseNamePattern.Checked;
        }

        private void txtNameFormatPatternActiveWindow_TextChanged(object sender, EventArgs e)
        {
            TaskSettings.UploadSettings.NameFormatPatternActiveWindow = txtNameFormatPatternActiveWindow.Text;
            NameParser nameParser = new NameParser(NameParserType.FileName) { AutoIncrementNumber = TaskSettings.UploadSettings.AutoIncrementNumber, WindowText = Text };
            lblNameFormatPatternPreviewActiveWindow.Text = "Preview: " + nameParser.Parse(TaskSettings.UploadSettings.NameFormatPatternActiveWindow);
        }

        private void btnResetAutoIncrementNumber_Click(object sender, EventArgs e)
        {
            TaskSettings.UploadSettings.AutoIncrementNumber = 0;
        }

        private void txtNameFormatPattern_TextChanged(object sender, EventArgs e)
        {
            TaskSettings.UploadSettings.NameFormatPattern = txtNameFormatPattern.Text;
            NameParser nameParser = new NameParser(NameParserType.FileName) { AutoIncrementNumber = TaskSettings.UploadSettings.AutoIncrementNumber };
            lblNameFormatPatternPreview.Text = "Preview: " + nameParser.Parse(TaskSettings.UploadSettings.NameFormatPattern);
        }

        private void cbShowClipboardContentViewer_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.UploadSettings.ShowClipboardContentViewer = cbShowClipboardContentViewer.Checked;
        }

        private void cbClipboardUploadAutoDetectURL_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.UploadSettings.ClipboardUploadAutoDetectURL = cbClipboardUploadAutoDetectURL.Checked;
        }

        private void chkUseDefaultImageSettings_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.UseDefaultImageSettings = chkUseDefaultImageSettings.Checked;
            UpdateDefaultSettingVisibility();
        }

        private void chkUseDefaultCaptureSettings_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.UseDefaultCaptureSettings = chkUseDefaultCaptureSettings.Checked;
            UpdateDefaultSettingVisibility();
        }

        private void chkUseDefaultActions_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.UseDefaultActions = chkUseDefaultActions.Checked;
            UpdateDefaultSettingVisibility();
        }

        private void chkUseDefaultUploadSettings_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.UseDefaultUploadSettings = chkUseDefaultUploadSettings.Checked;
            UpdateDefaultSettingVisibility();
        }

        private void chkUseDefaultAdvancedSettings_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.UseDefaultAdvancedSettings = chkUseDefaultAdvancedSettings.Checked;
            UpdateDefaultSettingVisibility();
        }

        private void UpdateDefaultSettingVisibility()
        {
            if (!IsDefault)
            {
                tcImage.Enabled = !TaskSettings.UseDefaultImageSettings;
                tcCapture.Enabled = !TaskSettings.UseDefaultCaptureSettings;
                pActions.Enabled = !TaskSettings.UseDefaultActions;
                tcUpload.Enabled = !TaskSettings.UseDefaultUploadSettings;
                pgTaskSettings.Enabled = !TaskSettings.UseDefaultAdvancedSettings;
            }
        }

        private void btnBrowseCommandLinePath_Click(object sender, EventArgs e)
        {
            Helpers.BrowseFile("ShareX - Choose encoder path", tbCommandLinePath, Program.StartupPath);
            TaskSettings.CaptureSettings.ScreenRecordCommandLinePath = tbCommandLinePath.Text;
        }

        private void tbCommandLineArgs_TextChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.ScreenRecordCommandLineArgs = tbCommandLineArgs.Text;
        }

        private void tbCommandLineOutputExtension_TextChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.ScreenRecordCommandLineOutputExtension = tbCommandLineOutputExtension.Text;
        }

        private void nudFPS_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.ScreenRecordFPS = (int)nudFPS.Value;
        }

        private void nudDuration_ValueChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.ScreenRecordDuration = (float)nudDuration.Value;
        }

        private void cbFixedDuration_CheckedChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.ScreenRecordFixedDuration = cbFixedDuration.Checked;
            nudDuration.Enabled = TaskSettings.CaptureSettings.ScreenRecordFixedDuration;
        }

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskSettings.CaptureSettings.ScreenRecordOutput = (ScreenRecordOutput)cbOutput.SelectedIndex;
            gbCommandLineEncoderSettings.Enabled = TaskSettings.CaptureSettings.ScreenRecordOutput == ScreenRecordOutput.AVICommandLine;
        }

        private void btnWatchFolderAdd_Click(object sender, EventArgs e)
        {
            using (WatchFolderForm form = new WatchFolderForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    AddWatchFolder(form.WatchFolder);
                }
            }
        }

        private void AddWatchFolder(WatchFolderSettings watchFolderSetting)
        {
            if (watchFolderSetting != null)
            {
                Program.WatchFolderManager.AddWatchFolder(watchFolderSetting, TaskSettings);

                ListViewItem lvi = new ListViewItem(watchFolderSetting.FolderPath ?? "");
                lvi.Tag = watchFolderSetting;
                lvi.SubItems.Add(watchFolderSetting.Filter ?? "");
                lvi.SubItems.Add(watchFolderSetting.IncludeSubdirectories.ToString());
                lvWatchFolderList.Items.Add(lvi);
            }
        }

        private void btnWatchFolderRemove_Click(object sender, EventArgs e)
        {
            if (lvWatchFolderList.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvWatchFolderList.SelectedItems[0];
                WatchFolderSettings watchFolderSetting = lvi.Tag as WatchFolderSettings;
                Program.WatchFolderManager.RemoveWatchFolder(watchFolderSetting);
                lvWatchFolderList.Items.Remove(lvi);
            }
        }

        private void cbWatchFolderEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                TaskSettings.WatchFolderEnabled = cbWatchFolderEnabled.Checked;

                foreach (WatchFolderSettings watchFolderSetting in TaskSettings.WatchFolderList)
                {
                    Program.WatchFolderManager.UpdateWatchFolderState(watchFolderSetting);
                }
            }
        }
    }
}