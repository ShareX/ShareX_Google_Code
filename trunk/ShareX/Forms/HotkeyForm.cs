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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ShareX
{
    public class HotkeyForm : Form
    {
        public bool IgnoreHotkeys { get; set; }
        public int HotkeyRepeatLimit { get; set; }

        public delegate void HotkeyEventHandler(ushort id, Keys key, Modifiers modifier);
        public event HotkeyEventHandler HotkeyPress;

        private Stopwatch repeatLimitTimer;

        public HotkeyForm()
        {
            HotkeyRepeatLimit = 1000;
            repeatLimitTimer = Stopwatch.StartNew();
        }

        public HotkeyInfo RegisterHotkey(HotkeyInfo hotkeyInfo)
        {
            if (hotkeyInfo != null && hotkeyInfo.Status != HotkeyStatus.Registered)
            {
                if (hotkeyInfo.ID > 0)
                {
                    return RegisterHotkey(hotkeyInfo.Hotkey, hotkeyInfo.ID);
                }
                else
                {
                    return RegisterHotkey(hotkeyInfo.Hotkey);
                }
            }

            return hotkeyInfo;
        }

        private HotkeyInfo RegisterHotkey(Keys hotkey)
        {
            return RegisterHotkey(hotkey, Helpers.GetUniqueID());
        }

        private HotkeyInfo RegisterHotkey(Keys hotkey, string atomName)
        {
            ushort id = NativeMethods.GlobalAddAtom(atomName);

            return RegisterHotkey(hotkey, id);
        }

        private HotkeyInfo RegisterHotkey(Keys hotkey, ushort id)
        {
            HotkeyInfo hotkeyInfo = new HotkeyInfo(hotkey, id);

            if (!hotkeyInfo.IsValidHotkey)
            {
                hotkeyInfo.Status = HotkeyStatus.NotConfigured;
                return hotkeyInfo;
            }

            if (id == 0)
            {
                DebugHelper.WriteLine("Unable to generate unique hotkey ID: " + hotkeyInfo);
                hotkeyInfo.Status = HotkeyStatus.Failed;
                return hotkeyInfo;
            }

            if (!NativeMethods.RegisterHotKey(Handle, (int)id, (uint)hotkeyInfo.ModifiersEnum, (uint)hotkeyInfo.KeyCode))
            {
                NativeMethods.GlobalDeleteAtom(id);
                DebugHelper.WriteLine("Unable to register hotkey: " + hotkeyInfo);
                hotkeyInfo.ID = 0;
                hotkeyInfo.Status = HotkeyStatus.Failed;
                return hotkeyInfo;
            }

            hotkeyInfo.Status = HotkeyStatus.Registered;
            return hotkeyInfo;
        }

        public bool UnregisterHotkey(HotkeyInfo hotkeyInfo)
        {
            if (hotkeyInfo != null)
            {
                bool result = UnregisterHotkey(hotkeyInfo.ID);

                if (result)
                {
                    hotkeyInfo.ID = 0;
                    hotkeyInfo.Status = HotkeyStatus.NotConfigured;
                }
                else
                {
                    hotkeyInfo.Status = HotkeyStatus.Failed;
                }

                return result;
            }

            return false;
        }

        private bool UnregisterHotkey(ushort id)
        {
            bool result = false;

            if (id > 0)
            {
                result = NativeMethods.UnregisterHotKey(Handle, id);

                if (result)
                {
                    NativeMethods.GlobalDeleteAtom(id);
                }
            }

            return result;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowsMessages.HOTKEY && !IgnoreHotkeys && CheckRepeatLimitTime())
            {
                ushort id = (ushort)m.WParam;
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                Modifiers modifier = (Modifiers)((int)m.LParam & 0xFFFF);
                OnKeyPressed(id, key, modifier);
                return;
            }

            base.WndProc(ref m);
        }

        protected void OnKeyPressed(ushort id, Keys key, Modifiers modifier)
        {
            if (HotkeyPress != null)
            {
                HotkeyPress(id, key, modifier);
            }
        }

        private bool CheckRepeatLimitTime()
        {
            if (HotkeyRepeatLimit > 0)
            {
                if (repeatLimitTimer.ElapsedMilliseconds >= HotkeyRepeatLimit)
                {
                    repeatLimitTimer.Reset();
                    repeatLimitTimer.Start();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}