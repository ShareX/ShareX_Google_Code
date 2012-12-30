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
    public class ScreenRecorder
    {
        private static string tempFolderName = "TempVideos";
        private static string tempFolderPath = Path.Combine(Application.StartupPath, tempFolderName);
        private bool isWorking;

        private int fps, delay, frameCount;
        private float durationSeconds;
        private Rectangle captureRect;

        public ScreenRecorder(int fps, float durationSeconds, Rectangle captureRect)
        {
            this.fps = fps;
            this.durationSeconds = durationSeconds;
            this.captureRect = captureRect;

            delay = 1000 / fps;
            frameCount = (int)(fps * durationSeconds);
        }

        public void StartRecording()
        {
            if (!isWorking)
            {
                isWorking = true;

                PrepareTempFolder();

                for (int i = 0; i < frameCount; i++)
                {
                    string path = Path.Combine(tempFolderPath, i.ToString("d5") + ".png");

                    using (Image img = Screenshot.CaptureRectangle(captureRect))
                    {
                        img.Save(path, ImageFormat.Png);
                    }

                    Thread.Sleep(delay);
                }

                isWorking = false;
            }
        }

        private void PrepareTempFolder()
        {
            if (Directory.Exists(tempFolderPath))
            {
                Directory.Delete(tempFolderPath, true);
            }

            Directory.CreateDirectory(tempFolderPath);
        }

        public void ClearTempFolder()
        {
            if (Directory.Exists(tempFolderPath))
            {
                Directory.Delete(tempFolderPath, true);
            }
        }

        public void MakeGIF(string path, GIFQuality quality = GIFQuality.Default)
        {
            using (AnimatedGif gifEncoder = new AnimatedGif(delay))
            {
                foreach (string file in Directory.GetFiles(tempFolderPath, "*.png", SearchOption.TopDirectoryOnly))
                {
                    gifEncoder.AddFrame(file, quality);
                }

                gifEncoder.Finish();
                gifEncoder.Save(path);
            }
        }
    }
}