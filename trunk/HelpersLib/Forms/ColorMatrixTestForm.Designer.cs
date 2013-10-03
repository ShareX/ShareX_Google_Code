namespace HelpersLib
{
    partial class ColorMatrixTestForm
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
            this.cbColorMatrix = new System.Windows.Forms.ComboBox();
            this.nudValue = new System.Windows.Forms.NumericUpDown();
            this.lblValue = new System.Windows.Forms.Label();
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // cbColorMatrix
            // 
            this.cbColorMatrix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorMatrix.FormattingEnabled = true;
            this.cbColorMatrix.Location = new System.Drawing.Point(8, 8);
            this.cbColorMatrix.Name = "cbColorMatrix";
            this.cbColorMatrix.Size = new System.Drawing.Size(184, 21);
            this.cbColorMatrix.TabIndex = 2;
            this.cbColorMatrix.SelectedIndexChanged += new System.EventHandler(this.cbColorMatrix_SelectedIndexChanged);
            // 
            // nudValue
            // 
            this.nudValue.DecimalPlaces = 1;
            this.nudValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudValue.Location = new System.Drawing.Point(240, 8);
            this.nudValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudValue.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudValue.Name = "nudValue";
            this.nudValue.Size = new System.Drawing.Size(64, 20);
            this.nudValue.TabIndex = 3;
            this.nudValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudValue.ValueChanged += new System.EventHandler(this.nudValue_ValueChanged);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(200, 12);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 13);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "Value:";
            // 
            // pbSource
            // 
            this.pbSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSource.Location = new System.Drawing.Point(8, 56);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(144, 144);
            this.pbSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSource.TabIndex = 5;
            this.pbSource.TabStop = false;
            // 
            // pbResult
            // 
            this.pbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbResult.Location = new System.Drawing.Point(160, 56);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(144, 144);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbResult.TabIndex = 6;
            this.pbResult.TabStop = false;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(8, 40);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(44, 13);
            this.lblSource.TabIndex = 7;
            this.lblSource.Text = "Source:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(160, 40);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 8;
            this.lblResult.Text = "Result:";
            // 
            // ColorMatrixTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 208);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.pbResult);
            this.Controls.Add(this.pbSource);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.nudValue);
            this.Controls.Add(this.cbColorMatrix);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ColorMatrixTestForm";
            this.Text = "Color matrix test";
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbColorMatrix;
        private System.Windows.Forms.NumericUpDown nudValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblResult;
    }
}