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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HelpersLib;
using ShareX.Properties;

namespace ShareX
{
    public partial class WatermarkUI : Form
    {
        public WatermarkConfig Config { get; set; }

        private ContextMenuStrip codesMenu;

        public WatermarkUI(WatermarkConfig config = null)
        {
            InitializeComponent();

            if (config == null)
            {
                config = new WatermarkConfig();
            }

            Config = config;

            codesMenu = NameParser.CreateCodesMenu(txtWatermarkText, new ReplacementVariables[] { ReplacementVariables.t, ReplacementVariables.host });
        }

        private void WatermarkUI_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName + " - Watermark settings";

            if (cboWatermarkType.Items.Count == 0)
            {
                cboWatermarkType.Items.AddRange(Helpers.GetEnumDescriptions<WatermarkType>());
            }

            cboWatermarkType.SelectedIndex = (int)Config.WatermarkMode;
            if (chkWatermarkPosition.Items.Count == 0)
            {
                chkWatermarkPosition.Items.AddRange(Helpers.GetEnumDescriptions<WatermarkPositionType>());
            }

            chkWatermarkPosition.SelectedIndex = (int)Config.WatermarkPositionMode;
            nudWatermarkOffset.Value = Config.WatermarkOffset;
            cbWatermarkAddReflection.Checked = Config.WatermarkAddReflection;
            cbWatermarkAutoHide.Checked = Config.WatermarkAutoHide;

            txtWatermarkText.Text = Config.WatermarkText;
            pbWatermarkFontColor.BackColor = Config.WatermarkFontArgb;
            lblWatermarkFont.Text = FontToString();
            nudWatermarkFontTrans.Value = Config.WatermarkFontTrans;
            trackWatermarkFontTrans.Value = (int)Config.WatermarkFontTrans;
            nudWatermarkCornerRadius.Value = Config.WatermarkCornerRadius;
            pbWatermarkGradient1.BackColor = Config.WatermarkGradient1Argb;
            pbWatermarkGradient2.BackColor = Config.WatermarkGradient2Argb;
            pbWatermarkBorderColor.BackColor = Config.WatermarkBorderArgb;
            nudWatermarkBackTrans.Value = Config.WatermarkBackTrans;
            trackWatermarkBackgroundTrans.Value = (int)Config.WatermarkBackTrans;
            if (cbWatermarkGradientType.Items.Count == 0)
            {
                cbWatermarkGradientType.Items.AddRange(Enum.GetNames(typeof(LinearGradientMode)));
            }

            cbWatermarkGradientType.SelectedIndex = (int)Config.WatermarkGradientType;
            cboUseCustomGradient.Checked = Config.WatermarkUseCustomGradient;

            txtWatermarkImageLocation.Text = Config.WatermarkImageLocation;
            cbWatermarkUseBorder.Checked = Config.WatermarkUseBorder;
            nudWatermarkImageScale.Value = Config.WatermarkImageScale;

            UpdatePreview();
        }

        private void WatermarkUI_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private string FontToString()
        {
            return FontToString(Config.WatermarkFont, Config.WatermarkFontArgb);
        }

        private string FontToString(Font font, Color color)
        {
            return "Name: " + font.Name + " - Size: " + font.Size + " - Style: " + font.Style + " - Color: " + color.R + "," + color.G + "," + color.B;
        }

        private void SelectColor(Control pb, ref XmlColor color)
        {
            using (DialogColor dColor = new DialogColor(pb.BackColor))
            {
                if (dColor.ShowDialog() == DialogResult.OK)
                {
                    pb.BackColor = dColor.Color;
                    color = dColor.Color;
                }
            }
        }

        private void UpdatePreview()
        {
            Bitmap bmp = CaptureHelpers.ResizeImage(Resources.ShareXLogo, pbWatermarkShow.Width, pbWatermarkShow.Height, false, true);
            pbWatermarkShow.Image = new WatermarkManager(Config).ApplyWatermark(bmp);
        }

        private void btnSelectGradient_Click(object sender, EventArgs e)
        {
            using (var gradient = new GradientMaker(Config.GradientMakerOptions))
            {
                gradient.Icon = Icon;
                if (gradient.ShowDialog() == DialogResult.OK)
                {
                    Config.GradientMakerOptions = gradient.Options;
                    UpdatePreview();
                }
            }
        }

        private void btnWatermarkFont_Click(object sender, EventArgs e)
        {
            DialogResult result = WatermarkManager.ShowFontDialog(Config);

            if (result == DialogResult.OK)
            {
                pbWatermarkFontColor.BackColor = Config.WatermarkFontArgb;
                lblWatermarkFont.Text = FontToString();
                UpdatePreview();
            }
        }

        private void btwWatermarkBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog { InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtWatermarkImageLocation.Text = fd.FileName;
            }
        }

        private void cboWatermarkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.WatermarkMode = (WatermarkType)cboWatermarkType.SelectedIndex;
            UpdatePreview();
        }

        private void cbUseCustomGradient_CheckedChanged(object sender, EventArgs e)
        {
            Config.WatermarkUseCustomGradient = cboUseCustomGradient.Checked;
            gbGradientMakerBasic.Enabled = !cboUseCustomGradient.Checked;
            UpdatePreview();
        }

        private void cbWatermarkAddReflection_CheckedChanged(object sender, EventArgs e)
        {
            Config.WatermarkAddReflection = cbWatermarkAddReflection.Checked;
            UpdatePreview();
        }

        private void cbWatermarkAutoHide_CheckedChanged(object sender, EventArgs e)
        {
            Config.WatermarkAutoHide = cbWatermarkAutoHide.Checked;
            UpdatePreview();
        }

        private void cbWatermarkGradientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.WatermarkGradientType = (LinearGradientMode)cbWatermarkGradientType.SelectedIndex;
            UpdatePreview();
        }

        private void cbWatermarkPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.WatermarkPositionMode = (WatermarkPositionType)chkWatermarkPosition.SelectedIndex;
            UpdatePreview();
        }

        private void cbWatermarkUseBorder_CheckedChanged(object sender, EventArgs e)
        {
            Config.WatermarkUseBorder = cbWatermarkUseBorder.Checked;
            UpdatePreview();
        }

        private void nudWatermarkBackTrans_ValueChanged(object sender, EventArgs e)
        {
            Config.WatermarkBackTrans = (int)nudWatermarkBackTrans.Value;
            trackWatermarkBackgroundTrans.Value = (int)nudWatermarkBackTrans.Value;
        }

        private void nudWatermarkCornerRadius_ValueChanged(object sender, EventArgs e)
        {
            Config.WatermarkCornerRadius = (int)nudWatermarkCornerRadius.Value;
            UpdatePreview();
        }

        private void nudWatermarkFontTrans_ValueChanged(object sender, EventArgs e)
        {
            Config.WatermarkFontTrans = (int)nudWatermarkFontTrans.Value;
            trackWatermarkFontTrans.Value = (int)nudWatermarkFontTrans.Value;
        }

        private void nudWatermarkImageScale_ValueChanged(object sender, EventArgs e)
        {
            Config.WatermarkImageScale = (int)nudWatermarkImageScale.Value;
            UpdatePreview();
        }

        private void nudWatermarkOffset_ValueChanged(object sender, EventArgs e)
        {
            Config.WatermarkOffset = (int)nudWatermarkOffset.Value;
            UpdatePreview();
        }

        private void pbWatermarkBorderColor_Click(object sender, EventArgs e)
        {
            SelectColor((PictureBox)sender, ref Config.WatermarkBorderArgb);
            UpdatePreview();
        }

        private void pbWatermarkFontColor_Click(object sender, EventArgs e)
        {
            SelectColor((PictureBox)sender, ref Config.WatermarkFontArgb);
            lblWatermarkFont.Text = FontToString();
            UpdatePreview();
        }

        private void pbWatermarkGradient1_Click(object sender, EventArgs e)
        {
            SelectColor((PictureBox)sender, ref Config.WatermarkGradient1Argb);
            UpdatePreview();
        }

        private void pbWatermarkGradient2_Click(object sender, EventArgs e)
        {
            SelectColor((PictureBox)sender, ref Config.WatermarkGradient2Argb);
            UpdatePreview();
        }

        private void trackWatermarkBackgroundTrans_Scroll(object sender, EventArgs e)
        {
            Config.WatermarkBackTrans = trackWatermarkBackgroundTrans.Value;
            nudWatermarkBackTrans.Value = Config.WatermarkBackTrans;
            UpdatePreview();
        }

        private void trackWatermarkFontTrans_Scroll(object sender, EventArgs e)
        {
            Config.WatermarkFontTrans = trackWatermarkFontTrans.Value;
            nudWatermarkFontTrans.Value = Config.WatermarkFontTrans;
            UpdatePreview();
        }

        private void txtWatermarkImageLocation_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(txtWatermarkImageLocation.Text))
            {
                Config.WatermarkImageLocation = txtWatermarkImageLocation.Text;
                UpdatePreview();
            }
        }

        private void txtWatermarkText_TextChanged(object sender, EventArgs e)
        {
            Config.WatermarkText = txtWatermarkText.Text;
            UpdatePreview();
        }
    }
}