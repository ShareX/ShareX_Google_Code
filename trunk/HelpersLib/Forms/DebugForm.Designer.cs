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
            this.components = new System.ComponentModel.Container();
            this.txtDebugLog = new System.Windows.Forms.TextBox();
            this.btnLoadedAssemblies = new System.Windows.Forms.Button();
            this.tUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.cbAutoUpdateText = new System.Windows.Forms.CheckBox();
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
            this.btnLoadedAssemblies.Size = new System.Drawing.Size(120, 23);
            this.btnLoadedAssemblies.TabIndex = 2;
            this.btnLoadedAssemblies.Text = "Loaded assemblies";
            this.btnLoadedAssemblies.UseVisualStyleBackColor = true;
            this.btnLoadedAssemblies.Click += new System.EventHandler(this.btnLoadedAssemblies_Click);
            // 
            // tUpdateTimer
            // 
            this.tUpdateTimer.Enabled = true;
            this.tUpdateTimer.Interval = 1000;
            this.tUpdateTimer.Tick += new System.EventHandler(this.tUpdateTimer_Tick);
            // 
            // cbAutoUpdateText
            // 
            this.cbAutoUpdateText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAutoUpdateText.AutoSize = true;
            this.cbAutoUpdateText.Checked = true;
            this.cbAutoUpdateText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoUpdateText.Location = new System.Drawing.Point(648, 491);
            this.cbAutoUpdateText.Name = "cbAutoUpdateText";
            this.cbAutoUpdateText.Size = new System.Drawing.Size(104, 17);
            this.cbAutoUpdateText.TabIndex = 3;
            this.cbAutoUpdateText.Text = "Auto update text";
            this.cbAutoUpdateText.UseVisualStyleBackColor = true;
            this.cbAutoUpdateText.CheckedChanged += new System.EventHandler(this.cbAutoUpdateText_CheckedChanged);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 518);
            this.Controls.Add(this.cbAutoUpdateText);
            this.Controls.Add(this.btnLoadedAssemblies);
            this.Controls.Add(this.txtDebugLog);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "DebugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - Debug log";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDebugLog;
        private System.Windows.Forms.Button btnLoadedAssemblies;
        private System.Windows.Forms.Timer tUpdateTimer;
        private System.Windows.Forms.CheckBox cbAutoUpdateText;
    }
}