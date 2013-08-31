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
        public List<HotkeySetting> Hotkeys { get; private set; }

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

        public void RegisterAllHotkeys()
        {
            foreach (HotkeySetting hotkeySetting in Hotkeys)
            {
                RegisterHotkey(hotkeySetting);
            }
        }

        public void ShowFailedHotkeys()
        {
            IEnumerable<HotkeySetting> failedHotkeysList = Hotkeys.Where(x => x.HotkeyInfo.Status == HotkeyStatus.Failed);

            if (failedHotkeysList.Count() > 0)
            {
                string failedHotkeys = string.Join("\r\n", failedHotkeysList.Select(x => x.TaskSettings.Description + ": " + x.ToString()).ToArray());

                MessageBox.Show("Unable to register hotkey(s):\r\n\r\n" + failedHotkeys +
                    "\r\n\r\nPlease select a different hotkey or quit the conflicting application and reopen ShareX.",
                    "ShareX - Hotkey register failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RegisterHotkey(HotkeySetting hotkeySetting)
        {
            if (hotkeySetting.HotkeyInfo.HotkeyPress == null)
            {
                hotkeySetting.HotkeyInfo.HotkeyPress = () => triggerAction(hotkeySetting);
            }

            hotkeySetting.HotkeyInfo = hotkeyForm.RegisterHotkey(hotkeySetting.HotkeyInfo);

            if (!Hotkeys.Contains(hotkeySetting))
            {
                Hotkeys.Add(hotkeySetting);
            }
        }

        public void UpdateHotkey(HotkeySetting hotkeySetting)
        {
            hotkeyForm.UnregisterHotkey(hotkeySetting.HotkeyInfo);

            RegisterHotkey(hotkeySetting);
        }

        public void UnregisterHotkey(HotkeySetting hotkeySetting)
        {
            hotkeyForm.UnregisterHotkey(hotkeySetting.HotkeyInfo);

            Hotkeys.Remove(hotkeySetting);
        }

        public void ResetHotkeys()
        {
            for (int i = Hotkeys.Count - 1; i >= 0; i--)
            {
                UnregisterHotkey(Hotkeys[i]);
            }

            Hotkeys.AddRange(GetDefaultHotkeyList());
        }

        public HotkeySetting[] GetDefaultHotkeyList()
        {
            return new HotkeySetting[]
            {
                new HotkeySetting(HotkeyType.ClipboardUpload, Keys.Control | Keys.PageUp),
                new HotkeySetting(HotkeyType.FileUpload, Keys.Shift | Keys.PageUp),
                new HotkeySetting(HotkeyType.PrintScreen, Keys.PrintScreen),
                new HotkeySetting(HotkeyType.ActiveWindow, Keys.Alt | Keys.PrintScreen),
                new HotkeySetting(HotkeyType.ActiveMonitor, Keys.Control | Keys.Alt | Keys.PrintScreen),
                new HotkeySetting(HotkeyType.WindowRectangle, Keys.Shift | Keys.PrintScreen),
                new HotkeySetting(HotkeyType.RectangleRegion, Keys.Control | Keys.PrintScreen),
                new HotkeySetting(HotkeyType.ScreenRecorder, Keys.Shift | Keys.F11)
            };
        }
    }
}