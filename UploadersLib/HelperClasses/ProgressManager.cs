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
using System.Diagnostics;
using System.Linq;

namespace ShareX.HelperClasses
{
    public class ProgressManager
    {
        public long Length { get; private set; }
        public long Position { get; set; }
        public double Percentage { get; private set; }
        public double Speed { get; private set; }
        public TimeSpan Elapsed { get; private set; }
        public TimeSpan Remaining { get; private set; }

        private Stopwatch startTimer = new Stopwatch();
        private Stopwatch smoothTimer = new Stopwatch();
        private int smoothTime;
        private long speedTest;
        private List<double> averageSpeed = new List<double>(10);

        public ProgressManager(long length, int smoothTime = 250)
        {
            Length = length;
            this.smoothTime = smoothTime;
            startTimer.Start();
            smoothTimer.Start();
        }

        public bool ChangeProgress(int bytesRead, bool cumulative = false)
        {
            if (!cumulative)
            {
                Position += bytesRead;
            }
            else
            {
                Position = bytesRead;
            }

            Percentage = (double)Position / Length * 100;
            speedTest += bytesRead;

            if (Position >= Length)
            {
                Elapsed = startTimer.Elapsed;
                Remaining = TimeSpan.Zero;

                return true;
            }

            if (smoothTimer.ElapsedMilliseconds > smoothTime)
            {
                if (averageSpeed.Count == 10)
                {
                    averageSpeed.RemoveAt(0);
                }

                averageSpeed.Add((double)speedTest / smoothTimer.ElapsedMilliseconds);

                Speed = averageSpeed.Average();
                Elapsed = startTimer.Elapsed;
                Remaining = TimeSpan.FromMilliseconds((Length - Position) / Speed);

                speedTest = 0;
                smoothTimer.Reset();
                smoothTimer.Start();

                return true;
            }

            return false;
        }
    }
}