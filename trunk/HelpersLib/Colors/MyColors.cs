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
using System.Drawing;
using System.Linq;

namespace HelpersLib
{
    #region Public Structs

    public struct MyColor
    {
        public RGB RGB;
        public HSB HSB;
        public CMYK CMYK;

        public MyColor(Color color)
        {
            this.RGB = color;
            this.HSB = color;
            this.CMYK = color;
        }

        public static implicit operator MyColor(Color color)
        {
            return new MyColor(color);
        }

        public static implicit operator Color(MyColor color)
        {
            return color.RGB;
        }

        public static bool operator ==(MyColor left, MyColor right)
        {
            return (left.RGB == right.RGB) && (left.HSB == right.HSB) && (left.CMYK == right.CMYK);
        }

        public static bool operator !=(MyColor left, MyColor right)
        {
            return !(left == right);
        }

        public void RGBUpdate()
        {
            this.HSB = this.RGB;
            this.CMYK = this.RGB;
        }

        public void HSBUpdate()
        {
            this.RGB = this.HSB;
            this.CMYK = this.HSB;
        }

        public void CMYKUpdate()
        {
            this.RGB = this.CMYK;
            this.HSB = this.CMYK;
        }

        public override string ToString()
        {
            return String.Format("{0}\r\n{1}\r\n{2}", RGB, HSB, CMYK);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

    public struct RGB
    {
        private int red;
        private int green;
        private int blue;

        public int Red
        {
            get { return red; }
            set { red = ColorHelpers.CheckColor(value); }
        }

        public int Green
        {
            get { return green; }
            set { green = ColorHelpers.CheckColor(value); }
        }

        public int Blue
        {
            get { return blue; }
            set { blue = ColorHelpers.CheckColor(value); }
        }

        public RGB(int red, int green, int blue)
            : this()
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public RGB(Color color)
        {
            this = new RGB(color.R, color.G, color.B);
        }

        public static implicit operator RGB(Color color)
        {
            return new RGB(color.R, color.G, color.B);
        }

        public static implicit operator Color(RGB color)
        {
            return color.ToColor();
        }

        public static implicit operator HSB(RGB color)
        {
            return color.ToHSB();
        }

        public static implicit operator CMYK(RGB color)
        {
            return color.ToCMYK();
        }

        public static bool operator ==(RGB left, RGB right)
        {
            return (left.Red == right.Red) && (left.Green == right.Green) && (left.Blue == right.Blue);
        }

        public static bool operator !=(RGB left, RGB right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return String.Format("Red: {0}, Green: {1}, Blue: {2}", Red, Green, Blue);
        }

        public static Color ToColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

        public Color ToColor()
        {
            return ToColor(Red, Green, Blue);
        }

        public static HSB ToHSB(Color color)
        {
            HSB hsb = new HSB();

            int Max, Min;

            if (color.R > color.G) { Max = color.R; Min = color.G; }
            else { Max = color.G; Min = color.R; }
            if (color.B > Max) Max = color.B;
            else if (color.B < Min) Min = color.B;

            int Diff = Max - Min;

            hsb.Brightness = (double)Max / 255;

            if (Max == 0) hsb.Saturation = 0;
            else hsb.Saturation = (double)Diff / Max;

            double q;
            if (Diff == 0) q = 0;
            else q = (double)60 / Diff;

            if (Max == color.R)
            {
                if (color.G < color.B) hsb.Hue = (360 + q * (color.G - color.B)) / 360;
                else hsb.Hue = q * (color.G - color.B) / 360;
            }
            else if (Max == color.G) hsb.Hue = (120 + q * (color.B - color.R)) / 360;
            else if (Max == color.B) hsb.Hue = (240 + q * (color.R - color.G)) / 360;
            else hsb.Hue = 0.0;

            return hsb;
        }

        public HSB ToHSB()
        {
            return ToHSB(this);
        }

        public static CMYK ToCMYK(Color color)
        {
            CMYK cmyk = new CMYK();
            double low = 1.0;

            cmyk.Cyan = (double)(255 - color.R) / 255;
            if (low > cmyk.Cyan)
                low = cmyk.Cyan;

            cmyk.Magenta = (double)(255 - color.G) / 255;
            if (low > cmyk.Magenta)
                low = cmyk.Magenta;

            cmyk.Yellow = (double)(255 - color.B) / 255;
            if (low > cmyk.Yellow)
                low = cmyk.Yellow;

            if (low > 0.0)
            {
                cmyk.Key = low;
            }

            return cmyk;
        }

        public CMYK ToCMYK()
        {
            return ToCMYK(this);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

    public struct HSB
    {
        private double hue;
        private double saturation;
        private double brightness;

        public double Hue
        {
            get { return hue; }
            set { hue = ColorHelpers.CheckColor(value); }
        }

        public double Hue360
        {
            get { return hue * 360; }
            set { hue = ColorHelpers.CheckColor(value / 360); }
        }

        public double Saturation
        {
            get { return saturation; }
            set { saturation = ColorHelpers.CheckColor(value); }
        }

        public double Saturation100
        {
            get { return saturation * 100; }
            set { saturation = ColorHelpers.CheckColor(value / 100); }
        }

        public double Brightness
        {
            get { return brightness; }
            set { brightness = ColorHelpers.CheckColor(value); }
        }

        public double Brightness100
        {
            get { return brightness * 100; }
            set { brightness = ColorHelpers.CheckColor(value / 100); }
        }

        public HSB(double hue, double saturation, double brightness)
            : this()
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Brightness = brightness;
        }

        public HSB(int hue, int saturation, int brightness)
            : this()
        {
            this.Hue360 = hue;
            this.Saturation100 = saturation;
            this.Brightness100 = brightness;
        }

        public HSB(Color color)
        {
            this = RGB.ToHSB(color);
        }

        public static implicit operator HSB(Color color)
        {
            return RGB.ToHSB(color);
        }

        public static implicit operator Color(HSB color)
        {
            return color.ToColor();
        }

        public static implicit operator RGB(HSB color)
        {
            return color.ToColor();
        }

        public static implicit operator CMYK(HSB color)
        {
            return color.ToColor();
        }

        public static bool operator ==(HSB left, HSB right)
        {
            return (left.Hue == right.Hue) && (left.Saturation == right.Saturation) && (left.Brightness == right.Brightness);
        }

        public static bool operator !=(HSB left, HSB right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return String.Format("Hue: {0}, Saturation: {1}, Brightness: {2}", ColorHelpers.Round(Hue360),
              ColorHelpers.Round(Saturation100), ColorHelpers.Round(Brightness100));
        }

        public static Color ToColor(HSB hsb)
        {
            int Mid;

            int Max = ColorHelpers.Round(hsb.Brightness * 255);
            int Min = ColorHelpers.Round((1.0 - hsb.Saturation) * (hsb.Brightness / 1.0) * 255);
            double q = (double)(Max - Min) / 255;

            if (hsb.Hue >= 0 && hsb.Hue <= (double)1 / 6)
            {
                Mid = ColorHelpers.Round(((hsb.Hue - 0) * q) * 1530 + Min);
                return Color.FromArgb(Max, Mid, Min);
            }
            if (hsb.Hue <= (double)1 / 3)
            {
                Mid = ColorHelpers.Round(-((hsb.Hue - (double)1 / 6) * q) * 1530 + Max);
                return Color.FromArgb(Mid, Max, Min);
            }
            if (hsb.Hue <= 0.5)
            {
                Mid = ColorHelpers.Round(((hsb.Hue - (double)1 / 3) * q) * 1530 + Min);
                return Color.FromArgb(Min, Max, Mid);
            }
            if (hsb.Hue <= (double)2 / 3)
            {
                Mid = ColorHelpers.Round(-((hsb.Hue - 0.5) * q) * 1530 + Max);
                return Color.FromArgb(Min, Mid, Max);
            }
            if (hsb.Hue <= (double)5 / 6)
            {
                Mid = ColorHelpers.Round(((hsb.Hue - (double)2 / 3) * q) * 1530 + Min);
                return Color.FromArgb(Mid, Min, Max);
            }
            if (hsb.Hue <= 1.0)
            {
                Mid = ColorHelpers.Round(-((hsb.Hue - (double)5 / 6) * q) * 1530 + Max);
                return Color.FromArgb(Max, Min, Mid);
            }
            return Color.FromArgb(0, 0, 0);
        }

        public static Color ToColor(double hue, double saturation, double brightness)
        {
            return ToColor(new HSB(hue, saturation, brightness));
        }

        public Color ToColor()
        {
            return ToColor(this);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

    public struct CMYK
    {
        private double cyan;
        private double magenta;
        private double yellow;
        private double key;

        public double Cyan
        {
            get { return cyan; }
            set { cyan = ColorHelpers.CheckColor(value); }
        }

        public double Cyan100
        {
            get { return cyan * 100; }
            set { cyan = ColorHelpers.CheckColor(value / 100); }
        }

        public double Magenta
        {
            get { return magenta; }
            set { magenta = ColorHelpers.CheckColor(value); }
        }

        public double Magenta100
        {
            get { return magenta * 100; }
            set { magenta = ColorHelpers.CheckColor(value / 100); }
        }

        public double Yellow
        {
            get { return yellow; }
            set { yellow = ColorHelpers.CheckColor(value); }
        }

        public double Yellow100
        {
            get { return yellow * 100; }
            set { yellow = ColorHelpers.CheckColor(value / 100); }
        }

        public double Key
        {
            get { return key; }
            set { key = ColorHelpers.CheckColor(value); }
        }

        public double Key100
        {
            get { return key * 100; }
            set { key = ColorHelpers.CheckColor(value / 100); }
        }

        public CMYK(double cyan, double magenta, double yellow, double key)
            : this()
        {
            this.Cyan = cyan;
            this.Magenta = magenta;
            this.Yellow = yellow;
            this.Key = key;
        }

        public CMYK(int cyan, int magenta, int yellow, int key)
            : this()
        {
            this.Cyan100 = cyan;
            this.Magenta100 = magenta;
            this.Yellow100 = yellow;
            this.Key100 = key;
        }

        public CMYK(Color color)
        {
            this = RGB.ToCMYK(color);
        }

        public static implicit operator CMYK(Color color)
        {
            return RGB.ToCMYK(color);
        }

        public static implicit operator Color(CMYK color)
        {
            return color.ToColor();
        }

        public static implicit operator RGB(CMYK color)
        {
            return color.ToColor();
        }

        public static implicit operator HSB(CMYK color)
        {
            return color.ToColor();
        }

        public static bool operator ==(CMYK left, CMYK right)
        {
            return (left.Cyan == right.Cyan) && (left.Magenta == right.Magenta) && (left.Yellow == right.Yellow) &&
                (left.Key == right.Key);
        }

        public static bool operator !=(CMYK left, CMYK right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return String.Format("Cyan: {0}, Magenta: {1}, Yellow: {2}, Key: {3}", ColorHelpers.Round(Cyan100),
              ColorHelpers.Round(Magenta100), ColorHelpers.Round(Yellow100), ColorHelpers.Round(Key100));
        }

        public static Color ToColor(CMYK cmyk)
        {
            int red = ColorHelpers.Round(255 - (255 * cmyk.Cyan));
            int green = ColorHelpers.Round(255 - (255 * cmyk.Magenta));
            int blue = ColorHelpers.Round(255 - (255 * cmyk.Yellow));

            return Color.FromArgb(red, green, blue);
        }

        public static Color ToColor(double cyan, double magenta, double yellow, double key)
        {
            return ToColor(new CMYK(cyan, magenta, yellow, key));
        }

        public Color ToColor()
        {
            return ToColor(this);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

    #endregion Public Structs

    public static class MyColors
    {
        public static Color ParseColor(string color)
        {
            if (color.StartsWith("#"))
            {
                return MyColors.HexToColor(color);
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
            HSB hsb = RGB.ToHSB(c);
            hsb.Hue = Hue;
            return hsb.ToColor();
        }

        public static Color ModifyHue(Color c, double Hue)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Hue *= Hue;
            return hsb.ToColor();
        }

        public static Color SetSaturation(Color c, double Saturation)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Saturation = Saturation;
            return hsb.ToColor();
        }

        public static Color ModifySaturation(Color c, double Saturation)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Saturation *= Saturation;
            return hsb.ToColor();
        }

        public static Color SetBrightness(Color c, double brightness)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Brightness = brightness;
            return hsb.ToColor();
        }

        public static Color ModifyBrightness(Color c, double brightness)
        {
            HSB hsb = RGB.ToHSB(c);
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