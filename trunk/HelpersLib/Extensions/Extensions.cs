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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HelpersLib
{
    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
            }
            return value.ToString();
        }

        public static string GetCategory(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                CategoryAttribute[] attributes = (CategoryAttribute[])fi.GetCustomAttributes(typeof(CategoryAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Category : value.ToString();
            }
            return value.ToString();
        }

        public static string[] GetEnumDescriptions(this Type type)
        {
            return Enum.GetValues(type).OfType<Enum>().Select(x => x.GetDescription()).ToArray();
        }

        public static bool HasFlag(this Enum keys, Enum flag)
        {
            ulong keysVal = Convert.ToUInt64(keys);
            ulong flagVal = Convert.ToUInt64(flag);
            return (keysVal & flagVal) == flagVal;
        }

        public static bool HasFlagAny(this Enum keys, params Enum[] flags)
        {
            return flags.Any(x => keys.HasFlag(x));
        }

        public static bool HasFlagAll(this Enum keys, params Enum[] flags)
        {
            return flags.All(x => keys.HasFlag(x));
        }

        public static int Between(this int num, int min, int max)
        {
            if (num <= min) return min;
            if (num >= max) return max;
            return num;
        }

        public static int BetweenOrDefault(this int num, int min, int max, int defaultValue = 0)
        {
            if (num >= min && num <= max) return num;
            return defaultValue;
        }

        public static bool IsBetween(this int num, int min, int max)
        {
            return num >= min && num <= max;
        }

        public static float Between(this float num, float min, float max)
        {
            if (num <= min) return min;
            if (num >= max) return max;
            return num;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");

            foreach (T item in source)
            {
                action(item);
            }
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            using (IEnumerator<TFirst> e1 = first.GetEnumerator())
            using (IEnumerator<TSecond> e2 = second.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return resultSelector(e1.Current, e2.Current);
                }
            }
        }

        public static byte[] GetBytes(this Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        public static Stream GetStream(this Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);
            return ms;
        }

        public static ImageCodecInfo GetCodecInfo(this ImageFormat format)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(info => info.FormatID.Equals(format.Guid));
        }

        public static string GetMimeType(this ImageFormat format)
        {
            ImageCodecInfo codec = format.GetCodecInfo();

            if (codec != null) return codec.MimeType;

            return "image/unknown";
        }

        public static bool ReplaceFirst(this string text, string search, string replace, out string result)
        {
            int location = text.IndexOf(search);

            if (location < 0)
            {
                result = text;
                return false;
            }

            result = text.Remove(location, search.Length).Insert(location, replace);
            return true;
        }

        public static bool IsValidIndex<T>(this T[] array, int index)
        {
            return array != null && index >= 0 && index < array.Length;
        }

        public static bool IsValidIndex<T>(this List<T> list, int index)
        {
            return list != null && index >= 0 && index < list.Count;
        }

        public static T ReturnIfValidIndex<T>(this T[] array, int index)
        {
            if (array.IsValidIndex(index)) return array[index];
            return default(T);
        }

        public static T ReturnIfValidIndex<T>(this List<T> list, int index)
        {
            if (list.IsValidIndex(index)) return list[index];
            return default(T);
        }

        public static T Last<T>(this T[] array, int index = 0)
        {
            if (array.Length > index) return array[array.Length - index - 1];
            return default(T);
        }

        public static T Last<T>(this List<T> list, int index = 0)
        {
            if (list.Count > index) return list[list.Count - index - 1];
            return default(T);
        }

        public static double ToDouble(this Version value)
        {
            return Math.Max(value.Major, 0) * Math.Pow(10, 12) +
                   Math.Max(value.Minor, 0) * Math.Pow(10, 9) +
                   Math.Max(value.Build, 0) * Math.Pow(10, 6) +
                   Math.Max(value.Revision, 0);
        }

        public static bool IsValid(this Rectangle rect)
        {
            return rect.Width > 0 && rect.Height > 0;
        }

        public static Rectangle SizeOffset(this Rectangle rect, int offset)
        {
            return rect.SizeOffset(offset, offset);
        }

        public static Rectangle SizeOffset(this Rectangle rect, int width, int height)
        {
            return new Rectangle(rect.X, rect.Y, rect.Width + width, rect.Height + height);
        }

        public static string Join<T>(this T[] array, string separator = " ")
        {
            StringBuilder sb = new StringBuilder();

            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (sb.Length > 0 && !string.IsNullOrEmpty(separator)) sb.Append(separator);
                    sb.Append(array[i].ToString());
                }
            }

            return sb.ToString();
        }

        public static Icon ToIcon(this Bitmap bmp)
        {
            IntPtr hicon = bmp.GetHicon();
            Icon icon = Icon.FromHandle(hicon);
            return icon;
        }
    }
}