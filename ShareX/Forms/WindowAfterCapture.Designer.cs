namespace ShareX
{
    partial class WindowAfterCapture
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
            this.chkAnnotateImage = new System.Windows.Forms.CheckBox();
            this.chkCopyImageToClipboard = new System.Windows.Forms.CheckBox();
            this.chkSaveImageToFile = new System.Windows.Forms.CheckBox();
            this.chkUploadImageToHost = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkAnnotateImage
            // 
            this.chkAnnotateImage.AutoSize = true;
            this.chkAnnotateImage.Location = new System.Drawing.Point(8, 8);
            this.chkAnnotateImage.Name = "chkAnnotateImage";
            this.chkAnnotateImage.Size = new System.Drawing.Size(100, 17);
            this.chkAnnotateImage.TabIndex = 0;
            this.chkAnnotateImage.Text = "Annotate image";
            this.chkAnnotateImage.UseVisualStyleBackColor = true;
            // 
            // chkCopyImageToClipboard
            // 
            this.chkCopyImageToClipboard.AutoSize = true;
            this.chkCopyImageToClipboard.Location = new System.Drawing.Point(8, 32);
            this.chkCopyImageToClipboard.Name = "chkCopyImageToClipboard";
            this.chkCopyImageToClipboard.Size = new System.Drawing.Size(139, 17);
            this.chkCopyImageToClipboard.TabIndex = 1;
            this.chkCopyImageToClipboard.Text = "Copy image to clipboard";
            this.chkCopyImageToClipboard.UseVisualStyleBackColor = true;
            // 
            // chkSaveImageToFile
            // 
            this.chkSaveImageToFile.AutoSize = true;
            this.chkSaveImageToFile.Location = new System.Drawing.Point(8, 56);
            this.chkSaveImageToFile.Name = "chkSaveImageToFile";
            this.chkSaveImageToFile.Size = new System.Drawing.Size(110, 17);
            this.chkSaveImageToFile.TabIndex = 2;
            this.chkSaveImageToFile.Text = "Save image to file";
            this.chkSaveImageToFile.UseVisualStyleBackColor = true;
            // 
            // chkUploadImageToHost
            // 
            this.chkUploadImageToHost.AutoSize = true;
            this.chkUploadImageToHost.Location = new System.Drawing.Point(8, 80);
            this.chkUploadImageToHost.Name = "chkUploadImageToHost";
            this.chkUploadImageToHost.Size = new System.Drawing.Size(126, 17);
            this.chkUploadImageToHost.TabIndex = 3;
            this.chkUploadImageToHost.Text = "Upload image to host";
            this.chkUploadImageToHost.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(208, 96);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(74, 22);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // WindowAfterCapture
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 126);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkUploadImageToHost);
            this.Controls.Add(this.chkSaveImageToFile);
            this.Controls.Add(this.chkCopyImageToClipboard);
            this.Controls.Add(this.chkAnnotateImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WindowAfterCapture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "After capture...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WindowAfterCapture_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAnnotateImage;
        private System.Windows.Forms.CheckBox chkCopyImageToClipboard;
        private System.Windows.Forms.CheckBox chkSaveImageToFile;
        private System.Windows.Forms.CheckBox chkUploadImageToHost;
        private System.Windows.Forms.Button btnOk;
    }
}