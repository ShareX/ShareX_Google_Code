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
using System.Linq;
using System.Windows.Forms;

namespace HelpersLib
{
    public partial class ClipboardContentViewer : Form
    {
        public bool IsClipboardEmpty { get; private set; }

        public bool DontShowThisWindow { get; private set; }

        public ClipboardContentViewer()
        {
            InitializeComponent();
        }

        private void ClipboardContentViewer_Load(object sender, EventArgs e)
        {
            pbClipboard.Visible = txtClipboard.Visible = lbClipboard.Visible = false;

            if (Clipboard.ContainsImage())
            {
                Image img = Clipboard.GetImage();

                if (img.Width > pbClipboard.ClientSize.Width || img.Height > pbClipboard.ClientSize.Height)
                {
                    pbClipboard.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbClipboard.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                pbClipboard.Image = img;
                lblQuestion.Text = string.Format("Content type: Bitmap (Image), Size: {0}x{1}", img.Width, img.Height);
                pbClipboard.Visible = true;
            }
            else if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                lblQuestion.Text = "Content type: Text, Length: " + text.Length;
                txtClipboard.Text = text;
                txtClipboard.Visible = true;
            }
            else if (Clipboard.ContainsFileDropList())
            {
                string[] files = Clipboard.GetFileDropList().OfType<string>().ToArray();
                lblQuestion.Text = "Content type: File, Count: " + files.Length;
                lbClipboard.Items.AddRange(files);
                lbClipboard.Visible = true;
            }
            else
            {
                lblQuestion.Text = "Clipboard is empty or contains unknown data.";
                IsClipboardEmpty = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbDontShowThisWindow_CheckedChanged(object sender, EventArgs e)
        {
            DontShowThisWindow = cbDontShowThisWindow.Checked;
        }
    }
}