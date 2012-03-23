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

public class TreeFile
{
    private double mSize;
    private string mPath;

    public TreeFile(string filePath)
    {
        this.mPath = filePath;

        if (File.Exists(filePath))
        {
            FileInfo fi = new FileInfo(GetFilePath());
            SetSize(fi.Length);
        }
    }

    public string GetFileExtension()
    {
        return Path.GetExtension(mPath);
    }

    public string GetFilePath()
    {
        return this.mPath;
    }

    public string GetFileName()
    {
        return Path.GetFileName(GetFilePath());
    }

    public string GetFileNameWithoutExtension()
    {
        return Path.GetFileNameWithoutExtension(GetFilePath());
    }

    public void SetSize(double size)
    {
        this.mSize = size;
    }

    public double GetSize(TreeDir.BinaryPrefix prefix)
    {
        switch (prefix)
        {
            case TreeDir.BinaryPrefix.Bytes:
                return mSize;
            case TreeDir.BinaryPrefix.Kibibits:
                return (mSize / 128);
            case TreeDir.BinaryPrefix.Kibibytes:
                return (mSize / 1024);
            case TreeDir.BinaryPrefix.Mebibytes:
                return (mSize / (1024 * 1024));
            case TreeDir.BinaryPrefix.Gibibytes:
                return (mSize / (1024 * 1024 * 1024));
        }

        return mSize;
    }

    public string GetSizeToString(TreeDir.BinaryPrefix prefix)
    {
        string bp = "";
        switch (prefix)
        {
            case TreeDir.BinaryPrefix.Gibibytes:
                bp = " GiB";
                break;
            case TreeDir.BinaryPrefix.Mebibytes:
                bp = " MiB";
                break;
            case TreeDir.BinaryPrefix.Kibibytes:
                bp = " KiB";
                break;
        }
        return GetSize(prefix).ToString("N") + bp;
    }
}