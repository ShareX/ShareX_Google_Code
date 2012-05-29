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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HelpersLib
{
    public static class Helpers
    {
        public static readonly Random Random = new Random();

        private static readonly object ClipboardLock = new object();

        private static bool IsValidFile(string path, Type enumType)
        {
            string ext = Path.GetExtension(path);

            if (!string.IsNullOrEmpty(ext) && ext.Length > 1)
            {
                ext = ext.Remove(0, 1);
                return Enum.GetNames(enumType).Any(x => ext.Equals(x, StringComparison.InvariantCultureIgnoreCase));
            }

            return false;
        }

        public static bool IsImageFile(string path)
        {
            return IsValidFile(path, typeof(ImageFileExtensions));
        }

        public static bool IsTextFile(string path)
        {
            return IsValidFile(path, typeof(TextFileExtensions));
        }

        public static bool CopyTextSafely(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                try
                {
                    lock (ClipboardLock)
                    {
                        Clipboard.Clear();
                        Clipboard.SetText(text);
                    }
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public static void CopyFileToClipboard(string path)
        {
            try
            {
                Clipboard.SetFileDropList(new StringCollection() { path });
            }
            catch { }
        }

        public static void CopyImageFileToClipboard(string path)
        {
            try
            {
                using (Image img = Image.FromFile(path))
                {
                    Clipboard.SetImage(img);
                }
            }
            catch { }
        }

        public static void CopyTextFileToClipboard(string path)
        {
            string text = File.ReadAllText(path);
            CopyTextSafely(text);
        }

        /// <summary>Function to get a Rectangle of all the screens combined</summary>
        public static Rectangle GetScreenBounds()
        {
            Point topLeft = new Point(0, 0);
            Point bottomRight = new Point(0, 0);
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Bounds.X < topLeft.X) topLeft.X = screen.Bounds.X;
                if (screen.Bounds.Y < topLeft.Y) topLeft.Y = screen.Bounds.Y;
                if ((screen.Bounds.X + screen.Bounds.Width) > bottomRight.X) bottomRight.X = screen.Bounds.X + screen.Bounds.Width;
                if ((screen.Bounds.Y + screen.Bounds.Height) > bottomRight.Y) bottomRight.Y = screen.Bounds.Y + screen.Bounds.Height;
            }
            return new Rectangle(topLeft.X, topLeft.Y, bottomRight.X + Math.Abs(topLeft.X), bottomRight.Y + Math.Abs(topLeft.Y));
        }

        public static string AddZeroes(int number, int digits = 2)
        {
            return number.ToString("d" + digits);
        }

        public static string HourTo12(int hour)
        {
            if (hour == 0)
            {
                return (12).ToString();
            }

            if (hour > 12)
            {
                return AddZeroes(hour - 12);
            }

            return AddZeroes(hour);
        }

        public const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        public const string AlphabetCapital = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Numbers = "0123456789";
        public const string Alphanumeric = Alphabet + AlphabetCapital + Numbers;

        public static char GetRandomChar(string chars)
        {
            return chars[Random.Next(chars.Length)];
        }

        public static string GetRandomString(string chars, int length)
        {
            StringBuilder sb = new StringBuilder();

            while (length-- > 0)
            {
                sb.Append(GetRandomChar(chars));
            }

            return sb.ToString();
        }

        public static string GetRandomNumber(int length)
        {
            return GetRandomString(Numbers, length);
        }

        public static string GetRandomAlphanumeric(int length)
        {
            return GetRandomString(Alphanumeric, length);
        }

        public static string GetRandomKey(int length = 5, int count = 3, char separator = '-')
        {
            return Enumerable.Range(1, (length + 1) * count - 1).Aggregate("", (x, index) => x += index % (length + 1) == 0 ? separator : GetRandomChar(Alphanumeric));
        }

        public static string GetAllCharacters()
        {
            return Encoding.UTF8.GetString(Enumerable.Range(1, 255).Select(i => (byte)i).ToArray());
        }

        public static string ReplaceIllegalChars(string filename, char replace)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in filename)
            {
                if (IsCharValid(c))
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append(replace);
                }
            }

            return sb.ToString();
        }

        /// <summary>Valid chars: abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789()-._!</summary>
        public static bool IsCharValid(char c)
        {
            string chars = Alphanumeric + "()-._!";

            return chars.Any(c2 => c == c2);
        }

        public static string NormalizeString(string text, bool convertSpace = true, bool isFolderPath = false)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                // @, ?, = is for HttpHomePath we use in FTP Account
                if (IsCharValid(c) || (isFolderPath && (c == Path.DirectorySeparatorChar || c == '/' || c == '.' || c == '@' || c == '?' || c == '=')))
                {
                    result.Append(c);
                }
                else if (c == ' ')
                {
                    result.Append('_');
                }
            }

            while (result.Length > 0 && result[0] == '.')
            {
                result.Remove(0, 1);
            }

            return result.ToString();
        }

        public static string GetXMLValue(string input, string tag)
        {
            return Regex.Match(input, String.Format("(?<={0}>).+?(?=</{0})", tag)).Value;
        }

        public static string CombineURL(string url1, string url2)
        {
            bool url1Empty = string.IsNullOrEmpty(url1);
            bool url2Empty = string.IsNullOrEmpty(url2);

            if (url1Empty && url2Empty)
            {
                return string.Empty;
            }
            else if (url1Empty)
            {
                return url2;
            }
            else if (url2Empty)
            {
                return url1;
            }

            if (url1.EndsWith("/"))
            {
                url1 = url1.Substring(0, url1.Length - 1);
            }

            if (url2.StartsWith("/"))
            {
                url2 = url2.Remove(0, 1);
            }

            return url1 + "/" + url2;
        }

        public static string CombineURL(params string[] urls)
        {
            return urls.Aggregate((current, arg) => CombineURL(current, arg));
        }

        public static string GetMimeType(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string ext = Path.GetExtension(fileName).ToLower();
                RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(ext);
                if (regKey != null && regKey.GetValue("Content Type") != null)
                {
                    return regKey.GetValue("Content Type").ToString();
                }
            }
            return "application/octet-stream";
        }

        public static int GetEnumLength<T>()
        {
            return Enum.GetValues(typeof(T)).Length;
        }

        public static string[] GetEnumDescriptions<T>()
        {
            List<string> descriptions = new List<string>();
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("T must be of type System.Enum");
            }

            foreach (int value in Enum.GetValues(enumType))
            {
                descriptions.Add(((Enum)Enum.ToObject(enumType, value)).GetDescription());
            }

            return descriptions.ToArray();
        }

        public static int GetEnumMemberIndex<T>(T element) where T : struct
        {
            T[] values = (T[])Enum.GetValues(typeof(T));
            return Array.IndexOf(values, element);
        }

        public const string UnreservedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_.~";

        public static string URLEncode(string text)
        {
            StringBuilder result = new StringBuilder();

            if (!string.IsNullOrEmpty(text))
            {
                foreach (char symbol in text)
                {
                    if (UnreservedCharacters.Contains(symbol))
                    {
                        result.Append(symbol);
                    }
                    else
                    {
                        result.AppendFormat("%{0:X2}", (int)symbol);
                    }
                }
            }

            return result.ToString();
        }

        public static void OpenFolder(string directory)
        {
            Process.Start("explorer.exe", directory);
        }

        public static void OpenFolderWithFile(string filePath)
        {
            OpenFolder(string.Format("/select,\"{0}\"", filePath));
        }

        public static WebProxy GetDefaultWebProxy()
        {
            try
            {
                return ((WebProxy)typeof(WebProxy).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                    null, new Type[] { typeof(bool) }, null).Invoke(new object[] { true }));
            }
            catch
            {
            }

            return null;
        }

        public static bool CheckVersion(Version verRemote, Version verLocal)
        {
            return ProperVersion(verRemote).CompareTo(ProperVersion(verLocal)) > 0;
        }

        private static Version ProperVersion(Version version)
        {
            return new Version(Math.Max(version.Major, 0), Math.Max(version.Minor, 0), Math.Max(version.Build, 0), Math.Max(version.Revision, 0));
        }

        public static bool IsWindows8()
        {
            return Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 2;
        }

        public static void LoadBrowserAsync(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                ThreadPool.QueueUserWorkItem(x => Process.Start(url));
            }
        }

        public static bool IsValidURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                url = url.Trim();
                return !url.StartsWith("file://") && Uri.IsWellFormedUriString(url, UriKind.Absolute);
            }

            return false;
        }

        public static string GetUniqueFilePath(string folder, string filename)
        {
            string filepath = Path.Combine(folder, filename);

            if (File.Exists(filepath))
            {
                string filenameWithoutExt, ext;
                int num;

                GroupCollection groups = Regex.Match(filepath, @"(.+ \()(\d+)(\)\.\w+)").Groups;

                if (string.IsNullOrEmpty(groups[2].Value))
                {
                    filenameWithoutExt = Path.GetFileNameWithoutExtension(filename) + " (";
                    num = 1;
                    ext = ")" + Path.GetExtension(filename);
                }
                else
                {
                    filenameWithoutExt = groups[1].Value;
                    num = int.Parse(groups[2].Value);
                    ext = groups[3].Value;
                }

                do
                {
                    filepath = filenameWithoutExt + ++num + ext;
                }
                while (File.Exists(filepath));
            }

            return filepath;
        }

        /// <summary>
        /// Method to give file size with units e.g. 35 KiB or 40 kB/s
        /// </summary>
        /// <param name="size">Size in Bytes</param>
        /// <param name="binary">Whether or not units should be binary or in decimal format</param>
        /// <param name="perUnit">Per second symbol e.g. /s</param>
        /// <returns>file size with units</returns>
        public static string ProperFileSize(long size, string perUnit = "", bool binary = false)
        {
            string[] suf_decimal = { "B", "kB", "MB", "GB", "TB", "PB" };
            string[] suf_binary = { "B", "KiB", "MiB", "GiB", "TiB", "PiB" };
            int bytes = binary ? 1024 : 1000;

            int place = Convert.ToInt32(Math.Floor(Math.Log(size, bytes)));
            double num = size / Math.Pow(bytes, place);
            string format = place == 0 ? "0" : "0.00";
            return num.ToString(format) + " " + (binary ? suf_binary[place] : suf_decimal[place]) + perUnit;
        }

        public static string ProperTimeSpan(TimeSpan ts)
        {
            string time = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
            int hours = (int)ts.TotalHours;
            if (hours > 0) time = hours + ":" + time;
            return time;
        }

        public static void AsyncJob(Action thread, Action threadCompleted)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (sender, e) => thread();
            bw.RunWorkerCompleted += (sender, e) => threadCompleted();
            bw.RunWorkerAsync();
        }

        public static object Clone(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
                binaryFormatter.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                return binaryFormatter.Deserialize(ms);
            }
        }

        public static void PlaySoundAsync(Stream stream)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                using (stream)
                using (SoundPlayer soundPlayer = new SoundPlayer(stream))
                {
                    soundPlayer.PlaySync();
                }
            });
        }

        public static bool BrowseFile(string title, TextBox tb, string initialDirectory = "")
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = title;

                try
                {
                    string path = tb.Text;

                    if (!string.IsNullOrEmpty(path))
                    {
                        path = Path.GetDirectoryName(path);

                        if (Directory.Exists(path))
                        {
                            ofd.InitialDirectory = path;
                        }
                    }
                }
                finally
                {
                    if (string.IsNullOrEmpty(ofd.InitialDirectory) && !string.IsNullOrEmpty(initialDirectory))
                    {
                        ofd.InitialDirectory = initialDirectory;
                    }
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tb.Text = ofd.FileName;
                    return true;
                }
            }

            return false;
        }

        public static bool BrowseFolder(string title, TextBox tb, string initialDirectory = "")
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = title;

                string path = tb.Text;

                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    fbd.SelectedPath = path;
                }
                else if (!string.IsNullOrEmpty(initialDirectory))
                {
                    fbd.SelectedPath = initialDirectory;
                }

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tb.Text = fbd.SelectedPath;
                    return true;
                }
            }

            return false;
        }
    }
}