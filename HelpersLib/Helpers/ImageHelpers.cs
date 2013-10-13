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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HelpersLib
{
    public static class ImageHelpers
    {
        public static Image ResizeImage(Image img, int width, int height)
        {
            return ResizeImage(img, 0, 0, width, height);
        }

        public static Image ResizeImage(Image img, Size size)
        {
            return ResizeImage(img, 0, 0, size.Width, size.Height);
        }

        public static Image ResizeImage(Image img, int x, int y, int width, int height)
        {
            if (img.Width == width && img.Height == height)
            {
                return img;
            }

            Bitmap bmp = new Bitmap(width, height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                g.DrawImage(img, x, y, width, height);

                img.Dispose();
            }

            return bmp;
        }

        public static Image ResizeImageByPercentage(Image img, float percentage)
        {
            return ResizeImageByPercentage(img, percentage, percentage);
        }

        public static Image ResizeImageByPercentage(Image img, float percentageWidth, float percentageHeight)
        {
            int width = (int)(percentageWidth / 100 * img.Width);
            int height = (int)(percentageHeight / 100 * img.Height);
            return ResizeImage(img, width, height);
        }

        public static Image ResizeImageByWidth(Image img, int width, bool keepAspectRatio = true)
        {
            int height = keepAspectRatio ? width / img.Width * img.Height : img.Height;
            return ResizeImage(img, width, height);
        }

        public static Image ResizeImageByHeight(Image img, int height, bool keepAspectRatio = true)
        {
            int width = keepAspectRatio ? height / img.Height * img.Width : img.Width;
            return ResizeImage(img, width, height);
        }

        public static Image ResizeImage(Image img, int width, int height, bool allowEnlarge, bool centerImage)
        {
            return ResizeImage(img, 0, 0, width, height, allowEnlarge, centerImage);
        }

        public static Image ResizeImage(Image img, Rectangle rect, bool allowEnlarge, bool centerImage)
        {
            return ResizeImage(img, rect.X, rect.Y, rect.Width, rect.Height, allowEnlarge, centerImage);
        }

        public static Image ResizeImage(Image img, int x, int y, int width, int height, bool allowEnlarge, bool centerImage)
        {
            double ratio;
            int newWidth, newHeight, newX, newY;

            if (!allowEnlarge && img.Width <= width && img.Height <= height)
            {
                ratio = 1.0;
                newWidth = img.Width;
                newHeight = img.Height;
            }
            else
            {
                double ratioX = (double)width / (double)img.Width;
                double ratioY = (double)height / (double)img.Height;
                ratio = ratioX < ratioY ? ratioX : ratioY;
                newWidth = (int)(img.Width * ratio);
                newHeight = (int)(img.Height * ratio);
            }

            newX = x;
            newY = y;

            if (centerImage)
            {
                newX += (int)((width - (img.Width * ratio)) / 2);
                newY += (int)((height - (img.Height * ratio)) / 2);
            }

            return ResizeImage(img, newX, newY, newWidth, newHeight);
        }

        public static Image CropImage(Image img, Rectangle rect)
        {
            if (img != null && rect.X >= 0 && rect.Y >= 0 && rect.Width > 0 && rect.Height > 0 &&
                new Rectangle(0, 0, img.Width, img.Height).Contains(rect))
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    return bmp.Clone(rect, bmp.PixelFormat);
                }
            }

            return null;
        }

        public static Bitmap CropBitmap(Bitmap bmp, Rectangle rect)
        {
            if (bmp != null && rect.X >= 0 && rect.Y >= 0 && rect.Width > 0 && rect.Height > 0 &&
                new Rectangle(0, 0, bmp.Width, bmp.Height).Contains(rect))
            {
                return bmp.Clone(rect, bmp.PixelFormat);
            }

            return null;
        }

        public static Image CropImage(Image img, Rectangle rect, GraphicsPath gp)
        {
            if (img != null && rect.Width > 0 && rect.Height > 0 && gp != null)
            {
                Bitmap bmp = new Bitmap(rect.Width, rect.Height);
                bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    using (Region region = new Region(gp))
                    {
                        g.Clip = region;
                        g.DrawImage(img, new Rectangle(0, 0, rect.Width, rect.Height), rect, GraphicsUnit.Pixel);
                    }
                }

                return bmp;
            }

            return null;
        }

        public static Image DrawBorder(Image img, BorderType borderType, Color borderColor, int borderSize)
        {
            Bitmap bmp = null;

            using (Pen borderPen = new Pen(borderColor, borderSize) { Alignment = PenAlignment.Inset })
            {
                if (borderType == BorderType.Inside)
                {
                    bmp = (Bitmap)img;

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawRectangleProper(borderPen, new Rectangle(0, 0, img.Width, img.Height));
                    }

                    return img;
                }
                else
                {
                    bmp = new Bitmap(img.Width + borderSize * 2, img.Height + borderSize * 2);
                    bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImageUnscaled(img, borderSize, borderSize);
                        g.DrawRectangleProper(borderPen, new Rectangle(0, 0, img.Width + borderSize * 2, img.Height + borderSize * 2));
                    }

                    img.Dispose();
                }
            }

            return bmp;
        }

        public static Image DrawOutline(Image img, GraphicsPath gp)
        {
            if (img != null && gp != null)
            {
                Bitmap bmp = new Bitmap(img);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    gp.WindingModeOutline();
                    g.DrawPath(Pens.Black, gp);
                }

                return bmp;
            }

            return null;
        }

        private static Bitmap AddSkew(Bitmap bmp, int skew)
        {
            Bitmap result = new Bitmap(bmp.Width + skew, bmp.Height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Point[] destinationPoints = { new Point(0, 0), new Point(bmp.Width, 0), new Point(skew, bmp.Height - 1) };
                g.DrawImage(bmp, destinationPoints);
            }

            return result;
        }

        public static Image AddCanvas(Image img, int size)
        {
            Image bmp = new Bitmap(img.Width + size * 2, img.Height + size * 2);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, new Rectangle(size, size, img.Width, img.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            }

            return bmp;
        }

        public static Image DrawReflection(Image img, int percentage, int transparency, int offset, bool skew, int skewSize)
        {
            Bitmap reflection = AddReflection(img, percentage, transparency);

            if (skew)
            {
                reflection = AddSkew(reflection, skewSize);
            }

            Bitmap result = new Bitmap(reflection.Width, img.Height + reflection.Height + offset);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                g.DrawImage(reflection, new Point(0, img.Height + offset));
            }

            return result;
        }

        private static Bitmap AddReflection(Image img, int percentage, int transparency)
        {
            Bitmap b = new Bitmap(img);
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);
            b = b.Clone(new Rectangle(0, 0, b.Width, (int)(b.Height * (float)percentage / 100)), PixelFormat.Format32bppArgb);
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            byte alpha;
            int nOffset = bmData.Stride - b.Width * 4;

            unsafe
            {
                byte* p = (byte*)(void*)bmData.Scan0;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        alpha = (byte)(transparency - transparency * (y + 1) / b.Height);
                        if (p[3] > alpha) p[3] = alpha;
                        p += 4;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return b;
        }

        public static Bitmap AddReflection(Image bmp, int percentage, int minAlpha, int maxAlpha)
        {
            Bitmap b = (Bitmap)bmp.Clone();
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);
            b = b.Clone(new Rectangle(0, 0, b.Width, (int)(b.Height * ((float)percentage / 100))), PixelFormat.Format32bppArgb);

            using (UnsafeBitmap unsafeBitmap = new UnsafeBitmap(b, true, ImageLockMode.ReadWrite))
            {
                maxAlpha = maxAlpha.Between(0, 255);
                minAlpha = minAlpha.Between(0, 255);
                int alphaAdd = maxAlpha - minAlpha;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        ColorBgra color = unsafeBitmap.GetPixel(x, y);
                        byte alpha = (byte)(minAlpha + (maxAlpha - (alphaAdd * (y + 1) / b.Height)));

                        if (color.Alpha > alpha)
                        {
                            color.Alpha = alpha;
                            unsafeBitmap.SetPixel(x, y, color);
                        }
                    }
                }
            }

            return b;
        }

        public static void FillImageBackground(Image img, Color color)
        {
            using (Image tempImage = (Image)img.Clone())
            {
                Bitmap bmp = (Bitmap)img;

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    g.Clear(color);
                    g.DrawImageUnscaled(tempImage, 0, 0);
                }
            }
        }

        public static Image FillImageBackground(Image img, Color color, Color color2)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(img.Width - 1, 0), color, color2))
                {
                    g.FillRectangle(brush, 0, 0, img.Width, img.Height);
                    g.DrawImageUnscaled(img, 0, 0);
                }
            }

            return bmp;
        }

        public static Image CreateCheckers(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                Image checker = CreateCheckers(8, Color.LightGray, Color.White);
                Brush checkerBrush = new TextureBrush(checker, WrapMode.Tile);

                g.FillRectangle(checkerBrush, new Rectangle(0, 0, bmp.Width, bmp.Height));
            }

            return bmp;
        }

        public static Image DrawCheckers(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                Image checker = CreateCheckers(8, Color.LightGray, Color.White);
                Brush checkerBrush = new TextureBrush(checker, WrapMode.Tile);

                g.FillRectangle(checkerBrush, new Rectangle(0, 0, bmp.Width, bmp.Height));
                g.DrawImageUnscaled(img, 0, 0);
            }

            return bmp;
        }

        public static Image CreateCheckers(int size, Color color1, Color color2)
        {
            Bitmap bmp = new Bitmap(size * 2, size * 2);

            using (Graphics g = Graphics.FromImage(bmp))
            using (Brush brush1 = new SolidBrush(color1))
            using (Brush brush2 = new SolidBrush(color2))
            {
                g.FillRectangle(brush1, 0, 0, size, size);
                g.FillRectangle(brush1, size, size, size, size);

                g.FillRectangle(brush2, size, 0, size, size);
                g.FillRectangle(brush2, 0, size, size, size);
            }

            return bmp;
        }

        public static void DrawTextWithOutline(Graphics g, string text, PointF position, Font font, Color textColor, Color borderColor, int shadowOffset = 1)
        {
            SmoothingMode tempMode = g.SmoothingMode;

            g.SmoothingMode = SmoothingMode.HighQuality;

            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddString(text, font.FontFamily, (int)font.Style, font.Size, position, new StringFormat());

                using (Pen borderPen = new Pen(borderColor, 2) { LineJoin = LineJoin.Round })
                {
                    g.DrawPath(borderPen, gp);
                }

                using (Brush textBrush = new SolidBrush(textColor))
                {
                    g.FillPath(textBrush, gp);
                }
            }

            g.SmoothingMode = tempMode;
        }

        public static void DrawTextWithShadow(Graphics g, string text, PointF position, Font font, Color textColor, Color shadowColor, int shadowOffset = 1)
        {
            using (Brush shadowBrush = new SolidBrush(shadowColor))
            {
                g.DrawString(text, font, shadowBrush, position.X + shadowOffset, position.Y + shadowOffset);
            }

            using (Brush textBrush = new SolidBrush(textColor))
            {
                g.DrawString(text, font, textBrush, position.X, position.Y);
            }
        }

        public static bool IsImagesEqual(Bitmap bmp1, Bitmap bmp2)
        {
            using (UnsafeBitmap unsafeBitmap1 = new UnsafeBitmap(bmp1))
            using (UnsafeBitmap unsafeBitmap2 = new UnsafeBitmap(bmp2))
            {
                return unsafeBitmap1 == unsafeBitmap2;
            }
        }

        public static bool AddMetadata(Image img, int id, string text)
        {
            PropertyItem pi = null;

            try
            {
                // TODO: Need better solution
                pi = (PropertyItem)typeof(PropertyItem).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { }, null).Invoke(null);
                pi.Id = id;
                pi.Len = text.Length + 1;
                pi.Type = 2;
                byte[] bytesText = Encoding.ASCII.GetBytes(text + " ");
                bytesText[bytesText.Length - 1] = 0;
                pi.Value = bytesText;

                if (pi != null)
                {
                    img.SetPropertyItem(pi);
                    return true;
                }
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e, "Reflection fail");
            }

            return false;
        }

        public static void CopyMetadata(Image fromImage, Image toImage)
        {
            PropertyItem[] propertyItems = fromImage.PropertyItems;
            foreach (PropertyItem pi in propertyItems)
            {
                try
                {
                    toImage.SetPropertyItem(pi);
                }
                catch (Exception e)
                {
                    DebugHelper.WriteException(e);
                }
            }
        }

        public static Bitmap RotateImage(Image img, float theta)
        {
            using (Matrix matrix = new Matrix())
            {
                matrix.Translate(img.Width / -2, img.Height / -2, MatrixOrder.Append);
                matrix.RotateAt(theta, new Point(0, 0), MatrixOrder.Append);
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddPolygon(new Point[] { new Point(0, 0), new Point(img.Width, 0), new Point(0, img.Height) });
                    gp.Transform(matrix);
                    PointF[] pts = gp.PathPoints;

                    Rectangle bbox = BoundingBox(img, matrix);
                    Bitmap bmpDest = new Bitmap(bbox.Width, bbox.Height);

                    using (Graphics gDest = Graphics.FromImage(bmpDest))
                    {
                        using (Matrix mDest = new Matrix())
                        {
                            mDest.Translate(bmpDest.Width / 2, bmpDest.Height / 2, MatrixOrder.Append);
                            gDest.Transform = mDest;
                            gDest.CompositingQuality = CompositingQuality.HighQuality;
                            gDest.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            gDest.DrawImage(img, pts);
                            return bmpDest;
                        }
                    }
                }
            }
        }

        private static Rectangle BoundingBox(Image img, Matrix matrix)
        {
            GraphicsUnit gu = new GraphicsUnit();
            Rectangle rImg = Rectangle.Round(img.GetBounds(ref gu));

            Point topLeft = new Point(rImg.Left, rImg.Top);
            Point topRight = new Point(rImg.Right, rImg.Top);
            Point bottomRight = new Point(rImg.Right, rImg.Bottom);
            Point bottomLeft = new Point(rImg.Left, rImg.Bottom);
            Point[] points = new Point[] { topLeft, topRight, bottomRight, bottomLeft };
            using (GraphicsPath gp = new GraphicsPath(points,
                new byte[] { (byte)PathPointType.Start, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line }))
            {
                gp.Transform(matrix);
                return Rectangle.Round(gp.GetBounds());
            }
        }
    }
}