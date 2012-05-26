#region License Information (GPL v3)

/*
    ShareX - A program that allows you to upload images, text or files in your clipboard
    Copyright (C) 2008-2011 ShareX Developers

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

namespace ShareX
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.cmsUploads = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyShortenedURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyThumbnailURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDeletionURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showResponseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbClipboardUpload = new System.Windows.Forms.ToolStripButton();
            this.tsbFileUpload = new System.Windows.Forms.ToolStripButton();
            this.tsbDebug = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiTestImageUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTestTextUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTestShapeCapture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbCapture = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiFullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindowRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRoundedRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEllipse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTriangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiamond = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPolygon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFreeHand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLastRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbDestinations = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiImageUploaders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTextUploaders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileUploaders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiURLShorteners = new System.Windows.Forms.ToolStripMenuItem();
            this.tssDestinations1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiUploadersConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tssMain1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tssMain2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHistory = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.tsbDonate = new System.Windows.Forms.ToolStripButton();
            this.tscMain = new System.Windows.Forms.ToolStripContainer();
            this.lvUploads = new HelpersLib.MyListView();
            this.chFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chElapsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRemaining = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUploaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTrayClipboardUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayFileUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCapture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayFullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayWindowRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayRoundedRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayEllipse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayTriangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayDiamond = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayPolygon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayFreeHand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrayLastRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.tssTray1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.tssTray2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsUploads.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.tscMain.ContentPanel.SuspendLayout();
            this.tscMain.TopToolStripPanel.SuspendLayout();
            this.tscMain.SuspendLayout();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsUploads
            // 
            this.cmsUploads.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openURLToolStripMenuItem,
            this.copyURLToolStripMenuItem,
            this.copyShortenedURLToolStripMenuItem,
            this.copyThumbnailURLToolStripMenuItem,
            this.copyDeletionURLToolStripMenuItem,
            this.showErrorsToolStripMenuItem,
            this.copyErrorsToolStripMenuItem,
            this.showResponseToolStripMenuItem,
            this.uploadFileToolStripMenuItem,
            this.stopUploadToolStripMenuItem});
            this.cmsUploads.Name = "cmsUploads";
            this.cmsUploads.ShowImageMargin = false;
            this.cmsUploads.ShowItemToolTips = false;
            this.cmsUploads.Size = new System.Drawing.Size(163, 224);
            // 
            // openURLToolStripMenuItem
            // 
            this.openURLToolStripMenuItem.Name = "openURLToolStripMenuItem";
            this.openURLToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openURLToolStripMenuItem.Text = "Open URL";
            this.openURLToolStripMenuItem.Click += new System.EventHandler(this.openURLToolStripMenuItem_Click);
            // 
            // copyURLToolStripMenuItem
            // 
            this.copyURLToolStripMenuItem.Name = "copyURLToolStripMenuItem";
            this.copyURLToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.copyURLToolStripMenuItem.Text = "Copy URL";
            this.copyURLToolStripMenuItem.Click += new System.EventHandler(this.copyURLToolStripMenuItem_Click);
            // 
            // copyShortenedURLToolStripMenuItem
            // 
            this.copyShortenedURLToolStripMenuItem.Name = "copyShortenedURLToolStripMenuItem";
            this.copyShortenedURLToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.copyShortenedURLToolStripMenuItem.Text = "Copy Shortened URL";
            this.copyShortenedURLToolStripMenuItem.Click += new System.EventHandler(this.copyShortenedURLToolStripMenuItem_Click);
            // 
            // copyThumbnailURLToolStripMenuItem
            // 
            this.copyThumbnailURLToolStripMenuItem.Name = "copyThumbnailURLToolStripMenuItem";
            this.copyThumbnailURLToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.copyThumbnailURLToolStripMenuItem.Text = "Copy Thumbnail URL";
            this.copyThumbnailURLToolStripMenuItem.Click += new System.EventHandler(this.copyThumbnailURLToolStripMenuItem_Click);
            // 
            // copyDeletionURLToolStripMenuItem
            // 
            this.copyDeletionURLToolStripMenuItem.Name = "copyDeletionURLToolStripMenuItem";
            this.copyDeletionURLToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.copyDeletionURLToolStripMenuItem.Text = "Copy Deletion URL";
            this.copyDeletionURLToolStripMenuItem.Click += new System.EventHandler(this.copyDeletionURLToolStripMenuItem_Click);
            // 
            // showErrorsToolStripMenuItem
            // 
            this.showErrorsToolStripMenuItem.Name = "showErrorsToolStripMenuItem";
            this.showErrorsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.showErrorsToolStripMenuItem.Text = "Show Errors";
            this.showErrorsToolStripMenuItem.Click += new System.EventHandler(this.showErrorsToolStripMenuItem_Click);
            // 
            // copyErrorsToolStripMenuItem
            // 
            this.copyErrorsToolStripMenuItem.Name = "copyErrorsToolStripMenuItem";
            this.copyErrorsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.copyErrorsToolStripMenuItem.Text = "Copy Errors";
            this.copyErrorsToolStripMenuItem.Click += new System.EventHandler(this.copyErrorsToolStripMenuItem_Click);
            // 
            // showResponseToolStripMenuItem
            // 
            this.showResponseToolStripMenuItem.Name = "showResponseToolStripMenuItem";
            this.showResponseToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.showResponseToolStripMenuItem.Text = "Show Response";
            this.showResponseToolStripMenuItem.Click += new System.EventHandler(this.showResponseToolStripMenuItem_Click);
            // 
            // uploadFileToolStripMenuItem
            // 
            this.uploadFileToolStripMenuItem.Name = "uploadFileToolStripMenuItem";
            this.uploadFileToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.uploadFileToolStripMenuItem.Text = "Upload file...";
            this.uploadFileToolStripMenuItem.Click += new System.EventHandler(this.uploadFileToolStripMenuItem_Click);
            // 
            // stopUploadToolStripMenuItem
            // 
            this.stopUploadToolStripMenuItem.Name = "stopUploadToolStripMenuItem";
            this.stopUploadToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.stopUploadToolStripMenuItem.Text = "Stop upload";
            this.stopUploadToolStripMenuItem.Click += new System.EventHandler(this.stopUploadToolStripMenuItem_Click);
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClipboardUpload,
            this.tsbFileUpload,
            this.tsbDebug,
            this.tsddbCapture,
            this.tsddbDestinations,
            this.tssMain1,
            this.tsbCopy,
            this.tsbOpen,
            this.tssMain2,
            this.tsbHistory,
            this.tsbSettings,
            this.tsbAbout,
            this.tsbDonate});
            this.tsMain.Location = new System.Drawing.Point(3, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.tsMain.ShowItemToolTips = false;
            this.tsMain.Size = new System.Drawing.Size(899, 33);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbClipboardUpload
            // 
            this.tsbClipboardUpload.Image = global::ShareX.Properties.Resources.clipboard__plus;
            this.tsbClipboardUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClipboardUpload.Name = "tsbClipboardUpload";
            this.tsbClipboardUpload.Size = new System.Drawing.Size(128, 20);
            this.tsbClipboardUpload.Text = "Clipboard upload...";
            this.tsbClipboardUpload.Click += new System.EventHandler(this.tsbClipboardUpload_Click);
            // 
            // tsbFileUpload
            // 
            this.tsbFileUpload.Image = global::ShareX.Properties.Resources.folder__plus;
            this.tsbFileUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileUpload.Name = "tsbFileUpload";
            this.tsbFileUpload.Size = new System.Drawing.Size(94, 20);
            this.tsbFileUpload.Text = "File upload...";
            this.tsbFileUpload.Click += new System.EventHandler(this.tsbFileUpload_Click);
            // 
            // tsbDebug
            // 
            this.tsbDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTestImageUpload,
            this.tsmiTestTextUpload,
            this.tsmiTestShapeCapture});
            this.tsbDebug.Image = global::ShareX.Properties.Resources.gear;
            this.tsbDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDebug.Name = "tsbDebug";
            this.tsbDebug.Size = new System.Drawing.Size(58, 20);
            this.tsbDebug.Text = "Test";
            this.tsbDebug.Visible = false;
            // 
            // tsmiTestImageUpload
            // 
            this.tsmiTestImageUpload.Name = "tsmiTestImageUpload";
            this.tsmiTestImageUpload.Size = new System.Drawing.Size(173, 22);
            this.tsmiTestImageUpload.Text = "Test image upload";
            this.tsmiTestImageUpload.Click += new System.EventHandler(this.tsmiTestImageUpload_Click);
            // 
            // tsmiTestTextUpload
            // 
            this.tsmiTestTextUpload.Name = "tsmiTestTextUpload";
            this.tsmiTestTextUpload.Size = new System.Drawing.Size(173, 22);
            this.tsmiTestTextUpload.Text = "Test text upload";
            this.tsmiTestTextUpload.Click += new System.EventHandler(this.tsmiTestTextUpload_Click);
            // 
            // tsmiTestShapeCapture
            // 
            this.tsmiTestShapeCapture.Name = "tsmiTestShapeCapture";
            this.tsmiTestShapeCapture.Size = new System.Drawing.Size(173, 22);
            this.tsmiTestShapeCapture.Text = "Test shape capture";
            this.tsmiTestShapeCapture.Click += new System.EventHandler(this.tsmiTestShapeCapture_Click);
            // 
            // tsddbCapture
            // 
            this.tsddbCapture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFullscreen,
            this.tsmiWindow,
            this.tsmiWindowRectangle,
            this.tsmiRectangle,
            this.tsmiRoundedRectangle,
            this.tsmiEllipse,
            this.tsmiTriangle,
            this.tsmiDiamond,
            this.tsmiPolygon,
            this.tsmiFreeHand,
            this.tsmiLastRegion});
            this.tsddbCapture.Image = global::ShareX.Properties.Resources.camera;
            this.tsddbCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbCapture.Name = "tsddbCapture";
            this.tsddbCapture.Size = new System.Drawing.Size(78, 20);
            this.tsddbCapture.Text = "Capture";
            this.tsddbCapture.DropDownOpening += new System.EventHandler(this.tsddbCapture_DropDownOpening);
            // 
            // tsmiFullscreen
            // 
            this.tsmiFullscreen.Image = global::ShareX.Properties.Resources.Fullscreen;
            this.tsmiFullscreen.Name = "tsmiFullscreen";
            this.tsmiFullscreen.Size = new System.Drawing.Size(186, 22);
            this.tsmiFullscreen.Text = "Fullscreen";
            this.tsmiFullscreen.Click += new System.EventHandler(this.tsmiFullscreen_Click);
            // 
            // tsmiWindow
            // 
            this.tsmiWindow.Image = global::ShareX.Properties.Resources.Window;
            this.tsmiWindow.Name = "tsmiWindow";
            this.tsmiWindow.Size = new System.Drawing.Size(186, 22);
            this.tsmiWindow.Text = "Window";
            // 
            // tsmiWindowRectangle
            // 
            this.tsmiWindowRectangle.Image = global::ShareX.Properties.Resources.Window;
            this.tsmiWindowRectangle.Name = "tsmiWindowRectangle";
            this.tsmiWindowRectangle.Size = new System.Drawing.Size(186, 22);
            this.tsmiWindowRectangle.Text = "Window && Rectangle";
            this.tsmiWindowRectangle.Click += new System.EventHandler(this.tsmiWindowRectangle_Click);
            // 
            // tsmiRectangle
            // 
            this.tsmiRectangle.Image = global::ShareX.Properties.Resources.Rectangle;
            this.tsmiRectangle.Name = "tsmiRectangle";
            this.tsmiRectangle.Size = new System.Drawing.Size(186, 22);
            this.tsmiRectangle.Text = "Rectangle";
            this.tsmiRectangle.Click += new System.EventHandler(this.tsmiRectangle_Click);
            // 
            // tsmiRoundedRectangle
            // 
            this.tsmiRoundedRectangle.Image = global::ShareX.Properties.Resources.RoundedRectangle;
            this.tsmiRoundedRectangle.Name = "tsmiRoundedRectangle";
            this.tsmiRoundedRectangle.Size = new System.Drawing.Size(186, 22);
            this.tsmiRoundedRectangle.Text = "Rounded Rectangle";
            this.tsmiRoundedRectangle.Click += new System.EventHandler(this.tsmiRoundedRectangle_Click);
            // 
            // tsmiEllipse
            // 
            this.tsmiEllipse.Image = global::ShareX.Properties.Resources.Ellipse;
            this.tsmiEllipse.Name = "tsmiEllipse";
            this.tsmiEllipse.Size = new System.Drawing.Size(186, 22);
            this.tsmiEllipse.Text = "Ellipse";
            this.tsmiEllipse.Click += new System.EventHandler(this.tsmiEllipse_Click);
            // 
            // tsmiTriangle
            // 
            this.tsmiTriangle.Image = global::ShareX.Properties.Resources.Triangle;
            this.tsmiTriangle.Name = "tsmiTriangle";
            this.tsmiTriangle.Size = new System.Drawing.Size(186, 22);
            this.tsmiTriangle.Text = "Triangle";
            this.tsmiTriangle.Click += new System.EventHandler(this.tsmiTriangle_Click);
            // 
            // tsmiDiamond
            // 
            this.tsmiDiamond.Image = global::ShareX.Properties.Resources.Diamond;
            this.tsmiDiamond.Name = "tsmiDiamond";
            this.tsmiDiamond.Size = new System.Drawing.Size(186, 22);
            this.tsmiDiamond.Text = "Diamond";
            this.tsmiDiamond.Click += new System.EventHandler(this.tsmiDiamond_Click);
            // 
            // tsmiPolygon
            // 
            this.tsmiPolygon.Image = global::ShareX.Properties.Resources.Polygon;
            this.tsmiPolygon.Name = "tsmiPolygon";
            this.tsmiPolygon.Size = new System.Drawing.Size(186, 22);
            this.tsmiPolygon.Text = "Polygon";
            this.tsmiPolygon.Click += new System.EventHandler(this.tsmiPolygon_Click);
            // 
            // tsmiFreeHand
            // 
            this.tsmiFreeHand.Image = global::ShareX.Properties.Resources.FreeHand;
            this.tsmiFreeHand.Name = "tsmiFreeHand";
            this.tsmiFreeHand.Size = new System.Drawing.Size(186, 22);
            this.tsmiFreeHand.Text = "Free Hand";
            this.tsmiFreeHand.Click += new System.EventHandler(this.tsmiFreeHand_Click);
            // 
            // tsmiLastRegion
            // 
            this.tsmiLastRegion.Image = global::ShareX.Properties.Resources.Rectangle;
            this.tsmiLastRegion.Name = "tsmiLastRegion";
            this.tsmiLastRegion.Size = new System.Drawing.Size(186, 22);
            this.tsmiLastRegion.Text = "Last Region";
            this.tsmiLastRegion.Click += new System.EventHandler(this.tsmiLastRegion_Click);
            // 
            // tsddbDestinations
            // 
            this.tsddbDestinations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImageUploaders,
            this.tsmiTextUploaders,
            this.tsmiFileUploaders,
            this.tsmiURLShorteners,
            this.tssDestinations1,
            this.tsmiUploadersConfig});
            this.tsddbDestinations.Image = global::ShareX.Properties.Resources.drive_globe;
            this.tsddbDestinations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbDestinations.Name = "tsddbDestinations";
            this.tsddbDestinations.Size = new System.Drawing.Size(101, 20);
            this.tsddbDestinations.Text = "Destinations";
            // 
            // tsmiImageUploaders
            // 
            this.tsmiImageUploaders.Image = global::ShareX.Properties.Resources.image;
            this.tsmiImageUploaders.Name = "tsmiImageUploaders";
            this.tsmiImageUploaders.Size = new System.Drawing.Size(162, 22);
            this.tsmiImageUploaders.Text = "Image uploaders";
            // 
            // tsmiTextUploaders
            // 
            this.tsmiTextUploaders.Image = global::ShareX.Properties.Resources.notebook;
            this.tsmiTextUploaders.Name = "tsmiTextUploaders";
            this.tsmiTextUploaders.Size = new System.Drawing.Size(162, 22);
            this.tsmiTextUploaders.Text = "Text uploaders";
            // 
            // tsmiFileUploaders
            // 
            this.tsmiFileUploaders.Image = global::ShareX.Properties.Resources.application_block;
            this.tsmiFileUploaders.Name = "tsmiFileUploaders";
            this.tsmiFileUploaders.Size = new System.Drawing.Size(162, 22);
            this.tsmiFileUploaders.Text = "File uploaders";
            // 
            // tsmiURLShorteners
            // 
            this.tsmiURLShorteners.Image = global::ShareX.Properties.Resources.edit_scale;
            this.tsmiURLShorteners.Name = "tsmiURLShorteners";
            this.tsmiURLShorteners.Size = new System.Drawing.Size(162, 22);
            this.tsmiURLShorteners.Text = "URL shorteners";
            // 
            // tssDestinations1
            // 
            this.tssDestinations1.Name = "tssDestinations1";
            this.tssDestinations1.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmiUploadersConfig
            // 
            this.tsmiUploadersConfig.Image = global::ShareX.Properties.Resources.gear;
            this.tsmiUploadersConfig.Name = "tsmiUploadersConfig";
            this.tsmiUploadersConfig.Size = new System.Drawing.Size(162, 22);
            this.tsmiUploadersConfig.Text = "Configuration...";
            this.tsmiUploadersConfig.Click += new System.EventHandler(this.tsddbUploadersConfig_Click);
            // 
            // tssMain1
            // 
            this.tssMain1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tssMain1.Name = "tssMain1";
            this.tssMain1.Size = new System.Drawing.Size(6, 23);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Image = global::ShareX.Properties.Resources.document_copy;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(55, 20);
            this.tsbCopy.Text = "Copy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = global::ShareX.Properties.Resources.document__arrow;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(56, 20);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tssMain2
            // 
            this.tssMain2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tssMain2.Name = "tssMain2";
            this.tssMain2.Size = new System.Drawing.Size(6, 23);
            // 
            // tsbHistory
            // 
            this.tsbHistory.Image = global::ShareX.Properties.Resources.address_book_blue;
            this.tsbHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHistory.Name = "tsbHistory";
            this.tsbHistory.Size = new System.Drawing.Size(74, 20);
            this.tsbHistory.Text = "History...";
            this.tsbHistory.Click += new System.EventHandler(this.tsbHistory_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.Image = global::ShareX.Properties.Resources.application_form;
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(78, 20);
            this.tsbSettings.Text = "Settings...";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Image = global::ShareX.Properties.Resources.application_browser;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(69, 20);
            this.tsbAbout.Text = "About...";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // tsbDonate
            // 
            this.tsbDonate.Image = global::ShareX.Properties.Resources.present;
            this.tsbDonate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDonate.Name = "tsbDonate";
            this.tsbDonate.Size = new System.Drawing.Size(74, 20);
            this.tsbDonate.Text = "Donate...";
            this.tsbDonate.Click += new System.EventHandler(this.tsbDonate_Click);
            // 
            // tscMain
            // 
            this.tscMain.BottomToolStripPanelVisible = false;
            // 
            // tscMain.ContentPanel
            // 
            this.tscMain.ContentPanel.Controls.Add(this.lvUploads);
            this.tscMain.ContentPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tscMain.ContentPanel.Size = new System.Drawing.Size(902, 333);
            this.tscMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscMain.LeftToolStripPanelVisible = false;
            this.tscMain.Location = new System.Drawing.Point(0, 0);
            this.tscMain.Name = "tscMain";
            this.tscMain.RightToolStripPanelVisible = false;
            this.tscMain.Size = new System.Drawing.Size(902, 366);
            this.tscMain.TabIndex = 0;
            this.tscMain.Text = "toolStripContainer1";
            // 
            // tscMain.TopToolStripPanel
            // 
            this.tscMain.TopToolStripPanel.Controls.Add(this.tsMain);
            // 
            // lvUploads
            // 
            this.lvUploads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFilename,
            this.chStatus,
            this.chProgress,
            this.chSpeed,
            this.chElapsed,
            this.chRemaining,
            this.chUploaderType,
            this.chHost,
            this.chURL});
            this.lvUploads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUploads.FullRowSelect = true;
            this.lvUploads.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvUploads.HideSelection = false;
            this.lvUploads.Location = new System.Drawing.Point(3, 3);
            this.lvUploads.Name = "lvUploads";
            this.lvUploads.ShowItemToolTips = true;
            this.lvUploads.Size = new System.Drawing.Size(896, 327);
            this.lvUploads.TabIndex = 0;
            this.lvUploads.UseCompatibleStateImageBehavior = false;
            this.lvUploads.View = System.Windows.Forms.View.Details;
            this.lvUploads.SelectedIndexChanged += new System.EventHandler(this.lvUploads_SelectedIndexChanged);
            this.lvUploads.DoubleClick += new System.EventHandler(this.lvUploads_DoubleClick);
            this.lvUploads.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvUploads_MouseUp);
            // 
            // chFilename
            // 
            this.chFilename.Text = "Filename";
            this.chFilename.Width = 150;
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            // 
            // chProgress
            // 
            this.chProgress.Text = "Progress";
            this.chProgress.Width = 120;
            // 
            // chSpeed
            // 
            this.chSpeed.Text = "Speed";
            this.chSpeed.Width = 70;
            // 
            // chElapsed
            // 
            this.chElapsed.Text = "Elapsed";
            this.chElapsed.Width = 50;
            // 
            // chRemaining
            // 
            this.chRemaining.Text = "Remaining";
            this.chRemaining.Width = 50;
            // 
            // chUploaderType
            // 
            this.chUploaderType.Text = "Type";
            this.chUploaderType.Width = 50;
            // 
            // chHost
            // 
            this.chHost.Text = "Host";
            this.chHost.Width = 100;
            // 
            // chURL
            // 
            this.chURL.Text = "URL";
            this.chURL.Width = 247;
            // 
            // niTray
            // 
            this.niTray.ContextMenuStrip = this.cmsTray;
            this.niTray.Text = "ShareX";
            this.niTray.BalloonTipClicked += new System.EventHandler(this.niTray_BalloonTipClicked);
            this.niTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niTray_MouseDoubleClick);
            // 
            // cmsTray
            // 
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTrayClipboardUpload,
            this.tsmiTrayFileUpload,
            this.tsmiCapture,
            this.tsmiConfiguration,
            this.tssTray1,
            this.tsmiHistory,
            this.tsmiSettings,
            this.tsmiAbout,
            this.tsmiDonate,
            this.tssTray2,
            this.tsmiTrayExit});
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.Size = new System.Drawing.Size(176, 214);
            // 
            // tsmiTrayClipboardUpload
            // 
            this.tsmiTrayClipboardUpload.Image = global::ShareX.Properties.Resources.clipboard__plus;
            this.tsmiTrayClipboardUpload.Name = "tsmiTrayClipboardUpload";
            this.tsmiTrayClipboardUpload.Size = new System.Drawing.Size(175, 22);
            this.tsmiTrayClipboardUpload.Text = "Clipboard upload...";
            this.tsmiTrayClipboardUpload.Click += new System.EventHandler(this.tsbClipboardUpload_Click);
            // 
            // tsmiTrayFileUpload
            // 
            this.tsmiTrayFileUpload.Image = global::ShareX.Properties.Resources.folder__plus;
            this.tsmiTrayFileUpload.Name = "tsmiTrayFileUpload";
            this.tsmiTrayFileUpload.Size = new System.Drawing.Size(175, 22);
            this.tsmiTrayFileUpload.Text = "File upload...";
            this.tsmiTrayFileUpload.Click += new System.EventHandler(this.tsbFileUpload_Click);
            // 
            // tsmiCapture
            // 
            this.tsmiCapture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTrayFullscreen,
            this.tsmiTrayWindow,
            this.tsmiTrayWindowRectangle,
            this.tsmiTrayRectangle,
            this.tsmiTrayRoundedRectangle,
            this.tsmiTrayEllipse,
            this.tsmiTrayTriangle,
            this.tsmiTrayDiamond,
            this.tsmiTrayPolygon,
            this.tsmiTrayFreeHand,
            this.tsmiTrayLastRegion});
            this.tsmiCapture.Image = global::ShareX.Properties.Resources.camera;
            this.tsmiCapture.Name = "tsmiCapture";
            this.tsmiCapture.Size = new System.Drawing.Size(175, 22);
            this.tsmiCapture.Text = "Capture";
            this.tsmiCapture.DropDownOpening += new System.EventHandler(this.tsmiCapture_DropDownOpening);
            // 
            // tsmiTrayFullscreen
            // 
            this.tsmiTrayFullscreen.Image = global::ShareX.Properties.Resources.Fullscreen;
            this.tsmiTrayFullscreen.Name = "tsmiTrayFullscreen";
            this.tsmiTrayFullscreen.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayFullscreen.Text = "Fullscreen";
            this.tsmiTrayFullscreen.Click += new System.EventHandler(this.tsmiTrayFullscreen_Click);
            // 
            // tsmiTrayWindow
            // 
            this.tsmiTrayWindow.Image = global::ShareX.Properties.Resources.Window;
            this.tsmiTrayWindow.Name = "tsmiTrayWindow";
            this.tsmiTrayWindow.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayWindow.Text = "Window";
            // 
            // tsmiTrayWindowRectangle
            // 
            this.tsmiTrayWindowRectangle.Image = global::ShareX.Properties.Resources.Window;
            this.tsmiTrayWindowRectangle.Name = "tsmiTrayWindowRectangle";
            this.tsmiTrayWindowRectangle.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayWindowRectangle.Text = "Window && Rectangle";
            this.tsmiTrayWindowRectangle.Click += new System.EventHandler(this.tsmiTrayWindowRectangle_Click);
            // 
            // tsmiTrayRectangle
            // 
            this.tsmiTrayRectangle.Image = global::ShareX.Properties.Resources.Rectangle;
            this.tsmiTrayRectangle.Name = "tsmiTrayRectangle";
            this.tsmiTrayRectangle.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayRectangle.Text = "Rectangle";
            this.tsmiTrayRectangle.Click += new System.EventHandler(this.tsmiTrayRectangle_Click);
            // 
            // tsmiTrayRoundedRectangle
            // 
            this.tsmiTrayRoundedRectangle.Image = global::ShareX.Properties.Resources.RoundedRectangle;
            this.tsmiTrayRoundedRectangle.Name = "tsmiTrayRoundedRectangle";
            this.tsmiTrayRoundedRectangle.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayRoundedRectangle.Text = "Rounded Rectangle";
            this.tsmiTrayRoundedRectangle.Click += new System.EventHandler(this.tsmiTrayRoundedRectangle_Click);
            // 
            // tsmiTrayEllipse
            // 
            this.tsmiTrayEllipse.Image = global::ShareX.Properties.Resources.Ellipse;
            this.tsmiTrayEllipse.Name = "tsmiTrayEllipse";
            this.tsmiTrayEllipse.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayEllipse.Text = "Ellipse";
            this.tsmiTrayEllipse.Click += new System.EventHandler(this.tsmiTrayEllipse_Click);
            // 
            // tsmiTrayTriangle
            // 
            this.tsmiTrayTriangle.Image = global::ShareX.Properties.Resources.Triangle;
            this.tsmiTrayTriangle.Name = "tsmiTrayTriangle";
            this.tsmiTrayTriangle.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayTriangle.Text = "Triangle";
            this.tsmiTrayTriangle.Click += new System.EventHandler(this.tsmiTrayTriangle_Click);
            // 
            // tsmiTrayDiamond
            // 
            this.tsmiTrayDiamond.Image = global::ShareX.Properties.Resources.Diamond;
            this.tsmiTrayDiamond.Name = "tsmiTrayDiamond";
            this.tsmiTrayDiamond.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayDiamond.Text = "Diamond";
            this.tsmiTrayDiamond.Click += new System.EventHandler(this.tsmiTrayDiamond_Click);
            // 
            // tsmiTrayPolygon
            // 
            this.tsmiTrayPolygon.Image = global::ShareX.Properties.Resources.Polygon;
            this.tsmiTrayPolygon.Name = "tsmiTrayPolygon";
            this.tsmiTrayPolygon.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayPolygon.Text = "Polygon";
            this.tsmiTrayPolygon.Click += new System.EventHandler(this.tsmiTrayPolygon_Click);
            // 
            // tsmiTrayFreeHand
            // 
            this.tsmiTrayFreeHand.Image = global::ShareX.Properties.Resources.FreeHand;
            this.tsmiTrayFreeHand.Name = "tsmiTrayFreeHand";
            this.tsmiTrayFreeHand.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayFreeHand.Text = "Free Hand";
            this.tsmiTrayFreeHand.Click += new System.EventHandler(this.tsmiTrayFreeHand_Click);
            // 
            // tsmiTrayLastRegion
            // 
            this.tsmiTrayLastRegion.Image = global::ShareX.Properties.Resources.Rectangle;
            this.tsmiTrayLastRegion.Name = "tsmiTrayLastRegion";
            this.tsmiTrayLastRegion.Size = new System.Drawing.Size(186, 22);
            this.tsmiTrayLastRegion.Text = "Last Region";
            this.tsmiTrayLastRegion.Click += new System.EventHandler(this.tsmiTrayLastRegion_Click);
            // 
            // tsmiConfiguration
            // 
            this.tsmiConfiguration.Image = global::ShareX.Properties.Resources.gear;
            this.tsmiConfiguration.Name = "tsmiConfiguration";
            this.tsmiConfiguration.Size = new System.Drawing.Size(175, 22);
            this.tsmiConfiguration.Text = "Uploaders config...";
            this.tsmiConfiguration.Click += new System.EventHandler(this.tsddbUploadersConfig_Click);
            // 
            // tssTray1
            // 
            this.tssTray1.Name = "tssTray1";
            this.tssTray1.Size = new System.Drawing.Size(172, 6);
            // 
            // tsmiHistory
            // 
            this.tsmiHistory.Image = global::ShareX.Properties.Resources.address_book_blue;
            this.tsmiHistory.Name = "tsmiHistory";
            this.tsmiHistory.Size = new System.Drawing.Size(175, 22);
            this.tsmiHistory.Text = "History...";
            this.tsmiHistory.Click += new System.EventHandler(this.tsbHistory_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Image = global::ShareX.Properties.Resources.application_form;
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(175, 22);
            this.tsmiSettings.Text = "Settings...";
            this.tsmiSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = global::ShareX.Properties.Resources.application_browser;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(175, 22);
            this.tsmiAbout.Text = "About...";
            this.tsmiAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // tsmiDonate
            // 
            this.tsmiDonate.Image = global::ShareX.Properties.Resources.present;
            this.tsmiDonate.Name = "tsmiDonate";
            this.tsmiDonate.Size = new System.Drawing.Size(175, 22);
            this.tsmiDonate.Text = "Donate...";
            this.tsmiDonate.Click += new System.EventHandler(this.tsbDonate_Click);
            // 
            // tssTray2
            // 
            this.tssTray2.Name = "tssTray2";
            this.tssTray2.Size = new System.Drawing.Size(172, 6);
            // 
            // tsmiTrayExit
            // 
            this.tsmiTrayExit.Image = global::ShareX.Properties.Resources.cross_button;
            this.tsmiTrayExit.Name = "tsmiTrayExit";
            this.tsmiTrayExit.Size = new System.Drawing.Size(175, 22);
            this.tsmiTrayExit.Text = "Exit";
            this.tsmiTrayExit.Click += new System.EventHandler(this.tsmiTrayExit_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 366);
            this.Controls.Add(this.tscMain);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(910, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.cmsUploads.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.tscMain.ContentPanel.ResumeLayout(false);
            this.tscMain.TopToolStripPanel.ResumeLayout(false);
            this.tscMain.TopToolStripPanel.PerformLayout();
            this.tscMain.ResumeLayout(false);
            this.tscMain.PerformLayout();
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        private HelpersLib.MyListView lvUploads;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ColumnHeader chURL;
        private System.Windows.Forms.ContextMenuStrip cmsUploads;
        private System.Windows.Forms.ToolStripMenuItem copyURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyThumbnailURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDeletionURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyErrorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader chFilename;
        private System.Windows.Forms.ColumnHeader chProgress;
        private System.Windows.Forms.ColumnHeader chHost;
        private System.Windows.Forms.ColumnHeader chUploaderType;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbClipboardUpload;
        private System.Windows.Forms.ToolStripButton tsbFileUpload;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripSeparator tssMain1;
        private System.Windows.Forms.ToolStripSeparator tssMain2;
        private System.Windows.Forms.ToolStripContainer tscMain;
        private System.Windows.Forms.ColumnHeader chSpeed;
        private System.Windows.Forms.ColumnHeader chRemaining;
        private System.Windows.Forms.ToolStripMenuItem stopUploadToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader chElapsed;
        private System.Windows.Forms.ToolStripButton tsbHistory;
        private System.Windows.Forms.ToolStripMenuItem showErrorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showResponseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiImageUploaders;
        private System.Windows.Forms.ToolStripMenuItem tsmiTextUploaders;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileUploaders;
        private System.Windows.Forms.ToolStripMenuItem tsmiURLShorteners;
        private System.Windows.Forms.ToolStripDropDownButton tsddbDestinations;
        private System.Windows.Forms.ToolStripMenuItem copyShortenedURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator tssDestinations1;
        private System.Windows.Forms.ToolStripMenuItem tsmiUploadersConfig;
        private System.Windows.Forms.ToolStripButton tsbDonate;
        private System.Windows.Forms.ContextMenuStrip cmsTray;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayClipboardUpload;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayFileUpload;
        private System.Windows.Forms.ToolStripSeparator tssTray1;
        public System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.ToolStripDropDownButton tsddbCapture;
        private System.Windows.Forms.ToolStripMenuItem tsmiFullscreen;
        private System.Windows.Forms.ToolStripMenuItem tsmiRectangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoundedRectangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiEllipse;
        private System.Windows.Forms.ToolStripMenuItem tsmiTriangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiamond;
        private System.Windows.Forms.ToolStripMenuItem tsmiPolygon;
        private System.Windows.Forms.ToolStripMenuItem tsmiFreeHand;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindowRectangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiDonate;
        private System.Windows.Forms.ToolStripSeparator tssTray2;
        private System.Windows.Forms.ToolStripMenuItem tsmiCapture;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayFullscreen;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayWindowRectangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayRectangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayRoundedRectangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayTriangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayDiamond;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayPolygon;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayFreeHand;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfiguration;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayEllipse;
        private System.Windows.Forms.ToolStripDropDownButton tsbDebug;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestImageUpload;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestTextUpload;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestShapeCapture;
        private System.Windows.Forms.ToolStripMenuItem tsmiLastRegion;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrayLastRegion;
    }
}