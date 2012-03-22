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
using System.ComponentModel;
using HelpersLib;

namespace UploadersLib.TextUploaders
{
    public sealed class PastebinUploader : TextUploader
    {
        private const string APIURL = "http://pastebin.com/api/api_post.php";
        private const string APILoginURL = "http://pastebin.com/api/api_login.php";

        private string APIKey;

        public PastebinSettings Settings { get; private set; }

        public PastebinUploader(string apiKey)
        {
            APIKey = apiKey;
            Settings = new PastebinSettings();
        }

        public PastebinUploader(string apiKey, PastebinSettings settings)
        {
            APIKey = apiKey;
            Settings = settings;
        }

        public bool Login()
        {
            if (!string.IsNullOrEmpty(Settings.Username) && !string.IsNullOrEmpty(Settings.Password))
            {
                Dictionary<string, string> loginArgs = new Dictionary<string, string>();

                loginArgs.Add("api_dev_key", APIKey);
                loginArgs.Add("api_user_name", Settings.Username);
                loginArgs.Add("api_user_password", Settings.Password);

                string loginResponse = SendPostRequest(APILoginURL, loginArgs);

                if (!string.IsNullOrEmpty(loginResponse) && !loginResponse.StartsWith("Bad API request"))
                {
                    Settings.UserKey = loginResponse;
                    return true;
                }

                Errors.Add("Pastebin login failed.");
            }

            return false;
        }

        public override string UploadText(string text)
        {
            if (!string.IsNullOrEmpty(text) && Settings != null)
            {
                Dictionary<string, string> args = new Dictionary<string, string>();

                args.Add("api_dev_key", APIKey); // which is your unique API Developers Key
                args.Add("api_option", "paste"); // set as 'paste', this will indicate you want to create a new paste
                args.Add("api_paste_code", text); // this is the text that will be written inside your paste

                // Optional args
                args.Add("api_paste_name", Settings.Title); // this will be the name / title of your paste
                args.Add("api_paste_format", Settings.TextFormat); // this will be the syntax highlighting value
                args.Add("api_paste_private", Settings.IsPublic ? "0" : "1"); // this makes a paste public or private, public = 0, private = 1
                args.Add("api_paste_expire_date", Settings.ExpireTime); // this sets the expiration date of your paste

                if (!string.IsNullOrEmpty(Settings.UserKey))
                {
                    args.Add("api_user_key", Settings.UserKey); // this paramater is part of the login system
                }

                string response = SendPostRequest(APIURL, args);

                if (!string.IsNullOrEmpty(response) && !response.StartsWith("Bad API request") && response.IsValidUrl())
                {
                    return response;
                }

                Errors.Add(response);
            }

            return null;
        }
    }

    public class PastebinSettings
    {
        [Description("Paste name / title")]
        public string Title { get; set; }

        [Description("Syntax highlighting")]
        public string TextFormat { get; set; }

        [DefaultValue("N"), Description("Paste expiration\r\nN = Never, 10M = 10 Minutes, 1H = 1 Hour, 1D = 1 Day, 1M = 1 Month")]
        public string ExpireTime { get; set; }

        [Description("Paste exposure"), DefaultValue(false)]
        public bool IsPublic { get; set; }

        [Description("Account username")]
        public string Username { get; set; }

        [PasswordPropertyText(true), Description("Account password")]
        public string Password { get; set; }

        [Description("Will be created automaticly with Username && Password")]
        public string UserKey { get; set; }

        public PastebinSettings()
        {
            ExpireTime = "N";
        }
    }
}