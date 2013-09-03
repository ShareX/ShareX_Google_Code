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
        public List<HotkeyInfo> HotkeyList { get; private set; }

        public bool IgnoreHotkeys { get; set; }

        public int HotkeyRepeatLimit { get; set; }

        public delegate void HotkeyEventHandler(KeyEventArgs e);
        public event HotkeyEventHandler HotkeyPress;

        private Stopwatch repeatLimitTimer;

        public HotkeyForm()
        {
            HotkeyList = new List<HotkeyInfo>();
            HotkeyRepeatLimit = 1000;

            repeatLimitTimer = Stopwatch.StartNew();
        }

        public HotkeyInfo RegisterHotkey(HotkeyInfo hotkeyInfo)
        {
            if (hotkeyInfo != null && hotkeyInfo.Status != HotkeyStatus.Registered)
            {
                if (hotkeyInfo.ID > 0)
                {
                    return RegisterHotkey(hotkeyInfo.Hotkey, hotkeyInfo.HotkeyPress, hotkeyInfo.ID);
                }
                else
                {
                    return RegisterHotkey(hotkeyInfo.Hotkey, hotkeyInfo.HotkeyPress);
                }
            }

            return hotkeyInfo;
        }

        private HotkeyInfo RegisterHotkey(Keys hotkey, Action hotkeyPress)
        {
            return RegisterHotkey(hotkey, hotkeyPress, Helpers.GetUniqueID());
        }

        private HotkeyInfo RegisterHotkey(Keys hotkey, Action hotkeyPress, string atomName)
        {
            ushort id = NativeMethods.GlobalAddAtom(atomName);

            return RegisterHotkey(hotkey, hotkeyPress, id);
        }

        private HotkeyInfo RegisterHotkey(Keys hotkey, Action hotkeyPress, ushort id)
        {
            HotkeyInfo hotkeyInfo = new HotkeyInfo(hotkey, hotkeyPress, id);

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

            if (IsHotkeyExist(hotkey))
            {
                DebugHelper.WriteLine("Hotkey already exist: " + hotkeyInfo);
                hotkeyInfo.Status = HotkeyStatus.Failed;
                return hotkeyInfo;
            }

            if (!NativeMethods.RegisterHotKey(Handle, (int)id, (uint)hotkeyInfo.ModifiersEnum, (uint)hotkeyInfo.KeyCode))
            {
                NativeMethods.GlobalDeleteAtom(id);
                DebugHelper.WriteLine("Unable to register hotkey: " + hotkeyInfo);
                hotkeyInfo.Status = HotkeyStatus.Failed;
                return hotkeyInfo;
            }

            HotkeyList.Add(hotkeyInfo);

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
                    hotkeyInfo.Status = HotkeyStatus.NotConfigured;
                }
                else
                {
                    hotkeyInfo.Status = HotkeyStatus.Failed;
                }

                HotkeyList.Remove(hotkeyInfo);
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
                NativeMethods.GlobalDeleteAtom(id);
            }

            return result;
        }

        public HotkeyInfo UpdateHotkey(HotkeyInfo hotkeyInfo)
        {
            UnregisterHotkey(hotkeyInfo);
            return RegisterHotkey(hotkeyInfo);
        }

        public void UnregisterAllHotkeys()
        {
            for (int i = 0; i < HotkeyList.Count; i++)
            {
                UnregisterHotkey(HotkeyList[i]);
            }
        }

        public bool IsHotkeyExist(Keys key)
        {
            return HotkeyList.Any(x => x.Hotkey == key);
        }

        private HotkeyInfo GetHotkeyInfoFromID(ushort id)
        {
            return HotkeyList.FirstOrDefault(x => x.ID == id);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowsMessages.HOTKEY && !IgnoreHotkeys && CheckRepeatLimitTime())
            {
                HotkeyInfo hotkey = GetHotkeyInfoFromID((ushort)m.WParam);

                if (hotkey != null)
                {
                    if (hotkey.HotkeyPress != null)
                    {
                        hotkey.HotkeyPress();
                    }

                    OnKeyPressed(new KeyEventArgs(hotkey.Hotkey));
                }

                return;
            }

            base.WndProc(ref m);
        }

        protected void OnKeyPressed(KeyEventArgs e)
        {
            if (HotkeyPress != null)
            {
                HotkeyPress(e);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            UnregisterAllHotkeys();

            base.OnClosed(e);
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