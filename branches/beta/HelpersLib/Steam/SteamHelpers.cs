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

using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace HelpersLib.Steam
{
    public static class SteamHelpers
    {
        public static string GetSteamDirectory()
        {
            string steamPath = string.Empty;

            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam", false);

                if (reg != null)
                {
                    steamPath = reg.GetValue("SteamPath") as string;
                }

                if (string.IsNullOrEmpty(steamPath))
                {
                    reg = Registry.LocalMachine.OpenSubKey(@"Software\Valve\Steam", false);

                    if (reg != null)
                    {
                        steamPath = reg.GetValue("InstallPath") as string;
                    }
                }

                if (string.IsNullOrEmpty(steamPath))
                {
                    reg = Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Valve\Steam", false);

                    if (reg != null)
                    {
                        steamPath = reg.GetValue("InstallPath") as string;
                    }
                }

                if (!string.IsNullOrEmpty(steamPath))
                {
                    steamPath = steamPath.Trim().Replace('/', '\\');
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            return steamPath;
        }

        public static string GetSteamUserDataDirectory()
        {
            string steamPath = GetSteamDirectory();

            if (!string.IsNullOrEmpty(steamPath))
            {
                string steamPathUserData = Path.Combine(steamPath, "userdata");

                string[] folders = Directory.GetDirectories(steamPathUserData);

                foreach (string folder in folders)
                {
                    if (Path.GetFileName(folder).IsNumber())
                    {
                        return folder;
                    }
                }
            }

            return string.Empty;
        }
    }
}