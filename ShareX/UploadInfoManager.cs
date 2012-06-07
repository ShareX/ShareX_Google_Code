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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelpersLib;

namespace ShareX
{
    public class UploadInfoManager
    {
        public UploadInfo UploadItem { get; private set; }

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

        public UploadInfoManager(ListView listView)
        {
            lv = listView;
        }

        public void RefreshInfo()
        {
            UploadItem = GetSelectedUploadInfo();

            IsURLExist = !string.IsNullOrEmpty(UploadItem.Result.URL);
            IsShortenedURLExist = !string.IsNullOrEmpty(UploadItem.Result.ShortenedURL);
            IsThumbnailURLExist = !string.IsNullOrEmpty(UploadItem.Result.ThumbnailURL);
            IsDeletionURLExist = !string.IsNullOrEmpty(UploadItem.Result.DeletionURL);
            IsImageURL = IsURLExist && Helpers.IsImageFile(UploadItem.Result.URL);
            IsTextURL = IsURLExist && Helpers.IsTextFile(UploadItem.Result.URL);
            IsFilePathValid = !string.IsNullOrEmpty(UploadItem.FilePath) && Path.HasExtension(UploadItem.FilePath);
            IsFileExist = IsFilePathValid && File.Exists(UploadItem.FilePath);
            IsImageFile = IsFileExist && Helpers.IsImageFile(UploadItem.FilePath);
            IsTextFile = IsFileExist && Helpers.IsTextFile(UploadItem.FilePath);
        }

        private UploadInfo GetSelectedUploadInfo()
        {
            if (lv.SelectedItems.Count > 0)
            {
                return lv.SelectedItems[0].Tag as UploadInfo;
            }

            return null;
        }

        public void OpenURL()
        {
            if (UploadItem != null && IsURLExist) Helpers.LoadBrowserAsync(UploadItem.Result.URL);
        }

        public void OpenShortenedURL()
        {
            if (UploadItem != null && IsShortenedURLExist) Helpers.LoadBrowserAsync(UploadItem.Result.ShortenedURL);
        }

        public void OpenThumbnailURL()
        {
            if (UploadItem != null && IsThumbnailURLExist) Helpers.LoadBrowserAsync(UploadItem.Result.ThumbnailURL);
        }

        public void OpenDeletionURL()
        {
            if (UploadItem != null && IsDeletionURLExist) Helpers.LoadBrowserAsync(UploadItem.Result.DeletionURL);
        }

        public void OpenFile()
        {
            if (UploadItem != null && IsFileExist) Helpers.LoadBrowserAsync(UploadItem.FilePath);
        }

        public void OpenFolder()
        {
            if (UploadItem != null && IsFileExist) Helpers.OpenFolderWithFile(UploadItem.FilePath);
        }

        public void CopyURL()
        {
            if (UploadItem != null && IsURLExist)
            {
                string[] array = lv.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag as UploadInfo).
                    Where(x => x != null && x.Result != null && !string.IsNullOrEmpty(x.Result.URL)).Select(x => x.Result.URL).ToArray();

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
            if (UploadItem != null && IsShortenedURLExist) Helpers.CopyTextSafely(UploadItem.Result.ShortenedURL);
        }

        public void CopyThumbnailURL()
        {
            if (UploadItem != null && IsThumbnailURLExist) Helpers.CopyTextSafely(UploadItem.Result.ThumbnailURL);
        }

        public void CopyDeletionURL()
        {
            if (UploadItem != null && IsDeletionURLExist) Helpers.CopyTextSafely(UploadItem.Result.DeletionURL);
        }

        public void CopyFile()
        {
            if (UploadItem != null && IsFileExist) Helpers.CopyFileToClipboard(UploadItem.FilePath);
        }

        public void CopyImage()
        {
            if (UploadItem != null && IsImageFile) Helpers.CopyImageFileToClipboard(UploadItem.FilePath);
        }

        public void CopyText()
        {
            if (UploadItem != null && IsTextFile) Helpers.CopyTextFileToClipboard(UploadItem.FilePath);
        }

        public void CopyHTMLLink()
        {
            if (UploadItem != null && IsURLExist) Helpers.CopyTextSafely(string.Format("<a href=\"{0}\">{0}</a>", UploadItem.Result.URL));
        }

        public void CopyHTMLImage()
        {
            if (UploadItem != null && IsImageURL) Helpers.CopyTextSafely(string.Format("<img src=\"{0}\"/>", UploadItem.Result.URL));
        }

        public void CopyHTMLLinkedImage()
        {
            if (UploadItem != null && IsImageURL && IsThumbnailURLExist)
            {
                Helpers.CopyTextSafely(string.Format("<a href=\"{0}\"><img src=\"{1}\"/></a>", UploadItem.Result.URL, UploadItem.Result.ThumbnailURL));
            }
        }

        public void CopyForumLink()
        {
            if (UploadItem != null && IsURLExist) Helpers.CopyTextSafely(string.Format("[url]{0}[/url]", UploadItem.Result.URL));
        }

        public void CopyForumImage()
        {
            if (UploadItem != null && IsImageURL) Helpers.CopyTextSafely(string.Format("[img]{0}[/img]", UploadItem.Result.URL));
        }

        public void CopyForumLinkedImage()
        {
            if (UploadItem != null && IsImageURL && IsThumbnailURLExist)
            {
                Helpers.CopyTextSafely(string.Format("[url={0}][img]{1}[/img][/url]", UploadItem.Result.URL, UploadItem.Result.ThumbnailURL));
            }
        }

        public void CopyFilePath()
        {
            if (UploadItem != null && IsFilePathValid) Helpers.CopyTextSafely(UploadItem.FilePath);
        }

        public void CopyFileName()
        {
            if (UploadItem != null && IsFilePathValid) Helpers.CopyTextSafely(Path.GetFileNameWithoutExtension(UploadItem.FilePath));
        }

        public void CopyFileNameWithExtension()
        {
            if (UploadItem != null && IsFilePathValid) Helpers.CopyTextSafely(Path.GetFileName(UploadItem.FilePath));
        }

        public void CopyFolder()
        {
            if (UploadItem != null && IsFilePathValid) Helpers.CopyTextSafely(Path.GetDirectoryName(UploadItem.FilePath));
        }

        public void DeleteLocalFile()
        {
            RefreshInfo();
            if (UploadItem != null && IsFileExist && MessageBox.Show("Do you want to delete this file?\n" + UploadItem.FilePath,
                "Delete Local File", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(UploadItem.FilePath);
            }
        }
    }
}