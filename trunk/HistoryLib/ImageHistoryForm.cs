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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HelpersLib;
using Manina.Windows.Forms;

namespace HistoryLib
{
    public partial class ImageHistoryForm : Form
    {
        public string HistoryPath { get; private set; }
        public int MaxItemCount { get; set; }

        private HistoryManager history;
        private HistoryItemManager him;
        private HistoryItem[] historyItems;

        public ImageHistoryForm(string historyPath, string title = "", int maxItemCount = -1)
        {
            InitializeComponent();

            HistoryPath = historyPath;
            MaxItemCount = maxItemCount;

            if (!string.IsNullOrEmpty(title))
            {
                Text = title;
            }
            else
            {
                Text = "Image history: " + historyPath;
            }

            him = new HistoryItemManager();
            him.GetHistoryItems += new HistoryItemManager.GetHistoryItemsEventHandler(him_GetHistoryItems);
        }

        private void RefreshHistoryItems()
        {
            if (history == null)
            {
                history = new HistoryManager(HistoryPath);
            }

            historyItems = GetHistoryItems();

            ilvImages.Items.Clear();
            ilvImages.SuspendLayout();

            foreach (HistoryItem historyItem in historyItems)
            {
                ImageListViewItem ilvi = new ImageListViewItem(historyItem.Filepath);
                ilvi.Tag = historyItem;
                ilvImages.Items.Add(ilvi);
            }

            ilvImages.ResumeLayout();
        }

        private HistoryItem[] him_GetHistoryItems()
        {
            return ilvImages.SelectedItems.Cast<ImageListViewItem>().Select(x => x.Tag as HistoryItem).ToArray();
        }

        private HistoryItem[] GetHistoryItems()
        {
            IEnumerable<HistoryItem> tempHistoryItems = history.GetHistoryItems().Where(x => !string.IsNullOrEmpty(x.Filepath) &&
                Helpers.IsImageFile(x.Filepath) && File.Exists(x.Filepath)).Reverse().ToArray();

            if (MaxItemCount > -1)
            {
                tempHistoryItems = tempHistoryItems.Take(MaxItemCount);
            }

            return tempHistoryItems.ToArray();
        }

        #region Form events

        private void ImageHistoryForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            BringToFront();
            Activate();
            RefreshHistoryItems();
        }

        private void ImageHistoryForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    RefreshHistoryItems();
                    e.Handled = true;
                    break;
            }
        }

        private void ilvImages_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                him.cmsHistory.Show(ilvImages, e.X + 1, e.Y + 1);
            }
        }

        private void ilvImages_SelectionChanged(object sender, EventArgs e)
        {
            him.RefreshInfo();
        }

        private void ilvImages_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            him.ShowImagePreview();
        }

        private void tsmiThumbnailSize75_Click(object sender, EventArgs e)
        {
            ilvImages.ThumbnailSize = new Size(75, 75);
        }

        private void tsmiThumbnailSize100_Click(object sender, EventArgs e)
        {
            ilvImages.ThumbnailSize = new Size(100, 100);
        }

        private void tsmiThumbnailSize150_Click(object sender, EventArgs e)
        {
            ilvImages.ThumbnailSize = new Size(150, 150);
        }

        private void tsmiThumbnailSize200_Click(object sender, EventArgs e)
        {
            ilvImages.ThumbnailSize = new Size(200, 200);
        }

        private void tsmiThumbnailSize250_Click(object sender, EventArgs e)
        {
            ilvImages.ThumbnailSize = new Size(250, 250);
        }

        private void tsmiViewModeThumbnails_Click(object sender, EventArgs e)
        {
            ilvImages.View = Manina.Windows.Forms.View.Thumbnails;
        }

        private void tsmiViewModeGallery_Click(object sender, EventArgs e)
        {
            ilvImages.View = Manina.Windows.Forms.View.Gallery;
        }

        private void tsmiViewModePane_Click(object sender, EventArgs e)
        {
            ilvImages.View = Manina.Windows.Forms.View.Pane;
        }

        private void ilvImages_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                default: return;
                case Keys.Enter:
                    him.OpenURL();
                    break;
                case Keys.Control | Keys.Enter:
                    him.OpenFile();
                    break;
                case Keys.Control | Keys.C:
                    him.CopyURL();
                    break;
            }

            e.Handled = true;
        }

        #endregion Form events
    }
}