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
using System.Reflection;
using System.Windows.Forms;
using HelpersLib;

namespace HistoryLib.CustomControls
{
    public class ObjectListView : MyListView
    {
        public enum ObjectType { Fields, Properties }

        public ObjectType SetObjectType { get; set; }

        public object SelectedObject
        {
            set
            {
                SelectObject(value);
            }
        }

        public ObjectListView()
        {
            this.SetObjectType = ObjectType.Properties;
            this.MultiSelect = false;
            this.Columns.Add("Name", 125);
            this.Columns.Add("Value", 300);
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add("Copy name").Click += new EventHandler(PropertyListView_Click_Name);
            contextMenu.MenuItems.Add("Copy value").Click += new EventHandler(PropertyListView_Click_Value);
            this.ContextMenu = contextMenu;
        }

        private void PropertyListView_Click_Name(object sender, EventArgs e)
        {
            if (this.SelectedItems.Count > 0)
            {
                string text = this.SelectedItems[0].Text;
                if (!string.IsNullOrEmpty(text))
                {
                    Helpers.CopyTextSafely(text);
                }
            }
        }

        private void PropertyListView_Click_Value(object sender, EventArgs e)
        {
            if (this.SelectedItems.Count > 0)
            {
                string text = this.SelectedItems[0].SubItems[1].Text;
                if (!string.IsNullOrEmpty(text))
                {
                    Helpers.CopyTextSafely(text);
                }
            }
        }

        public void SelectObject(object obj)
        {
            this.Items.Clear();

            if (obj != null)
            {
                Type type = obj.GetType();

                if (SetObjectType == ObjectType.Fields)
                {
                    foreach (FieldInfo property in type.GetFields())
                    {
                        AddObject(property.GetValue(obj), property.Name);
                    }
                }
                else if (SetObjectType == ObjectType.Properties)
                {
                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        AddObject(property.GetValue(obj, null), property.Name);
                    }
                }

                FillLastColumn();
            }
        }

        private void AddObject(object obj, string name)
        {
            if (obj is HistoryItem)
            {
                SelectObject(obj);
                return;
            }

            ListViewItem lvi = new ListViewItem(name);
            lvi.Tag = obj;
            if (obj != null)
            {
                lvi.SubItems.Add(obj.ToString());
            }

            this.Items.Add(lvi);
        }
    }
}