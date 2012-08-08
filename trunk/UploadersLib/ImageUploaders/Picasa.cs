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
using System.Windows.Forms;
using HelpersLib;
using Newtonsoft.Json;
using UploadersLib.HelperClasses;
using System.Drawing;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace UploadersLib.URLShorteners
{
    public class Picasa : ImageUploader, IOAuth
    {
        private const string APIURL = "https://picasaweb.google.com/data/feed/api/user/default/albumid/default";

        private const string URLRequestToken = "https://www.google.com/accounts/OAuthGetRequestToken";
        private const string URLAuthorize = "https://www.google.com/accounts/OAuthAuthorizeToken";
        private const string URLAccessToken = "https://www.google.com/accounts/OAuthGetAccessToken";

        public OAuthInfo AuthInfo { get; set; }

        public Picasa(OAuthInfo oauth)
        {
            AuthInfo = oauth;
        }

        public string GetAuthorizationURL()
        {
            return GetAuthorizationURL(URLRequestToken, URLAuthorize, AuthInfo,
                new Dictionary<string, string> { { "scope", "https://picasaweb.google.com/data/" }, { "xoauth_displayname", Application.ProductName } });
        }

        public bool GetAccessToken(string verificationCode = null)
        {
            AuthInfo.AuthVerifier = verificationCode;
            return GetAccessToken(URLAccessToken, AuthInfo);
        }

        private static readonly XNamespace AtomNS = "http://www.w3.org/2005/Atom";
        private static readonly XNamespace MediaNS = "http://search.yahoo.com/mrss/";

        public override UploadResult Upload(Stream stream, string fileName)
        {
            string query = OAuthManager.GenerateQuery(APIURL, null, HttpMethod.Post, AuthInfo);

            string contentType = "image/*";

            if (fileName.EndsWith(".jpg") || fileName.EndsWith(".jpeg")) contentType = "image/jpeg";
            else if (fileName.EndsWith(".png")) contentType = "image/png";
            else if (fileName.EndsWith(".bmp")) contentType = "image/bmp";
            else if (fileName.EndsWith(".gif")) contentType = "image/gif";

            string response = UploadDataPicasa(stream, query, fileName, contentType);

            UploadResult result = new UploadResult();

            XDocument xd = XDocument.Parse(response);

            XElement entry_element = xd.Element(AtomNS + "entry");

            if (entry_element != null)
            {
                Console.WriteLine("entry_element is not null", entry_element);

                XElement group_element = entry_element.Element(MediaNS + "group");

                if (group_element != null)
                {
                    Console.WriteLine("group_element is not null", group_element);

                    XElement content_element = group_element.Element(MediaNS + "content");

                    if (content_element != null)
                    {
                        result.ThumbnailURL = content_element.GetAttributeValue("url");

                        int last_slash_index = result.ThumbnailURL.LastIndexOf(@"/");

                        result.URL = result.ThumbnailURL.Insert(last_slash_index, @"/s0");
                    }
                }
                else
                {
                    Console.WriteLine("group_element is null");
                }
            }
            else
            {
                Console.WriteLine("entry_element is null");
            }

            return result;
        }
    }
}