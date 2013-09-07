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
using ShareX.Properties;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UploadersLib;

namespace ShareX
{
    public class UploadInfoManager
    {
        public UploadInfoStatus[] SelectedItems { get; private set; }
        private ListView lv;
        private UploadInfoParser parser;

        public UploadInfoManager(ListView listView)
        {
            lv = listView;
            parser = new UploadInfoParser();
        }

        private UploadInfoStatus[] GetSelectedItems()
        {
            if (lv != null && lv.SelectedItems.Count > 0)
            {
                return lv.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag as UploadTask).Where(x => x != null && x.Info != null).Select(x => new UploadInfoStatus(x.Info)).ToArray();
            }

            return null;
        }

        private void CopyTexts(IEnumerable<string> texts)
        {
            if (texts != null && texts.Count() > 0)
            {
                string urls = string.Join("\r\n", texts.ToArray());

                if (!string.IsNullOrEmpty(urls))
                {
                    ClipboardHelper.CopyText(urls);
                }
            }
        }

        public bool IsSelectedItemsValid()
        {
            return SelectedItems != null && SelectedItems.Length > 0;
        }

        public bool RefreshSelectedItems()
        {
            SelectedItems = GetSelectedItems();
            return SelectedItems != null;
        }

        #region Open

        public void OpenURL()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsURLExist) Helpers.LoadBrowserAsync(SelectedItems[0].Info.Result.URL);
        }

        public void OpenShortenedURL()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsShortenedURLExist) Helpers.LoadBrowserAsync(SelectedItems[0].Info.Result.ShortenedURL);
        }

        public void OpenThumbnailURL()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsThumbnailURLExist) Helpers.LoadBrowserAsync(SelectedItems[0].Info.Result.ThumbnailURL);
        }

        public void OpenDeletionURL()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsDeletionURLExist) Helpers.LoadBrowserAsync(SelectedItems[0].Info.Result.DeletionURL);
        }

        public void OpenFile()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsFileExist) Helpers.LoadBrowserAsync(SelectedItems[0].Info.FilePath);
        }

        public void OpenFolder()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsFileExist) Helpers.OpenFolderWithFile(SelectedItems[0].Info.FilePath);
        }

        public void TryOpen()
        {
            if (IsSelectedItemsValid())
            {
                if (SelectedItems[0].IsShortenedURLExist)
                {
                    Helpers.LoadBrowserAsync(SelectedItems[0].Info.Result.ShortenedURL);
                }
                else if (SelectedItems[0].IsURLExist)
                {
                    Helpers.LoadBrowserAsync(SelectedItems[0].Info.Result.URL);
                }
                else if (SelectedItems[0].IsFileExist)
                {
                    Helpers.LoadBrowserAsync(SelectedItems[0].Info.FilePath);
                }
            }
        }

        #endregion Open

        #region Copy

        public void CopyURL()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsURLExist).Select(x => x.Info.Result.URL));
        }

        public void CopyShortenedURL()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsShortenedURLExist).Select(x => x.Info.Result.ShortenedURL));
        }

        public void CopyThumbnailURL()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsThumbnailURLExist).Select(x => x.Info.Result.ThumbnailURL));
        }

        public void CopyDeletionURL()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsDeletionURLExist).Select(x => x.Info.Result.DeletionURL));
        }

        public void CopyFile()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsFileExist) ClipboardHelper.CopyFile(SelectedItems[0].Info.FilePath);
        }

        public void CopyImage()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsImageFile) ClipboardHelper.CopyImageFromFile(SelectedItems[0].Info.FilePath);
        }

        public void CopyText()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsTextFile) ClipboardHelper.CopyTextFromFile(SelectedItems[0].Info.FilePath);
        }

        public void CopyHTMLLink()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsURLExist).Select(x => parser.Parse(x.Info, UploadInfoParser.HTMLLink)));
        }

        public void CopyHTMLImage()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsImageURL).Select(x => parser.Parse(x.Info, UploadInfoParser.HTMLImage)));
        }

        public void CopyHTMLLinkedImage()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsImageURL && x.IsThumbnailURLExist).
                Select(x => parser.Parse(x.Info, UploadInfoParser.HTMLLinkedImage)));
        }

        public void CopyForumLink()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsURLExist).Select(x => parser.Parse(x.Info, UploadInfoParser.ForumLink)));
        }

        public void CopyForumImage()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsImageURL).Select(x => parser.Parse(x.Info, UploadInfoParser.ForumImage)));
        }

        public void CopyForumLinkedImage()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsImageURL && x.IsThumbnailURLExist).
                Select(x => parser.Parse(x.Info, UploadInfoParser.ForumLinkedImage)));
        }

        public void CopyFilePath()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsFilePathValid).Select(x => x.Info.FilePath));
        }

        public void CopyFileName()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsFilePathValid).Select(x => Path.GetFileNameWithoutExtension(x.Info.FilePath)));
        }

        public void CopyFileNameWithExtension()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsFilePathValid).Select(x => Path.GetFileName(x.Info.FilePath)));
        }

        public void CopyFolder()
        {
            if (IsSelectedItemsValid()) CopyTexts(SelectedItems.Where(x => x.IsFilePathValid).Select(x => Path.GetDirectoryName(x.Info.FilePath)));
        }

        public void CopyCustomFormat(string format)
        {
            if (!string.IsNullOrEmpty(format) && IsSelectedItemsValid())
            {
                CopyTexts(SelectedItems.Where(x => x.IsURLExist).Select(x => parser.Parse(x.Info, format)));
            }
        }

        #endregion Copy

        #region Other

        public void ShowImagePreview()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsImageFile) ImageViewer.ShowImage(SelectedItems[0].Info.FilePath);
        }

        public void ShowErrors()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].Info.Result != null && SelectedItems[0].Info.Result.IsError)
            {
                string errors = SelectedItems[0].Info.Result.ErrorsToString();

                if (!string.IsNullOrEmpty(errors))
                {
                    using (ErrorForm form = new ErrorForm(Application.ProductName, "Upload errors", errors, Program.MyLogger, Program.LogFilePath, Links.URL_ISSUES))
                    {
                        form.ShowDialog();
                    }
                }
            }
        }

        public void ShowResponse()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].Info.Result != null && !string.IsNullOrEmpty(SelectedItems[0].Info.Result.Response))
            {
                using (ResponseForm form = new ResponseForm(SelectedItems[0].Info.Result.Response))
                {
                    form.Icon = Resources.ShareXIcon;
                    form.ShowDialog();
                }
            }
        }

        public void Upload()
        {
            if (IsSelectedItemsValid() && SelectedItems[0].IsFileExist) UploadManager.UploadFile(SelectedItems[0].Info.FilePath);
        }

        #endregion Other
    }
}