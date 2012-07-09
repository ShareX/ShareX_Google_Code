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

namespace ColorsLib
{
    public class ColorSlider : ColorUserControl
    {
        public ColorSlider()
        {
            Initialize();
        }

        #region Protected Override Methods

        protected override void Initialize()
        {
            this.Name = "ColorSlider";
            this.Size = new Size(30, 260);
            base.Initialize();
        }

        protected override void DrawCrosshair(Graphics g)
        {
            int rectOffset = 3;
            int rectSize = 4;
            g.DrawRectangle(new Pen(Color.Black), new Rectangle(rectOffset, lastPos.Y - rectSize,
                width - rectOffset * 2, rectSize * 2 + 1));
            g.DrawRectangle(new Pen(Color.White), new Rectangle(rectOffset + 1, lastPos.Y - rectSize + 1,
                width - rectOffset * 2 - 2, rectSize * 2 - 1));
        }

        // Hue = 360 -> 0
        protected override void DrawHue()
        {
            Graphics g = Graphics.FromImage(bmp);
            HSB color = new HSB(0.0, 1.0, 1.0);

            for (int i = 0; i < height; i++)
            {
                color.Hue = 1.0 - (double)i / (height - 1);
                g.DrawLine(new Pen(color), 0, i, width, i);
            }
        }

        // Saturation = 100 -> 0
        protected override void DrawSaturation()
        {
            Graphics g = Graphics.FromImage(bmp);
            HSB color = new HSB(SetColor.HSB.Hue, 0.0, SetColor.HSB.Brightness);

            for (int i = 0; i < height; i++)
            {
                color.Saturation = 1.0 - (double)i / (height - 1);
                g.DrawLine(new Pen(color), 0, i, width, i);
            }
        }

        // Brightness = 100 -> 0
        protected override void DrawBrightness()
        {
            Graphics g = Graphics.FromImage(bmp);
            HSB color = new HSB(SetColor.HSB.Hue, SetColor.HSB.Saturation, 0.0);

            for (int i = 0; i < height; i++)
            {
                color.Brightness = 1.0 - (double)i / (height - 1);
                g.DrawLine(new Pen(color), 0, i, width, i);
            }
        }

        // Red = 255 -> 0
        protected override void DrawRed()
        {
            Graphics g = Graphics.FromImage(bmp);
            RGB color = new RGB(0, SetColor.RGB.Green, SetColor.RGB.Blue);

            for (int i = 0; i < height; i++)
            {
                color.Red = 255 - Round(255 * (double)i / (height - 1));
                g.DrawLine(new Pen(color), 0, i, width, i);
            }
        }

        // Green = 255 -> 0
        protected override void DrawGreen()
        {
            Graphics g = Graphics.FromImage(bmp);
            RGB color = new RGB(SetColor.RGB.Red, 0, SetColor.RGB.Blue);

            for (int i = 0; i < height; i++)
            {
                color.Green = 255 - Round(255 * (double)i / (height - 1));
                g.DrawLine(new Pen(color), 0, i, width, i);
            }
        }

        // Blue = 255 -> 0
        protected override void DrawBlue()
        {
            Graphics g = Graphics.FromImage(bmp);
            RGB color = new RGB(SetColor.RGB.Red, SetColor.RGB.Green, 0);

            for (int i = 0; i < height; i++)
            {
                color.Blue = 255 - Round(255 * (double)i / (height - 1));
                g.DrawLine(new Pen(color), 0, i, width, i);
            }
        }

        #endregion Protected Override Methods
    }
}