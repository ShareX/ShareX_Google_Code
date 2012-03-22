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

// http://aspnetupload.com
// Copyright � 2009 Krystalware, Inc.
//
// This work is licensed under a Creative Commons Attribution-Share Alike 3.0 United States License
// http://creativecommons.org/licenses/by-sa/3.0/us/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Krystalware.UploadHelper
{
    public class HttpUploadHelper
    {
        private HttpUploadHelper()
        { }

        public static string Upload(string url, UploadFile[] files, NameValueCollection form)
        {
            HttpWebResponse resp = Upload((HttpWebRequest)WebRequest.Create(url), files, form);

            using (Stream s = resp.GetResponseStream())
            using (StreamReader sr = new StreamReader(s))
            {
                return sr.ReadToEnd();
            }
        }

        public static HttpWebResponse Upload(HttpWebRequest req, UploadFile[] files, NameValueCollection form)
        {
            List<MimePart> mimeParts = new List<MimePart>();

            try
            {
                foreach (string key in form.AllKeys)
                {
                    StringMimePart part = new StringMimePart();

                    part.Headers["Content-Disposition"] = "form-data; name=\"" + key + "\"";
                    part.StringData = form[key];

                    mimeParts.Add(part);
                }

                int nameIndex = 0;

                foreach (UploadFile file in files)
                {
                    StreamMimePart part = new StreamMimePart();

                    if (string.IsNullOrEmpty(file.FieldName))
                        file.FieldName = "file" + nameIndex++;

                    part.Headers["Content-Disposition"] = "form-data; name=\"" + file.FieldName + "\"; filename=\"" + file.FileName + "\"";
                    part.Headers["Content-Type"] = file.ContentType;

                    part.SetStream(file.Data);

                    mimeParts.Add(part);
                }

                string boundary = "----------" + DateTime.Now.Ticks.ToString("x");

                req.ContentType = "multipart/form-data; boundary=" + boundary;
                req.Method = "POST";

                long contentLength = 0;

                byte[] _footer = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");

                foreach (MimePart part in mimeParts)
                {
                    contentLength += part.GenerateHeaderFooterData(boundary);
                }

                req.ContentLength = contentLength + _footer.Length;

                byte[] buffer = new byte[8192];
                byte[] afterFile = Encoding.UTF8.GetBytes("\r\n");
                int read;

                using (Stream s = req.GetRequestStream())
                {
                    foreach (MimePart part in mimeParts)
                    {
                        s.Write(part.Header, 0, part.Header.Length);

                        while ((read = part.Data.Read(buffer, 0, buffer.Length)) > 0)
                            s.Write(buffer, 0, read);

                        part.Data.Dispose();

                        s.Write(afterFile, 0, afterFile.Length);
                    }

                    s.Write(_footer, 0, _footer.Length);
                }

                return (HttpWebResponse)req.GetResponse();
            }
            catch
            {
                foreach (MimePart part in mimeParts)
                    if (part.Data != null)
                        part.Data.Dispose();

                throw;
            }
        }
    }
}