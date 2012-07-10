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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using HelpersLib;

namespace ShareX
{
    public class WatchFolder : IDisposable
    {
        private SynchronizationContext context;
        private FileSystemWatcher fileWatcher;

        public string FolderPath { get; set; }
        public string Filter { get; set; }
        public bool IncludeSubdirectories { get; set; }

        public void Enable()
        {
            Dispose();

            if (!string.IsNullOrEmpty(FolderPath) && Directory.Exists(FolderPath))
            {
                context = SynchronizationContext.Current;

                if (context == null)
                {
                    context = new SynchronizationContext();
                }

                fileWatcher = new FileSystemWatcher(FolderPath);
                if (!string.IsNullOrEmpty(Filter)) fileWatcher.Filter = Filter;
                fileWatcher.IncludeSubdirectories = IncludeSubdirectories;
                fileWatcher.Created += new FileSystemEventHandler(fileWatcher_Created);
                fileWatcher.EnableRaisingEvents = true;
            }
        }

        private void fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            Action onCompleted = () => context.Post(state => UploadManager.UploadFile(path), null);
            Helpers.WaitWhileAsync(() => Helpers.IsFileLocked(path), 250, 5000, onCompleted);
        }

        public void Dispose()
        {
            if (fileWatcher != null) fileWatcher.Dispose();
        }
    }
}