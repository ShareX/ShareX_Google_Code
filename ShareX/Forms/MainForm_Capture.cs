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
using System.Media;
using System.Threading;
using System.Windows.Forms;
using HelpersLib;
using HelpersLib.Hotkey;
using ScreenCapture;
using ShareX.HelperClasses;

namespace ShareX
{
    public partial class MainForm
    {
        private delegate Image ScreenCaptureDelegate();

        private void InitHotkeys()
        {
            HotkeyManager = new HotkeyManager(this, ZAppType.ShareX);
            HotkeyManager.AddHotkey(ZUploaderHotkey.ClipboardUpload, Program.Settings.HotkeyClipboardUpload, UploadManager.ClipboardUpload);
            HotkeyManager.AddHotkey(ZUploaderHotkey.FileUpload, Program.Settings.HotkeyFileUpload, UploadManager.UploadFile);
            HotkeyManager.AddHotkey(ZUploaderHotkey.PrintScreen, Program.Settings.HotkeyPrintScreen, () => CaptureScreen(false), tsmiFullscreen);
            HotkeyManager.AddHotkey(ZUploaderHotkey.ActiveWindow, Program.Settings.HotkeyActiveWindow, () => CaptureActiveWindow(false));
            HotkeyManager.AddHotkey(ZUploaderHotkey.ActiveMonitor, Program.Settings.HotkeyActiveMonitor, () => CaptureActiveMonitor(false));
            HotkeyManager.AddHotkey(ZUploaderHotkey.WindowRectangle, Program.Settings.HotkeyWindowRectangle, () => WindowRectangleCapture(false), tsmiWindowRectangle);
            HotkeyManager.AddHotkey(ZUploaderHotkey.RectangleRegion, Program.Settings.HotkeyRectangleRegion,
                () => CaptureRegion(new RectangleRegion(), false), tsmiRectangle);
            HotkeyManager.AddHotkey(ZUploaderHotkey.RoundedRectangleRegion, Program.Settings.HotkeyRoundedRectangleRegion,
                () => CaptureRegion(new RoundedRectangleRegion(), false), tsmiRoundedRectangle);
            HotkeyManager.AddHotkey(ZUploaderHotkey.EllipseRegion, Program.Settings.HotkeyEllipseRegion,
                () => CaptureRegion(new EllipseRegion(), false), tsmiEllipse);
            HotkeyManager.AddHotkey(ZUploaderHotkey.TriangleRegion, Program.Settings.HotkeyTriangleRegion,
                () => CaptureRegion(new TriangleRegion(), false), tsmiTriangle);
            HotkeyManager.AddHotkey(ZUploaderHotkey.DiamondRegion, Program.Settings.HotkeyDiamondRegion,
                () => CaptureRegion(new DiamondRegion(), false), tsmiDiamond);
            HotkeyManager.AddHotkey(ZUploaderHotkey.PolygonRegion, Program.Settings.HotkeyPolygonRegion,
                () => CaptureRegion(new PolygonRegion(), false), tsmiPolygon);
            HotkeyManager.AddHotkey(ZUploaderHotkey.FreeHandRegion, Program.Settings.HotkeyFreeHandRegion,
                () => CaptureRegion(new FreeHandRegion(), false), tsmiFreeHand);

            string failedHotkeys;

            if (HotkeyManager.IsHotkeyRegisterFailed(out failedHotkeys))
            {
                MessageBox.Show("Unable to register hotkey(s):\r\n\r\n" + failedHotkeys +
                    "\r\n\r\nPlease select a different hotkey or quit the conflicting application and reopen ShareX.",
                    "Hotkey register failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private new void Capture(ScreenCaptureDelegate capture, bool autoHideForm = true)
        {
            if (autoHideForm)
            {
                Hide();
                Thread.Sleep(250);
            }

            Image img = null;

            try
            {
                Screenshot.DrawCursor = Program.Settings.ShowCursor;
                Screenshot.CaptureShadow = Program.Settings.CaptureShadow;
                img = capture();

                if (img != null && Program.Settings.AutoPlaySound)
                {
                    string soundPath = Path.Combine(Application.StartupPath, "Camera.wav");

                    if (File.Exists(soundPath))
                    {
                        new SoundPlayer(soundPath).Play();
                    }
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteException(ex);
            }
            finally
            {
                if (autoHideForm)
                {
                    ShowActivate();
                }

                AfterCapture(img);
            }
        }

        private void EditImage(ref Image img)
        {
            if (Greenshot.MainForm.instance == null)
                Greenshot.MainForm.Start(new string[0]);

            GreenshotPlugin.Core.CoreConfiguration coreConfiguration = Greenshot.IniFile.IniConfig.GetIniSection<GreenshotPlugin.Core.CoreConfiguration>();
            coreConfiguration.OutputFileFilenamePattern = "${title}";
            coreConfiguration.OutputFilePath = Program.ScreenshotsPath;

            Greenshot.Plugin.ICapture capture = new GreenshotPlugin.Core.Capture();
            capture.Image = img;
            ImageData imageData = TaskHelper.PrepareImageAndFilename(img);
            capture.CaptureDetails.Filename = Path.Combine(Program.ScreenshotsPath, imageData.Filename);
            capture.CaptureDetails.Title =
                Path.GetFileNameWithoutExtension(capture.CaptureDetails.Filename);
            capture.CaptureDetails.AddMetaData("file", capture.CaptureDetails.Filename);
            capture.CaptureDetails.AddMetaData("source", "file");

            var surface = new Greenshot.Drawing.Surface(capture);
            var editor = new Greenshot.ImageEditorForm(surface, Program.Settings.CaptureSaveImage) { Icon = this.Icon };

            editor.SetImagePath(capture.CaptureDetails.Filename);
            editor.Visible = false;
            editor.ShowDialog();
            img = editor.GetImageForExport();
        }

        private void AfterCapture(Image img)
        {
            if (img != null)
            {
                WizardAfterCaptureConfig configAfterCapture = new WizardAfterCaptureConfig
                {
                    AnnotateImage = Program.Settings.CaptureAnnotateImage,
                    CopyImageToClipboard = Program.Settings.CaptureCopyImage,
                    SaveImageToFile = Program.Settings.CaptureSaveImage,
                    UploadImageToHost = Program.Settings.CaptureUploadImage
                };

                if (Program.Settings.DynamicOutputs)
                {
                    WizardAfterCapture dlg = new WizardAfterCapture(configAfterCapture);
                    dlg.ShowDialog();
                    configAfterCapture = dlg.Config;
                }

                if (configAfterCapture.AnnotateImage.Value)
                {
                    EditImage(ref img);
                }

                if (configAfterCapture.CopyImageToClipboard.Value)
                {
                    Clipboard.SetImage(img);
                }

                if (configAfterCapture.SaveImageToFile.Value)
                {
                    ImageData imageData = TaskHelper.PrepareImageAndFilename(img);
                    imageData.WriteToFile(Program.ScreenshotsPath);

                    if (configAfterCapture.UploadImageToHost.Value)
                    {
                        UploadManager.UploadImageStream(imageData.ImageStream, imageData.Filename);
                    }
                    else
                    {
                        imageData.Dispose();
                    }
                }
                else if (configAfterCapture.UploadImageToHost.Value)
                {
                    UploadManager.UploadImage(img);
                }
            }
        }

        private void CaptureScreen(bool autoHideForm = true)
        {
            Capture(Screenshot.CaptureFullscreen, autoHideForm);
        }

        private void CaptureActiveWindow(bool autoHideForm = true)
        {
            if (Program.Settings.CaptureTransparent)
            {
                Capture(Screenshot.CaptureActiveWindowTransparent, autoHideForm);
            }
            else
            {
                Capture(Screenshot.CaptureActiveWindow, autoHideForm);
            }
        }

        private void CaptureActiveMonitor(bool autoHideForm = true)
        {
            Capture(Screenshot.CaptureActiveMonitor, autoHideForm);
        }

        private void CaptureWindow(IntPtr handle, bool autoHideForm = true)
        {
            autoHideForm = autoHideForm && handle != this.Handle;

            Capture(() =>
            {
                if (NativeMethods.IsIconic(handle))
                {
                    NativeMethods.RestoreWindow(handle);
                }

                NativeMethods.SetForegroundWindow(handle);
                Thread.Sleep(250);

                if (Program.Settings.CaptureTransparent)
                {
                    return Screenshot.CaptureWindowTransparent(handle);
                }

                return Screenshot.CaptureWindow(handle);
            }, autoHideForm);
        }

        private void CaptureRegion(Surface surface, bool autoHideForm = true)
        {
            Capture(() =>
            {
                Image img = null;
                Image screenshot = Screenshot.CaptureFullscreen();

                surface.Config = Program.Settings.SurfaceOptions;
                surface.SurfaceImage = screenshot;
                surface.Prepare();

                if (surface.ShowDialog() == DialogResult.OK)
                {
                    img = surface.GetRegionImage();
                }

                surface.Dispose();

                return img;
            }, autoHideForm);
        }

        private void WindowRectangleCapture(bool autoHideForm = true)
        {
            RectangleRegion rectangleRegion = new RectangleRegion();
            rectangleRegion.AreaManager.WindowCaptureMode = true;
            CaptureRegion(rectangleRegion, autoHideForm);
        }

        private void PrepareWindowsMenu(ToolStripMenuItem tsmi, EventHandler handler)
        {
            tsmi.DropDownItems.Clear();

            WindowsList windowsList = new WindowsList();
            List<WindowInfo> windows = windowsList.GetVisibleWindowsList();

            foreach (WindowInfo window in windows)
            {
                string title = window.Text.Truncate(50);
                ToolStripItem tsi = tsmi.DropDownItems.Add(title);
                tsi.Click += handler;

                try
                {
                    using (Icon icon = window.Icon)
                    {
                        if (icon != null)
                        {
                            tsi.Image = icon.ToBitmap();
                        }
                    }
                }
                catch (Exception e)
                {
                    DebugHelper.WriteException(e);
                }

                tsi.Tag = window;
            }
        }

        #region Menu events

        private void tsmiFullscreen_Click(object sender, EventArgs e)
        {
            CaptureScreen();
        }

        private void tsddbCapture_DropDownOpening(object sender, EventArgs e)
        {
            PrepareWindowsMenu(tsmiWindow, tsmiWindowItems_Click);
        }

        private void tsmiWindowItems_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            WindowInfo wi = tsi.Tag as WindowInfo;
            if (wi != null) CaptureWindow(wi.Handle);
        }

        private void tsmiWindowRectangle_Click(object sender, EventArgs e)
        {
            WindowRectangleCapture();
        }

        private void tsmiRectangle_Click(object sender, EventArgs e)
        {
            CaptureRegion(new RectangleRegion());
        }

        private void tsmiRoundedRectangle_Click(object sender, EventArgs e)
        {
            CaptureRegion(new RoundedRectangleRegion());
        }

        private void tsmiEllipse_Click(object sender, EventArgs e)
        {
            CaptureRegion(new EllipseRegion());
        }

        private void tsmiTriangle_Click(object sender, EventArgs e)
        {
            CaptureRegion(new TriangleRegion());
        }

        private void tsmiDiamond_Click(object sender, EventArgs e)
        {
            CaptureRegion(new DiamondRegion());
        }

        private void tsmiPolygon_Click(object sender, EventArgs e)
        {
            CaptureRegion(new PolygonRegion());
        }

        private void tsmiFreeHand_Click(object sender, EventArgs e)
        {
            CaptureRegion(new FreeHandRegion());
        }

        #endregion Menu events

        #region Tray events

        private void tsmiTrayFullscreen_Click(object sender, EventArgs e)
        {
            CaptureScreen(false);
        }

        private void tsmiCapture_DropDownOpening(object sender, EventArgs e)
        {
            PrepareWindowsMenu(tsmiTrayWindow, tsmiTrayWindowItems_Click);
        }

        private void tsmiTrayWindowItems_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            WindowInfo wi = tsi.Tag as WindowInfo;
            if (wi != null) CaptureWindow(wi.Handle, false);
        }

        private void tsmiTrayWindowRectangle_Click(object sender, EventArgs e)
        {
            WindowRectangleCapture(false);
        }

        private void tsmiTrayRectangle_Click(object sender, EventArgs e)
        {
            CaptureRegion(new RectangleRegion(), false);
        }

        private void tsmiTrayRoundedRectangle_Click(object sender, EventArgs e)
        {
            CaptureRegion(new RoundedRectangleRegion(), false);
        }

        private void tsmiTrayTriangle_Click(object sender, EventArgs e)
        {
            CaptureRegion(new TriangleRegion(), false);
        }

        private void tsmiTrayDiamond_Click(object sender, EventArgs e)
        {
            CaptureRegion(new DiamondRegion(), false);
        }

        private void tsmiTrayPolygon_Click(object sender, EventArgs e)
        {
            CaptureRegion(new PolygonRegion(), false);
        }

        private void tsmiTrayFreeHand_Click(object sender, EventArgs e)
        {
            CaptureRegion(new FreeHandRegion(), false);
        }

        #endregion Tray events
    }
}