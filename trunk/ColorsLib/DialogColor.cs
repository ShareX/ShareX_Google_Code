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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using HelpersLib;

namespace ColorsLib
{
    public partial class DialogColor : Form
    {
        public Color Color;
        private MyColor NewColor = Color.Red;
        private MyColor OldColor;
        public bool ScreenPicker;
        private bool oldColorExist;
        private bool dialogChanged;

        public DialogColor()
        {
            Initialize(Color.Empty);
        }

        public DialogColor(Color currentColor)
        {
            Initialize(currentColor);
        }

        private void Initialize(Color currentColor)
        {
            InitializeComponent();

            foreach (Control cntrl in this.Controls)
            {
                if (cntrl is NumericUpDown || cntrl is TextBox)
                {
                    cntrl.DoubleClick += new EventHandler(CopyToClipboard);
                }
            }

            if (currentColor.IsEmpty)
            {
                colorPicker.DrawCrosshair = lblOld.Visible = oldColorExist;
                DrawColors();
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
            DrawColors();
        }

        private void UpdateControls(MyColor color)
        {
            DrawColors();
            dialogChanged = true;
            nudHue.Value = (decimal)Math.Round(color.HSB.Hue360);
            nudSaturation.Value = (decimal)Math.Round(color.HSB.Saturation100);
            nudBrightness.Value = (decimal)Math.Round(color.HSB.Brightness100);
            nudRed.Value = color.RGB.Red;
            nudGreen.Value = color.RGB.Green;
            nudBlue.Value = color.RGB.Blue;
            nudCyan.Value = (decimal)Math.Round(color.CMYK.Cyan100);
            nudMagenta.Value = (decimal)Math.Round(color.CMYK.Magenta100);
            nudYellow.Value = (decimal)Math.Round(color.CMYK.Yellow100);
            nudKey.Value = (decimal)Math.Round(color.CMYK.Key100);
            txtHex.Text = MyColors.ColorToHex(color);
            txtDecimal.Text = MyColors.ColorToDecimal(color).ToString();
            dialogChanged = false;
        }

        private void DrawColors()
        {
            Bitmap bmp = new Bitmap(lblColorPreview.ClientSize.Width, lblColorPreview.ClientSize.Height);
            Graphics g = Graphics.FromImage(bmp);
            int bmpHeight = bmp.Height;
            if (oldColorExist) bmpHeight /= 2;
            g.FillRectangle(new SolidBrush(NewColor), new Rectangle(0, 0, bmp.Width, bmpHeight));
            if (oldColorExist) g.FillRectangle(new SolidBrush(OldColor),
                new Rectangle(0, bmpHeight, bmp.Width, bmpHeight));
            lblColorPreview.Image = bmp;
        }

        #region Events

        private void DialogColor_Load(object sender, EventArgs e)
        {
            if (ScreenPicker)
            {
                this.Location = new Point(10, 10);
                colorPicker.DrawCrosshair = true;
                colorTimer.Start();
            }
            else
            {
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - (this.Width / 2),
                                Screen.PrimaryScreen.Bounds.Height / 2 - (this.Height / 2));
            }
        }

        private void CopyToClipboard(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                Clipboard.SetText(((NumericUpDown)sender).Value.ToString()); // ok
            }
            else if (sender is TextBox)
            {
                Clipboard.SetText(((TextBox)sender).Text); // ok
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
                colorTimer.Enabled = !colorTimer.Enabled;
            }
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            colorTimer.Enabled = !colorTimer.Enabled;
        }

        private void colorTimer_Tick(object sender, EventArgs e)
        {
            Point pos = MousePosition;
            colorPicker.Color = Helpers.GetPixelColor(pos);
            txtX.Text = pos.X.ToString();
            txtY.Text = pos.Y.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Color = Color.FromArgb((int)nudRed.Value, (int)nudGreen.Value, (int)nudBlue.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        private void DialogColor_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Press \"Control\" button for start or stop screen color picker.\r\nIf you double " +
                "click on any of TextBox or NumericUpDown controls value or text will be copied to clipboard automatically.",
                "Color Dialog");
            e.Cancel = true;
        }

        private void RGB_ValueChanged(object sender, EventArgs e)
        {
            if (!dialogChanged)
            {
                colorPicker.Color = new RGB((int)nudRed.Value, (int)nudGreen.Value, (int)nudBlue.Value).ToColor();
            }
        }

        private void HSB_ValueChanged(object sender, EventArgs e)
        {
            if (!dialogChanged)
            {
                colorPicker.Color = new HSB((int)nudHue.Value, (int)nudSaturation.Value, (int)nudBrightness.Value).ToColor();
            }
        }

        private void CMYK_ValueChanged(object sender, EventArgs e)
        {
            if (!dialogChanged)
            {
                colorPicker.Color = new CMYK((int)nudCyan.Value, (int)nudMagenta.Value, (int)nudYellow.Value,
                    (int)nudKey.Value).ToColor();
            }
        }

        private void txtHex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!dialogChanged)
                {
                    colorPicker.Color = MyColors.HexToColor(txtHex.Text);
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
                    colorPicker.Color = MyColors.DecimalToColor(Convert.ToInt32(txtDecimal.Text));
                }
            }
            catch { }
        }

        #endregion Events
    }
}