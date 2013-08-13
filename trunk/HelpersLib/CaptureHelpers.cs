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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace HelpersLib
{
    public static class CaptureHelpers
    {
        public static Rectangle GetScreenBounds()
        {
            return SystemInformation.VirtualScreen;
        }

        public static Rectangle GetScreenBounds2()
        {
            Point topLeft = Point.Empty;
            Point bottomRight = Point.Empty;

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Bounds.X < topLeft.X) topLeft.X = screen.Bounds.X;
                if (screen.Bounds.Y < topLeft.Y) topLeft.Y = screen.Bounds.Y;
                if ((screen.Bounds.X + screen.Bounds.Width) > bottomRight.X) bottomRight.X = screen.Bounds.X + screen.Bounds.Width;
                if ((screen.Bounds.Y + screen.Bounds.Height) > bottomRight.Y) bottomRight.Y = screen.Bounds.Y + screen.Bounds.Height;
            }

            return new Rectangle(topLeft.X, topLeft.Y, bottomRight.X + Math.Abs(topLeft.X), bottomRight.Y + Math.Abs(topLeft.Y));
        }

        public static Rectangle GetScreenBounds3()
        {
            Point topLeft = Point.Empty;
            Point bottomRight = Point.Empty;

            foreach (Screen screen in Screen.AllScreens)
            {
                topLeft.X = Math.Min(topLeft.X, screen.Bounds.X);
                topLeft.Y = Math.Min(topLeft.Y, screen.Bounds.Y);
                bottomRight.X = Math.Max(bottomRight.X, screen.Bounds.Right);
                bottomRight.Y = Math.Max(bottomRight.Y, screen.Bounds.Bottom);
            }

            return new Rectangle(topLeft.X, topLeft.Y, bottomRight.X + Math.Abs(topLeft.X), bottomRight.Y + Math.Abs(topLeft.Y));
        }

        public static Rectangle GetScreenBounds4()
        {
            return Screen.AllScreens.Aggregate(Rectangle.Empty, (current, screen) => Rectangle.Union(current, screen.Bounds));
        }

        public static Rectangle GetActiveScreenBounds()
        {
            return Screen.FromPoint(GetMousePosition()).Bounds;
        }

        public static Rectangle GetScreenBounds0Based()
        {
            return ScreenToClient(GetScreenBounds());
        }

        public static Point ScreenToClient(Point p)
        {
            int screenX = NativeMethods.GetSystemMetrics(SystemMetric.SM_XVIRTUALSCREEN);
            int screenY = NativeMethods.GetSystemMetrics(SystemMetric.SM_YVIRTUALSCREEN);
            return new Point(p.X - screenX, p.Y - screenY);
        }

        public static Rectangle ScreenToClient(Rectangle r)
        {
            return new Rectangle(ScreenToClient(r.Location), r.Size);
        }

        public static Point ClientToScreen(Point p)
        {
            int screenX = NativeMethods.GetSystemMetrics(SystemMetric.SM_XVIRTUALSCREEN);
            int screenY = NativeMethods.GetSystemMetrics(SystemMetric.SM_YVIRTUALSCREEN);
            return new Point(p.X + screenX, p.Y + screenY);
        }

        public static Rectangle ClientToScreen(Rectangle r)
        {
            return new Rectangle(ClientToScreen(r.Location), r.Size);
        }

        public static Point GetMousePosition()
        {
            POINT pt = new POINT();
            NativeMethods.GetCursorPos(out pt);
            return (Point)pt;
        }

        public static Point GetZeroBasedMousePosition()
        {
            return ScreenToClient(GetMousePosition());
        }

        public static Rectangle CreateRectangle(int x, int y, int x2, int y2)
        {
            int width, height;

            if (x <= x2)
            {
                width = x2 - x + 1;
            }
            else
            {
                width = x - x2 + 1;
                x = x2;
            }

            if (y <= y2)
            {
                height = y2 - y + 1;
            }
            else
            {
                height = y - y2 + 1;
                y = y2;
            }

            return new Rectangle(x, y, width, height);
        }

        public static Rectangle CreateRectangle(Point pos, Point pos2)
        {
            return CreateRectangle(pos.X, pos.Y, pos2.X, pos2.Y);
        }

        public static Rectangle FixRectangle(int x, int y, int width, int height)
        {
            if (width < 0)
            {
                x += width;
                width = -width;
            }

            if (height < 0)
            {
                y += height;
                height = -height;
            }

            return new Rectangle(x, y, width, height);
        }

        public static Rectangle FixRectangle(Rectangle rect)
        {
            return FixRectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public static Point ProportionalPosition(Point pos, Point pos2)
        {
            Point newPosition = Point.Empty;
            int min;

            if (pos.X < pos2.X)
            {
                if (pos.Y < pos2.Y)
                {
                    min = Math.Min(pos2.X - pos.X, pos2.Y - pos.Y);
                    newPosition.X = pos.X + min;
                    newPosition.Y = pos.Y + min;
                }
                else
                {
                    min = Math.Min(pos2.X - pos.X, pos.Y - pos2.Y);
                    newPosition.X = pos.X + min;
                    newPosition.Y = pos.Y - min;
                }
            }
            else
            {
                if (pos.Y > pos2.Y)
                {
                    min = Math.Min(pos.X - pos2.X, pos.Y - pos2.Y);
                    newPosition.X = pos.X - min;
                    newPosition.Y = pos.Y - min;
                }
                else
                {
                    min = Math.Min(pos.X - pos2.X, pos2.Y - pos.Y);
                    newPosition.X = pos.X - min;
                    newPosition.Y = pos.Y + min;
                }
            }

            return newPosition;
        }

        public static Rectangle GetWindowRectangle(IntPtr handle, bool maximizeFix = true)
        {
            Rectangle rect = Rectangle.Empty;

            if (NativeMethods.IsDWMEnabled())
            {
                Rectangle tempRect;

                if (NativeMethods.GetExtendedFrameBounds(handle, out tempRect))
                {
                    rect = tempRect;
                }
            }

            if (rect.IsEmpty)
            {
                rect = NativeMethods.GetWindowRect(handle);
            }

            if (maximizeFix && NativeMethods.IsZoomed(handle))
            {
                rect = NativeMethods.MaximizedWindowFix(handle, rect);
            }

            return rect;
        }

        public static Rectangle GetActiveWindowRectangle(bool maximizeFix = true)
        {
            IntPtr handle = NativeMethods.GetForegroundWindow();

            if (handle.ToInt32() > 0)
            {
                return CaptureHelpers.GetWindowRectangle(handle);
            }

            return Rectangle.Empty;
        }

        public static Image CropImage(Image img, Rectangle rect)
        {
            if (img != null && rect.X >= 0 && rect.Y >= 0 && rect.Width > 0 && rect.Height > 0)
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
            if (bmp != null && rect.X >= 0 && rect.Y >= 0 && rect.Width > 0 && rect.Height > 0)
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

        public static Image ResizeImage(Image img, int width, int height, bool highQualityScaling = true)
        {
            return ResizeImage(img, 0, 0, width, height, highQualityScaling);
        }

        public static Image ResizeImage(Image img, Rectangle rect, bool highQualityScaling = true)
        {
            return ResizeImage(img, rect.X, rect.Y, rect.Width, rect.Height, highQualityScaling);
        }

        public static Image ResizeImage(Image img, int x, int y, int width, int height, bool highQualityScaling = true)
        {
            if (img.Width == width && img.Height == height)
            {
                return img;
            }

            Bitmap bmp = new Bitmap(width, height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (highQualityScaling)
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                }

                g.DrawImage(img, x, y, width, height);
                img.Dispose();
            }

            return bmp;
        }

        public static Image ResizeImage(Image img, int width, int height, bool allowEnlarge, bool centerImage, bool highQualityScaling = true)
        {
            return ResizeImage(img, 0, 0, width, height, allowEnlarge, centerImage, highQualityScaling);
        }

        public static Image ResizeImage(Image img, Rectangle rect, bool allowEnlarge, bool centerImage, bool highQualityScaling = true)
        {
            return ResizeImage(img, rect.X, rect.Y, rect.Width, rect.Height, allowEnlarge, centerImage, highQualityScaling);
        }

        public static Image ResizeImage(Image img, int x, int y, int width, int height, bool allowEnlarge, bool centerImage, bool highQualityScaling = true)
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

            return ResizeImage(img, newX, newY, newWidth, newHeight, highQualityScaling);
        }

        public static Image DrawBorder(Image img, BorderType borderType, Color borderColor, int borderSize)
        {
            Bitmap bmp = null;

            using (Pen borderPen = new Pen(borderColor, borderSize) { Alignment = PenAlignment.Inset })
            {
                if (borderType == BorderType.Inside)
                {
                    bmp = new Bitmap(img);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawRectangleProper(borderPen, new Rectangle(0, 0, img.Width, img.Height));
                    }
                }
                else
                {
                    bmp = new Bitmap(img.Width + borderSize * 2, img.Height + borderSize * 2);
                    bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(img, borderSize, borderSize, img.Width, img.Height);
                        g.DrawRectangleProper(borderPen, new Rectangle(0, 0, img.Width + borderSize * 2, img.Height + borderSize * 2));
                    }
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

        public static Image FillImageBackground(Image img, Color color)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                g.Clear(color);
                g.DrawImageUnscaled(img, 0, 0);
            }

            return bmp;
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
    }
}