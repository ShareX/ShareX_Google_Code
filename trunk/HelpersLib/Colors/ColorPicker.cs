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

using System.ComponentModel;
using System.Windows.Forms;

namespace HelpersLib
{
    [DefaultEvent("ColorChanged")]
    public class ColorPicker : UserControl
    {
        #region Variables

        public event ColorEventHandler ColorChanged;

        public MyColor Color
        {
            get
            {
                return mColor;
            }
            set
            {
                if (mColor != value)
                {
                    mColor = value;
                    colorBox.SelectedColor = value;
                    colorSlider.SelectedColor = value;
                }
            }
        }

        public MyColor ColorBox
        {
            get { return mColorBox; }
            private set
            {
                mColorBox = value;
                mColor = value;
            }
        }

        public MyColor ColorSlider
        {
            get { return mColorSlider; }
            private set
            {
                mColorSlider = value;
                mColor = value;
            }
        }

        public DrawStyle DrawStyle
        {
            get
            { return mDrawStyle; }
            set
            {
                colorBox.DrawStyle = value;
                colorSlider.DrawStyle = value;
                mDrawStyle = value;
            }
        }

        public bool DrawCrosshair
        {
            set
            {
                colorBox.drawCrosshair = value;
                colorSlider.drawCrosshair = value;
            }
        }

        private ColorBox colorBox;
        private ColorSlider colorSlider;

        private MyColor mColor;
        private MyColor mColorBox;
        private MyColor mColorSlider;
        private DrawStyle mDrawStyle;

        #endregion Variables

        public ColorPicker()
        {
            InitializeComponent();
            DrawStyle = DrawStyle.Hue;
            colorBox.ColorChanged += colorBox_ColorChanged;
            colorSlider.ColorChanged += colorSlider_ColorChanged;
        }

        private void colorBox_ColorChanged(object sender, ColorEventArgs e)
        {
            ColorBox = e.Color;
            if (e.UpdateControl) colorSlider.SelectedColor = ColorBox;
            ThrowEvent();
        }

        private void colorSlider_ColorChanged(object sender, ColorEventArgs e)
        {
            ColorSlider = e.Color;
            if (e.UpdateControl) colorBox.SelectedColor = ColorSlider;
            ThrowEvent();
        }

        private void ThrowEvent()
        {
            if (ColorChanged != null)
            {
                ColorChanged(this, new ColorEventArgs(Color, DrawStyle));
            }
        }

        #region Component Designer generated code

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.colorBox = new HelpersLib.ColorBox();
            this.colorSlider = new HelpersLib.ColorSlider();

            // colorBox
            this.colorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorBox.DrawStyle = HelpersLib.DrawStyle.Hue;
            this.colorBox.Location = new System.Drawing.Point(0, 0);
            this.colorBox.Name = "colorBox";
            this.colorBox.TabIndex = 0;

            // colorSlider
            this.colorSlider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSlider.DrawStyle = HelpersLib.DrawStyle.Hue;
            this.colorSlider.Location = new System.Drawing.Point(colorBox.Width, 0);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.TabIndex = 1;

            // ColorPicker
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.colorSlider);
            this.AutoSize = true;
            this.Name = "ColorPicker";
            this.Size = new System.Drawing.Size(colorBox.Width + colorSlider.Width, colorBox.Height);

            this.ResumeLayout(false);
        }

        #endregion Component Designer generated code
    }
}