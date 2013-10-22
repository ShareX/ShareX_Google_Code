namespace ShareX
{
    partial class ScreenColorPicker
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
            this.btnPipette = new System.Windows.Forms.Button();
            this.lblScreenColorPickerTip = new System.Windows.Forms.Label();
            this.btnColorPicker = new System.Windows.Forms.Button();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.lblY = new System.Windows.Forms.Label();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.lblX = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPipette
            // 
            this.btnPipette.Image = global::ShareX.Properties.Resources.pipette;
            this.btnPipette.Location = new System.Drawing.Point(352, 274);
            this.btnPipette.Name = "btnPipette";
            this.btnPipette.Size = new System.Drawing.Size(32, 24);
            this.btnPipette.TabIndex = 56;
            this.btnPipette.UseVisualStyleBackColor = true;
            this.btnPipette.Click += new System.EventHandler(this.btnPipette_Click);
            // 
            // lblScreenColorPickerTip
            // 
            this.lblScreenColorPickerTip.AutoSize = true;
            this.lblScreenColorPickerTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScreenColorPickerTip.Location = new System.Drawing.Point(393, 271);
            this.lblScreenColorPickerTip.Name = "lblScreenColorPickerTip";
            this.lblScreenColorPickerTip.Size = new System.Drawing.Size(193, 30);
            this.lblScreenColorPickerTip.TabIndex = 55;
            this.lblScreenColorPickerTip.Text = "Press Ctrl when this window active\r\nto stop screen color picker.";
            this.lblScreenColorPickerTip.Visible = false;
            // 
            // btnColorPicker
            // 
            this.btnColorPicker.Location = new System.Drawing.Point(200, 274);
            this.btnColorPicker.Name = "btnColorPicker";
            this.btnColorPicker.Size = new System.Drawing.Size(144, 24);
            this.btnColorPicker.TabIndex = 52;
            this.btnColorPicker.Text = "Start screen color picker";
            this.btnColorPicker.UseVisualStyleBackColor = true;
            this.btnColorPicker.Click += new System.EventHandler(this.btnColorPicker_Click);
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(32, 276);
            this.nudX.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudX.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(64, 20);
            this.nudX.TabIndex = 54;
            this.nudX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudX.Value = new decimal(new int[] {
            1680,
            0,
            0,
            0});
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(104, 280);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 51;
            this.lblY.Text = "Y:";
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(128, 276);
            this.nudY.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudY.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(64, 20);
            this.nudY.TabIndex = 53;
            this.nudY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudY.Value = new decimal(new int[] {
            1050,
            0,
            0,
            0});
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(8, 280);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 50;
            this.lblX.Text = "X:";
            // 
            // ScreenColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 305);
            this.Controls.Add(this.btnPipette);
            this.Controls.Add(this.lblScreenColorPickerTip);
            this.Controls.Add(this.btnColorPicker);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.lblX);
            this.KeyPreview = true;
            this.Name = "ScreenColorPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ShareX - Screen color picker (You can double click any field to copy its value)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenColorPicker_KeyDown);
            this.Controls.SetChildIndex(this.txtHex, 0);
            this.Controls.SetChildIndex(this.colorPicker, 0);
            this.Controls.SetChildIndex(this.lblX, 0);
            this.Controls.SetChildIndex(this.nudY, 0);
            this.Controls.SetChildIndex(this.lblY, 0);
            this.Controls.SetChildIndex(this.nudX, 0);
            this.Controls.SetChildIndex(this.btnColorPicker, 0);
            this.Controls.SetChildIndex(this.lblScreenColorPickerTip, 0);
            this.Controls.SetChildIndex(this.btnPipette, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPipette;
        private System.Windows.Forms.Label lblScreenColorPickerTip;
        private System.Windows.Forms.Button btnColorPicker;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.Label lblX;
    }
}