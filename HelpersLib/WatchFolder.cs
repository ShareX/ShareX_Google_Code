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

using HelpersLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace HelpersLib
{
    public class WatchFolder : IDisposable
    {
        private SynchronizationContext context;
        private FileSystemWatcher fileWatcher;
        private List<WatchFolderDuplicateEventTimer> timers = new List<WatchFolderDuplicateEventTimer>();

        public string FolderPath { get; set; }
        public string Filter { get; set; }
        public bool IncludeSubdirectories { get; set; }

        public delegate void FileWatcherTriggerEventHandler(string path);
        public event FileWatcherTriggerEventHandler FileWatcherTrigger;

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

        private void OnFileWatcherTrigger(string path)
        {
            if (FileWatcherTrigger != null)
            {
                FileWatcherTrigger(path);
            }
        }

        private void fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            CleanElapsedTimers();

            string path = e.FullPath;

            foreach (WatchFolderDuplicateEventTimer timer in timers)
            {
                if (timer.IsDuplicateEvent(path))
                {
                    return;
                }
            }

            timers.Add(new WatchFolderDuplicateEventTimer(path));

            Action onCompleted = () => context.Post(state => OnFileWatcherTrigger(path), null);
            Helpers.WaitWhileAsync(() => Helpers.IsFileLocked(path), 250, 5000, onCompleted, 1000);
        }

        private void CleanElapsedTimers()
        {
            for (int i = 0; i < timers.Count; i++)
            {
                if (timers[i].IsElapsed)
                {
                    timers.Remove(timers[i]);
                }
            }
        }

        public void Dispose()
        {
            if (fileWatcher != null)
            {
                fileWatcher.Dispose();
            }
        }
    }

    public class WatchFolderDuplicateEventTimer
    {
        private const int expireTime = 1000;

        private Stopwatch timer;
        private string path;

        public bool IsElapsed
        {
            get
            {
                return timer.ElapsedMilliseconds >= expireTime;
            }
        }

        public WatchFolderDuplicateEventTimer(string path)
        {
            timer = Stopwatch.StartNew();
            this.path = path;
        }

        public bool IsDuplicateEvent(string path)
        {
            bool result = path == this.path && !IsElapsed;
            if (result)
            {
                timer = Stopwatch.StartNew();
            }
            return result;
        }
    }
}