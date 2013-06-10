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

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelpersLib
{
    public static class ClipboardHelper
    {
        private static readonly object ClipboardLock = new object();

        private static bool CopyData(object data)
        {
            if (data != null)
            {
                try
                {
                    lock (ClipboardLock)
                    {
                        Clipboard.SetDataObject(data, true, 10, 200);
                    }

                    return true;
                }
                catch { }
            }

            return false;
        }

        public static bool CopyText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                DataObject data = new DataObject();
                string dataFormat;

                if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 5)
                {
                    dataFormat = DataFormats.Text;
                }
                else
                {
                    dataFormat = DataFormats.UnicodeText;
                }

                data.SetData(dataFormat, false, text);
                return CopyData(data);
            }

            return false;
        }

        public static bool CopyImage(Image img)
        {
            if (img != null)
            {
                DataObject data = new DataObject();

                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Png);
                    data.SetData("PNG", false, ms);
                    data.SetData(DataFormats.Bitmap, true, img);
                    return CopyData(data);
                }
            }

            return false;
        }

        public static bool CopyFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                DataObject data = new DataObject();
                data.SetFileDropList(new StringCollection() { path });
                return CopyData(data);
            }

            return false;
        }

        public static bool CopyImageFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    using (Image img = Image.FromFile(path))
                    {
                        return CopyImage(img);
                    }
                }
                catch { }
            }

            return false;
        }

        public static bool CopyTextFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    string text = File.ReadAllText(path);
                    return CopyText(text);
                }
                catch { }
            }

            return false;
        }
    }
}