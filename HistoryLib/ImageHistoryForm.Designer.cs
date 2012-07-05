namespace HistoryLib
{
    partial class ImageHistoryForm
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
            this.ilvImages = new Manina.Windows.Forms.ImageListView();
            this.SuspendLayout();
            // 
            // ilvImages
            // 
            this.ilvImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ilvImages.ColumnHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ilvImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilvImages.GroupHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ilvImages.Location = new System.Drawing.Point(0, 0);
            this.ilvImages.Name = "ilvImages";
            this.ilvImages.PersistentCacheFile = "";
            this.ilvImages.PersistentCacheSize = ((long)(100));
            this.ilvImages.Size = new System.Drawing.Size(784, 562);
            this.ilvImages.TabIndex = 0;
            this.ilvImages.ItemDoubleClick += new Manina.Windows.Forms.ItemDoubleClickEventHandler(this.ilvImages_ItemDoubleClick);
            this.ilvImages.SelectionChanged += new System.EventHandler(this.ilvImages_SelectionChanged);
            this.ilvImages.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ilvImages_MouseUp);
            // 
            // ImageHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.ilvImages);
            this.Name = "ImageHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageHistoryForm";
            this.Shown += new System.EventHandler(this.ImageHistoryForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Manina.Windows.Forms.ImageListView ilvImages;
    }
}