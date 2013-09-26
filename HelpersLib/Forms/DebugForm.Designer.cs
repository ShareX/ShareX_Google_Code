namespace HelpersLib
{
    partial class DebugForm
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
            this.txtDebugLog = new System.Windows.Forms.TextBox();
            this.btnLoadedAssemblies = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDebugLog
            // 
            this.txtDebugLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugLog.BackColor = System.Drawing.Color.White;
            this.txtDebugLog.Location = new System.Drawing.Point(8, 8);
            this.txtDebugLog.Multiline = true;
            this.txtDebugLog.Name = "txtDebugLog";
            this.txtDebugLog.ReadOnly = true;
            this.txtDebugLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebugLog.Size = new System.Drawing.Size(744, 472);
            this.txtDebugLog.TabIndex = 1;
            this.txtDebugLog.WordWrap = false;
            // 
            // btnLoadedAssemblies
            // 
            this.btnLoadedAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadedAssemblies.Location = new System.Drawing.Point(8, 488);
            this.btnLoadedAssemblies.Name = "btnLoadedAssemblies";
            this.btnLoadedAssemblies.Size = new System.Drawing.Size(136, 23);
            this.btnLoadedAssemblies.TabIndex = 2;
            this.btnLoadedAssemblies.Text = "Loaded assemblies...";
            this.btnLoadedAssemblies.UseVisualStyleBackColor = true;
            this.btnLoadedAssemblies.Click += new System.EventHandler(this.btnLoadedAssemblies_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 518);
            this.Controls.Add(this.btnLoadedAssemblies);
            this.Controls.Add(this.txtDebugLog);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "DebugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - Debug log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDebugLog;
        private System.Windows.Forms.Button btnLoadedAssemblies;
    }
}