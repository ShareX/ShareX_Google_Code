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
        private const string Root = "dropbox"; // dropbox or sandbox

        private const string URLAPI = "https://api.dropbox.com/" + APIVersion;
        private const string URLAPIContent = "https://api-content.dropbox.com/" + APIVersion;

        private const string URLAccountInfo = URLAPI + "/account/info";
        private const string URLFiles = URLAPIContent + "/files/" + Root;
        private const string URLMetaData = URLAPI + "/metadata/" + Root;
        private const string URLShares = URLAPI + "/shares/" + Root;
        private const string URLCopy = URLAPI + "/fileops/copy";
        private const string URLCreateFolder = URLAPI + "/fileops/create_folder";
        private const string URLDelete = URLAPI + "/fileops/delete";
        private const string URLMove = URLAPI + "/fileops/move";
        private const string URLDownload = "https://dl.dropbox.com/u";

        private const string URLRequestToken = URLAPI + "/oauth/request_token";
        private const string URLAuthorize = "https://www.dropbox.com/" + APIVersion + "/oauth/authorize";
        private const string URLAccessToken = URLAPI + "/oauth/access_token";

        public Dropbox(OAuthInfo oauth)
        {
            AuthInfo = oauth;
        }

        public Dropbox(OAuthInfo oauth, DropboxAccountInfo accountInfo)
            : this(oauth)
        {
            AccountInfo = accountInfo;
        }

        // https://www.dropbox.com/developers/core/api#request-token
        // https://www.dropbox.com/developers/core/api#authorize
        public string GetAuthorizationURL()
        {
            return GetAuthorizationURL(URLRequestToken, URLAuthorize, AuthInfo);
        }

        // https://www.dropbox.com/developers/core/api#access-token
        public bool GetAccessToken(string verificationCode = null)
        {
            AuthInfo.AuthVerifier = verificationCode;
            return GetAccessToken(URLAccessToken, AuthInfo);
        }

        #region Dropbox accounts

        // https://www.dropbox.com/developers/core/api#account-info
        public DropboxAccountInfo GetAccountInfo()
        {
            DropboxAccountInfo account = null;

            if (OAuthInfo.CheckOAuth(AuthInfo))
            {
                string query = OAuthManager.GenerateQuery(URLAccountInfo, null, HttpMethod.Get, AuthInfo);

                string response = SendGetRequest(query);

                if (!string.IsNullOrEmpty(response))
                {
                    account = JsonConvert.DeserializeObject<DropboxAccountInfo>(response);

                    if (account != null)
                    {
                        AccountInfo = account;
                    }
                }
            }

            return account;
        }

        #endregion Dropbox accounts

        #region Files and metadata

        // https://www.dropbox.com/developers/core/api#files-GET
        public bool DownloadFile(string path, Stream downloadStream)
        {
            if (!string.IsNullOrEmpty(path) && OAuthInfo.CheckOAuth(AuthInfo))
            {
                string url = Helpers.CombineURL(URLFiles, path);
                string query = OAuthManager.GenerateQuery(url, null, HttpMethod.Get, AuthInfo);
                return SendGetRequest(downloadStream, query);
            }

            return false;
        }

        // https://www.dropbox.com/developers/core/api#files-POST
        public UploadResult UploadFile(Stream stream, string path, string fileName, bool autoShortenURL = false)
        {
            if (!OAuthInfo.CheckOAuth(AuthInfo))
            {
                Errors.Add("Login is required.");
                return null;
            }

            string url = Helpers.CombineURL(URLFiles, path);

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
                    if (autoShortenURL)
                    {
                        DropboxShares shares = CreateShareableLink(content.Path);

                        if (shares != null)
                        {
                            result.URL = shares.URL;
                        }
                    }
                    else
                    {
                        result.URL = GetPublicURL(content.Path);
                    }
                }
            }

            return result;
        }

        // https://www.dropbox.com/developers/core/api#metadata
        public DropboxDirectoryInfo GetFilesList(string path)
        {
            DropboxDirectoryInfo directoryInfo = null;

            if (OAuthInfo.CheckOAuth(AuthInfo))
            {
                string url = Helpers.CombineURL(URLMetaData, path);
                string query = OAuthManager.GenerateQuery(url, null, HttpMethod.Get, AuthInfo);

                string response = SendGetRequest(query);

                if (!string.IsNullOrEmpty(response))
                {
                    directoryInfo = JsonConvert.DeserializeObject<DropboxDirectoryInfo>(response);
                }
            }

            return directoryInfo;
        }

        // https://www.dropbox.com/developers/core/api#shares
        public DropboxShares CreateShareableLink(string path, bool short_url = true)
        {
            DropboxShares shares = null;

            if (!string.IsNullOrEmpty(path) && OAuthInfo.CheckOAuth(AuthInfo))
            {
                string url = Helpers.CombineURL(URLShares, path);

                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("short_url", short_url ? "true" : "false");

                string query = OAuthManager.GenerateQuery(url, args, HttpMethod.Post, AuthInfo);

                string response = SendPostRequest(query);

                if (!string.IsNullOrEmpty(response))
                {
                    shares = JsonConvert.DeserializeObject<DropboxShares>(response);
                }
            }

            return shares;
        }

        #endregion Files and metadata

        #region File operations

        // https://www.dropbox.com/developers/core/api#fileops-copy
        public DropboxContentInfo Copy(string from_path, string to_path)
        {
            DropboxContentInfo contentInfo = null;

            if (!string.IsNullOrEmpty(from_path) && !string.IsNullOrEmpty(to_path) && OAuthInfo.CheckOAuth(AuthInfo))
            {
                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("root", Root);
                args.Add("from_path", from_path);
                args.Add("to_path", to_path);

                string query = OAuthManager.GenerateQuery(URLCopy, args, HttpMethod.Post, AuthInfo);

                string response = SendPostRequest(query);

                if (!string.IsNullOrEmpty(response))
                {
                    contentInfo = JsonConvert.DeserializeObject<DropboxContentInfo>(response);
                }
            }

            return contentInfo;
        }

        // https://www.dropbox.com/developers/core/api#fileops-create-folder
        public DropboxContentInfo CreateFolder(string path)
        {
            DropboxContentInfo contentInfo = null;

            if (!string.IsNullOrEmpty(path) && OAuthInfo.CheckOAuth(AuthInfo))
            {
                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("root", Root);
                args.Add("path", path);

                string query = OAuthManager.GenerateQuery(URLCreateFolder, args, HttpMethod.Post, AuthInfo);

                string response = SendPostRequest(query);

                if (!string.IsNullOrEmpty(response))
                {
                    contentInfo = JsonConvert.DeserializeObject<DropboxContentInfo>(response);
                }
            }

            return contentInfo;
        }

        // https://www.dropbox.com/developers/core/api#fileops-delete
        public DropboxContentInfo Delete(string path)
        {
            DropboxContentInfo contentInfo = null;

            if (!string.IsNullOrEmpty(path) && OAuthInfo.CheckOAuth(AuthInfo))
            {
                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("root", Root);
                args.Add("path", path);

                string query = OAuthManager.GenerateQuery(URLDelete, args, HttpMethod.Post, AuthInfo);

                string response = SendPostRequest(query);

                if (!string.IsNullOrEmpty(response))
                {
                    contentInfo = JsonConvert.DeserializeObject<DropboxContentInfo>(response);
                }
            }

            return contentInfo;
        }

        // https://www.dropbox.com/developers/core/api#fileops-move
        public DropboxContentInfo Move(string from_path, string to_path)
        {
            DropboxContentInfo contentInfo = null;

            if (!string.IsNullOrEmpty(from_path) && !string.IsNullOrEmpty(to_path) && OAuthInfo.CheckOAuth(AuthInfo))
            {
                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("root", Root);
                args.Add("from_path", from_path);
                args.Add("to_path", to_path);

                string query = OAuthManager.GenerateQuery(URLMove, args, HttpMethod.Post, AuthInfo);

                string response = SendPostRequest(query);

                if (!string.IsNullOrEmpty(response))
                {
                    contentInfo = JsonConvert.DeserializeObject<DropboxContentInfo>(response);
                }
            }

            return contentInfo;
        }

        #endregion File operations

        public override UploadResult Upload(Stream stream, string fileName)
        {
            return UploadFile(stream, UploadPath, fileName, AutoCreateShareableLink);
        }

        public string GetPublicURL(string path)
        {
            return GetPublicURL(AccountInfo.Uid, path);
        }

        public static string GetPublicURL(long userID, string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                path = path.Trim('/');

                if (path.StartsWith("Public/", StringComparison.InvariantCultureIgnoreCase))
                {
                    path = Helpers.URLPathEncode((path.Substring(7)));
                    return Helpers.CombineURL(URLDownload, userID.ToString(), path);
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