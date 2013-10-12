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

using HelpersLib;
using System.ComponentModel;
using System.Drawing;

namespace ImageEffectsLib
{
    public class Reflection : IPluginItem
    {
        public override string Name { get { return "Reflection"; } }

        public override string Description { get { return "Draw reflection bottom of screenshots."; } }

        private int percentage;

        [Description("Reflection height size relative to screenshot height.\nValue need to be between 1 to 100.")]
        public int Percentage
        {
            get
            {
                return percentage;
            }
            set
            {
                percentage = value.Between(1, 100);
            }
        }

        private int transparency;

        [Description("Reflection transparency start from this value to 0.\nValue need to be between 0 to 255.")]
        public int Transparency
        {
            get
            {
                return transparency;
            }
            set
            {
                transparency = value.Between(0, 255);
            }
        }

        private int offset;

        [Description("Reflection position will be start: Screenshot height + Offset")]
        public int Offset
        {
            get
            {
                return offset;
            }
            set
            {
                offset = value;
            }
        }

        private bool skew;

        [Description("Adding skew to reflection from bottom left to bottom right.")]
        public bool Skew
        {
            get
            {
                return skew;
            }
            set
            {
                skew = value;
            }
        }

        private int skewSize;

        [Description("How much pixel skew left to right.")]
        public int SkewSize
        {
            get
            {
                return skewSize;
            }
            set
            {
                skewSize = value;
            }
        }

        public Reflection()
        {
            percentage = 20;
            transparency = 255;
            offset = 0;
            skew = true;
            skewSize = 25;
        }

        public override Image ApplyEffect(Image img)
        {
            return ImageHelpers.DrawReflection(img, percentage, transparency, offset, skew, skewSize);
        }
    }
}