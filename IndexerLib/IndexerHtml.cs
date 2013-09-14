﻿#region License Information (GPL v3)

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
using IndexerLib.Properties;
using System.IO;
using System.Text;

namespace IndexerLib
{
    public class IndexerHtml : Indexer
    {
        public override string Index(string folderPath, IndexerSettings config)
        {
            string index = base.Index(folderPath, config);

            StringBuilder sbIndexHtml = new StringBuilder();

            sbIndexHtml.AppendLine(Resources.doctype_xhtml);
            sbIndexHtml.AppendLine(HtmlHelper.GetDomCollapse());
            sbIndexHtml.AppendLine(HtmlHelper.GetCssStyle(config.CssFilePath));
            sbIndexHtml.AppendLine(HtmlHelper.GetTitle("Index for " + Path.GetFileName(folderPath)));
            sbIndexHtml.AppendLine(HtmlHelper.HeadClose);
            sbIndexHtml.AppendLine(HtmlHelper.BodyOpen);
            sbIndexHtml.AppendLine(index);
            sbIndexHtml.AppendLine(HtmlHelper.BodyClose);

            return sbIndexHtml.ToString();
        }

        protected override void IndexFolder(FolderInfo dir, int level)
        {
            sbIndex.AppendLine(GetFolderNameRow(dir, level));

            if (dir.HasParent && dir.HasFolders)
            {
                sbIndex.AppendLine(HtmlHelper.GetStartTag("div"));
            }

            if (dir.Files.Count > 0)
            {
                sbIndex.AppendLine();

                string marginStyle = string.Format("margin-left:{0}px;", level * 30 - 10);
                sbIndex.AppendLine(HtmlHelper.GetStartTag("ul", marginStyle));

                foreach (FileInfo fi in dir.Files)
                {
                    sbIndex.AppendLine(GetFileNameRow(fi, level));
                }

                sbIndex.AppendLine(HtmlHelper.GetEndTag("ul"));
            }

            foreach (FolderInfo subdir in dir.Folders)
            {
                sbIndex.AppendLine();
                IndexFolder(subdir, level + 1);
            }

            if (dir.HasParent && dir.HasFolders)
            {
                sbIndex.AppendLine(HtmlHelper.GetEndTag("div"));
            }
        }

        protected override string GetFileNameRow(FileInfo fi, int level)
        {
            return HtmlHelper.GetListItem(base.GetFileNameRow(fi));
        }

        protected override string GetFolderNameRow(FolderInfo dir, int level)
        {
            int heading = (level + 1).Between(1, 6);
            string marginStyle = level > 0 ? string.Format("margin-left:{0}px;", level * 30) : string.Empty;
            string className = string.Empty;
            if (dir.Folders.Count > 0 || dir.Files.Count > 0)
            {
                className = "trigger";
            }
            return HtmlHelper.GetHeading(base.GetFolderNameRow(dir), heading, className, marginStyle);
        }
    }
}