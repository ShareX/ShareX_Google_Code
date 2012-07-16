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

namespace UploadersLib.HelperClasses
{
    public class UploadResult
    {
        public string URL { get; set; }
        public string ThumbnailURL { get; set; }
        public string DeletionURL { get; set; }
        public string ShortenedURL { get; set; }
        public string LocalFilePath { get; set; }

        public string Source { get; set; }
        public List<string> Errors { get; set; }
        public bool IsURLExpected { get; set; }

        public bool IsError
        {
            get { return Errors != null && Errors.Count > 0; }
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

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(ShortenedURL))
            {
                return ShortenedURL;
            }

            return URL;
        }

        public string ErrorsToString()
        {
            if (IsError)
            {
                return string.Join(Environment.NewLine + Environment.NewLine, Errors.ToArray());
            }

            return null;
        }
    }
}