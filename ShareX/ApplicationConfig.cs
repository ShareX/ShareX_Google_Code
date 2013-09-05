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
using System.Collections.Generic;
using System.Drawing;
using UploadersLib;

namespace ShareX
{
    public class ApplicationConfig : SettingsBase<ApplicationConfig>
    {
        public TaskSettings DefaultTaskSettings = new TaskSettings();

        public string FileUploadDefaultDirectory = "";
        public bool ShowUploadWarning = true; // First time upload warning
        public bool ShowMultiUploadWarning = true; // More than 10 files upload warning

        #region Main Form

        public bool ShowMenu = true;
        public bool IsPreviewCollapsed = false;
        public int PreviewSplitterDistance = 400;

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

        #region Proxy

        public ProxyInfo ProxySettings = new ProxyInfo();

        #endregion Proxy

        #region Upload

        public bool IfUploadFailRetryOnce = false;
        public int UploadLimit = 5;
        public int BufferSizePower = 5;
        public List<ClipboardFormat> ClipboardContentFormats = new List<ClipboardFormat>();

        #endregion Upload

        #region Print

        public bool DontShowPrintSettingsDialog = false;
        public PrintSettings PrintSettings = new PrintSettings();

        #endregion Print

        #endregion Settings Form

        #region History Form

        public WindowState HistoryWindowState = new WindowState();
        public WindowState ImageHistoryWindowState = new WindowState();
        public int ImageHistoryMaxItemCount = 100;
        public int ImageHistoryViewMode = 3;
        public Size ImageHistoryThumbnailSize = new Size(100, 100);

        #endregion History Form

        #region AutoCapture Form

        public decimal AutoCaptureRepeatTime = 60;
        public bool AutoCaptureMinimizeToTray = true;
        public bool AutoCaptureWaitUpload = true;

        #endregion AutoCapture Form
    }
}