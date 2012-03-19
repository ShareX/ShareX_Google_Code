namespace HelpersLib
{
    partial class HotkeyInputForm
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
            this.cbControl = new System.Windows.Forms.CheckBox();
            this.cbShift = new System.Windows.Forms.CheckBox();
            this.cbAlt = new System.Windows.Forms.CheckBox();
            this.cbKeys = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbControl
            // 
            this.cbControl.AutoSize = true;
            this.cbControl.Location = new System.Drawing.Point(16, 16);
            this.cbControl.Name = "cbControl";
            this.cbControl.Size = new System.Drawing.Size(41, 17);
            this.cbControl.TabIndex = 0;
            this.cbControl.Text = "Ctrl";
            this.cbControl.UseVisualStyleBackColor = true;
            // 
            // cbShift
            // 
            this.cbShift.AutoSize = true;
            this.cbShift.Location = new System.Drawing.Point(63, 16);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(47, 17);
            this.cbShift.TabIndex = 1;
            this.cbShift.Text = "Shift";
            this.cbShift.UseVisualStyleBackColor = true;
            // 
            // cbAlt
            // 
            this.cbAlt.AutoSize = true;
            this.cbAlt.Location = new System.Drawing.Point(116, 16);
            this.cbAlt.Name = "cbAlt";
            this.cbAlt.Size = new System.Drawing.Size(38, 17);
            this.cbAlt.TabIndex = 2;
            this.cbAlt.Text = "Alt";
            this.cbAlt.UseVisualStyleBackColor = true;
            // 
            // cbKeys
            // 
            this.cbKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeys.FormattingEnabled = true;
            this.cbKeys.Location = new System.Drawing.Point(160, 14);
            this.cbKeys.MaxDropDownItems = 30;
            this.cbKeys.Name = "cbKeys";
            this.cbKeys.Size = new System.Drawing.Size(128, 21);
            this.cbKeys.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(8, 48);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(80, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(152, 48);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(224, 48);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // HotkeyInputForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 84);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbKeys);
            this.Controls.Add(this.cbAlt);
            this.Controls.Add(this.cbShift);
            this.Controls.Add(this.cbControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HotkeyInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Hotkey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbControl;
        private System.Windows.Forms.CheckBox cbShift;
        private System.Windows.Forms.CheckBox cbAlt;
        private System.Windows.Forms.ComboBox cbKeys;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClear;
    }
}