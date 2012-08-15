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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelpersLib;
using ShareX.Properties;

namespace ShareX
{
    public partial class AfterCaptureForm : Form
    {
        public AfterCaptureTasks AfterCaptureTasks { get; private set; }
        public Image Image { get; private set; }
        public AfterCaptureFormResult Result { get; private set; }

        public AfterCaptureForm(Image img, AfterCaptureTasks afterCaptureTasks)
        {
            InitializeComponent();
            Icon = Resources.ShareX;
            AfterCaptureTasks = afterCaptureTasks;
            AddAfterCaptureItems(AfterCaptureTasks);
            Image = img;
            pbImage.LoadImage(Image);
        }

        private void AddAfterCaptureItems(AfterCaptureTasks afterCaptureTasks)
        {
            AfterCaptureTasks[] enums = (AfterCaptureTasks[])Enum.GetValues(typeof(AfterCaptureTasks));

            for (int i = 1; i < enums.Length; i++)
            {
                ListViewItem lvi = new ListViewItem(enums[i].GetDescription());
                lvi.Checked = AfterCaptureTasks.HasFlag(1 << (i - 1));
                lvi.Tag = enums[i];
                lvAfterCaptureTasks.Items.Add(lvi);
            }
        }

        private void lvAfterCaptureTasks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            AfterCaptureTasks afterCaptureTasks = AfterCaptureTasks.None;

            for (int i = 1; i < lvAfterCaptureTasks.Items.Count; i++)
            {
                ListViewItem lvi = lvAfterCaptureTasks.Items[i];

                if (lvi.Checked)
                {
                    afterCaptureTasks = afterCaptureTasks.Add((AfterCaptureTasks)(1 << i));
                }
            }

            AfterCaptureTasks = afterCaptureTasks;
        }

        private void Close(AfterCaptureFormResult result)
        {
            Result = result;
            Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Close(AfterCaptureFormResult.Continue);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close(AfterCaptureFormResult.Cancel);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Close(AfterCaptureFormResult.Copy);
        }
    }
}