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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShareX
{
    public partial class HotkeySelectionControl : UserControl
    {
        public event EventHandler HotkeyChanged;
        public event EventHandler SelectedChanged;
        public event EventHandler LabelDoubleClick;

        public HotkeySetting Setting { get; set; }

        private bool selected;
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;

                if (selected)
                {
                    lblHotkeyDescription.BackColor = Color.FromArgb(200, 255, 200);
                }
                else
                {
                    lblHotkeyDescription.BackColor = Color.White;
                }
            }
        }

        public HotkeySelectionControl(HotkeySetting setting)
        {
            InitializeComponent();
            Setting = setting;
            lblHotkeyDescription.Text = setting.TaskSettings.Description;
            btnSetHotkey.Text = new KeyInfo(Setting.Hotkey).ToString();
            UpdateHotkeyStatus();
        }

        private void btnSetHotkey_Click(object sender, EventArgs e)
        {
            using (HotkeyInputForm inputForm = new HotkeyInputForm(Setting.Hotkey, Setting.HotkeyDefault))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    Setting.Hotkey = inputForm.SelectedKey;
                    btnSetHotkey.Text = new KeyInfo(Setting.Hotkey).ToString();
                    OnHotkeyChanged();
                    UpdateHotkeyStatus();
                }
            }
        }

        private void UpdateHotkeyStatus()
        {
            switch (Setting.HotkeyStatus)
            {
                case HotkeyStatus.Failed:
                    lblIsHotkeyActive.BackColor = Color.IndianRed;
                    break;
                case HotkeyStatus.NotConfigured:
                    lblIsHotkeyActive.BackColor = Color.LightGoldenrodYellow;
                    break;
                case HotkeyStatus.Registered:
                    lblIsHotkeyActive.BackColor = Color.PaleGreen;
                    break;
            }
        }

        public void UpdateDescription()
        {
            lblHotkeyDescription.Text = Setting.TaskSettings.Description;
        }

        protected void OnHotkeyChanged()
        {
            if (HotkeyChanged != null)
            {
                HotkeyChanged(this, EventArgs.Empty);
            }
        }

        protected void OnSelectedChanged()
        {
            if (SelectedChanged != null)
            {
                SelectedChanged(this, EventArgs.Empty);
            }
        }

        protected void OnLabelDoubleClick()
        {
            if (LabelDoubleClick != null)
            {
                LabelDoubleClick(this, EventArgs.Empty);
            }
        }

        private void lblHotkeyDescription_MouseEnter(object sender, EventArgs e)
        {
            if (!Selected)
            {
                lblHotkeyDescription.BackColor = Color.FromArgb(220, 240, 255);
            }
        }

        private void lblHotkeyDescription_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                lblHotkeyDescription.BackColor = Color.White;
            }
        }

        private void lblHotkeyDescription_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Selected = true;
                OnSelectedChanged();
                Focus();
            }
        }

        private void lblHotkeyDescription_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OnLabelDoubleClick();
            }
        }
    }
}