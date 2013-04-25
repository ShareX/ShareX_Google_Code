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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HelpersLib
{
    public partial class MyPictureBox : UserControl
    {
        private string text;

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;

                if (string.IsNullOrEmpty(value))
                {
                    lblStatus.Visible = false;
                }
                else
                {
                    lblStatus.Text = value;
                    lblStatus.Visible = true;
                }
            }
        }

        private bool drawCheckeredBackground = false;

        [DefaultValue(false)]
        public bool DrawCheckeredBackground
        {
            get
            {
                return drawCheckeredBackground;
            }
            set
            {
                drawCheckeredBackground = value;
                UpdateCheckers();
            }
        }

        private bool fullscreenOnClick = false;

        [DefaultValue(false)]
        public bool FullscreenOnClick
        {
            get
            {
                return fullscreenOnClick;
            }
            set
            {
                fullscreenOnClick = value;
            }
        }

        public new event MouseEventHandler MouseDown
        {
            add
            {
                pbMain.MouseDown += value;
                lblStatus.MouseDown += value;
            }
            remove
            {
                pbMain.MouseDown -= value;
                lblStatus.MouseDown -= value;
            }
        }

        private bool isReady;
        private bool isLoadLocal;

        public MyPictureBox()
        {
            InitializeComponent();
            Text = string.Empty;
            pbMain.InitialImage = Resources.Loading;
            pbMain.LoadProgressChanged += new ProgressChangedEventHandler(pbMain_LoadProgressChanged);
            pbMain.LoadCompleted += new AsyncCompletedEventHandler(pbMain_LoadCompleted);
            pbMain.Resize += pbMain_Resize;
            MouseDown += MyPictureBox_MouseDown;
        }

        private void pbMain_Resize(object sender, EventArgs e)
        {
            UpdateCheckers();
            AutoSetSizeMode();
        }

        private void UpdateCheckers()
        {
            if (DrawCheckeredBackground)
            {
                if (pbMain.BackgroundImage == null || pbMain.BackgroundImage.Size != pbMain.ClientSize)
                {
                    pbMain.BackgroundImage = CaptureHelpers.CreateCheckers(8, Color.LightGray, Color.White);
                }
            }
            else
            {
                pbMain.BackgroundImage = null;
            }
        }

        public void LoadImage(Image img)
        {
            pbMain.Image = (Image)img.Clone();
            AutoSetSizeMode();
            isReady = true;
        }

        public void LoadImageFromFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                Text = "Loading local image...";
                isLoadLocal = true;
                LoadImage(filePath);
            }
        }

        public void LoadImageFromURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Text = "Downloading image from URL...";
                isLoadLocal = false;
                LoadImage(url);
            }
        }

        private void LoadImage(string path)
        {
            isReady = false;
            lblStatus.Visible = true;
            if (FullscreenOnClick)
            {
                Cursor = Cursors.Default;
            }
            pbMain.LoadAsync(path);
        }

        public void Reset()
        {
            pbMain.Image = null;
        }

        private void pbMain_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            AutoSetSizeMode();
            lblStatus.Visible = false;
            if (FullscreenOnClick)
            {
                Cursor = Cursors.Hand;
            }
            isReady = true;
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
            Text = status;
        }

        private void AutoSetSizeMode()
        {
            if (pbMain.Image != null)
            {
                if (pbMain.Image.Width > pbMain.ClientSize.Width || pbMain.Image.Height > pbMain.ClientSize.Height)
                {
                    pbMain.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbMain.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }

        private void MyPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (FullscreenOnClick && e.Button == MouseButtons.Left && isReady && pbMain.Image != null)
            {
                ImageViewer.ShowImage(pbMain.Image);
            }
        }
    }
}