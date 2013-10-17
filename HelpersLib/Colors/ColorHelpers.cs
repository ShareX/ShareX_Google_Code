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

    public enum DrawStyle
    {
        Hue, Saturation, Brightness, Red, Green, Blue
    }

    public static class ColorHelpers
    {
        public static double CheckColor(double number)
        {
            return GetBetween(number, 0, 1);
        }

        public static int CheckColor(int number)
        {
            return GetBetween(number, 0, 255);
        }

        public static int GetBetween(int number, int min, int max)
        {
            return Math.Max(Math.Min(number, max), min);
        }

        public static double GetBetween(double value, double min, double max)
        {
            return Math.Max(Math.Min(value, max), min);
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
    }
}