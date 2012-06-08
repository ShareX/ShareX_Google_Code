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
        public UploadInfo Info { get; private set; }
        public int SelectedItemCount { get; private set; }

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

        public bool RefreshInfo()
        {
            Info = GetSelectedUploadInfo();

            if (Info != null)
            {
                IsURLExist = !string.IsNullOrEmpty(Info.Result.URL);
                IsShortenedURLExist = !string.IsNullOrEmpty(Info.Result.ShortenedURL);
                IsThumbnailURLExist = !string.IsNullOrEmpty(Info.Result.ThumbnailURL);
                IsDeletionURLExist = !string.IsNullOrEmpty(Info.Result.DeletionURL);
                IsImageURL = IsURLExist && Helpers.IsImageFile(Info.Result.URL);
                IsTextURL = IsURLExist && Helpers.IsTextFile(Info.Result.URL);
                IsFilePathValid = !string.IsNullOrEmpty(Info.FilePath) && Path.HasExtension(Info.FilePath);
                IsFileExist = IsFilePathValid && File.Exists(Info.FilePath);
                IsImageFile = IsFileExist && Helpers.IsImageFile(Info.FilePath);
                IsTextFile = IsFileExist && Helpers.IsTextFile(Info.FilePath);

                return true;
            }

            return false;
        }

        private UploadInfo GetSelectedUploadInfo()
        {
            SelectedItemCount = lv.SelectedItems.Count;

            if (SelectedItemCount > 0)
            {
                return lv.SelectedItems[0].Tag as UploadInfo;
            }

            return null;
        }

        public void OpenURL()
        {
            if (Info != null && IsURLExist) Helpers.LoadBrowserAsync(Info.Result.URL);
        }

        public void OpenShortenedURL()
        {
            if (Info != null && IsShortenedURLExist) Helpers.LoadBrowserAsync(Info.Result.ShortenedURL);
        }

        public void OpenThumbnailURL()
        {
            if (Info != null && IsThumbnailURLExist) Helpers.LoadBrowserAsync(Info.Result.ThumbnailURL);
        }

        public void OpenDeletionURL()
        {
            if (Info != null && IsDeletionURLExist) Helpers.LoadBrowserAsync(Info.Result.DeletionURL);
        }

        public void OpenFile()
        {
            if (Info != null && IsFileExist) Helpers.LoadBrowserAsync(Info.FilePath);
        }

        public void OpenFolder()
        {
            if (Info != null && IsFileExist) Helpers.OpenFolderWithFile(Info.FilePath);
        }

        public void CopyURL()
        {
            if (Info != null && IsURLExist)
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
            if (Info != null && IsShortenedURLExist) Helpers.CopyTextSafely(Info.Result.ShortenedURL);
        }

        public void CopyThumbnailURL()
        {
            if (Info != null && IsThumbnailURLExist) Helpers.CopyTextSafely(Info.Result.ThumbnailURL);
        }

        public void CopyDeletionURL()
        {
            if (Info != null && IsDeletionURLExist) Helpers.CopyTextSafely(Info.Result.DeletionURL);
        }

        public void CopyFile()
        {
            if (Info != null && IsFileExist) Helpers.CopyFileToClipboard(Info.FilePath);
        }

        public void CopyImage()
        {
            if (Info != null && IsImageFile) Helpers.CopyImageFileToClipboard(Info.FilePath);
        }

        public void CopyText()
        {
            if (Info != null && IsTextFile) Helpers.CopyTextFileToClipboard(Info.FilePath);
        }

        public void CopyHTMLLink()
        {
            if (Info != null && IsURLExist) Helpers.CopyTextSafely(string.Format("<a href=\"{0}\">{0}</a>", Info.Result.URL));
        }

        public void CopyHTMLImage()
        {
            if (Info != null && IsImageURL) Helpers.CopyTextSafely(string.Format("<img src=\"{0}\"/>", Info.Result.URL));
        }

        public void CopyHTMLLinkedImage()
        {
            if (Info != null && IsImageURL && IsThumbnailURLExist)
            {
                Helpers.CopyTextSafely(string.Format("<a href=\"{0}\"><img src=\"{1}\"/></a>", Info.Result.URL, Info.Result.ThumbnailURL));
            }
        }

        public void CopyForumLink()
        {
            if (Info != null && IsURLExist) Helpers.CopyTextSafely(string.Format("[url]{0}[/url]", Info.Result.URL));
        }

        public void CopyForumImage()
        {
            if (Info != null && IsImageURL) Helpers.CopyTextSafely(string.Format("[img]{0}[/img]", Info.Result.URL));
        }

        public void CopyForumLinkedImage()
        {
            if (Info != null && IsImageURL && IsThumbnailURLExist)
            {
                Helpers.CopyTextSafely(string.Format("[url={0}][img]{1}[/img][/url]", Info.Result.URL, Info.Result.ThumbnailURL));
            }
        }

        public void CopyFilePath()
        {
            if (Info != null && IsFilePathValid) Helpers.CopyTextSafely(Info.FilePath);
        }

        public void CopyFileName()
        {
            if (Info != null && IsFilePathValid) Helpers.CopyTextSafely(Path.GetFileNameWithoutExtension(Info.FilePath));
        }

        public void CopyFileNameWithExtension()
        {
            if (Info != null && IsFilePathValid) Helpers.CopyTextSafely(Path.GetFileName(Info.FilePath));
        }

        public void CopyFolder()
        {
            if (Info != null && IsFilePathValid) Helpers.CopyTextSafely(Path.GetDirectoryName(Info.FilePath));
        }

        public void ShowErrors()
        {
            string errors = Info.Result.ErrorsToString();

            if (!string.IsNullOrEmpty(errors))
            {
                new ErrorForm(Application.ProductName, "Upload errors", errors, Program.MyLogger, Program.LogFilePath, Links.URL_ISSUES).ShowDialog();
            }
        }

        public void ShowResponse()
        {
            if (Info != null && Info.Result != null && !string.IsNullOrEmpty(Info.Result.Source))
            {
                new ResponseForm(Info.Result.Source).ShowDialog();
            }
        }
    }
}