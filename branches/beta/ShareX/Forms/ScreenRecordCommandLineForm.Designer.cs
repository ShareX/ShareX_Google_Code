namespace ShareX
{
    partial class ScreenRecordCommandLineForm
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
            this.tbCommandLinePath = new System.Windows.Forms.TextBox();
            this.tbCommandLineOutputExtension = new System.Windows.Forms.TextBox();
            this.tbCommandLineArgs = new System.Windows.Forms.TextBox();
            this.lblCommandLinePath = new System.Windows.Forms.Label();
            this.lblCommandLineArgs = new System.Windows.Forms.Label();
            this.lblCommandLineOutputExtension = new System.Windows.Forms.Label();
            this.btnBrowseCommandLinePath = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbCommandLinePath
            // 
            this.tbCommandLinePath.Location = new System.Drawing.Point(112, 8);
            this.tbCommandLinePath.Name = "tbCommandLinePath";
            this.tbCommandLinePath.Size = new System.Drawing.Size(184, 20);
            this.tbCommandLinePath.TabIndex = 0;
            // 
            // tbCommandLineOutputExtension
            // 
            this.tbCommandLineOutputExtension.Location = new System.Drawing.Point(112, 72);
            this.tbCommandLineOutputExtension.Name = "tbCommandLineOutputExtension";
            this.tbCommandLineOutputExtension.Size = new System.Drawing.Size(224, 20);
            this.tbCommandLineOutputExtension.TabIndex = 1;
            // 
            // tbCommandLineArgs
            // 
            this.tbCommandLineArgs.Location = new System.Drawing.Point(112, 40);
            this.tbCommandLineArgs.Name = "tbCommandLineArgs";
            this.tbCommandLineArgs.Size = new System.Drawing.Size(224, 20);
            this.tbCommandLineArgs.TabIndex = 2;
            // 
            // lblCommandLinePath
            // 
            this.lblCommandLinePath.AutoSize = true;
            this.lblCommandLinePath.Location = new System.Drawing.Point(16, 12);
            this.lblCommandLinePath.Name = "lblCommandLinePath";
            this.lblCommandLinePath.Size = new System.Drawing.Size(74, 13);
            this.lblCommandLinePath.TabIndex = 3;
            this.lblCommandLinePath.Text = "Encoder path:";
            // 
            // lblCommandLineArgs
            // 
            this.lblCommandLineArgs.AutoSize = true;
            this.lblCommandLineArgs.Location = new System.Drawing.Point(16, 44);
            this.lblCommandLineArgs.Name = "lblCommandLineArgs";
            this.lblCommandLineArgs.Size = new System.Drawing.Size(60, 13);
            this.lblCommandLineArgs.TabIndex = 4;
            this.lblCommandLineArgs.Text = "Arguments:";
            // 
            // lblCommandLineOutputExtension
            // 
            this.lblCommandLineOutputExtension.AutoSize = true;
            this.lblCommandLineOutputExtension.Location = new System.Drawing.Point(16, 76);
            this.lblCommandLineOutputExtension.Name = "lblCommandLineOutputExtension";
            this.lblCommandLineOutputExtension.Size = new System.Drawing.Size(90, 13);
            this.lblCommandLineOutputExtension.TabIndex = 5;
            this.lblCommandLineOutputExtension.Text = "Output extension:";
            // 
            // btnBrowseCommandLinePath
            // 
            this.btnBrowseCommandLinePath.Location = new System.Drawing.Point(304, 6);
            this.btnBrowseCommandLinePath.Name = "btnBrowseCommandLinePath";
            this.btnBrowseCommandLinePath.Size = new System.Drawing.Size(32, 24);
            this.btnBrowseCommandLinePath.TabIndex = 6;
            this.btnBrowseCommandLinePath.Text = "...";
            this.btnBrowseCommandLinePath.UseVisualStyleBackColor = true;
            this.btnBrowseCommandLinePath.Click += new System.EventHandler(this.btnBrowseCommandLinePath_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(184, 104);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(264, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ScreenRecordCommandLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 137);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowseCommandLinePath);
            this.Controls.Add(this.lblCommandLineOutputExtension);
            this.Controls.Add(this.lblCommandLineArgs);
            this.Controls.Add(this.lblCommandLinePath);
            this.Controls.Add(this.tbCommandLineArgs);
            this.Controls.Add(this.tbCommandLineOutputExtension);
            this.Controls.Add(this.tbCommandLinePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScreenRecordCommandLineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - Command line encoder settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCommandLinePath;
        private System.Windows.Forms.TextBox tbCommandLineOutputExtension;
        private System.Windows.Forms.TextBox tbCommandLineArgs;
        private System.Windows.Forms.Label lblCommandLinePath;
        private System.Windows.Forms.Label lblCommandLineArgs;
        private System.Windows.Forms.Label lblCommandLineOutputExtension;
        private System.Windows.Forms.Button btnBrowseCommandLinePath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}