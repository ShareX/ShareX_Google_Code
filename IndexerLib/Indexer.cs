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

using HelpersLib;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IndexerLib
{
    public abstract class Indexer
    {
        protected StringBuilder sbIndex = new StringBuilder();
        protected IndexerSettings config = null;

        public static string Run(string folderPath, IndexerSettings config)
        {
            Indexer indexer = null;

            switch (config.Output)
            {
                case IndexerOutput.Html:
                    indexer = new IndexerHtml();
                    break;
                case IndexerOutput.Txt:
                    indexer = new IndexerText();
                    break;
            }

            return indexer.Index(folderPath, config);
        }

        public virtual string Index(string folderPath, IndexerSettings config)
        {
            this.config = config;

            FolderInfo folderInfo = GetFolderInfo(folderPath);

            IndexFolder(folderInfo);

            return sbIndex.ToString();
        }

        private FolderInfo GetFolderInfo(string folderPath)
        {
            FolderInfo folderInfo = new FolderInfo(folderPath);
            DirectoryInfo currentDirectoryInfo = new DirectoryInfo(folderPath);

            foreach (DirectoryInfo directoryInfo in currentDirectoryInfo.GetDirectories())
            {
                if (config.SkipHiddenFolders && directoryInfo.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    continue;
                }

                FolderInfo subFolderInfo = GetFolderInfo(directoryInfo.FullName);
                folderInfo.Folders.Add(subFolderInfo);
                subFolderInfo.Parent = folderInfo;
            }

            foreach (FileInfo fileInfo in currentDirectoryInfo.GetFiles())
            {
                if (config.SkipHiddenFiles && fileInfo.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    continue;
                }

                folderInfo.Files.Add(fileInfo);
            }

            folderInfo.Size = folderInfo.Folders.Sum(x => x.Size) + folderInfo.Files.Sum(x => x.Length);

            return folderInfo;
        }

        protected abstract void IndexFolder(FolderInfo dir, int level = 0);

        protected virtual string GetFolderNameRow(FolderInfo dir, int level = 0)
        {
            string text = string.Format("{0}{1}", config.IndentationText.Repeat(level), Path.GetFileName(dir.FolderPath));

            if (dir.Size > 0)
            {
                text += string.Format(" [{0}]", dir.Size.ToSizeString(config.BinaryUnits));
            }

            return text;
        }

        protected virtual string GetFileNameRow(FileInfo fi, int level = 0)
        {
            return string.Format("{0}{1} [{2}]", config.IndentationText.Repeat(level), Path.GetFileName(fi.FullName), fi.Length.ToSizeString(config.BinaryUnits));
        }

        protected virtual string GetFooter()
        {
            return string.Format("Generated on {0} using {1}. Latest version can be downloaded from ",
                DateTime.UtcNow.ToString("yyyy-MM-dd 'at' HH:mm:ss 'UTC'"),
                string.Format("{0} v{1}", Application.ProductName, Application.ProductVersion));
        }
    }
}