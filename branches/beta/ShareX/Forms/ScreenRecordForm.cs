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
        public Rectangle CaptureRectangle { get; private set; }

        private static ScreenRecordForm instance;
        private static TaskSettings taskSettings;

        public static ScreenRecordForm Instance(TaskSettings taskSettings)
        {
            ScreenRecordForm.taskSettings = taskSettings;
            if (instance == null || instance.IsDisposed)
            {
                instance = new ScreenRecordForm(taskSettings);
            }

            return instance;
        }

        public bool IsRecording { get; private set; }

        private ScreenRecorder screenRecorder = null;

        private ScreenRecordForm(TaskSettings taskSettings)
        {
            InitializeComponent();
            Icon = Resources.ShareX;
            niTray.Icon = Icon.FromHandle(Resources.control_record.GetHicon());

            lblRegion.Text = CaptureRectangle.ToString();
            nudFPS.Value = taskSettings.ScreenRecordFPS;
            cbFixedDuration.Checked = taskSettings.ScreenRecordFixedDuration;
            nudDuration.Enabled = taskSettings.ScreenRecordFixedDuration;
            nudDuration.Value = (decimal)taskSettings.ScreenRecordDuration;
            cbOutput.Items.AddRange(Helpers.GetEnumDescriptions<ScreenRecordOutput>());
            cbOutput.SelectedIndex = (int)taskSettings.ScreenRecordOutput;
            cbAutoUploadGIF.Checked = taskSettings.ScreenRecordAutoUpload;

            Screenshot.CaptureCursor = taskSettings.ShowCursor;

            SelectRegion(taskSettings);
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
            StartRecording(taskSettings);
        }

        public async void StartRecording(TaskSettings taskSettings)
        {
            if (taskSettings == null) taskSettings = Program.Settings.DefaultTaskSettings;

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
                        if (taskSettings.ScreenRecordOutput == ScreenRecordOutput.AVI)
                        {
                            path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename(taskSettings, "avi"));
                        }
                        else
                        {
                            path = Program.ScreenRecorderCacheFilePath;
                        }

                        float duration = taskSettings.ScreenRecordFixedDuration ? taskSettings.ScreenRecordDuration : 0;

                        screenRecorder = new ScreenRecorder(taskSettings.ScreenRecordFPS, duration, CaptureRectangle, path, taskSettings.ScreenRecordOutput);

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

                if (screenRecorder != null && taskSettings.ScreenRecordOutput != ScreenRecordOutput.AVI)
                {
                    screenRecorder.EncodingProgressChanged += screenRecorder_EncodingProgressChanged;

                    await TaskEx.Run(() =>
                    {
                        Stopwatch timer = Stopwatch.StartNew();

                        switch (taskSettings.ScreenRecordOutput)
                        {
                            case ScreenRecordOutput.GIF:
                                path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename(taskSettings, "gif"));
                                screenRecorder.SaveAsGIF(path, taskSettings.ImageGIFQuality);
                                break;
                            case ScreenRecordOutput.AVICommandLine:
                                path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename(taskSettings));
                                screenRecorder.EncodeUsingCommandLine(path, taskSettings.ScreenRecordCommandLinePath, taskSettings.ScreenRecordCommandLineArgs);
                                break;
                        }
                    });
                }
            }
            finally
            {
                if (screenRecorder != null)
                {
                    if (taskSettings.ScreenRecordOutput == ScreenRecordOutput.AVICommandLine &&
                        !string.IsNullOrEmpty(screenRecorder.CachePath) && File.Exists(screenRecorder.CachePath))
                    {
                        File.Delete(screenRecorder.CachePath);
                    }

                    screenRecorder.Dispose();
                    screenRecorder = null;
                }
            }

            if (taskSettings.ScreenRecordAutoUpload)
            {
                UploadManager.UploadFile(path, taskSettings);
            }
            else
            {
                TaskHelper.ShowResultNotifications(path);
            }

            pbEncoding.Visible = false;
            btnRecord.Enabled = true;
            btnRecord.Visible = true;
            IsRecording = false;
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
            SelectRegion(taskSettings);
        }

        private void nudFPS_ValueChanged(object sender, EventArgs e)
        {
            taskSettings.ScreenRecordFPS = (int)nudFPS.Value;
        }

        private void nudDuration_ValueChanged(object sender, EventArgs e)
        {
            taskSettings.ScreenRecordDuration = (float)nudDuration.Value;
        }

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            taskSettings.ScreenRecordOutput = (ScreenRecordOutput)cbOutput.SelectedIndex;

            btnSettings.Visible = taskSettings.ScreenRecordOutput == ScreenRecordOutput.AVICommandLine;
        }

        private void cbAutoUploadGIF_CheckedChanged(object sender, EventArgs e)
        {
            taskSettings.ScreenRecordAutoUpload = cbAutoUploadGIF.Checked;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (ScreenRecordCommandLineForm form = new ScreenRecordCommandLineForm(taskSettings))
            {
                form.Icon = Icon;
                form.ShowDialog();
            }
        }

        private void cbFixedDuration_CheckedChanged(object sender, EventArgs e)
        {
            taskSettings.ScreenRecordFixedDuration = cbFixedDuration.Checked;
            nudDuration.Enabled = taskSettings.ScreenRecordFixedDuration;
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