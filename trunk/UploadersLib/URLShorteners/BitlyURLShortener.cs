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
using System.Xml.Linq;
using HelpersLib;

namespace UploadersLib.URLShorteners
{
    public sealed class BitlyURLShortener : URLShortener
    {
        private const string URLShorten = "http://api.bit.ly/v3/shorten";

        public string APILogin { get; set; }

        public string APIKey { get; set; }

        public override string Host
        {
            get
            {
                return UrlShortenerType.BITLY.GetDescription();
            }
        }

        public BitlyURLShortener(string login, string key)
        {
            APILogin = login;
            APIKey = key;
        }

        public override string ShortenURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Dictionary<string, string> arguments = new Dictionary<string, string>();
                arguments.Add("format", "xml");
                arguments.Add("longUrl", url);
                arguments.Add("login", APILogin);
                arguments.Add("apiKey", APIKey);

                string result = SendGetRequest(URLShorten, arguments);

                XDocument xd = XDocument.Parse(result);
                return xd.GetValue("response/data/url");
            }

            return null;
        }
    }
}