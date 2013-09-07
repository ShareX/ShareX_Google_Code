namespace ShareX
{
    partial class AfterUploadForm
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
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.pbPreview = new HelpersLib.MyPictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCopyImage = new System.Windows.Forms.Button();
            this.btnCopyLink = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFolderOpen = new System.Windows.Forms.Button();
            this.btnOpenLink = new System.Windows.Forms.Button();
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
            this.tlpMain.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.Controls.Add(this.tvMain, 1, 0);
            this.tlpMain.Controls.Add(this.pbPreview, 0, 0);
            this.tlpMain.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tlpMain.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpMain.Size = new System.Drawing.Size(588, 274);
            this.tlpMain.TabIndex = 0;
            // 
            // tvMain
            // 
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.Location = new System.Drawing.Point(238, 3);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(347, 229);
            this.tvMain.TabIndex = 1;
            this.tvMain.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMain_NodeMouseDoubleClick);
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.White;
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.DrawCheckeredBackground = true;
            this.pbPreview.Location = new System.Drawing.Point(4, 4);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(227, 227);
            this.pbPreview.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCopyImage);
            this.flowLayoutPanel1.Controls.Add(this.btnCopyLink);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 238);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(229, 33);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.AutoSize = true;
            this.btnCopyImage.Location = new System.Drawing.Point(3, 3);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(92, 27);
            this.btnCopyImage.TabIndex = 0;
            this.btnCopyImage.Text = "Copy image";
            this.btnCopyImage.UseVisualStyleBackColor = true;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // btnCopyLink
            // 
            this.btnCopyLink.AutoSize = true;
            this.btnCopyLink.Location = new System.Drawing.Point(101, 3);
            this.btnCopyLink.Name = "btnCopyLink";
            this.btnCopyLink.Size = new System.Drawing.Size(75, 27);
            this.btnCopyLink.TabIndex = 1;
            this.btnCopyLink.Text = "Copy link";
            this.btnCopyLink.UseVisualStyleBackColor = true;
            this.btnCopyLink.Click += new System.EventHandler(this.btnCopyLink_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnFolderOpen);
            this.flowLayoutPanel2.Controls.Add(this.btnOpenLink);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(238, 238);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(347, 33);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnFolderOpen
            // 
            this.btnFolderOpen.AutoSize = true;
            this.btnFolderOpen.Location = new System.Drawing.Point(3, 3);
            this.btnFolderOpen.Name = "btnFolderOpen";
            this.btnFolderOpen.Size = new System.Drawing.Size(105, 27);
            this.btnFolderOpen.TabIndex = 0;
            this.btnFolderOpen.Text = "Open folder...";
            this.btnFolderOpen.UseVisualStyleBackColor = true;
            this.btnFolderOpen.Click += new System.EventHandler(this.btnFolderOpen_Click);
            // 
            // btnOpenLink
            // 
            this.btnOpenLink.AutoSize = true;
            this.btnOpenLink.Location = new System.Drawing.Point(114, 3);
            this.btnOpenLink.Name = "btnOpenLink";
            this.btnOpenLink.Size = new System.Drawing.Size(90, 27);
            this.btnOpenLink.TabIndex = 1;
            this.btnOpenLink.Text = "Open link...";
            this.btnOpenLink.UseVisualStyleBackColor = true;
            this.btnOpenLink.Click += new System.EventHandler(this.btnOpenLink_Click);
            // 
            // tmrClose
            // 
            this.tmrClose.Enabled = true;
            this.tmrClose.Interval = 60000;
            this.tmrClose.Tick += new System.EventHandler(this.tmrClose_Tick);
            // 
            // AfterUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 274);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(604, 313);
            this.Name = "AfterUploadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "After Upload";
            this.tlpMain.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TreeView tvMain;
        private HelpersLib.MyPictureBox pbPreview;
        private System.Windows.Forms.Timer tmrClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnFolderOpen;
        private System.Windows.Forms.Button btnCopyImage;
        private System.Windows.Forms.Button btnOpenLink;
        private System.Windows.Forms.Button btnCopyLink;
    }
}