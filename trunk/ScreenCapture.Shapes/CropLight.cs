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

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using HelpersLib;

namespace ScreenCapture
{
    public class CropLight : Form
    {
        private Timer timer;
        private TextureBrush backgroundBrush;
        private Pen rectanglePen;
        private Point positionOnClick, positionCurrent, positionOld;
        private bool isMouseDown;

        public Rectangle SelectionRectangle { get; private set; }

        public CropLight(Image backgroundImage)
        {
            InitializeComponent();

            backgroundBrush = new TextureBrush(backgroundImage);
            rectanglePen = new Pen(Color.Red);

            timer = new Timer { Interval = 10 };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void SimpleCrop_Shown(object sender, EventArgs e)
        {
            BringToFront();
            Activate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isMouseDown)
            {
                positionOld = positionCurrent;
                positionCurrent = CaptureHelpers.GetZeroBasedMousePosition();

                if (positionCurrent != positionOld)
                {
                    SelectionRectangle = CaptureHelpers.CreateRectangle(positionOnClick.X, positionOnClick.Y, positionCurrent.X, positionCurrent.Y);
                    Refresh();
                }
            }
        }

        private void Crop_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void Crop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                positionOnClick = e.Location;
                isMouseDown = true;
            }
            else
            {
                if (isMouseDown)
                {
                    isMouseDown = false;
                    Refresh();
                }
                else
                {
                    Close();
                }
            }
        }

        private void Crop_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown && e.Button == MouseButtons.Left)
            {
                if (SelectionRectangle.Width > 0 && SelectionRectangle.Height > 0)
                {
                    DialogResult = DialogResult.OK;
                }

                Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.FillRectangle(backgroundBrush, Bounds);

            if (isMouseDown)
            {
                g.DrawRectangleProper(rectanglePen, SelectionRectangle);
            }
        }

        #region Windows Form Designer generated code

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (timer != null) timer.Dispose();
            if (backgroundBrush != null) backgroundBrush.Dispose();
            if (rectanglePen != null) rectanglePen.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "Crop";
            this.Text = "Crop";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = CaptureHelpers.GetScreenBounds();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.Cursor = Cursors.Cross;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.KeyDown += new KeyEventHandler(this.Crop_KeyDown);
            this.MouseDown += new MouseEventHandler(this.Crop_MouseDown);
            this.MouseUp += new MouseEventHandler(this.Crop_MouseUp);
            this.Shown += new EventHandler(SimpleCrop_Shown);
            this.ResumeLayout(false);
        }

        #endregion Windows Form Designer generated code
    }
}