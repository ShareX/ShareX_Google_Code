#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (C) 2008-2013 ShareX Developers

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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using UploadersLib.HelperClasses;

namespace UploadersLib.FileUploaders
{
    public sealed class Localhostr : FileUploader
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool DirectURL { get; set; }

        public Localhostr(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            UploadResult result = null;

            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                NameValueCollection headers = CreateAuthenticationHeader(Email, Password);
                result = UploadData(stream, "https://api.localhostr.com/file", fileName, "file", null, null, headers);

                if (result.IsSuccess)
                {
                    LocalhostrFileUploadResponse response = JsonConvert.DeserializeObject<LocalhostrFileUploadResponse>(result.Response);

                    if (response != null)
                    {
                        if (DirectURL && response.direct != null)
                        {
                            result.URL = string.Format("http://localhostr.com/file/{0}/{1}", response.id, response.name);
                            result.ThumbnailURL = response.direct.direct_150x;
                        }
                        else
                        {
                            result.URL = response.href;
                        }
                    }
                }
            }

            return result;
        }

        public class LocalhostrFileUploadResponse
        {
            public string added { get; set; }
            public string name { get; set; }
            public string href { get; set; }
            public int size { get; set; }
            public string type { get; set; }
            public LocalhostrFileUploadResponseDirect direct { get; set; }
            public string id { get; set; }
        }

        public class LocalhostrFileUploadResponseDirect
        {
            [JsonProperty("150x")]
            public string direct_150x { get; set; }
            [JsonProperty("930x")]
            public string direct_930x { get; set; }
        }
    }
}