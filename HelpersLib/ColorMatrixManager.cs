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

namespace HelpersLib
{
    public static class ColorMatrixManager
    {
        /*
        private const float rw = 0.3086f;
        private const float gw = 0.6094f;
        private const float bw = 0.0820f;
        */

        private const float rw = 0.212671f;
        private const float gw = 0.715160f;
        private const float bw = 0.072169f;

        public static Image Apply(this ColorMatrix matrix, Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(bmp))
            using (ImageAttributes imgattr = new ImageAttributes())
            {
                imgattr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgattr);
            }

            return bmp;
        }

        public static ColorMatrix IdentityMatrix
        {
            get
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix[0, 0] = matrix[1, 1] = matrix[2, 2] = matrix[3, 3] = matrix[4, 4] = 1.0f;
                return matrix;
            }
        }

        public static Image ChangeGamma(Image img, float gamma)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);

            gamma = gamma / 100 + 1;
            gamma = gamma.Between(0.1f, 10.0f);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (ImageAttributes imgattr = new ImageAttributes())
                {
                    imgattr.SetGamma(gamma, ColorAdjustType.Bitmap);
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgattr);
                }
            }

            return bmp;
        }

        public static ColorMatrix Alpha(float percentage, float addition)
        {
            float perc = 1 - percentage / 100;
            float add = addition / 100;

            return new ColorMatrix(new[]{
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, perc, 0},
                new float[] {0, 0, 0, add, 1}});
        }

        public static ColorMatrix Brightness(float percentage)
        {
            float perc = percentage / 100;

            return new ColorMatrix(new[]{
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {perc, perc, perc, 0, 1}});
        }

        public static ColorMatrix Colorize(Color color, float percentage)
        {
            float r = (float)color.R / 255;
            float g = (float)color.G / 255;
            float b = (float)color.B / 255;
            float amount = percentage / 100;
            float inv_amount = 1 - amount;

            return new ColorMatrix(new[]{
                new float[] {inv_amount + amount * r * rw, amount * g * rw, amount * b * rw, 0, 0},
                new float[] {amount * r * gw, inv_amount + amount * g * gw, amount * b * gw, 0, 0},
                new float[] {amount * r * bw, amount * g * bw, inv_amount + amount * b * bw, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}});
        }

        public static ColorMatrix Contrast(float percentage)
        {
            float perc = 1 + percentage / 100;

            return new ColorMatrix(new[]{
                new float[] {perc, 0, 0, 0, 0},
                new float[] {0, perc, 0, 0, 0},
                new float[] {0, 0, perc, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}});
        }

        public static ColorMatrix Grayscale()
        {
            return new ColorMatrix(new[]{
                new float[] {rw, rw, rw, 0, 0},
                new float[] {gw, gw, gw, 0, 0},
                new float[] {bw, bw, bw, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}});
        }

        public static ColorMatrix Hue(float angle)
        {
            float a = angle * (float)(Math.PI / 180);
            float c = (float)Math.Cos(a);
            float s = (float)Math.Sin(a);

            return new ColorMatrix(new[]{
                new float[] {(rw + (c * (1 - rw))) + (s * -rw), (rw + (c * -rw)) + (s * 0.143f), (rw + (c * -rw)) + (s * -(1 - rw)), 0, 0},
                new float[] {(gw + (c * -gw)) + (s * -gw), (gw + (c * (1 - gw))) + (s * 0.14f), (gw + (c * -gw)) + (s * gw), 0, 0},
                new float[] {(bw + (c * -bw)) + (s * (1 - bw)), (bw + (c * -bw)) + (s * -0.283f), (bw + (c * (1 - bw))) + (s * bw), 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}});
        }

        public static ColorMatrix Inverse()
        {
            return new ColorMatrix(new[]{
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {1, 1, 1, 0, 1}});
        }

        public static ColorMatrix Saturation(float percentage)
        {
            float s = 1 + percentage / 100;

            return new ColorMatrix(new[]{
                new float[] {(1.0f - s) * rw + s, (1.0f - s) * rw, (1.0f - s) * rw, 0, 0},
                new float[] {(1.0f - s) * gw, (1.0f - s) * gw + s, (1.0f - s) * gw, 0, 0},
                new float[] {(1.0f - s) * bw, (1.0f - s) * bw, (1.0f - s) * bw + s, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}});
        }
    }
}