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
using ScreenCapture;
using ShareX;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;

namespace ShareXTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TestScreenCaptureSpeed();
            Test();
            Console.ReadLine();
        }

        private static void Test()
        {
        }

        private static void TestScreenCaptureSpeed()
        {
            Rectangle rect = CaptureHelpers.GetScreenBounds();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + 1);

                Thread.Sleep(1000);

                DebugTimer timer1 = new DebugTimer();
                using (Image img1 = Screenshot.CaptureRectangleNative(rect))
                {
                    timer1.WriteElapsedMiliseconds("CaptureRectangleNative");
                }

                Thread.Sleep(1000);

                DebugTimer timer2 = new DebugTimer();
                using (Image img2 = Screenshot.CaptureRectangleNative2(NativeMethods.GetDesktopWindow(), rect))
                {
                    timer2.WriteElapsedMiliseconds("CaptureRectangleNative2");
                }

                Thread.Sleep(1000);

                DebugTimer timer3 = new DebugTimer();
                using (Image img3 = Screenshot.CaptureRectangleManaged(rect))
                {
                    timer3.WriteElapsedMiliseconds("CaptureRectangleManaged");

                    Thread.Sleep(1000);

                    DebugTimer timer4 = new DebugTimer();
                    Point cursorOffset = CaptureHelpers.FixScreenCoordinates(rect.Location);
                    CaptureHelpers.DrawCursorToImage(img3, cursorOffset);
                    timer4.WriteElapsedMiliseconds("DrawCursorToImage");
                }
            }
        }
    }
}