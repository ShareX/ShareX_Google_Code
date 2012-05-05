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
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace HelpersLib
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

        public HotkeyStatus RegisterHotkey(Keys hotkey, Action hotkeyPress = null, int tag = 0)
        {
            KeyInfo keyInfo = new KeyInfo(hotkey);

            if (keyInfo.KeyCode == Keys.None)
            {
                return HotkeyStatus.NotConfigured;
            }

            if (IsHotkeyExist(hotkey))
            {
                DebugHelper.WriteLine("Hotkey already exist: " + keyInfo);
                return HotkeyStatus.Failed;
            }

            string atomName = Thread.CurrentThread.ManagedThreadId.ToString("X8") + (int)hotkey;

            ushort id = NativeMethods.GlobalAddAtom(atomName);

            if (id == 0)
            {
                DebugHelper.WriteLine("Unable to generate unique hotkey ID. Error code: " + Marshal.GetLastWin32Error());
                return HotkeyStatus.Failed;
            }

            if (!NativeMethods.RegisterHotKey(Handle, (int)id, (uint)keyInfo.ModifiersEnum, (uint)keyInfo.KeyCode))
            {
                NativeMethods.GlobalDeleteAtom(id);
                DebugHelper.WriteLine("Unable to register hotkey: {0}\r\nError code: {1}", keyInfo, Marshal.GetLastWin32Error());
                return HotkeyStatus.Failed;
            }

            HotkeyInfo hotkeyInfo = new HotkeyInfo(id, hotkey, hotkeyPress, tag);
            HotkeyList.Add(hotkeyInfo);

            return HotkeyStatus.Registered;
        }

        public bool UnregisterHotkey(ushort id)
        {
            bool result = false;

            if (id > 0)
            {
                result = NativeMethods.UnregisterHotKey(Handle, id);
                NativeMethods.GlobalDeleteAtom(id);
            }

            return result;
        }

        public bool UnregisterHotkey(HotkeyInfo hotkeyInfo)
        {
            if (hotkeyInfo != null)
            {
                bool result = UnregisterHotkey(hotkeyInfo.ID);
                HotkeyList.Remove(hotkeyInfo);
                return result;
            }

            return false;
        }

        public bool UnregisterHotkey(Keys key)
        {
            HotkeyInfo hotkeyInfo = GetHotkeyInfoFromKey(key);

            return UnregisterHotkey(hotkeyInfo);
        }

        public HotkeyStatus ChangeHotkey(int tag, Keys newHotkey, Action hotkeyPress = null)
        {
            HotkeyInfo hi = GetHotkeyInfoFromTag(tag);

            if (hi != null)
            {
                UnregisterHotkey(hi);
            }

            return RegisterHotkey(newHotkey, hotkeyPress, tag);
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
            return HotkeyList.Any(x => x.Key == key);
        }

        public HotkeyInfo GetHotkeyInfoFromKey(Keys key)
        {
            return HotkeyList.FirstOrDefault(x => x.Key == key);
        }

        public HotkeyInfo GetHotkeyInfoFromTag(int tag)
        {
            return HotkeyList.FirstOrDefault(x => x.Tag == tag);
        }

        public HotkeyInfo GetHotkeyInfoFromID(ushort id)
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

                    OnKeyPressed(new KeyEventArgs(hotkey.Key));
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