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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace HelpersLib.Steam
{
    public class SteamScreenshotsWatchFolder : WatchFolder
    {
        public void Enable(string userDataPath)
        {
            string vdfPath = Path.Combine(userDataPath, @"760\screenshots.vdf");
            FolderPath = Path.GetDirectoryName(vdfPath);

            Dispose();

            if (!string.IsNullOrEmpty(FolderPath))
            {
                context = SynchronizationContext.Current;

                if (context == null)
                {
                    context = new SynchronizationContext();
                }

                fileWatcher = new FileSystemWatcher();
                fileWatcher.Path = FolderPath;
                fileWatcher.Filter = Path.GetFileName(vdfPath);
                if (!string.IsNullOrEmpty(Filter)) fileWatcher.Filter = Filter;
                fileWatcher.Created += fileWatcher_Changed;
                fileWatcher.Changed += fileWatcher_Changed;
                fileWatcher.EnableRaisingEvents = true;
            }
        }

        private void fileWatcher_Changed(object sender, FileSystemEventArgs e)
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

            Action onCompleted = () =>
            {
                try
                {
                    SteamScreenshotsParse parse = new SteamScreenshotsParse();
                    parse.Parse(path);
                    string ssPath = parse.GetLastScreenshotPath().Replace('/', '\\');
                    ssPath = Path.Combine(Path.Combine(FolderPath, "remote"), ssPath);
                    context.Post(state => OnFileWatcherTrigger(ssPath), null);
                }
                catch { }
            };
            Helpers.WaitWhileAsync(() => Helpers.IsFileLocked(path), 250, 5000, onCompleted, 1000);
        }
    }
}