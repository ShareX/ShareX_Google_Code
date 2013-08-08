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
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareX
{
    public partial class MainForm
    {
        private delegate Image ScreenCaptureDelegate();

        private void InitHotkeys()
        {
            if (Program.Settings.HotkeyList == null)
            {
                Program.Settings.HotkeyList = new List<HotkeySetting>();
            }

            HotkeyManager = new HotkeyManager(this, Program.Settings.HotkeyList, HandleHotkeys);
            HotkeyManager.RunHotkeys();

            string failedHotkeys;

            if (HotkeyManager.IsHotkeyRegisterFailed(out failedHotkeys))
            {
                MessageBox.Show("Unable to register hotkey(s):\r\n\r\n" + failedHotkeys +
                    "\r\n\r\nPlease select a different hotkey or quit the conflicting application and reopen ShareX.",
                    "Hotkey register failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleHotkeys(HotkeySetting hotkeySetting)
        {
            TaskSettings taskSettings = hotkeySetting.TaskSettings.Clone();
            taskSettings.SetDefaultSettings();

            switch (hotkeySetting.Job)
            {
                case EHotkey.ClipboardUpload:
                    UploadManager.ClipboardUpload();
                    break;
                case EHotkey.FileUpload:
                    UploadManager.UploadFile();
                    break;
                case EHotkey.PrintScreen:
                    CaptureScreenshot(CaptureType.Screen, false, taskSettings);
                    break;
                case EHotkey.ActiveWindow:
                    CaptureScreenshot(CaptureType.ActiveWindow, false, taskSettings);
                    break;
                case EHotkey.ActiveMonitor:
                    CaptureScreenshot(CaptureType.ActiveMonitor, false, taskSettings);
                    break;
                case EHotkey.WindowRectangle:
                    CaptureScreenshot(CaptureType.RectangleWindow, false, taskSettings);
                    break;
                case EHotkey.RectangleRegion:
                    CaptureScreenshot(CaptureType.Rectangle, false, taskSettings);
                    break;
                case EHotkey.RoundedRectangleRegion:
                    CaptureScreenshot(CaptureType.RoundedRectangle, false, taskSettings);
                    break;
                case EHotkey.EllipseRegion:
                    CaptureScreenshot(CaptureType.Ellipse, false, taskSettings);
                    break;
                case EHotkey.TriangleRegion:
                    CaptureScreenshot(CaptureType.Triangle, false, taskSettings);
                    break;
                case EHotkey.DiamondRegion:
                    CaptureScreenshot(CaptureType.Diamond, false, taskSettings);
                    break;
                case EHotkey.PolygonRegion:
                    CaptureScreenshot(CaptureType.Polygon, false, taskSettings);
                    break;
                case EHotkey.FreeHandRegion:
                    CaptureScreenshot(CaptureType.Freehand, false, taskSettings);
                    break;
                case EHotkey.LastRegion:
                    CaptureScreenshot(CaptureType.LastRegion, false, taskSettings);
                    break;
                case EHotkey.ScreenRecorder:
                    OpenScreenRecorder();
                    break;
                case EHotkey.AutoCapture:
                    OpenAutoCapture();
                    break;
            }
        }

        public void CaptureScreenshot(CaptureType captureType, bool autoHideForm = true, TaskSettings taskSettings = null)
        {
            switch (captureType)
            {
                case CaptureType.Screen:
                    DoCapture(Screenshot.CaptureFullscreen, CaptureType.Screen, autoHideForm, taskSettings);
                    break;
                case CaptureType.ActiveWindow:
                    CaptureActiveWindow(autoHideForm, taskSettings);
                    break;
                case CaptureType.ActiveMonitor:
                    DoCapture(Screenshot.CaptureActiveMonitor, CaptureType.ActiveMonitor, autoHideForm, taskSettings);
                    break;
                case CaptureType.RectangleWindow:
                case CaptureType.Rectangle:
                case CaptureType.RoundedRectangle:
                case CaptureType.Ellipse:
                case CaptureType.Triangle:
                case CaptureType.Diamond:
                case CaptureType.Polygon:
                case CaptureType.Freehand:
                    CaptureRegion(captureType, autoHideForm, taskSettings);
                    break;
                case CaptureType.LastRegion:
                    CaptureLastRegion(autoHideForm, taskSettings);
                    break;
            }
        }

        private void DoCapture(ScreenCaptureDelegate capture, CaptureType captureType, bool autoHideForm = true, TaskSettings taskSettings = null)
        {
            if (Program.Settings.IsDelayScreenshot && Program.Settings.DelayScreenshot > 0)
            {
                int sleep = (int)(Program.Settings.DelayScreenshot * 1000);
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += (sender, e) => Thread.Sleep(sleep);
                bw.RunWorkerCompleted += (sender, e) => DoCaptureWork(capture, captureType, autoHideForm, taskSettings);
                bw.RunWorkerAsync();
            }
            else
            {
                DoCaptureWork(capture, captureType, autoHideForm, taskSettings);
            }
        }

        private void DoCaptureWork(ScreenCaptureDelegate capture, CaptureType captureType, bool autoHideForm = true, TaskSettings taskSettings = null)
        {
            if (autoHideForm)
            {
                Hide();
                Thread.Sleep(250);
            }

            Image img = null;

            try
            {
                Screenshot.CaptureCursor = Program.Settings.ShowCursor;
                Screenshot.CaptureShadow = Program.Settings.CaptureShadow;
                Screenshot.ShadowOffset = Program.Settings.CaptureShadowOffset;
                Screenshot.CaptureClientArea = Program.Settings.CaptureClientArea;
                Screenshot.AutoHideTaskbar = Program.Settings.CaptureAutoHideTaskbar;

                img = capture();

                if (img != null && Program.Settings.PlaySoundAfterCapture)
                {
                    Helpers.PlaySoundAsync(Resources.CameraSound);
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
                    this.ShowActivate();
                }

                AfterCapture(img, captureType, taskSettings);
            }
        }

        private void AfterCapture(Image img, CaptureType captureType, TaskSettings taskSettings = null)
        {
            if (img != null)
            {
                if (taskSettings == null)
                {
                    taskSettings = new TaskSettings(true);
                }

                if (Program.Settings.ImageEffectOnlyRegionCapture && !IsRegionCapture(captureType))
                {
                    taskSettings.AfterCaptureJob = taskSettings.AfterCaptureJob.Remove(AfterCaptureTasks.AddBorder | AfterCaptureTasks.AddShadow);
                }

                if (Program.Settings.ShowAfterCaptureTasksForm)
                {
                    using (AfterCaptureForm afterCaptureForm = new AfterCaptureForm(img, taskSettings.AfterCaptureJob))
                    {
                        afterCaptureForm.ShowDialog();

                        switch (afterCaptureForm.Result)
                        {
                            case AfterCaptureFormResult.Continue:
                                taskSettings.AfterCaptureJob = afterCaptureForm.AfterCaptureTasks;
                                break;
                            case AfterCaptureFormResult.Copy:
                                taskSettings.AfterCaptureJob = AfterCaptureTasks.CopyImageToClipboard;
                                break;
                        }
                    }
                }

                UploadManager.RunImageTask(img, taskSettings);
            }
        }

        private bool IsRegionCapture(CaptureType captureType)
        {
            return captureType.HasFlagAny(CaptureType.RectangleWindow, CaptureType.Rectangle, CaptureType.RoundedRectangle, CaptureType.Ellipse, CaptureType.Triangle,
                CaptureType.Diamond, CaptureType.Polygon, CaptureType.Freehand, CaptureType.LastRegion);
        }

        private void CaptureActiveWindow(bool autoHideForm = true, TaskSettings taskSettings = null)
        {
            DoCapture(() =>
            {
                Image img = null;
                string activeWindowTitle = NativeMethods.GetForegroundWindowText();

                if (Program.Settings.CaptureTransparent && !Program.Settings.CaptureClientArea)
                {
                    img = Screenshot.CaptureActiveWindowTransparent();
                }
                else
                {
                    img = Screenshot.CaptureActiveWindow();
                }

                img.Tag = new ImageTag() { ActiveWindowTitle = activeWindowTitle };

                return img;
            }, CaptureType.ActiveWindow, autoHideForm, taskSettings);
        }

        private void CaptureWindow(IntPtr handle, bool autoHideForm = true, TaskSettings taskSettings = null)
        {
            autoHideForm = autoHideForm && handle != this.Handle;

            DoCapture(() =>
            {
                if (NativeMethods.IsIconic(handle))
                {
                    NativeMethods.RestoreWindow(handle);
                }

                NativeMethods.SetForegroundWindow(handle);
                Thread.Sleep(250);

                if (Program.Settings.CaptureTransparent && !Program.Settings.CaptureClientArea)
                {
                    return Screenshot.CaptureWindowTransparent(handle);
                }
                else
                {
                    return Screenshot.CaptureWindow(handle);
                }
            }, CaptureType.Window, autoHideForm, taskSettings);
        }

        private void CaptureRegion(CaptureType captureType, bool autoHideForm = true, TaskSettings taskSettings = null)
        {
            Surface surface;

            switch (captureType)
            {
                default:
                case CaptureType.Rectangle:
                    surface = new RectangleRegion();
                    break;
                case CaptureType.RectangleWindow:
                    RectangleRegion rectangleRegion = new RectangleRegion();
                    rectangleRegion.AreaManager.WindowCaptureMode = true;
                    surface = rectangleRegion;
                    break;
                case CaptureType.RoundedRectangle:
                    surface = new RoundedRectangleRegion();
                    break;
                case CaptureType.Ellipse:
                    surface = new EllipseRegion();
                    break;
                case CaptureType.Triangle:
                    surface = new TriangleRegion();
                    break;
                case CaptureType.Diamond:
                    surface = new DiamondRegion();
                    break;
                case CaptureType.Polygon:
                    surface = new PolygonRegion();
                    break;
                case CaptureType.Freehand:
                    surface = new FreeHandRegion();
                    break;
            }

            DoCapture(() =>
            {
                Image img = null;
                Image screenshot = Screenshot.CaptureFullscreen();

                surface.Config = Program.Settings.SurfaceOptions;
                surface.SurfaceImage = screenshot;
                surface.Prepare();
                surface.ShowDialog();

                if (surface.Result == SurfaceResult.Region)
                {
                    img = surface.GetRegionImage();
                    screenshot.Dispose();
                }
                else if (surface.Result == SurfaceResult.Fullscreen)
                {
                    img = screenshot;
                }

                surface.Dispose();

                return img;
            }, captureType, autoHideForm, taskSettings);
        }

        private void CaptureLastRegion(bool autoHideForm = true, TaskSettings taskSettings = null)
        {
            if (Surface.LastRegionFillPath != null)
            {
                DoCapture(() =>
                {
                    using (Image screenshot = Screenshot.CaptureFullscreen())
                    {
                        return ShapeCaptureHelpers.GetRegionImage(screenshot, Surface.LastRegionFillPath, Surface.LastRegionDrawPath, Program.Settings.SurfaceOptions);
                    }
                }, CaptureType.LastRegion, autoHideForm, taskSettings);
            }
            else
            {
                CaptureRegion(CaptureType.Rectangle, autoHideForm);
            }
        }

        private async void PrepareCaptureMenuAsync(ToolStripMenuItem tsmiWindow, EventHandler handlerWindow, ToolStripMenuItem tsmiMonitor, EventHandler handlerMonitor)
        {
            tsmiWindow.DropDownItems.Clear();

            List<WindowInfo> windows = null;

            WindowsList windowsList = new WindowsList();
            windows = await TaskEx.Run(() => windowsList.GetVisibleWindowsList());

            if (windows != null)
            {
                foreach (WindowInfo window in windows)
                {
                    string title = window.Text.Truncate(50);
                    ToolStripItem tsi = tsmiWindow.DropDownItems.Add(title);
                    tsi.Tag = window;
                    tsi.Click += handlerWindow;

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
                }
            }

            tsmiMonitor.DropDownItems.Clear();

            Screen[] screens = Screen.AllScreens;

            for (int i = 0; i < screens.Length; i++)
            {
                Screen screen = screens[i];
                string text = string.Format("{0}. {1}x{2}", i + 1, screen.Bounds.Width, screen.Bounds.Height);
                ToolStripItem tsi = tsmiMonitor.DropDownItems.Add(text);
                tsi.Tag = screen.Bounds;
                tsi.Click += handlerMonitor;
            }

            tsmiWindow.Invalidate();
            tsmiMonitor.Invalidate();
        }

        #region Menu events

        private void tsmiFullscreen_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Screen);
        }

        private void tsddbCapture_DropDownOpening(object sender, EventArgs e)
        {
            PrepareCaptureMenuAsync(tsmiWindow, tsmiWindowItems_Click, tsmiMonitor, tsmiMonitorItems_Click);
        }

        private void tsmiWindowItems_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            WindowInfo wi = tsi.Tag as WindowInfo;
            if (wi != null)
            {
                CaptureWindow(wi.Handle);
            }
        }

        private void tsmiMonitorItems_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            Rectangle rectangle = (Rectangle)tsi.Tag;
            if (!rectangle.IsEmpty)
            {
                DoCapture(() => Screenshot.CaptureRectangle(rectangle), CaptureType.Monitor);
            }
        }

        private void tsmiWindowRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.RectangleWindow);
        }

        private void tsmiRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Rectangle);
        }

        private void tsmiRoundedRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.RoundedRectangle);
        }

        private void tsmiEllipse_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Ellipse);
        }

        private void tsmiTriangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Triangle);
        }

        private void tsmiDiamond_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Diamond);
        }

        private void tsmiPolygon_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Polygon);
        }

        private void tsmiFreeHand_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Freehand);
        }

        private void tsmiLastRegion_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.LastRegion);
        }

        #endregion Menu events

        #region Tray events

        private void tsmiTrayFullscreen_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Screen, false);
        }

        private void tsmiCapture_DropDownOpening(object sender, EventArgs e)
        {
            PrepareCaptureMenuAsync(tsmiTrayWindow, tsmiTrayWindowItems_Click, tsmiTrayMonitor, tsmiTrayMonitorItems_Click);
        }

        private void tsmiTrayWindowItems_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            WindowInfo wi = tsi.Tag as WindowInfo;
            if (wi != null)
            {
                CaptureWindow(wi.Handle, false);
            }
        }

        private void tsmiTrayMonitorItems_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            Rectangle rectangle = (Rectangle)tsi.Tag;
            if (!rectangle.IsEmpty)
            {
                DoCapture(() => Screenshot.CaptureRectangle(rectangle), CaptureType.Monitor, false);
            }
        }

        private void tsmiTrayWindowRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.RectangleWindow, false);
        }

        private void tsmiTrayRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Rectangle, false);
        }

        private void tsmiTrayRoundedRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.RoundedRectangle, false);
        }

        private void tsmiTrayEllipse_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Ellipse, false);
        }

        private void tsmiTrayTriangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Triangle, false);
        }

        private void tsmiTrayDiamond_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Diamond, false);
        }

        private void tsmiTrayPolygon_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Polygon, false);
        }

        private void tsmiTrayFreeHand_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Freehand, false);
        }

        private void tsmiTrayLastRegion_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.LastRegion, false);
        }

        #endregion Tray events
    }
}