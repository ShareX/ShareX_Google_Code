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
    public partial class ScreenRecordForm : Form
    {
        public static TaskSettings TaskSettings { get; set; }
        public Rectangle CaptureRectangle { get; private set; }

        private static ScreenRecordForm instance;

        public static ScreenRecordForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new ScreenRecordForm();
                }

                return instance;
            }
        }

        public bool IsRecording { get; private set; }

        private ScreenRecorder screenRecorder = null;

        private ScreenRecordForm()
        {
            InitializeComponent();
            Icon = Resources.ShareXIcon;
            niTray.Icon = Icon.FromHandle(Resources.control_record.GetHicon());
        }

        public void LoadSettings()
        {
            Screenshot.CaptureCursor = TaskSettings.CaptureSettings.ShowCursor;

            SelectRegion(TaskSettings);
        }

        private void SelectRegion(TaskSettings taskSettings)
        {
            Rectangle rect;
            if (TaskHelper.SelectRegion(taskSettings, out rect) && !rect.IsEmpty)
            {
                CaptureRectangle = Helpers.EvenRectangleSize(rect);
                lblRegion.Text = string.Format("X: {0}, Y: {1}, Width: {2}, Height: {3}", CaptureRectangle.X, CaptureRectangle.Y,
                    CaptureRectangle.Width, CaptureRectangle.Height);
                btnRecord.Enabled = true;
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            StartRecording();
        }

        public async void StartRecording()
        {
            if (IsRecording || CaptureRectangle.IsEmpty || screenRecorder != null)
            {
                if (!Visible) this.ShowActivate();
                return;
            }

            IsRecording = true;
            if (Visible) Hide();
            btnRecord.Enabled = false;
            btnRecord.Visible = false;
            pbEncoding.Visible = true;
            pbEncoding.Value = 0;

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

                        screenRecorder = new ScreenRecorder(TaskSettings.CaptureSettings.ScreenRecordFPS, duration, CaptureRectangle, path, TaskSettings.CaptureSettings.ScreenRecordOutput);

                        Thread.Sleep(1000);
                        screenRegionManager.ChangeColor();

                        if (duration <= 0)
                        {
                            this.InvokeSafe(() => niTray.Visible = true);
                        }

                        screenRecorder.StartRecording();
                    });
                }

                this.ShowActivate();

                if (niTray.Visible)
                {
                    niTray.Visible = false;
                }

                if (screenRecorder != null && TaskSettings.CaptureSettings.ScreenRecordOutput != ScreenRecordOutput.AVI)
                {
                    screenRecorder.EncodingProgressChanged += screenRecorder_EncodingProgressChanged;

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
                                path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename(TaskSettings, TaskSettings.CaptureSettings.ScreenRecordCommandLineOutputExtension));
                                screenRecorder.EncodeUsingCommandLine(path, TaskSettings.CaptureSettings.ScreenRecordCommandLinePath, TaskSettings.CaptureSettings.ScreenRecordCommandLineArgs);
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
            }

            if (TaskSettings.AfterCaptureJob.HasFlag(AfterCaptureTasks.UploadImageToHost))
            {
                UploadManager.UploadFile(path, TaskSettings);
            }
            else
            {
                TaskHelper.ShowResultNotifications(path);
            }

            pbEncoding.Visible = false;
            btnRecord.Enabled = true;
            btnRecord.Visible = true;
            IsRecording = false;
            Close();
        }

        private void screenRecorder_EncodingProgressChanged(int progress)
        {
            this.InvokeSafe(() =>
            {
                if (progress == -1)
                {
                    if (pbEncoding.Style != ProgressBarStyle.Marquee)
                    {
                        pbEncoding.Style = ProgressBarStyle.Marquee;
                    }
                }
                else
                {
                    if (pbEncoding.Style != ProgressBarStyle.Blocks)
                    {
                        pbEncoding.Style = ProgressBarStyle.Blocks;
                    }

                    pbEncoding.Value = progress;
                }
            });
        }

        private void btnRegion_Click(object sender, EventArgs e)
        {
            SelectRegion(TaskSettings);
        }

        private void niTray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StopRecording();
            }
        }

        public void StopRecording()
        {
            if (IsRecording && screenRecorder != null)
            {
                screenRecorder.StopRecording();

                if (niTray.Visible)
                {
                    niTray.Visible = false;
                }
            }
        }
    }
}