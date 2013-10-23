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

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace HelpersLib
{
    public delegate void ColorEventHandler(object sender, ColorEventArgs e);

    public class ColorEventArgs : EventArgs
    {
        public ColorEventArgs(MyColor color, ColorType colorType)
        {
            Color = color;
            ColorType = colorType;
        }

        public ColorEventArgs(MyColor color, DrawStyle drawStyle)
        {
            Color = color;
            DrawStyle = drawStyle;
        }

        public MyColor Color;
        public ColorType ColorType;
        public DrawStyle DrawStyle;
    }

    public static class ColorHelpers
    {
        public static double CheckColor(double number)
        {
            return number.Between(0, 1);
        }

        public static int CheckColor(int number)
        {
            return number.Between(0, 255);
        }

        public static int Round(double val)
        {
            int ret_val = (int)val;

            int temp = (int)(val * 100);

            if ((temp % 100) >= 50)
                ret_val += 1;

            return ret_val;
        }

        public static Color Mix(List<Color> colors)
        {
            int a = 0;
            int r = 0;
            int g = 0;
            int b = 0;
            int count = 0;

            foreach (Color color in colors)
            {
                if (!color.Equals(Color.Empty))
                {
                    a += color.A;
                    r += color.R;
                    g += color.G;
                    b += color.B;
                    count++;
                }
            }

            if (count == 0)
            {
                return Color.Empty;
            }

            return Color.FromArgb(a / count, r / count, g / count, b / count);
        }

        public static Color ParseColor(string color)
        {
            if (color.StartsWith("#"))
            {
                return HexToColor(color);
            }

            if (color.Contains(','))
            {
                int[] colors = color.Split(',').Select(int.Parse).ToArray();

                if (colors.Length == 3)
                {
                    return Color.FromArgb(colors[0], colors[1], colors[2]);
                }
                if (colors.Length == 4)
                {
                    return Color.FromArgb(colors[0], colors[1], colors[2], colors[3]);
                }
            }

            return Color.FromName(color);
        }

        public static string ColorToHex(Color color)
        {
            return string.Format("{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        public static Color HexToColor(string hex)
        {
            if (string.IsNullOrEmpty(hex))
            {
                return Color.Empty;
            }

            if (hex[0] == '#')
            {
                hex = hex.Remove(0, 1);
            }

            if (hex.Length != 8 && hex.Length != 6)
            {
                return Color.Empty;
            }

            if (hex.Length == 6)
            {
                hex += "FF";
            }

            int r = HexToDecimal(hex.Substring(0, 2));
            int g = HexToDecimal(hex.Substring(2, 2));
            int b = HexToDecimal(hex.Substring(4, 2));
            int a = HexToDecimal(hex.Substring(6, 2));

            return Color.FromArgb(a, r, g, b);
        }

        public static int HexToDecimal(string hex)
        {
            return Convert.ToInt32(hex, 16);
        }

        public static string IntRGBToHex(int dec)
        {
            return dec.ToString("X6");
        }

        public static int ColorToIntRGB(Color color)
        {
            return color.R << 16 | color.G << 8 | color.B;
        }

        public static int ColorToIntRGBA(Color color)
        {
            return color.R << 24 | color.G << 16 | color.B << 8 | color.A;
        }

        public static int ColorToIntARGB(Color color)
        {
            return color.A << 24 | color.R << 16 | color.G << 8 | color.B;
        }

        public static Color IntRGBToColor(int dec)
        {
            return Color.FromArgb((dec >> 16) & 0xFF, (dec >> 8) & 0xFF, dec & 0xFF);
        }

        public static Color IntRGBAToColor(int dec)
        {
            return Color.FromArgb(dec & 0xFF, (dec >> 24) & 0xFF, (dec >> 16) & 0xFF, (dec >> 8) & 0xFF);
        }

        public static Color IntARGBToColor(int dec)
        {
            return Color.FromArgb((dec >> 24) & 0xFF, (dec >> 16) & 0xFF, (dec >> 8) & 0xFF, dec & 0xFF);
        }

        public static Color SetHue(Color c, double Hue)
        {
            HSB hsb = RGBA.ToHSB(c);
            hsb.Hue = Hue;
            return hsb.ToColor();
        }

        public static Color ModifyHue(Color c, double Hue)
        {
            HSB hsb = RGBA.ToHSB(c);
            hsb.Hue *= Hue;
            return hsb.ToColor();
        }

        public static Color SetSaturation(Color c, double Saturation)
        {
            HSB hsb = RGBA.ToHSB(c);
            hsb.Saturation = Saturation;
            return hsb.ToColor();
        }

        public static Color ModifySaturation(Color c, double Saturation)
        {
            HSB hsb = RGBA.ToHSB(c);
            hsb.Saturation *= Saturation;
            return hsb.ToColor();
        }

        public static Color SetBrightness(Color c, double brightness)
        {
            HSB hsb = RGBA.ToHSB(c);
            hsb.Brightness = brightness;
            return hsb.ToColor();
        }

        public static Color ModifyBrightness(Color c, double brightness)
        {
            HSB hsb = RGBA.ToHSB(c);
            hsb.Brightness *= brightness;
            return hsb.ToColor();
        }

        public static Color RandomColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }
    }
}