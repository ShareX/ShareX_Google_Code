﻿#region License Information (GPL v3)

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

        public ScreenRecordForm()
        {
            InitializeComponent();

            lblRegion.Text = CaptureRectangle.ToString();
            nudFPS.Value = Program.Settings.ScreenRecordFPS;
            nudDuration.Value = (decimal)Program.Settings.ScreenRecordDuration;
            cbOutput.Items.AddRange(Enum.GetNames(typeof(ScreenRecordOutput)));
            cbOutput.SelectedIndex = (int)Program.Settings.ScreenRecordOutput;
            cbAutoUploadGIF.Checked = Program.Settings.ScreenRecordAutoUpload;

            Screenshot.CaptureCursor = Program.Settings.ShowCursor;

            SelectRegion();
        }

        private void SelectRegion()
        {
            Rectangle rect;
            if (TaskHelper.SelectRegion(out rect))
            {
                CaptureRectangle = Helpers.EvenRectangleSize(rect);
                lblRegion.Text = string.Format("X: {0}, Y: {1}, Width: {2}, Height: {3}", CaptureRectangle.X, CaptureRectangle.Y,
                    CaptureRectangle.Width, CaptureRectangle.Height);
            }
        }

        private async void btnRecord_Click(object sender, EventArgs e)
        {
            if (CaptureRectangle.IsEmpty)
            {
                return;
            }

            btnRecord.Enabled = false;
            Hide();
            btnRecord.Visible = false;
            pbEncoding.Visible = true;
            pbEncoding.Value = 0;

            ScreenRecorder screenRecorder = null;
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

                        screenRecorder = new ScreenRecorder(Program.Settings.ScreenRecordFPS, Program.Settings.ScreenRecordDuration,
                            CaptureRectangle, path, Program.Settings.ScreenRecordOutput);

                        Thread.Sleep(1000);
                        screenRegionManager.ChangeColor();

                        screenRecorder.StartRecording();
                    });
                }

                Show();

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
                            case ScreenRecordOutput.AVI_CommandLine:
                                path = Path.Combine(Program.ScreenshotsPath, TaskHelper.GetFilename("mp4"));
                                screenRecorder.EncodeUsingCommandLine(path, "x264.exe", "--output %output %input");
                                break;
                        }
                    });
                }
            }
            finally
            {
                if (screenRecorder != null)
                {
                    if (Program.Settings.ScreenRecordOutput == ScreenRecordOutput.AVI_CommandLine &&
                        !string.IsNullOrEmpty(screenRecorder.CachePath) && File.Exists(screenRecorder.CachePath))
                    {
                        File.Delete(screenRecorder.CachePath);
                    }

                    screenRecorder.Dispose();
                }
            }

            if (Program.Settings.ScreenRecordAutoUpload && Program.Settings.ScreenRecordOutput != ScreenRecordOutput.AVI)
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
        }

        private void cbAutoUploadGIF_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ScreenRecordAutoUpload = cbAutoUploadGIF.Checked;
        }
    }
}