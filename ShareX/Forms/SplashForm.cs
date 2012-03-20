#region License Information (GPL v3)

/*
    ShareX - A program that allows to you take screenshots and share any file type
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

using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ShareX
{
    public class SplashForm : Form
    {
        private static Thread splashThread;
        private static SplashForm splashForm;

        public SplashForm(Image splashImage)
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(splashImage.Width, splashImage.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = splashImage;
            this.Name = "SplashForm";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        public static void ShowSplash()
        {
            if (splashThread == null)
            {
                splashThread = new Thread(DoShowSplash);
                splashThread.IsBackground = true;
                splashThread.Start();
            }
        }

        public static void CloseSplash()
        {
            if (splashThread != null)
            {
                if (splashForm.InvokeRequired)
                {
                    splashForm.Invoke(new MethodInvoker(CloseSplash));
                }
                else
                {
                    Application.ExitThread();
                }
            }
        }

        private static void DoShowSplash()
        {
            if (splashForm == null)
            {
                // splashForm = new SplashForm(Resources.ShareXLogo);
            }

            Application.Run(splashForm);
        }

        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}