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
using ShareX.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShareX
{
    public partial class HotkeyInputForm : Form
    {
        public Keys SelectedKey { get; set; }

        public KeyInfo SelectedKeyInfo
        {
            get
            {
                return new KeyInfo(SelectedKey);
            }
        }

        public Keys DefaultKey { get; set; }

        private HotkeyInputForm()
        {
            InitializeComponent();
            Icon = Resources.ShareXIcon;
        }

        public HotkeyInputForm(Keys key, Keys defaultKey)
            : this()
        {
            SelectedKey = key;
            DefaultKey = defaultKey;
            btnReset.Visible = defaultKey != Keys.None;
            UpdateTextBox();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedKeyInfo.IsOnlyModifiers)
            {
                SelectedKey = Keys.None;
            }

            Program.MainForm.IgnoreHotkeys = false;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Program.MainForm.IgnoreHotkeys = false;
            DialogResult = DialogResult.Cancel;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SelectedKey = DefaultKey;
            UpdateTextBox();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SelectedKey = Keys.None;
            UpdateTextBox();
        }

        private void UpdateTextBox()
        {
            if (SelectedKey == Keys.None)
            {
                tbHotkey.Text = "Select hotkey...";
            }
            else
            {
                tbHotkey.Text = SelectedKeyInfo.ToString();
            }
        }

        private void tbHotkey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // For handle Tab key etc.
            e.IsInputKey = true;
        }

        private void tbHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            SelectedKey = e.KeyData;
            UpdateTextBox();
        }

        private void tbHotkey_KeyUp(object sender, KeyEventArgs e)
        {
            // PrintScreen not trigger KeyDown event
            if (e.KeyCode == Keys.PrintScreen)
            {
                e.SuppressKeyPress = true;
                SelectedKey = e.KeyData;
                UpdateTextBox();
            }
        }

        private void tbHotkey_Enter(object sender, EventArgs e)
        {
            Program.MainForm.IgnoreHotkeys = true;
            tbHotkey.Text = string.Empty;
        }

        private void tbHotkey_Leave(object sender, EventArgs e)
        {
            Program.MainForm.IgnoreHotkeys = false;
            UpdateTextBox();
        }
    }
}