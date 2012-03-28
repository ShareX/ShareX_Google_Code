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
using HelpersLib;
using UploadersLib.HelperClasses;

namespace UploadersLib.FileUploaders
{
    public sealed class FTPUploader : FileUploader
    {
        public FTPAccount FTPAccount;

        public FTPUploader(FTPAccount account)
        {
            FTPAccount = account;
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            UploadResult result = new UploadResult();

            string remotePath = GetRemotePath(fileName);

            try
            {
                stream.Position = 0;

                if (FTPAccount.Protocol == FTPProtocol.SFTP)
                {
                    using (SFTP sftpClient = new SFTP(FTPAccount))
                    {
                        if (!sftpClient.IsInstantiated)
                        {
                            Errors.Add("An SFTP client couldn't be instantiated, not enough information.\r\nCould be a missing key file.");
                        }
                        else
                        {
                            sftpClient.ProgressChanged += new Uploader.ProgressEventHandler(x => OnProgressChanged(x));
                            sftpClient.UploadData(stream, remotePath);
                        }
                    }
                }
                else // FTP or FTPS
                {
                    using (FTP ftpClient = new FTP(FTPAccount))
                    {
                        ftpClient.ProgressChanged += new Uploader.ProgressEventHandler(x => OnProgressChanged(x));
                        ftpClient.UploadData(stream, remotePath);
                    }
                }
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
                Errors.Add(e.Message);
            }

            if (Errors.Count == 0)
            {
                result.URL = FTPAccount.GetUriPath(fileName);
            }

            return result;
        }

        private string GetRemotePath(string fileName)
        {
            fileName = Helpers.ReplaceIllegalChars(fileName, '_');

            while (fileName.IndexOf("__") != -1)
            {
                fileName = fileName.Replace("__", "_");
            }

            return FTPHelpers.CombineURL(FTPAccount.GetSubFolderPath(), fileName);
        }
    }
}