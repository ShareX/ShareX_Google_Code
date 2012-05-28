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
using System.ComponentModel;
using System.Linq;
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
        public UploadersConfig()
        {
            PasswordsEncryptionStrength = EncryptionStrength.High;
            TestPassword = "password";
        }

        #region General

        [Category(ComponentModelStrings.AppPasswords), DefaultValue(false), Description("Encrypt passwords using AES")]
        public bool PasswordsSecureUsingEncryption { get; set; }

        [Browsable(false), Category(ComponentModelStrings.AppPasswords), DefaultValue(EncryptionStrength.High), Description("Strength can be Low = 128, Medium = 192, or High = 256")]
        public EncryptionStrength PasswordsEncryptionStrength { get; set; }

        [Browsable(false), Category(ComponentModelStrings.AppPasswords), DefaultValue("password"), Description("If this SamplePassword displayed as 'password' then configuration is not encrypted.")]
        public string TestPassword { get; set; }

        #endregion General

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

        #region File uploaders

        // FTP

        public List<FTPAccount> FTPAccountList = new List<FTPAccount>();
        public int FTPSelectedImage = 0;
        public int FTPSelectedText = 0;
        public int FTPSelectedFile = 0;
        public int FTPThumbnailWidthLimit = 150;

        // If image size smaller than thumbnail size then not make thumbnail
        public bool FTPThumbnailCheckSize = true;

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

        // Custom Uploaders

        public List<CustomUploaderInfo> CustomUploadersList = new List<CustomUploaderInfo>();
        public int CustomUploaderSelected = 0;

        #endregion File uploaders

        #region Text uploaders

        // Pastebin

        public PastebinSettings PastebinSettings = new PastebinSettings();

        #endregion Text uploaders

        #region URL shorteners

        public AccountType GoogleURLShortenerAccountType = AccountType.Anonymous;
        public OAuthInfo GoogleURLShortenerOAuthInfo = null;

        #endregion URL shorteners

        #region Other services

        // Twitter

        public List<OAuthInfo> TwitterOAuthInfoList = new List<OAuthInfo>();
        public int TwitterSelectedAccount = 0;
        public TwitterClientSettings TwitterClientConfig = new TwitterClientSettings();
        public bool TwitterEnabled = false;

        #endregion Other services

        #region Other destinations

        // Localhost

        public List<LocalhostAccount> LocalhostAccountList = new List<LocalhostAccount>();
        public int LocalhostSelectedImages = 0;
        public int LocalhostSelectedText = 0;
        public int LocalhostSelectedFiles = 0;

        #endregion Other destinations

        #region Helper Methods

        public bool IsActive(FileDestination ut)
        {
            switch (ut)
            {
                case FileDestination.Dropbox:
                    return DropboxOAuthInfo != null && !string.IsNullOrEmpty(DropboxOAuthInfo.UserToken) && !string.IsNullOrEmpty(DropboxOAuthInfo.UserSecret);
                case FileDestination.RapidShare:
                    return !string.IsNullOrEmpty(RapidShareUsername) && !string.IsNullOrEmpty(RapidSharePassword);
                case FileDestination.SendSpace:
                    return SendSpaceAccountType == AccountType.Anonymous || (!string.IsNullOrEmpty(SendSpaceUsername) && !string.IsNullOrEmpty(SendSpacePassword));
                case FileDestination.Minus:
                    return MinusConfig != null && MinusConfig.MinusUser != null;
                case FileDestination.Box:
                    return !string.IsNullOrEmpty(BoxAuthToken);
                case FileDestination.CustomUploader:
                    return CustomUploadersList != null && CustomUploadersList.Count > 0;
                case FileDestination.FTP:
                    return FTPAccountList != null && FTPAccountList.Count > 0;
                case FileDestination.SharedFolder:
                    return LocalhostAccountList != null && LocalhostAccountList.Count > 0;
                default:
                    return true;
            }
        }

        public bool IsActive(TextDestination ut)
        {
            switch (ut)
            {
                case TextDestination.FileUploader:
                    return Enum.GetValues(typeof(FileDestination)).Cast<FileDestination>().Any(fu => IsActive(fu));
                default:
                    return true;
            }
        }

        public bool IsActive(ImageDestination ut)
        {
            switch (ut)
            {
                case ImageDestination.Flickr:
                    return !string.IsNullOrEmpty(FlickrAuthInfo.Token);
                case ImageDestination.ImageShack:
                    return ImageShackAccountType == AccountType.Anonymous || !string.IsNullOrEmpty(ImageShackRegistrationCode);
                case ImageDestination.TinyPic:
                    return TinyPicAccountType == AccountType.Anonymous || !string.IsNullOrEmpty(TinyPicRegistrationCode);
                case ImageDestination.Imgur:
                    return ImgurAccountType == AccountType.Anonymous || ImgurAccountType == AccountType.User && ImgurOAuthInfo != null && !string.IsNullOrEmpty(ImgurOAuthInfo.UserToken) && !string.IsNullOrEmpty(ImgurOAuthInfo.UserSecret);
                case ImageDestination.Photobucket:
                    return PhotobucketAccountInfo != null && PhotobucketOAuthInfo != null;
                case ImageDestination.Twitpic:
                case ImageDestination.Twitsnaps:
                    return TwitterOAuthInfoList.Count > 0;
                case ImageDestination.UploadScreenshot:
                    return true;
                case ImageDestination.yFrog:
                    return !string.IsNullOrEmpty(YFrogPassword);
                case ImageDestination.Immio:
                    return true;
                case ImageDestination.FileUploader:
                    return Enum.GetValues(typeof(FileDestination)).Cast<FileDestination>().Any(fu => IsActive(fu));
            }

            return false;
        }

        public void CryptPasswords(bool doEncrypt)
        {
            bool isEncrypted = TestPassword != "password";

            if (doEncrypt && isEncrypted || !doEncrypt && !isEncrypted)
            {
                // ensure encrupted passwords are not encrypted again or decrypted passwords are not decrypted again
                return;
            }

            DebugHelper.WriteLine((doEncrypt ? "Encrypting " : "Decrypting") + " passwords.");

            CryptKeys crypt = new CryptKeys() { KeySize = this.PasswordsEncryptionStrength };

            this.TestPassword = doEncrypt ? crypt.Encrypt(TestPassword) : crypt.Decrypt(TestPassword);

            this.TinyPicPassword = doEncrypt ? crypt.Encrypt(this.TinyPicPassword) : crypt.Decrypt(this.TinyPicPassword);

            this.RapidSharePassword = doEncrypt ? crypt.Encrypt(this.RapidSharePassword) : crypt.Decrypt(this.RapidSharePassword);

            this.SendSpacePassword = doEncrypt ? crypt.Encrypt(this.SendSpacePassword) : crypt.Decrypt(this.SendSpacePassword);

            foreach (FTPAccount acc in this.FTPAccountList)
            {
                acc.Password = doEncrypt ? crypt.Encrypt(acc.Password) : crypt.Decrypt(acc.Password);
                acc.Passphrase = doEncrypt ? crypt.Encrypt(acc.Passphrase) : crypt.Decrypt(acc.Passphrase);
            }

            foreach (LocalhostAccount acc in this.LocalhostAccountList)
            {
                acc.Password = doEncrypt ? crypt.Encrypt(acc.Password) : crypt.Decrypt(acc.Password);
            }

            this.EmailPassword = doEncrypt ? crypt.Encrypt(this.EmailPassword) : crypt.Decrypt(this.EmailPassword);
        }

        public int GetFtpIndex(EDataType dataType)
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

        #region I/O Methods

        public static new UploadersConfig Load(string filePath)
        {
            UploadersConfig config = SettingsBase<UploadersConfig>.Load(filePath);
            if (config.PasswordsSecureUsingEncryption) config.CryptPasswords(false);
            return config;
        }

        public override bool Save(string filePath)
        {
            bool result;
            if (PasswordsSecureUsingEncryption) CryptPasswords(true);
            result = base.Save(filePath);
            if (PasswordsSecureUsingEncryption) CryptPasswords(false);
            return result;
        }

        #endregion I/O Methods
    }
}