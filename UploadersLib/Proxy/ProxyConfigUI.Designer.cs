namespace UploadersLib
{
    partial class ProxyConfigUI
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
            this.gpProxySettings = new System.Windows.Forms.GroupBox();
            this.cboProxyConfig = new System.Windows.Forms.ComboBox();
            this.ucProxyAccounts = new UploadersLib.AccountsControl();
            this.gpProxySettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpProxySettings
            // 
            this.gpProxySettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpProxySettings.Controls.Add(this.cboProxyConfig);
            this.gpProxySettings.Location = new System.Drawing.Point(8, 376);
            this.gpProxySettings.Name = "gpProxySettings";
            this.gpProxySettings.Size = new System.Drawing.Size(742, 72);
            this.gpProxySettings.TabIndex = 1;
            this.gpProxySettings.TabStop = false;
            this.gpProxySettings.Text = "Proxy Settings";
            // 
            // cboProxyConfig
            // 
            this.cboProxyConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProxyConfig.FormattingEnabled = true;
            this.cboProxyConfig.Location = new System.Drawing.Point(16, 24);
            this.cboProxyConfig.Name = "cboProxyConfig";
            this.cboProxyConfig.Size = new System.Drawing.Size(264, 21);
            this.cboProxyConfig.TabIndex = 0;
            this.cboProxyConfig.SelectedIndexChanged += new System.EventHandler(this.cboProxyConfig_SelectedIndexChanged);
            // 
            // ucProxyAccounts
            // 
            this.ucProxyAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucProxyAccounts.Location = new System.Drawing.Point(8, 8);
            this.ucProxyAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.ucProxyAccounts.Name = "ucProxyAccounts";
            this.ucProxyAccounts.Size = new System.Drawing.Size(752, 360);
            this.ucProxyAccounts.TabIndex = 0;
            // 
            // ProxyConfigUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 465);
            this.Controls.Add(this.gpProxySettings);
            this.Controls.Add(this.ucProxyAccounts);
            this.Name = "ProxyConfigUI";
            this.Text = "Proxy Configurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProxyConfigUI_FormClosing);
            this.Load += new System.EventHandler(this.ProxyConfigUI_Load);
            this.gpProxySettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gpProxySettings;
        internal System.Windows.Forms.ComboBox cboProxyConfig;
        internal AccountsControl ucProxyAccounts;
    }
}