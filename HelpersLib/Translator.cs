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

using System.Text;
using System.Text.RegularExpressions;

namespace HelpersLib
{
    public class Translator
    {
        public string Text { get; private set; }

        // http://en.wikipedia.org/wiki/Binary_numeral_system
        public string[] Binary { get; private set; }

        public string BinaryText
        {
            get
            {
                return Binary.Join();
            }
        }

        // http://en.wikipedia.org/wiki/Hexidecimal
        public string[] Hex { get; private set; }

        public string HexText
        {
            get
            {
                return Hex.Join();
            }
        }

        // http://en.wikipedia.org/wiki/ASCII
        public byte[] ASCII { get; private set; }

        public string ASCIIText
        {
            get
            {
                return ASCII.Join();
            }
        }

        // http://en.wikipedia.org/wiki/Base64
        public string Base64 { get; private set; }

        // http://en.wikipedia.org/wiki/Md5
        public string MD5 { get; private set; }

        // http://en.wikipedia.org/wiki/Sha1
        public string SHA1 { get; private set; }

        public void EncodeText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Text = text;
                Binary = TranslatorHelper.TextToBinary(text);
                Hex = TranslatorHelper.TextToHexidecimal(text);
                ASCII = TranslatorHelper.TextToASCII(text);
                Base64 = TranslatorHelper.TextToBase64(text);
                MD5 = TranslatorHelper.TextToCrypto(text, CryptoType.MD5);
                SHA1 = TranslatorHelper.TextToCrypto(text, CryptoType.SHA1);
            }
        }

        public bool DecodeBinary(string binary)
        {
            string binaryText = Regex.Replace(binary, @"[^01]", "");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i + 8 <= binaryText.Length; i += 8)
            {
                char c = (char)TranslatorHelper.BinaryToByte(binaryText.Substring(i, 8));
                sb.Append(c);
            }

            return DecodeReturn(sb.ToString());
        }

        public bool DecodeHex(string hex)
        {
            string hexText = Regex.Replace(hex, @"[^0-9a-fA-F]", "");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i + 2 <= hexText.Length; i += 2)
            {
                char c = (char)TranslatorHelper.HexToByte(hexText.Substring(i, 2));
                sb.Append(c);
            }

            return DecodeReturn(sb.ToString());
        }

        public bool DecodeASCII(string dec)
        {
            string[] numbers = Regex.Split(dec, @"\D+");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numbers.Length; i++)
            {
                int number;
                if (int.TryParse(numbers[i], out number))
                {
                    sb.Append((char)number);
                }
            }

            return DecodeReturn(sb.ToString());
        }

        public bool DecodeBase64(string base64)
        {
            string result = TranslatorHelper.Base64ToText(base64);

            return DecodeReturn(result);
        }

        private bool DecodeReturn(string result)
        {
            if (!string.IsNullOrEmpty(result))
            {
                EncodeText(result);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return string.Format("Text: {0}\r\nBinary: {1}\r\nHex: {2}\r\nASCII: {3}\r\nBase64: {4}\r\nMD5: {5}\r\nSHA1: {6}",
                Text, BinaryText, HexText, ASCIIText, Base64, MD5, SHA1);
        }
    }
}