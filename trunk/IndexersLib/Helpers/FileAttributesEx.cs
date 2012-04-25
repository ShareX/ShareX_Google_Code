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

namespace ZSS.IndexersLib.Helpers
{
    public class FileAttributesEx
    {
        public string FilePath { get; set; }

        public FileAttributesEx() { }

        public FileAttributesEx(string path)
        {
            FilePath = path;
        }

        public bool isReadOnlyDirectory()
        {
            return isDirectory() && isReadOnly();
        }

        public bool isDirectory()
        {
            return (File.GetAttributes(FilePath) & FileAttributes.Directory) == FileAttributes.Directory;
        }

        public bool isReadOnly()
        {
            return (File.GetAttributes(FilePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
        }

        public bool isHidden()
        {
            return (File.GetAttributes(FilePath) & FileAttributes.Hidden) == FileAttributes.Hidden;
        }

        public bool isArchive()
        {
            return (File.GetAttributes(FilePath) & FileAttributes.Archive) == FileAttributes.Archive;
        }

        public bool isSystem()
        {
            return (File.GetAttributes(FilePath) & FileAttributes.System) == FileAttributes.System;
        }

        public bool isHiddenSystemFile()
        {
            return isHidden() && isSystem() && isArchive();
        }

        public void AddSystem()
        {
            File.SetAttributes(FilePath, File.GetAttributes(FilePath) | FileAttributes.System);
        }

        public void AddReadOnly()
        {
            File.SetAttributes(FilePath, File.GetAttributes(FilePath) | FileAttributes.ReadOnly);
        }

        public void AddHidden()
        {
            File.SetAttributes(FilePath, File.GetAttributes(FilePath) | FileAttributes.Hidden);
        }

        public void AddArchive()
        {
            File.SetAttributes(FilePath, File.GetAttributes(FilePath) | FileAttributes.Archive);
        }

        public void Clear()
        {
            File.SetAttributes(FilePath, File.GetAttributes(FilePath)
            & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.System | FileAttributes.Hidden));
        }
    }
}