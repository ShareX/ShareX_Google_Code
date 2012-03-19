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

// http://aspnetupload.com
// Copyright � 2009 Krystalware, Inc.
//
// This work is licensed under a Creative Commons Attribution-Share Alike 3.0 United States License
// http://creativecommons.org/licenses/by-sa/3.0/us/

using System.IO;

namespace Krystalware.UploadHelper
{
    public class UploadFile
    {
        Stream _data;
        string _fieldName;
        string _fileName;
        string _contentType;

        public UploadFile(Stream data, string fieldName, string fileName, string contentType)
        {
            _data = data;
            _fieldName = fieldName;
            _fileName = fileName;
            _contentType = contentType;
        }

        public UploadFile(string fileName, string fieldName, string contentType)
            : this(File.OpenRead(fileName), fieldName, Path.GetFileName(fileName), contentType)
        { }

        public UploadFile(string fileName)
            : this(fileName, null, "application/octet-stream")
        { }

        public Stream Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }
    }
}