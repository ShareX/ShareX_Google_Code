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

namespace HelpersLib
{
    #region Public Structs

    public struct MyColor
    {
        public RGBA RGBA;
        public HSB HSB;
        public CMYK CMYK;

        public bool IsTransparent
        {
            get
            {
                return RGBA.Alpha < 255;
            }
        }

        public MyColor(Color color)
        {
            RGBA = color;
            HSB = color;
            CMYK = color;
        }

        public static implicit operator MyColor(Color color)
        {
            return new MyColor(color);
        }

        public static implicit operator Color(MyColor color)
        {
            return color.RGBA;
        }

        public static bool operator ==(MyColor left, MyColor right)
        {
            return (left.RGBA == right.RGBA) && (left.HSB == right.HSB) && (left.CMYK == right.CMYK);
        }

        public static bool operator !=(MyColor left, MyColor right)
        {
            return !(left == right);
        }

        public void RGBUpdate()
        {
            HSB = RGBA;
            CMYK = RGBA;
        }

        public void HSBUpdate()
        {
            RGBA = HSB;
            CMYK = HSB;
        }

        public void CMYKUpdate()
        {
            RGBA = CMYK;
            HSB = CMYK;
        }

        public override string ToString()
        {
            return String.Format("{0}\r\n{1}\r\n{2}", RGBA, HSB, CMYK);
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

    public struct RGBA
    {
        private int red, green, blue, alpha;

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

        public int Alpha
        {
            get { return alpha; }
            set { alpha = ColorHelpers.CheckColor(value); }
        }

        public RGBA(int red, int green, int blue, int alpha = 255)
            : this()
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public RGBA(Color color)
            : this(color.R, color.G, color.B, color.A)
        {
        }

        public static implicit operator RGBA(Color color)
        {
            return new RGBA(color);
        }

        public static implicit operator Color(RGBA color)
        {
            return color.ToColor();
        }

        public static implicit operator HSB(RGBA color)
        {
            return color.ToHSB();
        }

        public static implicit operator CMYK(RGBA color)
        {
            return color.ToCMYK();
        }

        public static bool operator ==(RGBA left, RGBA right)
        {
            return (left.Red == right.Red) && (left.Green == right.Green) && (left.Blue == right.Blue) && (left.Alpha == right.Alpha);
        }

        public static bool operator !=(RGBA left, RGBA right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return String.Format("Red: {0}, Green: {1}, Blue: {2}, Alpha: {3}", Red, Green, Blue, Alpha);
        }

        public Color ToColor()
        {
            return Color.FromArgb(Alpha, Red, Green, Blue);
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

            hsb.Alpha = color.A;

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

            cmyk.Alpha = color.A;

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
        private int alpha;

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

        public int Alpha
        {
            get { return alpha; }
            set { alpha = ColorHelpers.CheckColor(value); }
        }

        public HSB(double hue, double saturation, double brightness, int alpha = 255)
            : this()
        {
            Hue = hue;
            Saturation = saturation;
            Brightness = brightness;
            Alpha = alpha;
        }

        public HSB(int hue, int saturation, int brightness, int alpha = 255)
            : this()
        {
            Hue360 = hue;
            Saturation100 = saturation;
            Brightness100 = brightness;
            Alpha = alpha;
        }

        public HSB(Color color)
        {
            this = RGBA.ToHSB(color);
        }

        public static implicit operator HSB(Color color)
        {
            return RGBA.ToHSB(color);
        }

        public static implicit operator Color(HSB color)
        {
            return color.ToColor();
        }

        public static implicit operator RGBA(HSB color)
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
                return Color.FromArgb(hsb.Alpha, Max, Mid, Min);
            }
            if (hsb.Hue <= (double)1 / 3)
            {
                Mid = ColorHelpers.Round(-((hsb.Hue - (double)1 / 6) * q) * 1530 + Max);
                return Color.FromArgb(hsb.Alpha, Mid, Max, Min);
            }
            if (hsb.Hue <= 0.5)
            {
                Mid = ColorHelpers.Round(((hsb.Hue - (double)1 / 3) * q) * 1530 + Min);
                return Color.FromArgb(hsb.Alpha, Min, Max, Mid);
            }
            if (hsb.Hue <= (double)2 / 3)
            {
                Mid = ColorHelpers.Round(-((hsb.Hue - 0.5) * q) * 1530 + Max);
                return Color.FromArgb(hsb.Alpha, Min, Mid, Max);
            }
            if (hsb.Hue <= (double)5 / 6)
            {
                Mid = ColorHelpers.Round(((hsb.Hue - (double)2 / 3) * q) * 1530 + Min);
                return Color.FromArgb(hsb.Alpha, Mid, Min, Max);
            }
            if (hsb.Hue <= 1.0)
            {
                Mid = ColorHelpers.Round(-((hsb.Hue - (double)5 / 6) * q) * 1530 + Max);
                return Color.FromArgb(hsb.Alpha, Max, Min, Mid);
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
        private int alpha;

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

        public int Alpha
        {
            get { return alpha; }
            set { alpha = ColorHelpers.CheckColor(value); }
        }

        public CMYK(double cyan, double magenta, double yellow, double key, int alpha = 255)
            : this()
        {
            Cyan = cyan;
            Magenta = magenta;
            Yellow = yellow;
            Key = key;
            Alpha = alpha;
        }

        public CMYK(int cyan, int magenta, int yellow, int key, int alpha = 255)
            : this()
        {
            Cyan100 = cyan;
            Magenta100 = magenta;
            Yellow100 = yellow;
            Key100 = key;
            Alpha = alpha;
        }

        public CMYK(Color color)
        {
            this = RGBA.ToCMYK(color);
        }

        public static implicit operator CMYK(Color color)
        {
            return RGBA.ToCMYK(color);
        }

        public static implicit operator Color(CMYK color)
        {
            return color.ToColor();
        }

        public static implicit operator RGBA(CMYK color)
        {
            return color.ToColor();
        }

        public static implicit operator HSB(CMYK color)
        {
            return color.ToColor();
        }

        public static bool operator ==(CMYK left, CMYK right)
        {
            return (left.Cyan == right.Cyan) && (left.Magenta == right.Magenta) && (left.Yellow == right.Yellow) && (left.Key == right.Key);
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

            return Color.FromArgb(cmyk.Alpha, red, green, blue);
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
}