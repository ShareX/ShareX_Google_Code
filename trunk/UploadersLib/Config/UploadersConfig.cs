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
using System.Windows.Forms;
using HelpersLib;
using UploadersLib.FileUploaders;
using UploadersLib.HelperClasses;
using UploadersLib.ImageUploaders;
using UploadersLib.TextUploaders;

namespace UploadersLib
{
    public class UploadersConfig : SettingsBase<UploadersConfig>
    {
        #region Image uploaders

        // ImageShack

        public AccountType ImageShackAccountType = AccountType.Anonymous;
        public string ImageShackRegistrationCode = string.Empty;
        public string ImageShackUsername = string.Empty;
        public bool ImageShackShowImagesInPublic = false;

        // TinyPic

        public AccountType TinyPicAccountType = AccountType.Anonymous;
        public string TinyPicRegistrationCode = string.Empty;
        public string TinyPicUsername = string.Empty;
        public string TinyPicPassword = string.Empty;
        public bool TinyPicRememberUserPass = false;

        // Imgur

        public AccountType ImgurAccountType = AccountType.Anonymous;
        public ImgurThumbnailType ImgurThumbnailType = ImgurThumbnailType.Large_Thumbnail;
        public OAuthInfo ImgurOAuthInfo = null;

        // Flickr

        public FlickrAuthInfo FlickrAuthInfo = new FlickrAuthInfo();
        public FlickrSettings FlickrSettings = new FlickrSettings();

        // Photobucket

        public OAuthInfo PhotobucketOAuthInfo = null;
        public PhotobucketAccountInfo PhotobucketAccountInfo = null;

        // TwitPic

        public bool TwitPicShowFull = false;
        public TwitPicThumbnailType TwitPicThumbnailMode = TwitPicThumbnailType.Thumb;

        // YFrog

        public string YFrogUsername = string.Empty;
        public string YFrogPassword = string.Empty;

        #endregion Image uploaders

        #region Text uploaders

        // Pastebin

        public PastebinSettings PastebinSettings = new PastebinSettings();

        // Paste.ee

        public string Paste_eeUserAPIKey = "public";

        #endregion Text uploaders

        #region File uploaders

        // Dropbox

        public OAuthInfo DropboxOAuthInfo = null;
        public string DropboxUploadPath = "Public/" + Application.ProductName + "/%y-%mo";
        public bool DropboxAutoCreateShareableLink = false;
        public DropboxAccountInfo DropboxAccountInfo = null;

        // RapidShare

        public string RapidShareUsername = string.Empty;
        public string RapidSharePassword = string.Empty;
        public string RapidShareFolderID = string.Empty;

        // SendSpace

        public AccountType SendSpaceAccountType = AccountType.Anonymous;
        public string SendSpaceUsername = string.Empty;
        public string SendSpacePassword = string.Empty;

        // Minus

        public MinusOptions MinusConfig = new MinusOptions();

        // Box

        public string BoxTicket = string.Empty;
        public string BoxAuthToken = string.Empty;
        public string BoxFolderID = "0";
        public bool BoxShare = true;

        // Ge.tt

        public Ge_ttLogin Ge_ttLogin = null;

        // Custom Uploader

        public List<CustomUploaderInfo> CustomUploadersList = new List<CustomUploaderInfo>();
        public int CustomUploaderSelected = 0;

        // FTP Server

        public List<FTPAccount> FTPAccountList = new List<FTPAccount>();
        public int FTPSelectedImage = 0;
        public int FTPSelectedText = 0;
        public int FTPSelectedFile = 0;

        // Shared Folder

        public List<LocalhostAccount> LocalhostAccountList = new List<LocalhostAccount>();
        public int LocalhostSelectedImages = 0;
        public int LocalhostSelectedText = 0;
        public int LocalhostSelectedFiles = 0;

        // Email

        public string EmailSmtpServer = "smtp.gmail.com";
        public int EmailSmtpPort = 587;
        public string EmailFrom = "...@gmail.com";
        public string EmailPassword = string.Empty;
        public bool EmailRememberLastTo = true;
        public bool EmailConfirmSend = true;
        public string EmailLastTo = string.Empty;
        public string EmailDefaultSubject = "Sending email from " + Application.ProductName;
        public string EmailDefaultBody = "Screenshot is attached.";

        #endregion File uploaders

        #region URL shorteners

        public AccountType GoogleURLShortenerAccountType = AccountType.Anonymous;
        public OAuthInfo GoogleURLShortenerOAuthInfo = null;

        #endregion URL shorteners

        #region Social networking services

        // Twitter

        public List<OAuthInfo> TwitterOAuthInfoList = new List<OAuthInfo>();
        public int TwitterSelectedAccount = 0;
        public TwitterClientSettings TwitterClientConfig = new TwitterClientSettings();

        #endregion Social networking services

        #region Helper Methods

        public bool IsActive<T>(int index)
        {
            Enum destination = (Enum)Enum.ToObject(typeof(T), index);

            if (destination is ImageDestination)
            {
                return IsActive((ImageDestination)destination);
            }
            else if (destination is TextDestination)
            {
                return IsActive((TextDestination)destination);
            }
            else if (destination is FileDestination)
            {
                return IsActive((FileDestination)destination);
            }
            else if (destination is UrlShortenerType)
            {
                return IsActive((UrlShortenerType)destination);
            }
            else if (destination is SocialNetworkingService)
            {
                return IsActive((SocialNetworkingService)destination);
            }

            return true;
        }

        public bool IsActive(ImageDestination destination)
        {
            switch (destination)
            {
                case ImageDestination.ImageShack:
                    return ImageShackAccountType == AccountType.Anonymous || !string.IsNullOrEmpty(ImageShackRegistrationCode);
                case ImageDestination.TinyPic:
                    return TinyPicAccountType == AccountType.Anonymous || !string.IsNullOrEmpty(TinyPicRegistrationCode);
                case ImageDestination.Imgur:
                    return ImgurAccountType == AccountType.Anonymous || OAuthInfo.CheckOAuth(ImgurOAuthInfo);
                case ImageDestination.Flickr:
                    return !string.IsNullOrEmpty(FlickrAuthInfo.Token);
                case ImageDestination.Photobucket:
                    return PhotobucketAccountInfo != null && OAuthInfo.CheckOAuth(PhotobucketOAuthInfo);
                case ImageDestination.Twitpic:
                case ImageDestination.Twitsnaps:
                    return TwitterOAuthInfoList != null && TwitterOAuthInfoList.IsValidIndex(TwitterSelectedAccount);
                case ImageDestination.yFrog:
                    return !string.IsNullOrEmpty(YFrogUsername) && !string.IsNullOrEmpty(YFrogPassword);
                default:
                    return true;
            }
        }

        public bool IsActive(TextDestination destination)
        {
            switch (destination)
            {
                default:
                    return true;
            }
        }

        public bool IsActive(FileDestination destination)
        {
            switch (destination)
            {
                case FileDestination.Dropbox:
                    return OAuthInfo.CheckOAuth(DropboxOAuthInfo);
                case FileDestination.RapidShare:
                    return !string.IsNullOrEmpty(RapidShareUsername) && !string.IsNullOrEmpty(RapidSharePassword);
                case FileDestination.SendSpace:
                    return SendSpaceAccountType == AccountType.Anonymous || (!string.IsNullOrEmpty(SendSpaceUsername) && !string.IsNullOrEmpty(SendSpacePassword));
                case FileDestination.Minus:
                    return MinusConfig != null && MinusConfig.MinusUser != null;
                case FileDestination.Box:
                    return !string.IsNullOrEmpty(BoxAuthToken);
                case FileDestination.Ge_tt:
                    return Ge_ttLogin != null && !string.IsNullOrEmpty(Ge_ttLogin.AccessToken);
                case FileDestination.CustomUploader:
                    return CustomUploadersList != null && CustomUploadersList.IsValidIndex(CustomUploaderSelected);
                case FileDestination.FTP:
                    return FTPAccountList != null && FTPAccountList.IsValidIndex(FTPSelectedFile);
                case FileDestination.SharedFolder:
                    return LocalhostAccountList != null && LocalhostAccountList.IsValidIndex(LocalhostSelectedFiles);
                case FileDestination.Email:
                    return !string.IsNullOrEmpty(EmailSmtpServer) && EmailSmtpPort > 0 && !string.IsNullOrEmpty(EmailFrom) && !string.IsNullOrEmpty(EmailPassword);
                default:
                    return true;
            }
        }

        public bool IsActive(UrlShortenerType destination)
        {
            switch (destination)
            {
                case UrlShortenerType.Google:
                    return GoogleURLShortenerAccountType == AccountType.Anonymous || OAuthInfo.CheckOAuth(GoogleURLShortenerOAuthInfo);
                default:
                    return true;
            }
        }

        public bool IsActive(SocialNetworkingService destination)
        {
            switch (destination)
            {
                case SocialNetworkingService.Twitter:
                    return TwitterOAuthInfoList != null && TwitterOAuthInfoList.IsValidIndex(TwitterSelectedAccount);
                default:
                    return true;
            }
        }

        public int GetFTPIndex(EDataType dataType)
        {
            switch (dataType)
            {
                case EDataType.Image:
                    return FTPSelectedImage;
                case EDataType.Text:
                    return FTPSelectedText;
                default:
                    return FTPSelectedFile;
            }
        }

        public int GetLocalhostIndex(EDataType dataType)
        {
            switch (dataType)
            {
                case EDataType.Image:
                    return LocalhostSelectedImages;
                case EDataType.Text:
                    return LocalhostSelectedText;
                default:
                    return LocalhostSelectedFiles;
            }
        }

        #endregion Helper Methods
    }
}