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
using Newtonsoft.Json;
using ScreenCapture;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using UploadersLib;

namespace ShareX
{
    public class TaskSettings
    {
        public string Description = string.Empty;
        public HotkeyType Job = HotkeyType.None;

        public bool UseDefaultAfterCaptureJob = true;
        public AfterCaptureTasks AfterCaptureJob = AfterCaptureTasks.SaveImageToFile | AfterCaptureTasks.UploadImageToHost;

        public bool UseDefaultAfterUploadJob = true;
        public AfterUploadTasks AfterUploadJob = AfterUploadTasks.CopyURLToClipboard;

        public bool UseDefaultDestinations = true;
        public ImageDestination ImageDestination = ImageDestination.Imgur;
        public TextDestination TextDestination = TextDestination.Pastebin;
        public FileDestination FileDestination = FileDestination.Dropbox;
        public UrlShortenerType URLShortenerDestination = UrlShortenerType.BITLY;
        public SocialNetworkingService SocialNetworkingServiceDestination = SocialNetworkingService.Twitter;

        public bool UseDefaultImageSettings = true;
        public TaskSettingsImage ImageSettings = new TaskSettingsImage();

        public bool UseDefaultCaptureSettings = true;
        public TaskSettingsCapture CaptureSettings = new TaskSettingsCapture();

        public bool UseDefaultUploadSettings = true;
        public TaskSettingsUpload UploadSettings = new TaskSettingsUpload();

        public bool UseDefaultActions = true;
        public List<ExternalProgram> ExternalPrograms = new List<ExternalProgram>();

        public bool UseDefaultAdvancedSettings = true;
        public TaskSettingsAdvanced AdvancedSettings = new TaskSettingsAdvanced();

        [JsonIgnore]
        public TaskSettings TaskSettingsReference { get; private set; }

        public TaskSettings()
        {
            SetDefaultSettings();
        }

        public static TaskSettings GetSafeTaskSettings(TaskSettings taskSettings)
        {
            TaskSettings taskSettingsCopy = taskSettings.Copy();
            taskSettingsCopy.TaskSettingsReference = taskSettings;
            taskSettingsCopy.SetDefaultSettings();
            return taskSettingsCopy;
        }

        private void SetDefaultSettings()
        {
            if (Program.DefaultTaskSettings != null)
            {
                TaskSettings defaultTaskSettings = Program.DefaultTaskSettings.Copy();

                if (UseDefaultAfterCaptureJob)
                {
                    AfterCaptureJob = defaultTaskSettings.AfterCaptureJob;
                }

                if (UseDefaultAfterUploadJob)
                {
                    AfterUploadJob = defaultTaskSettings.AfterUploadJob;
                }

                if (UseDefaultDestinations)
                {
                    ImageDestination = defaultTaskSettings.ImageDestination;
                    TextDestination = defaultTaskSettings.TextDestination;
                    FileDestination = defaultTaskSettings.FileDestination;
                    URLShortenerDestination = defaultTaskSettings.URLShortenerDestination;
                    SocialNetworkingServiceDestination = defaultTaskSettings.SocialNetworkingServiceDestination;
                }

                if (UseDefaultImageSettings)
                {
                    ImageSettings = defaultTaskSettings.ImageSettings;
                }

                if (UseDefaultCaptureSettings)
                {
                    CaptureSettings = defaultTaskSettings.CaptureSettings;
                }
                if (UseDefaultUploadSettings)
                {
                    UploadSettings = defaultTaskSettings.UploadSettings;
                }

                if (UseDefaultActions)
                {
                    ExternalPrograms = defaultTaskSettings.ExternalPrograms;
                }

                if (UseDefaultAdvancedSettings)
                {
                    AdvancedSettings = defaultTaskSettings.AdvancedSettings;
                }
            }
        }
    }

    public class TaskSettingsImage
    {
        #region Image / Quality

        public EImageFormat ImageFormat = EImageFormat.PNG;
        public int ImageJPEGQuality = 90;
        public GIFQuality ImageGIFQuality = GIFQuality.Default;
        public int ImageSizeLimit = 1024;
        public EImageFormat ImageFormat2 = EImageFormat.JPEG;
        public bool UseImageFormat2FileUpload = false;

        #endregion Image / Quality

        #region Image / Resize

        public bool ImageAutoResize = false;
        public bool ImageKeepAspectRatio = false;
        public bool ImageUseSmoothScaling = true;
        public ImageScaleType ImageScaleType = ImageScaleType.Percentage;
        public int ImageScalePercentageWidth = 100;
        public int ImageScalePercentageHeight = 100;
        public int ImageScaleToWidth = 100;
        public int ImageScaleToHeight = 100;
        public int ImageScaleSpecificWidth = 100;
        public int ImageScaleSpecificHeight = 100;

        #endregion Image / Resize

        #region Image / Effects

        public WatermarkConfig WatermarkConfig = new WatermarkConfig();

        public bool ImageEffectOnlyRegionCapture = true;
        public BorderType BorderType = BorderType.Outside;
        public XmlColor BorderColor = Color.Black;
        public int BorderSize = 1;
        public float ShadowDarkness = 0.6f;
        public int ShadowSize = 9;
        public Point ShadowOffset = new Point(0, 0);

        #endregion Image / Effects
    }

    public class TaskSettingsCapture
    {
        #region Capture / General

        public bool ShowCursor = true;
        public bool CaptureTransparent = true;
        public bool CaptureShadow = true;
        public int CaptureShadowOffset = 20;
        public bool CaptureClientArea = false;
        public bool IsDelayScreenshot = false;
        public decimal DelayScreenshot = 2.0m;
        public bool CaptureAutoHideTaskbar = false;

        #endregion Capture / General

        #region Capture / Shape capture

        public SurfaceOptions SurfaceOptions = new SurfaceOptions();

        #endregion Capture / Shape capture

        #region Capture / Screen recorder

        public int ScreenRecordFPS = 5;
        public bool ScreenRecordFixedDuration = true;
        public float ScreenRecordDuration = 3f;
        public ScreenRecordOutput ScreenRecordOutput = ScreenRecordOutput.GIF;

        public string ScreenRecordCommandLinePath = "x264.exe";
        public string ScreenRecordCommandLineArgs = "--output %output %input";
        public string ScreenRecordCommandLineOutputExtension = "mp4";

        #endregion Capture / Screen recorder
    }

    public class TaskSettingsUpload
    {
        #region Upload / Name pattern

        public string NameFormatPattern = "%y-%mo-%d_%h-%mi-%s"; // Test: %y %mo %mon %mon2 %d %h %mi %s %ms %w %w2 %pm %rn %ra %width %height %app %ver
        public string NameFormatPatternActiveWindow = "%t_%y-%mo-%d_%h-%mi-%s";
        public int AutoIncrementNumber = 0;
        public bool FileUploadUseNamePattern = false;

        #endregion Upload / Name pattern

        #region Upload / Clipboard upload

        public bool ShowClipboardContentViewer = true;
        public bool ClipboardUploadAutoDetectURL = true;
        public bool ClipboardUploadUseAfterCaptureTasks = false;
        public bool ClipboardUploadExcludeImageEffects = true;

        #endregion Upload / Clipboard upload
    }

    public class TaskSettingsAdvanced
    {
        #region Interaction

        [Category("Interaction"), DefaultValue(false), Description("Disable notifications.")]
        public bool DisableNotifications { get; set; }

        #endregion Interaction

        #region Upload Text

        [Category("Upload Text"), DefaultValue("text"), Description("Text format e.g. csharp, cpp, etc.")]
        public string TextFormat { get; set; }

        [Category("Upload Text"), DefaultValue("txt"), Description("File extension when saving text to the local hard disk.")]
        public string TextFileExtension { get; set; }

        #endregion Upload Text

        [Category("After capture / Clipboard"), DefaultValue("$url"), Description("Clipboard content format after uploading. Supported variables: $url, $shorturl, $thumbnailurl, $deletionurl, $folderpath, $foldername, $filepath, $filename and other variables such as %y-%m-%d etc.")]
        public string ClipboardContentFormat { get; set; }

        public TaskSettingsAdvanced()
        {
            Helpers.ApplyDefaultPropertyValues(this);
        }
    }
}