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

    Copyright (C) 2007 Rick Brewster, Chris Crosetto, Tom Jackson, Michael Kelsey, Brandon Ortiz, Craig Taylor,
    Chris Trevino, and Luke Walker.

    Portions Copyright (C) 2007 Microsoft Corporation. All Rights Reserved.

    This software is licensed as per the MIT License below, but with one exception:

    The Paint.NET logo and icon artwork are Copyright (C) Rick Brewster.
    They are covered by the Creative Commons Attribution-NonCommercial-NoDerivs 2.5 license which is detailed here:
    http://creativecommons.org/licenses/by-nc-nd/2.5/.
    Permission is granted to use the logo and icon artwork in ways that discuss or
    promote Paint.NET (e.g. blog and news posts about Paint.NET, "Made with Paint.NET" watermarks or insets).

    MIT License: http://www.opensource.org/licenses/mit-license.php

    Permission is hereby granted, free of charge, to any person obtaining a copy of this software
    and associated documentation files (the "Software"), to deal in the Software without restriction,
    including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
    and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
    subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all copies or substantial
    portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE
    AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#endregion License Information (GPL v3)

using HelpersLib;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageEffectsLib
{
    public class Blur : IPluginItem
    {
        public override string Name { get { return "Blur"; } }

        public override string Description { get { return "Blur"; } }

        private int radius;

        [Description("Blur radius in pixels (between 0 and 15).")]
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value.Between(0, 15);
            }
        }

        private bool expand;

        [Description("Expand image to fit blurred image.")]
        public bool Expand
        {
            get
            {
                return expand;
            }
            set
            {
                expand = value;
            }
        }

        public Blur()
        {
            Radius = 2;
            Expand = true;
        }

        public override Image ApplyEffect(Image img)
        {
            return ApplyBlur((Bitmap)img, radius, expand);
        }

        public unsafe static Image ApplyBlur(Bitmap bmp, int radius, bool expand)
        {
            if (expand)
            {
                bmp = (Bitmap)ImageHelpers.AddCanvas(bmp, radius);
            }

            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);

            using (UnsafeBitmap src = new UnsafeBitmap(bmp, false, ImageLockMode.ReadWrite))
            using (UnsafeBitmap dst = new UnsafeBitmap(bmp2, false, ImageLockMode.ReadWrite))
            {
                int[] w = CreateGaussianBlurRow(radius);
                int wlen = w.Length;

                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

                if (rect.Height >= 1 && rect.Width >= 1)
                {
                    for (int y = rect.Top; y < rect.Bottom; ++y)
                    {
                        long* waSums = stackalloc long[wlen];
                        long* wcSums = stackalloc long[wlen];
                        long* aSums = stackalloc long[wlen];
                        long* bSums = stackalloc long[wlen];
                        long* gSums = stackalloc long[wlen];
                        long* rSums = stackalloc long[wlen];
                        long waSum = 0;
                        long wcSum = 0;
                        long aSum = 0;
                        long bSum = 0;
                        long gSum = 0;
                        long rSum = 0;

                        ColorBgra* dstPtr = dst.GetPointAddress(rect.Left, y);

                        for (int wx = 0; wx < wlen; ++wx)
                        {
                            int srcX = rect.Left + wx - radius;
                            waSums[wx] = 0;
                            wcSums[wx] = 0;
                            aSums[wx] = 0;
                            bSums[wx] = 0;
                            gSums[wx] = 0;
                            rSums[wx] = 0;

                            if (srcX >= 0 && srcX < src.Width)
                            {
                                for (int wy = 0; wy < wlen; ++wy)
                                {
                                    int srcY = y + wy - radius;

                                    if (srcY >= 0 && srcY < src.Height)
                                    {
                                        ColorBgra c = src.GetPoint(srcX, srcY);
                                        int wp = w[wy];

                                        waSums[wx] += wp;
                                        wp *= c.Alpha + (c.Alpha >> 7);
                                        wcSums[wx] += wp;
                                        wp >>= 8;

                                        aSums[wx] += wp * c.Alpha;
                                        bSums[wx] += wp * c.Blue;
                                        gSums[wx] += wp * c.Green;
                                        rSums[wx] += wp * c.Red;
                                    }
                                }

                                int wwx = w[wx];
                                waSum += wwx * waSums[wx];
                                wcSum += wwx * wcSums[wx];
                                aSum += wwx * aSums[wx];
                                bSum += wwx * bSums[wx];
                                gSum += wwx * gSums[wx];
                                rSum += wwx * rSums[wx];
                            }
                        }

                        wcSum >>= 8;

                        if (waSum == 0 || wcSum == 0)
                        {
                            dstPtr->Bgra = 0;
                        }
                        else
                        {
                            uint alpha = (uint)(aSum / waSum);
                            uint blue = (uint)(bSum / wcSum);
                            uint green = (uint)(gSum / wcSum);
                            uint red = (uint)(rSum / wcSum);

                            dstPtr->Bgra = ColorBgra.BgraToUInt32(blue, green, red, alpha);
                        }

                        ++dstPtr;

                        for (int x = rect.Left + 1; x < rect.Right; ++x)
                        {
                            for (int i = 0; i < wlen - 1; ++i)
                            {
                                waSums[i] = waSums[i + 1];
                                wcSums[i] = wcSums[i + 1];
                                aSums[i] = aSums[i + 1];
                                bSums[i] = bSums[i + 1];
                                gSums[i] = gSums[i + 1];
                                rSums[i] = rSums[i + 1];
                            }

                            waSum = 0;
                            wcSum = 0;
                            aSum = 0;
                            bSum = 0;
                            gSum = 0;
                            rSum = 0;

                            int wx;
                            for (wx = 0; wx < wlen - 1; ++wx)
                            {
                                long wwx = (long)w[wx];
                                waSum += wwx * waSums[wx];
                                wcSum += wwx * wcSums[wx];
                                aSum += wwx * aSums[wx];
                                bSum += wwx * bSums[wx];
                                gSum += wwx * gSums[wx];
                                rSum += wwx * rSums[wx];
                            }

                            wx = wlen - 1;

                            waSums[wx] = 0;
                            wcSums[wx] = 0;
                            aSums[wx] = 0;
                            bSums[wx] = 0;
                            gSums[wx] = 0;
                            rSums[wx] = 0;

                            int srcX = x + wx - radius;

                            if (srcX >= 0 && srcX < src.Width)
                            {
                                for (int wy = 0; wy < wlen; ++wy)
                                {
                                    int srcY = y + wy - radius;

                                    if (srcY >= 0 && srcY < src.Height)
                                    {
                                        ColorBgra c = src.GetPoint(srcX, srcY);
                                        int wp = w[wy];

                                        waSums[wx] += wp;
                                        wp *= c.Alpha + (c.Alpha >> 7);
                                        wcSums[wx] += wp;
                                        wp >>= 8;

                                        aSums[wx] += wp * (long)c.Alpha;
                                        bSums[wx] += wp * (long)c.Blue;
                                        gSums[wx] += wp * (long)c.Green;
                                        rSums[wx] += wp * (long)c.Red;
                                    }
                                }

                                int wr = w[wx];
                                waSum += (long)wr * waSums[wx];
                                wcSum += (long)wr * wcSums[wx];
                                aSum += (long)wr * aSums[wx];
                                bSum += (long)wr * bSums[wx];
                                gSum += (long)wr * gSums[wx];
                                rSum += (long)wr * rSums[wx];
                            }

                            wcSum >>= 8;

                            if (waSum == 0 || wcSum == 0)
                            {
                                dstPtr->Bgra = 0;
                            }
                            else
                            {
                                uint alpha = (uint)(aSum / waSum);
                                uint blue = (uint)(bSum / wcSum);
                                uint green = (uint)(gSum / wcSum);
                                uint red = (uint)(rSum / wcSum);

                                dstPtr->Bgra = ColorBgra.BgraToUInt32(blue, green, red, alpha);
                            }

                            ++dstPtr;
                        }
                    }
                }
            }

            return bmp2;
        }

        private static int[] CreateGaussianBlurRow(int amount)
        {
            int size = 1 + (amount * 2);
            int[] weights = new int[size];

            for (int i = 0; i <= amount; ++i)
            {
                // 1 + aa - aa + 2ai - ii
                weights[i] = 16 * (i + 1);
                weights[weights.Length - i - 1] = weights[i];
            }

            return weights;
        }
    }
}