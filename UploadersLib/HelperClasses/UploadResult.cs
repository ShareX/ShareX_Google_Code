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
using HelpersLib;

namespace UploadersLib.HelperClasses
{
    public class UploadResult
    {
        public string Host { get; set; }

        public string LocalFilePath { get; set; }

        public string URL { get; set; }

        public string ThumbnailURL { get; set; }

        public string DeletionURL { get; set; }

        public string ShortenedURL { get; set; }

        public string Source { get; set; }

        public List<string> Errors { get; set; }

        public bool IsURLExpected { get; set; }

        public bool IsError
        {
            get { return Errors != null && Errors.Count > 0; }
        }

        public string ErrorsToString()
        {
            if (IsError)
            {
                return string.Join(Environment.NewLine, Errors.ToArray());
            }

            return null;
        }

        public UploadResult()
        {
            Errors = new List<string>();
            IsURLExpected = true;
        }

        public UploadResult(string source, string url = null)
            : this()
        {
            Source = source;
            URL = url;
        }

        #region Links

        public string GetUrlByType(LinkFormatEnum type, string longUrl)
        {
            switch (type)
            {
                case LinkFormatEnum.FULL:
                    return longUrl;
                case LinkFormatEnum.FULL_TINYURL:
                    return this.ShortenedURL;
                case LinkFormatEnum.FULL_IMAGE_FORUMS:
                    return GetFullImageForumsUrl(longUrl);
                case LinkFormatEnum.FULL_IMAGE_HTML:
                    return GetFullImageHTML(longUrl);
                case LinkFormatEnum.FULL_IMAGE_WIKI:
                    return GetFullImageWiki(longUrl);
                case LinkFormatEnum.FULL_IMAGE_MEDIAWIKI:
                    return GetFullImageMediaWikiInnerLink(longUrl);
                case LinkFormatEnum.LINKED_THUMBNAIL:
                    return GetLinkedThumbnailForumUrl(longUrl);
                case LinkFormatEnum.LinkedThumbnailHtml:
                    return GetLinkedThumbnailHtmlUrl(longUrl);
                case LinkFormatEnum.LINKED_THUMBNAIL_WIKI:
                    return GetLinkedThumbnailWikiUrl(longUrl);
                case LinkFormatEnum.THUMBNAIL:
                    return this.ThumbnailURL;
                case LinkFormatEnum.LocalFilePath:
                    return this.LocalFilePath;
                case LinkFormatEnum.LocalFilePathUri:
                    return GetLocalFilePathAsUri(LocalFilePath);
            }

            return this.URL;
        }

        public string GetFullImageUrl()
        {
            return this.URL;
        }

        public string GetFullImageForumsUrl(string url)
        {
            if (!string.IsNullOrEmpty(url) && Helpers.IsImageFile(url))
            {
                return string.Format("[IMG]{0}[/IMG]", url);
            }
            return string.Empty;
        }

        public string GetFullImageHTML(string url)
        {
            if (!string.IsNullOrEmpty(url) && Helpers.IsImageFile(url))
            {
                return string.Format("<img src=\"{0}\"/>", url);
            }
            return string.Empty;
        }

        public string GetFullImageWiki(string url)
        {
            if (!string.IsNullOrEmpty(url) && Helpers.IsImageFile(url))
            {
                return string.Format("[{0}]", url);
            }
            return string.Empty;
        }

        public string GetFullImageMediaWikiInnerLink(string url)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;
            int index = url.IndexOf("Image:");
            if (index < 0)
                return string.Empty;
            string name = url.Substring(index + "Image:".Length);
            return string.Format("[[Image:{0}]]", name);
        }

        public string GetThumbnailUrl()
        {
            return this.ThumbnailURL;
        }

        public string GetLinkedThumbnailForumUrl(string full)
        {
            string thumb = GetThumbnailUrl();
            if (!string.IsNullOrEmpty(full) && !string.IsNullOrEmpty(thumb))
            {
                return string.Format("[URL={0}][IMG]{1}[/IMG][/URL]", full, thumb);
            }
            return string.Empty;
        }

        private string GetLinkedThumbnailHtmlUrl(string url)
        {
            string th = GetThumbnailUrl();
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(th))
            {
                return string.Format("<a target='_blank' href=\"{0}\"><img src=\"{1}\" border='0'/></a>", url, th);
            }
            return string.Empty;
        }

        public string GetLinkedThumbnailWikiUrl(string full)
        {
            // e.g. [http://code.google.com http://code.google.com/images/code_sm.png]
            string thumb = GetThumbnailUrl();
            if (!string.IsNullOrEmpty(full) && !string.IsNullOrEmpty(thumb))
            {
                return string.Format("[{0} {1}]", full, thumb);
            }
            return string.Empty;
        }

        public string GetLocalFilePathAsUri(string fp)
        {
            if (File.Exists(fp))
            {
                try
                {
                    return new Uri(fp).AbsoluteUri;
                }
                catch (Exception ex)
                {
                    DebugHelper.WriteException(ex);
                }
            }
            return string.Empty;
        }

        #endregion Links

        #region Source Methods

        public enum SourceType
        {
            TEXT,
            HTML,
            STRING
        }

        /// <summary>
        /// Return a file path of the Source saved as text or html
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="sType"></param>
        /// <returns></returns>
        public string GetSource(string dirPath, SourceType sType)
        {
            string filePath = "";
            if (!string.IsNullOrEmpty(this.Source))
            {
                switch (sType)
                {
                    case SourceType.TEXT:
                        filePath = Path.Combine(dirPath, "LastSource.txt");
                        File.WriteAllText(filePath, this.Source);
                        break;
                    case SourceType.HTML:
                        filePath = Path.Combine(dirPath, "LastSource.html");
                        File.WriteAllText(filePath, this.Source);
                        break;
                    case SourceType.STRING:
                        filePath = this.Source;
                        break;
                }
            }

            return filePath;
        }

        #endregion Source Methods
    }
}