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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using UploadersLib.HelperClasses;

namespace UploadersLib.FileUploaders
{
    public sealed class Dropbox : FileUploader, IOAuth
    {
        public OAuthInfo AuthInfo { get; set; }
        public DropboxAccountInfo AccountInfo { get; set; }
        public string UploadPath { get; set; }
        public bool AutoCreateShareableLink { get; set; }

        private const string APIVersion = "1";
        private const string URLAPI = "https://api.dropbox.com/" + APIVersion;
        private const string URLAPIContent = "https://api-content.dropbox.com/" + APIVersion;

        private const string URLAccountInfo = URLAPI + "/account/info";
        private const string URLFiles = URLAPIContent + "/files/dropbox";
        private const string URLMetaData = URLAPI + "/metadata/dropbox";
        private const string URLShares = URLAPI + "/shares/dropbox";
        private const string URLDownload = "https://dl.dropbox.com/u";

        private const string URLRequestToken = URLAPI + "/oauth/request_token";
        private const string URLAuthorize = "https://www.dropbox.com/" + APIVersion + "/oauth/authorize";
        private const string URLAccessToken = URLAPI + "/oauth/access_token";

        public Dropbox(OAuthInfo oauth)
        {
            AuthInfo = oauth;
        }

        public Dropbox(OAuthInfo oauth, string uploadPath, DropboxAccountInfo accountInfo)
            : this(oauth)
        {
            UploadPath = uploadPath;
            AccountInfo = accountInfo;
        }

        public string GetAuthorizationURL()
        {
            return GetAuthorizationURL(URLRequestToken, URLAuthorize, AuthInfo);
        }

        public bool GetAccessToken(string verificationCode = null)
        {
            AuthInfo.AuthVerifier = verificationCode;
            return GetAccessToken(URLAccessToken, AuthInfo);
        }

        public DropboxAccountInfo GetAccountInfo()
        {
            if (OAuthInfo.CheckOAuth(AuthInfo))
            {
                string url = OAuthManager.GenerateQuery(URLAccountInfo, null, HttpMethod.Get, AuthInfo);

                string response = SendGetRequest(url);

                if (!string.IsNullOrEmpty(response))
                {
                    DropboxAccountInfo account = JsonConvert.DeserializeObject<DropboxAccountInfo>(response);

                    if (account != null)
                    {
                        AccountInfo = account;
                        return account;
                    }
                }
            }

            return null;
        }

        public DropboxDirectoryInfo GetFilesList(string path)
        {
            DropboxDirectoryInfo directoryInfo = null;

            if (OAuthInfo.CheckOAuth(AuthInfo))
            {
                string url = OAuthManager.GenerateQuery(Helpers.CombineURL(URLMetaData, path), null, HttpMethod.Get, AuthInfo);

                string response = SendGetRequest(url);

                if (!string.IsNullOrEmpty(response))
                {
                    directoryInfo = JsonConvert.DeserializeObject<DropboxDirectoryInfo>(response);
                }
            }

            return directoryInfo;
        }

        public DropboxShares CreateShareableLink(string path)
        {
            if (OAuthInfo.CheckOAuth(AuthInfo))
            {
                string url = OAuthManager.GenerateQuery(Helpers.CombineURL(URLShares, path), null, HttpMethod.Get, AuthInfo);

                string response = SendGetRequest(url);

                if (!string.IsNullOrEmpty(response))
                {
                    DropboxShares shares = JsonConvert.DeserializeObject<DropboxShares>(response);
                    return shares;
                }
            }

            return null;
        }

        public bool DownloadFile(string path, Stream downloadStream)
        {
            if (OAuthInfo.CheckOAuth(AuthInfo))
            {
                string url = OAuthManager.GenerateQuery(Helpers.CombineURL(URLFiles, path), null, HttpMethod.Get, AuthInfo);
                return SendGetRequest(downloadStream, url, null);
            }

            return false;
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            if (AuthInfo == null || string.IsNullOrEmpty(AuthInfo.UserToken) || string.IsNullOrEmpty(AuthInfo.UserSecret))
            {
                Errors.Add("Login is required.");
                return null;
            }

            string url = Helpers.CombineURL(URLFiles, UploadPath);

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("file", fileName);

            string query = OAuthManager.GenerateQuery(url, args, HttpMethod.Post, AuthInfo);

            // There's a 150MB limit to all uploads through the API.
            UploadResult result = UploadData(stream, query, fileName);

            if (result.IsSuccess)
            {
                DropboxContentInfo content = JsonConvert.DeserializeObject<DropboxContentInfo>(result.Response);

                if (content != null)
                {
                    if (AutoCreateShareableLink)
                    {
                        DropboxShares shares = CreateShareableLink(content.Path);

                        if (shares != null)
                        {
                            result.URL = shares.URL;
                        }
                    }
                    else
                    {
                        result.URL = GetDropboxURL(AccountInfo.Uid, content.Path);
                    }
                }
            }

            return result;
        }

        public static string GetDropboxURL(long userID, string uploadPath)
        {
            if (!string.IsNullOrEmpty(uploadPath))
            {
                uploadPath = uploadPath.Trim('/');

                if (uploadPath.StartsWith("Public/", StringComparison.InvariantCultureIgnoreCase))
                {
                    uploadPath = HttpUtility.UrlPathEncode(uploadPath.Substring(7));
                    return Helpers.CombineURL(URLDownload, userID.ToString(), uploadPath);
                }
            }

            return "Upload path is private. Use \"Public\" folder to get public URL.";
        }

        public static string TidyUploadPath(string uploadPath)
        {
            if (!string.IsNullOrEmpty(uploadPath))
            {
                return uploadPath.Trim().Replace('\\', '/').Trim('/') + "/";
            }

            return string.Empty;
        }
    }

    public class DropboxUserLogin
    {
        public string Token { get; set; }
        public string Secret { get; set; }
    }

    public class DropboxAccountInfo
    {
        public string Referral_link { get; set; }
        public string Display_name { get; set; }
        public long Uid { get; set; }
        public string Country { get; set; }
        public DropboxQuotaInfo Quota_info { get; set; }
        public string Email { get; set; }
    }

    public class DropboxQuotaInfo
    {
        public long Shared { get; set; }
        public long Quota { get; set; }
        public long Normal { get; set; }
    }

    public class DropboxDirectoryInfo
    {
        public string Hash { get; set; }
        public bool Thumb_exists { get; set; }
        public long Bytes { get; set; }
        public string Path { get; set; }
        public bool Is_dir { get; set; }
        public string Size { get; set; }
        public string Root { get; set; }
        public DropboxContentInfo[] Contents { get; set; }
        public string Icon { get; set; }
    }

    public class DropboxContentInfo
    {
        public long Revision { get; set; }
        public string Rev { get; set; }
        public bool Thumb_exists { get; set; }
        public long Bytes { get; set; }
        public string Modified { get; set; }
        public string Client_mtime { get; set; }
        public string Path { get; set; }
        public bool Is_dir { get; set; }
        public string Icon { get; set; }
        public string Root { get; set; }
        public string Mime_type { get; set; }
        public string Size { get; set; }
    }

    public class DropboxShares
    {
        public string URL { get; set; }
        public string Expires { get; set; }
    }
}