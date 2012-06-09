namespace HelpersLib
{
    partial class ClipboardContentViewer
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.pbClipboard = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtClipboard = new System.Windows.Forms.TextBox();
            this.lbClipboard = new System.Windows.Forms.ListBox();
            this.cbDontShowThisWindow = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbClipboard)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQuestion.ForeColor = System.Drawing.Color.White;
            this.lblQuestion.Location = new System.Drawing.Point(0, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(385, 25);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Your clipboard contains the following:";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbClipboard
            // 
            this.pbClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClipboard.BackColor = System.Drawing.Color.White;
            this.pbClipboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbClipboard.Location = new System.Drawing.Point(8, 32);
            this.pbClipboard.Name = "pbClipboard";
            this.pbClipboard.Size = new System.Drawing.Size(368, 288);
            this.pbClipboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClipboard.TabIndex = 1;
            this.pbClipboard.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(208, 328);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(296, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtClipboard
            // 
            this.txtClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClipboard.BackColor = System.Drawing.Color.White;
            this.txtClipboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClipboard.Location = new System.Drawing.Point(8, 32);
            this.txtClipboard.Multiline = true;
            this.txtClipboard.Name = "txtClipboard";
            this.txtClipboard.ReadOnly = true;
            this.txtClipboard.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtClipboard.Size = new System.Drawing.Size(368, 288);
            this.txtClipboard.TabIndex = 1;
            // 
            // lbClipboard
            // 
            this.lbClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClipboard.FormattingEnabled = true;
            this.lbClipboard.IntegralHeight = false;
            this.lbClipboard.Location = new System.Drawing.Point(8, 32);
            this.lbClipboard.Name = "lbClipboard";
            this.lbClipboard.Size = new System.Drawing.Size(368, 288);
            this.lbClipboard.TabIndex = 2;
            // 
            // cbDontShowThisWindow
            // 
            this.cbDontShowThisWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDontShowThisWindow.AutoSize = true;
            this.cbDontShowThisWindow.Location = new System.Drawing.Point(9, 332);
            this.cbDontShowThisWindow.Name = "cbDontShowThisWindow";
            this.cbDontShowThisWindow.Size = new System.Drawing.Size(137, 17);
            this.cbDontShowThisWindow.TabIndex = 2;
            this.cbDontShowThisWindow.Text = "Don\'t show this window";
            this.cbDontShowThisWindow.UseVisualStyleBackColor = true;
            this.cbDontShowThisWindow.CheckedChanged += new System.EventHandler(this.cbDontShowThisWindow_CheckedChanged);
            // 
            // ClipboardContentViewer
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 360);
            this.Controls.Add(this.cbDontShowThisWindow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.txtClipboard);
            this.Controls.Add(this.pbClipboard);
            this.Controls.Add(this.lbClipboard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(375, 375);
            this.Name = "ClipboardContentViewer";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Are you sure you want to upload?";
            this.Load += new System.EventHandler(this.ClipboardContentViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbClipboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.PictureBox pbClipboard;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtClipboard;
        private System.Windows.Forms.ListBox lbClipboard;
        private System.Windows.Forms.CheckBox cbDontShowThisWindow;
    }
}