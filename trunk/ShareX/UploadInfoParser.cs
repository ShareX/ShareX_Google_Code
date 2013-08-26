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

using ShareX;
using System.IO;

namespace HelpersLib
{
    public class UploadInfoParser : NameParser
    {
        public const string HTMLLink = "<a href=\"$url\">$url</a>";
        public const string HTMLImage = "<img src=\"$url\"/>";
        public const string HTMLLinkedImage = "<a href=\"$url\"><img src=\"$thumbnailurl\"/></a>";
        public const string ForumLink = "[url]$url[/url]";
        public const string ForumImage = "[img]$url[/img]";
        public const string ForumLinkedImage = "[url=$url][img]$thumbnailurl[/img][/url]";

        public string Parse(TaskInfo info, string pattern)
        {
            if (info != null && info.Result != null && !string.IsNullOrEmpty(pattern))
            {
                pattern = base.Parse(pattern);

                pattern = pattern.Replace("$result", info.Result.ToString());
                pattern = pattern.Replace("$url", info.Result.URL ?? "");
                pattern = pattern.Replace("$shorturl", info.Result.ShortenedURL ?? "");
                pattern = pattern.Replace("$thumbnailurl", info.Result.ThumbnailURL ?? "");
                pattern = pattern.Replace("$deletionurl", info.Result.DeletionURL ?? "");

                if (!string.IsNullOrEmpty(info.FilePath))
                {
                    pattern = pattern.Replace("$filepath", info.FilePath);
                    pattern = pattern.Replace("$filename", Path.GetFileName(info.FilePath));
                    pattern = pattern.Replace("$filenamenoext", Path.GetFileNameWithoutExtension(info.FilePath));
                    pattern = pattern.Replace("$folderpath", Path.GetDirectoryName(info.FilePath));
                    pattern = pattern.Replace("$foldername", Path.GetFileName(Path.GetDirectoryName(info.FilePath)));
                }

                pattern = pattern.Replace("$uploadtime", ((int)info.UploadDuration.TotalMilliseconds).ToString());
            }

            return pattern;
        }
    }
}