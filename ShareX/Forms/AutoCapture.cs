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
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ShareX
{
    public partial class AutoCapture : Form
    {
        public bool IsRunning { get; private set; }
        public Rectangle CaptureRectangle { get; private set; }

        private Timer timer, statusTimer;
        private int delay, count, timeleft, percentage;
        private bool waitUploads;
        private Stopwatch stopwatch = new Stopwatch();

        public AutoCapture()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += TimerTick;
            statusTimer = new Timer { Interval = 250 };
            statusTimer.Tick += StatusTimerTick;

            nudRepeatTime.Value = Program.Settings.AutoCaptureRepeatTime;
            cbAutoMinimize.Checked = Program.Settings.AutoCaptureMinimize;
            cbWaitUploads.Checked = Program.Settings.AutoCaptureWaitUpload;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (waitUploads && TaskManager.IsBusy)
            {
                timer.Interval = 1000;
            }
            else
            {
                stopwatch.Reset();
                stopwatch.Start();
                timer.Interval = delay;
                //Take SS
                count++;
            }
        }

        private void SelectRegion()
        {
            Rectangle rect;
            if (TaskHelper.SelectRegion(out rect))
            {
                CaptureRectangle = rect;
                lblRegion.Text = string.Format("X: {0}, Y: {1}, Width: {2}, Height: {3}", CaptureRectangle.X, CaptureRectangle.Y,
                    CaptureRectangle.Width, CaptureRectangle.Height);
            }
        }

        private void StatusTimerTick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Execute();
        }

        public void Execute()
        {
            if (IsRunning)
            {
                IsRunning = false;
                tspbBar.Value = 0;
                btnExecute.Text = "Start";
            }
            else
            {
                IsRunning = true;
                btnExecute.Text = "Stop";
                timer.Interval = 1000;
                delay = (int)(Program.Settings.AutoCaptureRepeatTime * 1000);
                waitUploads = Program.Settings.AutoCaptureWaitUpload;
                if (Program.Settings.AutoCaptureMinimize)
                {
                    WindowState = FormWindowState.Minimized;
                }
            }

            timer.Enabled = IsRunning;
            statusTimer.Enabled = IsRunning;
        }

        private void UpdateStatus()
        {
            timeleft = Math.Max(0, delay - (int)stopwatch.ElapsedMilliseconds);
            percentage = (int)(100 - (double)timeleft / delay * 100);
            tspbBar.Value = percentage;
            tsslStatus.Text = " Timeleft: " + timeleft + "ms (" + percentage + "%)";
            Text = "ShareX - Auto Capture (Count: " + count + ")";
        }

        private void btnRegion_Click(object sender, EventArgs e)
        {
            SelectRegion();
        }

        private void nudDuration_ValueChanged(object sender, EventArgs e)
        {
            Program.Settings.AutoCaptureRepeatTime = nudRepeatTime.Value;
        }

        private void cbAutoMinimize_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.AutoCaptureMinimize = cbAutoMinimize.Checked;
        }

        private void cbWaitUploads_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.AutoCaptureWaitUpload = cbWaitUploads.Checked;
        }
    }
}