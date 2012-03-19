namespace HelpersLib
{
    partial class OptionsCoreUI
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Capture");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Effects");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Saving");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Hotkeys");
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tvOptions = new System.Windows.Forms.TreeView();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tlpMain.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tvOptions, 0, 0);
            this.tlpMain.Controls.Add(this.tcMain, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(795, 516);
            this.tlpMain.TabIndex = 0;
            // 
            // tvOptions
            // 
            this.tvOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOptions.Location = new System.Drawing.Point(3, 3);
            this.tvOptions.Name = "tvOptions";
            treeNode1.Name = "tnGeneral";
            treeNode1.Text = "General";
            treeNode2.Name = "tnCapture";
            treeNode2.Text = "Capture";
            treeNode3.Name = "tnEffects";
            treeNode3.Text = "Effects";
            treeNode4.Name = "tnSaving";
            treeNode4.Text = "Saving";
            treeNode5.Name = "tnHotkeys";
            treeNode5.Text = "Hotkeys";
            this.tvOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.tvOptions.Size = new System.Drawing.Size(160, 510);
            this.tvOptions.TabIndex = 0;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Controls.Add(this.tabPage5);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(169, 3);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(623, 510);
            this.tcMain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(615, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(615, 484);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(615, 484);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(615, 484);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // OptionsCoreUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 516);
            this.Controls.Add(this.tlpMain);
            this.Name = "OptionsCoreUI";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.ZScreenOptionsCoreUI_Load);
            this.tlpMain.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel tlpMain;
        protected System.Windows.Forms.TreeView tvOptions;
        protected System.Windows.Forms.TabControl tcMain;
        protected System.Windows.Forms.TabPage tabPage1;
        protected System.Windows.Forms.TabPage tabPage2;
        protected System.Windows.Forms.TabPage tabPage3;
        protected System.Windows.Forms.TabPage tabPage4;
        protected System.Windows.Forms.TabPage tabPage5;

    }
}