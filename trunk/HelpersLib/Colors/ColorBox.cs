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

using System.Drawing;
using System.Drawing.Drawing2D;

namespace HelpersLib
{
    public class ColorBox : ColorUserControl
    {
        public ColorBox()
        {
            Initialize();
        }

        #region Protected Override Methods

        protected override void Initialize()
        {
            this.Name = "ColorBox";
            this.Size = new Size(260, 260);
            base.Initialize();
        }

        protected override void DrawCrosshair(Graphics g)
        {
            DrawEllipse(g, 6, Color.Black);
            DrawEllipse(g, 5, Color.White);
        }

        // Saturation = 0 -> 100
        // Brightness = 100 -> 0
        protected override void DrawHue()
        {
            Graphics g = Graphics.FromImage(bmp);
            HSB start = new HSB(SetColor.HSB.Hue, 0.0, 0.0);
            HSB end = new HSB(SetColor.HSB.Hue, 1.0, 0.0);

            for (int i = 0; i < height; i++)
            {
                start.Brightness = end.Brightness = 1.0 - (double)i / (height - 1);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, width, 1),
                    start.ToColor(), end.ToColor(), 0, false);
                g.FillRectangle(brush, new Rectangle(0, i, width, 1));
            }
        }

        // Hue = 0 -> 360
        // Brightness = 100 -> 0
        protected override void DrawSaturation()
        {
            Graphics g = Graphics.FromImage(bmp);
            HSB start = new HSB(0.0, SetColor.HSB.Saturation, 1.0);
            HSB end = new HSB(0.0, SetColor.HSB.Saturation, 0.0);

            for (int i = 0; i < width; i++)
            {
                start.Hue = end.Hue = (double)i / (height - 1);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, 1, height),
                    start.ToColor(), end.ToColor(), 90, false);
                g.FillRectangle(brush, new Rectangle(i, 0, 1, height));
            }
        }

        // Hue = 0 -> 360
        // Saturation = 100 -> 0
        protected override void DrawBrightness()
        {
            Graphics g = Graphics.FromImage(bmp);
            HSB start = new HSB(0.0, 1.0, SetColor.HSB.Brightness);
            HSB end = new HSB(0.0, 0.0, SetColor.HSB.Brightness);

            for (int i = 0; i < width; i++)
            {
                start.Hue = end.Hue = (double)i / (height - 1);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, 1, height),
                    start.ToColor(), end.ToColor(), 90, false);
                g.FillRectangle(brush, new Rectangle(i, 0, 1, height));
            }
        }

        // Blue = 0 -> 255
        // Green = 255 -> 0
        protected override void DrawRed()
        {
            Graphics g = Graphics.FromImage(bmp);
            RGB start = new RGB(SetColor.RGB.Red, 0, 0);
            RGB end = new RGB(SetColor.RGB.Red, 0, 255);

            for (int i = 0; i < height; i++)
            {
                start.Green = end.Green = Round(255 - (255 * (double)i / (height - 1)));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, width, 1),
                  start.ToColor(), end.ToColor(), 0, false);
                g.FillRectangle(brush, new Rectangle(0, i, width, 1));
            }
        }

        // Blue = 0 -> 255
        // Red = 255 -> 0
        protected override void DrawGreen()
        {
            Graphics g = Graphics.FromImage(bmp);
            RGB start = new RGB(0, SetColor.RGB.Green, 0);
            RGB end = new RGB(0, SetColor.RGB.Green, 255);

            for (int i = 0; i < height; i++)
            {
                start.Red = end.Red = Round(255 - (255 * (double)i / (height - 1)));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, width, 1),
                  start.ToColor(), end.ToColor(), 0, false);
                g.FillRectangle(brush, new Rectangle(0, i, width, 1));
            }
        }

        // Red = 0 -> 255
        // Green = 255 -> 0
        protected override void DrawBlue()
        {
            Graphics g = Graphics.FromImage(bmp);
            RGB start = new RGB(0, 0, SetColor.RGB.Blue);
            RGB end = new RGB(255, 0, SetColor.RGB.Blue);

            for (int i = 0; i < height; i++)
            {
                start.Green = end.Green = Round(255 - (255 * (double)i / (height - 1)));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, width, 1),
                  start.ToColor(), end.ToColor(), 0, false);
                g.FillRectangle(brush, new Rectangle(0, i, width, 1));
            }
        }

        #endregion Protected Override Methods
    }
}