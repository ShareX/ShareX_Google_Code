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
            TaskEx.Run(() =>
            {
                if (Program.HotkeySettings == null)
                {
                    Program.HotkeySettingsResetEvent.WaitOne();
                }

                this.InvokeSafe(() =>
                {
                    Program.HotkeyManager = new HotkeyManager(this, Program.HotkeySettings.Hotkeys, HandleHotkeys);
                    Program.HotkeyManager.RunHotkeys();
                    Program.HotkeyManager.ShowFailedHotkeys();

                    HandleWatchFolder();
                });
            });
        }

        private void HandleHotkeys(HotkeySetting hotkeySetting)
        {
            if (hotkeySetting.TaskSettings.Job == HotkeyType.None) return;

            TaskSettings taskSettings = TaskSettings.GetSafeTaskSettings(hotkeySetting.TaskSettings);

            switch (hotkeySetting.TaskSettings.Job)
            {
                case HotkeyType.ClipboardUpload:
                    UploadManager.ClipboardUpload(taskSettings);
                    break;
                case HotkeyType.FileUpload:
                    UploadManager.UploadFile(taskSettings);
                    break;
                case HotkeyType.PrintScreen:
                    CaptureScreenshot(CaptureType.Screen, taskSettings, false);
                    break;
                case HotkeyType.ActiveWindow:
                    CaptureScreenshot(CaptureType.ActiveWindow, taskSettings, false);
                    break;
                case HotkeyType.ActiveMonitor:
                    CaptureScreenshot(CaptureType.ActiveMonitor, taskSettings, false);
                    break;
                case HotkeyType.WindowRectangle:
                    CaptureScreenshot(CaptureType.RectangleWindow, taskSettings, false);
                    break;
                case HotkeyType.RectangleRegion:
                    CaptureScreenshot(CaptureType.Rectangle, taskSettings, false);
                    break;
                case HotkeyType.RoundedRectangleRegion:
                    CaptureScreenshot(CaptureType.RoundedRectangle, taskSettings, false);
                    break;
                case HotkeyType.EllipseRegion:
                    CaptureScreenshot(CaptureType.Ellipse, taskSettings, false);
                    break;
                case HotkeyType.TriangleRegion:
                    CaptureScreenshot(CaptureType.Triangle, taskSettings, false);
                    break;
                case HotkeyType.DiamondRegion:
                    CaptureScreenshot(CaptureType.Diamond, taskSettings, false);
                    break;
                case HotkeyType.PolygonRegion:
                    CaptureScreenshot(CaptureType.Polygon, taskSettings, false);
                    break;
                case HotkeyType.FreeHandRegion:
                    CaptureScreenshot(CaptureType.Freehand, taskSettings, false);
                    break;
                case HotkeyType.LastRegion:
                    CaptureScreenshot(CaptureType.LastRegion, taskSettings, false);
                    break;
                case HotkeyType.ScreenRecorder:
                    DoScreenRecorder(taskSettings, true);
                    break;
                case HotkeyType.AutoCapture:
                    OpenAutoCapture();
                    break;
            }
        }

        public void CaptureScreenshot(CaptureType captureType, TaskSettings taskSettings, bool autoHideForm = true)
        {
            switch (captureType)
            {
                case CaptureType.Screen:
                    DoCapture(Screenshot.CaptureFullscreen, CaptureType.Screen, taskSettings, autoHideForm);
                    break;
                case CaptureType.ActiveWindow:
                    CaptureActiveWindow(taskSettings, autoHideForm);
                    break;
                case CaptureType.ActiveMonitor:
                    DoCapture(Screenshot.CaptureActiveMonitor, CaptureType.ActiveMonitor, taskSettings, autoHideForm);
                    break;
                case CaptureType.RectangleWindow:
                case CaptureType.Rectangle:
                case CaptureType.RoundedRectangle:
                case CaptureType.Ellipse:
                case CaptureType.Triangle:
                case CaptureType.Diamond:
                case CaptureType.Polygon:
                case CaptureType.Freehand:
                    CaptureRegion(captureType, taskSettings, autoHideForm);
                    break;
                case CaptureType.LastRegion:
                    CaptureLastRegion(taskSettings, autoHideForm);
                    break;
            }
        }

        private void DoCapture(ScreenCaptureDelegate capture, CaptureType captureType, TaskSettings taskSettings, bool autoHideForm = true)
        {
            if (taskSettings.CaptureSettings.IsDelayScreenshot && taskSettings.CaptureSettings.DelayScreenshot > 0)
            {
                int sleep = (int)(taskSettings.CaptureSettings.DelayScreenshot * 1000);
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += (sender, e) => Thread.Sleep(sleep);
                bw.RunWorkerCompleted += (sender, e) => DoCaptureWork(capture, captureType, taskSettings, autoHideForm);
                bw.RunWorkerAsync();
            }
            else
            {
                DoCaptureWork(capture, captureType, taskSettings, autoHideForm);
            }
        }

        private void DoCaptureWork(ScreenCaptureDelegate capture, CaptureType captureType, TaskSettings taskSettings, bool autoHideForm = true)
        {
            if (autoHideForm)
            {
                Hide();
                Thread.Sleep(250);
            }

            Image img = null;

            try
            {
                Screenshot.CaptureCursor = taskSettings.CaptureSettings.ShowCursor;
                Screenshot.CaptureShadow = taskSettings.CaptureSettings.CaptureShadow;
                Screenshot.ShadowOffset = taskSettings.CaptureSettings.CaptureShadowOffset;
                Screenshot.CaptureClientArea = taskSettings.CaptureSettings.CaptureClientArea;
                Screenshot.AutoHideTaskbar = taskSettings.CaptureSettings.CaptureAutoHideTaskbar;

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

        private void AfterCapture(Image img, CaptureType captureType, TaskSettings taskSettings)
        {
            if (img != null)
            {
                if (taskSettings.ImageSettings.ImageEffectOnlyRegionCapture && !IsRegionCapture(captureType))
                {
                    taskSettings.AfterCaptureJob = taskSettings.AfterCaptureJob.Remove(AfterCaptureTasks.AddBorder, AfterCaptureTasks.AddShadow);
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
                            case AfterCaptureFormResult.Cancel:
                                if (img != null) img.Dispose();
                                return;
                        }
                    }
                }

                UploadManager.RunImageTask(img, taskSettings);
            }
        }

        private bool IsRegionCapture(CaptureType captureType)
        {
            return captureType.HasFlagAny(CaptureType.RectangleWindow, CaptureType.Rectangle, CaptureType.RoundedRectangle, CaptureType.Ellipse,
                CaptureType.Triangle, CaptureType.Diamond, CaptureType.Polygon, CaptureType.Freehand, CaptureType.LastRegion);
        }

        private void CaptureActiveWindow(TaskSettings taskSettings, bool autoHideForm = true)
        {
            DoCapture(() =>
            {
                Image img = null;
                string activeWindowTitle = NativeMethods.GetForegroundWindowText();

                if (taskSettings.CaptureSettings.CaptureTransparent && !taskSettings.CaptureSettings.CaptureClientArea)
                {
                    img = Screenshot.CaptureActiveWindowTransparent();
                }
                else
                {
                    img = Screenshot.CaptureActiveWindow();
                }

                img.Tag = new ImageTag() { ActiveWindowTitle = activeWindowTitle };

                return img;
            }, CaptureType.ActiveWindow, taskSettings, autoHideForm);
        }

        private void CaptureWindow(IntPtr handle, TaskSettings taskSettings, bool autoHideForm = true)
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

                if (taskSettings.CaptureSettings.CaptureTransparent && !taskSettings.CaptureSettings.CaptureClientArea)
                {
                    return Screenshot.CaptureWindowTransparent(handle);
                }
                else
                {
                    return Screenshot.CaptureWindow(handle);
                }
            }, CaptureType.Window, taskSettings, autoHideForm);
        }

        private void CaptureRegion(CaptureType captureType, TaskSettings taskSettings, bool autoHideForm = true)
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

                surface.Config = taskSettings.CaptureSettings.SurfaceOptions;
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
            }, captureType, taskSettings, autoHideForm);
        }

        private void CaptureLastRegion(TaskSettings taskSettings, bool autoHideForm = true)
        {
            if (Surface.LastRegionFillPath != null)
            {
                DoCapture(() =>
                {
                    using (Image screenshot = Screenshot.CaptureFullscreen())
                    {
                        return ShapeCaptureHelpers.GetRegionImage(screenshot, Surface.LastRegionFillPath, Surface.LastRegionDrawPath, taskSettings.CaptureSettings.SurfaceOptions);
                    }
                }, CaptureType.LastRegion, taskSettings, autoHideForm);
            }
            else
            {
                CaptureRegion(CaptureType.Rectangle, taskSettings, autoHideForm);
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
            CaptureScreenshot(CaptureType.Screen, Program.DefaultTaskSettings);
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
                CaptureWindow(wi.Handle, Program.DefaultTaskSettings);
            }
        }

        private void tsmiMonitorItems_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            Rectangle rectangle = (Rectangle)tsi.Tag;
            if (!rectangle.IsEmpty)
            {
                DoCapture(() => Screenshot.CaptureRectangle(rectangle), CaptureType.Monitor, Program.DefaultTaskSettings);
            }
        }

        private void tsmiWindowRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.RectangleWindow, Program.DefaultTaskSettings);
        }

        private void tsmiRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Rectangle, Program.DefaultTaskSettings);
        }

        private void tsmiRoundedRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.RoundedRectangle, Program.DefaultTaskSettings);
        }

        private void tsmiEllipse_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Ellipse, Program.DefaultTaskSettings);
        }

        private void tsmiTriangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Triangle, Program.DefaultTaskSettings);
        }

        private void tsmiDiamond_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Diamond, Program.DefaultTaskSettings);
        }

        private void tsmiPolygon_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Polygon, Program.DefaultTaskSettings);
        }

        private void tsmiFreeHand_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Freehand, Program.DefaultTaskSettings);
        }

        private void tsmiLastRegion_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.LastRegion, Program.DefaultTaskSettings);
        }

        #endregion Menu events

        #region Tray events

        private void tsmiTrayFullscreen_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Screen, Program.DefaultTaskSettings, false);
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
                CaptureWindow(wi.Handle, Program.DefaultTaskSettings, false);
            }
        }

        private void tsmiTrayMonitorItems_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            Rectangle rectangle = (Rectangle)tsi.Tag;
            if (!rectangle.IsEmpty)
            {
                DoCapture(() => Screenshot.CaptureRectangle(rectangle), CaptureType.Monitor, Program.DefaultTaskSettings, false);
            }
        }

        private void tsmiTrayWindowRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.RectangleWindow, Program.DefaultTaskSettings, false);
        }

        private void tsmiTrayRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Rectangle, Program.DefaultTaskSettings, false);
        }

        private void tsmiTrayRoundedRectangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.RoundedRectangle, Program.DefaultTaskSettings, false);
        }

        private void tsmiTrayEllipse_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Ellipse, Program.DefaultTaskSettings, false);
        }

        private void tsmiTrayTriangle_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Triangle, Program.DefaultTaskSettings, false);
        }

        private void tsmiTrayDiamond_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Diamond, Program.DefaultTaskSettings, false);
        }

        private void tsmiTrayPolygon_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Polygon, Program.DefaultTaskSettings, false);
        }

        private void tsmiTrayFreeHand_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.Freehand, Program.DefaultTaskSettings, false);
        }

        private void tsmiTrayLastRegion_Click(object sender, EventArgs e)
        {
            CaptureScreenshot(CaptureType.LastRegion, Program.DefaultTaskSettings, false);
        }

        #endregion Tray events
    }
}