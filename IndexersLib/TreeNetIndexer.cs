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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IndexersLib
{
    public class TreeNetIndexer : Indexer
    {
        private IndexerAdapter mSettings;
        private FilterHelper mFilter;
        private bool mBooFirstDir = true;

        // 2.7.1.1 TreeGUI failed to index when Decimal Symbol set to a charactor other than dot
        string mDecimalSymbol = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public TreeNetIndexer(IndexerAdapter settings)
            : base(settings)
        {
            mSettings = new IndexerAdapter();
            mSettings = settings;
            mFilter = new FilterHelper(mSettings);
        }

        private TreeDir Analyze(string rootDirPath)
        {
            TreeDir dirRoot = new TreeDir(rootDirPath);
            dirRoot = GetFiles(dirRoot.DirectoryPath());
            if (mSettings.GetConfig().SortBySize)
            {
                dirRoot.GetSubDirColl().Sort(new TreeDirComparer());
                if (mSettings.GetConfig().SortBySizeMode == FileSortMode.Descending)
                {
                    dirRoot.GetSubDirColl().Reverse();
                }
            }
            return dirRoot;
        }

        private TreeDir GetFiles(string dirPath)
        {
            TreeDir dir = new TreeDir(dirPath);

            try
            {
                foreach (string filepath in Directory.GetFiles(dirPath))
                {
                    dir.SetFile(filepath, TreeDir.BinaryPrefix.Kibibytes);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            try
            {
                foreach (string subDirPath in Directory.GetDirectories(dirPath))
                {
                    TreeDir subdir = new TreeDir(subDirPath);
                    subdir = GetFiles(subDirPath);
                    dir.AddDir(subdir);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return dir;
        }

        private string fGetDirPath(TreeDir dir)
        {
            string dirName = null;
            string[] c = dir.DirectoryPath().Split(Path.DirectorySeparatorChar);
            if (c[1].Length == 0)
            {
                // Root Drive
                dirName = dir.DirectoryPath();
            }
            else
            {
                if (mSettings.GetConfig().ShowFolderPath)
                {
                    dirName = dir.DirectoryPath();
                }
                else
                {
                    dirName = dir.DirectoryName();
                }
            }
            return dirName;
        }

        private string fGetDirSizeString(TreeDir dir)
        {
            string dirSize = null;

            if (mBooFirstDir)
            {
                dirSize = dir.DirectorySizeToString(TreeDir.BinaryPrefix.Gibibytes);
                if (decimal.Parse(Regex.Split(dirSize, "\\" + mDecimalSymbol)[0]) == 0)
                {
                    dirSize = dir.DirectorySizeToString(TreeDir.BinaryPrefix.Mebibytes);
                    if (decimal.Parse(Regex.Split(dirSize, " ")[0]) == 0)
                    {
                        dirSize = dir.DirectorySizeToString(TreeDir.BinaryPrefix.Kibibytes);
                    }
                }
            }
            else
            {
                dirSize = dir.DirectorySizeToString(TreeDir.BinaryPrefix.Mebibytes);
                if (decimal.Parse(Regex.Split(dirSize, "\\" + mDecimalSymbol)[0]) == 0)
                {
                    dirSize = dir.DirectorySizeToString(TreeDir.BinaryPrefix.Kibibytes);
                }
            }

            return dirSize;
        }

        private string fGetVirtualDirName(string filePath)
        {
            foreach (string line in mSettings.GetConfig().VirtualFolderList)
            {
                string[] spline = Regex.Split(line, "|");
                if (filePath.IndexOf(spline[0]) != -1)
                {
                    return filePath.Replace(spline[0], spline[1]);
                }
            }
            return filePath;
        }

        private bool fDivWrap(TreeDir dir)
        {
            return (rootDir != dir.DirectoryPath()) && (dir.GetSubDirColl().Count > 0 | mSettings.GetConfig().ShowFileCount);
        }

        //' DOMCOLLAPSE RULES
        //' If a folder has subfolders then wrap the folder with div
        //' If a folder has no files then don't have trigger
        // TODO: TreeGUI - war59312 - Hide folders from output in which all its files are ignored

        string rootDir = string.Empty;

        private TreeDir IndexToHtmlFile(TreeDir dir, StringBuilder where)
        {
            bool isNotIndexableDir = mFilter.isBannedFolder(dir);

            string dirName = fGetDirPath(dir);
            string dirSize = (string)fGetDirSizeString(dir);

            string dirTitle = null;

            if (mSettings.GetConfig().EnabledFiltering && mSettings.GetConfig().IgnoreEmptyFolders && dir.DirectorySize() == 0.0)
            {
                //war59312 - dont show empty folders
                dirTitle = "";
            }
            else
            {
                if (mSettings.GetConfig().ShowDirSize)
                {
                    dirTitle = Xhtml.GetValidXhtmlLine(string.Format("{0} [{1}]", dirName, dirSize));
                }
                else
                {
                    dirTitle = Xhtml.GetValidXhtmlLine(dirName);
                }
            }

            if (mBooFirstDir)
            {
                rootDir = dir.DirectoryPath();
                where.AppendLine("<h1>" + dirTitle + "</h1>");
                mBooFirstDir = false;
                mNumTabs = 1;
            }
            else
            {
                if (!isNotIndexableDir)
                {
                    if (mSettings.GetConfig().EnabledFiltering && mSettings.GetConfig().IgnoreEmptyFolders && dir.DirectorySize() == 0.0)
                    {
                        //war59312 - dont show empty folders
                    }
                    else
                    {
                        if (mSettings.GetConfig().ShowFolderPathOnStatusBar)
                        {
                            string hyperlinkDir = null;
                            if (mSettings.GetConfig().ShowVirtualFolders)
                            {
                                // Virtual Folders
                                hyperlinkDir = mSettings.GetConfig().ServerInfo + "/" + fGetVirtualDirName(dir.DirectoryPath()).Replace("\\", "/");
                            }
                            else
                            {
                                // Locally Browse
                                hyperlinkDir = "file://" + dir.DirectoryPath();
                            }
                            hyperlinkDir = "<a href=" + (char)34 + hyperlinkDir + (char)34 + ">" + dirTitle + "</a>";
                            where.AppendLine(GetHeadingOpen(dir) + hyperlinkDir + GetHeadingClose());
                        }
                        else
                        {
                            where.AppendLine(GetHeadingOpen(dir) + dirTitle + GetHeadingClose());
                        }
                    }
                }
            }

            if (!isNotIndexableDir)
            {
                if (mSettings.GetConfig().EnabledFiltering && mSettings.GetConfig().IgnoreEmptyFolders && dir.DirectorySize() == 0.0)
                {
                    //war59312 - dont show empty folders
                }
                else
                {
                    List<TreeFile> files = dir.GetFilesColl(mSettings);

                    if (fDivWrap(dir))
                    {
                        where.AppendLine(Xhtml.OpenDiv());
                    }

                    if (double.Parse(Regex.Split(dir.DirectorySizeToString(TreeDir.BinaryPrefix.Kibibytes), " ")[0]) > 0 | files.Count > 0)
                    {
                        if (mSettings.GetConfig().ShowFileCount)
                        {
                            if (files.Count > 0)
                            {
                                where.AppendLine(Xhtml.OpenPara("foldercount"));
                                where.AppendLine("Files Count: " + files.Count.ToString());
                                where.AppendLine(Xhtml.ClosePara());
                            }
                        }
                    }
                    else
                    {
                        //Note:
                        // dir.GetFilesColl().Count = 0 DOESNT ALWAYS MEAN THAT
                        // it is an empty directory because there can be subfolders
                        // with files
                        //System.Windows.Forms.MessageBox.Show(dir.GetFilesColl().Count)
                        where.AppendLine(Xhtml.OpenPara(""));
                        where.AppendLine(mSettings.GetOptions().EmptyFolderMessage + Xhtml.AddBreak());
                        where.AppendLine(Xhtml.ClosePara());
                    }

                    if (files.Count > 0)
                    {
                        // Check if there is AT LEAST ONE valid file
                        bool booPrintList = false;
                        foreach (TreeFile fp in files)
                        {
                            if (!mFilter.IsBannedFile(fp.GetFilePath()))
                            {
                                booPrintList = true;
                                break;
                            }
                        }

                        if (mSettings.GetConfig().ShowFilesTreeNet)
                        {
                            if (booPrintList)
                            {
                                switch (mSettings.GetConfig().IndexListType)
                                {
                                    case XHTMLFileListMode.Bullets:
                                        where.AppendLine(Xhtml.OpenBulletedList());
                                        break;
                                    case XHTMLFileListMode.Numbered:
                                        where.AppendLine(Xhtml.OpenNumberedList());
                                        break;
                                }
                            }

                            if (mSettings.GetConfig().RevereFileOrder)
                            {
                                files.Reverse();
                            }

                            foreach (TreeFile f in files)
                            {
                                string lLine = null;

                                if (!mFilter.IsBannedFile(f.GetFilePath()))
                                {
                                    string strFilePath = null;

                                    if (mSettings.GetConfig().ShowFilePath)
                                    {
                                        if (mSettings.GetConfig().ShowVirtualFolders)
                                        {
                                            strFilePath = fGetVirtualDirName(f.GetFilePath());
                                        }
                                        else
                                        {
                                            strFilePath = f.GetFilePath();
                                        }
                                    }
                                    else
                                    {
                                        if (mSettings.GetConfig().HideExtension)
                                        {
                                            strFilePath = f.GetFileNameWithoutExtension();
                                        }
                                        else
                                        {
                                            strFilePath = f.GetFileName();
                                        }
                                    }

                                    if (mSettings.GetConfig().ShowFileSize)
                                    {
                                        string fileSize = f.GetSizeToString(TreeDir.BinaryPrefix.Mebibytes);
                                        if (double.Parse(Regex.Split(fileSize, "\\" + mDecimalSymbol)[0]) == 0)
                                        {
                                            fileSize = f.GetSizeToString(TreeDir.BinaryPrefix.Kibibytes);
                                        }
                                        lLine = Xhtml.GetValidXhtmlLine(strFilePath) + " " + Xhtml.GetSpan(string.Format(" [{0}]", fileSize), "filesize");
                                    }
                                    else
                                    {
                                        lLine = Xhtml.GetValidXhtmlLine(strFilePath);
                                    }

                                    if (mSettings.GetConfig().AudioInfo && fIsAudio(f.GetFileExtension().ToLower()) == true)
                                    {
                                        try
                                        {
                                            TagLib.File audioFile = TagLib.File.Create(f.GetFilePath());
                                            double fsize = f.GetSize(TreeDir.BinaryPrefix.Kibibits);
                                            double dura = audioFile.Properties.Duration.TotalSeconds;

                                            if (dura > 0)
                                            {
                                                Debug.WriteLine(fsize / dura);
                                                lLine += Xhtml.GetSpan(string.Format(" [{0} kb/s]", (fsize / dura).ToString("0.00"), fGetHMS(audioFile.Properties.Duration.TotalSeconds)), "audioinfo");
                                                lLine += Xhtml.GetSpan(string.Format(" [{0}]", fGetHMS(audioFile.Properties.Duration.TotalSeconds)), "audiolength");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Debug.WriteLine(ex.ToString() + "\n" + f.GetFilePath());
                                        }
                                    }

                                    where.AppendLine("<li>" + lLine + "</li>");
                                }
                            }

                            if (booPrintList)
                            {
                                switch (mSettings.GetConfig().IndexListType)
                                {
                                    case XHTMLFileListMode.Bullets:
                                        where.AppendLine(Xhtml.CloseBulletedList());
                                        break;
                                    case XHTMLFileListMode.Numbered:
                                        where.AppendLine(Xhtml.CloseNumberedList());
                                        break;
                                }
                            }
                            // Show Files for TreeNet
                        }
                    }

                    mNumTabs += 1;

                    foreach (TreeDir d in dir.GetSubDirColl())
                    {
                        TreeDir sd = new TreeDir(d.DirectoryPath());
                        sd = IndexToHtmlFile(d, where);
                    }

                    if (fDivWrap(dir))
                    {
                        where.AppendLine(Xhtml.CloseDiv());
                    }

                    mNumTabs -= 1;
                }
            }

            return dir;
        }

        public bool fIsAudio(string ext)
        {
            string[] exts = { ".mp3", ".m4a", ".flac", ".wma" };

            foreach (string ex in exts)
            {
                if (ext.Equals(ex.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        public string fGetHMS(double sec)
        {
            double[] hms = fGetDurationInHoursMS(sec);

            return string.Format("{0}:{1}:{2}", hms[0].ToString("00"), hms[1].ToString("00"), hms[2].ToString("00"));
        }

        public string fGetHMS2(double sec)
        {
            double[] hms = fGetDurationInHoursMS(sec);

            return string.Format("{0} Hours {1} Minutes {2} Seconds", hms[0], hms[1], hms[2]);
        }

        public double[] fGetDurationInHoursMS(double seconds)
        {
            double[] arrayHoursMinutesSeconds = new double[4];
            double SecondsLeft = seconds;
            int hours = 0;
            int minutes = 0;

            while (SecondsLeft >= 3600)
            {
                SecondsLeft -= 3600;
                hours += 1;
            }

            arrayHoursMinutesSeconds[0] = hours;

            while (SecondsLeft >= 60)
            {
                SecondsLeft -= 60;
                minutes += 1;
            }

            arrayHoursMinutesSeconds[1] = minutes;
            arrayHoursMinutesSeconds[2] = SecondsLeft;

            return arrayHoursMinutesSeconds;
        }

        private bool mBooFirstIndexFile = true;
        private bool mBooMoreFilesToCome = false;

        private string IndexRootFolderToHtml(string folderPath, StringBuilder sb, bool bAddFooter)
        {
            if (mBooFirstIndexFile)
            {
                sb.AppendLine(Xhtml.GetDocType());
                if (mSettings.GetConfig().CollapseFolders)
                {
                    sb.AppendLine(Xhtml.GetCollapseJs());
                    sb.AppendLine(Xhtml.GetCollapseCss());
                }
                sb.AppendLine(Xhtml.GetCssStyle(mSettings.GetConfig().CssFilePath));

                if (mBooMoreFilesToCome)
                {
                    sb.AppendLine(Xhtml.GetTitle(mSettings.GetConfig().MergedHtmlTitle));
                    mBooMoreFilesToCome = false;
                }
                else
                {
                    string[] c = folderPath.Split(Path.DirectorySeparatorChar);
                    if (c[1].Length == 0)
                    {
                        sb.AppendLine(Xhtml.GetTitle("Index for " + folderPath));
                    }
                    else
                    {
                        sb.AppendLine(Xhtml.GetTitle("Index for " + Path.GetFileName(folderPath)));
                    }
                }

                sb.AppendLine(Xhtml.CloseHead());
                sb.AppendLine(Xhtml.OpenBody());

                mBooFirstIndexFile = false;
            }

            TreeDir rootDir = new TreeDir(folderPath);

            rootDir = Analyze(rootDir.DirectoryPath());

            this.IndexToHtmlFile(rootDir, sb);

            if (bAddFooter)
            {
                sb.AppendLine(Xhtml.OpenDiv());
                sb.AppendLine("<hr />");
                sb.AppendLine(mSettings.GetFooterText(null, IndexingEngine.TreeNetLib, true));
                sb.AppendLine(Xhtml.CloseDiv());
                sb.AppendLine(Xhtml.CloseBody());
            }

            mBooFirstDir = true;

            return sb.ToString();
        }

        private string IndexFolderToTxt(string folderPath, StringBuilder sb, bool AddFooter)
        {
            if (Directory.Exists(folderPath))
            {
                // 2.7.1.6 TreeGUI crashed on Could not find a part of the path

                TreeDir dir = new TreeDir(folderPath);
                dir = Analyze(dir.DirectoryPath());
                this.IndexToTxtFile(dir, sb);
                if (AddFooter)
                {
                    sb.AppendLine("____");
                    sb.AppendLine(mSettings.GetFooterText(null, IndexingEngine.TreeNetLib, false));
                }
            }

            return sb.ToString();
        }

        private TreeDir IndexToTxtFile(TreeDir dir, StringBuilder sb)
        {
            bool isNotIndexableDir = mFilter.isBannedFolder(dir);

            string dirSize = fGetDirSizeString(dir);
            string dirTitle = string.Format("{0} [{1}]", dir.DirectoryName(), dirSize);

            string strStars = "";
            char[] styleArray = mSettings.GetConfig().FolderHeadingStyle.ToCharArray();

            for (int i = 0; i <= dirTitle.Length - 1; i++)
            {
                strStars += styleArray[i % styleArray.Length];
            }

            sb.AppendLine(GetTabs() + strStars);
            sb.AppendLine(GetTabs() + dirTitle);
            sb.AppendLine(GetTabs() + strStars);

            if (double.Parse(Regex.Split(dir.DirectorySizeToString(TreeDir.BinaryPrefix.Kibibytes), " ")[0]) == 0)
            {
                sb.AppendLine(GetTabs() + mSettings.GetOptions().EmptyFolderMessage);
            }

            if (mSettings.GetConfig().ShowFilesTreeNet)
            {
                List<TreeFile> files = dir.GetFilesColl(mSettings);
                if (files.Count > 0)
                {
                    sb.AppendLine();
                }
                foreach (TreeFile fi in files)
                {
                    string fileDesc = GetTabs() + "  ";

                    if (mSettings.GetConfig().ShowFileSize)
                    {
                        string fileSize = fi.GetSizeToString(TreeDir.BinaryPrefix.Mebibytes);
                        if (double.Parse(Regex.Split(fileSize, "\\" + mDecimalSymbol)[0]) == 0)
                        {
                            fileSize = fi.GetSizeToString(TreeDir.BinaryPrefix.Kibibytes);
                        }
                        fileDesc += string.Format("{0} [{1}]", fi.GetFileName(), fileSize);
                    }
                    else
                    {
                        fileDesc += fi.GetFileName();
                    }

                    if (mSettings.GetConfig().AudioInfo && fIsAudio(fi.GetFileExtension().ToLower()) == true)
                    {
                        try
                        {
                            TagLib.File audioFile = TagLib.File.Create(fi.GetFilePath());
                            double fsize = fi.GetSize(TreeDir.BinaryPrefix.Kibibits);
                            double dura = audioFile.Properties.Duration.TotalSeconds;

                            if (dura > 0)
                            {
                                Debug.WriteLine(fsize / dura);
                                fileDesc += string.Format(" [{0} Kibit/s]", (fsize / dura).ToString("0.00"), fGetHMS(audioFile.Properties.Duration.TotalSeconds));
                                fileDesc += string.Format(" [{0}]", fGetHMS(audioFile.Properties.Duration.TotalSeconds));
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.ToString() + "\n" + fi.GetFilePath());
                        }
                    }
                    sb.AppendLine(fileDesc);
                }
                sb.AppendLine();
            }

            mNumTabs += 1;

            foreach (TreeDir d in dir.GetSubDirColl())
            {
                TreeDir sd = new TreeDir(d.DirectoryPath());
                sd = IndexToTxtFile(d, sb);
            }
            mNumTabs -= 1;

            return dir;
        }

        int mNumTabs = 0;

        public override string IndexNow(IndexingMode IndexMode, bool bWriteToFile = true)
        {
            string fp = null;
            StringBuilder sb = new StringBuilder();
            List<string> folderList = new List<string>();
            folderList = mSettings.GetConfig().FolderList;
            TreeNetIndexer treeNetLib = new TreeNetIndexer(mSettings);

            string ext = mSettings.GetConfig().IndexFileExt;

            switch (IndexMode)
            {
                case IndexingMode.IN_EACH_DIRECTORY:
                    IndexInEachDir(mSettings);
                    break;
                case IndexingMode.IN_ONE_FOLDER_MERGED:
                    if (mSettings.GetConfig().MergeFiles)
                    {
                        fp = mSettings.fGetIndexFilePath(-1, IndexingMode.IN_ONE_FOLDER_MERGED);

                        if (mSettings.GetConfig().FolderList.Count > 1)
                        {
                            for (int i = 0; i <= mSettings.GetConfig().FolderList.Count - 2; i++)
                            {
                                string strDirPath = mSettings.GetConfig().FolderList[i];
                                TreeDir dir = new TreeDir(strDirPath);

                                this.CurrentDirMessage = "Indexing " + strDirPath;

                                if (ext.Contains(".html"))
                                {
                                    treeNetLib.mBooMoreFilesToCome = true;
                                    treeNetLib.IndexRootFolderToHtml(strDirPath, sb, false);
                                }
                                else
                                {
                                    treeNetLib.IndexFolderToTxt(strDirPath, sb, false);
                                }

                                this.Progress += 1;
                            }
                        }

                        TreeDir lastDir = new TreeDir(mSettings.GetConfig().FolderList[mSettings.GetConfig().FolderList.Count - 1]);
                        this.CurrentDirMessage = "Indexing " + lastDir.DirectoryPath();

                        if (ext.Contains(".html"))
                        {
                            treeNetLib.mBooFirstIndexFile = false || mSettings.GetConfig().FolderList.Count == 1;
                            treeNetLib.IndexRootFolderToHtml(lastDir.DirectoryPath(), sb, true);
                        }
                        else
                        {
                            treeNetLib.IndexFolderToTxt(lastDir.DirectoryPath(), sb, true);
                        }

                        if (mSettings.GetConfig().ZipMergedFile)
                        {
                            mSettings.ZipAdminFile(fp, null);
                        }

                        this.Progress += 1;
                    }
                    break;
                case IndexingMode.IN_ONE_FOLDER_SEPERATE:
                    // DO NOT MERGE INDEX FILES
                    if (!Directory.Exists(mSettings.GetConfig().OutputDir))
                    {
                        MessageBox.Show(string.Format("{0} does not exist." + Environment.NewLine + Environment.NewLine + "Please change the Output folder in Configuration." + Environment.NewLine + "The index file will be created in the same folder you chose to index.", mSettings.GetConfig().OutputDir), Application.ProductName, MessageBoxButtons.OK);
                    }

                    for (int i = 0; i <= mSettings.GetConfig().FolderList.Count - 1; i++)
                    {
                        string strDirPath = mSettings.GetConfig().FolderList[i];

                        string sDrive = Path.GetPathRoot(strDirPath).Substring(0, 1);
                        string sDirName = Path.GetFileName(strDirPath);
                        string sep = mSettings.GetOptions().IndividualIndexFileWordSeperator;

                        //where = mSettings.GetConfig().OutputDir + "\" + sDrive + sep + sDirName + sep + mSettings.GetConfig().GetIndexFileName
                        // New Behavior for getting where location
                        fp = mSettings.fGetIndexFilePath(i, IndexingMode.IN_ONE_FOLDER_SEPERATE);
                        mSettings.GetConfig().SetIndexPath(fp);
                        //MsgBox(where = mSettings.GetConfig().OutputDir + "\" + sDrive + sep + sDirName + sep + mSettings.GetConfig().GetIndexFileName)

                        this.CurrentDirMessage = "Indexing " + strDirPath;

                        if (ext.Contains(".html"))
                        {
                            treeNetLib.mBooFirstIndexFile = true;
                            treeNetLib.IndexRootFolderToHtml(strDirPath, sb, true);
                        }
                        else
                        {
                            treeNetLib.IndexFolderToTxt(strDirPath, sb, true);
                        }

                        if (mSettings.GetConfig().ZipFilesInOutputDir)
                        {
                            mSettings.ZipAdminFile(fp, null);
                        }

                        this.Progress += 1;
                    }
                    break;
            }

            if (bWriteToFile)
            {
                using (StreamWriter sw = new StreamWriter(fp, false))
                {
                    sw.Write(sb.ToString());
                    sw.Close();
                }
            }
            return sb.ToString();
        }

        private void IndexInEachDir(IndexerAdapter myReader)
        {
            string where = null;
            List<string> folderList = new List<string>();
            folderList = myReader.GetConfig().FolderList;
            TreeNetIndexer treeNetLib = new TreeNetIndexer(myReader);

            string ext = myReader.GetConfig().IndexFileExt;

            for (int i = 0; i <= myReader.GetConfig().FolderList.Count - 1; i++)
            {
                string strDirPath = myReader.GetConfig().FolderList[i];
                // 2.5.1.1 Indexer halted if a configuration file had non-existent folders paths
                if (Directory.Exists(strDirPath))
                {
                    where = myReader.fGetIndexFilePath(i, IndexingMode.IN_EACH_DIRECTORY);
                    if (Directory.Exists(Path.GetDirectoryName(where)) == false)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(where));
                    }

                    StreamWriter sw = new StreamWriter(where, false);
                    StringBuilder sb = new StringBuilder();
                    try
                    {
                        this.CurrentDirMessage = "Indexing " + strDirPath;

                        if (ext.Contains("html"))
                        {
                            //MessageBox.Show(myReader.GetConfig().mCssFilePath)
                            treeNetLib.mBooFirstIndexFile = true;
                            treeNetLib.IndexRootFolderToHtml(strDirPath, sb, mSettings.GetConfig().AddFooter);
                        }
                        else
                        {
                            treeNetLib.IndexFolderToTxt(strDirPath, sb, mSettings.GetConfig().AddFooter);
                        }

                        this.Progress += 1;
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show(ex.Message + "\n" + "Please Run TreeGUI As Administrator or Change Output Directory.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
                        return;
                    }
                    finally
                    {
                        sw.Write(sb.ToString());
                        sw.Close();
                    }

                    // Zip after sw is closed
                    if (myReader.GetConfig().ZipFilesInEachDir)
                    {
                        myReader.ZipAdminFile(where, null);
                    }
                }
            }
        }

        private string GetTabs()
        {
            string tabs = "";
            for (int i = 1; i <= mNumTabs; i++)
            {
                tabs += "\t";
            }
            return tabs;
        }

        private string GetHeadingOpen(TreeDir dir)
        {
            string cName = "trigger";
            List<TreeFile> files = dir.GetFilesColl(mSettings);

            /*
            if (mNumTabs > mSettings.GetConfig().FolderExpandLevel)
            {
                cName = "expanded";
            }
            else
            {
                cName = "trigger";
            }
            */

            string tabs = string.Empty;

            if (mNumTabs < 7)
            {
                if (dir.GetSubDirColl().Count > 0 || files.Count > 0)
                {
                    tabs = string.Format("<h{0} class=\"{1}\">", mNumTabs.ToString(), cName);
                }
                else
                {
                    tabs = string.Format("<h{0}>", mNumTabs.ToString());
                }
            }
            else
            {
                if (dir.GetSubDirColl().Count > 0 || files.Count > 0)
                {
                    tabs = string.Format("<h6 class=\"{0}\">", cName);
                }
                else
                {
                    tabs = "<h6>";
                }
            }

            return tabs;
        }

        private string GetHeadingClose()
        {
            if (mNumTabs < 7)
            {
                return "</h" + mNumTabs.ToString() + ">";
            }
            else
            {
                return "</h6>";
            }
        }
    }
}