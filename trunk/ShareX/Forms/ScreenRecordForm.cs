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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareX
{
    public class ScreenRecordForm : TrayForm
    {
        public Rectangle CaptureRectangle { get; private set; }
        public bool IsRecording { get; private set; }

        private static ScreenRecordForm instance;

        public static ScreenRecordForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new ScreenRecordForm();
                    instance.Show();
                }

                return instance;
            }
        }

        private ScreenRecorder screenRecorder = null;

        private ScreenRecordForm()
        {
            TrayIcon.Text = "ShareX - Screen recording";
            TrayIcon.MouseClick += TrayIcon_MouseClick;
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StopRecording();
            }
        }

        private void SelectRegion(TaskSettings taskSettings)
        {
            Rectangle rect;
            if (TaskHelper.SelectRegion(taskSettings, out rect) && !rect.IsEmpty)
            {
                CaptureRectangle = Helpers.EvenRectangleSize(rect);
            }
        }

        public async void StartRecording(TaskSettings TaskSettings)
        {
            SelectRegion(TaskSettings);
            Screenshot.CaptureCursor = TaskSettings.CaptureSettings.ShowCursor;

            if (IsRecording || CaptureRectangle.IsEmpty || screenRecorder != null)
            {
                return;
            }

            IsRecording = true;

            TrayIcon.Icon = Icon.FromHandle(Resources.control_record_yellow.GetHicon());
            TrayIcon.Visible = true;

            string path = "";

            try
            {
                using (ScreenRegionManager screenRegionManager = new ScreenRegionManager())
                {
                    screenRegionManager.Start(CaptureRectangle);

                    await TaskEx.Run(() =>
                    {
                        if (TaskSettings.CaptureSettings.ScreenRecordOutput == ScreenRecordOutput.AVI)
                        {
                            path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename(TaskSettings, "avi"));
                        }
                        else
                        {
                            path = Program.ScreenRecorderCacheFilePath;
                        }

                        float duration = TaskSettings.CaptureSettings.ScreenRecordFixedDuration ? TaskSettings.CaptureSettings.ScreenRecordDuration : 0;

                        screenRecorder = new ScreenRecorder(TaskSettings.CaptureSettings.ScreenRecordFPS, duration, CaptureRectangle, path,
                            TaskSettings.CaptureSettings.ScreenRecordOutput);

                        Thread.Sleep(1000);
                        screenRegionManager.ChangeColor();

                        this.InvokeSafe(() => TrayIcon.Icon = Icon.FromHandle(Resources.control_record.GetHicon()));

                        screenRecorder.StartRecording();
                    });
                }

                if (screenRecorder != null && TaskSettings.CaptureSettings.ScreenRecordOutput != ScreenRecordOutput.AVI)
                {
                    TrayIcon.Icon = Icon.FromHandle(Resources.camcorder__pencil.GetHicon());

                    await TaskEx.Run(() =>
                    {
                        Stopwatch timer = Stopwatch.StartNew();

                        switch (TaskSettings.CaptureSettings.ScreenRecordOutput)
                        {
                            case ScreenRecordOutput.GIF:
                                path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename(TaskSettings, "gif"));
                                screenRecorder.SaveAsGIF(path, TaskSettings.ImageSettings.ImageGIFQuality);
                                break;
                            case ScreenRecordOutput.AVICommandLine:
                                path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename(TaskSettings,
                                    TaskSettings.CaptureSettings.ScreenRecordCommandLineOutputExtension));
                                screenRecorder.EncodeUsingCommandLine(path, TaskSettings.CaptureSettings.ScreenRecordCommandLinePath,
                                    TaskSettings.CaptureSettings.ScreenRecordCommandLineArgs);
                                break;
                        }
                    });
                }
            }
            finally
            {
                if (screenRecorder != null)
                {
                    if (TaskSettings.CaptureSettings.ScreenRecordOutput == ScreenRecordOutput.AVICommandLine &&
                        !string.IsNullOrEmpty(screenRecorder.CachePath) && File.Exists(screenRecorder.CachePath))
                    {
                        File.Delete(screenRecorder.CachePath);
                    }

                    screenRecorder.Dispose();
                    screenRecorder = null;
                }

                if (TrayIcon.Visible)
                {
                    TrayIcon.Visible = false;
                }
            }

            if (TaskSettings.AfterCaptureJob.HasFlag(AfterCaptureTasks.UploadImageToHost))
            {
                UploadManager.UploadFile(path, TaskSettings);
            }
            else
            {
                TaskHelper.ShowResultNotifications(path);
            }

            IsRecording = false;
        }

        public void StopRecording()
        {
            if (IsRecording && screenRecorder != null)
            {
                screenRecorder.StopRecording();
            }
        }
    }
}