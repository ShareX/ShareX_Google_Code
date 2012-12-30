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
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class ScreenRecordForm : Form
    {
        public Rectangle CaptureRectangle { get; set; }
        public int FPS { get; set; }
        public float Duration { get; set; } // Seconds
        public GIFQuality GIFQuality { get; set; }

        public ScreenRecordForm()
        {
            InitializeComponent();
            FPS = 5;
            Duration = 3;
            CaptureRectangle = new Rectangle(0, 0, 500, 500);

            lblRegion.Text = CaptureRectangle.ToString();
            nudFPS.Value = FPS;
            nudDuration.Value = (decimal)Duration;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            btnRecord.Enabled = false;
            Hide();
            ScreenRecorder screenRecorder = new ScreenRecorder(FPS, Duration, CaptureRectangle);
            Helpers.AsyncJob(() =>
            {
                Thread.Sleep(1000);
                screenRecorder.StartRecording();
                Stopwatch timer = Stopwatch.StartNew();
                screenRecorder.MakeGIF2(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.gif"), GIFQuality);
                Debug.WriteLine("GIF encoding completed in " + timer.ElapsedMilliseconds + "ms");
            },
            () =>
            {
                screenRecorder.ClearTempFolder();
                btnRecord.Enabled = true;
                Show();
            });
        }

        private void btnRegion_Click(object sender, EventArgs e)
        {
            using (CropLight cropForm = new CropLight())
            {
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
    }
}