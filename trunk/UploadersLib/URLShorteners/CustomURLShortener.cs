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

using System.IO;
using System.Text;
using UploadersLib.HelperClasses;

namespace UploadersLib.URLShorteners
{
    public sealed class CustomURLShortener : URLShortener
    {
        private CustomUploaderItem customUploader;

        public CustomURLShortener(CustomUploaderItem customUploaderItem)
        {
            customUploader = customUploaderItem;
        }

        public override string ShortenURL(string url)
        {
            customUploader.SetInput(url);

            UploadResult result = new UploadResult();

            if (customUploader.RequestType == CustomUploaderRequestType.POST)
            {
                result.Response = SendPostRequest(customUploader.RequestURL, customUploader.Arguments);
            }
            else if (customUploader.RequestType == CustomUploaderRequestType.GET)
            {
                result.Response = SendGetRequest(customUploader.RequestURL, customUploader.Arguments);
            }

            if (result.IsSuccess)
            {
                customUploader.Parse(result.Response);

                result.URL = customUploader.ResultURL;
                result.ThumbnailURL = customUploader.ResultThumbnailURL;
                result.DeletionURL = customUploader.ResultDeletionURL;

                return result.URL;
            }

            return null;
        }
    }
}