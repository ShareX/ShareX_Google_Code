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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using HelpersLib;
using UpdateCheckerLib;
using UploadersLib;

namespace ShareX
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Text = Program.Title;
            lblProductName.Text = Program.FullTitle;
            lblCopyright.Text = Program.AssemblyCopyright;

            UpdateChecker updateChecker = new UpdateChecker(Links.URL_UPDATE, Application.ProductName, Program.AssemblyVersion,
                ReleaseChannelType.Stable, Uploader.ProxySettings.GetWebProxy);
            uclUpdate.CheckUpdate(updateChecker);
        }

        private void AboutForm_Shown(object sender, EventArgs e)
        {
            BringToFront();
            Activate();

            cLogo.Start();
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cLogo.Stop();
        }

        private void lblProjectPage_Click(object sender, EventArgs e)
        {
            Helpers.LoadBrowserAsync(Links.URL_WEBSITE);
        }

        private void lblBugs_Click(object sender, EventArgs e)
        {
            Helpers.LoadBrowserAsync(Links.URL_ISSUES);
        }

        private void pbBerkURL_Click(object sender, EventArgs e)
        {
            Helpers.LoadBrowserAsync(Links.URL_BERK);
        }

        private void pbMikeURL_Click(object sender, EventArgs e)
        {
            Helpers.LoadBrowserAsync(Links.URL_MIKE);
        }

        #region Animation

        private const int w = 200;
        private const int h = w;
        private const int mX = w / 2;
        private const int mY = h / 2;
        private const int minStep = 3;
        private const int maxStep = 30;
        private const int speed = 1;
        private int step = 10;
        private int direction = speed;

        private void cLogo_Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.TranslateTransform(mX, -(mY / 2));
            g.RotateTransform(45);

            for (int i = 0; i <= mX; i += step)
            {
                g.DrawLine(Pens.Black, i, mY, mX, mY + i); // Left top
                g.DrawLine(Pens.Black, i, mY, mX, mY - i); // Left bottom
                g.DrawLine(Pens.Black, w - i, mY, mX, mY - i); // Right top
                g.DrawLine(Pens.Black, w - i, mY, mX, mY + i); // Right bottom
            }

            g.DrawLine(Pens.Black, mX, mY, mX, mY + mX); // Left top
            g.DrawLine(Pens.Black, mX, mY, mX, mY - mX); // Left bottom
            g.DrawLine(Pens.Black, w - mX, mY, mX, mY - mX); // Right top
            g.DrawLine(Pens.Black, w - mX, mY, mX, mY + mX); // Right bottom

            if (step + speed > maxStep)
            {
                direction = -speed;
            }
            else if (step - speed < minStep)
            {
                direction = speed;
            }

            step += direction;
        }

        #endregion Animation
    }
}