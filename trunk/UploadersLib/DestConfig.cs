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
using System.ComponentModel;
using System.Text;
using HelpersLib;

namespace UploadersLib
{
    [Serializable]
    public class DestConfig
    {
        public List<OutputEnum> Outputs = new List<OutputEnum>();
        public List<ClipboardContentEnum> TaskClipboardContent = new List<ClipboardContentEnum>();
        public List<LinkFormatEnum> LinkFormat = new List<LinkFormatEnum>();

        public List<ImageDestination> ImageUploaders = new List<ImageDestination>();
        public List<TextDestination> TextUploaders = new List<TextDestination>();
        public List<FileDestination> FileUploaders = new List<FileDestination>();
        public List<UrlShortenerType> LinkUploaders = new List<UrlShortenerType>();

        [Category(ComponentModelStrings.ActivitiesUploadersText), DefaultValue("text"), Description("Text format e.g. csharp, cpp, etc.")]
        public string TextFormat { get; set; }

        [Browsable(false)]
        public bool IsEmptyAny
        {
            get
            {
                return FileUploaders.Count == 0 || TextUploaders.Count == 0 || ImageUploaders.Count == 0;
            }
        }

        [Browsable(false)]
        public bool IsEmptyAll
        {
            get
            {
                return FileUploaders.Count == 0 && TextUploaders.Count == 0 && ImageUploaders.Count == 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string temp = ToStringOutputs();
            if (!string.IsNullOrEmpty(temp))
            {
                sb.Append(temp);
            }

            temp = ToStringImageUploaders();
            if (!string.IsNullOrEmpty(temp))
            {
                sb.Append(" using ");
                sb.Append(temp);
            }

            temp = ToStringTextUploaders();
            if (!string.IsNullOrEmpty(temp))
            {
                sb.Append(", ");
                sb.Append(temp);
            }

            temp = ToStringFileUploaders();
            if (!string.IsNullOrEmpty(temp))
            {
                sb.Append(", ");
                sb.Append(temp);
            }

            temp = ToStringLinkUploaders();
            if (!string.IsNullOrEmpty(temp))
            {
                sb.Append(", ");
                sb.Append(temp);
            }

            return sb.ToString();
        }

        private string ToString<T>(List<T> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (T ut in list)
            {
                Enum en = (Enum)Convert.ChangeType(ut, typeof(Enum));
                sb.Append(en.GetDescription());
                sb.Append(", ");
            }
            if (sb.Length > 2)
            {
                sb.Remove(sb.Length - 2, 2);
            }
            return sb.ToString();
        }

        public string ToStringOutputs()
        {
            return ToString<OutputEnum>(Outputs);
        }

        public string ToStringImageUploaders()
        {
            return ToString<ImageDestination>(ImageUploaders);
        }

        public string ToStringTextUploaders()
        {
            return ToString<TextDestination>(TextUploaders);
        }

        public string ToStringFileUploaders()
        {
            return ToString<FileDestination>(FileUploaders);
        }

        public string ToStringLinkUploaders()
        {
            return ToString<UrlShortenerType>(LinkUploaders);
        }
    }
}