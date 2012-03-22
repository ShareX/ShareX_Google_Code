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

using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace Krystalware.UploadHelper
{
    public abstract class MimePart
    {
        NameValueCollection _headers = new NameValueCollection();
        byte[] _header;

        public NameValueCollection Headers
        {
            get { return _headers; }
        }

        public byte[] Header
        {
            get { return _header; }
        }

        public long GenerateHeaderFooterData(string boundary)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("--");
            sb.Append(boundary);
            sb.AppendLine();
            foreach (string key in _headers.AllKeys)
            {
                sb.Append(key);
                sb.Append(": ");
                sb.AppendLine(_headers[key]);
            }
            sb.AppendLine();

            _header = Encoding.UTF8.GetBytes(sb.ToString());

            return _header.Length + Data.Length + 2;
        }

        public abstract Stream Data { get; }
    }
}