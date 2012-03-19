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
using System.Collections.Generic;
using System.IO;
using System.Text;
using UploadersLib.HelperClasses;

namespace UploadersLib.ImageUploaders
{
    public sealed class MediaWikiUploader
    {
        public MediaWikiOptions Options { get; set; }

        private List<string> Errors { get; set; }

        public string WorkingDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public MediaWikiUploader(MediaWikiOptions options)
        {
            this.Options = options;
            this.Errors = new List<string>();
        }

        public UploadResult UploadImage(string localFilePath)
        {
            // Create the connector
            MediaWiki connector = new MediaWiki(this.Options);

            // Get the file name to save
            string filename = Path.GetFileName(localFilePath);

            // Upload the image
            connector.UploadImage(localFilePath, filename);

            string remotePath = Options.Account.Url + "/index.php?title=Image:" + filename;

            // Create the file manager object
            UploadResult ur = new UploadResult() { URL = remotePath };

            return ur;
        }

        public string ToErrorString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string err in this.Errors)
            {
                sb.AppendLine(err);
            }
            return sb.ToString();
        }
    }
}