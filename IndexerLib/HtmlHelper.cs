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

using IndexerLib.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IndexerLib
{
    public static class HtmlHelper
    {
        public const string HeadClose = "</head>";
        public const string BodyOpen = "<body>";
        public const string BodyClose = "</body>\n</html>";
        public const string BulletedListOpen = "<ul>";
        public const string BulletedListClose = "</ul>";
        public const string NumberedListOpen = "<ol>";
        public const string NumberedListClose = "</ol>";

        public static string GetCssStyle(string filePath = "")
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<style type=\"text/css\">");
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    sb.AppendLine(sr.ReadToEnd());
                }
            }
            else
            {
                sb.AppendLine(Resources.DefaultCss);
            }

            sb.AppendLine("</style>");

            return sb.ToString();
        }

        public static string GetTitle(string title)
        {
            return string.Format("<title>{0}</title>", title);
        }

        public static string GetHeading(string text, int level)
        {
            return string.Format("<h{0}>{1}</h{0}>", level, GetValidXhtmlLine(text));
        }

        public static string GetListItem(string text)
        {
            return string.Format("<li>{0}</li>", GetValidXhtmlLine(text));
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
    }
}