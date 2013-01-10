namespace ShareX
{
    partial class ScreenRecordForm
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
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnRegion = new System.Windows.Forms.Button();
            this.lblFPS = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.nudFPS = new System.Windows.Forms.NumericUpDown();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.cbOutput = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(16, 152);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(200, 24);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Start record (after 1 second)";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnRegion
            // 
            this.btnRegion.Location = new System.Drawing.Point(16, 16);
            this.btnRegion.Name = "btnRegion";
            this.btnRegion.Size = new System.Drawing.Size(104, 24);
            this.btnRegion.TabIndex = 1;
            this.btnRegion.Text = "Select region";
            this.btnRegion.UseVisualStyleBackColor = true;
            this.btnRegion.Click += new System.EventHandler(this.btnRegion_Click);
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Location = new System.Drawing.Point(16, 76);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(30, 13);
            this.lblFPS.TabIndex = 3;
            this.lblFPS.Text = "FPS:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(16, 100);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(99, 13);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = "Duration (seconds):";
            // 
            // nudDuration
            // 
            this.nudDuration.DecimalPlaces = 1;
            this.nudDuration.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudDuration.Location = new System.Drawing.Point(120, 96);
            this.nudDuration.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(64, 20);
            this.nudDuration.TabIndex = 5;
            this.nudDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDuration.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudDuration.ValueChanged += new System.EventHandler(this.nudDuration_ValueChanged);
            // 
            // nudFPS
            // 
            this.nudFPS.Location = new System.Drawing.Point(56, 72);
            this.nudFPS.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFPS.Name = "nudFPS";
            this.nudFPS.Size = new System.Drawing.Size(64, 20);
            this.nudFPS.TabIndex = 6;
            this.nudFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFPS.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudFPS.ValueChanged += new System.EventHandler(this.nudFPS_ValueChanged);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(16, 52);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(41, 13);
            this.lblRegion.TabIndex = 7;
            this.lblRegion.Text = "Region";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(16, 124);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(42, 13);
            this.lblOutput.TabIndex = 8;
            this.lblOutput.Text = "Output:";
            // 
            // cbOutput
            // 
            this.cbOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutput.FormattingEnabled = true;
            this.cbOutput.Location = new System.Drawing.Point(64, 120);
            this.cbOutput.Name = "cbOutput";
            this.cbOutput.Size = new System.Drawing.Size(64, 21);
            this.cbOutput.TabIndex = 9;
            this.cbOutput.SelectedIndexChanged += new System.EventHandler(this.cbOutput_SelectedIndexChanged);
            // 
            // ScreenRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 188);
            this.Controls.Add(this.cbOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.nudFPS);
            this.Controls.Add(this.nudDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblFPS);
            this.Controls.Add(this.btnRegion);
            this.Controls.Add(this.btnRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScreenRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - Screen record";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnRegion;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.NumericUpDown nudFPS;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.ComboBox cbOutput;
    }
}