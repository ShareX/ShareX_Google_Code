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
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using UploadersLib.HelperClasses;

namespace UploadersLib.ImageUploaders
{
    public sealed class Imgur_v3 : ImageUploader, IOAuth2
    {
        public AccountType UploadMethod { get; set; }
        public OAuth2Info AuthInfo { get; set; }
        public ImgurThumbnailType ThumbnailType { get; set; }

        public Imgur_v3(OAuth2Info oauth)
        {
            AuthInfo = oauth;
        }

        public string GetAuthorizationURL()
        {
            return string.Format("https://api.imgur.com/oauth2/authorize?client_id={0}&response_type={1}", AuthInfo.Client_ID, "pin");
        }

        public bool GetAccessToken(string pin)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("client_id", AuthInfo.Client_ID);
            args.Add("client_secret", AuthInfo.Client_Secret);
            args.Add("grant_type", "pin");
            args.Add("pin", pin);

            string response = SendPostRequest("https://api.imgur.com/oauth2/token", args);

            if (!string.IsNullOrEmpty(response))
            {
                OAuth2Token token = JsonConvert.DeserializeObject<OAuth2Token>(response);

                if (token != null)
                {
                    token.UpdateExpireDate();
                    AuthInfo.Token = token;
                    return true;
                }
            }

            return false;
        }

        public bool RefreshAccessToken()
        {
            if (OAuth2Info.CheckOAuth(AuthInfo) && !string.IsNullOrEmpty(AuthInfo.Token.refresh_token))
            {
                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("refresh_token", AuthInfo.Token.refresh_token);
                args.Add("client_id", AuthInfo.Client_ID);
                args.Add("client_secret", AuthInfo.Client_Secret);
                args.Add("grant_type", "refresh_token");

                string response = SendPostRequest("https://api.imgur.com/oauth2/token", args);

                if (!string.IsNullOrEmpty(response))
                {
                    OAuth2Token token = JsonConvert.DeserializeObject<OAuth2Token>(response);

                    if (token != null)
                    {
                        token.UpdateExpireDate();
                        AuthInfo.Token = token;
                        return true;
                    }
                }
            }

            return false;
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            if (UploadMethod == AccountType.User && !OAuth2Info.CheckOAuth(AuthInfo))
            {
                Errors.Add("Login is required.");
                return null;
            }

            NameValueCollection headers = new NameValueCollection();

            if (UploadMethod == AccountType.User)
            {
                if (AuthInfo.Token.IsExpired)
                {
                    if (!RefreshAccessToken())
                    {
                        Errors.Add("Refresh access token failed.");
                        return null;
                    }
                }

                headers.Add("Authorization", "Bearer " + AuthInfo.Token.access_token);
            }
            else if (UploadMethod == AccountType.Anonymous)
            {
                headers.Add("Authorization", "Client-ID " + AuthInfo.Client_ID);
            }

            UploadResult result = UploadData(stream, "https://api.imgur.com/3/image", fileName, "image", null, null, headers);

            if (!string.IsNullOrEmpty(result.Response))
            {
                ImgurUpload upload = JsonConvert.DeserializeObject<ImgurUpload>(result.Response);

                if (upload != null)
                {
                    if (upload.success)
                    {
                        if (upload.data != null && !string.IsNullOrEmpty(upload.data.link))
                        {
                            result.URL = upload.data.link;

                            int index = result.URL.LastIndexOf('.');
                            string thumbnail;

                            if (ThumbnailType == ImgurThumbnailType.Large_Thumbnail)
                            {
                                thumbnail = "l";
                            }
                            else
                            {
                                thumbnail = "s";
                            }

                            result.ThumbnailURL = result.URL.Remove(index) + thumbnail + result.URL.Substring(index);
                            result.DeletionURL = "http://imgur.com/delete/" + upload.data.deletehash;
                        }
                    }
                    else
                    {
                        Errors.Add("Imgur upload failed. Status code: " + upload.status);
                    }
                }
            }

            return result;
        }

        public class ImgurUploadData
        {
            public string id { get; set; }
            public string deletehash { get; set; }
            public string link { get; set; }
        }

        public class ImgurUpload
        {
            public ImgurUploadData data { get; set; }
            public bool success { get; set; }
            public int status { get; set; }
        }
    }
}