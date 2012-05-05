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

using System.Drawing;

namespace ScreenCapture
{
    public class NodeObject : DrawableObject
    {
        private PointF position;

        public PointF Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                Rectangle = new RectangleF(position.X - (NodeSize - 1) / 2, position.Y - (NodeSize - 1) / 2, NodeSize, NodeSize);
            }
        }

        public float NodeSize { get; set; }

        private Pen borderPen;
        private Brush backgroundBrush;

        public NodeObject(Pen borderPen, Brush backgroundBrush, float x = 0, float y = 0)
        {
            this.borderPen = borderPen;
            this.backgroundBrush = backgroundBrush;
            NodeSize = 13;
            Position = new PointF(x, y);
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.White, Rectangle.X + 1, Rectangle.Y + 1, Rectangle.Width - 3, Rectangle.Height - 3);
            g.DrawRectangle(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width - 1, Rectangle.Height - 1);
        }
    }
}