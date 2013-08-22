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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShareX
{
    public delegate void HotkeyTriggerEventHandler(HotkeySetting hotkeySetting);

    public class HotkeyManager
    {
        public List<HotkeySetting> Hotkeys = new List<HotkeySetting>();

        private HotkeyForm hotkeyForm;
        private HotkeyTriggerEventHandler triggerAction;

        public HotkeyManager(HotkeyForm hotkeyForm, List<HotkeySetting> hotkeys, HotkeyTriggerEventHandler action)
        {
            this.hotkeyForm = hotkeyForm;
            triggerAction = action;

            Hotkeys = hotkeys;

            if (Hotkeys.Count == 0)
            {
                ResetHotkeys();
            }
        }

        public void RunHotkeys()
        {
            foreach (HotkeySetting hotkey in Hotkeys)
            {
                if (hotkey.HotkeyStatus != HotkeyStatus.Registered)
                {
                    AddHotkey(hotkey);
                }
            }
        }

        public void AddHotkey(HotkeySetting hotkeySetting)
        {
            AddHotkey(hotkeySetting, hotkeySetting.TaskSettings.Description + "_" + hotkeySetting.TaskSettings.Job + "_" + hotkeySetting.Hotkey);
        }

        private void AddHotkey(HotkeySetting hotkeySetting, string tag)
        {
            hotkeySetting.Tag = tag;
            hotkeySetting.UpdateMenuItemShortcut();
            hotkeySetting.HotkeyStatus = hotkeyForm.RegisterHotkey(hotkeySetting.Hotkey, () => triggerAction(hotkeySetting), tag);
        }

        public HotkeyStatus UpdateHotkey(HotkeySetting hotkeySetting)
        {
            hotkeySetting.UpdateMenuItemShortcut();
            hotkeySetting.HotkeyStatus = hotkeyForm.ChangeHotkey(hotkeySetting.Tag, hotkeySetting.Hotkey, () => triggerAction(hotkeySetting));
            return hotkeySetting.HotkeyStatus;
        }

        public void RemoveHotkey(HotkeySetting hotkeySetting)
        {
            hotkeyForm.UnregisterHotkey(hotkeySetting.Tag);
            Hotkeys.Remove(hotkeySetting);
        }

        public bool IsHotkeyRegisterFailed(out string failedHotkeys)
        {
            failedHotkeys = null;
            bool status = false;
            var failedHotkeysList = Hotkeys.Where(x => x.HotkeyStatus == HotkeyStatus.Failed);
            if (status = failedHotkeysList.Count() > 0)
            {
                failedHotkeys = string.Join("\r\n", failedHotkeysList.Select(x => x.TaskSettings.Description + ": " + x.ToString()).ToArray());
            }
            return status;
        }

        public void ResetHotkeys()
        {
            for (int i = Hotkeys.Count - 1; i >= 0; i--)
            {
                RemoveHotkey(Hotkeys[i]);
            }

            Hotkeys.AddRange(new HotkeySetting[]
            {
                new HotkeySetting(EHotkey.ClipboardUpload, Keys.Control | Keys.PageUp),
                new HotkeySetting(EHotkey.FileUpload, Keys.Shift | Keys.PageUp),
                new HotkeySetting(EHotkey.PrintScreen, Keys.PrintScreen),
                new HotkeySetting(EHotkey.ActiveWindow, Keys.Alt | Keys.PrintScreen),
                new HotkeySetting(EHotkey.ActiveMonitor, Keys.Control | Keys.Alt | Keys.PrintScreen),
                new HotkeySetting(EHotkey.WindowRectangle, Keys.Shift | Keys.PrintScreen),
                new HotkeySetting(EHotkey.RectangleRegion, Keys.Control | Keys.PrintScreen),
                new HotkeySetting(EHotkey.RoundedRectangleRegion),
                new HotkeySetting(EHotkey.EllipseRegion),
                new HotkeySetting(EHotkey.TriangleRegion),
                new HotkeySetting(EHotkey.DiamondRegion),
                new HotkeySetting(EHotkey.PolygonRegion),
                new HotkeySetting(EHotkey.FreeHandRegion),
                new HotkeySetting(EHotkey.LastRegion),
                new HotkeySetting(EHotkey.ScreenRecorder),
                new HotkeySetting(EHotkey.AutoCapture)
            });
        }
    }
}