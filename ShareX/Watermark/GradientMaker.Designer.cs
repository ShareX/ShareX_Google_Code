namespace ShareX
{
    partial class GradientMaker
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
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.btnBrowseColor = new System.Windows.Forms.Button();
            this.rtbCodes = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cboGradientDirection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbBrushData = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(144, 6);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(248, 48);
            this.pbPreview.TabIndex = 2;
            this.pbPreview.TabStop = false;
            // 
            // btnAddColor
            // 
            this.btnAddColor.Location = new System.Drawing.Point(296, 368);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(99, 23);
            this.btnAddColor.TabIndex = 12;
            this.btnAddColor.Text = "Add / Update";
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Offset:";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(48, 368);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(112, 20);
            this.txtColor.TabIndex = 8;
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(248, 368);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(40, 20);
            this.txtOffset.TabIndex = 11;
            // 
            // btnBrowseColor
            // 
            this.btnBrowseColor.Location = new System.Drawing.Point(168, 368);
            this.btnBrowseColor.Name = "btnBrowseColor";
            this.btnBrowseColor.Size = new System.Drawing.Size(24, 23);
            this.btnBrowseColor.TabIndex = 9;
            this.btnBrowseColor.Text = "...";
            this.btnBrowseColor.UseVisualStyleBackColor = true;
            this.btnBrowseColor.Click += new System.EventHandler(this.btnBrowseColor_Click);
            // 
            // rtbCodes
            // 
            this.rtbCodes.AcceptsTab = true;
            this.rtbCodes.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCodes.Location = new System.Drawing.Point(8, 64);
            this.rtbCodes.Name = "rtbCodes";
            this.rtbCodes.Size = new System.Drawing.Size(384, 296);
            this.rtbCodes.TabIndex = 5;
            this.rtbCodes.Text = "";
            this.rtbCodes.SelectionChanged += new System.EventHandler(this.rtbCodes_SelectionChanged);
            this.rtbCodes.TextChanged += new System.EventHandler(this.rtbCodes_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(240, 400);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(320, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 400);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(72, 23);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // cboGradientDirection
            // 
            this.cboGradientDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradientDirection.FormattingEnabled = true;
            this.cboGradientDirection.Items.AddRange(new object[] {
            "Vertical",
            "Horizontal"});
            this.cboGradientDirection.Location = new System.Drawing.Point(8, 32);
            this.cboGradientDirection.Name = "cboGradientDirection";
            this.cboGradientDirection.Size = new System.Drawing.Size(120, 21);
            this.cboGradientDirection.TabIndex = 3;
            this.cboGradientDirection.SelectedIndexChanged += new System.EventHandler(this.cboGradientDirection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gradient direction:";
            // 
            // lbBrushData
            // 
            this.lbBrushData.FormattingEnabled = true;
            this.lbBrushData.Location = new System.Drawing.Point(400, 64);
            this.lbBrushData.Name = "lbBrushData";
            this.lbBrushData.Size = new System.Drawing.Size(152, 277);
            this.lbBrushData.TabIndex = 6;
            this.lbBrushData.SelectedIndexChanged += new System.EventHandler(this.lbBrushData_SelectedIndexChanged);
            this.lbBrushData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbBrushData_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(480, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(400, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(152, 20);
            this.txtName.TabIndex = 4;
            this.txtName.Text = "Gradient 1";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(400, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // GradientMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 432);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbBrushData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGradientDirection);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbCodes);
            this.Controls.Add(this.btnBrowseColor);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.pbPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GradientMaker";
            this.Text = "Gradient Maker";
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Button btnBrowseColor;
        private System.Windows.Forms.RichTextBox rtbCodes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ComboBox cboGradientDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbBrushData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAdd;
    }
}