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

namespace UploadersLib.URLShorteners
{
    public class GoogleURLShortener : URLShortener, IOAuth
    {
        private const string APIURL = "https://www.googleapis.com/urlshortener/v1/url";

        private const string URLRequestToken = "https://www.google.com/accounts/OAuthGetRequestToken";
        private const string URLAuthorize = "https://www.google.com/accounts/OAuthAuthorizeToken";
        private const string URLAccessToken = "https://www.google.com/accounts/OAuthGetAccessToken";

        public AccountType UploadMethod { get; set; }

        public string AnonymousKey { get; set; }

        public OAuthInfo AuthInfo { get; set; }

        public override string Host
        {
            get
            {
                return UrlShortenerType.Google.GetDescription();
            }
        }

        public GoogleURLShortener(AccountType uploadMethod, string anonymousKey, OAuthInfo oauth)
        {
            UploadMethod = uploadMethod;
            AnonymousKey = anonymousKey;
            AuthInfo = oauth;
        }

        public GoogleURLShortener(string anonymousKey)
        {
            UploadMethod = AccountType.Anonymous;
            AnonymousKey = anonymousKey;
        }

        public GoogleURLShortener(OAuthInfo oauth)
        {
            UploadMethod = AccountType.User;
            AuthInfo = oauth;
        }

        public string GetAuthorizationURL()
        {
            return GetAuthorizationURL(URLRequestToken, URLAuthorize, AuthInfo,
                new Dictionary<string, string> { { "scope", "https://www.googleapis.com/auth/urlshortener" }, { "xoauth_displayname", Application.ProductName } });
        }

        public bool GetAccessToken(string verificationCode = null)
        {
            AuthInfo.AuthVerifier = verificationCode;
            return GetAccessToken(URLAccessToken, AuthInfo);
        }

        public override string ShortenURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                string query;

                switch (UploadMethod)
                {
                    default:
                    case AccountType.Anonymous:
                        query = string.Format("{0}?key={1}", APIURL, AnonymousKey);
                        break;
                    case AccountType.User:
                        query = OAuthManager.GenerateQuery(APIURL, null, HttpMethod.Post, AuthInfo);
                        break;
                }

                string json = string.Format("{{\"longUrl\":\"{0}\"}}", url);

                string response = SendPostRequestJSON(query, json);

                if (!string.IsNullOrEmpty(response))
                {
                    GoogleURLShortenerResponse result = JsonConvert.DeserializeObject<GoogleURLShortenerResponse>(response);
                    if (result != null) return result.id;
                }
            }

            return null;
        }
    }

    public class GoogleURLShortenerResponse
    {
        public string kind { get; set; }

        public string id { get; set; }

        public string longUrl { get; set; }

        public string status { get; set; }
    }
}