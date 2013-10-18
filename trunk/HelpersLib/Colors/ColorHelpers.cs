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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HelpersLib
{
    public delegate void ColorEventHandler(object sender, ColorEventArgs e);

    public class ColorEventArgs : EventArgs
    {
        public ColorEventArgs(MyColor color, DrawStyle drawStyle, bool updateControl)
        {
            this.Color = color;
            this.DrawStyle = drawStyle;
            this.UpdateControl = updateControl;
        }

        public ColorEventArgs(MyColor color, DrawStyle drawStyle)
        {
            this.Color = color;
            this.DrawStyle = drawStyle;
            this.UpdateControl = true;
        }

        public MyColor Color;
        public DrawStyle DrawStyle;
        public bool UpdateControl;
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

        public static string ToShortString(double number)
        {
            return number.ToString("0.####");
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
                return ColorHelpers.HexToColor(color);
            }
            else if (color.Contains(','))
            {
                int[] colors = color.Split(',').Select(x => int.Parse(x)).ToArray();

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

        public static int ColorToDecimal(Color color)
        {
            return HexToDecimal(ColorToHex(color));
        }

        public static Color HexToColor(string hex)
        {
            if (hex.StartsWith("#"))
            {
                hex = hex.Substring(1);
            }

            string a = string.Empty;

            if (hex.Length == 8)
            {
                a = hex.Substring(0, 2);
                hex = hex.Substring(2);
            }

            string r = hex.Substring(0, 2);
            string g = hex.Substring(2, 2);
            string b = hex.Substring(4, 2);

            if (string.IsNullOrEmpty(a))
            {
                return Color.FromArgb(HexToDecimal(r), HexToDecimal(g), HexToDecimal(b));
            }
            else
            {
                return Color.FromArgb(HexToDecimal(a), HexToDecimal(r), HexToDecimal(g), HexToDecimal(b));
            }
        }

        public static int HexToDecimal(string hex)
        {
            //return int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return Convert.ToInt32(hex, 16);
        }

        public static string DecimalToHex(int dec)
        {
            return dec.ToString("X6");
        }

        public static Color DecimalToColor(int dec)
        {
            return Color.FromArgb(dec & 0xFF, (dec & 0xff00) / 256, dec / 65536);
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