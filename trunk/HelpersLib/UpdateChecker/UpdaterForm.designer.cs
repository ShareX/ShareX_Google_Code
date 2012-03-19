namespace UpdateCheckerLib
{
    partial class UpdaterForm
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
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.txtVer = new System.Windows.Forms.RichTextBox();
            this.lblVer = new System.Windows.Forms.Label();
            this.pbApp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbApp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYes.Location = new System.Drawing.Point(472, 8);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(72, 40);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "&Yes...";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNo.Location = new System.Drawing.Point(544, 8);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(72, 40);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "&No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // txtVer
            // 
            this.txtVer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVer.BackColor = System.Drawing.Color.DimGray;
            this.txtVer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVer.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVer.ForeColor = System.Drawing.Color.White;
            this.txtVer.Location = new System.Drawing.Point(8, 120);
            this.txtVer.Name = "txtVer";
            this.txtVer.ReadOnly = true;
            this.txtVer.Size = new System.Drawing.Size(608, 216);
            this.txtVer.TabIndex = 3;
            this.txtVer.TabStop = false;
            this.txtVer.Text = "";
            this.txtVer.WordWrap = false;
            this.txtVer.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TxtVerLinkClicked);
            // 
            // lblVer
            // 
            this.lblVer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVer.BackColor = System.Drawing.Color.Transparent;
            this.lblVer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVer.ForeColor = System.Drawing.Color.White;
            this.lblVer.Location = new System.Drawing.Point(136, 8);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(480, 104);
            this.lblVer.TabIndex = 0;
            this.lblVer.Text = "New version is available";
            // 
            // pbApp
            // 
            this.pbApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbApp.Location = new System.Drawing.Point(8, 8);
            this.pbApp.Name = "pbApp";
            this.pbApp.Size = new System.Drawing.Size(116, 100);
            this.pbApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbApp.TabIndex = 4;
            this.pbApp.TabStop = false;
            // 
            // UpdaterForm
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(625, 345);
            this.Controls.Add(this.pbApp);
            this.Controls.Add(this.txtVer);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblVer);
            this.MinimumSize = new System.Drawing.Size(509, 343);
            this.Name = "UpdaterForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update form";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewVersionWindow_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.RichTextBox txtVer;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.PictureBox pbApp;
    }
}