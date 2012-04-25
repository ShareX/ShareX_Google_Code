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
using System.Text;

namespace IndexersLib
{
    public static class Xhtml
    {
        public enum ListType
        {
            Numbered,
            Bulletted
        }

        public static string GetDocType()
        {
            return IndexerAdapter.GetText("html.txt");
        }

        public static string GetValidXhtmlLine(string line)
        {
            if (line != null)
            {
                line = line.Replace("&", "&amp;");
                line = line.Replace("™", "&trade;");
                line = line.Replace("©", "&copy;");
                line = line.Replace("®", "&reg;");
            }

            return line;
        }

        public static string GetJavaScript(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine("// <![CDATA[");

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    sb.AppendLine(sr.ReadToEnd());
                }
            }
            else
            {
                sb.AppendLine(IndexerAdapter.GetText("domCollapse.js"));
            }

            sb.AppendLine("// ]]>");
            sb.AppendLine("</script>");

            return sb.ToString();
        }

        public static string GetCollapseJs()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine("// <![CDATA[");
            sb.AppendLine(IndexerAdapter.GetText("domCollapse.js"));
            sb.AppendLine("// ]]>");
            sb.AppendLine("</script>");

            return sb.ToString();
        }

        public static string GetCollapseCss()
        {
            StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine(IndexerAdapter.GetText("domCollapse.css"));
            sb.AppendLine("</style>");

            return sb.ToString();
        }

        public static string GetCssStyle(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<style type=\"text/css\">");
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    sb.AppendLine(sr.ReadToEnd());
                }
            }
            else
            {
                sb.AppendLine(IndexerAdapter.GetText("Default.css"));
            }

            sb.AppendLine("</style>");

            return sb.ToString();
        }

        public static string MakeAnchor(string url, string text)
        {
            return string.Format("<a href=\"{0}\">{1}</a>", url, text);
        }

        public static string OpenDiv()
        {
            return "<div>";
        }

        public static string CloseDiv()
        {
            return "</div>";
        }

        public static string OpenBulletedList()
        {
            return "<ul>";
        }

        public static string CloseBulletedList()
        {
            return "</ul>";
        }

        public static string OpenNumberedList()
        {
            return "<ol>";
        }

        public static string CloseNumberedList()
        {
            return "</ol>";
        }

        public static string GetTitle(string title)
        {
            return "<title>" + title + "</title>";
        }

        public static string GetSpan(string lText, string lClass)
        {
            return "<span class=\"" + lClass + "\">" + lText + "</span>";
        }

        public static string CloseHead()
        {
            return "</head>";
        }

        public static string OpenBody()
        {
            return "<body>";
        }

        public static string CloseBody()
        {
            return "</body></html>";
        }

        public static string AddBreak()
        {
            return "<br />";
        }

        public static string GetPara(string msg)
        {
            return OpenPara(string.Empty) + GetValidXhtmlLine(msg) + ClosePara();
        }

        public static string GetBreak()
        {
            return OpenPara(string.Empty) + AddBreak() + ClosePara();
        }

        public static string OpenPara(string span)
        {
            if (span.Length > 0)
            {
                return string.Format("<p class=\"{0}\">", span);
            }
            else
            {
                return "<p>";
            }
        }

        public static string ClosePara()
        {
            return "</p>";
        }

        public static string GetWarning(string msg)
        {
            return "<p class=\"warning\">" + GetValidXhtmlLine(msg) + ClosePara();
        }

        public static string GetList(string msg)
        {
            return "<li>" + GetValidXhtmlLine(msg) + "</li>";
        }

        public static string GetHeading(string msg, int order)
        {
            return string.Format("<h{0}>{1}</h{0}>", order, GetValidXhtmlLine(msg));
        }

        public static string OpenList(ListType type)
        {
            switch (type)
            {
                case ListType.Bulletted:
                    return OpenBulletedList();
                case ListType.Numbered:
                    return OpenNumberedList();
                default:
                    return OpenNumberedList();
            }
        }

        public static string CloseList(ListType type)
        {
            switch (type)
            {
                case ListType.Bulletted:
                    return CloseBulletedList();
                case ListType.Numbered:
                    return CloseNumberedList();
                default:
                    return CloseNumberedList();
            }
        }
    }
}