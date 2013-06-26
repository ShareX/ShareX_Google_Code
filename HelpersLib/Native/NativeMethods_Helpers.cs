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
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HelpersLib
{
    public static partial class NativeMethods
    {
        public static string GetWindowText(IntPtr handle)
        {
            if (handle.ToInt32() > 0)
            {
                int length = GetWindowTextLength(handle);

                if (length > 0)
                {
                    StringBuilder sb = new StringBuilder(length + 1);

                    if (GetWindowText(handle, sb, sb.Capacity) > 0)
                    {
                        return sb.ToString();
                    }
                }
            }

            return null;
        }

        public static string GetClassName(IntPtr handle)
        {
            if (handle.ToInt32() > 0)
            {
                StringBuilder sb = new StringBuilder(256);

                if (GetClassName(handle, sb, sb.Capacity) > 0)
                {
                    return sb.ToString();
                }
            }

            return null;
        }

        public static IntPtr GetClassLongPtrSafe(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size > 4)
            {
                return GetClassLongPtr(hWnd, nIndex);
            }

            return new IntPtr(GetClassLong(hWnd, nIndex));
        }

        public static Icon GetSmallApplicationIcon(IntPtr handle)
        {
            IntPtr iconHandle = IntPtr.Zero;

            SendMessageTimeout(handle, (int)WindowsMessages.GETICON, ICON_SMALL2, 0, SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 1000, out iconHandle);

            if (iconHandle == IntPtr.Zero)
            {
                SendMessageTimeout(handle, (int)WindowsMessages.GETICON, ICON_SMALL, 0, SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 1000, out iconHandle);

                if (iconHandle == IntPtr.Zero)
                {
                    iconHandle = GetClassLongPtrSafe(handle, GCL_HICONSM);

                    if (iconHandle == IntPtr.Zero)
                    {
                        SendMessageTimeout(handle, (int)WindowsMessages.QUERYDRAGICON, 0, 0, SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 1000, out iconHandle);
                    }
                }
            }

            if (iconHandle != IntPtr.Zero)
            {
                return Icon.FromHandle(iconHandle);
            }

            return null;
        }

        public static Icon GetBigApplicationIcon(IntPtr handle)
        {
            IntPtr iconHandle = IntPtr.Zero;

            SendMessageTimeout(handle, (int)WindowsMessages.GETICON, ICON_BIG, 0, SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 1000, out iconHandle);

            if (iconHandle == IntPtr.Zero)
            {
                iconHandle = GetClassLongPtrSafe(handle, GCL_HICON);
            }

            if (iconHandle != IntPtr.Zero)
            {
                return Icon.FromHandle(iconHandle);
            }

            return null;
        }

        public static Icon GetApplicationIcon(IntPtr handle)
        {
            Icon icon = null;

            icon = GetSmallApplicationIcon(handle);

            if (icon == null)
            {
                icon = GetBigApplicationIcon(handle);
            }

            return icon;
        }

        public static string GetForegroundWindowText()
        {
            IntPtr handle = GetForegroundWindow();
            return GetWindowText(handle);
        }

        public static string GetWindowLabel()
        {
            const int numOfChars = 256;
            IntPtr handle = GetForegroundWindow();
            StringBuilder sb = new StringBuilder(numOfChars);

            if (GetWindowText(handle, sb, numOfChars) > 0)
            {
                return sb.ToString();
            }

            return string.Empty;
        }

        public static IntPtr GetWindowHandle()
        {
            const int numOfChars = 256;
            IntPtr handle = GetForegroundWindow();
            StringBuilder sb = new StringBuilder(numOfChars);

            if (GetWindowText(handle, sb, numOfChars) > 0)
            {
                return handle;
            }

            return IntPtr.Zero;
        }

        public static bool GetBorderSize(IntPtr handle, out Size size)
        {
            WINDOWINFO wi = new WINDOWINFO();

            bool result = GetWindowInfo(handle, ref wi);

            if (result)
            {
                size = new Size((int)wi.cxWindowBorders, (int)wi.cyWindowBorders);
            }
            else
            {
                size = Size.Empty;
            }

            return result;
        }

        public static bool GetWindowRegion(IntPtr hWnd, out Region region)
        {
            IntPtr hRgn = NativeMethods.CreateRectRgn(0, 0, 0, 0);
            RegionType regionType = (RegionType)GetWindowRgn(hWnd, hRgn);
            region = Region.FromHrgn(hRgn);
            return regionType != RegionType.ERROR && regionType != RegionType.NULLREGION;
        }

        public static bool IsDWMEnabled()
        {
            return Environment.OSVersion.Version.Major >= 6 && DwmIsCompositionEnabled();
        }

        public static bool GetExtendedFrameBounds(IntPtr handle, out Rectangle rectangle)
        {
            RECT rect;
            int result = DwmGetWindowAttribute(handle, (int)DwmWindowAttribute.ExtendedFrameBounds, out rect, Marshal.SizeOf(typeof(RECT)));
            rectangle = (Rectangle)rect;
            return result == 0;
        }

        public static bool GetNCRenderingEnabled(IntPtr handle)
        {
            bool enabled;
            int result = DwmGetWindowAttribute(handle, (int)DwmWindowAttribute.NCRenderingEnabled, out enabled, sizeof(bool));
            return result == 0 && enabled;
        }

        public static void SetNCRenderingPolicy(IntPtr handle, DwmNCRenderingPolicy renderingPolicy)
        {
            int renderPolicy = (int)renderingPolicy;
            DwmSetWindowAttribute(handle, (int)DwmWindowAttribute.NCRenderingPolicy, ref renderPolicy, sizeof(int));
        }

        public static Rectangle GetWindowRect(IntPtr handle)
        {
            RECT rect;
            GetWindowRect(handle, out rect);
            return (Rectangle)rect;
        }

        public static Rectangle GetClientRect(IntPtr handle)
        {
            RECT rect;
            GetClientRect(handle, out rect);
            Point position = rect.Location;
            ClientToScreen(handle, ref position);
            return new Rectangle(position, rect.Size);
        }

        public static Rectangle MaximizedWindowFix(IntPtr handle, Rectangle windowRect)
        {
            Size size = Size.Empty;

            if (GetBorderSize(handle, out size))
            {
                windowRect = new Rectangle(windowRect.X + size.Width, windowRect.Y + size.Height, windowRect.Width - (size.Width * 2), windowRect.Height - (size.Height * 2));
            }

            return windowRect;
        }

        public static void ActivateWindow(IntPtr handle)
        {
            SetForegroundWindow(handle);
            SetActiveWindow(handle);
        }

        public static void ActivateWindowRepeat(IntPtr handle, int count)
        {
            for (int i = 0; NativeMethods.GetForegroundWindow() != handle && i < count; i++)
            {
                NativeMethods.BringWindowToTop(handle);
                Thread.Sleep(1);
                Application.DoEvents();
            }
        }

        public static Rectangle GetTaskbarRectangle()
        {
            APPBARDATA abd = APPBARDATA.NewAPPBARDATA();
            IntPtr retval = SHAppBarMessage((uint)ABMsg.ABM_GETTASKBARPOS, ref abd);
            return (Rectangle)abd.rc;
        }

        public static void SetTaskbarVisible(bool visible)
        {
            IntPtr taskbarHandle = NativeMethods.FindWindow("Shell_TrayWnd", null);
            NativeMethods.ShowWindow(taskbarHandle, visible ? (int)WindowShowStyle.Show : (int)WindowShowStyle.Hide);
        }

        public static void TrimMemoryUse()
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, (IntPtr)(-1), (IntPtr)(-1));
        }

        public static bool IsWindowMaximized(IntPtr handle)
        {
            WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
            wp.length = Marshal.SizeOf(wp);
            GetWindowPlacement(handle, ref wp);
            return wp.showCmd == WindowShowStyle.Maximize;
        }

        public static IntPtr SetHook(int hookType, HookProc hookProc)
        {
            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule currentModule = currentProcess.MainModule)
            {
                return SetWindowsHookEx(hookType, hookProc, GetModuleHandle(currentModule.ModuleName), 0);
            }
        }

        public static void RestoreWindow(IntPtr handle)
        {
            WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
            wp.length = Marshal.SizeOf(wp);
            GetWindowPlacement(handle, ref wp);

            if (wp.flags == (int)WindowPlacementFlags.WPF_RESTORETOMAXIMIZED)
            {
                wp.showCmd = WindowShowStyle.ShowMaximized;
            }
            else
            {
                wp.showCmd = WindowShowStyle.Restore;
            }

            SetWindowPlacement(handle, ref wp);
        }
    }
}