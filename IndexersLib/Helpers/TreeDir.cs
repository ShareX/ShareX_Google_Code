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
using System.Runtime.InteropServices;
using ZSS.IndexersLib;

public class TreeDir
{
    private List<TreeDir> mSubDirCol = new List<TreeDir>();
    private double mSizeOfFiles = 0.0;
    private string mDirPath;
    private List<TreeFile> mFiles = new List<TreeFile>();

    public TreeDir(string dirPath)
    {
        mDirPath = dirPath;
    }

    public string DirectoryPath()
    {
        return mDirPath;
    }

    public string DirectoryName()
    {
        return Path.GetFileName(DirectoryPath());
    }

    public string SetFile(string filePath, [OptionalAttribute, DefaultParameterValueAttribute(BinaryPrefix.Kibibytes)] BinaryPrefix prefix)
    {
        TreeFile f = new TreeFile(filePath);
        mFiles.Add(f);

        mSizeOfFiles += f.GetSize(BinaryPrefix.Kibibytes);

        switch (prefix)
        {
            case BinaryPrefix.Mebibytes:
                return f.GetSize(BinaryPrefix.Mebibytes).ToString("N") + " MiB";
            case BinaryPrefix.Gibibytes:
                return f.GetSize(BinaryPrefix.Gibibytes).ToString("N") + " GiB";
            default:
                return f.GetSize(BinaryPrefix.Kibibytes).ToString("N") + " KiB";
        }
    }

    public List<TreeFile> GetFilesColl(IndexerAdapter settings)
    {
        List<TreeFile> files = new List<TreeFile>();
        files.AddRange(GetFilesColl());
        FilterHelper filter = new FilterHelper(settings);
        foreach (TreeFile f in GetFilesColl())
        {
            if (filter.IsBannedFile(f.GetFilePath()))
            {
                files.Remove(f);
            }
        }
        return files;
    }

    private List<TreeFile> GetFilesColl()
    {
        return mFiles;
    }

    public void AddDir(TreeDir mySubDir)
    {
        mSubDirCol.Add(mySubDir);
    }

    public List<TreeDir> GetSubDirColl()
    {
        return mSubDirCol;
    }

    public double DirectorySize()
    {
        double dirSize = this.mSizeOfFiles;

        foreach (TreeDir dir in this.GetSubDirColl())
        {
            dirSize += dir.DirectorySize();
        }

        return dirSize;
    }

    public string DirectorySizeToString(BinaryPrefix prefix)
    {
        switch (prefix)
        {
            case BinaryPrefix.Gibibytes:
                return (this.DirectorySize() / (1024 * 1024)).ToString("N") + " GiB";
            case BinaryPrefix.Mebibytes:
                return (this.DirectorySize() / 1024).ToString("N") + " MiB";
            case BinaryPrefix.Kibibytes:
                return (this.DirectorySize()).ToString("N") + " KiB";
        }

        return null;
    }

    public enum BinaryPrefix
    {
        Bytes,
        Kibibits,
        Kibibytes,
        Mebibytes,
        Gibibytes
    }

    private double GetSizeOfFiles()
    {
        return mSizeOfFiles;
    }
}