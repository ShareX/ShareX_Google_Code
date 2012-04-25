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

using System.IO;
using System.Text.RegularExpressions;
using IndexersLib.Helpers;

namespace IndexersLib
{
    public class FilterHelper
    {
        private IndexerAdapter mSettings;
        private string[] mBannedFilter;

        public FilterHelper(IndexerAdapter settings)
        {
            mSettings = settings;
            mBannedFilter = Regex.Split(mSettings.GetConfig().IgnoreFilesList, "\\" + mSettings.GetOptions().IgnoreFilesListDelimiter);
        }

        public bool isBannedFolder(TreeDir dir)
        {
            // Check if Option set to Enable Filtering
            if (mSettings.GetConfig().EnabledFiltering)
            {
                DirectoryInfo di = new DirectoryInfo(dir.DirectoryPath());
                FileAttributesEx dirAttrib = new FileAttributesEx(dir.DirectoryPath());

                string[] c = dir.DirectoryPath().Split(Path.DirectorySeparatorChar);
                // If Options says to filter protected OS folders
                if (mSettings.GetConfig().HideProtectedOperatingSystemFilesFolders)
                {
                    return c[1].Length != 0 && dirAttrib.isReadOnlyDirectory() && mSettings.GetConfig().HideProtectedOperatingSystemFilesFolders;
                }

                // If Config says to filter Hidden Folders
                if (mSettings.GetConfig().IgnoreHiddenFolders)
                {
                    return dirAttrib.isHidden();
                }

                // If Config says to filter System Folders
                if (mSettings.GetConfig().IgnoreSystemFolders)
                {
                    return dirAttrib.isSystem();
                }

                //war59312: If Config says to filter Empty Folders
                if (mSettings.GetConfig().IgnoreEmptyFolders && dir.DirectorySize() == 0.0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsBannedFile(string filePath)
        {
            // Check if Option set to Enable Filtering
            if (mSettings.GetConfig().EnabledFiltering)
            {
                // Establish an FileInfo, we need for the checks below
                FileAttributesEx fi = new FileAttributesEx(filePath);

                // If Options says to filter protected OS files
                if (mSettings.GetConfig().HideProtectedOperatingSystemFilesFolders)
                {
                    return fi.isHiddenSystemFile();
                }

                // If Config says to filter Hidden Files
                if (mSettings.GetConfig().IgnoreHiddenFiles)
                {
                    return fi.isHidden();
                }

                // If Config says to filter System Files
                if (mSettings.GetConfig().IgnoreSystemFiles)
                {
                    return fi.isSystem();
                }

                // If Config says to filter following files
                if (mSettings.GetConfig().IgnoreFollowingFiles)
                {
                    foreach (string item in mBannedFilter)
                    {
                        if (Path.GetFileName(filePath).ToLower() == item.ToLower())
                        {
                            return true;
                        }
                        if (item.IndexOf("*.") != -1 && item.IndexOf(Path.GetExtension(filePath)) != -1)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}