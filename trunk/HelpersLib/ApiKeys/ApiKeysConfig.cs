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

using System.ComponentModel;

namespace HelpersLib
{
    public class UploadersAPIKeys
    {
        #region Image Uploaders

        [Category("ImageShack"), DefaultValue(ZKeys.ImageShackKey), Description("ImageShack Key")]
        public string ImageShackKey { get; set; }

        [Category("TinyPic"), DefaultValue(ZKeys.TinyPicID), Description("TinyPic ID")]
        public string TinyPicID { get; set; }

        [Category("TinyPic"), DefaultValue(ZKeys.TinyPicKey), Description("TinyPic Key")]
        public string TinyPicKey { get; set; }

        [Category("Imgur"), DefaultValue(ZKeys.ImgurAnonymousKey), Description("Imgur Anonymous Key")]
        public string ImgurAnonymousKey { get; set; }

        [Category("Imgur"), DefaultValue(ZKeys.ImgurConsumerKey), Description("Imgur Consumer Key")]
        public string ImgurConsumerKey { get; set; }

        [Category("Imgur"), DefaultValue(ZKeys.ImgurConsumerSecret), Description("Imgur Consumer Secret")]
        public string ImgurConsumerSecret { get; set; }

        [Category("Flickr"), DefaultValue(ZKeys.FlickrKey), Description("Flickr Key")]
        public string FlickrKey { get; set; }

        [Category("Flickr"), DefaultValue(ZKeys.FlickrSecret), Description("Flickr Secret")]
        public string FlickrSecret { get; set; }

        [Category("Photobucket"), DefaultValue(ZKeys.PhotobucketConsumerKey), Description("Photobucket Consumer Key")]
        public string PhotobucketConsumerKey { get; set; }

        [Category("Photobucket"), DefaultValue(ZKeys.PhotobucketConsumerSecret), Description("Photobucket Consumer Secret")]
        public string PhotobucketConsumerSecret { get; set; }

        [Category("Uploadscreenshot"), DefaultValue(ZKeys.UploadScreenshotKey), Description("Uploadscreenshot Key")]
        public string UploadScreenshotKey { get; set; }

        [Category("ImageBam"), DefaultValue(ZKeys.ImageBamKey), Description("ImageBam Key")]
        public string ImageBamKey { get; set; }

        [Category("ImageBam"), DefaultValue(ZKeys.ImageBamSecret), Description("ImageBam Secret")]
        public string ImageBamSecret { get; set; }

        [Category("TwitSnaps"), DefaultValue(ZKeys.TwitsnapsKey), Description("TwitSnaps Key")]
        public string TwitsnapsKey { get; set; }

        #endregion Image Uploaders

        #region File Uploaders

        [Category("Dropbox"), DefaultValue(ZKeys.DropboxConsumerKey), Description("Dropbox Consumer Key")]
        public string DropboxConsumerKey { get; set; }

        [Category("Dropbox"), DefaultValue(ZKeys.DropboxConsumerSecret), Description("Dropbox Consumer Secret")]
        public string DropboxConsumerSecret { get; set; }

        [Category("Box"), DefaultValue(ZKeys.BoxKey), Description("Box Key")]
        public string BoxKey { get; set; }

        [Category("Minus"), DefaultValue(ZKeys.MinusConsumerKey), Description("Minus Consumer Secret")]
        public string MinusConsumerKey { get; set; }

        [Category("Minus"), DefaultValue(ZKeys.MinusConsumerSecret), Description("Minus Consumer Secret")]
        public string MinusConsumerSecret { get; set; }

        [Category("SendSpace"), DefaultValue(ZKeys.SendSpaceKey), Description("SendSpace Key")]
        public string SendSpaceKey { get; set; }

        [Category("Drop.IO"), Browsable(false), DefaultValue(ZKeys.DropIOKey), Description("Drop.IO Consumer Secret")]
        public string DropIOKey { get; set; }

        #endregion File Uploaders

        #region Text Uploaders

        [Category("Pastebin"), DefaultValue(ZKeys.PastebinKey), Description("Pastebin Consumer Secret")]
        public string PastebinKey { get; set; }

        [Category("Pastebin"), DefaultValue(ZKeys.PastebinCaKey), Description("Pastebin Consumer Secret")]
        public string PastebinCaKey { get; set; }

        #endregion Text Uploaders

        #region URL Shorteners

        [Category("bit.ly"), DefaultValue(ZKeys.BitlyLogin), Description("bit.ly Consumer Secret")]
        public string BitlyLogin { get; set; }

        [Category("bit.ly"), DefaultValue(ZKeys.BitlyKey), Description("bit.ly Consumer Secret")]
        public string BitlyKey { get; set; }

        [Category("bit.ly"), DefaultValue(ZKeys.BitlyConsumerKey), Description("bit.ly Consumer Secret")]
        public string BitlyConsumerKey { get; set; }

        [Category("bit.ly"), DefaultValue(ZKeys.BitlyConsumerSecret), Description("bit.ly Consumer Secret")]
        public string BitlyConsumerSecret { get; set; }

        [Category("Google"), DefaultValue(ZKeys.GoogleConsumerKey), Description("Google Consumer Key")]
        public string GoogleConsumerKey { get; set; }

        [Category("Google"), DefaultValue(ZKeys.GoogleConsumerSecret), Description("Google Consumer Secret")]
        public string GoogleConsumerSecret { get; set; }

        [Category("kl.am"), Browsable(false), DefaultValue(ZKeys.KlamKey), Description("kl.am key")]
        public string KlamKey { get; set; }

        [Category("3.ly"), Browsable(false), DefaultValue(ZKeys.ThreelyKey), Description("3.ly key")]
        public string ThreelyKey { get; set; }

        #endregion URL Shorteners

        #region Other Services

        [Category("Twitter"), DefaultValue(ZKeys.TwitterConsumerKey), Description("Twitter Consumer Secret")]
        public string TwitterConsumerKey { get; set; }

        [Category("Twitter"), DefaultValue(ZKeys.TwitterConsumerSecret), Description("Twitter Consumer Secret")]
        public string TwitterConsumerSecret { get; set; }

        [Category("Google"), DefaultValue(ZKeys.GoogleApiKey), Description("Google API Key")]
        public string GoogleApiKey { get; set; }

        [Category("Picnik"), DefaultValue(ZKeys.PicnikKey), Description("Picnik Key")]
        public string PicnikKey { get; set; }

        #endregion Other Services

        public UploadersAPIKeys()
        {
            ApplyDefaultValues(this);
        }

        public static void ApplyDefaultValues(object self)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(self))
            {
                DefaultValueAttribute attr = prop.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
                if (attr == null) continue;
                prop.SetValue(self, attr.Value);
            }
        }
    }
}