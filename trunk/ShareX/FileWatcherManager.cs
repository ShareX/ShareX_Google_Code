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
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using HelpersLib;

namespace ShareX
{
    public class FileWatcherManager
    {
        public List<FileSystemWatcher> FileWatchers;

        public FileWatcherManager()
        {
            FileWatchers = new List<FileSystemWatcher>();
        }

        public void AddFileWatcher(string filepath)
        {
            FileSystemWatcher fileWatcher = new FileSystemWatcher(filepath);
            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.Created += new FileSystemEventHandler(fileWatcher_Created);
            FileWatchers.Add(fileWatcher);
        }

        private void fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            Helpers.WaitWhileAsync(() => Helpers.IsFileLocked(path), 250, 5000, () => UploadManager.UploadFile(path));
        }
    }
}