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

using System;
using System.Drawing;
using System.Drawing.Imaging;
using HelpersLib;

namespace ScreenCapture
{
    public static partial class Screenshot
    {
        public static bool RemoveOutsideScreenArea = true;
        public static bool DrawCursor = false;
        public static bool CaptureShadow = true;

        public static Image CaptureRectangle(Rectangle rect)
        {
            if (RemoveOutsideScreenArea)
            {
                Rectangle bounds = CaptureHelpers.GetScreenBounds();
                rect = Rectangle.Intersect(bounds, rect);
            }

            Image img = CaptureRectangleNative(rect);

            if (DrawCursor)
            {
                Point cursorOffset = CaptureHelpers.FixScreenCoordinates(rect.Location);
                CaptureHelpers.DrawCursorToImage(img, cursorOffset);
            }

            return img;
        }

        public static Image CaptureFullscreen()
        {
            Rectangle bounds = CaptureHelpers.GetScreenBounds();

            return CaptureRectangle(bounds);
        }

        public static Image CaptureWindow(IntPtr handle)
        {
            if (handle.ToInt32() > 0)
            {
                Rectangle rect = CaptureHelpers.GetWindowRectangle(handle);

                return CaptureRectangle(rect);
            }

            return null;
        }

        public static Image CaptureActiveWindow()
        {
            IntPtr handle = NativeMethods.GetForegroundWindow();

            return CaptureWindow(handle);
        }

        public static Image CaptureActiveMonitor()
        {
            Rectangle bounds = CaptureHelpers.GetActiveScreenBounds();

            return CaptureRectangle(bounds);
        }

        // Managed can't use SourceCopy | CaptureBlt because of .NET bug
        public static Image CaptureRectangleManaged(Rectangle rect)
        {
            Image img = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(img))
            {
                g.CopyFromScreen(rect.Location, Point.Empty, rect.Size, CopyPixelOperation.SourceCopy);
            }

            return img;
        }

        public static Image CaptureRectangleNative(Rectangle rect)
        {
            return CaptureRectangleNative(NativeMethods.GetDesktopWindow(), rect);
        }

        public static Image CaptureRectangleNative(IntPtr handle, Rectangle rect)
        {
            // avoid System.ArgumentException: Parameter is not valid
            if (rect.Width == 0 || rect.Height == 0) return null;

            // Format24bppRgb because some images can show up with white dots
            Image img = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(img))
            {
                IntPtr hdcSrc = NativeMethods.GetWindowDC(handle);
                IntPtr hdcDest = g.GetHdc();
                NativeMethods.BitBlt(hdcDest, 0, 0, rect.Width, rect.Height, hdcSrc, rect.X, rect.Y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
                NativeMethods.ReleaseDC(handle, hdcSrc);
                g.ReleaseHdc(hdcDest);
            }

            return img;
        }

        public static Image CaptureRectangleNative2(Rectangle rect)
        {
            return CaptureRectangleNative2(NativeMethods.GetDesktopWindow(), rect);
        }

        public static Image CaptureRectangleNative2(IntPtr handle, Rectangle rect)
        {
            IntPtr hdcSrc = NativeMethods.GetWindowDC(handle);
            IntPtr hdcDest = NativeMethods.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = NativeMethods.CreateCompatibleBitmap(hdcSrc, rect.Width, rect.Height);
            IntPtr hOld = NativeMethods.SelectObject(hdcDest, hBitmap);
            NativeMethods.BitBlt(hdcDest, 0, 0, rect.Width, rect.Height, hdcSrc, rect.Left, rect.Top, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
            NativeMethods.SelectObject(hdcDest, hOld);
            NativeMethods.DeleteDC(hdcDest);
            NativeMethods.ReleaseDC(handle, hdcSrc);
            Image img = Image.FromHbitmap(hBitmap);
            NativeMethods.DeleteObject(hBitmap);

            return img;
        }
    }
}