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

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using HelpersLib;
using UploadersLib.HelperClasses;

namespace UploadersLib.OtherServices
{
    public class Twitter : Uploader, IOAuth
    {
        private const string APIVersion = "1";
        private const string URLRequestToken = "https://twitter.com/oauth/request_token";
        private const string URLAuthorize = "https://twitter.com/oauth/authorize";
        private const string URLAccessToken = "https://twitter.com/oauth/access_token";
        private const string URLTweet = "https://twitter.com/statuses/update.xml";
        // private const string URLTweet =  "http://api.twitter.com/" + APIVersion + "/statuses/update.xml";

        public OAuthInfo AuthInfo { get; set; }

        public Twitter(OAuthInfo oauth)
        {
            AuthInfo = oauth;
        }

        public string GetAuthorizationURL()
        {
            return GetAuthorizationURL(URLRequestToken, URLAuthorize, AuthInfo);
        }

        public bool GetAccessToken(string verificationCode)
        {
            AuthInfo.AuthVerifier = verificationCode;
            return GetAccessToken(URLAccessToken, AuthInfo);
        }

        public TweetStatus TweetMessage(string message)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("status", message);

            string query = OAuthManager.GenerateQuery(URLTweet, args, HttpMethod.Post, AuthInfo);

            string response = SendPostRequest(query);

            return ParseTweetResponse(response);
        }

        private TweetStatus ParseTweetResponse(string response)
        {
            TweetStatus tweet = new TweetStatus();

            XDocument xd = XDocument.Parse(response);

            if (xd != null)
            {
                XElement xe = xd.Element("status");

                if (xe != null)
                {
                    tweet.ID = Convert.ToInt64(xe.GetElementValue("id"));
                    tweet.Text = xe.GetElementValue("text");
                    tweet.InReplyToScreenName = xe.GetElementValue("in_reply_to_screen_name");
                }
            }

            return tweet;
        }
    }

    public class TweetStatus
    {
        public long ID { get; set; }

        public string Text { get; set; }

        public string InReplyToScreenName { get; set; }
    }
}