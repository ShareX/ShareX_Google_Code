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

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IndexerLib
{
    public class FolderInfo
    {
        public string FolderPath { get; set; }
        public long Size { get; set; }
        public List<FileInfo> Files { get; set; }
        public List<FolderInfo> Folders { get; set; }
        public FolderInfo Parent { get; set; }

        public string FolderName
        {
            get
            {
                return Path.GetFileName(FolderPath);
            }
        }

        public int TotalFileCount
        {
            get
            {
                return Files.Count + Folders.Sum(x => x.TotalFileCount);
            }
        }

        public int TotalFolderCount
        {
            get
            {
                return Folders.Count + Folders.Sum(x => x.TotalFolderCount);
            }
        }

        public FolderInfo(string folderPath)
        {
            FolderPath = folderPath;
            Files = new List<FileInfo>();
            Folders = new List<FolderInfo>();
        }
    }
}