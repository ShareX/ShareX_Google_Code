#region License Information (GPL v3)

/*
    ShareX - A program that allows to you take screenshots and share any file type
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
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using HelpersLib;
using Krystalware.UploadHelper;

namespace UploadersLib.HelperClasses
{
    internal class MediaWikiException : Exception
    {
        public MediaWikiException(string message)
            : base(message)
        {
        }

        public MediaWikiException(string message, Exception e)
            : base(message, e)
        {
        }
    }

    public class MediaWikiOptions
    {
        public MediaWikiAccount Account { get; set; }

        public IWebProxy ProxySettings { get; set; }

        public MediaWikiOptions(MediaWikiAccount acc, IWebProxy proxy)
        {
            this.Account = acc;
            this.ProxySettings = proxy;
        }
    }

    public class LoginInfo
    {
        public string Token { get; set; }

        public CookieContainer Cookies { get; set; }

        public bool NeedToken { get; set; }

        public bool Redirected = false;
    }

    public class MediaWiki
    {
        // TODO: Use FileUploader class for uploading

        private MediaWikiOptions Options { get; set; }

        public MediaWiki(MediaWikiOptions options)
        {
            this.Options = options;
        }

        public void UploadImage(string localFilePath, string remoteFilename)
        {
            // avoid sending "Expect: 100-continue"
            // (which would lead to a "417 Expectation Failed"  error from the server)
            System.Net.ServicePointManager.Expect100Continue = false;

            var loginInfo = Login();
            string editToken;
            editToken = QueryEditToken(loginInfo);

            try
            {
                UploadFile(editToken, loginInfo, localFilePath, remoteFilename);
            }
            catch (MediaWikiException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new MediaWikiException("Error uploading file to MediaWiki:\r\n" + e.Message);
            }
            this.Options.Account.History.Add(new MediaWikiHistory(remoteFilename, FastDateTime.Now));
        }

        // upload a file using the MediaWiki upload API
        private void UploadFile(string editToken, LoginInfo loginInfo, string localFilePath, string remoteFilename)
        {
            UploadFile[] files = new UploadFile[] { new UploadFile(localFilePath, "file", "application/octet-stream") };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetApiUrl());
            request.CookieContainer = loginInfo.Cookies;

            var parameters = new System.Collections.Specialized.NameValueCollection();
            parameters["format"] = "xml";
            parameters["action"] = "upload";
            parameters["filename"] = Path.GetFileName(localFilePath);
            parameters["token"] = editToken;

            var response = HttpUploadHelper.Upload(request, files, parameters);

            string strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (strResponse.StartsWith("unknown_action"))
            {
                // fallback : upload using web form
                UploadFileThroughForm(loginInfo, localFilePath, remoteFilename);
                return;
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strResponse);
                var element = xmlDoc.GetElementsByTagName("api")[0].ChildNodes[0];
                if (element.Name == "error")
                {
                    string errorCode = element.Attributes["code"].Value;
                    string errorMessage = element.Attributes["info"].Value;
                    throw new MediaWikiException("Error uploading to MediaWiki: " + errorCode + "\r\n" + errorMessage);
                }
                string result = element.Attributes["result"].Value;
                if (result == "Warning")
                {
                    foreach (XmlNode child in element.ChildNodes)
                    {
                        if (child.Name == "warnings")
                        {
                            if (child.Attributes["exists"] != null)
                            {
                                string existingImageName = child.Attributes["exists"].Value;
                                throw new MediaWikiException("Image already exists on the wiki: " + existingImageName);
                            }
                        }
                    }
                }

                if (result != "Success")
                    throw new MediaWikiException("Error uploading to MediaWiki:\r\n" + result);
            }
            catch (XmlException)
            {
                throw new MediaWikiException("Unexpected answer while uploading:\r\n" + strResponse);
            }
        }

        // upload a file using the web form instead of the API (for old versions of WikiMedia which don't have the upload API)
        private void UploadFileThroughForm(LoginInfo loginInfo, string localFilePath, string remoteFilename)
        {
            UploadFile[] files = new UploadFile[] { new UploadFile(localFilePath, "wpUploadFile", "application/octet-stream") };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetUrl("Special:Upload"));
            request.CookieContainer = loginInfo.Cookies;

            var parameters = new System.Collections.Specialized.NameValueCollection();
            parameters["wpSourceType"] = "file";
            parameters["wpDestFile"] = remoteFilename;
            parameters["wpUpload"] = "Upload file";

            var response = HttpUploadHelper.Upload(request, files, parameters);

            string strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (strResponse.Contains("A file with this name exists already"))
                throw new MediaWikiException("Image already exists on the wiki");
        }

        private string GetUrl(string path)
        {
            string url = Options.Account.Url;

            if (url.EndsWith("/"))
            {
                return url + path;
            }

            return url + "/" + path;
        }

        private string GetApiUrl()
        {
            return GetUrl("api.php");
        }

        public LoginInfo Login()
        {
            try
            {
                var loginInfo = Login1(new LoginInfo());
                if (loginInfo.NeedToken)
                    LoginWithToken(loginInfo);
                return loginInfo;
            }
            catch (Exception e)
            {
                throw new MediaWikiException("Error logging in to MediaWiki:\r\n" + e.Message, e);
            }
        }

        // login
        private LoginInfo Login1(LoginInfo loginInfo)
        {
            string postData = string.Format("format=xml&action=login&lgname={0}&lgpassword={1}", Options.Account.Username, Options.Account.Password);

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] postBytes = encoding.GetBytes(postData);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetApiUrl());
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            request.AllowAutoRedirect = true;
            var cookieContainer = loginInfo.Cookies ?? new CookieContainer();
            request.CookieContainer = cookieContainer;

            Stream postStream = request.GetRequestStream();
            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Close();

            var response = request.GetResponse();
            string strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // redirected to another page
            if (strResponse.StartsWith("<!DOCTYPE html"))
            {
                if (loginInfo.Redirected)
                {
                    throw new MediaWikiException("Still could not log in after redirection");
                }
                var uri = response.ResponseUri;
                LoginInfo newLoginInfo = LoginRedirected(uri);
                return Login1(newLoginInfo);
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strResponse);
                var loginElement = xmlDoc.GetElementsByTagName("api")[0].ChildNodes[0];
                string result = loginElement.Attributes["result"].Value;
                string token = (loginElement.Attributes["token"] ?? loginElement.Attributes["lgtoken"]).Value;

                bool needToken;
                if (result == "Success")
                    needToken = false;
                else if (result == "NeedToken")
                    needToken = true;
                else
                {
                    HandleError(result);
                    // should not happen since HandleError always throws an exception
                    throw new Exception("Error not handled");
                }

                return new LoginInfo() { Token = token, Cookies = cookieContainer, NeedToken = needToken };
            }
            catch (XmlException)
            {
                throw new MediaWikiException("unexpected answer:\r\n" + strResponse);
            }
        }

        // implemented for a wiki that logs users through another form after a redirection
        private LoginInfo LoginRedirected(Uri uri)
        {
            // These parameter names may be specific. If the need arises, they could be made configurable.
            string postData = string.Format("submit=Login&username={0}&password={1}", Options.Account.Username, Options.Account.Password);

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] postBytes = encoding.GetBytes(postData);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            var cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;

            Stream postStream = request.GetRequestStream();
            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Close();

            var response = request.GetResponse();
            string strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (strResponse.Contains("Authentication Failed"))
                throw new MediaWikiException("Authentication failed");

            //var cookies = cookieContainer.GetCookies(uri);
            return new LoginInfo() { NeedToken = false, Cookies = cookieContainer };
        }

        // login with the token from a first login attempt (if it returned "NeedToken")
        private void LoginWithToken(LoginInfo loginInfo)
        {
            string postData = string.Format("format=xml&action=login&lgname={0}&lgpassword={1}&lgtoken={2}", Options.Account.Username, Options.Account.Password, loginInfo.Token);

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] postBytes = encoding.GetBytes(postData);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetApiUrl());
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            request.CookieContainer = loginInfo.Cookies;

            Stream postStream = request.GetRequestStream();
            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Close();

            var response = request.GetResponse();
            string strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strResponse);
                var loginElement = xmlDoc.GetElementsByTagName("api")[0].ChildNodes[0];
                string result = loginElement.Attributes["result"].Value;

                if (result != "Success")
                    HandleError(result);
            }
            catch (XmlException)
            {
                throw new MediaWikiException("Unexpected answer:\r\n" + strResponse);
            }
        }

        // handle a login error
        private void HandleError(string result)
        {
            string message;
            switch (result)
            {
                case "NoName":
                    message = "You must provide a user name";
                    break;
                case "Illegal":
                    message = "Illegal user name";
                    break;
                case "NotExists":
                    message = "The username you provided doesn't exist";
                    break;
                case "EmptyPass":
                    message = "You must provide a password";
                    break;
                case "WrongPass":
                    message = "The password you provided is incorrect";
                    break;
                case "WrongPluginPass":
                    message = "The password you provided is incorrect (authentication plugin)";
                    break;
                case "CreateBlocked":
                    message = "The wiki tried to automatically create a new account for you, but your IP address has been blocked from account creation";
                    break;
                case "Throttled":
                    message = "You've logged in too many times in a short time. Please wait a few minutes and try again";
                    break;
                case "Blocked":
                    message = "User is blocked";
                    break;
                case "mustbeposted":
                    message = "The login module requires a POST request";
                    break;
                case "NeedToken":
                    message = "Login token needed";
                    break;
                default:
                    message = result;
                    break;
            }
            throw new MediaWikiException(message);
        }

        // query an edit token (needed for upload) after logging in
        private string QueryEditToken(LoginInfo loginInfo)
        {
            string strResponse;
            try
            {
                string postData = "format=xml&action=query&prop=info&intoken=edit&titles=Foo";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] postBytes = encoding.GetBytes(postData);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetApiUrl());
                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;
                request.CookieContainer = loginInfo.Cookies;

                Stream postStream = request.GetRequestStream();
                postStream.Write(postBytes, 0, postBytes.Length);
                postStream.Close();

                var response = request.GetResponse();
                strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                throw new MediaWikiException("Error getting edit token:\r\n" + e.Message);
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strResponse);
                var pageElement = xmlDoc.GetElementsByTagName("api")[0].ChildNodes[0].ChildNodes[0].ChildNodes[0];
                string edittoken = pageElement.Attributes["edittoken"].Value;
                return edittoken;
            }
            catch (Exception)
            {
                throw new MediaWikiException("Unexpected answer while querying edit token from MediaWiki:\r\n" + strResponse);
            }
        }
    }
}