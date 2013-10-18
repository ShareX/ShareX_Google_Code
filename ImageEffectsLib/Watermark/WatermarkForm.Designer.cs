namespace ImageEffectsLib
{
    partial class WatermarkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbWatermarkGeneral = new System.Windows.Forms.GroupBox();
            this.lblWatermarkOffsetPixel = new System.Windows.Forms.Label();
            this.cboWatermarkType = new System.Windows.Forms.ComboBox();
            this.cbWatermarkAutoHide = new System.Windows.Forms.CheckBox();
            this.cbWatermarkAddReflection = new System.Windows.Forms.CheckBox();
            this.lblWatermarkType = new System.Windows.Forms.Label();
            this.chkWatermarkPosition = new System.Windows.Forms.ComboBox();
            this.lblWatermarkPosition = new System.Windows.Forms.Label();
            this.nudWatermarkOffset = new System.Windows.Forms.NumericUpDown();
            this.lblWatermarkOffset = new System.Windows.Forms.Label();
            this.tcWatermark = new System.Windows.Forms.TabControl();
            this.tpWatermarkText = new System.Windows.Forms.TabPage();
            this.gbWatermarkBackground = new System.Windows.Forms.GroupBox();
            this.lblRectangleCornerRadius = new System.Windows.Forms.Label();
            this.lblWatermarkBackColors = new System.Windows.Forms.Label();
            this.pbWatermarkGradient2 = new System.Windows.Forms.PictureBox();
            this.cbWatermarkGradientType = new System.Windows.Forms.ComboBox();
            this.pbWatermarkBorderColor = new System.Windows.Forms.PictureBox();
            this.lblWatermarkGradientType = new System.Windows.Forms.Label();
            this.pbWatermarkGradient1 = new System.Windows.Forms.PictureBox();
            this.btnSelectGradient = new System.Windows.Forms.Button();
            this.cboUseCustomGradient = new System.Windows.Forms.CheckBox();
            this.nudWatermarkCornerRadius = new System.Windows.Forms.NumericUpDown();
            this.lblWatermarkCornerRadiusTip = new System.Windows.Forms.Label();
            this.gbWatermarkText = new System.Windows.Forms.GroupBox();
            this.lblWatermarkText = new System.Windows.Forms.Label();
            this.lblWatermarkFont = new System.Windows.Forms.Label();
            this.btnWatermarkFont = new System.Windows.Forms.Button();
            this.txtWatermarkText = new System.Windows.Forms.TextBox();
            this.pbWatermarkFontColor = new System.Windows.Forms.PictureBox();
            this.tpWatermarkImage = new System.Windows.Forms.TabPage();
            this.lblWatermarkImageScale = new System.Windows.Forms.Label();
            this.nudWatermarkImageScale = new System.Windows.Forms.NumericUpDown();
            this.cbWatermarkUseBorder = new System.Windows.Forms.CheckBox();
            this.btwWatermarkBrowseImage = new System.Windows.Forms.Button();
            this.txtWatermarkImageLocation = new System.Windows.Forms.TextBox();
            this.lblWatermarkBackColors2 = new System.Windows.Forms.Label();
            this.lblWatermarkBorderColor = new System.Windows.Forms.Label();
            this.pbPreview = new HelpersLib.MyPictureBox();
            this.gbWatermarkGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWatermarkOffset)).BeginInit();
            this.tcWatermark.SuspendLayout();
            this.tpWatermarkText.SuspendLayout();
            this.gbWatermarkBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermarkGradient2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermarkBorderColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermarkGradient1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWatermarkCornerRadius)).BeginInit();
            this.gbWatermarkText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermarkFontColor)).BeginInit();
            this.tpWatermarkImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWatermarkImageScale)).BeginInit();
            this.SuspendLayout();
            // 
            // gbWatermarkGeneral
            // 
            this.gbWatermarkGeneral.Controls.Add(this.lblWatermarkOffsetPixel);
            this.gbWatermarkGeneral.Controls.Add(this.cboWatermarkType);
            this.gbWatermarkGeneral.Controls.Add(this.cbWatermarkAutoHide);
            this.gbWatermarkGeneral.Controls.Add(this.cbWatermarkAddReflection);
            this.gbWatermarkGeneral.Controls.Add(this.lblWatermarkType);
            this.gbWatermarkGeneral.Controls.Add(this.chkWatermarkPosition);
            this.gbWatermarkGeneral.Controls.Add(this.lblWatermarkPosition);
            this.gbWatermarkGeneral.Controls.Add(this.nudWatermarkOffset);
            this.gbWatermarkGeneral.Controls.Add(this.lblWatermarkOffset);
            this.gbWatermarkGeneral.Location = new System.Drawing.Point(8, 8);
            this.gbWatermarkGeneral.Name = "gbWatermarkGeneral";
            this.gbWatermarkGeneral.Size = new System.Drawing.Size(288, 160);
            this.gbWatermarkGeneral.TabIndex = 0;
            this.gbWatermarkGeneral.TabStop = false;
            this.gbWatermarkGeneral.Text = "Watermark Settings";
            // 
            // lblWatermarkOffsetPixel
            // 
            this.lblWatermarkOffsetPixel.AutoSize = true;
            this.lblWatermarkOffsetPixel.Location = new System.Drawing.Point(152, 88);
            this.lblWatermarkOffsetPixel.Name = "lblWatermarkOffsetPixel";
            this.lblWatermarkOffsetPixel.Size = new System.Drawing.Size(18, 13);
            this.lblWatermarkOffsetPixel.TabIndex = 6;
            this.lblWatermarkOffsetPixel.Text = "px";
            // 
            // cboWatermarkType
            // 
            this.cboWatermarkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWatermarkType.FormattingEnabled = true;
            this.cboWatermarkType.Location = new System.Drawing.Point(88, 20);
            this.cboWatermarkType.Name = "cboWatermarkType";
            this.cboWatermarkType.Size = new System.Drawing.Size(120, 21);
            this.cboWatermarkType.TabIndex = 1;
            this.cboWatermarkType.SelectedIndexChanged += new System.EventHandler(this.cboWatermarkType_SelectedIndexChanged);
            // 
            // cbWatermarkAutoHide
            // 
            this.cbWatermarkAutoHide.AutoSize = true;
            this.cbWatermarkAutoHide.Location = new System.Drawing.Point(16, 136);
            this.cbWatermarkAutoHide.Name = "cbWatermarkAutoHide";
            this.cbWatermarkAutoHide.Size = new System.Drawing.Size(260, 17);
            this.cbWatermarkAutoHide.TabIndex = 8;
            this.cbWatermarkAutoHide.Text = "Hide watermark if image is smaller than watermark";
            this.cbWatermarkAutoHide.UseVisualStyleBackColor = true;
            this.cbWatermarkAutoHide.CheckedChanged += new System.EventHandler(this.cbWatermarkAutoHide_CheckedChanged);
            // 
            // cbWatermarkAddReflection
            // 
            this.cbWatermarkAddReflection.AutoSize = true;
            this.cbWatermarkAddReflection.Location = new System.Drawing.Point(16, 112);
            this.cbWatermarkAddReflection.Name = "cbWatermarkAddReflection";
            this.cbWatermarkAddReflection.Size = new System.Drawing.Size(121, 17);
            this.cbWatermarkAddReflection.TabIndex = 7;
            this.cbWatermarkAddReflection.Text = "Add reflection effect";
            this.cbWatermarkAddReflection.UseVisualStyleBackColor = true;
            this.cbWatermarkAddReflection.CheckedChanged += new System.EventHandler(this.cbWatermarkAddReflection_CheckedChanged);
            // 
            // lblWatermarkType
            // 
            this.lblWatermarkType.AutoSize = true;
            this.lblWatermarkType.Location = new System.Drawing.Point(16, 24);
            this.lblWatermarkType.Name = "lblWatermarkType";
            this.lblWatermarkType.Size = new System.Drawing.Size(34, 13);
            this.lblWatermarkType.TabIndex = 0;
            this.lblWatermarkType.Text = "Type:";
            // 
            // chkWatermarkPosition
            // 
            this.chkWatermarkPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chkWatermarkPosition.FormattingEnabled = true;
            this.chkWatermarkPosition.Location = new System.Drawing.Point(88, 52);
            this.chkWatermarkPosition.Name = "chkWatermarkPosition";
            this.chkWatermarkPosition.Size = new System.Drawing.Size(121, 21);
            this.chkWatermarkPosition.TabIndex = 3;
            this.chkWatermarkPosition.SelectedIndexChanged += new System.EventHandler(this.cbWatermarkPosition_SelectedIndexChanged);
            // 
            // lblWatermarkPosition
            // 
            this.lblWatermarkPosition.AutoSize = true;
            this.lblWatermarkPosition.Location = new System.Drawing.Point(16, 56);
            this.lblWatermarkPosition.Name = "lblWatermarkPosition";
            this.lblWatermarkPosition.Size = new System.Drawing.Size(60, 13);
            this.lblWatermarkPosition.TabIndex = 2;
            this.lblWatermarkPosition.Text = "Placement:";
            // 
            // nudWatermarkOffset
            // 
            this.nudWatermarkOffset.Location = new System.Drawing.Point(88, 84);
            this.nudWatermarkOffset.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudWatermarkOffset.Name = "nudWatermarkOffset";
            this.nudWatermarkOffset.Size = new System.Drawing.Size(56, 20);
            this.nudWatermarkOffset.TabIndex = 5;
            this.nudWatermarkOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudWatermarkOffset.ValueChanged += new System.EventHandler(this.nudWatermarkOffset_ValueChanged);
            // 
            // lblWatermarkOffset
            // 
            this.lblWatermarkOffset.AutoSize = true;
            this.lblWatermarkOffset.Location = new System.Drawing.Point(16, 88);
            this.lblWatermarkOffset.Name = "lblWatermarkOffset";
            this.lblWatermarkOffset.Size = new System.Drawing.Size(38, 13);
            this.lblWatermarkOffset.TabIndex = 4;
            this.lblWatermarkOffset.Text = "Offset:";
            // 
            // tcWatermark
            // 
            this.tcWatermark.Controls.Add(this.tpWatermarkText);
            this.tcWatermark.Controls.Add(this.tpWatermarkImage);
            this.tcWatermark.Location = new System.Drawing.Point(304, 8);
            this.tcWatermark.Name = "tcWatermark";
            this.tcWatermark.SelectedIndex = 0;
            this.tcWatermark.Size = new System.Drawing.Size(480, 408);
            this.tcWatermark.TabIndex = 1;
            // 
            // tpWatermarkText
            // 
            this.tpWatermarkText.Controls.Add(this.gbWatermarkBackground);
            this.tpWatermarkText.Controls.Add(this.gbWatermarkText);
            this.tpWatermarkText.ImageKey = "textfield_rename.png";
            this.tpWatermarkText.Location = new System.Drawing.Point(4, 22);
            this.tpWatermarkText.Name = "tpWatermarkText";
            this.tpWatermarkText.Padding = new System.Windows.Forms.Padding(3);
            this.tpWatermarkText.Size = new System.Drawing.Size(472, 382);
            this.tpWatermarkText.TabIndex = 0;
            this.tpWatermarkText.Text = "Text";
            this.tpWatermarkText.UseVisualStyleBackColor = true;
            // 
            // gbWatermarkBackground
            // 
            this.gbWatermarkBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWatermarkBackground.Controls.Add(this.lblWatermarkBorderColor);
            this.gbWatermarkBackground.Controls.Add(this.lblRectangleCornerRadius);
            this.gbWatermarkBackground.Controls.Add(this.btnSelectGradient);
            this.gbWatermarkBackground.Controls.Add(this.lblWatermarkBackColors2);
            this.gbWatermarkBackground.Controls.Add(this.cboUseCustomGradient);
            this.gbWatermarkBackground.Controls.Add(this.nudWatermarkCornerRadius);
            this.gbWatermarkBackground.Controls.Add(this.lblWatermarkBackColors);
            this.gbWatermarkBackground.Controls.Add(this.pbWatermarkGradient2);
            this.gbWatermarkBackground.Controls.Add(this.lblWatermarkCornerRadiusTip);
            this.gbWatermarkBackground.Controls.Add(this.pbWatermarkGradient1);
            this.gbWatermarkBackground.Controls.Add(this.pbWatermarkBorderColor);
            this.gbWatermarkBackground.Controls.Add(this.cbWatermarkGradientType);
            this.gbWatermarkBackground.Controls.Add(this.lblWatermarkGradientType);
            this.gbWatermarkBackground.Location = new System.Drawing.Point(8, 96);
            this.gbWatermarkBackground.Name = "gbWatermarkBackground";
            this.gbWatermarkBackground.Size = new System.Drawing.Size(450, 176);
            this.gbWatermarkBackground.TabIndex = 1;
            this.gbWatermarkBackground.TabStop = false;
            this.gbWatermarkBackground.Text = "Background settings";
            // 
            // lblRectangleCornerRadius
            // 
            this.lblRectangleCornerRadius.AutoSize = true;
            this.lblRectangleCornerRadius.Location = new System.Drawing.Point(16, 24);
            this.lblRectangleCornerRadius.Name = "lblRectangleCornerRadius";
            this.lblRectangleCornerRadius.Size = new System.Drawing.Size(123, 13);
            this.lblRectangleCornerRadius.TabIndex = 0;
            this.lblRectangleCornerRadius.Text = "Rectangle corner radius:";
            // 
            // lblWatermarkBackColors
            // 
            this.lblWatermarkBackColors.AutoSize = true;
            this.lblWatermarkBackColors.Location = new System.Drawing.Point(16, 56);
            this.lblWatermarkBackColors.Name = "lblWatermarkBackColors";
            this.lblWatermarkBackColors.Size = new System.Drawing.Size(94, 13);
            this.lblWatermarkBackColors.TabIndex = 0;
            this.lblWatermarkBackColors.Text = "Background color:";
            // 
            // pbWatermarkGradient2
            // 
            this.pbWatermarkGradient2.BackColor = System.Drawing.Color.Gray;
            this.pbWatermarkGradient2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbWatermarkGradient2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbWatermarkGradient2.Location = new System.Drawing.Point(264, 50);
            this.pbWatermarkGradient2.Name = "pbWatermarkGradient2";
            this.pbWatermarkGradient2.Size = new System.Drawing.Size(24, 24);
            this.pbWatermarkGradient2.TabIndex = 11;
            this.pbWatermarkGradient2.TabStop = false;
            this.pbWatermarkGradient2.Click += new System.EventHandler(this.pbWatermarkGradient2_Click);
            // 
            // cbWatermarkGradientType
            // 
            this.cbWatermarkGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWatermarkGradientType.FormattingEnabled = true;
            this.cbWatermarkGradientType.Location = new System.Drawing.Point(120, 84);
            this.cbWatermarkGradientType.Name = "cbWatermarkGradientType";
            this.cbWatermarkGradientType.Size = new System.Drawing.Size(121, 21);
            this.cbWatermarkGradientType.TabIndex = 6;
            this.cbWatermarkGradientType.SelectedIndexChanged += new System.EventHandler(this.cbWatermarkGradientType_SelectedIndexChanged);
            // 
            // pbWatermarkBorderColor
            // 
            this.pbWatermarkBorderColor.BackColor = System.Drawing.Color.Black;
            this.pbWatermarkBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbWatermarkBorderColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbWatermarkBorderColor.Location = new System.Drawing.Point(120, 114);
            this.pbWatermarkBorderColor.Name = "pbWatermarkBorderColor";
            this.pbWatermarkBorderColor.Size = new System.Drawing.Size(24, 24);
            this.pbWatermarkBorderColor.TabIndex = 14;
            this.pbWatermarkBorderColor.TabStop = false;
            this.pbWatermarkBorderColor.Click += new System.EventHandler(this.pbWatermarkBorderColor_Click);
            // 
            // lblWatermarkGradientType
            // 
            this.lblWatermarkGradientType.AutoSize = true;
            this.lblWatermarkGradientType.Location = new System.Drawing.Point(16, 88);
            this.lblWatermarkGradientType.Name = "lblWatermarkGradientType";
            this.lblWatermarkGradientType.Size = new System.Drawing.Size(73, 13);
            this.lblWatermarkGradientType.TabIndex = 5;
            this.lblWatermarkGradientType.Text = "Gradient type:";
            // 
            // pbWatermarkGradient1
            // 
            this.pbWatermarkGradient1.BackColor = System.Drawing.Color.White;
            this.pbWatermarkGradient1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbWatermarkGradient1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbWatermarkGradient1.Location = new System.Drawing.Point(120, 50);
            this.pbWatermarkGradient1.Name = "pbWatermarkGradient1";
            this.pbWatermarkGradient1.Size = new System.Drawing.Size(24, 24);
            this.pbWatermarkGradient1.TabIndex = 10;
            this.pbWatermarkGradient1.TabStop = false;
            this.pbWatermarkGradient1.Click += new System.EventHandler(this.pbWatermarkGradient1_Click);
            // 
            // btnSelectGradient
            // 
            this.btnSelectGradient.Location = new System.Drawing.Point(200, 141);
            this.btnSelectGradient.Name = "btnSelectGradient";
            this.btnSelectGradient.Size = new System.Drawing.Size(112, 23);
            this.btnSelectGradient.TabIndex = 5;
            this.btnSelectGradient.Text = "Gradient maker...";
            this.btnSelectGradient.UseVisualStyleBackColor = true;
            this.btnSelectGradient.Click += new System.EventHandler(this.btnSelectGradient_Click);
            // 
            // cboUseCustomGradient
            // 
            this.cboUseCustomGradient.AutoSize = true;
            this.cboUseCustomGradient.Location = new System.Drawing.Point(16, 144);
            this.cboUseCustomGradient.Name = "cboUseCustomGradient";
            this.cboUseCustomGradient.Size = new System.Drawing.Size(179, 17);
            this.cboUseCustomGradient.TabIndex = 4;
            this.cboUseCustomGradient.Text = "Use gradient maker (Advanced):";
            this.cboUseCustomGradient.UseVisualStyleBackColor = true;
            this.cboUseCustomGradient.CheckedChanged += new System.EventHandler(this.cbUseCustomGradient_CheckedChanged);
            // 
            // nudWatermarkCornerRadius
            // 
            this.nudWatermarkCornerRadius.Location = new System.Drawing.Point(148, 20);
            this.nudWatermarkCornerRadius.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudWatermarkCornerRadius.Name = "nudWatermarkCornerRadius";
            this.nudWatermarkCornerRadius.Size = new System.Drawing.Size(48, 20);
            this.nudWatermarkCornerRadius.TabIndex = 1;
            this.nudWatermarkCornerRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudWatermarkCornerRadius.ValueChanged += new System.EventHandler(this.nudWatermarkCornerRadius_ValueChanged);
            // 
            // lblWatermarkCornerRadiusTip
            // 
            this.lblWatermarkCornerRadiusTip.AutoSize = true;
            this.lblWatermarkCornerRadiusTip.Location = new System.Drawing.Point(204, 24);
            this.lblWatermarkCornerRadiusTip.Name = "lblWatermarkCornerRadiusTip";
            this.lblWatermarkCornerRadiusTip.Size = new System.Drawing.Size(146, 13);
            this.lblWatermarkCornerRadiusTip.TabIndex = 2;
            this.lblWatermarkCornerRadiusTip.Text = "(0 - 15) 0 = Normal Rectangle";
            // 
            // gbWatermarkText
            // 
            this.gbWatermarkText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWatermarkText.Controls.Add(this.lblWatermarkText);
            this.gbWatermarkText.Controls.Add(this.lblWatermarkFont);
            this.gbWatermarkText.Controls.Add(this.btnWatermarkFont);
            this.gbWatermarkText.Controls.Add(this.txtWatermarkText);
            this.gbWatermarkText.Controls.Add(this.pbWatermarkFontColor);
            this.gbWatermarkText.Location = new System.Drawing.Point(8, 8);
            this.gbWatermarkText.Name = "gbWatermarkText";
            this.gbWatermarkText.Size = new System.Drawing.Size(450, 80);
            this.gbWatermarkText.TabIndex = 0;
            this.gbWatermarkText.TabStop = false;
            this.gbWatermarkText.Text = "Text settings";
            // 
            // lblWatermarkText
            // 
            this.lblWatermarkText.AutoSize = true;
            this.lblWatermarkText.Location = new System.Drawing.Point(8, 24);
            this.lblWatermarkText.Name = "lblWatermarkText";
            this.lblWatermarkText.Size = new System.Drawing.Size(82, 13);
            this.lblWatermarkText.TabIndex = 0;
            this.lblWatermarkText.Text = "Watermark text:";
            // 
            // lblWatermarkFont
            // 
            this.lblWatermarkFont.AutoSize = true;
            this.lblWatermarkFont.Location = new System.Drawing.Point(152, 54);
            this.lblWatermarkFont.Name = "lblWatermarkFont";
            this.lblWatermarkFont.Size = new System.Drawing.Size(83, 13);
            this.lblWatermarkFont.TabIndex = 3;
            this.lblWatermarkFont.Text = "Font Information";
            // 
            // btnWatermarkFont
            // 
            this.btnWatermarkFont.Location = new System.Drawing.Point(8, 48);
            this.btnWatermarkFont.Name = "btnWatermarkFont";
            this.btnWatermarkFont.Size = new System.Drawing.Size(104, 24);
            this.btnWatermarkFont.TabIndex = 2;
            this.btnWatermarkFont.Text = "Change font...";
            this.btnWatermarkFont.UseVisualStyleBackColor = true;
            this.btnWatermarkFont.Click += new System.EventHandler(this.btnWatermarkFont_Click);
            // 
            // txtWatermarkText
            // 
            this.txtWatermarkText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWatermarkText.Location = new System.Drawing.Point(120, 20);
            this.txtWatermarkText.Name = "txtWatermarkText";
            this.txtWatermarkText.Size = new System.Drawing.Size(320, 20);
            this.txtWatermarkText.TabIndex = 1;
            this.txtWatermarkText.TextChanged += new System.EventHandler(this.txtWatermarkText_TextChanged);
            // 
            // pbWatermarkFontColor
            // 
            this.pbWatermarkFontColor.BackColor = System.Drawing.Color.Black;
            this.pbWatermarkFontColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbWatermarkFontColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbWatermarkFontColor.Location = new System.Drawing.Point(120, 48);
            this.pbWatermarkFontColor.Name = "pbWatermarkFontColor";
            this.pbWatermarkFontColor.Size = new System.Drawing.Size(24, 24);
            this.pbWatermarkFontColor.TabIndex = 17;
            this.pbWatermarkFontColor.TabStop = false;
            this.pbWatermarkFontColor.Click += new System.EventHandler(this.pbWatermarkFontColor_Click);
            // 
            // tpWatermarkImage
            // 
            this.tpWatermarkImage.Controls.Add(this.lblWatermarkImageScale);
            this.tpWatermarkImage.Controls.Add(this.nudWatermarkImageScale);
            this.tpWatermarkImage.Controls.Add(this.cbWatermarkUseBorder);
            this.tpWatermarkImage.Controls.Add(this.btwWatermarkBrowseImage);
            this.tpWatermarkImage.Controls.Add(this.txtWatermarkImageLocation);
            this.tpWatermarkImage.ImageKey = "image_edit.png";
            this.tpWatermarkImage.Location = new System.Drawing.Point(4, 22);
            this.tpWatermarkImage.Name = "tpWatermarkImage";
            this.tpWatermarkImage.Padding = new System.Windows.Forms.Padding(3);
            this.tpWatermarkImage.Size = new System.Drawing.Size(472, 382);
            this.tpWatermarkImage.TabIndex = 1;
            this.tpWatermarkImage.Text = "Image";
            this.tpWatermarkImage.UseVisualStyleBackColor = true;
            // 
            // lblWatermarkImageScale
            // 
            this.lblWatermarkImageScale.AutoSize = true;
            this.lblWatermarkImageScale.Location = new System.Drawing.Point(16, 76);
            this.lblWatermarkImageScale.Name = "lblWatermarkImageScale";
            this.lblWatermarkImageScale.Size = new System.Drawing.Size(117, 13);
            this.lblWatermarkImageScale.TabIndex = 3;
            this.lblWatermarkImageScale.Text = "Image size percentage:";
            // 
            // nudWatermarkImageScale
            // 
            this.nudWatermarkImageScale.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudWatermarkImageScale.Location = new System.Drawing.Point(136, 72);
            this.nudWatermarkImageScale.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudWatermarkImageScale.Name = "nudWatermarkImageScale";
            this.nudWatermarkImageScale.Size = new System.Drawing.Size(56, 20);
            this.nudWatermarkImageScale.TabIndex = 4;
            this.nudWatermarkImageScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudWatermarkImageScale.ValueChanged += new System.EventHandler(this.nudWatermarkImageScale_ValueChanged);
            // 
            // cbWatermarkUseBorder
            // 
            this.cbWatermarkUseBorder.AutoSize = true;
            this.cbWatermarkUseBorder.Location = new System.Drawing.Point(16, 48);
            this.cbWatermarkUseBorder.Name = "cbWatermarkUseBorder";
            this.cbWatermarkUseBorder.Size = new System.Drawing.Size(78, 17);
            this.cbWatermarkUseBorder.TabIndex = 2;
            this.cbWatermarkUseBorder.Text = "Add border";
            this.cbWatermarkUseBorder.UseVisualStyleBackColor = true;
            this.cbWatermarkUseBorder.CheckedChanged += new System.EventHandler(this.cbWatermarkUseBorder_CheckedChanged);
            // 
            // btwWatermarkBrowseImage
            // 
            this.btwWatermarkBrowseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btwWatermarkBrowseImage.Location = new System.Drawing.Point(392, 13);
            this.btwWatermarkBrowseImage.Name = "btwWatermarkBrowseImage";
            this.btwWatermarkBrowseImage.Size = new System.Drawing.Size(64, 24);
            this.btwWatermarkBrowseImage.TabIndex = 1;
            this.btwWatermarkBrowseImage.Tag = "Browse for a Watermark Image";
            this.btwWatermarkBrowseImage.Text = "Browse...";
            this.btwWatermarkBrowseImage.UseVisualStyleBackColor = true;
            this.btwWatermarkBrowseImage.Click += new System.EventHandler(this.btwWatermarkBrowseImage_Click);
            // 
            // txtWatermarkImageLocation
            // 
            this.txtWatermarkImageLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWatermarkImageLocation.Location = new System.Drawing.Point(16, 16);
            this.txtWatermarkImageLocation.Name = "txtWatermarkImageLocation";
            this.txtWatermarkImageLocation.Size = new System.Drawing.Size(368, 20);
            this.txtWatermarkImageLocation.TabIndex = 0;
            this.txtWatermarkImageLocation.TextChanged += new System.EventHandler(this.txtWatermarkImageLocation_TextChanged);
            // 
            // lblWatermarkBackColors2
            // 
            this.lblWatermarkBackColors2.AutoSize = true;
            this.lblWatermarkBackColors2.Location = new System.Drawing.Point(152, 56);
            this.lblWatermarkBackColors2.Name = "lblWatermarkBackColors2";
            this.lblWatermarkBackColors2.Size = new System.Drawing.Size(103, 13);
            this.lblWatermarkBackColors2.TabIndex = 15;
            this.lblWatermarkBackColors2.Text = "Background color 2:";
            // 
            // lblWatermarkBorderColor
            // 
            this.lblWatermarkBorderColor.AutoSize = true;
            this.lblWatermarkBorderColor.Location = new System.Drawing.Point(16, 120);
            this.lblWatermarkBorderColor.Name = "lblWatermarkBorderColor";
            this.lblWatermarkBorderColor.Size = new System.Drawing.Size(67, 13);
            this.lblWatermarkBorderColor.TabIndex = 16;
            this.lblWatermarkBorderColor.Text = "Border color:";
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.White;
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.DrawCheckeredBackground = true;
            this.pbPreview.Location = new System.Drawing.Point(8, 176);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(288, 240);
            this.pbPreview.TabIndex = 2;
            // 
            // WatermarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(792, 424);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.gbWatermarkGeneral);
            this.Controls.Add(this.tcWatermark);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WatermarkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - Watermark settings";
            this.Load += new System.EventHandler(this.WatermarkUI_Load);
            this.Resize += new System.EventHandler(this.WatermarkUI_Resize);
            this.gbWatermarkGeneral.ResumeLayout(false);
            this.gbWatermarkGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWatermarkOffset)).EndInit();
            this.tcWatermark.ResumeLayout(false);
            this.tpWatermarkText.ResumeLayout(false);
            this.gbWatermarkBackground.ResumeLayout(false);
            this.gbWatermarkBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermarkGradient2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermarkBorderColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermarkGradient1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWatermarkCornerRadius)).EndInit();
            this.gbWatermarkText.ResumeLayout(false);
            this.gbWatermarkText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermarkFontColor)).EndInit();
            this.tpWatermarkImage.ResumeLayout(false);
            this.tpWatermarkImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWatermarkImageScale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gbWatermarkGeneral;
        private System.Windows.Forms.Label lblWatermarkOffsetPixel;
        internal System.Windows.Forms.ComboBox cboWatermarkType;
        internal System.Windows.Forms.CheckBox cbWatermarkAutoHide;
        internal System.Windows.Forms.CheckBox cbWatermarkAddReflection;
        internal System.Windows.Forms.Label lblWatermarkType;
        internal System.Windows.Forms.ComboBox chkWatermarkPosition;
        internal System.Windows.Forms.Label lblWatermarkPosition;
        internal System.Windows.Forms.NumericUpDown nudWatermarkOffset;
        internal System.Windows.Forms.Label lblWatermarkOffset;
        internal System.Windows.Forms.TabControl tcWatermark;
        internal System.Windows.Forms.TabPage tpWatermarkText;
        internal System.Windows.Forms.GroupBox gbWatermarkBackground;
        internal System.Windows.Forms.Label lblRectangleCornerRadius;
        internal System.Windows.Forms.Label lblWatermarkBackColors;
        internal System.Windows.Forms.PictureBox pbWatermarkGradient2;
        internal System.Windows.Forms.ComboBox cbWatermarkGradientType;
        internal System.Windows.Forms.PictureBox pbWatermarkBorderColor;
        internal System.Windows.Forms.Label lblWatermarkGradientType;
        internal System.Windows.Forms.PictureBox pbWatermarkGradient1;
        private System.Windows.Forms.Button btnSelectGradient;
        private System.Windows.Forms.CheckBox cboUseCustomGradient;
        internal System.Windows.Forms.NumericUpDown nudWatermarkCornerRadius;
        internal System.Windows.Forms.Label lblWatermarkCornerRadiusTip;
        internal System.Windows.Forms.GroupBox gbWatermarkText;
        internal System.Windows.Forms.Label lblWatermarkText;
        internal System.Windows.Forms.Label lblWatermarkFont;
        internal System.Windows.Forms.Button btnWatermarkFont;
        internal System.Windows.Forms.TextBox txtWatermarkText;
        internal System.Windows.Forms.PictureBox pbWatermarkFontColor;
        internal System.Windows.Forms.TabPage tpWatermarkImage;
        internal System.Windows.Forms.Label lblWatermarkImageScale;
        internal System.Windows.Forms.NumericUpDown nudWatermarkImageScale;
        internal System.Windows.Forms.CheckBox cbWatermarkUseBorder;
        internal System.Windows.Forms.Button btwWatermarkBrowseImage;
        internal System.Windows.Forms.TextBox txtWatermarkImageLocation;
        internal System.Windows.Forms.Label lblWatermarkBorderColor;
        internal System.Windows.Forms.Label lblWatermarkBackColors2;
        private HelpersLib.MyPictureBox pbPreview;
    }
}