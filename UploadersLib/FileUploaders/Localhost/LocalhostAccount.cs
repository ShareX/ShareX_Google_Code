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
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Web;
using System.Windows.Forms.Design;
using HelpersLib;

namespace UploadersLib
{
    public class LocalhostAccount
    {
        [Category("Localhost"), Description("Shown in the list as: Name - LocalhostRoot:Port")]
        public string Name { get; set; }

        [Category("Localhost"), Description(@"Root folder, e.g. C:\Inetpub\wwwroot")]
        [EditorAttribute(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string LocalhostRoot { get; set; }

        [Category("Localhost"), Description("Port Number"), DefaultValue(80)]
        public int Port { get; set; }

        [Category("Localhost")]
        public string UserName { get; set; }

        [Category("Localhost"), PasswordPropertyText(true)]
        public string Password { get; set; }

        [Category("Localhost"), Description("Localhost Sub-folder Path, e.g. screenshots, %y = year, %mo = month. SubFolderPath will be automatically appended to HttpHomePath if HttpHomePath does not start with @"), DefaultValue("")]
        public string SubFolderPath { get; set; }

        [Category("Localhost"), Description("HTTP Home Path, %host = Host e.g. google.com without http:// because you choose that in Remote Protocol.\nURL = HttpHomePath (+ SubFolderPath, if HttpHomePath does not start with @) + FileName\nURL = Host + SubFolderPath + FileName (if HttpHomePath is empty)"), DefaultValue("")]
        public string HttpHomePath { get; set; }

        [Category("Localhost"), Description("Choose an appropriate protocol to be accessed by the browser. Use 'file' for Shared Folders. RemoteProtocol will always be 'file' if HTTP Home Path is empty. "), DefaultValue(BrowserProtocol.File)]
        public BrowserProtocol RemoteProtocol { get; set; }

        [Category("Localhost"), Description("file://Host:Port"), Browsable(false)]
        public string LocalUri
        {
            get
            {
                if (string.IsNullOrEmpty(this.LocalhostRoot))
                {
                    return string.Empty;
                }

                return new Uri(LocalhostRoot).AbsoluteUri;
            }
        }

        private string exampleFilename = "screenshot.jpg";

        [Category("Localhost"), Description("Preview of the Localhost Path based on the settings above")]
        public string PreviewLocalPath
        {
            get
            {
                return GetLocalhostUri(exampleFilename);
            }
        }

        [Category("Localhost"), Description("Preview of the HTTP Path based on the settings above")]
        public string PreviewRemotePath
        {
            get
            {
                return GetUriPath(exampleFilename);
            }
        }

        public LocalhostAccount()
        {
            ApplyDefaultValues(this);
        }

        public LocalhostAccount(string name)
            : this()
        {
            this.Name = name;
        }

        public string GetSubFolderPath()
        {
            NameParser parser = new NameParser { Host = this.LocalhostRoot, IsFolderPath = true };
            return parser.Convert(this.SubFolderPath);
        }

        public string GetHttpHomePath()
        {
            NameParser parser = new NameParser { Host = this.LocalhostRoot, IsFolderPath = true };
            HttpHomePath = parser.RemovePrefixes(HttpHomePath);
            return parser.Convert(HttpHomePath);
        }

        public string GetUriPath(string fileName)
        {
            return GetUriPath(fileName, false);
        }

        public string GetUriPath(string fileName, bool customPath)
        {
            if (string.IsNullOrEmpty(this.LocalhostRoot))
            {
                return string.Empty;
            }

            fileName = HttpUtility.UrlEncode(fileName).Replace("+", "%20");
            string path = string.Empty;
            string httppath = string.Empty;
            string lHttpHomePath = GetHttpHomePath();
            if (string.IsNullOrEmpty(lHttpHomePath))
            {
                RemoteProtocol = BrowserProtocol.File;
            }
            else if (!string.IsNullOrEmpty(lHttpHomePath) && RemoteProtocol == BrowserProtocol.File)
            {
                RemoteProtocol = BrowserProtocol.Http;
            }

            string lFolderPath = this.GetSubFolderPath();

            if (lHttpHomePath.StartsWith("@") || customPath)
            {
                lFolderPath = string.Empty;
            }

            if (string.IsNullOrEmpty(lHttpHomePath))
            {
                httppath = LocalUri.Replace("file://", "");
            }
            else
            {
                httppath = lHttpHomePath.Replace("%host", this.LocalhostRoot).TrimStart('@');
            }
            path = FTPHelpers.CombineURL(this.Port == 80 ? httppath : string.Format("{0}:{1}", httppath, this.Port), lFolderPath, fileName);

            if (!path.StartsWith(RemoteProtocol.GetDescription()))
            {
                path = RemoteProtocol.GetDescription() + path;
            }

            return path;
        }

        public string GetLocalhostPath(string fileName)
        {
            if (string.IsNullOrEmpty(LocalhostRoot))
            {
                return string.Empty;
            }
            return Path.Combine(Path.Combine(LocalhostRoot, this.GetSubFolderPath()), fileName);
        }

        public string GetLocalhostUri(string fileName)
        {
            string LocalhostAddress = this.LocalUri;

            if (string.IsNullOrEmpty(LocalhostAddress))
            {
                return string.Empty;
            }

            return FTPHelpers.CombineURL(LocalhostAddress, this.GetSubFolderPath(), fileName);
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

        public override string ToString()
        {
            return string.Format("{0} - {1}:{2}", this.Name, this.LocalhostRoot, this.Port);
        }
    }
}