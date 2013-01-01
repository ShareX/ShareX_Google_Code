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

using HelpersLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ScreenCapture
{
    public class ScreenRecorder : IDisposable
    {
        private bool isWorking;
        private int fps, delay, frameCount;
        private float durationSeconds;
        private Rectangle captureRect;
        private string cachePath;
        private List<LocationInfo> indexList;

        public ScreenRecorder(int fps, float durationSeconds, Rectangle captureRect, string cachePath)
        {
            this.fps = fps;
            this.durationSeconds = durationSeconds;
            this.captureRect = captureRect;
            this.cachePath = cachePath;

            delay = 1000 / fps;
            frameCount = (int)(fps * durationSeconds);

            if (string.IsNullOrEmpty(cachePath))
            {
                throw new Exception("Screen recorder cache path is empty.");
            }
        }

        public void StartRecording()
        {
            if (!isWorking)
            {
                isWorking = true;

                using (FileStream fsCache = new FileStream(cachePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    indexList = new List<LocationInfo>();

                    for (int i = 0; i < frameCount; i++)
                    {
                        Stopwatch timer = Stopwatch.StartNew();
                        Image img = Screenshot.CaptureRectangle(captureRect);

                        long position = fsCache.Position;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            img.Save(ms, ImageFormat.Bmp);
                            ms.CopyStreamTo(fsCache);
                        }
                        indexList.Add(new LocationInfo(position, fsCache.Length - position));

                        int sleepTime = delay - (int)timer.ElapsedMilliseconds;
                        if (sleepTime > 0)
                        {
                            Thread.Sleep(sleepTime);
                        }
                    }
                }

                isWorking = false;
            }
        }

        public void SaveAsGIF(string path, GIFQuality quality)
        {
            if (!isWorking && File.Exists(cachePath) && indexList != null && indexList.Count > 0)
            {
                using (GifCreator gifEncoder = new GifCreator(delay))
                using (FileStream fsCache = new FileStream(cachePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    foreach (LocationInfo index in indexList)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fsCache.CopyStreamTo(ms, (int)index.Location, (int)index.Length);

                            using (Image img = Image.FromStream(ms))
                            {
                                gifEncoder.AddFrame(img, quality);
                            }
                        }
                    }

                    gifEncoder.Finish();
                    gifEncoder.Save(path);
                }
            }
        }

        public void SaveAsAVI(string path)
        {
            if (!isWorking && File.Exists(cachePath) && indexList != null && indexList.Count > 0)
            {
                using (AVIManager aviManager = new AVIManager(path, fps))
                using (FileStream fsCache = new FileStream(cachePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    foreach (LocationInfo index in indexList)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fsCache.CopyStreamTo(ms, (int)index.Location, (int)index.Length);

                            using (Image img = Image.FromStream(ms))
                            {
                                aviManager.AddFrame(img);
                            }
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            if (File.Exists(cachePath))
            {
                File.Delete(cachePath);
            }
        }
    }
}