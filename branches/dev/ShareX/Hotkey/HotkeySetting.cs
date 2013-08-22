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
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ShareX
{
    public class HotkeySetting
    {
        public Keys Hotkey { get; set; }

        public Keys HotkeyDefault { get; set; }

        public TaskSettings TaskSettings { get; set; }

        [XmlIgnore, JsonIgnore]
        public HotkeyStatus HotkeyStatus { get; set; }

        [XmlIgnore, JsonIgnore]
        public string Tag { get; set; }

        [XmlIgnore, JsonIgnore]
        public ToolStripMenuItem MenuItem { get; set; }

        public HotkeySetting()
        {
            TaskSettings = new TaskSettings();
            HotkeyStatus = HotkeyStatus.NotConfigured;
        }

        public HotkeySetting(EHotkey job, Keys hotkey = Keys.None)
            : this()
        {
            TaskSettings.Job = job;
            TaskSettings.Description = job.GetDescription();
            Hotkey = hotkey;
            HotkeyDefault = hotkey;
        }

        public void UpdateMenuItemShortcut()
        {
            if (MenuItem != null)
            {
                MenuItem.ShortcutKeyDisplayString = new KeyInfo(Hotkey).ToString();
            }
        }

        public override string ToString()
        {
            return new KeyInfo(Hotkey).ToString();
        }
    }
}