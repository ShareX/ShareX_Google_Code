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
using HelpersLib;

namespace UploadersLib.URLShorteners
{
    public sealed class TurlURLShortener : URLShortener
    {
        private const string APIURL = "http://turl.ca/api.php";

        public override string Host
        {
            get
            {
                return UrlShortenerType.TURL.GetDescription();
            }
        }

        public override string ShortenURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Dictionary<string, string> arguments = new Dictionary<string, string>();
                arguments.Add("url", url);
                // arguments.Add("tag", settings.Tag);

                string response = SendGetRequest(APIURL, arguments);

                if (!string.IsNullOrEmpty(response))
                {
                    if (response.StartsWith("SUCCESS:"))
                    {
                        return "http://turl.ca/" + response.Substring(8);
                    }

                    if (response.StartsWith("ERROR:"))
                    {
                        this.Errors.Add(response.Substring(6));
                    }
                }
            }

            return null;
        }
    }
}