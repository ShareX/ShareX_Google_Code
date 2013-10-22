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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShareX
{
    public partial class ScreenColorPicker : DialogColor
    {
        private Timer colorTimer = new Timer { Interval = 10 };

        public ScreenColorPicker()
        {
            InitializeComponent();
            Location = CaptureHelpers.GetActiveScreenBounds().Location;
            colorPicker.DrawCrosshair = true;
            colorTimer.Tick += colorTimer_Tick;
            colorTimer.Start();
            UpdateColorPickerButtonText();
        }

        private void UpdateColor(int x, int y)
        {
            UpdateColor(x, y, CaptureHelpers.GetPixelColor(x, y));
        }

        private void UpdateColor(int x, int y, Color color)
        {
            nudX.Value = x;
            nudY.Value = y;
            colorPicker.ChangeColor(color);
        }

        private void UpdateColorPickerButtonText()
        {
            if (colorTimer.Enabled)
            {
                btnColorPicker.Text = "Stop screen color picker";
            }
            else
            {
                btnColorPicker.Text = "Start screen color picker";
            }

            lblScreenColorPickerTip.Visible = colorTimer.Enabled;
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            colorTimer.Enabled = !colorTimer.Enabled;
            UpdateColorPickerButtonText();
        }

        private void btnPipette_Click(object sender, EventArgs e)
        {
            colorTimer.Enabled = false;
            UpdateColorPickerButtonText();
            Refresh();

            PointInfo pointInfo = TaskHelpers.SelectPointColor();

            if (pointInfo != null)
            {
                UpdateColor(pointInfo.Position.X, pointInfo.Position.Y, pointInfo.Color);
            }
        }

        private void colorTimer_Tick(object sender, EventArgs e)
        {
            Point position = CaptureHelpers.GetCursorPosition();
            UpdateColor(position.X, position.Y);
        }

        private void ScreenColorPicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && !txtHex.Focused)
            {
                btnColorPicker.Focus();
                colorTimer.Enabled = !colorTimer.Enabled;
                UpdateColorPickerButtonText();
                e.SuppressKeyPress = true;
            }
        }
    }
}