namespace ImageEffectsLib
{
    partial class ImageEffectsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEffectsForm));
            this.tvEffects = new System.Windows.Forms.TreeView();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.pgSettings = new System.Windows.Forms.PropertyGrid();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvEffects = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemove = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbDefaultZoom = new System.Windows.Forms.PictureBox();
            this.lblDefault = new System.Windows.Forms.Label();
            this.pbDefault = new System.Windows.Forms.PictureBox();
            this.pbPreviewZoom = new System.Windows.Forms.PictureBox();
            this.lblPreview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDefaultZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // tvEffects
            // 
            this.tvEffects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvEffects.HideSelection = false;
            this.tvEffects.Location = new System.Drawing.Point(8, 280);
            this.tvEffects.Name = "tvEffects";
            this.tvEffects.Size = new System.Drawing.Size(296, 492);
            this.tvEffects.TabIndex = 4;
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.DimGray;
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(457, 492);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 1;
            this.pbPreview.TabStop = false;
            // 
            // pgSettings
            // 
            this.pgSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgSettings.Location = new System.Drawing.Point(312, 8);
            this.pgSettings.Name = "pgSettings";
            this.pgSettings.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgSettings.Size = new System.Drawing.Size(936, 264);
            this.pgSettings.TabIndex = 3;
            this.pgSettings.ToolbarVisible = false;
            this.pgSettings.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgSettings_PropertyValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvEffects
            // 
            this.lvEffects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvEffects.FullRowSelect = true;
            this.lvEffects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvEffects.HideSelection = false;
            this.lvEffects.Location = new System.Drawing.Point(8, 8);
            this.lvEffects.Name = "lvEffects";
            this.lvEffects.Size = new System.Drawing.Size(296, 264);
            this.lvEffects.TabIndex = 0;
            this.lvEffects.UseCompatibleStateImageBehavior = false;
            this.lvEffects.View = System.Windows.Forms.View.Details;
            this.lvEffects.SelectedIndexChanged += new System.EventHandler(this.lvEffects_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 275;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(96, 240);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(72, 24);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(312, 280);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbDefaultZoom);
            this.splitContainer1.Panel1.Controls.Add(this.lblDefault);
            this.splitContainer1.Panel1.Controls.Add(this.pbDefault);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbPreviewZoom);
            this.splitContainer1.Panel2.Controls.Add(this.lblPreview);
            this.splitContainer1.Panel2.Controls.Add(this.pbPreview);
            this.splitContainer1.Size = new System.Drawing.Size(935, 492);
            this.splitContainer1.SplitterDistance = 474;
            this.splitContainer1.TabIndex = 5;
            // 
            // pbDefaultZoom
            // 
            this.pbDefaultZoom.BackColor = System.Drawing.Color.DimGray;
            this.pbDefaultZoom.Location = new System.Drawing.Point(376, 8);
            this.pbDefaultZoom.Name = "pbDefaultZoom";
            this.pbDefaultZoom.Size = new System.Drawing.Size(88, 88);
            this.pbDefaultZoom.TabIndex = 4;
            this.pbDefaultZoom.TabStop = false;
            this.pbDefaultZoom.Visible = false;
            // 
            // lblDefault
            // 
            this.lblDefault.AutoSize = true;
            this.lblDefault.BackColor = System.Drawing.Color.DimGray;
            this.lblDefault.ForeColor = System.Drawing.Color.White;
            this.lblDefault.Location = new System.Drawing.Point(5, 8);
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(44, 13);
            this.lblDefault.TabIndex = 0;
            this.lblDefault.Text = "Default:";
            // 
            // pbDefault
            // 
            this.pbDefault.BackColor = System.Drawing.Color.DimGray;
            this.pbDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDefault.Location = new System.Drawing.Point(0, 0);
            this.pbDefault.Name = "pbDefault";
            this.pbDefault.Size = new System.Drawing.Size(474, 492);
            this.pbDefault.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDefault.TabIndex = 0;
            this.pbDefault.TabStop = false;
            // 
            // pbPreviewZoom
            // 
            this.pbPreviewZoom.BackColor = System.Drawing.Color.DimGray;
            this.pbPreviewZoom.Location = new System.Drawing.Point(360, 8);
            this.pbPreviewZoom.Name = "pbPreviewZoom";
            this.pbPreviewZoom.Size = new System.Drawing.Size(88, 88);
            this.pbPreviewZoom.TabIndex = 3;
            this.pbPreviewZoom.TabStop = false;
            this.pbPreviewZoom.Visible = false;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.BackColor = System.Drawing.Color.DimGray;
            this.lblPreview.ForeColor = System.Drawing.Color.White;
            this.lblPreview.Location = new System.Drawing.Point(8, 8);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(40, 13);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "Result:";
            // 
            // ImageEffectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 784);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pgSettings);
            this.Controls.Add(this.tvEffects);
            this.Controls.Add(this.lvEffects);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageEffectsForm";
            this.Text = "ShareX - Image Effects";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageEffectsGUI_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDefaultZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvEffects;
        public System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.PropertyGrid pgSettings;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvEffects;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pbDefault;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Label lblDefault;
        private System.Windows.Forms.PictureBox pbPreviewZoom;
        private System.Windows.Forms.PictureBox pbDefaultZoom;
    }
}

