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
using HelpersLib.Hotkey;
using ScreenCapture;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UploadersLib;
using UploadersLib.HelperClasses;

namespace ShareX
{
    public class Settings : SettingsBase<Settings>
    {
        #region Main Form

        public AfterCaptureTasks AfterCaptureTasks = AfterCaptureTasks.SaveImageToFile | AfterCaptureTasks.UploadImageToHost;
        public AfterUploadTasks AfterUploadTasks = AfterUploadTasks.CopyURLToClipboard;
        public ImageDestination ImageUploaderDestination = ImageDestination.Imgur;
        public TextDestination TextUploaderDestination = TextDestination.Pastebin;
        public FileDestination FileUploaderDestination = FileDestination.Dropbox;
        public UrlShortenerType URLShortenerDestination = UrlShortenerType.Google;
        public SocialNetworkingService SocialServiceDestination = SocialNetworkingService.Twitter;
        public bool IsPreviewCollapsed = true;
        public int PreviewSplitterDistance = 0;
        public string FileUploadDefaultDirectory = "";

        public WindowState HistoryWindowState = new WindowState();
        public WindowState ImageHistoryWindowState = new WindowState();
        public int ImageHistoryViewMode = 3;
        public Size ImageHistoryThumbnailSize = new Size(100, 100);

        #endregion Main Form

        #region Settings Form

        #region General

        public bool ShowTray = true;
        public bool AutoCheckUpdate = true;
        public bool ShowAfterCaptureTasksForm = false;
        public bool PlaySoundAfterCapture = true;
        public bool PlaySoundAfterUpload = true;
        public bool TrayBalloonTipAfterUpload = true;
        public bool SaveHistory = true;

        #endregion General

        #region Paths

        public bool UseCustomUploadersConfigPath = false;
        public string CustomUploadersConfigPath = string.Empty;
        public bool UseCustomHistoryPath = false;
        public string CustomHistoryPath = string.Empty;
        public bool UseCustomScreenshotsPath = false;
        public string CustomScreenshotsPath = string.Empty;
        public string SaveImageSubFolderPattern = "%y-%mo";

        #endregion Paths

        #region Hotkeys

        public HotkeySetting HotkeyClipboardUpload = Keys.Control | Keys.PageUp;
        public HotkeySetting HotkeyFileUpload = Keys.Shift | Keys.PageUp;
        public HotkeySetting HotkeyPrintScreen = Keys.PrintScreen;
        public HotkeySetting HotkeyActiveWindow = Keys.Alt | Keys.PrintScreen;
        public HotkeySetting HotkeyActiveMonitor = Keys.Control | Keys.Alt | Keys.PrintScreen;
        public HotkeySetting HotkeyWindowRectangle = Keys.Shift | Keys.PrintScreen;
        public HotkeySetting HotkeyRectangleRegion = Keys.Control | Keys.PrintScreen;
        public HotkeySetting HotkeyRoundedRectangleRegion = Keys.None;
        public HotkeySetting HotkeyEllipseRegion = Keys.None;
        public HotkeySetting HotkeyTriangleRegion = Keys.None;
        public HotkeySetting HotkeyDiamondRegion = Keys.None;
        public HotkeySetting HotkeyPolygonRegion = Keys.None;
        public HotkeySetting HotkeyFreeHandRegion = Keys.None;
        public HotkeySetting HotkeyLastRegion = Keys.None;

        #endregion Hotkeys

        #region Image / Quality

        public EImageFormat ImageFormat = EImageFormat.PNG;
        public int ImageJPEGQuality = 90;
        public GIFQuality ImageGIFQuality = GIFQuality.Default;
        public int ImageSizeLimit = 512;
        public EImageFormat ImageFormat2 = EImageFormat.JPEG;

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

        #region Image / Other

        public WatermarkConfig WatermarkConfig = new WatermarkConfig();

        public bool ImageEffectOnlyRegionCapture = true;
        public BorderType BorderType = BorderType.Outside;
        public XmlColor BorderColor = Color.Black;
        public int BorderSize = 1;
        public float ShadowDarkness = 0.6f;
        public int ShadowSize = 9;
        public Point ShadowOffset = new Point(0, 0);

        #endregion Image / Other

        #region Capture / General

        public bool ShowCursor = false;
        public bool CaptureTransparent = true;
        public bool CaptureShadow = true;
        public int CaptureShadowOffset = 20;
        public bool CaptureClientArea = false;
        public bool IsDelayScreenshot = false;
        public decimal DelayScreenshot = 2.0m;

        #endregion Capture / General

        #region Capture / Shape capture

        public SurfaceOptions SurfaceOptions = new SurfaceOptions();

        #endregion Capture / Shape capture

        #region Actions

        public List<ExternalProgram> ExternalPrograms;

        #endregion Actions

        #region Upload / General

        public int UploadLimit = 5;
        public int BufferSizePower = 5;
        public bool IfUploadFailRetryOnce = false;

        #endregion Upload / General

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

        #region Upload / Watch folder

        public bool WatchFolderEnabled = false;
        public List<WatchFolder> WatchFolderList = new List<WatchFolder>();

        #endregion Upload / Watch folder

        #region Proxy

        public ProxyInfo ProxySettings = new ProxyInfo();

        #endregion Proxy

        #endregion Settings Form

        #region ScreenRecord Form

        public int ScreenRecordFPS = 5;
        public float ScreenRecordDuration = 3f;
        public ScreenRecordOutput ScreenRecordOutput = ScreenRecordOutput.GIF;
        public bool ScreenRecordAutoUploadGIF = true;

        #endregion ScreenRecord Form
    }
}