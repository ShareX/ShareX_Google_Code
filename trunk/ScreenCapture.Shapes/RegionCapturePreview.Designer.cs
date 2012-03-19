namespace ScreenCapture
{
    partial class RegionCapturePreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionCapturePreview));
            this.tsRegionTools = new System.Windows.Forms.ToolStrip();
            this.tsbFullscreen = new System.Windows.Forms.ToolStripButton();
            this.tsbRectangle = new System.Windows.Forms.ToolStripButton();
            this.tsbRoundedRectangle = new System.Windows.Forms.ToolStripButton();
            this.tsbEllipse = new System.Windows.Forms.ToolStripButton();
            this.tsbTriangle = new System.Windows.Forms.ToolStripButton();
            this.tsbDiamond = new System.Windows.Forms.ToolStripButton();
            this.tsbPolygon = new System.Windows.Forms.ToolStripButton();
            this.tsbFreeHand = new System.Windows.Forms.ToolStripButton();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.cbDrawChecker = new System.Windows.Forms.CheckBox();
            this.cbDrawBorder = new System.Windows.Forms.CheckBox();
            this.pImage = new System.Windows.Forms.Panel();
            this.cbIsFixedSize = new System.Windows.Forms.CheckBox();
            this.nudFixedWidth = new System.Windows.Forms.NumericUpDown();
            this.nudFixedHeight = new System.Windows.Forms.NumericUpDown();
            this.cbQuickCrop = new System.Windows.Forms.CheckBox();
            this.btnClipboardCopy = new System.Windows.Forms.Button();
            this.tsbWindowRectangle = new System.Windows.Forms.ToolStripButton();
            this.tsRegionTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.pImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // tsRegionTools
            // 
            this.tsRegionTools.AutoSize = false;
            this.tsRegionTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsRegionTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFullscreen,
            this.tsbWindowRectangle,
            this.tsbRectangle,
            this.tsbRoundedRectangle,
            this.tsbEllipse,
            this.tsbTriangle,
            this.tsbDiamond,
            this.tsbPolygon,
            this.tsbFreeHand});
            this.tsRegionTools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.tsRegionTools.Location = new System.Drawing.Point(0, 0);
            this.tsRegionTools.Name = "tsRegionTools";
            this.tsRegionTools.Padding = new System.Windows.Forms.Padding(10, 10, 1, 0);
            this.tsRegionTools.ShowItemToolTips = false;
            this.tsRegionTools.Size = new System.Drawing.Size(168, 649);
            this.tsRegionTools.TabIndex = 0;
            this.tsRegionTools.Text = "toolStrip1";
            // 
            // tsbFullscreen
            // 
            this.tsbFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("tsbFullscreen.Image")));
            this.tsbFullscreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFullscreen.Name = "tsbFullscreen";
            this.tsbFullscreen.Size = new System.Drawing.Size(80, 20);
            this.tsbFullscreen.Text = "Fullscreen";
            this.tsbFullscreen.Click += new System.EventHandler(this.tsbFullscreen_Click);
            // 
            // tsbRectangle
            // 
            this.tsbRectangle.Image = ((System.Drawing.Image)(resources.GetObject("tsbRectangle.Image")));
            this.tsbRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRectangle.Name = "tsbRectangle";
            this.tsbRectangle.Size = new System.Drawing.Size(79, 20);
            this.tsbRectangle.Text = "Rectangle";
            this.tsbRectangle.Click += new System.EventHandler(this.tsbRectangle_Click);
            // 
            // tsbRoundedRectangle
            // 
            this.tsbRoundedRectangle.Image = ((System.Drawing.Image)(resources.GetObject("tsbRoundedRectangle.Image")));
            this.tsbRoundedRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRoundedRectangle.Name = "tsbRoundedRectangle";
            this.tsbRoundedRectangle.Size = new System.Drawing.Size(130, 20);
            this.tsbRoundedRectangle.Text = "Rounded Rectangle";
            this.tsbRoundedRectangle.Click += new System.EventHandler(this.tsbRoundedRectangle_Click);
            // 
            // tsbEllipse
            // 
            this.tsbEllipse.Image = ((System.Drawing.Image)(resources.GetObject("tsbEllipse.Image")));
            this.tsbEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEllipse.Name = "tsbEllipse";
            this.tsbEllipse.Size = new System.Drawing.Size(60, 20);
            this.tsbEllipse.Text = "Ellipse";
            this.tsbEllipse.Click += new System.EventHandler(this.tsbEllipse_Click);
            // 
            // tsbTriangle
            // 
            this.tsbTriangle.Image = ((System.Drawing.Image)(resources.GetObject("tsbTriangle.Image")));
            this.tsbTriangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTriangle.Name = "tsbTriangle";
            this.tsbTriangle.Size = new System.Drawing.Size(70, 20);
            this.tsbTriangle.Text = "Triangle";
            this.tsbTriangle.Click += new System.EventHandler(this.tsbTriangle_Click);
            // 
            // tsbDiamond
            // 
            this.tsbDiamond.Image = ((System.Drawing.Image)(resources.GetObject("tsbDiamond.Image")));
            this.tsbDiamond.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDiamond.Name = "tsbDiamond";
            this.tsbDiamond.Size = new System.Drawing.Size(76, 20);
            this.tsbDiamond.Text = "Diamond";
            this.tsbDiamond.Click += new System.EventHandler(this.tsbDiamond_Click);
            // 
            // tsbPolygon
            // 
            this.tsbPolygon.Image = ((System.Drawing.Image)(resources.GetObject("tsbPolygon.Image")));
            this.tsbPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPolygon.Name = "tsbPolygon";
            this.tsbPolygon.Size = new System.Drawing.Size(71, 20);
            this.tsbPolygon.Text = "Polygon";
            this.tsbPolygon.Click += new System.EventHandler(this.tsbPolygon_Click);
            // 
            // tsbFreeHand
            // 
            this.tsbFreeHand.Image = ((System.Drawing.Image)(resources.GetObject("tsbFreeHand.Image")));
            this.tsbFreeHand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFreeHand.Name = "tsbFreeHand";
            this.tsbFreeHand.Size = new System.Drawing.Size(81, 20);
            this.tsbFreeHand.Text = "Free Hand";
            this.tsbFreeHand.Click += new System.EventHandler(this.tsbFreeHand_Click);
            // 
            // pbResult
            // 
            this.pbResult.BackColor = System.Drawing.Color.Gray;
            this.pbResult.Location = new System.Drawing.Point(0, 0);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(936, 608);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbResult.TabIndex = 1;
            this.pbResult.TabStop = false;
            // 
            // cbDrawChecker
            // 
            this.cbDrawChecker.AutoSize = true;
            this.cbDrawChecker.ForeColor = System.Drawing.Color.White;
            this.cbDrawChecker.Location = new System.Drawing.Point(264, 8);
            this.cbDrawChecker.Name = "cbDrawChecker";
            this.cbDrawChecker.Size = new System.Drawing.Size(165, 17);
            this.cbDrawChecker.TabIndex = 2;
            this.cbDrawChecker.Text = "Draw checkered background";
            this.cbDrawChecker.UseVisualStyleBackColor = true;
            this.cbDrawChecker.CheckedChanged += new System.EventHandler(this.cbDrawChecker_CheckedChanged);
            // 
            // cbDrawBorder
            // 
            this.cbDrawBorder.AutoSize = true;
            this.cbDrawBorder.ForeColor = System.Drawing.Color.White;
            this.cbDrawBorder.Location = new System.Drawing.Point(176, 8);
            this.cbDrawBorder.Name = "cbDrawBorder";
            this.cbDrawBorder.Size = new System.Drawing.Size(84, 17);
            this.cbDrawBorder.TabIndex = 3;
            this.cbDrawBorder.Text = "Draw border";
            this.cbDrawBorder.UseVisualStyleBackColor = true;
            this.cbDrawBorder.CheckedChanged += new System.EventHandler(this.cbDrawBorder_CheckedChanged);
            // 
            // pImage
            // 
            this.pImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pImage.AutoScroll = true;
            this.pImage.Controls.Add(this.pbResult);
            this.pImage.Location = new System.Drawing.Point(176, 32);
            this.pImage.Name = "pImage";
            this.pImage.Size = new System.Drawing.Size(936, 608);
            this.pImage.TabIndex = 4;
            // 
            // cbIsFixedSize
            // 
            this.cbIsFixedSize.AutoSize = true;
            this.cbIsFixedSize.ForeColor = System.Drawing.Color.White;
            this.cbIsFixedSize.Location = new System.Drawing.Point(432, 8);
            this.cbIsFixedSize.Name = "cbIsFixedSize";
            this.cbIsFixedSize.Size = new System.Drawing.Size(86, 17);
            this.cbIsFixedSize.TabIndex = 5;
            this.cbIsFixedSize.Text = "Is fixed size?";
            this.cbIsFixedSize.UseVisualStyleBackColor = true;
            this.cbIsFixedSize.CheckedChanged += new System.EventHandler(this.cbIsFixedSize_CheckedChanged);
            // 
            // nudFixedWidth
            // 
            this.nudFixedWidth.Location = new System.Drawing.Point(520, 6);
            this.nudFixedWidth.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudFixedWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFixedWidth.Name = "nudFixedWidth";
            this.nudFixedWidth.Size = new System.Drawing.Size(56, 20);
            this.nudFixedWidth.TabIndex = 6;
            this.nudFixedWidth.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nudFixedWidth.ValueChanged += new System.EventHandler(this.nudFixedWidth_ValueChanged);
            // 
            // nudFixedHeight
            // 
            this.nudFixedHeight.Location = new System.Drawing.Point(584, 6);
            this.nudFixedHeight.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudFixedHeight.Name = "nudFixedHeight";
            this.nudFixedHeight.Size = new System.Drawing.Size(56, 20);
            this.nudFixedHeight.TabIndex = 7;
            this.nudFixedHeight.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nudFixedHeight.ValueChanged += new System.EventHandler(this.nudFixedHeight_ValueChanged);
            // 
            // cbQuickCrop
            // 
            this.cbQuickCrop.AutoSize = true;
            this.cbQuickCrop.ForeColor = System.Drawing.Color.White;
            this.cbQuickCrop.Location = new System.Drawing.Point(648, 8);
            this.cbQuickCrop.Name = "cbQuickCrop";
            this.cbQuickCrop.Size = new System.Drawing.Size(78, 17);
            this.cbQuickCrop.TabIndex = 2;
            this.cbQuickCrop.Text = "Quick crop";
            this.cbQuickCrop.UseVisualStyleBackColor = true;
            this.cbQuickCrop.CheckedChanged += new System.EventHandler(this.cbQuickCrop_CheckedChanged);
            // 
            // btnClipboardCopy
            // 
            this.btnClipboardCopy.Location = new System.Drawing.Point(728, 5);
            this.btnClipboardCopy.Name = "btnClipboardCopy";
            this.btnClipboardCopy.Size = new System.Drawing.Size(75, 23);
            this.btnClipboardCopy.TabIndex = 2;
            this.btnClipboardCopy.Text = "Copy";
            this.btnClipboardCopy.UseVisualStyleBackColor = true;
            this.btnClipboardCopy.Click += new System.EventHandler(this.btnClipboardCopy_Click);
            // 
            // tsbWindowRectangle
            // 
            this.tsbWindowRectangle.Image = ((System.Drawing.Image)(resources.GetObject("tsbWindowRectangle.Image")));
            this.tsbWindowRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWindowRectangle.Name = "tsbWindowRectangle";
            this.tsbWindowRectangle.Size = new System.Drawing.Size(139, 20);
            this.tsbWindowRectangle.Text = "Window && Rectangle";
            this.tsbWindowRectangle.Click += new System.EventHandler(this.tsbWindowRectangle_Click);
            // 
            // RegionCapturePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1123, 649);
            this.Controls.Add(this.btnClipboardCopy);
            this.Controls.Add(this.cbQuickCrop);
            this.Controls.Add(this.nudFixedHeight);
            this.Controls.Add(this.nudFixedWidth);
            this.Controls.Add(this.cbIsFixedSize);
            this.Controls.Add(this.pImage);
            this.Controls.Add(this.cbDrawBorder);
            this.Controls.Add(this.cbDrawChecker);
            this.Controls.Add(this.tsRegionTools);
            this.Name = "RegionCapturePreview";
            this.Text = "Region Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegionCapturePreview_FormClosing);
            this.tsRegionTools.ResumeLayout(false);
            this.tsRegionTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.pImage.ResumeLayout(false);
            this.pImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsRegionTools;
        private System.Windows.Forms.ToolStripButton tsbFreeHand;
        private System.Windows.Forms.ToolStripButton tsbEllipse;
        private System.Windows.Forms.ToolStripButton tsbRectangle;
        private System.Windows.Forms.ToolStripButton tsbRoundedRectangle;
        private System.Windows.Forms.ToolStripButton tsbTriangle;
        private System.Windows.Forms.ToolStripButton tsbPolygon;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.CheckBox cbDrawChecker;
        private System.Windows.Forms.ToolStripButton tsbDiamond;
        private System.Windows.Forms.ToolStripButton tsbFullscreen;
        private System.Windows.Forms.CheckBox cbDrawBorder;
        private System.Windows.Forms.Panel pImage;
        private System.Windows.Forms.CheckBox cbIsFixedSize;
        private System.Windows.Forms.NumericUpDown nudFixedWidth;
        private System.Windows.Forms.NumericUpDown nudFixedHeight;
        private System.Windows.Forms.CheckBox cbQuickCrop;
        private System.Windows.Forms.Button btnClipboardCopy;
        private System.Windows.Forms.ToolStripButton tsbWindowRectangle;
    }
}