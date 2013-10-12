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
    public partial class ImageEffectsGUI : Form
    {
        private List<IPluginItem> plugins;
        public Image DefaultImage { get; set; }

        public ImageEffectsGUI(string filePath)
            : this(Helpers.GetImageFromFile(filePath))
        {
            this.Text = string.Format("Image Effects - {0}", filePath);
            plugins = new List<IPluginItem>()
            {
                new Alpha(), new Brightness(), new Colorize(), new Contrast(), new Gamma(), new Grayscale(), new Hue(), new Inverse(), new Saturation(),
                new Shadow(),
                new Border(), new Reflection(), new Resize(), new Rotate(), new Scale()
            };
        }

        public ImageEffectsGUI(Image img)
        {
            InitializeComponent();
            FillPluginsList();

            DefaultImage = img;

            pbDefault.Image = DefaultImage;
            pbDefaultZoom.Image = ImageHelpers.ResizeImage(pbDefault.Image, 8, 12);
            lblDefault.Text = string.Format("Default image ({0}x{1})", pbDefault.Image.Width, pbDefault.Image.Height);
        }

        private void FillPluginsList()
        {
            TreeNode parentNode, childNode;
            foreach (IPluginInterface plugin in plugins)
            {
                parentNode = tvPlugins.Nodes.Add(plugin.Name);
                parentNode.Tag = plugin;

                foreach (IPluginItem item in plugin.PluginItems)
                {
                    childNode = parentNode.Nodes.Add(item.Name);
                    childNode.Tag = item;
                }
            }

            tvPlugins.ExpandAll();
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
            IPluginItem[] plugins = lvEffects.Items.Cast<ListViewItem>().Where(x => x.Tag is IPluginItem).Select(x => (IPluginItem)x.Tag).ToArray();
            Image tempImage = PluginManager.ApplyEffects(plugins, DefaultImage);
            return tempImage != null ? tempImage : DefaultImage;
        }

        private void lvEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgSettings.SelectedObject = null;

            if (lvEffects.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvEffects.SelectedItems[0];
                if (lvi.Tag is IPluginItem)
                {
                    pgSettings.SelectedObject = lvi.Tag;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TreeNode node = tvPlugins.SelectedNode;
            if (node.Tag is IPluginItem)
            {
                IPluginItem pluginItem = (IPluginItem)Activator.CreateInstance(node.Tag.GetType());
                ListViewItem lvi = new ListViewItem(pluginItem.Name);
                lvi.Tag = pluginItem;
                pluginItem.PreviewTextChanged += p => lvi.Text = string.Format("{0}: {1}", pluginItem.Name, p);

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
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}