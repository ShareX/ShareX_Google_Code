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
using System.IO;
using System.Text;

namespace IndexerLib
{
    public abstract class Indexer
    {
        protected StringBuilder sbIndex = new StringBuilder();

        public static string Run(IndexerSettings config)
        {
            Indexer indexer = null;

            switch (config.Output)
            {
                case IndexerOutput.Html:
                    indexer = new IndexerHtml();
                    break;
                case IndexerOutput.Text:
                    indexer = new IndexerText();
                    break;
            }

            return indexer.Index(config);
        }

        public virtual string Index(IndexerSettings config)
        {
            FolderInfo dir = new FolderInfo(config.FolderPath);
            dir.Read();

            IndexFolder(dir, 0);

            return sbIndex.ToString();
        }

        protected abstract void IndexFolder(FolderInfo dir, int level);

        private string GetPadding(int level)
        {
            StringBuilder padding = new StringBuilder();
            while (level > 0)
            {
                level--;
                padding.Append(" ");
            }
            return padding.ToString();
        }

        protected virtual string GetFolderNameRow(FolderInfo dir, int level = 0)
        {
            if (dir.Size > 0)
            {
                return string.Format("{0}{1} [{2}]", GetPadding(level), Path.GetFileName(dir.FolderPath), Helpers.ProperFileSize(dir.Size, "", true));
            }
            else
            {
                return string.Format("{0}{1}", GetPadding(level), Path.GetFileName(dir.FolderPath));
            }
        }

        protected virtual string GetFileNameRow(FileInfo fi, int level = 0)
        {
            return string.Format("{0}{1} [{2}]", GetPadding(level), Path.GetFileName(fi.FullName), Helpers.ProperFileSize(fi.Length, "", true));
        }
    }
}