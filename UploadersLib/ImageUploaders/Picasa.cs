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

using HelpersLib;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using UploadersLib.HelperClasses;

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
            UploadResult ur = new UploadResult();

            string url = OAuthManager.GenerateQuery(APIURL, null, HttpMethod.Post, AuthInfo);
            string contentType = Helpers.GetMimeType(fileName);
            NameValueCollection headers = new NameValueCollection { { "Slug", fileName } };

            ur.Response = SendPostRequestStream(url, stream, contentType, null, headers);

            XDocument xd = XDocument.Parse(ur.Response);

            XElement entry_element = xd.Element(AtomNS + "entry");

            if (entry_element != null)
            {
                XElement group_element = entry_element.Element(MediaNS + "group");

                if (group_element != null)
                {
                    XElement content_element = group_element.Element(MediaNS + "content");

                    if (content_element != null)
                    {
                        ur.ThumbnailURL = content_element.GetAttributeValue("url");

                        int last_slash_index = ur.ThumbnailURL.LastIndexOf(@"/");

                        ur.URL = ur.ThumbnailURL.Insert(last_slash_index, @"/s0");
                    }
                }
            }

            return ur;
        }
    }
}