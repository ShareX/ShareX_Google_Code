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

using HelpersLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageEffectsLib
{
    public partial class ImageEffectsForm : Form
    {
        public Image DefaultImage { get; private set; }

        public ImageEffectsForm(Image img)
        {
            InitializeComponent();

            DefaultImage = img;

            pbDefault.Image = DefaultImage;
            pbDefaultZoom.Image = ImageHelpers.ResizeImage(pbDefault.Image, 8, 12);
            lblDefault.Text = string.Format("Default image ({0}x{1})", pbDefault.Image.Width, pbDefault.Image.Height);
        }

        public ImageEffectsForm(string filePath)
            : this(Helpers.GetImageFromFile(filePath))
        {
            Text += " - " + filePath;
        }

        private void UpdatePreview()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            pbPreview.Image = GetImageForExport();
            lblPreview.Text = string.Format("Preview image ({0}x{1}) - {2} ms", pbPreview.Image.Width, pbPreview.Image.Height, timer.ElapsedMilliseconds);
            pbPreviewZoom.Image = ImageHelpers.ResizeImage(pbPreview.Image, 8, 12);
        }

        public Image GetImageForExport()
        {
            IImageEffect[] imageEffects = lvEffects.Items.Cast<ListViewItem>().Where(x => x.Tag is IImageEffect).Select(x => (IImageEffect)x.Tag).ToArray();
            Image tempImage = (Image)DefaultImage.Clone();

            foreach (IImageEffect imageEffect in imageEffects)
            {
                tempImage = imageEffect.Apply(tempImage);
            }

            return tempImage ?? DefaultImage;
        }

        private void lvEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgSettings.SelectedObject = null;

            if (lvEffects.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvEffects.SelectedItems[0];
                if (lvi.Tag is IImageEffect)
                {
                    pgSettings.SelectedObject = lvi.Tag;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TreeNode node = tvEffects.SelectedNode;

            if (node.Tag is IImageEffect)
            {
                IImageEffect imageEffect = (IImageEffect)Activator.CreateInstance(node.Tag.GetType());
                ListViewItem lvi = new ListViewItem(imageEffect.GetType().ToString());
                lvi.Tag = imageEffect;

                if (lvEffects.SelectedIndices.Count > 0)
                {
                    lvEffects.Items.Insert(lvEffects.SelectedIndices[lvEffects.SelectedIndices.Count - 1] + 1, lvi);
                }
                else
                {
                    lvEffects.Items.Add(lvi);
                    lvEffects.Items[lvEffects.Items.Count - 1].Selected = true;
                }
            }

            UpdatePreview();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvEffects.SelectedItems)
            {
                lvi.Remove();
            }

            UpdatePreview();
        }

        private void pgSettings_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdatePreview();
        }

        private void ImageEffectsGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}