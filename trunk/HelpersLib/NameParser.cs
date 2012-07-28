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
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace HelpersLib
{
    public enum ReplacementVariables
    {
        [Description("Title of active window")]
        t,
        [Description("Current year")]
        y,
        [Description("Current month")]
        mo,
        [Description("Current month name (Local language)")]
        mon,
        [Description("Current month name (English)")]
        mon2,
        [Description("Current day")]
        d,
        [Description("Current hour")]
        h,
        [Description("Current minute")]
        mi,
        [Description("Current second")]
        s,
        [Description("Current milisecond")]
        ms,
        [Description("Gets AM/PM")]
        pm,
        [Description("Current week name (Local language)")]
        w,
        [Description("Current week name (English)")]
        w2,
        [Description("Auto increment number")]
        i,
        [Description("Random number 0 to 9")]
        rn,
        [Description("Random alphanumeric char")]
        ra,
        [Description("Gets image width")]
        width,
        [Description("Gets image height")]
        height,
        [Description("User name")]
        un,
        [Description("User login name")]
        uln,
        [Description("Computer name")]
        cn,
        [Description("New line")]
        n
    }

    public static class ReplacementExtension
    {
        public const char Prefix = '%';

        public static string ToPrefixString(this ReplacementVariables replacement)
        {
            return Prefix + replacement.ToString();
        }
    }

    public enum NameParserType
    {
        Text,
        FileName,
        FolderPath,
        FilePath,
        URL
    }

    public class NameParser
    {
        public NameParserType Type { get; private set; }
        public int AutoIncrementNumber { get; set; }
        public string Host { get; set; }
        public Image Picture { get; set; }
        public DateTime CustomDate { get; set; }
        public int MaxNameLength { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string WindowText { get; set; }
        public bool AllowNewLine { get; set; }

        public NameParser(NameParserType nameParserType)
        {
            Type = nameParserType;
        }

        public string Convert(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder(pattern);

            if (!string.IsNullOrEmpty(WindowText))
            {
                sb.Replace(ReplacementVariables.t.ToPrefixString(), WindowText.Replace(' ', '_'));
            }

            string width = string.Empty, height = string.Empty;

            if (Picture != null)
            {
                width = Picture.Width.ToString();
                height = Picture.Height.ToString();
            }

            sb.Replace(ReplacementVariables.width.ToPrefixString(), width);
            sb.Replace(ReplacementVariables.height.ToPrefixString(), height);

            sb.Replace("%host", Host);

            DateTime dt;

            if (CustomDate != DateTime.MinValue)
            {
                dt = CustomDate;
            }
            else
            {
                dt = FastDateTime.Now;
            }

            sb.Replace(ReplacementVariables.mon2.ToPrefixString(), CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(dt.Month))
                .Replace(ReplacementVariables.mon.ToPrefixString(), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt.Month))
                .Replace(ReplacementVariables.y.ToPrefixString(), dt.Year.ToString())
                .Replace(ReplacementVariables.mo.ToPrefixString(), Helpers.AddZeroes(dt.Month))
                .Replace(ReplacementVariables.d.ToPrefixString(), Helpers.AddZeroes(dt.Day));

            string hour;

            if (sb.ToString().Contains(ReplacementVariables.pm.ToPrefixString()))
            {
                hour = Helpers.HourTo12(dt.Hour);
            }
            else
            {
                hour = Helpers.AddZeroes(dt.Hour);
            }

            sb.Replace(ReplacementVariables.h.ToPrefixString(), hour)
                 .Replace(ReplacementVariables.mi.ToPrefixString(), Helpers.AddZeroes(dt.Minute))
                 .Replace(ReplacementVariables.s.ToPrefixString(), Helpers.AddZeroes(dt.Second))
                 .Replace(ReplacementVariables.ms.ToPrefixString(), Helpers.AddZeroes(dt.Millisecond, 3))
                 .Replace(ReplacementVariables.w2.ToPrefixString(), CultureInfo.InvariantCulture.DateTimeFormat.GetDayName(dt.DayOfWeek))
                 .Replace(ReplacementVariables.w.ToPrefixString(), CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dt.DayOfWeek))
                 .Replace(ReplacementVariables.pm.ToPrefixString(), (dt.Hour >= 12 ? "PM" : "AM"));

            if (sb.ToString().Contains("%i"))
            {
                AutoIncrementNumber++;
                sb.Replace(ReplacementVariables.i.ToPrefixString(), AutoIncrementNumber.ToString());
            }

            sb.Replace(ReplacementVariables.un.ToPrefixString(), Environment.UserName);
            sb.Replace(ReplacementVariables.uln.ToPrefixString(), Environment.UserDomainName);
            sb.Replace(ReplacementVariables.cn.ToPrefixString(), Environment.MachineName);

            if (Type == NameParserType.Text && AllowNewLine)
            {
                sb.Replace(ReplacementVariables.n.ToPrefixString(), "\n");
            }

            string result = sb.ToString();

            string rn = ReplacementVariables.rn.ToPrefixString();
            while (result.ReplaceFirst(rn, Helpers.GetRandomChar(Helpers.Numbers).ToString(), out result)) ;

            string ra = ReplacementVariables.ra.ToPrefixString();
            while (result.ReplaceFirst(ra, Helpers.GetRandomChar(Helpers.Alphanumeric).ToString(), out result)) ;

            if (Type == NameParserType.FolderPath)
            {
                result = Helpers.GetValidFolderPath(result);
            }
            else if (Type == NameParserType.FileName)
            {
                result = Helpers.GetValidFileName(result);
            }
            else if (Type == NameParserType.FilePath)
            {
                result = Helpers.GetValidFilePath(result);
            }
            else if (Type == NameParserType.URL)
            {
                result = Helpers.GetValidURL(result);
            }

            if (MaxNameLength > 0 && result.Length > MaxNameLength)
            {
                result = result.Substring(0, MaxNameLength);
            }

            return result;
        }
    }
}