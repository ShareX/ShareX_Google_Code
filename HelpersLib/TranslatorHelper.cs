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
using System.Security.Cryptography;
using System.Text;

namespace HelpersLib
{
    public static class TranslatorHelper
    {
        public static string[] TextToBinary(string text)
        {
            string[] result = new string[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                result[i] = ByteToBinary((byte)text[i]);
            }

            return result;
        }

        public static string ByteToBinary(byte b)
        {
            char[] result = new char[8];
            int pos = 7;

            for (int i = 0; i < 8; i++)
            {
                if ((b & (1 << i)) != 0)
                {
                    result[pos] = '1';
                }
                else
                {
                    result[pos] = '0';
                }

                pos--;
            }

            return new string(result);
        }

        public static string[] TextToHexidecimal(string text)
        {
            string[] result = new string[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                result[i] = ((byte)text[i]).ToString("x2");
            }

            return result;
        }

        public static byte[] TextToASCII(string text)
        {
            return Encoding.ASCII.GetBytes(text);
        }

        public static byte BinaryToByte(string binary)
        {
            return Convert.ToByte(binary, 2);
        }

        public static byte HexToByte(string hex)
        {
            return Convert.ToByte(hex, 16);
        }

        public static string TextToBase64(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }

        public static string Base64ToText(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string TextToCrypto(string text, CryptoType cryptoType)
        {
            byte[] bytes;

            HashAlgorithm hash = null;

            switch (cryptoType)
            {
                case CryptoType.MD5:
                    hash = new MD5CryptoServiceProvider();
                    break;
                case CryptoType.SHA1:
                    hash = new SHA1CryptoServiceProvider();
                    break;
            }

            bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            hash.Clear();

            StringBuilder sb = new StringBuilder();

            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}