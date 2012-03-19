namespace ShareX
{
    partial class AboutForm
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
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblZScreen = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBugs = new System.Windows.Forms.Label();
            this.lblBerk = new System.Windows.Forms.Label();
            this.pbTR = new System.Windows.Forms.PictureBox();
            this.pbBerkURL = new System.Windows.Forms.PictureBox();
            this.pbMikeURL = new System.Windows.Forms.PictureBox();
            this.pbAU = new System.Windows.Forms.PictureBox();
            this.lblMike = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.uclUpdate = new UpdateCheckerLib.UpdateCheckerLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbTR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBerkURL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMikeURL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(272, 8);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(134, 24);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "ShareX 1.0.0.0";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZScreen
            // 
            this.lblZScreen.AutoSize = true;
            this.lblZScreen.BackColor = System.Drawing.Color.Transparent;
            this.lblZScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblZScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblZScreen.ForeColor = System.Drawing.Color.Black;
            this.lblZScreen.Location = new System.Drawing.Point(272, 64);
            this.lblZScreen.Name = "lblZScreen";
            this.lblZScreen.Size = new System.Drawing.Size(67, 13);
            this.lblZScreen.TabIndex = 2;
            this.lblZScreen.Text = "Project page";
            this.lblZScreen.Click += new System.EventHandler(this.lblZScreen_Click);
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(456, 224);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 31);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.ForeColor = System.Drawing.Color.Black;
            this.lblCopyright.Location = new System.Drawing.Point(272, 208);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(51, 13);
            this.lblCopyright.TabIndex = 7;
            this.lblCopyright.Text = "Copyright";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(272, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 52);
            this.label1.TabIndex = 6;
            this.label1.Text = "FTP Library: http://www.starksoft.com\r\nIcons: http://p.yusukekamiyamane.com\r\nJson" +
    ".NET: http://json.codeplex.com\r\nSSH.NET: http://sshnet.codeplex.com";
            // 
            // lblBugs
            // 
            this.lblBugs.AutoSize = true;
            this.lblBugs.BackColor = System.Drawing.Color.Transparent;
            this.lblBugs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBugs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBugs.ForeColor = System.Drawing.Color.Black;
            this.lblBugs.Location = new System.Drawing.Point(344, 64);
            this.lblBugs.Name = "lblBugs";
            this.lblBugs.Size = new System.Drawing.Size(100, 13);
            this.lblBugs.TabIndex = 3;
            this.lblBugs.Text = "Bugs / Suggestions";
            this.lblBugs.Click += new System.EventHandler(this.lblBugs_Click);
            // 
            // lblBerk
            // 
            this.lblBerk.AutoSize = true;
            this.lblBerk.BackColor = System.Drawing.Color.Transparent;
            this.lblBerk.ForeColor = System.Drawing.Color.Black;
            this.lblBerk.Location = new System.Drawing.Point(328, 92);
            this.lblBerk.Name = "lblBerk";
            this.lblBerk.Size = new System.Drawing.Size(108, 13);
            this.lblBerk.TabIndex = 4;
            this.lblBerk.Text = "Jaex (flexy123) - Berk";
            // 
            // pbTR
            // 
            this.pbTR.BackColor = System.Drawing.Color.Transparent;
            this.pbTR.Image = global::ShareX.Properties.Resources.tr;
            this.pbTR.Location = new System.Drawing.Point(280, 90);
            this.pbTR.Name = "pbTR";
            this.pbTR.Size = new System.Drawing.Size(16, 16);
            this.pbTR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTR.TabIndex = 8;
            this.pbTR.TabStop = false;
            // 
            // pbBerkURL
            // 
            this.pbBerkURL.BackColor = System.Drawing.Color.Transparent;
            this.pbBerkURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBerkURL.Image = global::ShareX.Properties.Resources.application_browser;
            this.pbBerkURL.Location = new System.Drawing.Point(304, 90);
            this.pbBerkURL.Name = "pbBerkURL";
            this.pbBerkURL.Size = new System.Drawing.Size(16, 16);
            this.pbBerkURL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBerkURL.TabIndex = 10;
            this.pbBerkURL.TabStop = false;
            this.pbBerkURL.Click += new System.EventHandler(this.pbBerkURL_Click);
            // 
            // pbMikeURL
            // 
            this.pbMikeURL.BackColor = System.Drawing.Color.Transparent;
            this.pbMikeURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMikeURL.Image = global::ShareX.Properties.Resources.application_browser;
            this.pbMikeURL.Location = new System.Drawing.Point(304, 112);
            this.pbMikeURL.Name = "pbMikeURL";
            this.pbMikeURL.Size = new System.Drawing.Size(16, 16);
            this.pbMikeURL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMikeURL.TabIndex = 14;
            this.pbMikeURL.TabStop = false;
            this.pbMikeURL.Click += new System.EventHandler(this.pbMikeURL_Click);
            // 
            // pbAU
            // 
            this.pbAU.BackColor = System.Drawing.Color.Transparent;
            this.pbAU.Image = global::ShareX.Properties.Resources.au;
            this.pbAU.Location = new System.Drawing.Point(280, 112);
            this.pbAU.Name = "pbAU";
            this.pbAU.Size = new System.Drawing.Size(16, 16);
            this.pbAU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAU.TabIndex = 12;
            this.pbAU.TabStop = false;
            // 
            // lblMike
            // 
            this.lblMike.AutoSize = true;
            this.lblMike.BackColor = System.Drawing.Color.Transparent;
            this.lblMike.ForeColor = System.Drawing.Color.Black;
            this.lblMike.Location = new System.Drawing.Point(328, 114);
            this.lblMike.Name = "lblMike";
            this.lblMike.Size = new System.Drawing.Size(164, 13);
            this.lblMike.TabIndex = 5;
            this.lblMike.Text = "McoreD (mcored) - Mike Delpach";
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::ShareX.Properties.Resources.ShareXLogo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(264, 264);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLogo.TabIndex = 19;
            this.pbLogo.TabStop = false;
            // 
            // uclUpdate
            // 
            this.uclUpdate.Location = new System.Drawing.Point(272, 35);
            this.uclUpdate.Name = "uclUpdate";
            this.uclUpdate.Size = new System.Drawing.Size(250, 24);
            this.uclUpdate.TabIndex = 1;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 264);
            this.Controls.Add(this.uclUpdate);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pbMikeURL);
            this.Controls.Add(this.pbAU);
            this.Controls.Add(this.lblMike);
            this.Controls.Add(this.pbBerkURL);
            this.Controls.Add(this.pbTR);
            this.Controls.Add(this.lblBerk);
            this.Controls.Add(this.lblBugs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblZScreen);
            this.Controls.Add(this.lblProductName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - About";
            this.Shown += new System.EventHandler(this.AboutForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbTR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBerkURL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMikeURL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblZScreen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBugs;
        private System.Windows.Forms.Label lblBerk;
        private System.Windows.Forms.PictureBox pbTR;
        private System.Windows.Forms.PictureBox pbBerkURL;
        private System.Windows.Forms.PictureBox pbMikeURL;
        private System.Windows.Forms.PictureBox pbAU;
        private System.Windows.Forms.Label lblMike;
        private System.Windows.Forms.PictureBox pbLogo;
        private UpdateCheckerLib.UpdateCheckerLabel uclUpdate;
    }
}