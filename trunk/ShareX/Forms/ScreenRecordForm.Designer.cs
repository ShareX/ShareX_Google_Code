namespace ShareX
{
    partial class ScreenRecordForm
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
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnRegion = new System.Windows.Forms.Button();
            this.lblRegion = new System.Windows.Forms.Label();
            this.pbEncoding = new System.Windows.Forms.ProgressBar();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // btnRecord
            // 
            this.btnRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecord.Enabled = false;
            this.btnRecord.Location = new System.Drawing.Point(16, 80);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(200, 24);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Start recording after 1 second";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnRegion
            // 
            this.btnRegion.Location = new System.Drawing.Point(16, 16);
            this.btnRegion.Name = "btnRegion";
            this.btnRegion.Size = new System.Drawing.Size(104, 24);
            this.btnRegion.TabIndex = 1;
            this.btnRegion.Text = "Select region";
            this.btnRegion.UseVisualStyleBackColor = true;
            this.btnRegion.Click += new System.EventHandler(this.btnRegion_Click);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(16, 48);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(41, 13);
            this.lblRegion.TabIndex = 7;
            this.lblRegion.Text = "Region";
            // 
            // pbEncoding
            // 
            this.pbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEncoding.Location = new System.Drawing.Point(16, 80);
            this.pbEncoding.Name = "pbEncoding";
            this.pbEncoding.Size = new System.Drawing.Size(200, 24);
            this.pbEncoding.TabIndex = 11;
            this.pbEncoding.Visible = false;
            // 
            // niTray
            // 
            this.niTray.Text = "Stop screen recording";
            this.niTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.niTray_MouseClick);
            // 
            // ScreenRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 114);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.btnRegion);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.pbEncoding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScreenRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - Screen recorder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnRegion;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.ProgressBar pbEncoding;
        private System.Windows.Forms.NotifyIcon niTray;
    }
}