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
        public bool IsRecording { get; private set; }

        public int FPS
        {
            get
            {
                return fps;
            }
            set
            {
                if (!IsRecording)
                {
                    fps = value;
                    UpdateInfo();
                }
            }
        }

        public float DurationSeconds
        {
            get
            {
                return durationSeconds;
            }
            set
            {
                if (!IsRecording)
                {
                    durationSeconds = value;
                    UpdateInfo();
                }
            }
        }

        public Rectangle CaptureRectangle
        {
            get
            {
                return captureRectangle;
            }
            private set
            {
                if (!IsRecording)
                {
                    captureRectangle = value;
                }
            }
        }

        public string CachePath { get; private set; }

        private int fps, delay, frameCount;
        private float durationSeconds;
        private Rectangle captureRectangle;
        private List<LocationInfo> indexList;

        public ScreenRecorder(int fps, float durationSeconds, Rectangle captureRectangle, string cachePath)
        {
            if (string.IsNullOrEmpty(cachePath))
            {
                throw new Exception("Screen recorder cache path is empty.");
            }

            FPS = fps;
            DurationSeconds = durationSeconds;
            CaptureRectangle = captureRectangle;
            CachePath = cachePath;
        }

        private void UpdateInfo()
        {
            delay = 1000 / fps;
            frameCount = (int)(fps * durationSeconds);
        }

        public void StartRecording()
        {
            if (!IsRecording)
            {
                IsRecording = true;

                using (FileStream fsCache = new FileStream(CachePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    indexList = new List<LocationInfo>();

                    for (int i = 0; i < frameCount; i++)
                    {
                        Stopwatch timer = Stopwatch.StartNew();
                        Image img = Screenshot.CaptureRectangle(CaptureRectangle);

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

                IsRecording = false;
            }
        }

        public void SaveAsGIF(string path, GIFQuality quality)
        {
            if (!IsRecording && File.Exists(CachePath) && indexList != null && indexList.Count > 0)
            {
                using (GifCreator gifEncoder = new GifCreator(delay))
                using (FileStream fsCache = new FileStream(CachePath, FileMode.Open, FileAccess.Read, FileShare.Read))
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

        public void SaveAsAVI(string path, int heightLimit = 720)
        {
            if (!IsRecording && File.Exists(CachePath) && indexList != null && indexList.Count > 0)
            {
                using (AVIManager aviManager = new AVIManager(path, FPS))
                using (FileStream fsCache = new FileStream(CachePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    foreach (LocationInfo index in indexList)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fsCache.CopyStreamTo(ms, (int)index.Location, (int)index.Length);

                            Image img = null;

                            try
                            {
                                img = Image.FromStream(ms);

                                if (heightLimit > 0 && CaptureRectangle.Height > heightLimit)
                                {
                                    int width = (int)((float)heightLimit / CaptureRectangle.Height * captureRectangle.Width);
                                    img = CaptureHelpers.ResizeImage(img, width, heightLimit);
                                }

                                aviManager.AddFrame(img);
                            }
                            finally
                            {
                                if (img != null) img.Dispose();
                            }
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            if (File.Exists(CachePath))
            {
                File.Delete(CachePath);
            }
        }
    }
}