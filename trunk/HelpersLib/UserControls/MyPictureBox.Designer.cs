namespace HelpersLib
{
    partial class MyPictureBox
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
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BackColor = System.Drawing.Color.White;
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Image = global::HelpersLib.Properties.Resources.explorer;
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(150, 150);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseClick);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.DimGray;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(150, 24);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Test";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // MyPictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbMain);
            this.Name = "MyPictureBox";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion Component Designer generated code

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Label lblStatus;
    }
}