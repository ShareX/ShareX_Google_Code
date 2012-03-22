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

namespace HelpersLib
{
    public class XFont
    {
        public string FontFamily { get; set; }

        public float Size { get; set; }

        public FontStyle Style { get; set; }

        public GraphicsUnit GraphicsUnit { get; set; }

        public XFont() { }

        public XFont(Font font)
        {
            Init(font);
        }

        public XFont(string fontName, float fontSize, FontStyle fontStyle = FontStyle.Regular)
        {
            Font font = CreateFont(fontName, fontSize, fontStyle);
            Init(font);
        }

        private void Init(Font font)
        {
            FontFamily = font.FontFamily.Name;
            GraphicsUnit = font.Unit;
            Size = font.Size;
            Style = font.Style;
        }

        private Font CreateFont(string fontName, float fontSize, FontStyle fontStyle)
        {
            try
            {
                return new Font(fontName, fontSize, fontStyle);
            }
            catch
            {
                return new Font(SystemFonts.DefaultFont.FontFamily, fontSize, fontStyle);
            }
        }

        public static implicit operator Font(XFont font)
        {
            return new Font(font.FontFamily, font.Size, font.Style, font.GraphicsUnit);
        }

        public static implicit operator XFont(Font font)
        {
            return new XFont(font);
        }
    }

    public class XColor
    {
        public int Argb { get; set; }

        public XColor() { }

        public XColor(Color color)
        {
            Argb = color.ToArgb();
        }

        public XColor(byte a, byte r, byte g, byte b)
        {
            Argb = (a << 24) | (r << 16) | (g << 8) | b;
        }

        public static implicit operator Color(XColor color)
        {
            return Color.FromArgb(color.Argb);
        }

        public static implicit operator XColor(Color color)
        {
            return new XColor(color);
        }
    }
}