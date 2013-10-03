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

using HelpersLib.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelpersLib
{
    public partial class ColorMatrixTestForm : Form
    {
        public ColorMatrixTestForm()
        {
            InitializeComponent();
            Icon = Resources.ShareXIcon;
            cbColorMatrix.Items.Add("Identity");
            cbColorMatrix.Items.Add("Inverse");
            cbColorMatrix.Items.Add("Alpha");
            cbColorMatrix.Items.Add("Brightness");
            cbColorMatrix.Items.Add("Contrast");
            cbColorMatrix.Items.Add("Grayscale");
            cbColorMatrix.Items.Add("Hue");
            cbColorMatrix.Items.Add("Saturation");
            cbColorMatrix.Items.Add("Colorize");
            cbColorMatrix.Items.Add("Gamma");
            cbColorMatrix.SelectedIndex = 0;
            pbSource.Image = Resources.tick;
        }

        private void UpdateResult()
        {
            float value = (float)nudValue.Value;

            switch (cbColorMatrix.Text)
            {
                case "Identity":
                    ShowResult(ColorMatrixManager.Identity());
                    break;
                case "Inverse":
                    ShowResult(ColorMatrixManager.Inverse());
                    break;
                case "Alpha":
                    ShowResult(ColorMatrixManager.Alpha(value, 0));
                    break;
                case "Brightness":
                    ShowResult(ColorMatrixManager.Brightness(value));
                    break;
                case "Contrast":
                    ShowResult(ColorMatrixManager.Contrast(value));
                    break;
                case "Grayscale":
                    ShowResult(ColorMatrixManager.Grayscale(value));
                    break;
                case "Hue":
                    ShowResult(ColorMatrixManager.Hue(value));
                    break;
                case "Saturation":
                    ShowResult(ColorMatrixManager.Saturation(value));
                    break;
                case "Colorize":
                    ShowResult(ColorMatrixManager.Colorize(Color.Red, value));
                    break;
                case "Gamma":
                    ShowResult(ColorMatrixManager.ChangeGamma(Resources.tick, value));
                    break;
            }
        }

        private void ShowResult(ColorMatrix colorMatrix)
        {
            ShowResult(colorMatrix.Apply(Resources.tick));
        }

        private void ShowResult(Image img)
        {
            if (pbResult.Image != null) pbResult.Image.Dispose();
            pbResult.Image = img;
        }

        private void cbColorMatrix_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void nudValue_ValueChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }
    }
}