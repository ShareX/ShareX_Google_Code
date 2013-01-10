using HelpersLib;
using ScreenCapture;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace ShareXTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestScreenCaptureSpeed();
            Console.ReadLine();
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