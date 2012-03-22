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

using System.Collections.Generic;
using System.IO;
using HelpersLib;
using UploadersLib.HelperClasses;

namespace UploadersLib.ImageUploaders
{
    public sealed class ImageShackUploader : ImageUploader
    {
        public AccountType AccountType { get; private set; }

        public bool IsPublic { get; set; }

        private string DeveloperKey { get; set; }

        private string RegistrationCode { get; set; }

        public override string Host
        {
            get
            {
                return ImageDestination.ImageShack.GetDescription();
            }
        }

        public ImageShackUploader(string developerKey, AccountType accountType = AccountType.Anonymous, string registrationCode = null)
        {
            DeveloperKey = developerKey;
            AccountType = accountType;
            RegistrationCode = registrationCode;
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            UploadResult ur = new UploadResult();

            Dictionary<string, string> arguments = new Dictionary<string, string>();
            arguments.Add("key", DeveloperKey);
            arguments.Add("public", IsPublic ? "yes" : "no");

            if (AccountType == AccountType.User && !string.IsNullOrEmpty(RegistrationCode))
            {
                arguments.Add("cookie", RegistrationCode);
            }

            ur.Source = UploadData(stream, "http://www.imageshack.us/upload_api.php", fileName, "fileupload", arguments);

            if (!string.IsNullOrEmpty(ur.Source))
            {
                ur.URL = ZAppHelper.GetXMLValue(ur.Source, "image_link");
                ur.ThumbnailURL = ZAppHelper.GetXMLValue(ur.Source, "thumb_link");
            }

            return ur;
        }
    }
}