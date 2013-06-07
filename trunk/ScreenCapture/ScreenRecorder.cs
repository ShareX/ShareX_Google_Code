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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

namespace ScreenCapture
{
    public class ScreenRecorder : IDisposable
    {
        public bool IsRecording { get; private set; }
        public bool WriteCompressed { get; set; }

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

        public delegate void ProgressEventHandler(float progress);
        public event ProgressEventHandler EncodingProgressChanged;

        private int fps, delay, frameCount;
        private float durationSeconds;
        private Rectangle captureRectangle;
        private ScreenRecorderCache cache;

        public ScreenRecorder(int fps, float durationSeconds, Rectangle captureRectangle, string cachePath, bool writeCompressed)
        {
            if (string.IsNullOrEmpty(cachePath))
            {
                throw new Exception("Screen recorder cache path is empty.");
            }

            FPS = fps;
            DurationSeconds = durationSeconds;
            CaptureRectangle = captureRectangle;
            CachePath = cachePath;
            WriteCompressed = writeCompressed;
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

                using (cache = new ScreenRecorderCache(CachePath))
                {
                    for (int i = 0; i < frameCount; i++)
                    {
                        Stopwatch timer = Stopwatch.StartNew();
                        Image img = Screenshot.CaptureRectangle(CaptureRectangle);

                        cache.AddImageAsync(img);

                        if (i + 1 < frameCount)
                        {
                            int sleepTime = delay - (int)timer.ElapsedMilliseconds;

                            if (sleepTime > 0)
                            {
                                Thread.Sleep(sleepTime);
                            }
                            else
                            {
                                Debug.WriteLine("FPS drop: " + sleepTime);
                            }
                        }
                    }

                    cache.Finish();
                }

                IsRecording = false;
            }
        }

        public void SaveAsGIF(string path, GIFQuality quality)
        {
            if (!IsRecording)
            {
                using (GifCreator gifEncoder = new GifCreator(delay))
                {
                    int i = 0;
                    int count = cache.Count;

                    foreach (Image img in cache.GetImageEnumerator())
                    {
                        i++;
                        OnEncodingProgressChanged((float)i / count * 100);

                        using (img)
                        {
                            gifEncoder.AddFrame(img, quality);
                        }
                    }

                    gifEncoder.Finish();
                    gifEncoder.Save(path);
                }
            }
        }

        public void SaveAsAVI(string path, int heightLimit = 720)
        {
            if (!IsRecording)
            {
                using (AVIManager aviManager = new AVIManager(path, FPS))
                {
                    int i = 0;
                    int count = cache.Count;

                    foreach (Image img in cache.GetImageEnumerator())
                    {
                        i++;
                        OnEncodingProgressChanged((float)i / count * 100);
                        Image img2 = img;

                        try
                        {
                            if (heightLimit > 0 && CaptureRectangle.Height > heightLimit)
                            {
                                int width = (int)((float)heightLimit / CaptureRectangle.Height * captureRectangle.Width);
                                img2 = CaptureHelpers.ResizeImage(img2, width, heightLimit);
                            }

                            aviManager.AddFrame(img2, WriteCompressed);
                        }
                        finally
                        {
                            if (img2 != null) img2.Dispose();
                        }
                    }
                }
            }
        }

        protected void OnEncodingProgressChanged(float progress)
        {
            if (EncodingProgressChanged != null)
            {
                EncodingProgressChanged(progress);
            }
        }

        public void Dispose()
        {
            if (cache != null)
            {
                cache.Dispose();
            }

            if (File.Exists(CachePath))
            {
                File.Delete(CachePath);
            }
        }
    }
}