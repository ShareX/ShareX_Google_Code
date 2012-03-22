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
using UploadersLib.HelperClasses;

namespace UploadersLib.ImageUploaders
{
    public sealed class CustomUploader : FileUploader
    {
        private CustomUploaderInfo imageHosting;

        public CustomUploader(CustomUploaderInfo imageHosting)
        {
            this.imageHosting = imageHosting;
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            string response = UploadData(stream, imageHosting.UploadURL, fileName, imageHosting.FileFormName, imageHosting.GetArguments());

            UploadResult result = new UploadResult(response);

            if (!string.IsNullOrEmpty(response))
            {
                imageHosting.Parse(response);

                if (!string.IsNullOrEmpty(imageHosting.URL))
                {
                    result.URL = imageHosting.GetURL(URLType.URL);
                }
                else if (imageHosting.AutoUseResponse)
                {
                    result.URL = response;
                }

                if (!string.IsNullOrEmpty(imageHosting.ThumbnailURL))
                {
                    result.ThumbnailURL = imageHosting.GetURL(URLType.ThumbnailURL);
                }

                if (!string.IsNullOrEmpty(imageHosting.DeletionURL))
                {
                    result.DeletionURL = imageHosting.GetURL(URLType.DeletionURL);
                }
            }

            return result;
        }
    }
}