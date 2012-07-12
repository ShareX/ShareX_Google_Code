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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using HelpersLib;

namespace ScreenCapture
{
    public class RectangleRegion : Surface
    {
        public AreaManager AreaManager { get; private set; }

        private int magnifierPixelCount = 15;
        private int magnifierPixelSize = 10;

        public RectangleRegion(Image backgroundImage = null)
            : base(backgroundImage)
        {
            AreaManager = new AreaManager(this);
            KeyDown += new KeyEventHandler(RectangleRegion_KeyDown);
            MouseWheel += new MouseEventHandler(RectangleRegion_MouseWheel);
        }

        private void RectangleRegion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.I:
                    Config.ShowInfo = !Config.ShowInfo;
                    break;
                case Keys.C:
                    Config.ShowCrosshair = !Config.ShowCrosshair;
                    break;
                case Keys.M:
                    Config.ShowMagnifier = !Config.ShowMagnifier;
                    break;
            }
        }

        private void RectangleRegion_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    if (magnifierPixelSize < 30) magnifierPixelSize++;
                }
                else
                {
                    if (magnifierPixelCount < 35) magnifierPixelCount += 2;
                }
            }
            else if (e.Delta < 0)
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    if (magnifierPixelSize > 3) magnifierPixelSize--;
                }
                else
                {
                    if (magnifierPixelCount > 3) magnifierPixelCount -= 2;
                }
            }
        }

        public override void Prepare()
        {
            base.Prepare();

            if (Config != null)
            {
                AreaManager.WindowCaptureMode |= Config.ForceWindowCapture;

                if (AreaManager.WindowCaptureMode)
                {
                    WindowsListAdvanced wla = new WindowsListAdvanced();
                    wla.IgnoreWindows.Add(Handle);
                    wla.IncludeChildWindows = Config.IncludeControls;
                    AreaManager.Windows = wla.GetWindowsRectangleList();
                }
            }
        }

        protected override void Update()
        {
            base.Update();
            AreaManager.Update();
        }

        protected override void Draw(Graphics g)
        {
            borderDotPen.DashOffset = (float)timer.Elapsed.TotalSeconds * 10;
            borderDotPen2.DashOffset = 5 + (float)timer.Elapsed.TotalSeconds * 10;

            if (Config.ShowCrosshair)
            {
                DrawCrosshair(g);
            }

            List<Rectangle> areas = AreaManager.GetValidAreas;

            if (areas.Count > 0 || !AreaManager.CurrentHoverArea.IsEmpty)
            {
                UpdateRegionPath();

                using (Region region = new Region(regionDrawPath))
                {
                    g.ExcludeClip(region);
                    g.FillRectangle(shadowBrush, 0, 0, Width, Height);
                    g.ResetClip();
                }

                g.DrawPath(borderPen, regionDrawPath);

                if (areas.Count > 1)
                {
                    Rectangle totalArea = AreaManager.CombineAreas();
                    g.DrawCrossRectangle(borderPen, totalArea, 15);

                    if (Config.ShowInfo)
                    {
                        CaptureHelpers.DrawTextWithOutline(g, string.Format("X:{0} Y:{1} W:{2} H:{3}", totalArea.X, totalArea.Y,
                            totalArea.Width, totalArea.Height), new PointF(totalArea.X + 5, totalArea.Y - 25), textFont, Color.White, Color.Black);
                        g.SmoothingMode = SmoothingMode.HighSpeed;
                    }
                }

                if (AreaManager.IsCurrentHoverAreaValid)
                {
                    GraphicsPath hoverFillPath = new GraphicsPath() { FillMode = FillMode.Winding };
                    AddShapePath(hoverFillPath, AreaManager.CurrentHoverArea);

                    g.FillPath(lightBrush, hoverFillPath);

                    GraphicsPath hoverDrawPath = new GraphicsPath() { FillMode = FillMode.Winding };
                    AddShapePath(hoverDrawPath, AreaManager.CurrentHoverArea.SizeOffset(-1));

                    g.DrawPath(borderDotPen, hoverDrawPath);
                    g.DrawPath(borderDotPen2, hoverDrawPath);
                }

                if (AreaManager.IsCurrentAreaValid)
                {
                    g.DrawRectangleProper(borderDotPen, AreaManager.CurrentArea);
                    g.DrawRectangleProper(borderDotPen2, AreaManager.CurrentArea);
                    DrawObjects(g);
                }

                if (Config.ShowInfo)
                {
                    foreach (Rectangle area in areas)
                    {
                        if (area.IsValid())
                        {
                            CaptureHelpers.DrawTextWithOutline(g, string.Format("X:{0} Y:{1}\nW:{2} H:{3}", area.X, area.Y, area.Width, area.Height),
                                new PointF(area.X + 5, area.Y + 5), textFont, Color.White, Color.Black);
                        }
                    }

                    g.SmoothingMode = SmoothingMode.HighSpeed;
                }
            }
            else
            {
                g.FillRectangle(shadowBrush, 0, 0, Width, Height);
            }

            if (Config.ShowMagnifier)
            {
                DrawMagnifier(g);
            }
        }

        private void DrawCrosshair(Graphics g)
        {
            int offset = 10;
            Point mousePos = InputManager.MousePosition0Based;
            Point left = new Point(mousePos.X - offset, mousePos.Y), left2 = new Point(0, mousePos.Y);
            Point right = new Point(mousePos.X + offset, mousePos.Y), right2 = new Point(ScreenRectangle0Based.Width - 1, mousePos.Y);
            Point top = new Point(mousePos.X, mousePos.Y - offset), top2 = new Point(mousePos.X, 0);
            Point bottom = new Point(mousePos.X, mousePos.Y + offset), bottom2 = new Point(mousePos.X, ScreenRectangle0Based.Height - 1);

            if (left.X - left2.X > 10)
            {
                g.DrawLine(borderDotPen, left, left2);
                g.DrawLine(borderDotPen2, left, left2);
            }

            if (right2.X - right.X > 10)
            {
                g.DrawLine(borderDotPen, right, right2);
                g.DrawLine(borderDotPen2, right, right2);
            }

            if (top.Y - top2.Y > 10)
            {
                g.DrawLine(borderDotPen, top, top2);
                g.DrawLine(borderDotPen2, top, top2);
            }

            if (bottom2.Y - bottom.Y > 10)
            {
                g.DrawLine(borderDotPen, bottom, bottom2);
                g.DrawLine(borderDotPen2, bottom, bottom2);
            }
        }

        private void DrawMagnifier(Graphics g)
        {
            Point mousePos = InputManager.MousePosition0Based;
            int offset = 25;

            using (Bitmap magnifier = Magnifier(SurfaceImage, mousePos, magnifierPixelCount, magnifierPixelCount, magnifierPixelSize))
            {
                int x = mousePos.X + offset;

                if (x + magnifier.Width > ScreenRectangle0Based.Width)
                {
                    x = mousePos.X - offset - magnifier.Width;
                }

                int y = mousePos.Y + offset;

                if (y + magnifier.Height > ScreenRectangle0Based.Height)
                {
                    y = mousePos.Y - offset - magnifier.Height;
                }

                g.DrawImage(magnifier, new Point(x, y));
            }
        }

        private Bitmap Magnifier(Image img, Point position, int horizontalPixelCount, int verticalPixelCount, int pixelSize)
        {
            if (horizontalPixelCount % 2 == 0 || verticalPixelCount % 2 == 0)
            {
                throw new Exception("Pixel count must be odd.");
            }

            int width = horizontalPixelCount * pixelSize;
            int height = verticalPixelCount * pixelSize;
            Bitmap bmp = new Bitmap(width + 1, height + 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;

                g.DrawImage(SurfaceImage, new Rectangle(Point.Empty, new Size(width, height)),
                    new Rectangle(position.X - horizontalPixelCount / 2, position.Y - verticalPixelCount / 2, horizontalPixelCount, verticalPixelCount), GraphicsUnit.Pixel);

                g.PixelOffsetMode = PixelOffsetMode.None;

                using (SolidBrush crosshairBrush = new SolidBrush(Color.FromArgb(100, Color.Red)))
                {
                    g.FillRectangle(crosshairBrush, new Rectangle(0, (height - pixelSize) / 2, (width - pixelSize) / 2, pixelSize)); // Left
                    g.FillRectangle(crosshairBrush, new Rectangle((width + pixelSize) / 2, (height - pixelSize) / 2, (width - pixelSize) / 2, pixelSize)); // Right
                    g.FillRectangle(crosshairBrush, new Rectangle((width - pixelSize) / 2, 0, pixelSize, (height - pixelSize) / 2)); // Top
                    g.FillRectangle(crosshairBrush, new Rectangle((width - pixelSize) / 2, (height + pixelSize) / 2, pixelSize, (height - pixelSize) / 2)); // Bottom
                }

                using (Pen borderPen = new Pen(Color.FromArgb(75, Color.Black)))
                {
                    for (int x = 1; x < horizontalPixelCount; x++)
                    {
                        g.DrawLine(borderPen, new Point(x * pixelSize, 0), new Point(x * pixelSize, height));
                    }

                    for (int y = 1; y < verticalPixelCount; y++)
                    {
                        g.DrawLine(borderPen, new Point(0, y * pixelSize), new Point(width, y * pixelSize));
                    }
                }

                g.DrawRectangle(Pens.Black, 0, 0, width, height);
                g.DrawRectangle(Pens.Black, (width - pixelSize) / 2, (height - pixelSize) / 2, pixelSize, pixelSize);
            }

            return bmp;
        }

        public void UpdateRegionPath()
        {
            regionFillPath = new GraphicsPath() { FillMode = FillMode.Winding };
            regionDrawPath = new GraphicsPath() { FillMode = FillMode.Winding };

            foreach (Rectangle area in AreaManager.GetValidAreas)
            {
                AddShapePath(regionFillPath, area);
                AddShapePath(regionDrawPath, area.SizeOffset(-1));
            }
        }

        protected virtual void AddShapePath(GraphicsPath graphicsPath, Rectangle rect)
        {
            graphicsPath.AddRectangle(rect);
        }
    }
}