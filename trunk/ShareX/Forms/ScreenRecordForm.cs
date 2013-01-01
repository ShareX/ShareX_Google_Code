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

using HelpersLib;
using ScreenCapture;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ShareX
{
    public partial class ScreenRecordForm : Form
    {
        public Rectangle CaptureRectangle { get; set; }
        public int FPS { get; set; }
        public float Duration { get; set; } // Seconds
        public ScreenRecordOutput Output { get; set; }

        public ScreenRecordForm()
        {
            InitializeComponent();
            FPS = 5;
            Duration = 3;
            CaptureRectangle = new Rectangle(0, 0, 500, 500);
            Output = ScreenRecordOutput.GIF;

            lblRegion.Text = CaptureRectangle.ToString();
            nudFPS.Value = FPS;
            nudDuration.Value = (decimal)Duration;
            cbOutput.Items.AddRange(Enum.GetNames(typeof(ScreenRecordOutput)));
            cbOutput.SelectedIndex = (int)Output;

            Screenshot.DrawCursor = Program.Settings.ShowCursor;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            btnRecord.Enabled = false;
            Hide();
            Helpers.AsyncJob(() =>
            {
                Thread.Sleep(1000);
                using (ScreenRecorder screenRecorder = new ScreenRecorder(FPS, Duration, CaptureRectangle, Program.ScreenRecorderCacheFilePath))
                {
                    screenRecorder.StartRecording();
                    Stopwatch timer = Stopwatch.StartNew();

                    switch (Output)
                    {
                        case ScreenRecordOutput.GIF:
                            string pathGIF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.gif");
                            screenRecorder.SaveAsGIF(pathGIF, Program.Settings.ImageGIFQuality);
                            break;
                        case ScreenRecordOutput.AVI:
                            string pathAVI = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.avi");
                            screenRecorder.SaveAsAVI(pathAVI);
                            break;
                    }

                    Debug.WriteLine("Encoding completed in " + timer.ElapsedMilliseconds + "ms");
                }
            },
            () =>
            {
                btnRecord.Enabled = true;
                Show();
            });
        }

        private void btnRegion_Click(object sender, EventArgs e)
        {
            using (CropLight cropForm = new CropLight())
            {
                cropForm.ShowRectangleInfo = true;

                if (cropForm.ShowDialog() == DialogResult.OK)
                {
                    CaptureRectangle = cropForm.SelectionRectangle;
                    lblRegion.Text = CaptureRectangle.ToString();
                }
            }
        }

        private void nudFPS_ValueChanged(object sender, EventArgs e)
        {
            FPS = (int)nudFPS.Value;
        }

        private void nudDuration_ValueChanged(object sender, EventArgs e)
        {
            Duration = (float)nudDuration.Value;
        }

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            Output = (ScreenRecordOutput)cbOutput.SelectedIndex;
        }
    }
}