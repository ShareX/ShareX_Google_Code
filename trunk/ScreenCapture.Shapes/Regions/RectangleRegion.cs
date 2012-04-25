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

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using HelpersLib;

namespace ScreenCapture
{
    public class RectangleRegion : Surface
    {
        public AreaManager AreaManager { get; private set; }

        public RectangleRegion(Image backgroundImage = null)
            : base(backgroundImage)
        {
            AreaManager = new AreaManager(this);
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
            List<Rectangle> areas = AreaManager.GetValidAreas;

            if (areas.Count > 0 || !AreaManager.CurrentHoverArea.IsEmpty)
            {
                UpdateRegionPath();

                using (Region region = new Region(regionFillPath))
                {
                    g.ExcludeClip(region);
                    g.FillRectangle(shadowBrush, 0, 0, Width, Height);
                    g.ResetClip();
                }

                /*foreach (WindowInfo wi in AreaManager.Windows)
                {
                    g.DrawRectangleProper(Pens.Yellow, Rectangle.Intersect(ScreenRectangle0Based, wi.Rectangle0Based));
                }*/

                borderDotPen.DashOffset = (float)timer.Elapsed.TotalSeconds * 10;
                borderDotPen2.DashOffset = 5 + (float)timer.Elapsed.TotalSeconds * 10;

                g.DrawPath(borderPen, regionDrawPath);

                if (areas.Count > 1)
                {
                    Rectangle totalArea = AreaManager.CombineAreas();
                    g.DrawCrossRectangle(borderPen, totalArea, 15);
                    CaptureHelpers.DrawTextWithOutline(g, string.Format("X:{0}, Y:{1}, Width:{2}, Height:{3}", totalArea.X, totalArea.Y,
                        totalArea.Width, totalArea.Height), new PointF(totalArea.X + 5, totalArea.Y - 20), textFont, Color.White, Color.Black);
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
                    g.ExcludeClip(AreaManager.CurrentArea);
                    DrawObjects(g);
                    g.ResetClip();
                }

                foreach (Rectangle area in areas)
                {
                    if (area.Width > 100 && area.Height > 20)
                    {
                        g.Clip = new Region(area);

                        CaptureHelpers.DrawTextWithOutline(g, string.Format("X:{0}, Y:{1}, Width:{2}, Height:{3}", area.X, area.Y, area.Width, area.Height),
                            new PointF(area.X + 5, area.Y + 5), textFont, Color.White, Color.Black);
                    }
                }

                g.ResetClip();
            }
            else
            {
                g.FillRectangle(shadowBrush, 0, 0, Width, Height);
            }

            DrawMagnifyingGlass(g);
        }

        private void DrawMagnifyingGlass(Graphics g)
        {
            Point mousePos = InputManager.MousePosition0Based;
            int offset = 20;
            int size = 110;

            using (Bitmap magnifier = MagnifyingGlass(SurfaceImage, mousePos))
            {
                Point magnifyingGlassPosition;

                if (InputManager.MousePosition == AreaManager.CurrentArea.Location)
                {
                    magnifyingGlassPosition = new Point(mousePos.X - size - offset, mousePos.Y - size - offset);
                }
                else
                {
                    magnifyingGlassPosition = new Point(mousePos.X + offset, mousePos.Y + offset);
                }

                g.DrawImage(magnifier, magnifyingGlassPosition);
            }
        }

        private Bitmap MagnifyingGlass(Image img, Point point)
        {
            Bitmap bmp = new Bitmap(110, 110);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;

                g.DrawImage(SurfaceImage, new Rectangle(Point.Empty, new Size(110, 110)), new Rectangle(point.X - 5, point.Y - 5, 11, 11), GraphicsUnit.Pixel);

                g.PixelOffsetMode = PixelOffsetMode.None;

                using (SolidBrush crosshair = new SolidBrush(Color.FromArgb(100, Color.Red)))
                {
                    g.FillRectangle(crosshair, new Rectangle(0, 50, 110, 10));
                    g.FillRectangle(crosshair, new Rectangle(50, 0, 10, 110));
                }

                using (Pen borderPen = new Pen(Color.FromArgb(100, Color.Black)))
                {
                    for (int x = 0; x < 11; x++)
                    {
                        g.DrawLine(borderPen, new Point(x * 10, 0), new Point(x * 10, 110));
                    }

                    for (int y = 0; y < 11; y++)
                    {
                        g.DrawLine(borderPen, new Point(0, y * 10), new Point(110, y * 10));
                    }
                }

                g.DrawRectangle(Pens.Black, 0, 0, bmp.Width - 1, bmp.Height - 1);
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