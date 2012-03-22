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
using System.Windows.Forms;

namespace HelpersLib
{
    public class KeyInfo
    {
        public Keys Key { get; set; }

        public Keys KeyCode
        {
            get
            {
                return Key & Keys.KeyCode;
            }
        }

        public Keys ModifiersKeys
        {
            get
            {
                return Key & Keys.Modifiers;
            }
        }

        public bool Alt
        {
            get
            {
                return (Key & Keys.Alt) == Keys.Alt;
            }
        }

        public bool Control
        {
            get
            {
                return (Key & Keys.Control) == Keys.Control;
            }
        }

        public bool Shift
        {
            get
            {
                return (Key & Keys.Shift) == Keys.Shift;
            }
        }

        public Modifiers ModifiersEnum
        {
            get
            {
                Modifiers modifiers = Modifiers.None;

                if (Alt) modifiers |= Modifiers.Alt;
                if (Control) modifiers |= Modifiers.Control;
                if (Shift) modifiers |= Modifiers.Shift;

                return modifiers;
            }
        }

        public KeyInfo(Keys key)
        {
            Key = key;
        }

        public override string ToString()
        {
            string text = string.Empty;

            if (Control)
            {
                text += "Control + ";
            }

            if (Shift)
            {
                text += "Shift + ";
            }

            if (Alt)
            {
                text += "Alt + ";
            }

            if (KeyCode == Keys.PageDown)
            {
                text += "Page Down";
            }
            else if (KeyCode == Keys.Back)
            {
                text += "Backspace";
            }
            else if (KeyCode >= Keys.D0 && KeyCode <= Keys.D9)
            {
                text += (KeyCode - Keys.D0).ToString();
            }
            else
            {
                text += ToStringWithSpaces(KeyCode);
            }

            return text;
        }

        private string ToStringWithSpaces(Keys key)
        {
            string name = key.ToString();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < name.Length; i++)
            {
                if (i > 0 && char.IsUpper(name[i]))
                {
                    result.Append(" " + name[i]);
                }
                else
                {
                    result.Append(name[i]);
                }
            }

            return result.ToString();
        }
    }
}