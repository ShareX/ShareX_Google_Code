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

using HelpersLib;
using ScreenCapture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShareX
{
    public partial class ScreenRecordForm : Form
    {
        public ScreenRecordForm()
        {
            InitializeComponent();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            btnRecord.Enabled = false;
            ScreenRecorder screenRecorder = new ScreenRecorder(5, 3, new Rectangle(0, 0, 500, 300));
            Helpers.AsyncJob(() =>
            {
                screenRecorder.StartRecording();
            },
            () =>
            {
                Stopwatch timer = Stopwatch.StartNew();
                screenRecorder.MakeGIF(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.gif"), Program.Settings.ImageGIFQuality);
                Debug.WriteLine(timer.ElapsedMilliseconds);
                screenRecorder.ClearTempFolder();
                btnRecord.Enabled = true;
            });
        }
    }
}