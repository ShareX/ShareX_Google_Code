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

using HelpersLib.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HelpersLib
{
    public partial class DialogColor : Form
    {
        public Color Color;
        public bool ScreenPicker;

        private MyColor NewColor = Color.Red;
        private MyColor OldColor;
        private bool oldColorExist;
        private bool dialogChanged;

        public DialogColor()
            : this(Color.Empty)
        {
        }

        public DialogColor(Color currentColor)
        {
            Initialize(currentColor);
        }

        private void Initialize(Color currentColor)
        {
            InitializeComponent();
            Icon = Resources.ShareXIcon;

            foreach (Control control in Controls)
            {
                if (control is NumericUpDown || control is TextBox)
                {
                    control.DoubleClick += new EventHandler(CopyToClipboard);
                }
            }

            if (currentColor.IsEmpty)
            {
                colorPicker.DrawCrosshair = lblOld.Visible = oldColorExist;
                DrawPreviewColors();
            }
            else
            {
                SetCurrentColor(currentColor);
            }
        }

        public void SetCurrentColor(Color currentColor)
        {
            oldColorExist = true;
            colorPicker.DrawCrosshair = lblOld.Visible = oldColorExist;
            colorPicker.Color = NewColor = OldColor = currentColor;
            nudAlpha.Value = currentColor.A;
            DrawPreviewColors();
        }

        private void UpdateControls(MyColor color)
        {
            DrawPreviewColors();
            dialogChanged = true;
            nudHue.Value = (decimal)Math.Round(color.HSB.Hue360);
            nudSaturation.Value = (decimal)Math.Round(color.HSB.Saturation100);
            nudBrightness.Value = (decimal)Math.Round(color.HSB.Brightness100);
            nudRed.Value = color.RGBA.Red;
            nudGreen.Value = color.RGBA.Green;
            nudBlue.Value = color.RGBA.Blue;
            nudCyan.Value = (decimal)Math.Round(color.CMYK.Cyan100);
            nudMagenta.Value = (decimal)Math.Round(color.CMYK.Magenta100);
            nudYellow.Value = (decimal)Math.Round(color.CMYK.Yellow100);
            nudKey.Value = (decimal)Math.Round(color.CMYK.Key100);
            txtHex.Text = ColorHelpers.ColorToHex(color);
            txtDecimal.Text = ColorHelpers.ColorToDecimal(color).ToString();
            dialogChanged = false;
        }

        private void DrawPreviewColors()
        {
            Bitmap bmp = new Bitmap(pbColorPreview.ClientSize.Width, pbColorPreview.ClientSize.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                int bmpHeight = bmp.Height;

                if (oldColorExist)
                {
                    bmpHeight /= 2;

                    using (SolidBrush oldColorBrush = new SolidBrush(OldColor))
                    {
                        g.FillRectangle(oldColorBrush, new Rectangle(0, bmpHeight, bmp.Width, bmpHeight));
                    }
                }

                using (SolidBrush newColorBrush = new SolidBrush(NewColor))
                {
                    g.FillRectangle(newColorBrush, new Rectangle(0, 0, bmp.Width, bmpHeight));
                }
            }

            using (bmp)
            {
                pbColorPreview.LoadImage(bmp);
            }
        }

        private void UpdateColor(int x, int y)
        {
            nudX.Value = x;
            nudY.Value = y;
            colorPicker.Color = CaptureHelpers.GetPixelColor(x, y);
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

        #region Events

        private void DialogColor_Load(object sender, EventArgs e)
        {
            if (ScreenPicker)
            {
                Location = new Point(0, 0);
                ClientSize = new Size(ClientSize.Width, pScreenColorPicker.Location.Y + pScreenColorPicker.Height);
                pScreenColorPicker.Visible = true;
                colorPicker.DrawCrosshair = true;
                colorTimer.Start();
                UpdateColorPickerButtonText();
            }
            else
            {
                Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Width / 2), Screen.PrimaryScreen.Bounds.Height / 2 - (Height / 2));
            }
        }

        private void CopyToClipboard(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                ClipboardHelpers.CopyText(((NumericUpDown)sender).Value.ToString());
            }
            else if (sender is TextBox)
            {
                ClipboardHelpers.CopyText(((TextBox)sender).Text);
            }
        }

        private void colorPicker_ColorChanged(object sender, ColorEventArgs e)
        {
            NewColor = e.Color;
            UpdateControls(NewColor);
        }

        private void ColorDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && !txtHex.Focused)
            {
                btnColorPicker.Focus();
                colorTimer.Enabled = !colorTimer.Enabled;
                UpdateColorPickerButtonText();
                e.SuppressKeyPress = true;
            }
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            colorTimer.Enabled = !colorTimer.Enabled;
            UpdateColorPickerButtonText();
        }

        private void colorTimer_Tick(object sender, EventArgs e)
        {
            Point position = CaptureHelpers.GetCursorPosition();
            UpdateColor(position.X, position.Y);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Color = Color.FromArgb((int)nudAlpha.Value, (int)nudRed.Value, (int)nudGreen.Value, (int)nudBlue.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void rbHue_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHue.Checked) colorPicker.DrawStyle = DrawStyle.Hue;
        }

        private void rbSaturation_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSaturation.Checked) colorPicker.DrawStyle = DrawStyle.Saturation;
        }

        private void rbBrightness_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBrightness.Checked) colorPicker.DrawStyle = DrawStyle.Brightness;
        }

        private void rbRed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRed.Checked) colorPicker.DrawStyle = DrawStyle.Red;
        }

        private void rbGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGreen.Checked) colorPicker.DrawStyle = DrawStyle.Green;
        }

        private void rbBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBlue.Checked) colorPicker.DrawStyle = DrawStyle.Blue;
        }

        private void lblColorPreview_Click(object sender, EventArgs e)
        {
            if (oldColorExist)
            {
                colorPicker.Color = OldColor;
            }
        }

        private void RGB_ValueChanged(object sender, EventArgs e)
        {
            if (!dialogChanged)
            {
                colorPicker.Color = new RGBA((int)nudRed.Value, (int)nudGreen.Value, (int)nudBlue.Value, (int)nudAlpha.Value).ToColor();
            }
        }

        private void HSB_ValueChanged(object sender, EventArgs e)
        {
            if (!dialogChanged)
            {
                colorPicker.Color = new HSB((int)nudHue.Value, (int)nudSaturation.Value, (int)nudBrightness.Value, (int)nudAlpha.Value).ToColor();
            }
        }

        private void CMYK_ValueChanged(object sender, EventArgs e)
        {
            if (!dialogChanged)
            {
                colorPicker.Color = new CMYK((int)nudCyan.Value, (int)nudMagenta.Value, (int)nudYellow.Value, (int)nudKey.Value, (int)nudAlpha.Value).ToColor();
            }
        }

        private void txtHex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!dialogChanged)
                {
                    colorPicker.Color = ColorHelpers.HexToColor(txtHex.Text);
                }
            }
            catch { }
        }

        private void txtDecimal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!dialogChanged)
                {
                    colorPicker.Color = ColorHelpers.DecimalToColor(Convert.ToInt32(txtDecimal.Text));
                }
            }
            catch { }
        }

        #endregion Events
    }
}