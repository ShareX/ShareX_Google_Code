#region License Information (GPL v3)

/*
    ShareX - A program that allows to you take screenshots and share any file type
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
using System.Windows.Forms;
using HelpersLib;

namespace ScreenCapture
{
    public class FreeHandRegion : Surface
    {
        private NodeObject lastNode;
        private List<Point> points;
        private bool isAreaCreated;
        private Rectangle currentArea;

        public FreeHandRegion(Image backgroundImage = null)
            : base(backgroundImage)
        {
            points = new List<Point>(128);
            regionFillPath = new GraphicsPath();

            lastNode = new NodeObject(borderPen, nodeBackgroundBrush);
            DrawableObjects.Add(lastNode);
        }

        protected override void Update()
        {
            base.Update();

            if (InputManager.IsMousePressed(MouseButtons.Right))
            {
                if (isAreaCreated)
                {
                    isAreaCreated = false;
                    regionFillPath.Reset();
                    HideNodes();
                    points.Clear();
                }
                else
                {
                    Close(false);
                }
            }

            if (Config.QuickCrop && isAreaCreated && InputManager.IsMouseReleased(MouseButtons.Left))
            {
                Close(true);
            }

            if (!isAreaCreated && InputManager.IsMouseDown(MouseButtons.Left))
            {
                lastNode.Visible = true;
                lastNode.IsDragging = true;
                isAreaCreated = true;
            }

            if (lastNode.Visible && lastNode.IsDragging)
            {
                lastNode.Position = InputManager.MousePosition0Based;

                if (InputManager.IsMouseMoved)
                {
                    points.Add(InputManager.MousePosition0Based);

                    if (points.Count > 1)
                    {
                        regionFillPath.AddLine(InputManager.PreviousMousePosition0Based, InputManager.MousePosition0Based);
                    }
                }
            }

            if (points.Count > 2)
            {
                RectangleF rect = regionFillPath.GetBounds();
                currentArea = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width + 1, (int)rect.Height + 1);
            }
        }

        protected override void Draw(Graphics g)
        {
            if (points.Count > 2)
            {
                using (Region region = new Region(regionFillPath))
                {
                    g.ExcludeClip(region);
                    g.FillRectangle(shadowBrush, 0, 0, Width, Height);
                    g.ResetClip();
                }

                g.DrawPath(borderPen, regionFillPath);
                g.DrawLine(borderPen, points[0], points[points.Count - 1]);
                g.DrawRectangleProper(borderPen, currentArea);
            }
            else
            {
                g.FillRectangle(shadowBrush, 0, 0, Width, Height);
            }

            base.Draw(g);
        }
    }
}