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
using HistoryLib;
using UploadersLib.HelperClasses;

namespace ShareX
{
    public class UploadInfo
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public TaskJob Job { get; set; }
        public TaskImageJob ImageJob { get; set; }

        public bool IsUploadJob
        {
            get
            {
                return Job != TaskJob.ImageJob || ImageJob.HasFlag(TaskImageJob.UploadImageToHost);
            }
        }

        public ProgressManager Progress { get; set; }

        private string filePath;

        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
                FileName = Path.GetFileName(filePath);
            }
        }

        public string FileName { get; set; }
        public EDataType DataType { get; set; }

        private EDataType uploadDestination;

        public EDataType UploadDestination
        {
            get
            {
                return uploadDestination;
            }
            set
            {
                uploadDestination = value;

                switch (uploadDestination)
                {
                    case EDataType.File:
                        UploaderHost = UploadManager.FileUploader.GetDescription();
                        break;
                    case EDataType.Image:
                        UploaderHost = UploadManager.ImageUploader.GetDescription();
                        break;
                    case EDataType.Text:
                        UploaderHost = UploadManager.TextUploader.GetDescription();
                        break;
                    case EDataType.URL:
                        UploaderHost = UploadManager.URLShortener.GetDescription();
                        break;
                }
            }
        }

        public string UploaderHost { get; private set; }
        public DateTime StartTime { get; set; }
        public DateTime UploadTime { get; set; }

        public TimeSpan UploadDuration
        {
            get { return UploadTime - StartTime; }
        }

        public UploadResult Result { get; set; }

        public UploadInfo()
        {
            Result = new UploadResult();
            ImageJob = TaskImageJob.UploadImageToHost;
        }

        public HistoryItem GetHistoryItem()
        {
            return new HistoryItem
            {
                Filename = FileName,
                Filepath = FilePath,
                DateTimeUtc = UploadTime,
                Type = UploadDestination.ToString(),
                Host = UploaderHost,
                URL = Result.URL,
                ThumbnailURL = Result.ThumbnailURL,
                DeletionURL = Result.DeletionURL,
                ShortenedURL = Result.ShortenedURL
            };
        }
    }
}