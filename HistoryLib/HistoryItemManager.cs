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

using System.IO;
using System.Linq;
using System.Windows.Forms;
using HelpersLib;

namespace HistoryLib
{
    public class HistoryItemManager
    {
        public HistoryItem HistoryItem { get; private set; }

        public int HistoryItemCount { get; private set; }

        public bool IsURLExist { get; private set; }

        public bool IsShortenedURLExist { get; private set; }

        public bool IsThumbnailURLExist { get; private set; }

        public bool IsDeletionURLExist { get; private set; }

        public bool IsImageURL { get; private set; }

        public bool IsTextURL { get; private set; }

        public bool IsFilePathValid { get; private set; }

        public bool IsFileExist { get; private set; }

        public bool IsImageFile { get; private set; }

        public bool IsTextFile { get; private set; }

        private ListView lv;

        public HistoryItemManager(ListView listView)
        {
            lv = listView;
        }

        public HistoryRefreshInfoResult RefreshInfo()
        {
            HistoryItem tempHistoryItem = GetSelectedHistoryItem();

            if (tempHistoryItem != null)
            {
                if (HistoryItem != tempHistoryItem)
                {
                    HistoryItem = tempHistoryItem;

                    IsURLExist = !string.IsNullOrEmpty(HistoryItem.URL);
                    IsShortenedURLExist = !string.IsNullOrEmpty(HistoryItem.ShortenedURL);
                    IsThumbnailURLExist = !string.IsNullOrEmpty(HistoryItem.ThumbnailURL);
                    IsDeletionURLExist = !string.IsNullOrEmpty(HistoryItem.DeletionURL);
                    IsImageURL = IsURLExist && Helpers.IsImageFile(HistoryItem.URL);
                    IsTextURL = IsURLExist && Helpers.IsTextFile(HistoryItem.URL);
                    IsFilePathValid = !string.IsNullOrEmpty(HistoryItem.Filepath) && Path.HasExtension(HistoryItem.Filepath);
                    IsFileExist = IsFilePathValid && File.Exists(HistoryItem.Filepath);
                    IsImageFile = IsFileExist && Helpers.IsImageFile(HistoryItem.Filepath);
                    IsTextFile = IsFileExist && Helpers.IsTextFile(HistoryItem.Filepath);

                    return HistoryRefreshInfoResult.Success;
                }

                return HistoryRefreshInfoResult.Same;
            }

            return HistoryRefreshInfoResult.Invalid;
        }

        private HistoryItem GetSelectedHistoryItem()
        {
            HistoryItemCount = lv.SelectedItems.Count;

            if (HistoryItemCount > 0)
            {
                return lv.SelectedItems[0].Tag as HistoryItem;
            }

            return null;
        }

        public void OpenURL()
        {
            if (HistoryItem != null && IsURLExist) Helpers.LoadBrowserAsync(HistoryItem.URL);
        }

        public void OpenShortenedURL()
        {
            if (HistoryItem != null && IsShortenedURLExist) Helpers.LoadBrowserAsync(HistoryItem.ShortenedURL);
        }

        public void OpenThumbnailURL()
        {
            if (HistoryItem != null && IsThumbnailURLExist) Helpers.LoadBrowserAsync(HistoryItem.ThumbnailURL);
        }

        public void OpenDeletionURL()
        {
            if (HistoryItem != null && IsDeletionURLExist) Helpers.LoadBrowserAsync(HistoryItem.DeletionURL);
        }

        public void OpenFile()
        {
            if (HistoryItem != null && IsFileExist) Helpers.LoadBrowserAsync(HistoryItem.Filepath);
        }

        public void OpenFolder()
        {
            if (HistoryItem != null && IsFileExist) Helpers.OpenFolderWithFile(HistoryItem.Filepath);
        }

        public void CopyURL()
        {
            if (HistoryItem != null && IsURLExist)
            {
                string[] array = lv.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag as HistoryItem).
                    Where(x => x != null && !string.IsNullOrEmpty(x.URL)).Select(x => x.URL).ToArray();

                if (array != null && array.Length > 0)
                {
                    string urls = string.Join("\r\n", array);

                    if (!string.IsNullOrEmpty(urls))
                    {
                        Helpers.CopyTextSafely(urls);
                    }
                }
            }
        }

        public void CopyShortenedURL()
        {
            if (HistoryItem != null && IsShortenedURLExist) Helpers.CopyTextSafely(HistoryItem.ShortenedURL);
        }

        public void CopyThumbnailURL()
        {
            if (HistoryItem != null && IsThumbnailURLExist) Helpers.CopyTextSafely(HistoryItem.ThumbnailURL);
        }

        public void CopyDeletionURL()
        {
            if (HistoryItem != null && IsDeletionURLExist) Helpers.CopyTextSafely(HistoryItem.DeletionURL);
        }

        public void CopyFile()
        {
            if (HistoryItem != null && IsFileExist) Helpers.CopyFileToClipboard(HistoryItem.Filepath);
        }

        public void CopyImage()
        {
            if (HistoryItem != null && IsImageFile) Helpers.CopyImageFileToClipboard(HistoryItem.Filepath);
        }

        public void CopyText()
        {
            if (HistoryItem != null && IsTextFile) Helpers.CopyTextFileToClipboard(HistoryItem.Filepath);
        }

        public void CopyHTMLLink()
        {
            if (HistoryItem != null && IsURLExist) Helpers.CopyTextSafely(string.Format("<a href=\"{0}\">{0}</a>", HistoryItem.URL));
        }

        public void CopyHTMLImage()
        {
            if (HistoryItem != null && IsImageURL) Helpers.CopyTextSafely(string.Format("<img src=\"{0}\"/>", HistoryItem.URL));
        }

        public void CopyHTMLLinkedImage()
        {
            if (HistoryItem != null && IsImageURL && IsThumbnailURLExist)
            {
                Helpers.CopyTextSafely(string.Format("<a href=\"{0}\"><img src=\"{1}\"/></a>", HistoryItem.URL, HistoryItem.ThumbnailURL));
            }
        }

        public void CopyForumLink()
        {
            if (HistoryItem != null && IsURLExist) Helpers.CopyTextSafely(string.Format("[url]{0}[/url]", HistoryItem.URL));
        }

        public void CopyForumImage()
        {
            if (HistoryItem != null && IsImageURL) Helpers.CopyTextSafely(string.Format("[img]{0}[/img]", HistoryItem.URL));
        }

        public void CopyForumLinkedImage()
        {
            if (HistoryItem != null && IsImageURL && IsThumbnailURLExist)
            {
                Helpers.CopyTextSafely(string.Format("[url={0}][img]{1}[/img][/url]", HistoryItem.URL, HistoryItem.ThumbnailURL));
            }
        }

        public void CopyFilePath()
        {
            if (HistoryItem != null && IsFilePathValid) Helpers.CopyTextSafely(HistoryItem.Filepath);
        }

        public void CopyFileName()
        {
            if (HistoryItem != null && IsFilePathValid) Helpers.CopyTextSafely(Path.GetFileNameWithoutExtension(HistoryItem.Filepath));
        }

        public void CopyFileNameWithExtension()
        {
            if (HistoryItem != null && IsFilePathValid) Helpers.CopyTextSafely(Path.GetFileName(HistoryItem.Filepath));
        }

        public void CopyFolder()
        {
            if (HistoryItem != null && IsFilePathValid) Helpers.CopyTextSafely(Path.GetDirectoryName(HistoryItem.Filepath));
        }

        public void DeleteLocalFile()
        {
            RefreshInfo();
            if (HistoryItem != null && IsFileExist && MessageBox.Show("Do you want to delete this file?\n" + HistoryItem.Filepath,
                "Delete Local File", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(HistoryItem.Filepath);
            }
        }

        public void MoreInfo()
        {
            new HistoryItemInfoForm(this).Show();
        }
    }
}