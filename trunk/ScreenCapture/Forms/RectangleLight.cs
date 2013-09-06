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
using ScreenCapture.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ScreenCapture
{
    public class RectangleLight : Form
    {
        private Timer timer;
        private Image backgroundImage;
        private TextureBrush backgroundBrush;
        private Pen rectanglePen;
        private Point positionOnClick, positionOld;
        private bool isMouseDown;

        public Rectangle ScreenRectangle { get; private set; }

        public Rectangle ScreenRectangle0Based
        {
            get
            {
                return new Rectangle(0, 0, ScreenRectangle.Width, ScreenRectangle.Height);
            }
        }

        public Rectangle SelectionRectangle { get; private set; }

        public Rectangle SelectionRectangle0Based
        {
            get
            {
                return new Rectangle(SelectionRectangle.X - ScreenRectangle.X, SelectionRectangle.Y - ScreenRectangle.Y,
                    SelectionRectangle.Width, SelectionRectangle.Height);
            }
        }

        public Point CurrentMousePosition { get; private set; }

        public Point CurrentMousePosition0Based
        {
            get
            {
                return new Point(CurrentMousePosition.X - ScreenRectangle.X, CurrentMousePosition.Y - ScreenRectangle.Y);
            }
        }

        public bool ShowRectangleInfo { get; set; }

        public RectangleLight()
        {
            backgroundImage = Screenshot.CaptureFullscreen();
            backgroundBrush = new TextureBrush(backgroundImage);
            rectanglePen = new Pen(Color.Red);
            ScreenRectangle = CaptureHelpers.GetScreenBounds();

            InitializeComponent();

            using (MemoryStream cursorStream = new MemoryStream(Resources.Crosshair))
            {
                Cursor = new Cursor(cursorStream);
            }

            timer = new Timer { Interval = 10 };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (timer != null) timer.Dispose();
            if (backgroundImage != null) backgroundImage.Dispose();
            if (backgroundBrush != null) backgroundBrush.Dispose();
            if (rectanglePen != null) rectanglePen.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = ScreenRectangle;
            this.FormBorderStyle = FormBorderStyle.None;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.Text = "ShareX - Rectangle Capture Light";
#if !DEBUG
            this.ShowInTaskbar = false;
            this.TopMost = true;
#endif
            this.Shown += RectangleLight_Shown;
            this.KeyUp += RectangleLight_KeyUp;
            this.MouseDown += RectangleLight_MouseDown;
            this.MouseUp += RectangleLight_MouseUp;
            this.ResumeLayout(false);
        }

        private void RectangleLight_Shown(object sender, EventArgs e)
        {
            Activate();
        }

        private void RectangleLight_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void RectangleLight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                positionOnClick = CaptureHelpers.GetMousePosition();
                isMouseDown = true;
            }
            else if (isMouseDown)
            {
                isMouseDown = false;
                Refresh();
            }
            else
            {
                Close();
            }
        }

        private void RectangleLight_MouseUp(object sender, MouseEventArgs e)
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

        public Image GetAreaImage()
        {
            Rectangle rect = SelectionRectangle0Based;

            if (rect.Width > 0 && rect.Height > 0)
            {
                if (rect.X == 0 && rect.Y == 0 && rect.Width == backgroundImage.Width && rect.Height == backgroundImage.Height)
                {
                    return (Image)backgroundImage.Clone();
                }

                return CaptureHelpers.CropImage(backgroundImage, rect);
            }

            return null;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            positionOld = CurrentMousePosition;
            CurrentMousePosition = CaptureHelpers.GetMousePosition();

            if (CurrentMousePosition != positionOld)
            {
                SelectionRectangle = CaptureHelpers.CreateRectangle(positionOnClick.X, positionOnClick.Y, CurrentMousePosition.X, CurrentMousePosition.Y);
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.FillRectangle(backgroundBrush, ScreenRectangle0Based);

            if (isMouseDown)
            {
                if (ShowRectangleInfo)
                {
                    int offset = 10;
                    Point position = new Point(CurrentMousePosition0Based.X + offset, CurrentMousePosition0Based.Y + offset);

                    using (Font font = new Font("Arial", 17, FontStyle.Bold))
                    {
                        CaptureHelpers.DrawTextWithOutline(g, string.Format("{0}, {1}\r\n{2} x {3}", SelectionRectangle.X, SelectionRectangle.Y,
                            SelectionRectangle.Width, SelectionRectangle.Height), position, font, Color.White, Color.Black, 3);
                    }
                }

                g.DrawRectangleProper(rectanglePen, SelectionRectangle0Based);
            }
        }
    }
}