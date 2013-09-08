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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCopyImage = new System.Windows.Forms.Button();
            this.btnCopyLink = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnOpenLink = new System.Windows.Forms.Button();
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
            this.pbPreview = new HelpersLib.MyPictureBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
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
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.Size = new System.Drawing.Size(684, 352);
            this.tlpMain.TabIndex = 0;
            // 
            // tvMain
            // 
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.Location = new System.Drawing.Point(273, 3);
            this.tvMain.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(408, 316);
            this.tvMain.TabIndex = 1;
            this.tvMain.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMain_NodeMouseDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCopyImage);
            this.flowLayoutPanel1.Controls.Add(this.btnCopyLink);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 322);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(267, 27);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.AutoSize = true;
            this.btnCopyImage.Location = new System.Drawing.Point(0, 0);
            this.btnCopyImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(90, 27);
            this.btnCopyImage.TabIndex = 0;
            this.btnCopyImage.Text = "Copy image";
            this.btnCopyImage.UseVisualStyleBackColor = true;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // btnCopyLink
            // 
            this.btnCopyLink.AutoSize = true;
            this.btnCopyLink.Location = new System.Drawing.Point(93, 0);
            this.btnCopyLink.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnCopyLink.Name = "btnCopyLink";
            this.btnCopyLink.Size = new System.Drawing.Size(90, 27);
            this.btnCopyLink.TabIndex = 1;
            this.btnCopyLink.Text = "Copy link";
            this.btnCopyLink.UseVisualStyleBackColor = true;
            this.btnCopyLink.Click += new System.EventHandler(this.btnCopyLink_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnOpenLink);
            this.flowLayoutPanel2.Controls.Add(this.btnOpenFile);
            this.flowLayoutPanel2.Controls.Add(this.btnOpenFolder);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(273, 322);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(408, 27);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.AutoSize = true;
            this.btnOpenFolder.Location = new System.Drawing.Point(186, 0);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(90, 27);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "Open folder...";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnFolderOpen_Click);
            // 
            // btnOpenLink
            // 
            this.btnOpenLink.AutoSize = true;
            this.btnOpenLink.Location = new System.Drawing.Point(0, 0);
            this.btnOpenLink.Margin = new System.Windows.Forms.Padding(0);
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
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.White;
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.DrawCheckeredBackground = true;
            this.pbPreview.FullscreenOnClick = true;
            this.pbPreview.Location = new System.Drawing.Point(3, 3);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(267, 316);
            this.pbPreview.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AutoSize = true;
            this.btnOpenFile.Location = new System.Drawing.Point(93, 0);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(90, 27);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Open file...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // AfterUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 352);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(604, 313);
            this.Name = "AfterUploadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - After upload";
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
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnCopyImage;
        private System.Windows.Forms.Button btnOpenLink;
        private System.Windows.Forms.Button btnCopyLink;
        private System.Windows.Forms.Button btnOpenFile;
    }
}