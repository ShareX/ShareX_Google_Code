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

        private ScreenRecorder screenRecorder = null;

        private ScreenRecordForm()
        {
            InitializeComponent();
            Icon = Resources.ShareX;
            niTray.Icon = Icon.FromHandle(Resources.control_record.GetHicon());

            lblRegion.Text = CaptureRectangle.ToString();
            nudFPS.Value = Program.Settings.ScreenRecordFPS;
            cbFixedDuration.Checked = Program.Settings.ScreenRecordFixedDuration;
            nudDuration.Enabled = Program.Settings.ScreenRecordFixedDuration;
            nudDuration.Value = (decimal)Program.Settings.ScreenRecordDuration;
            cbOutput.Items.AddRange(Helpers.GetEnumDescriptions<ScreenRecordOutput>());
            cbOutput.SelectedIndex = (int)Program.Settings.ScreenRecordOutput;
            cbAutoUploadGIF.Checked = Program.Settings.ScreenRecordAutoUpload;

            Screenshot.CaptureCursor = Program.Settings.ShowCursor;

            SelectRegion();
        }

        private void SelectRegion()
        {
            Rectangle rect;
            if (TaskHelper.SelectRegion(out rect) && !rect.IsEmpty)
            {
                CaptureRectangle = Helpers.EvenRectangleSize(rect);
                lblRegion.Text = string.Format("X: {0}, Y: {1}, Width: {2}, Height: {3}", CaptureRectangle.X, CaptureRectangle.Y,
                    CaptureRectangle.Width, CaptureRectangle.Height);
                btnRecord.Enabled = true;
            }
        }

        private async void btnRecord_Click(object sender, EventArgs e)
        {
            if (CaptureRectangle.IsEmpty || screenRecorder != null)
            {
                return;
            }

            btnRecord.Enabled = false;
            Hide();
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
                        if (Program.Settings.ScreenRecordOutput == ScreenRecordOutput.AVI)
                        {
                            path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename("avi"));
                        }
                        else
                        {
                            path = Program.ScreenRecorderCacheFilePath;
                        }

                        float duration = Program.Settings.ScreenRecordFixedDuration ? Program.Settings.ScreenRecordDuration : 0;

                        screenRecorder = new ScreenRecorder(Program.Settings.ScreenRecordFPS, duration, CaptureRectangle, path, Program.Settings.ScreenRecordOutput);

                        Thread.Sleep(1000);
                        screenRegionManager.ChangeColor();

                        if (duration <= 0)
                        {
                            this.InvokeSafe(() => niTray.Visible = true);
                        }

                        screenRecorder.StartRecording();
                    });
                }

                Show();
                if (niTray.Visible)
                {
                    niTray.Visible = false;
                }

                if (screenRecorder != null && Program.Settings.ScreenRecordOutput != ScreenRecordOutput.AVI)
                {
                    screenRecorder.EncodingProgressChanged += screenRecorder_EncodingProgressChanged;

                    await TaskEx.Run(() =>
                    {
                        Stopwatch timer = Stopwatch.StartNew();

                        switch (Program.Settings.ScreenRecordOutput)
                        {
                            case ScreenRecordOutput.GIF:
                                path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename("gif"));
                                screenRecorder.SaveAsGIF(path, Program.Settings.ImageGIFQuality);
                                break;
                            case ScreenRecordOutput.AVICommandLine:
                                path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename(Program.Settings.ScreenRecordCommandLineOutputExtension));
                                screenRecorder.EncodeUsingCommandLine(path, Program.Settings.ScreenRecordCommandLinePath, Program.Settings.ScreenRecordCommandLineArgs);
                                break;
                        }
                    });
                }
            }
            finally
            {
                if (screenRecorder != null)
                {
                    if (Program.Settings.ScreenRecordOutput == ScreenRecordOutput.AVICommandLine &&
                        !string.IsNullOrEmpty(screenRecorder.CachePath) && File.Exists(screenRecorder.CachePath))
                    {
                        File.Delete(screenRecorder.CachePath);
                    }

                    screenRecorder.Dispose();
                    screenRecorder = null;
                }
            }

            if (Program.Settings.ScreenRecordAutoUpload)
            {
                UploadManager.UploadFile(path);
            }
            else
            {
                TaskHelper.ShowResultNotifications(path);
            }

            pbEncoding.Visible = false;
            btnRecord.Enabled = true;
            btnRecord.Visible = true;
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
            SelectRegion();
        }

        private void nudFPS_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ScreenRecordFPS = (int)nudFPS.Value;
        }

        private void nudDuration_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.ScreenRecordDuration = (float)nudDuration.Value;
        }

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Settings.ScreenRecordOutput = (ScreenRecordOutput)cbOutput.SelectedIndex;

            btnSettings.Visible = Program.Settings.ScreenRecordOutput == ScreenRecordOutput.AVICommandLine;
        }

        private void cbAutoUploadGIF_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ScreenRecordAutoUpload = cbAutoUploadGIF.Checked;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (ScreenRecordCommandLineForm form = new ScreenRecordCommandLineForm())
            {
                form.Icon = Icon;
                form.ShowDialog();
            }
        }

        private void cbFixedDuration_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ScreenRecordFixedDuration = cbFixedDuration.Checked;
            nudDuration.Enabled = Program.Settings.ScreenRecordFixedDuration;
        }

        private void niTray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && screenRecorder != null)
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