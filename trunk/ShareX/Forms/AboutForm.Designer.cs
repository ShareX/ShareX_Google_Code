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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProjectPage = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblBugs = new System.Windows.Forms.Label();
            this.lblBerk = new System.Windows.Forms.Label();
            this.pbTR = new System.Windows.Forms.PictureBox();
            this.pbBerkURL = new System.Windows.Forms.PictureBox();
            this.pbMikeURL = new System.Windows.Forms.PictureBox();
            this.pbAU = new System.Windows.Forms.PictureBox();
            this.lblMike = new System.Windows.Forms.Label();
            this.cLogo = new HelpersLib.Canvas();
            this.uclUpdate = new UpdateCheckerLib.UpdateCheckerLabel();
            this.pbBerkSteamURL = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBerkURL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMikeURL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBerkSteamURL)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(16, 8);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(134, 24);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "ShareX 1.0.0.0";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProjectPage
            // 
            this.lblProjectPage.AutoSize = true;
            this.lblProjectPage.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblProjectPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProjectPage.ForeColor = System.Drawing.Color.Black;
            this.lblProjectPage.Location = new System.Drawing.Point(16, 64);
            this.lblProjectPage.Name = "lblProjectPage";
            this.lblProjectPage.Size = new System.Drawing.Size(67, 13);
            this.lblProjectPage.TabIndex = 4;
            this.lblProjectPage.Text = "Project page";
            this.lblProjectPage.Click += new System.EventHandler(this.lblProjectPage_Click);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.ForeColor = System.Drawing.Color.Black;
            this.lblCopyright.Location = new System.Drawing.Point(16, 272);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(51, 13);
            this.lblCopyright.TabIndex = 8;
            this.lblCopyright.Text = "Copyright";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.BackColor = System.Drawing.Color.Transparent;
            this.lblCredits.ForeColor = System.Drawing.Color.Black;
            this.lblCredits.Location = new System.Drawing.Point(16, 144);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(348, 117);
            this.lblCredits.TabIndex = 7;
            this.lblCredits.Text = resources.GetString("lblCredits.Text");
            // 
            // lblBugs
            // 
            this.lblBugs.AutoSize = true;
            this.lblBugs.BackColor = System.Drawing.Color.Transparent;
            this.lblBugs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBugs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBugs.ForeColor = System.Drawing.Color.Black;
            this.lblBugs.Location = new System.Drawing.Point(88, 64);
            this.lblBugs.Name = "lblBugs";
            this.lblBugs.Size = new System.Drawing.Size(100, 13);
            this.lblBugs.TabIndex = 5;
            this.lblBugs.Text = "Bugs / Suggestions";
            this.lblBugs.Click += new System.EventHandler(this.lblBugs_Click);
            // 
            // lblBerk
            // 
            this.lblBerk.AutoSize = true;
            this.lblBerk.BackColor = System.Drawing.Color.Transparent;
            this.lblBerk.ForeColor = System.Drawing.Color.Black;
            this.lblBerk.Location = new System.Drawing.Point(88, 90);
            this.lblBerk.Name = "lblBerk";
            this.lblBerk.Size = new System.Drawing.Size(108, 13);
            this.lblBerk.TabIndex = 1;
            this.lblBerk.Text = "Jaex (flexy123) - Berk";
            // 
            // pbTR
            // 
            this.pbTR.BackColor = System.Drawing.Color.Transparent;
            this.pbTR.Image = global::ShareX.Properties.Resources.tr;
            this.pbTR.Location = new System.Drawing.Point(16, 88);
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
            this.pbBerkURL.Location = new System.Drawing.Point(40, 88);
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
            this.pbMikeURL.Location = new System.Drawing.Point(40, 112);
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
            this.pbAU.Location = new System.Drawing.Point(16, 112);
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
            this.lblMike.Location = new System.Drawing.Point(64, 114);
            this.lblMike.Name = "lblMike";
            this.lblMike.Size = new System.Drawing.Size(164, 13);
            this.lblMike.TabIndex = 6;
            this.lblMike.Text = "McoreD (mcored) - Mike Delpach";
            // 
            // cLogo
            // 
            this.cLogo.Interval = 100;
            this.cLogo.Location = new System.Drawing.Point(209, 0);
            this.cLogo.Name = "cLogo";
            this.cLogo.Size = new System.Drawing.Size(200, 200);
            this.cLogo.TabIndex = 2;
            this.cLogo.Draw += new HelpersLib.Canvas.DrawEventHandler(this.cLogo_Draw);
            this.cLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cLogo_MouseDown);
            this.cLogo.MouseLeave += new System.EventHandler(this.cLogo_MouseLeave);
            this.cLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cLogo_MouseMove);
            // 
            // uclUpdate
            // 
            this.uclUpdate.Location = new System.Drawing.Point(16, 35);
            this.uclUpdate.Name = "uclUpdate";
            this.uclUpdate.Size = new System.Drawing.Size(224, 24);
            this.uclUpdate.TabIndex = 3;
            // 
            // pbBerkSteamURL
            // 
            this.pbBerkSteamURL.BackColor = System.Drawing.Color.Transparent;
            this.pbBerkSteamURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBerkSteamURL.Image = global::ShareX.Properties.Resources.steam;
            this.pbBerkSteamURL.Location = new System.Drawing.Point(64, 88);
            this.pbBerkSteamURL.Name = "pbBerkSteamURL";
            this.pbBerkSteamURL.Size = new System.Drawing.Size(16, 16);
            this.pbBerkSteamURL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBerkSteamURL.TabIndex = 21;
            this.pbBerkSteamURL.TabStop = false;
            this.pbBerkSteamURL.Click += new System.EventHandler(this.pbBerkSteamURL_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 294);
            this.Controls.Add(this.pbBerkSteamURL);
            this.Controls.Add(this.lblBerk);
            this.Controls.Add(this.lblMike);
            this.Controls.Add(this.cLogo);
            this.Controls.Add(this.uclUpdate);
            this.Controls.Add(this.pbMikeURL);
            this.Controls.Add(this.pbAU);
            this.Controls.Add(this.pbBerkURL);
            this.Controls.Add(this.pbTR);
            this.Controls.Add(this.lblBugs);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblProjectPage);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblCredits);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutForm_FormClosing);
            this.Shown += new System.EventHandler(this.AboutForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbTR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBerkURL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMikeURL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBerkSteamURL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProjectPage;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblBugs;
        private System.Windows.Forms.Label lblBerk;
        private System.Windows.Forms.PictureBox pbTR;
        private System.Windows.Forms.PictureBox pbBerkURL;
        private System.Windows.Forms.PictureBox pbMikeURL;
        private System.Windows.Forms.PictureBox pbAU;
        private System.Windows.Forms.Label lblMike;
        private UpdateCheckerLib.UpdateCheckerLabel uclUpdate;
        private HelpersLib.Canvas cLogo;
        private System.Windows.Forms.PictureBox pbBerkSteamURL;
    }
}