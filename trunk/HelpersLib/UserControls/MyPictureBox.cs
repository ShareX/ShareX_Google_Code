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

using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HelpersLib
{
    public partial class MyPictureBox : UserControl
    {
        public bool DisableViewer { get; set; }

        public Image LoadingImage
        {
            set { pbMain.InitialImage = value; }
        }

        public PictureBoxSizeMode SizeMode
        {
            set { pbMain.SizeMode = value; }
        }

        private bool isReady;
        private bool isLoadLocal;

        public MyPictureBox()
        {
            InitializeComponent();
            pbMain.LoadCompleted += new AsyncCompletedEventHandler(pbMain_LoadCompleted);
            pbMain.LoadProgressChanged += new ProgressChangedEventHandler(pbMain_LoadProgressChanged);
        }

        public void LoadImage(Image img, PictureBoxSizeMode sizeMode = PictureBoxSizeMode.Zoom)
        {
            pbMain.SizeMode = sizeMode;
            pbMain.Image = (Image)img.Clone();
            isReady = true;
        }

        public void LoadImage(string imagePath, string imageURL)
        {
            if (!string.IsNullOrEmpty(imagePath) && Helpers.IsImageFile(imagePath) && File.Exists(imagePath))
            {
                lblStatus.Text = "Loading local image...";
                isLoadLocal = true;
                LoadImage(imagePath);
            }
            else if (!string.IsNullOrEmpty(imageURL) && Helpers.IsImageFile(imageURL))
            {
                lblStatus.Text = "Downloading image from URL...";
                isLoadLocal = false;
                LoadImage(imageURL);
            }
        }

        private void LoadImage(string path)
        {
            isReady = false;
            lblStatus.Visible = true;
            this.Cursor = Cursors.Default;
            pbMain.LoadAsync(path);
        }

        public void SetNote(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                lblStatus.Text = text;
                lblStatus.Visible = true;
            }
        }

        public void Reset()
        {
            pbMain.Image = null;
        }

        private void pbMain_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            isReady = true;
            lblStatus.Visible = false;
            this.Cursor = Cursors.Hand;
        }

        private void pbMain_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string status;

            if (isLoadLocal)
            {
                status = "Loading local image - ";
            }
            else
            {
                status = "Downloading image from URL - ";
            }

            status += e.ProgressPercentage + "%";
            lblStatus.Text = status;
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (!DisableViewer && e.Button == MouseButtons.Left && isReady && pbMain.Image != null)
            {
                using (ImageViewer viewer = new ImageViewer(pbMain.Image))
                {
                    viewer.ShowDialog();
                }
            }
        }
    }
}