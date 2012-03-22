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

using System.Collections.Generic;

namespace UploadersLib.TextUploaders
{
    public sealed class Paste2Uploader : TextUploader
    {
        private const string APIURL = "http://paste2.org/new-paste";

        private Paste2Settings settings;

        public Paste2Uploader()
        {
            settings = new Paste2Settings();
        }

        public Paste2Uploader(Paste2Settings settings)
        {
            this.settings = settings;
        }

        public override string UploadText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Dictionary<string, string> arguments = new Dictionary<string, string>();
                arguments.Add("code", text);
                arguments.Add("description", settings.Description);
                arguments.Add("lang", settings.TextFormat);
                arguments.Add("parent", "0");

                return SendPostRequest(APIURL, arguments, ResponseType.RedirectionURL);
            }

            return null;
        }
    }

    public class Paste2Settings
    {
        public string TextFormat { get; set; }

        public string Description { get; set; }

        public Paste2Settings()
        {
            TextFormat = "text";
            Description = string.Empty;
        }
    }
}