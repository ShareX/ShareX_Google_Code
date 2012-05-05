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
using System.Windows.Forms;
using Microsoft.Win32;

namespace HelpersLib
{
    public static class RegistryHelper
    {
        private static string WindowsStartupRun = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private static string ApplicationPath = string.Format("\"{0}\"", Application.ExecutablePath);
        private static string StartupPath = ApplicationPath + " -silent";

        private static string ShellExtMenuFiles = @"Software\Classes\*\shell\" + Application.ProductName;
        private static string ShellExtMenuFilesCmd = ShellExtMenuFiles + @"\command";

        private static string ShellExtMenuFolders = @"Software\Classes\Folder\shell\" + Application.ProductName;
        private static string ShellExtMenuFoldersCmd = ShellExtMenuFolders + @"\command";

        private static string ShellExtDesc = "Upload using " + Application.ProductName;
        private static string ShellExtPath = string.Format("{0} \"%1\"", ApplicationPath);

        public static bool CheckStartWithWindows()
        {
            try
            {
                return CheckRegistry(WindowsStartupRun, Application.ProductName, StartupPath);
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }

            return false;
        }

        public static void SetStartWithWindows(bool startWithWindows)
        {
            try
            {
                using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(WindowsStartupRun, true))
                {
                    if (regkey != null)
                    {
                        if (startWithWindows)
                        {
                            regkey.SetValue(Application.ProductName, StartupPath, RegistryValueKind.String);
                        }
                        else
                        {
                            regkey.DeleteValue(Application.ProductName, false);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }
        }

        public static bool CheckShellContextMenu()
        {
            try
            {
                return CheckRegistry(ShellExtMenuFilesCmd) && CheckRegistry(ShellExtMenuFoldersCmd);
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }

            return false;
        }

        public static void SetShellContextMenu(bool shellContextMenu)
        {
            try
            {
                if (shellContextMenu)
                {
                    RegisterShellContextMenu();
                }
                else
                {
                    UnregisterShellContextMenu();
                }
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }
        }

        public static void RegisterShellContextMenu()
        {
            CreateRegistryKey(ShellExtMenuFiles, ShellExtDesc);
            CreateRegistryKey(ShellExtMenuFilesCmd, ShellExtPath);
            CreateRegistryKey(ShellExtMenuFolders, ShellExtDesc);
            CreateRegistryKey(ShellExtMenuFoldersCmd, ShellExtPath);
        }

        public static void UnregisterShellContextMenu()
        {
            RemoveRegistryKey(ShellExtMenuFilesCmd);
            RemoveRegistryKey(ShellExtMenuFiles);
            RemoveRegistryKey(ShellExtMenuFoldersCmd);
            RemoveRegistryKey(ShellExtMenuFolders);
        }

        private static void CreateRegistryKey(string path, string value, string name = null)
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(path))
            {
                if (rk != null)
                {
                    rk.SetValue(name, value);
                }
            }
        }

        private static void RemoveRegistryKey(string path)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(path))
            {
                if (rk != null)
                {
                    Registry.CurrentUser.DeleteSubKey(path);
                }
            }
        }

        private static bool CheckRegistry(string path, string name = null, string value = null)
        {
            string registryValue = GetRegistryValue(path, name);

            if (registryValue != null)
            {
                return value == null || registryValue.Equals(value, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }

        private static string GetRegistryValue(string path, string name = null)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(path))
            {
                if (rk != null)
                {
                    return rk.GetValue(name, null) as string;
                }
            }

            return null;
        }
    }
}