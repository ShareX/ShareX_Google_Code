namespace HelpersLib.Hotkey
{
    partial class HotkeySelectionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHotkeyDescription = new System.Windows.Forms.Label();
            this.btnSetHotkey = new System.Windows.Forms.Button();
            this.lblIsHotkeyActive = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHotkeyDescription
            // 
            this.lblHotkeyDescription.Location = new System.Drawing.Point(0, 5);
            this.lblHotkeyDescription.Name = "lblHotkeyDescription";
            this.lblHotkeyDescription.Size = new System.Drawing.Size(250, 15);
            this.lblHotkeyDescription.TabIndex = 0;
            this.lblHotkeyDescription.Text = "Description";
            // 
            // btnSetHotkey
            // 
            this.btnSetHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetHotkey.Location = new System.Drawing.Point(288, 0);
            this.btnSetHotkey.Name = "btnSetHotkey";
            this.btnSetHotkey.Size = new System.Drawing.Size(195, 23);
            this.btnSetHotkey.TabIndex = 1;
            this.btnSetHotkey.Text = "Ctrl + Shift + Alt + Print Screen";
            this.btnSetHotkey.UseVisualStyleBackColor = true;
            this.btnSetHotkey.Click += new System.EventHandler(this.btnSetHotkey_Click);
            // 
            // lblIsHotkeyActive
            // 
            this.lblIsHotkeyActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIsHotkeyActive.BackColor = System.Drawing.Color.IndianRed;
            this.lblIsHotkeyActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIsHotkeyActive.Location = new System.Drawing.Point(256, 1);
            this.lblIsHotkeyActive.Name = "lblIsHotkeyActive";
            this.lblIsHotkeyActive.Size = new System.Drawing.Size(28, 21);
            this.lblIsHotkeyActive.TabIndex = 2;
            // 
            // HotkeySelectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIsHotkeyActive);
            this.Controls.Add(this.btnSetHotkey);
            this.Controls.Add(this.lblHotkeyDescription);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.Name = "HotkeySelectionControl";
            this.Size = new System.Drawing.Size(483, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHotkeyDescription;
        private System.Windows.Forms.Button btnSetHotkey;
        private System.Windows.Forms.Label lblIsHotkeyActive;
    }
}
