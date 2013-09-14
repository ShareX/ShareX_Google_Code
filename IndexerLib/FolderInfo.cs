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
        public string FolderPath { get; private set; }
        public long Size { get; private set; }
        public List<FileInfo> Files { get; private set; }
        public List<FolderInfo> Folders { get; private set; }

        public FolderInfo(string folderPath)
        {
            FolderPath = folderPath;
            Files = new List<FileInfo>();
            Folders = new List<FolderInfo>();
        }

        public void Read()
        {
            Read(this);
        }

        public string FolderName
        {
            get
            {
                return Path.GetFileName(FolderPath);
            }
        }

        private FolderInfo Read(FolderInfo dir)
        {
            foreach (string fp in Directory.GetFiles(dir.FolderPath))
            {
                dir.Files.Add(new FileInfo(fp));
            }

            dir.Size = dir.Files.Sum(x => x.Length);

            foreach (string dp in Directory.GetDirectories(dir.FolderPath))
            {
                FolderInfo subdir = new FolderInfo(dp);
                subdir.Read();
                dir.Folders.Add(subdir);
            }

            dir.Size += dir.Folders.Sum(x => x.Size);

            return dir;
        }
    }
}