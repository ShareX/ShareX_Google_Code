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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HelpersLib
{
    public class CursorData : IDisposable
    {
        public Icon Icon { get; private set; }
        public Point Position { get; private set; }
        public bool IsVisible { get; private set; }

        public static CursorData GetCursorData()
        {
            CursorData cursorData = new CursorData();

            CursorInfo cursorInfo = new CursorInfo();
            cursorInfo.cbSize = Marshal.SizeOf(cursorInfo);

            if (NativeMethods.GetCursorInfo(out cursorInfo))
            {
                cursorData.IsVisible = cursorInfo.flags == NativeMethods.CURSOR_SHOWING;

                if (cursorData.IsVisible)
                {
                    IntPtr hIcon = NativeMethods.CopyIcon(cursorInfo.hCursor);
                    IconInfo iconInfo;

                    if (NativeMethods.GetIconInfo(hIcon, out iconInfo))
                    {
                        Point cursorPosition = CaptureHelpers.GetZeroBasedMousePosition();
                        cursorData.Position = new Point(cursorPosition.X - iconInfo.xHotspot, cursorPosition.Y - iconInfo.yHotspot);

                        cursorData.Icon = Icon.FromHandle(hIcon);

                        if (iconInfo.hbmMask != IntPtr.Zero)
                        {
                            NativeMethods.DeleteObject(iconInfo.hbmMask);
                        }

                        if (iconInfo.hbmColor != IntPtr.Zero)
                        {
                            NativeMethods.DeleteObject(iconInfo.hbmColor);
                        }
                    }
                }
            }

            return cursorData;
        }

        public static void DrawCursorToImage(Image img)
        {
            DrawCursorToImage(img, Point.Empty);
        }

        public static void DrawCursorToImage(Image img, Point offset)
        {
            try
            {
                using (CursorData cursor = CursorData.GetCursorData())
                {
                    if (cursor != null && cursor.IsVisible)
                    {
                        cursor.DrawIcon(img, offset);
                    }
                }
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e, "Cursor capture failed");
            }
        }

        public void DrawIcon(Image img, Point offset)
        {
            if (Icon != null)
            {
                Point position = new Point(Position.X - offset.X, Position.Y - offset.Y);

                using (Graphics g = Graphics.FromImage(img))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawIcon(Icon, position.X, position.Y);
                }
            }
        }

        public void Dispose()
        {
            if (Icon != null) Icon.Dispose();
        }
    }
}