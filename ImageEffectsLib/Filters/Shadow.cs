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
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageEffectsLib
{
    public class Shadow : IPluginItem
    {
        public override string Name { get { return "Shadow"; } }

        public override string Description { get { return "Shadow"; } }

        private int radius;

        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value.Between(0, 25);
            }
        }

        private int offsetX;

        public int OffsetX
        {
            get
            {
                return offsetX;
            }
            set
            {
                offsetX = value;
            }
        }

        private int offsetY;

        public int OffsetY
        {
            get
            {
                return offsetY;
            }
            set
            {
                offsetY = value;
            }
        }

        private int transparency;

        public int Transparency
        {
            get
            {
                return transparency;
            }
            set
            {
                transparency = value;
            }
        }

        public Shadow()
        {
            radius = 5;
            offsetX = 3;
            offsetY = 3;
            transparency = 50;
        }

        public override Image ApplyEffect(Image img)
        {
            ColorMatrix matrix = ColorMatrixManager.Identity();
            matrix[4, 0] = matrix[4, 1] = matrix[4, 2] = -1.0f;

            using (Image blackImage = ColorMatrixManager.Apply(matrix, img))
            using (Image shadow = Blur.ApplyBlur((Bitmap)blackImage, radius, true))
            using (Image shadow2 = ColorMatrixManager.Apply(ColorMatrixManager.Alpha(transparency, 0), shadow))
            {
                Bitmap result = new Bitmap(shadow.Width + Math.Abs(offsetX), shadow.Height + Math.Abs(offsetY));

                using (Graphics g = Graphics.FromImage(result))
                {
                    Rectangle shadowRect = new Rectangle(0, 0, shadow.Width, shadow.Height);
                    Rectangle imageRect = new Rectangle(radius, radius, img.Width, img.Height);

                    if (offsetX < 0)
                    {
                        imageRect.X += -offsetX + Math.Min(radius, -offsetX);
                    }
                    else
                    {
                        imageRect.X = Math.Max(0, radius - offsetX);
                        shadowRect.X = offsetX;
                    }

                    if (offsetY < 0)
                    {
                        imageRect.Y += -offsetY + Math.Min(radius, -offsetX);
                    }
                    else
                    {
                        imageRect.Y = Math.Max(0, radius - offsetY);
                        shadowRect.Y = offsetY;
                    }

                    g.DrawImage(shadow2, shadowRect);
                    g.DrawImage(img, imageRect);
                }

                return result;
            }
        }
    }
}