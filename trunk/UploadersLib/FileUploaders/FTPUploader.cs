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
using System.IO;
using System.Threading;
using HelpersLib;
using UploadersLib.HelperClasses;

namespace UploadersLib.FileUploaders
{
    public class FTPUploader : FileUploader
    {
        public FTPAccount Account;

        private FTP ftpClient;

        public FTPUploader(FTPAccount account)
        {
            Account = account;
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            UploadResult result = new UploadResult();

            fileName = FTPHelpers.FixFilename(fileName);
            string path = Account.GetSubFolderPath(fileName);

            using (ftpClient = new FTP(Account))
            {
                ftpClient.ProgressChanged += new Uploader.ProgressEventHandler(x => OnProgressChanged(x));

                try
                {
                    IsUploading = true;
                    ftpClient.UploadData(stream, path);
                }
                finally
                {
                    IsUploading = false;
                }
            }

            if (!stopUpload && Errors.Count == 0)
            {
                result.URL = Account.GetUriPath(fileName);
            }

            return result;
        }

        public override void StopUpload()
        {
            if (IsUploading && !stopUpload && ftpClient != null)
            {
                stopUpload = true;

                ThreadPool.QueueUserWorkItem(state => ftpClient.StopUpload());
            }
        }

        protected string GetRemotePath(string fileName)
        {
            fileName = Helpers.ReplaceIllegalChars(fileName, '_');

            while (fileName.IndexOf("__") != -1)
            {
                fileName = fileName.Replace("__", "_");
            }

            return FTPHelpers.CombineURL(Account.GetSubFolderPath(), fileName);
        }
    }
}