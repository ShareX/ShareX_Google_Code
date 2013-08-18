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
                lock (ClipboardLock)
                {
                    Clipboard.SetDataObject(data, true, 10, 200);
                }

                return true;
            }

            return false;
        }

        public static bool CopyText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                try
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
                catch (Exception e)
                {
                    DebugHelper.WriteException(e, "Clipboard copy text");
                }
            }

            return false;
        }

        public static bool CopyImage(Image img)
        {
            if (img != null)
            {
                try
                {
                    DataObject data = new DataObject();

                    using (MemoryStream msPNG = new MemoryStream())
                    using (MemoryStream msBMP = new MemoryStream())
                    using (MemoryStream msDIB = new MemoryStream())
                    {
                        img.Save(msPNG, ImageFormat.Png);
                        data.SetData("PNG", false, msPNG);
                        img.Save(msBMP, ImageFormat.Bmp);
                        msBMP.CopyStreamTo(msDIB, 14, (int)msBMP.Length - 14);
                        data.SetData(DataFormats.Dib, true, msDIB);
                        return CopyData(data);
                    }
                }
                catch (Exception e)
                {
                    DebugHelper.WriteException(e, "Clipboard copy image");
                }
            }

            return false;
        }

        public static bool CopyFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    DataObject data = new DataObject();
                    data.SetFileDropList(new StringCollection() { path });
                    return CopyData(data);
                }
                catch (Exception e)
                {
                    DebugHelper.WriteException(e, "Clipboard copy file");
                }
            }

            return false;
        }

        public static bool CopyImageFromFile(string path)
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
                catch (Exception e)
                {
                    DebugHelper.WriteException(e, "Clipboard copy image file");
                }
            }

            return false;
        }

        public static bool CopyTextFromFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    string text = File.ReadAllText(path);
                    return CopyText(text);
                }
                catch (Exception e)
                {
                    DebugHelper.WriteException(e, "Clipboard copy text file");
                }
            }

            return false;
        }
    }
}