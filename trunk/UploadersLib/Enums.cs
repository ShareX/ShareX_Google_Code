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

namespace UploadersLib
{
    public enum ImageDestination
    {
        [Description("imageshack.us")]
        ImageShack,
        [Description("tinypic.com")]
        TinyPic,
        [Description("imgur.com")]
        Imgur,
        [Description("flickr.com")]
        Flickr,
        [Description("photobucket.com")]
        Photobucket,
        [Description("uploadscreenshot.com")]
        UploadScreenshot,
        [Description("twitpic.com")]
        Twitpic,
        [Description("twitsnaps.com")]
        Twitsnaps,
        [Description("yfrog.com")]
        yFrog,
        [Description("imm.io")]
        Immio,
        [Description("File Uploader")]
        FileUploader
    }

    public enum TextDestination
    {
        [Description("pastebin.com")]
        Pastebin,
        [Description("pastebin.ca")]
        PastebinCA,
        [Description("paste2.org")]
        Paste2,
        [Description("slexy.org")]
        Slexy,
        [Description("pastee.org")]
        Pastee,
        [Description("File Uploader")]
        FileUploader
    }

    public enum FileDestination
    {
        [Description("dropbox.com")]
        Dropbox,
        [Description("rapidshare.com")]
        RapidShare,
        [Description("sendspace.com")]
        SendSpace,
        [Description("minus.com")]
        Minus,
        [Description("box.com")]
        Box,
        [Description("Custom Uploader")]
        CustomUploader,
        [Description("FTP Server")]
        FTP,
        [Description("Shared Folder")]
        SharedFolder,
        [Description("Email")]
        Email
    }

    public enum UrlShortenerType
    {
        [Description("goo.gl")]
        Google,
        [Description("bit.ly")]
        BITLY,
        [Description("j.mp")]
        Jmp,
        [Description("is.gd")]
        ISGD,
        [Description("tinyurl.com")]
        TINYURL,
        [Description("turl.ca")]
        TURL
    }

    public enum HttpMethod
    {
        [Description("GET")]
        Get,
        [Description("POST")]
        Post,
        [Description("DELETE")]
        Delete
    }

    public enum ResponseType
    {
        Text, RedirectionURL
    }

    public enum Proxy
    {
        [Description("HTTP Proxy")]
        HTTP,
        [Description("SOCKS v4 Proxy")]
        SOCKS4,
        [Description("SOCKS v4a Proxy")]
        SOCKS4a,
        [Description("SOCKS v5 Proxy")]
        SOCKS5
    }

    public enum FTPProtocol
    {
        [Description("FTP")]
        FTP,
        [Description("FTPS (FTP over SSL)")]
        FTPS,
        [Description("SFTP (SSH FTP)")]
        SFTP
    }

    public enum BrowserProtocol
    {
        [Description("http://")]
        Http,
        [Description("https://")]
        Https,
        [Description("Same as ServerProtocol")]
        ServerProtocol,
        [Description("file://")]
        File
    }

    public enum ServerProtocol
    {
        [Description("ftp://")]
        Ftp,
        [Description("ftps://")]
        Ftps
    }

    public enum LinkType
    {
        URL,
        ThumbnailURL,
        DeletionLink,
        FULLIMAGE_TINYURL
    }

    public enum URLType
    {
        URL, ThumbnailURL, DeletionURL
    }

    public enum Privacy
    {
        Public, Private
    }

    public enum AccountType
    {
        [Description("Anonymous")]
        Anonymous,
        [Description("User")]
        User
    }

    public enum OutputEnum
    {
        [Description("Clipboard")]
        Clipboard,
        [Description("File")]
        LocalDisk,
        [Description("Upload")]
        RemoteHost,
        [Description("E-mail")]
        Email,
        [Description("Printer")]
        Printer,
        [Description("Shared folder")]
        SharedFolder
    }

    public enum ClipboardContentEnum
    {
        [Description("Image or Text")]
        Data,
        [Description("Local file path")]
        Local,
        [Description("Uploaded URL")]
        Remote,
        [Description("Text using OCR")]
        OCR
    }

    public enum LinkFormatEnum
    {
        [Description("Full URL")]
        FULL,
        [Description("Full Image for Forums")]
        FULL_IMAGE_FORUMS,
        [Description("Full Image as HTML")]
        FULL_IMAGE_HTML,
        [Description("Full Image for Wiki")]
        FULL_IMAGE_WIKI,
        [Description("Full Image Link for MediaWiki")]
        FULL_IMAGE_MEDIAWIKI,
        [Description("Shortened URL")]
        FULL_TINYURL,
        [Description("Linked Thumbnail for Forums")]
        LINKED_THUMBNAIL,
        [Description("Linked Thumbnail as HTML")]
        LinkedThumbnailHtml,
        [Description("Linked Thumbnail for Wiki")]
        LINKED_THUMBNAIL_WIKI,
        [Description("Thumbnail")]
        THUMBNAIL,
        [Description("Local File path")]
        LocalFilePath,
        [Description("Local File path as URI")]
        LocalFilePathUri
    }
}