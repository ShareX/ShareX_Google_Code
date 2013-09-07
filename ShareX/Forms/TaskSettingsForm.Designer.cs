namespace ShareX
{
    partial class TaskSettingsForm
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
            this.btnAfterCapture = new System.Windows.Forms.Button();
            this.cmsAfterCapture = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAfterUpload = new System.Windows.Forms.Button();
            this.btnImageUploaders = new System.Windows.Forms.Button();
            this.btnTextUploaders = new System.Windows.Forms.Button();
            this.btnFileUploaders = new System.Windows.Forms.Button();
            this.btnURLShorteners = new System.Windows.Forms.Button();
            this.btnSocialNetworkingServices = new System.Windows.Forms.Button();
            this.cmsAfterUpload = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsImageUploaders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsTextUploaders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsFileUploaders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsURLShorteners = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsSocialNetworkingServices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbUseDefaultAfterCaptureSettings = new System.Windows.Forms.CheckBox();
            this.cbUseDefaultAfterUploadSettings = new System.Windows.Forms.CheckBox();
            this.cbUseDefaultDestinationSettings = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btnTask = new System.Windows.Forms.Button();
            this.cmsTask = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tcHotkeySettings = new System.Windows.Forms.TabControl();
            this.tpTask = new System.Windows.Forms.TabPage();
            this.tpImage = new System.Windows.Forms.TabPage();
            this.tcImage = new System.Windows.Forms.TabControl();
            this.tpQuality = new System.Windows.Forms.TabPage();
            this.chkProcessImagesDuringFileUpload = new System.Windows.Forms.CheckBox();
            this.lblImageFormat = new System.Windows.Forms.Label();
            this.lblUseImageFormat2AfterHint = new System.Windows.Forms.Label();
            this.cbImageFormat = new System.Windows.Forms.ComboBox();
            this.lblImageJPEGQualityHint = new System.Windows.Forms.Label();
            this.lblImageJPEGQuality = new System.Windows.Forms.Label();
            this.cbImageGIFQuality = new System.Windows.Forms.ComboBox();
            this.lblImageGIFQuality = new System.Windows.Forms.Label();
            this.cbImageFormat2 = new System.Windows.Forms.ComboBox();
            this.nudImageJPEGQuality = new System.Windows.Forms.NumericUpDown();
            this.lblImageFormat2 = new System.Windows.Forms.Label();
            this.nudUseImageFormat2After = new System.Windows.Forms.NumericUpDown();
            this.lblUseImageFormat2After = new System.Windows.Forms.Label();
            this.tpResize = new System.Windows.Forms.TabPage();
            this.cbImageUseSmoothScaling = new System.Windows.Forms.CheckBox();
            this.cbImageKeepAspectRatio = new System.Windows.Forms.CheckBox();
            this.cbImageAutoResize = new System.Windows.Forms.CheckBox();
            this.gbImageScaleSettings = new System.Windows.Forms.GroupBox();
            this.rbImageScaleTypePercentage = new System.Windows.Forms.RadioButton();
            this.lblImageScaleToHeight2 = new System.Windows.Forms.Label();
            this.rbImageScaleTypeToWidth = new System.Windows.Forms.RadioButton();
            this.lblImageScaleSpecificWidth2 = new System.Windows.Forms.Label();
            this.rbImageScaleTypeToHeight = new System.Windows.Forms.RadioButton();
            this.lblImageScaleSpecificHeight2 = new System.Windows.Forms.Label();
            this.rbImageScaleTypeSpecific = new System.Windows.Forms.RadioButton();
            this.lblImageScaleToWidth2 = new System.Windows.Forms.Label();
            this.lblImageScalePercentageWidth = new System.Windows.Forms.Label();
            this.lblImageScalePercentageHeight2 = new System.Windows.Forms.Label();
            this.nudImageScalePercentageWidth = new System.Windows.Forms.NumericUpDown();
            this.lblImageScalePercentageWidth2 = new System.Windows.Forms.Label();
            this.lblImageScalePercentageHeight = new System.Windows.Forms.Label();
            this.nudImageScaleToHeight = new System.Windows.Forms.NumericUpDown();
            this.nudImageScalePercentageHeight = new System.Windows.Forms.NumericUpDown();
            this.nudImageScaleToWidth = new System.Windows.Forms.NumericUpDown();
            this.lblImageScaleToWidth = new System.Windows.Forms.Label();
            this.nudImageScaleSpecificHeight = new System.Windows.Forms.NumericUpDown();
            this.lblImageScaleToHeight = new System.Windows.Forms.Label();
            this.lblImageScaleSpecificHeight = new System.Windows.Forms.Label();
            this.lblImageScaleSpecificWidth = new System.Windows.Forms.Label();
            this.nudImageScaleSpecificWidth = new System.Windows.Forms.NumericUpDown();
            this.tpEffects = new System.Windows.Forms.TabPage();
            this.gbImageShadow = new System.Windows.Forms.GroupBox();
            this.lblImageShadowSize = new System.Windows.Forms.Label();
            this.lblImageShadowDarkness = new System.Windows.Forms.Label();
            this.nudImageShadowSize = new System.Windows.Forms.NumericUpDown();
            this.nudImageShadowDarkness = new System.Windows.Forms.NumericUpDown();
            this.cbImageEffectOnlyRegionCapture = new System.Windows.Forms.CheckBox();
            this.btnWatermarkSettings = new System.Windows.Forms.Button();
            this.gbBorder = new System.Windows.Forms.GroupBox();
            this.nudBorderSize = new System.Windows.Forms.NumericUpDown();
            this.btnBorderColor = new System.Windows.Forms.Button();
            this.lblBorderSize = new System.Windows.Forms.Label();
            this.lblBorderColor = new System.Windows.Forms.Label();
            this.chkUseDefaultImageSettings = new System.Windows.Forms.CheckBox();
            this.tpCapture = new System.Windows.Forms.TabPage();
            this.tcCapture = new System.Windows.Forms.TabControl();
            this.tpCaptureGeneral = new System.Windows.Forms.TabPage();
            this.cbCaptureAutoHideTaskbar = new System.Windows.Forms.CheckBox();
            this.lblScreenshotDelayInfo = new System.Windows.Forms.Label();
            this.nudScreenshotDelay = new System.Windows.Forms.NumericUpDown();
            this.cbScreenshotDelay = new System.Windows.Forms.CheckBox();
            this.nudCaptureShadowOffset = new System.Windows.Forms.NumericUpDown();
            this.cbCaptureClientArea = new System.Windows.Forms.CheckBox();
            this.cbCaptureShadow = new System.Windows.Forms.CheckBox();
            this.cbShowCursor = new System.Windows.Forms.CheckBox();
            this.cbCaptureTransparent = new System.Windows.Forms.CheckBox();
            this.tpCaptureShape = new System.Windows.Forms.TabPage();
            this.btnOpenCapturingShapesWiki = new System.Windows.Forms.Button();
            this.cbShapeForceWindowCapture = new System.Windows.Forms.CheckBox();
            this.cbShapeIncludeControls = new System.Windows.Forms.CheckBox();
            this.lblFixedShapeSizeHeight = new System.Windows.Forms.Label();
            this.cbDrawBorder = new System.Windows.Forms.CheckBox();
            this.lblFixedShapeSizeWidth = new System.Windows.Forms.Label();
            this.cbCaptureMultipleShapes = new System.Windows.Forms.CheckBox();
            this.nudFixedShapeSizeHeight = new System.Windows.Forms.NumericUpDown();
            this.cbDrawCheckerboard = new System.Windows.Forms.CheckBox();
            this.nudFixedShapeSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.cbFixedShapeSize = new System.Windows.Forms.CheckBox();
            this.tpScreenRecorder = new System.Windows.Forms.TabPage();
            this.cbOutput = new System.Windows.Forms.ComboBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.cbFixedDuration = new System.Windows.Forms.CheckBox();
            this.nudFPS = new System.Windows.Forms.NumericUpDown();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblFPS = new System.Windows.Forms.Label();
            this.gbCommandLineEncoderSettings = new System.Windows.Forms.GroupBox();
            this.btnBrowseCommandLinePath = new System.Windows.Forms.Button();
            this.lblCommandLineOutputExtension = new System.Windows.Forms.Label();
            this.lblCommandLineArgs = new System.Windows.Forms.Label();
            this.lblCommandLinePath = new System.Windows.Forms.Label();
            this.tbCommandLineArgs = new System.Windows.Forms.TextBox();
            this.tbCommandLineOutputExtension = new System.Windows.Forms.TextBox();
            this.tbCommandLinePath = new System.Windows.Forms.TextBox();
            this.chkUseDefaultCaptureSettings = new System.Windows.Forms.CheckBox();
            this.tpActions = new System.Windows.Forms.TabPage();
            this.pActions = new System.Windows.Forms.Panel();
            this.btnActionsAdd = new System.Windows.Forms.Button();
            this.lvActions = new HelpersLib.MyListView();
            this.chActionsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chActionsPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chActionsArgs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnActionsEdit = new System.Windows.Forms.Button();
            this.btnActionsRemove = new System.Windows.Forms.Button();
            this.chkUseDefaultActions = new System.Windows.Forms.CheckBox();
            this.tpUpload = new System.Windows.Forms.TabPage();
            this.tcUpload = new System.Windows.Forms.TabControl();
            this.tpUploadNamePattern = new System.Windows.Forms.TabPage();
            this.cbFileUploadUseNamePattern = new System.Windows.Forms.CheckBox();
            this.lblNameFormatPattern = new System.Windows.Forms.Label();
            this.txtNameFormatPatternActiveWindow = new System.Windows.Forms.TextBox();
            this.btnResetAutoIncrementNumber = new System.Windows.Forms.Button();
            this.lblNameFormatPatternActiveWindow = new System.Windows.Forms.Label();
            this.txtNameFormatPattern = new System.Windows.Forms.TextBox();
            this.lblNameFormatPatternPreview = new System.Windows.Forms.Label();
            this.lblNameFormatPatternPreviewActiveWindow = new System.Windows.Forms.Label();
            this.tpUploadClipboard = new System.Windows.Forms.TabPage();
            this.cbShowClipboardContentViewer = new System.Windows.Forms.CheckBox();
            this.cbClipboardUploadAutoDetectURL = new System.Windows.Forms.CheckBox();
            this.chkUseDefaultUploadSettings = new System.Windows.Forms.CheckBox();
            this.tpWatchFolders = new System.Windows.Forms.TabPage();
            this.cbWatchFolderEnabled = new System.Windows.Forms.CheckBox();
            this.lvWatchFolderList = new System.Windows.Forms.ListView();
            this.chWatchFolderFolderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWatchFolderFilter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWatchFolderIncludeSubdirectories = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnWatchFolderRemove = new System.Windows.Forms.Button();
            this.btnWatchFolderAdd = new System.Windows.Forms.Button();
            this.tpAdvanced = new System.Windows.Forms.TabPage();
            this.pgTaskSettings = new System.Windows.Forms.PropertyGrid();
            this.chkUseDefaultAdvancedSettings = new System.Windows.Forms.CheckBox();
            this.tcHotkeySettings.SuspendLayout();
            this.tpTask.SuspendLayout();
            this.tpImage.SuspendLayout();
            this.tcImage.SuspendLayout();
            this.tpQuality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageJPEGQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUseImageFormat2After)).BeginInit();
            this.tpResize.SuspendLayout();
            this.gbImageScaleSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScalePercentageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScaleToHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScalePercentageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScaleToWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScaleSpecificHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScaleSpecificWidth)).BeginInit();
            this.tpEffects.SuspendLayout();
            this.gbImageShadow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageShadowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageShadowDarkness)).BeginInit();
            this.gbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderSize)).BeginInit();
            this.tpCapture.SuspendLayout();
            this.tcCapture.SuspendLayout();
            this.tpCaptureGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenshotDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaptureShadowOffset)).BeginInit();
            this.tpCaptureShape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedShapeSizeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedShapeSizeWidth)).BeginInit();
            this.tpScreenRecorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.gbCommandLineEncoderSettings.SuspendLayout();
            this.tpActions.SuspendLayout();
            this.pActions.SuspendLayout();
            this.tpUpload.SuspendLayout();
            this.tcUpload.SuspendLayout();
            this.tpUploadNamePattern.SuspendLayout();
            this.tpUploadClipboard.SuspendLayout();
            this.tpWatchFolders.SuspendLayout();
            this.tpAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAfterCapture
            // 
            this.btnAfterCapture.Location = new System.Drawing.Point(6, 93);
            this.btnAfterCapture.Name = "btnAfterCapture";
            this.btnAfterCapture.Size = new System.Drawing.Size(506, 23);
            this.btnAfterCapture.TabIndex = 4;
            this.btnAfterCapture.Text = "After capture...";
            this.btnAfterCapture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAfterCapture.UseMnemonic = false;
            this.btnAfterCapture.UseVisualStyleBackColor = true;
            this.btnAfterCapture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAfterCapture_MouseClick);
            // 
            // cmsAfterCapture
            // 
            this.cmsAfterCapture.Name = "cmsAfterCapture";
            this.cmsAfterCapture.Size = new System.Drawing.Size(61, 4);
            // 
            // btnAfterUpload
            // 
            this.btnAfterUpload.Location = new System.Drawing.Point(6, 149);
            this.btnAfterUpload.Name = "btnAfterUpload";
            this.btnAfterUpload.Size = new System.Drawing.Size(506, 23);
            this.btnAfterUpload.TabIndex = 6;
            this.btnAfterUpload.Text = "After upload...";
            this.btnAfterUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAfterUpload.UseMnemonic = false;
            this.btnAfterUpload.UseVisualStyleBackColor = true;
            this.btnAfterUpload.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAfterUpload_MouseClick);
            // 
            // btnImageUploaders
            // 
            this.btnImageUploaders.Location = new System.Drawing.Point(6, 205);
            this.btnImageUploaders.Name = "btnImageUploaders";
            this.btnImageUploaders.Size = new System.Drawing.Size(506, 23);
            this.btnImageUploaders.TabIndex = 8;
            this.btnImageUploaders.Text = "Image uploaders";
            this.btnImageUploaders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImageUploaders.UseMnemonic = false;
            this.btnImageUploaders.UseVisualStyleBackColor = true;
            this.btnImageUploaders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnImageUploaders_MouseClick);
            // 
            // btnTextUploaders
            // 
            this.btnTextUploaders.Location = new System.Drawing.Point(6, 229);
            this.btnTextUploaders.Name = "btnTextUploaders";
            this.btnTextUploaders.Size = new System.Drawing.Size(506, 23);
            this.btnTextUploaders.TabIndex = 9;
            this.btnTextUploaders.Text = "Text uploaders";
            this.btnTextUploaders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTextUploaders.UseMnemonic = false;
            this.btnTextUploaders.UseVisualStyleBackColor = true;
            this.btnTextUploaders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnTextUploaders_MouseClick);
            // 
            // btnFileUploaders
            // 
            this.btnFileUploaders.Location = new System.Drawing.Point(6, 253);
            this.btnFileUploaders.Name = "btnFileUploaders";
            this.btnFileUploaders.Size = new System.Drawing.Size(506, 23);
            this.btnFileUploaders.TabIndex = 10;
            this.btnFileUploaders.Text = "File uploaders";
            this.btnFileUploaders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFileUploaders.UseMnemonic = false;
            this.btnFileUploaders.UseVisualStyleBackColor = true;
            this.btnFileUploaders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnFileUploaders_MouseClick);
            // 
            // btnURLShorteners
            // 
            this.btnURLShorteners.Location = new System.Drawing.Point(6, 277);
            this.btnURLShorteners.Name = "btnURLShorteners";
            this.btnURLShorteners.Size = new System.Drawing.Size(506, 23);
            this.btnURLShorteners.TabIndex = 11;
            this.btnURLShorteners.Text = "URL shorteners";
            this.btnURLShorteners.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnURLShorteners.UseMnemonic = false;
            this.btnURLShorteners.UseVisualStyleBackColor = true;
            this.btnURLShorteners.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnURLShorteners_MouseClick);
            // 
            // btnSocialNetworkingServices
            // 
            this.btnSocialNetworkingServices.Location = new System.Drawing.Point(6, 301);
            this.btnSocialNetworkingServices.Name = "btnSocialNetworkingServices";
            this.btnSocialNetworkingServices.Size = new System.Drawing.Size(506, 23);
            this.btnSocialNetworkingServices.TabIndex = 12;
            this.btnSocialNetworkingServices.Text = "Social networking services";
            this.btnSocialNetworkingServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSocialNetworkingServices.UseMnemonic = false;
            this.btnSocialNetworkingServices.UseVisualStyleBackColor = true;
            this.btnSocialNetworkingServices.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSocialNetworkingServices_MouseClick);
            // 
            // cmsAfterUpload
            // 
            this.cmsAfterUpload.Name = "cmsAfterCapture";
            this.cmsAfterUpload.Size = new System.Drawing.Size(61, 4);
            // 
            // cmsImageUploaders
            // 
            this.cmsImageUploaders.Name = "cmsAfterCapture";
            this.cmsImageUploaders.Size = new System.Drawing.Size(61, 4);
            // 
            // cmsTextUploaders
            // 
            this.cmsTextUploaders.Name = "cmsAfterCapture";
            this.cmsTextUploaders.Size = new System.Drawing.Size(61, 4);
            // 
            // cmsFileUploaders
            // 
            this.cmsFileUploaders.Name = "cmsAfterCapture";
            this.cmsFileUploaders.Size = new System.Drawing.Size(61, 4);
            // 
            // cmsURLShorteners
            // 
            this.cmsURLShorteners.Name = "cmsAfterCapture";
            this.cmsURLShorteners.Size = new System.Drawing.Size(61, 4);
            // 
            // cmsSocialNetworkingServices
            // 
            this.cmsSocialNetworkingServices.Name = "cmsAfterCapture";
            this.cmsSocialNetworkingServices.Size = new System.Drawing.Size(61, 4);
            // 
            // cbUseDefaultAfterCaptureSettings
            // 
            this.cbUseDefaultAfterCaptureSettings.AutoSize = true;
            this.cbUseDefaultAfterCaptureSettings.Location = new System.Drawing.Point(6, 69);
            this.cbUseDefaultAfterCaptureSettings.Name = "cbUseDefaultAfterCaptureSettings";
            this.cbUseDefaultAfterCaptureSettings.Size = new System.Drawing.Size(193, 17);
            this.cbUseDefaultAfterCaptureSettings.TabIndex = 3;
            this.cbUseDefaultAfterCaptureSettings.Text = "Use default \"After capture\" settings";
            this.cbUseDefaultAfterCaptureSettings.UseVisualStyleBackColor = true;
            this.cbUseDefaultAfterCaptureSettings.CheckedChanged += new System.EventHandler(this.cbUseDefaultAfterCaptureSettings_CheckedChanged);
            // 
            // cbUseDefaultAfterUploadSettings
            // 
            this.cbUseDefaultAfterUploadSettings.AutoSize = true;
            this.cbUseDefaultAfterUploadSettings.Location = new System.Drawing.Point(6, 125);
            this.cbUseDefaultAfterUploadSettings.Name = "cbUseDefaultAfterUploadSettings";
            this.cbUseDefaultAfterUploadSettings.Size = new System.Drawing.Size(189, 17);
            this.cbUseDefaultAfterUploadSettings.TabIndex = 5;
            this.cbUseDefaultAfterUploadSettings.Text = "Use default \"After upload\" settings";
            this.cbUseDefaultAfterUploadSettings.UseVisualStyleBackColor = true;
            this.cbUseDefaultAfterUploadSettings.CheckedChanged += new System.EventHandler(this.cbUseDefaultAfterUploadSettings_CheckedChanged);
            // 
            // cbUseDefaultDestinationSettings
            // 
            this.cbUseDefaultDestinationSettings.AutoSize = true;
            this.cbUseDefaultDestinationSettings.Location = new System.Drawing.Point(6, 181);
            this.cbUseDefaultDestinationSettings.Name = "cbUseDefaultDestinationSettings";
            this.cbUseDefaultDestinationSettings.Size = new System.Drawing.Size(185, 17);
            this.cbUseDefaultDestinationSettings.TabIndex = 7;
            this.cbUseDefaultDestinationSettings.Text = "Use default \"Destination\" settings";
            this.cbUseDefaultDestinationSettings.UseVisualStyleBackColor = true;
            this.cbUseDefaultDestinationSettings.CheckedChanged += new System.EventHandler(this.cbUseDefaultDestinationSettings_CheckedChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 13);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(78, 9);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(434, 20);
            this.tbDescription.TabIndex = 1;
            this.tbDescription.TextChanged += new System.EventHandler(this.tbDescription_TextChanged);
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(6, 37);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(506, 23);
            this.btnTask.TabIndex = 2;
            this.btnTask.Text = "Task...";
            this.btnTask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTask.UseMnemonic = false;
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnTask_MouseClick);
            // 
            // cmsTask
            // 
            this.cmsTask.Name = "cmsAfterCapture";
            this.cmsTask.Size = new System.Drawing.Size(61, 4);
            // 
            // tcHotkeySettings
            // 
            this.tcHotkeySettings.Controls.Add(this.tpTask);
            this.tcHotkeySettings.Controls.Add(this.tpImage);
            this.tcHotkeySettings.Controls.Add(this.tpCapture);
            this.tcHotkeySettings.Controls.Add(this.tpActions);
            this.tcHotkeySettings.Controls.Add(this.tpUpload);
            this.tcHotkeySettings.Controls.Add(this.tpWatchFolders);
            this.tcHotkeySettings.Controls.Add(this.tpAdvanced);
            this.tcHotkeySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcHotkeySettings.Location = new System.Drawing.Point(3, 3);
            this.tcHotkeySettings.Name = "tcHotkeySettings";
            this.tcHotkeySettings.SelectedIndex = 0;
            this.tcHotkeySettings.Size = new System.Drawing.Size(528, 386);
            this.tcHotkeySettings.TabIndex = 0;
            // 
            // tpTask
            // 
            this.tpTask.Controls.Add(this.tbDescription);
            this.tpTask.Controls.Add(this.btnAfterCapture);
            this.tpTask.Controls.Add(this.btnAfterUpload);
            this.tpTask.Controls.Add(this.btnImageUploaders);
            this.tpTask.Controls.Add(this.btnTextUploaders);
            this.tpTask.Controls.Add(this.btnFileUploaders);
            this.tpTask.Controls.Add(this.btnURLShorteners);
            this.tpTask.Controls.Add(this.btnSocialNetworkingServices);
            this.tpTask.Controls.Add(this.cbUseDefaultAfterCaptureSettings);
            this.tpTask.Controls.Add(this.btnTask);
            this.tpTask.Controls.Add(this.cbUseDefaultAfterUploadSettings);
            this.tpTask.Controls.Add(this.cbUseDefaultDestinationSettings);
            this.tpTask.Controls.Add(this.lblDescription);
            this.tpTask.Location = new System.Drawing.Point(4, 22);
            this.tpTask.Name = "tpTask";
            this.tpTask.Padding = new System.Windows.Forms.Padding(3);
            this.tpTask.Size = new System.Drawing.Size(520, 360);
            this.tpTask.TabIndex = 0;
            this.tpTask.Text = "Task";
            this.tpTask.UseVisualStyleBackColor = true;
            // 
            // tpImage
            // 
            this.tpImage.Controls.Add(this.tcImage);
            this.tpImage.Controls.Add(this.chkUseDefaultImageSettings);
            this.tpImage.Location = new System.Drawing.Point(4, 22);
            this.tpImage.Name = "tpImage";
            this.tpImage.Padding = new System.Windows.Forms.Padding(3);
            this.tpImage.Size = new System.Drawing.Size(520, 360);
            this.tpImage.TabIndex = 1;
            this.tpImage.Text = "Image";
            this.tpImage.UseVisualStyleBackColor = true;
            // 
            // tcImage
            // 
            this.tcImage.Controls.Add(this.tpQuality);
            this.tcImage.Controls.Add(this.tpResize);
            this.tcImage.Controls.Add(this.tpEffects);
            this.tcImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcImage.Location = new System.Drawing.Point(3, 30);
            this.tcImage.Name = "tcImage";
            this.tcImage.SelectedIndex = 0;
            this.tcImage.Size = new System.Drawing.Size(514, 327);
            this.tcImage.TabIndex = 1;
            // 
            // tpQuality
            // 
            this.tpQuality.Controls.Add(this.chkProcessImagesDuringFileUpload);
            this.tpQuality.Controls.Add(this.lblImageFormat);
            this.tpQuality.Controls.Add(this.lblUseImageFormat2AfterHint);
            this.tpQuality.Controls.Add(this.cbImageFormat);
            this.tpQuality.Controls.Add(this.lblImageJPEGQualityHint);
            this.tpQuality.Controls.Add(this.lblImageJPEGQuality);
            this.tpQuality.Controls.Add(this.cbImageGIFQuality);
            this.tpQuality.Controls.Add(this.lblImageGIFQuality);
            this.tpQuality.Controls.Add(this.cbImageFormat2);
            this.tpQuality.Controls.Add(this.nudImageJPEGQuality);
            this.tpQuality.Controls.Add(this.lblImageFormat2);
            this.tpQuality.Controls.Add(this.nudUseImageFormat2After);
            this.tpQuality.Controls.Add(this.lblUseImageFormat2After);
            this.tpQuality.Location = new System.Drawing.Point(4, 22);
            this.tpQuality.Name = "tpQuality";
            this.tpQuality.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuality.Size = new System.Drawing.Size(506, 301);
            this.tpQuality.TabIndex = 0;
            this.tpQuality.Text = "Quality";
            this.tpQuality.UseVisualStyleBackColor = true;
            // 
            // chkProcessImagesDuringFileUpload
            // 
            this.chkProcessImagesDuringFileUpload.AutoSize = true;
            this.chkProcessImagesDuringFileUpload.Location = new System.Drawing.Point(16, 176);
            this.chkProcessImagesDuringFileUpload.Name = "chkProcessImagesDuringFileUpload";
            this.chkProcessImagesDuringFileUpload.Size = new System.Drawing.Size(261, 17);
            this.chkProcessImagesDuringFileUpload.TabIndex = 12;
            this.chkProcessImagesDuringFileUpload.Text = "Process images during file upload and drag && drop";
            this.chkProcessImagesDuringFileUpload.UseVisualStyleBackColor = true;
            this.chkProcessImagesDuringFileUpload.CheckedChanged += new System.EventHandler(this.cbUseImageFormat2FileUpload_CheckedChanged);
            // 
            // lblImageFormat
            // 
            this.lblImageFormat.AutoSize = true;
            this.lblImageFormat.Location = new System.Drawing.Point(16, 16);
            this.lblImageFormat.Name = "lblImageFormat";
            this.lblImageFormat.Size = new System.Drawing.Size(71, 13);
            this.lblImageFormat.TabIndex = 0;
            this.lblImageFormat.Text = "Image format:";
            // 
            // lblUseImageFormat2AfterHint
            // 
            this.lblUseImageFormat2AfterHint.AutoSize = true;
            this.lblUseImageFormat2AfterHint.Location = new System.Drawing.Point(288, 112);
            this.lblUseImageFormat2AfterHint.Name = "lblUseImageFormat2AfterHint";
            this.lblUseImageFormat2AfterHint.Size = new System.Drawing.Size(121, 13);
            this.lblUseImageFormat2AfterHint.TabIndex = 9;
            this.lblUseImageFormat2AfterHint.Text = "kB  0 - 5000 (0 disables)";
            // 
            // cbImageFormat
            // 
            this.cbImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageFormat.FormattingEnabled = true;
            this.cbImageFormat.Items.AddRange(new object[] {
            "PNG",
            "JPEG",
            "GIF",
            "BMP",
            "TIFF"});
            this.cbImageFormat.Location = new System.Drawing.Point(104, 12);
            this.cbImageFormat.Name = "cbImageFormat";
            this.cbImageFormat.Size = new System.Drawing.Size(56, 21);
            this.cbImageFormat.TabIndex = 1;
            this.cbImageFormat.SelectedIndexChanged += new System.EventHandler(this.cbImageFormat_SelectedIndexChanged);
            // 
            // lblImageJPEGQualityHint
            // 
            this.lblImageJPEGQualityHint.AutoSize = true;
            this.lblImageJPEGQualityHint.Location = new System.Drawing.Point(168, 48);
            this.lblImageJPEGQualityHint.Name = "lblImageJPEGQualityHint";
            this.lblImageJPEGQualityHint.Size = new System.Drawing.Size(40, 13);
            this.lblImageJPEGQualityHint.TabIndex = 4;
            this.lblImageJPEGQualityHint.Text = "0 - 100";
            // 
            // lblImageJPEGQuality
            // 
            this.lblImageJPEGQuality.AutoSize = true;
            this.lblImageJPEGQuality.Location = new System.Drawing.Point(16, 48);
            this.lblImageJPEGQuality.Name = "lblImageJPEGQuality";
            this.lblImageJPEGQuality.Size = new System.Drawing.Size(70, 13);
            this.lblImageJPEGQuality.TabIndex = 2;
            this.lblImageJPEGQuality.Text = "JPEG quality:";
            // 
            // cbImageGIFQuality
            // 
            this.cbImageGIFQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageGIFQuality.FormattingEnabled = true;
            this.cbImageGIFQuality.Items.AddRange(new object[] {
            "Default (Fast)",
            "256 colors (8 bit)",
            "16 colors (4 bit)",
            "Grayscale"});
            this.cbImageGIFQuality.Location = new System.Drawing.Point(104, 76);
            this.cbImageGIFQuality.Name = "cbImageGIFQuality";
            this.cbImageGIFQuality.Size = new System.Drawing.Size(120, 21);
            this.cbImageGIFQuality.TabIndex = 6;
            this.cbImageGIFQuality.SelectedIndexChanged += new System.EventHandler(this.cbImageGIFQuality_SelectedIndexChanged);
            // 
            // lblImageGIFQuality
            // 
            this.lblImageGIFQuality.AutoSize = true;
            this.lblImageGIFQuality.Location = new System.Drawing.Point(16, 80);
            this.lblImageGIFQuality.Name = "lblImageGIFQuality";
            this.lblImageGIFQuality.Size = new System.Drawing.Size(60, 13);
            this.lblImageGIFQuality.TabIndex = 5;
            this.lblImageGIFQuality.Text = "GIF quality:";
            // 
            // cbImageFormat2
            // 
            this.cbImageFormat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageFormat2.FormattingEnabled = true;
            this.cbImageFormat2.Items.AddRange(new object[] {
            "PNG",
            "JPEG",
            "GIF",
            "BMP",
            "TIFF"});
            this.cbImageFormat2.Location = new System.Drawing.Point(104, 140);
            this.cbImageFormat2.Name = "cbImageFormat2";
            this.cbImageFormat2.Size = new System.Drawing.Size(56, 21);
            this.cbImageFormat2.TabIndex = 11;
            this.cbImageFormat2.SelectedIndexChanged += new System.EventHandler(this.cbImageFormat2_SelectedIndexChanged);
            // 
            // nudImageJPEGQuality
            // 
            this.nudImageJPEGQuality.Location = new System.Drawing.Point(104, 44);
            this.nudImageJPEGQuality.Name = "nudImageJPEGQuality";
            this.nudImageJPEGQuality.Size = new System.Drawing.Size(56, 20);
            this.nudImageJPEGQuality.TabIndex = 3;
            this.nudImageJPEGQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudImageJPEGQuality.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudImageJPEGQuality.ValueChanged += new System.EventHandler(this.nudImageJPEGQuality_ValueChanged);
            // 
            // lblImageFormat2
            // 
            this.lblImageFormat2.AutoSize = true;
            this.lblImageFormat2.Location = new System.Drawing.Point(16, 144);
            this.lblImageFormat2.Name = "lblImageFormat2";
            this.lblImageFormat2.Size = new System.Drawing.Size(80, 13);
            this.lblImageFormat2.TabIndex = 10;
            this.lblImageFormat2.Text = "Image format 2:";
            // 
            // nudUseImageFormat2After
            // 
            this.nudUseImageFormat2After.Location = new System.Drawing.Point(224, 108);
            this.nudUseImageFormat2After.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudUseImageFormat2After.Name = "nudUseImageFormat2After";
            this.nudUseImageFormat2After.Size = new System.Drawing.Size(56, 20);
            this.nudUseImageFormat2After.TabIndex = 8;
            this.nudUseImageFormat2After.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudUseImageFormat2After.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudUseImageFormat2After.ValueChanged += new System.EventHandler(this.nudUseImageFormat2After_ValueChanged);
            // 
            // lblUseImageFormat2After
            // 
            this.lblUseImageFormat2After.AutoSize = true;
            this.lblUseImageFormat2After.Location = new System.Drawing.Point(16, 112);
            this.lblUseImageFormat2After.Name = "lblUseImageFormat2After";
            this.lblUseImageFormat2After.Size = new System.Drawing.Size(198, 13);
            this.lblUseImageFormat2After.TabIndex = 7;
            this.lblUseImageFormat2After.Text = "Image size limit for use \"Image format 2\":";
            // 
            // tpResize
            // 
            this.tpResize.Controls.Add(this.cbImageUseSmoothScaling);
            this.tpResize.Controls.Add(this.cbImageKeepAspectRatio);
            this.tpResize.Controls.Add(this.cbImageAutoResize);
            this.tpResize.Controls.Add(this.gbImageScaleSettings);
            this.tpResize.Location = new System.Drawing.Point(4, 22);
            this.tpResize.Name = "tpResize";
            this.tpResize.Padding = new System.Windows.Forms.Padding(3);
            this.tpResize.Size = new System.Drawing.Size(506, 301);
            this.tpResize.TabIndex = 1;
            this.tpResize.Text = "Resize";
            this.tpResize.UseVisualStyleBackColor = true;
            // 
            // cbImageUseSmoothScaling
            // 
            this.cbImageUseSmoothScaling.AutoSize = true;
            this.cbImageUseSmoothScaling.Location = new System.Drawing.Point(16, 64);
            this.cbImageUseSmoothScaling.Name = "cbImageUseSmoothScaling";
            this.cbImageUseSmoothScaling.Size = new System.Drawing.Size(183, 17);
            this.cbImageUseSmoothScaling.TabIndex = 2;
            this.cbImageUseSmoothScaling.Text = "Use smooth scaling (Anti aliasing)";
            this.cbImageUseSmoothScaling.UseVisualStyleBackColor = true;
            this.cbImageUseSmoothScaling.CheckedChanged += new System.EventHandler(this.cbImageUseSmoothScaling_CheckedChanged);
            // 
            // cbImageKeepAspectRatio
            // 
            this.cbImageKeepAspectRatio.AutoSize = true;
            this.cbImageKeepAspectRatio.Location = new System.Drawing.Point(16, 40);
            this.cbImageKeepAspectRatio.Name = "cbImageKeepAspectRatio";
            this.cbImageKeepAspectRatio.Size = new System.Drawing.Size(109, 17);
            this.cbImageKeepAspectRatio.TabIndex = 1;
            this.cbImageKeepAspectRatio.Text = "Keep aspect ratio";
            this.cbImageKeepAspectRatio.UseVisualStyleBackColor = true;
            this.cbImageKeepAspectRatio.CheckedChanged += new System.EventHandler(this.cbImageKeepAspectRatio_CheckedChanged);
            // 
            // cbImageAutoResize
            // 
            this.cbImageAutoResize.AutoSize = true;
            this.cbImageAutoResize.Location = new System.Drawing.Point(16, 16);
            this.cbImageAutoResize.Name = "cbImageAutoResize";
            this.cbImageAutoResize.Size = new System.Drawing.Size(149, 17);
            this.cbImageAutoResize.TabIndex = 0;
            this.cbImageAutoResize.Text = "Automatically resize image";
            this.cbImageAutoResize.UseVisualStyleBackColor = true;
            this.cbImageAutoResize.CheckedChanged += new System.EventHandler(this.cbImageAutoResize_CheckedChanged);
            // 
            // gbImageScaleSettings
            // 
            this.gbImageScaleSettings.Controls.Add(this.rbImageScaleTypePercentage);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScaleToHeight2);
            this.gbImageScaleSettings.Controls.Add(this.rbImageScaleTypeToWidth);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScaleSpecificWidth2);
            this.gbImageScaleSettings.Controls.Add(this.rbImageScaleTypeToHeight);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScaleSpecificHeight2);
            this.gbImageScaleSettings.Controls.Add(this.rbImageScaleTypeSpecific);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScaleToWidth2);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScalePercentageWidth);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScalePercentageHeight2);
            this.gbImageScaleSettings.Controls.Add(this.nudImageScalePercentageWidth);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScalePercentageWidth2);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScalePercentageHeight);
            this.gbImageScaleSettings.Controls.Add(this.nudImageScaleToHeight);
            this.gbImageScaleSettings.Controls.Add(this.nudImageScalePercentageHeight);
            this.gbImageScaleSettings.Controls.Add(this.nudImageScaleToWidth);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScaleToWidth);
            this.gbImageScaleSettings.Controls.Add(this.nudImageScaleSpecificHeight);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScaleToHeight);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScaleSpecificHeight);
            this.gbImageScaleSettings.Controls.Add(this.lblImageScaleSpecificWidth);
            this.gbImageScaleSettings.Controls.Add(this.nudImageScaleSpecificWidth);
            this.gbImageScaleSettings.Location = new System.Drawing.Point(288, 8);
            this.gbImageScaleSettings.Name = "gbImageScaleSettings";
            this.gbImageScaleSettings.Size = new System.Drawing.Size(200, 272);
            this.gbImageScaleSettings.TabIndex = 3;
            this.gbImageScaleSettings.TabStop = false;
            this.gbImageScaleSettings.Text = "Scale settings";
            // 
            // rbImageScaleTypePercentage
            // 
            this.rbImageScaleTypePercentage.AutoSize = true;
            this.rbImageScaleTypePercentage.Location = new System.Drawing.Point(16, 24);
            this.rbImageScaleTypePercentage.Name = "rbImageScaleTypePercentage";
            this.rbImageScaleTypePercentage.Size = new System.Drawing.Size(123, 17);
            this.rbImageScaleTypePercentage.TabIndex = 0;
            this.rbImageScaleTypePercentage.TabStop = true;
            this.rbImageScaleTypePercentage.Text = "Scale by percentage";
            this.rbImageScaleTypePercentage.UseVisualStyleBackColor = true;
            this.rbImageScaleTypePercentage.CheckedChanged += new System.EventHandler(this.rbImageScaleTypePercentage_CheckedChanged);
            // 
            // lblImageScaleToHeight2
            // 
            this.lblImageScaleToHeight2.AutoSize = true;
            this.lblImageScaleToHeight2.Location = new System.Drawing.Point(144, 172);
            this.lblImageScaleToHeight2.Name = "lblImageScaleToHeight2";
            this.lblImageScaleToHeight2.Size = new System.Drawing.Size(33, 13);
            this.lblImageScaleToHeight2.TabIndex = 14;
            this.lblImageScaleToHeight2.Text = "pixels";
            // 
            // rbImageScaleTypeToWidth
            // 
            this.rbImageScaleTypeToWidth.AutoSize = true;
            this.rbImageScaleTypeToWidth.Location = new System.Drawing.Point(16, 96);
            this.rbImageScaleTypeToWidth.Name = "rbImageScaleTypeToWidth";
            this.rbImageScaleTypeToWidth.Size = new System.Drawing.Size(92, 17);
            this.rbImageScaleTypeToWidth.TabIndex = 7;
            this.rbImageScaleTypeToWidth.TabStop = true;
            this.rbImageScaleTypeToWidth.Text = "Scale to width";
            this.rbImageScaleTypeToWidth.UseVisualStyleBackColor = true;
            this.rbImageScaleTypeToWidth.CheckedChanged += new System.EventHandler(this.rbImageScaleTypeToWidth_CheckedChanged);
            // 
            // lblImageScaleSpecificWidth2
            // 
            this.lblImageScaleSpecificWidth2.AutoSize = true;
            this.lblImageScaleSpecificWidth2.Location = new System.Drawing.Point(144, 220);
            this.lblImageScaleSpecificWidth2.Name = "lblImageScaleSpecificWidth2";
            this.lblImageScaleSpecificWidth2.Size = new System.Drawing.Size(33, 13);
            this.lblImageScaleSpecificWidth2.TabIndex = 18;
            this.lblImageScaleSpecificWidth2.Text = "pixels";
            // 
            // rbImageScaleTypeToHeight
            // 
            this.rbImageScaleTypeToHeight.AutoSize = true;
            this.rbImageScaleTypeToHeight.Location = new System.Drawing.Point(16, 144);
            this.rbImageScaleTypeToHeight.Name = "rbImageScaleTypeToHeight";
            this.rbImageScaleTypeToHeight.Size = new System.Drawing.Size(96, 17);
            this.rbImageScaleTypeToHeight.TabIndex = 11;
            this.rbImageScaleTypeToHeight.TabStop = true;
            this.rbImageScaleTypeToHeight.Text = "Scale to height";
            this.rbImageScaleTypeToHeight.UseVisualStyleBackColor = true;
            this.rbImageScaleTypeToHeight.CheckedChanged += new System.EventHandler(this.rbImageScaleTypeToHeight_CheckedChanged);
            // 
            // lblImageScaleSpecificHeight2
            // 
            this.lblImageScaleSpecificHeight2.AutoSize = true;
            this.lblImageScaleSpecificHeight2.Location = new System.Drawing.Point(144, 244);
            this.lblImageScaleSpecificHeight2.Name = "lblImageScaleSpecificHeight2";
            this.lblImageScaleSpecificHeight2.Size = new System.Drawing.Size(33, 13);
            this.lblImageScaleSpecificHeight2.TabIndex = 21;
            this.lblImageScaleSpecificHeight2.Text = "pixels";
            // 
            // rbImageScaleTypeSpecific
            // 
            this.rbImageScaleTypeSpecific.AutoSize = true;
            this.rbImageScaleTypeSpecific.Location = new System.Drawing.Point(16, 192);
            this.rbImageScaleTypeSpecific.Name = "rbImageScaleTypeSpecific";
            this.rbImageScaleTypeSpecific.Size = new System.Drawing.Size(84, 17);
            this.rbImageScaleTypeSpecific.TabIndex = 15;
            this.rbImageScaleTypeSpecific.TabStop = true;
            this.rbImageScaleTypeSpecific.Text = "Specific size";
            this.rbImageScaleTypeSpecific.UseVisualStyleBackColor = true;
            this.rbImageScaleTypeSpecific.CheckedChanged += new System.EventHandler(this.rbImageScaleTypeSpecific_CheckedChanged);
            // 
            // lblImageScaleToWidth2
            // 
            this.lblImageScaleToWidth2.AutoSize = true;
            this.lblImageScaleToWidth2.Location = new System.Drawing.Point(144, 124);
            this.lblImageScaleToWidth2.Name = "lblImageScaleToWidth2";
            this.lblImageScaleToWidth2.Size = new System.Drawing.Size(33, 13);
            this.lblImageScaleToWidth2.TabIndex = 10;
            this.lblImageScaleToWidth2.Text = "pixels";
            // 
            // lblImageScalePercentageWidth
            // 
            this.lblImageScalePercentageWidth.AutoSize = true;
            this.lblImageScalePercentageWidth.Location = new System.Drawing.Point(32, 52);
            this.lblImageScalePercentageWidth.Name = "lblImageScalePercentageWidth";
            this.lblImageScalePercentageWidth.Size = new System.Drawing.Size(38, 13);
            this.lblImageScalePercentageWidth.TabIndex = 1;
            this.lblImageScalePercentageWidth.Text = "Width:";
            // 
            // lblImageScalePercentageHeight2
            // 
            this.lblImageScalePercentageHeight2.AutoSize = true;
            this.lblImageScalePercentageHeight2.Location = new System.Drawing.Point(144, 76);
            this.lblImageScalePercentageHeight2.Name = "lblImageScalePercentageHeight2";
            this.lblImageScalePercentageHeight2.Size = new System.Drawing.Size(15, 13);
            this.lblImageScalePercentageHeight2.TabIndex = 6;
            this.lblImageScalePercentageHeight2.Text = "%";
            // 
            // nudImageScalePercentageWidth
            // 
            this.nudImageScalePercentageWidth.Location = new System.Drawing.Point(80, 48);
            this.nudImageScalePercentageWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudImageScalePercentageWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageScalePercentageWidth.Name = "nudImageScalePercentageWidth";
            this.nudImageScalePercentageWidth.Size = new System.Drawing.Size(56, 20);
            this.nudImageScalePercentageWidth.TabIndex = 2;
            this.nudImageScalePercentageWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudImageScalePercentageWidth.ValueChanged += new System.EventHandler(this.nudImageScalePercentageWidth_ValueChanged);
            // 
            // lblImageScalePercentageWidth2
            // 
            this.lblImageScalePercentageWidth2.AutoSize = true;
            this.lblImageScalePercentageWidth2.Location = new System.Drawing.Point(144, 52);
            this.lblImageScalePercentageWidth2.Name = "lblImageScalePercentageWidth2";
            this.lblImageScalePercentageWidth2.Size = new System.Drawing.Size(15, 13);
            this.lblImageScalePercentageWidth2.TabIndex = 3;
            this.lblImageScalePercentageWidth2.Text = "%";
            // 
            // lblImageScalePercentageHeight
            // 
            this.lblImageScalePercentageHeight.AutoSize = true;
            this.lblImageScalePercentageHeight.Location = new System.Drawing.Point(32, 76);
            this.lblImageScalePercentageHeight.Name = "lblImageScalePercentageHeight";
            this.lblImageScalePercentageHeight.Size = new System.Drawing.Size(41, 13);
            this.lblImageScalePercentageHeight.TabIndex = 4;
            this.lblImageScalePercentageHeight.Text = "Height:";
            // 
            // nudImageScaleToHeight
            // 
            this.nudImageScaleToHeight.Location = new System.Drawing.Point(80, 168);
            this.nudImageScaleToHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudImageScaleToHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageScaleToHeight.Name = "nudImageScaleToHeight";
            this.nudImageScaleToHeight.Size = new System.Drawing.Size(56, 20);
            this.nudImageScaleToHeight.TabIndex = 13;
            this.nudImageScaleToHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudImageScaleToHeight.ValueChanged += new System.EventHandler(this.nudImageScaleToHeight_ValueChanged);
            // 
            // nudImageScalePercentageHeight
            // 
            this.nudImageScalePercentageHeight.Location = new System.Drawing.Point(80, 72);
            this.nudImageScalePercentageHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudImageScalePercentageHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageScalePercentageHeight.Name = "nudImageScalePercentageHeight";
            this.nudImageScalePercentageHeight.Size = new System.Drawing.Size(56, 20);
            this.nudImageScalePercentageHeight.TabIndex = 5;
            this.nudImageScalePercentageHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudImageScalePercentageHeight.ValueChanged += new System.EventHandler(this.nudImageScalePercentageHeight_ValueChanged);
            // 
            // nudImageScaleToWidth
            // 
            this.nudImageScaleToWidth.Location = new System.Drawing.Point(80, 120);
            this.nudImageScaleToWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudImageScaleToWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageScaleToWidth.Name = "nudImageScaleToWidth";
            this.nudImageScaleToWidth.Size = new System.Drawing.Size(56, 20);
            this.nudImageScaleToWidth.TabIndex = 9;
            this.nudImageScaleToWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudImageScaleToWidth.ValueChanged += new System.EventHandler(this.nudImageScaleToWidth_ValueChanged);
            // 
            // lblImageScaleToWidth
            // 
            this.lblImageScaleToWidth.AutoSize = true;
            this.lblImageScaleToWidth.Location = new System.Drawing.Point(32, 124);
            this.lblImageScaleToWidth.Name = "lblImageScaleToWidth";
            this.lblImageScaleToWidth.Size = new System.Drawing.Size(38, 13);
            this.lblImageScaleToWidth.TabIndex = 8;
            this.lblImageScaleToWidth.Text = "Width:";
            // 
            // nudImageScaleSpecificHeight
            // 
            this.nudImageScaleSpecificHeight.Location = new System.Drawing.Point(80, 240);
            this.nudImageScaleSpecificHeight.Name = "nudImageScaleSpecificHeight";
            this.nudImageScaleSpecificHeight.Size = new System.Drawing.Size(56, 20);
            this.nudImageScaleSpecificHeight.TabIndex = 20;
            this.nudImageScaleSpecificHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudImageScaleSpecificHeight.ValueChanged += new System.EventHandler(this.nudImageScaleSpecificHeight_ValueChanged);
            // 
            // lblImageScaleToHeight
            // 
            this.lblImageScaleToHeight.AutoSize = true;
            this.lblImageScaleToHeight.Location = new System.Drawing.Point(32, 172);
            this.lblImageScaleToHeight.Name = "lblImageScaleToHeight";
            this.lblImageScaleToHeight.Size = new System.Drawing.Size(41, 13);
            this.lblImageScaleToHeight.TabIndex = 12;
            this.lblImageScaleToHeight.Text = "Height:";
            // 
            // lblImageScaleSpecificHeight
            // 
            this.lblImageScaleSpecificHeight.AutoSize = true;
            this.lblImageScaleSpecificHeight.Location = new System.Drawing.Point(32, 244);
            this.lblImageScaleSpecificHeight.Name = "lblImageScaleSpecificHeight";
            this.lblImageScaleSpecificHeight.Size = new System.Drawing.Size(41, 13);
            this.lblImageScaleSpecificHeight.TabIndex = 19;
            this.lblImageScaleSpecificHeight.Text = "Height:";
            // 
            // lblImageScaleSpecificWidth
            // 
            this.lblImageScaleSpecificWidth.AutoSize = true;
            this.lblImageScaleSpecificWidth.Location = new System.Drawing.Point(32, 220);
            this.lblImageScaleSpecificWidth.Name = "lblImageScaleSpecificWidth";
            this.lblImageScaleSpecificWidth.Size = new System.Drawing.Size(38, 13);
            this.lblImageScaleSpecificWidth.TabIndex = 16;
            this.lblImageScaleSpecificWidth.Text = "Width:";
            // 
            // nudImageScaleSpecificWidth
            // 
            this.nudImageScaleSpecificWidth.Location = new System.Drawing.Point(80, 216);
            this.nudImageScaleSpecificWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudImageScaleSpecificWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageScaleSpecificWidth.Name = "nudImageScaleSpecificWidth";
            this.nudImageScaleSpecificWidth.Size = new System.Drawing.Size(56, 20);
            this.nudImageScaleSpecificWidth.TabIndex = 17;
            this.nudImageScaleSpecificWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudImageScaleSpecificWidth.ValueChanged += new System.EventHandler(this.nudImageScaleSpecificWidth_ValueChanged);
            // 
            // tpEffects
            // 
            this.tpEffects.Controls.Add(this.gbImageShadow);
            this.tpEffects.Controls.Add(this.cbImageEffectOnlyRegionCapture);
            this.tpEffects.Controls.Add(this.btnWatermarkSettings);
            this.tpEffects.Controls.Add(this.gbBorder);
            this.tpEffects.Location = new System.Drawing.Point(4, 22);
            this.tpEffects.Name = "tpEffects";
            this.tpEffects.Padding = new System.Windows.Forms.Padding(3);
            this.tpEffects.Size = new System.Drawing.Size(506, 301);
            this.tpEffects.TabIndex = 2;
            this.tpEffects.Text = "Effects";
            this.tpEffects.UseVisualStyleBackColor = true;
            // 
            // gbImageShadow
            // 
            this.gbImageShadow.Controls.Add(this.lblImageShadowSize);
            this.gbImageShadow.Controls.Add(this.lblImageShadowDarkness);
            this.gbImageShadow.Controls.Add(this.nudImageShadowSize);
            this.gbImageShadow.Controls.Add(this.nudImageShadowDarkness);
            this.gbImageShadow.Location = new System.Drawing.Point(16, 152);
            this.gbImageShadow.Name = "gbImageShadow";
            this.gbImageShadow.Size = new System.Drawing.Size(472, 56);
            this.gbImageShadow.TabIndex = 3;
            this.gbImageShadow.TabStop = false;
            this.gbImageShadow.Text = "Shadow";
            // 
            // lblImageShadowSize
            // 
            this.lblImageShadowSize.AutoSize = true;
            this.lblImageShadowSize.Location = new System.Drawing.Point(152, 24);
            this.lblImageShadowSize.Name = "lblImageShadowSize";
            this.lblImageShadowSize.Size = new System.Drawing.Size(30, 13);
            this.lblImageShadowSize.TabIndex = 2;
            this.lblImageShadowSize.Text = "Size:";
            // 
            // lblImageShadowDarkness
            // 
            this.lblImageShadowDarkness.AutoSize = true;
            this.lblImageShadowDarkness.Location = new System.Drawing.Point(16, 24);
            this.lblImageShadowDarkness.Name = "lblImageShadowDarkness";
            this.lblImageShadowDarkness.Size = new System.Drawing.Size(55, 13);
            this.lblImageShadowDarkness.TabIndex = 0;
            this.lblImageShadowDarkness.Text = "Darkness:";
            // 
            // nudImageShadowSize
            // 
            this.nudImageShadowSize.Location = new System.Drawing.Point(192, 20);
            this.nudImageShadowSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudImageShadowSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudImageShadowSize.Name = "nudImageShadowSize";
            this.nudImageShadowSize.Size = new System.Drawing.Size(56, 20);
            this.nudImageShadowSize.TabIndex = 3;
            this.nudImageShadowSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudImageShadowSize.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudImageShadowSize.ValueChanged += new System.EventHandler(this.nudImageShadowSize_ValueChanged);
            // 
            // nudImageShadowDarkness
            // 
            this.nudImageShadowDarkness.DecimalPlaces = 1;
            this.nudImageShadowDarkness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudImageShadowDarkness.Location = new System.Drawing.Point(80, 20);
            this.nudImageShadowDarkness.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudImageShadowDarkness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudImageShadowDarkness.Name = "nudImageShadowDarkness";
            this.nudImageShadowDarkness.Size = new System.Drawing.Size(56, 20);
            this.nudImageShadowDarkness.TabIndex = 1;
            this.nudImageShadowDarkness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudImageShadowDarkness.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            this.nudImageShadowDarkness.ValueChanged += new System.EventHandler(this.nudImageShadowDarkness_ValueChanged);
            // 
            // cbImageEffectOnlyRegionCapture
            // 
            this.cbImageEffectOnlyRegionCapture.AutoSize = true;
            this.cbImageEffectOnlyRegionCapture.Location = new System.Drawing.Point(16, 56);
            this.cbImageEffectOnlyRegionCapture.Name = "cbImageEffectOnlyRegionCapture";
            this.cbImageEffectOnlyRegionCapture.Size = new System.Drawing.Size(240, 17);
            this.cbImageEffectOnlyRegionCapture.TabIndex = 1;
            this.cbImageEffectOnlyRegionCapture.Text = "Only apply border && shadow to region capture";
            this.cbImageEffectOnlyRegionCapture.UseVisualStyleBackColor = true;
            this.cbImageEffectOnlyRegionCapture.CheckedChanged += new System.EventHandler(this.cbImageEffectOnlyRectangleCapture_CheckedChanged);
            // 
            // btnWatermarkSettings
            // 
            this.btnWatermarkSettings.Location = new System.Drawing.Point(16, 16);
            this.btnWatermarkSettings.Name = "btnWatermarkSettings";
            this.btnWatermarkSettings.Size = new System.Drawing.Size(160, 23);
            this.btnWatermarkSettings.TabIndex = 0;
            this.btnWatermarkSettings.Text = "Watermark settings...";
            this.btnWatermarkSettings.UseVisualStyleBackColor = true;
            this.btnWatermarkSettings.Click += new System.EventHandler(this.btnWatermarkSettings_Click);
            // 
            // gbBorder
            // 
            this.gbBorder.Controls.Add(this.nudBorderSize);
            this.gbBorder.Controls.Add(this.btnBorderColor);
            this.gbBorder.Controls.Add(this.lblBorderSize);
            this.gbBorder.Controls.Add(this.lblBorderColor);
            this.gbBorder.Location = new System.Drawing.Point(16, 88);
            this.gbBorder.Name = "gbBorder";
            this.gbBorder.Size = new System.Drawing.Size(472, 56);
            this.gbBorder.TabIndex = 2;
            this.gbBorder.TabStop = false;
            this.gbBorder.Text = "Border";
            // 
            // nudBorderSize
            // 
            this.nudBorderSize.Location = new System.Drawing.Point(224, 20);
            this.nudBorderSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBorderSize.Name = "nudBorderSize";
            this.nudBorderSize.Size = new System.Drawing.Size(56, 20);
            this.nudBorderSize.TabIndex = 3;
            this.nudBorderSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudBorderSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBorderSize.ValueChanged += new System.EventHandler(this.nudBorderSize_ValueChanged);
            // 
            // btnBorderColor
            // 
            this.btnBorderColor.BackColor = System.Drawing.Color.Black;
            this.btnBorderColor.Location = new System.Drawing.Point(88, 18);
            this.btnBorderColor.Name = "btnBorderColor";
            this.btnBorderColor.Size = new System.Drawing.Size(56, 24);
            this.btnBorderColor.TabIndex = 1;
            this.btnBorderColor.UseVisualStyleBackColor = false;
            this.btnBorderColor.Click += new System.EventHandler(this.btnBorderColor_Click);
            // 
            // lblBorderSize
            // 
            this.lblBorderSize.AutoSize = true;
            this.lblBorderSize.Location = new System.Drawing.Point(152, 24);
            this.lblBorderSize.Name = "lblBorderSize";
            this.lblBorderSize.Size = new System.Drawing.Size(62, 13);
            this.lblBorderSize.TabIndex = 2;
            this.lblBorderSize.Text = "Border size:";
            // 
            // lblBorderColor
            // 
            this.lblBorderColor.AutoSize = true;
            this.lblBorderColor.Location = new System.Drawing.Point(16, 24);
            this.lblBorderColor.Name = "lblBorderColor";
            this.lblBorderColor.Size = new System.Drawing.Size(67, 13);
            this.lblBorderColor.TabIndex = 0;
            this.lblBorderColor.Text = "Border color:";
            // 
            // chkUseDefaultImageSettings
            // 
            this.chkUseDefaultImageSettings.AutoSize = true;
            this.chkUseDefaultImageSettings.Checked = true;
            this.chkUseDefaultImageSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultImageSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkUseDefaultImageSettings.Location = new System.Drawing.Point(3, 3);
            this.chkUseDefaultImageSettings.Name = "chkUseDefaultImageSettings";
            this.chkUseDefaultImageSettings.Padding = new System.Windows.Forms.Padding(5);
            this.chkUseDefaultImageSettings.Size = new System.Drawing.Size(514, 27);
            this.chkUseDefaultImageSettings.TabIndex = 0;
            this.chkUseDefaultImageSettings.Text = "Use default image settings";
            this.chkUseDefaultImageSettings.UseVisualStyleBackColor = true;
            this.chkUseDefaultImageSettings.CheckedChanged += new System.EventHandler(this.chkUseDefaultImageSettings_CheckedChanged);
            // 
            // tpCapture
            // 
            this.tpCapture.Controls.Add(this.tcCapture);
            this.tpCapture.Controls.Add(this.chkUseDefaultCaptureSettings);
            this.tpCapture.Location = new System.Drawing.Point(4, 22);
            this.tpCapture.Name = "tpCapture";
            this.tpCapture.Padding = new System.Windows.Forms.Padding(3);
            this.tpCapture.Size = new System.Drawing.Size(520, 360);
            this.tpCapture.TabIndex = 2;
            this.tpCapture.Text = "Capture";
            this.tpCapture.UseVisualStyleBackColor = true;
            // 
            // tcCapture
            // 
            this.tcCapture.Controls.Add(this.tpCaptureGeneral);
            this.tcCapture.Controls.Add(this.tpCaptureShape);
            this.tcCapture.Controls.Add(this.tpScreenRecorder);
            this.tcCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCapture.Location = new System.Drawing.Point(3, 30);
            this.tcCapture.Name = "tcCapture";
            this.tcCapture.SelectedIndex = 0;
            this.tcCapture.Size = new System.Drawing.Size(514, 327);
            this.tcCapture.TabIndex = 1;
            // 
            // tpCaptureGeneral
            // 
            this.tpCaptureGeneral.Controls.Add(this.cbCaptureAutoHideTaskbar);
            this.tpCaptureGeneral.Controls.Add(this.lblScreenshotDelayInfo);
            this.tpCaptureGeneral.Controls.Add(this.nudScreenshotDelay);
            this.tpCaptureGeneral.Controls.Add(this.cbScreenshotDelay);
            this.tpCaptureGeneral.Controls.Add(this.nudCaptureShadowOffset);
            this.tpCaptureGeneral.Controls.Add(this.cbCaptureClientArea);
            this.tpCaptureGeneral.Controls.Add(this.cbCaptureShadow);
            this.tpCaptureGeneral.Controls.Add(this.cbShowCursor);
            this.tpCaptureGeneral.Controls.Add(this.cbCaptureTransparent);
            this.tpCaptureGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpCaptureGeneral.Name = "tpCaptureGeneral";
            this.tpCaptureGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpCaptureGeneral.Size = new System.Drawing.Size(506, 301);
            this.tpCaptureGeneral.TabIndex = 0;
            this.tpCaptureGeneral.Text = "General";
            this.tpCaptureGeneral.UseVisualStyleBackColor = true;
            // 
            // cbCaptureAutoHideTaskbar
            // 
            this.cbCaptureAutoHideTaskbar.AutoSize = true;
            this.cbCaptureAutoHideTaskbar.Location = new System.Drawing.Point(16, 136);
            this.cbCaptureAutoHideTaskbar.Name = "cbCaptureAutoHideTaskbar";
            this.cbCaptureAutoHideTaskbar.Size = new System.Drawing.Size(402, 17);
            this.cbCaptureAutoHideTaskbar.TabIndex = 8;
            this.cbCaptureAutoHideTaskbar.Text = "When doing window capture if window intersects with taskbar then hide taskbar";
            this.cbCaptureAutoHideTaskbar.UseVisualStyleBackColor = true;
            this.cbCaptureAutoHideTaskbar.CheckedChanged += new System.EventHandler(this.cbCaptureAutoHideTaskbar_CheckedChanged);
            // 
            // lblScreenshotDelayInfo
            // 
            this.lblScreenshotDelayInfo.AutoSize = true;
            this.lblScreenshotDelayInfo.Location = new System.Drawing.Point(192, 114);
            this.lblScreenshotDelayInfo.Name = "lblScreenshotDelayInfo";
            this.lblScreenshotDelayInfo.Size = new System.Drawing.Size(47, 13);
            this.lblScreenshotDelayInfo.TabIndex = 7;
            this.lblScreenshotDelayInfo.Text = "seconds";
            // 
            // nudScreenshotDelay
            // 
            this.nudScreenshotDelay.DecimalPlaces = 1;
            this.nudScreenshotDelay.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudScreenshotDelay.Location = new System.Drawing.Point(128, 110);
            this.nudScreenshotDelay.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudScreenshotDelay.Name = "nudScreenshotDelay";
            this.nudScreenshotDelay.Size = new System.Drawing.Size(56, 20);
            this.nudScreenshotDelay.TabIndex = 6;
            this.nudScreenshotDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudScreenshotDelay.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudScreenshotDelay.ValueChanged += new System.EventHandler(this.nudScreenshotDelay_ValueChanged);
            // 
            // cbScreenshotDelay
            // 
            this.cbScreenshotDelay.AutoSize = true;
            this.cbScreenshotDelay.Location = new System.Drawing.Point(16, 112);
            this.cbScreenshotDelay.Name = "cbScreenshotDelay";
            this.cbScreenshotDelay.Size = new System.Drawing.Size(111, 17);
            this.cbScreenshotDelay.TabIndex = 5;
            this.cbScreenshotDelay.Text = "Screenshot delay:";
            this.cbScreenshotDelay.UseVisualStyleBackColor = true;
            this.cbScreenshotDelay.CheckedChanged += new System.EventHandler(this.cbScreenshotDelay_CheckedChanged);
            // 
            // nudCaptureShadowOffset
            // 
            this.nudCaptureShadowOffset.Location = new System.Drawing.Point(368, 62);
            this.nudCaptureShadowOffset.Name = "nudCaptureShadowOffset";
            this.nudCaptureShadowOffset.Size = new System.Drawing.Size(48, 20);
            this.nudCaptureShadowOffset.TabIndex = 3;
            this.nudCaptureShadowOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCaptureShadowOffset.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudCaptureShadowOffset.ValueChanged += new System.EventHandler(this.nudCaptureShadowOffset_ValueChanged);
            // 
            // cbCaptureClientArea
            // 
            this.cbCaptureClientArea.AutoSize = true;
            this.cbCaptureClientArea.Location = new System.Drawing.Point(16, 88);
            this.cbCaptureClientArea.Name = "cbCaptureClientArea";
            this.cbCaptureClientArea.Size = new System.Drawing.Size(334, 17);
            this.cbCaptureClientArea.TabIndex = 4;
            this.cbCaptureClientArea.Text = "Capture client area when doing window or active window capture";
            this.cbCaptureClientArea.UseVisualStyleBackColor = true;
            this.cbCaptureClientArea.CheckedChanged += new System.EventHandler(this.cbCaptureClientArea_CheckedChanged);
            // 
            // cbCaptureShadow
            // 
            this.cbCaptureShadow.AutoSize = true;
            this.cbCaptureShadow.Location = new System.Drawing.Point(16, 64);
            this.cbCaptureShadow.Name = "cbCaptureShadow";
            this.cbCaptureShadow.Size = new System.Drawing.Size(351, 17);
            this.cbCaptureShadow.TabIndex = 2;
            this.cbCaptureShadow.Text = "Capture window with shadow (requires transparency)  Shadow offset:";
            this.cbCaptureShadow.UseVisualStyleBackColor = true;
            this.cbCaptureShadow.CheckedChanged += new System.EventHandler(this.cbCaptureShadow_CheckedChanged);
            // 
            // cbShowCursor
            // 
            this.cbShowCursor.AutoSize = true;
            this.cbShowCursor.Location = new System.Drawing.Point(16, 16);
            this.cbShowCursor.Name = "cbShowCursor";
            this.cbShowCursor.Size = new System.Drawing.Size(156, 17);
            this.cbShowCursor.TabIndex = 0;
            this.cbShowCursor.Text = "Show cursor in screenshots";
            this.cbShowCursor.UseVisualStyleBackColor = true;
            this.cbShowCursor.CheckedChanged += new System.EventHandler(this.cbShowCursor_CheckedChanged);
            // 
            // cbCaptureTransparent
            // 
            this.cbCaptureTransparent.AutoSize = true;
            this.cbCaptureTransparent.Location = new System.Drawing.Point(16, 40);
            this.cbCaptureTransparent.Name = "cbCaptureTransparent";
            this.cbCaptureTransparent.Size = new System.Drawing.Size(188, 17);
            this.cbCaptureTransparent.TabIndex = 1;
            this.cbCaptureTransparent.Text = "Capture window with transparency";
            this.cbCaptureTransparent.UseVisualStyleBackColor = true;
            this.cbCaptureTransparent.CheckedChanged += new System.EventHandler(this.cbCaptureTransparent_CheckedChanged);
            // 
            // tpCaptureShape
            // 
            this.tpCaptureShape.Controls.Add(this.btnOpenCapturingShapesWiki);
            this.tpCaptureShape.Controls.Add(this.cbShapeForceWindowCapture);
            this.tpCaptureShape.Controls.Add(this.cbShapeIncludeControls);
            this.tpCaptureShape.Controls.Add(this.lblFixedShapeSizeHeight);
            this.tpCaptureShape.Controls.Add(this.cbDrawBorder);
            this.tpCaptureShape.Controls.Add(this.lblFixedShapeSizeWidth);
            this.tpCaptureShape.Controls.Add(this.cbCaptureMultipleShapes);
            this.tpCaptureShape.Controls.Add(this.nudFixedShapeSizeHeight);
            this.tpCaptureShape.Controls.Add(this.cbDrawCheckerboard);
            this.tpCaptureShape.Controls.Add(this.nudFixedShapeSizeWidth);
            this.tpCaptureShape.Controls.Add(this.cbFixedShapeSize);
            this.tpCaptureShape.Location = new System.Drawing.Point(4, 22);
            this.tpCaptureShape.Name = "tpCaptureShape";
            this.tpCaptureShape.Padding = new System.Windows.Forms.Padding(3);
            this.tpCaptureShape.Size = new System.Drawing.Size(506, 301);
            this.tpCaptureShape.TabIndex = 1;
            this.tpCaptureShape.Text = "Shape capture";
            this.tpCaptureShape.UseVisualStyleBackColor = true;
            // 
            // btnOpenCapturingShapesWiki
            // 
            this.btnOpenCapturingShapesWiki.Location = new System.Drawing.Point(408, 8);
            this.btnOpenCapturingShapesWiki.Name = "btnOpenCapturingShapesWiki";
            this.btnOpenCapturingShapesWiki.Size = new System.Drawing.Size(88, 24);
            this.btnOpenCapturingShapesWiki.TabIndex = 0;
            this.btnOpenCapturingShapesWiki.Text = "Tips && tricks...";
            this.btnOpenCapturingShapesWiki.UseVisualStyleBackColor = true;
            this.btnOpenCapturingShapesWiki.Click += new System.EventHandler(this.btnOpenCapturingShapesWiki_Click);
            // 
            // cbShapeForceWindowCapture
            // 
            this.cbShapeForceWindowCapture.AutoSize = true;
            this.cbShapeForceWindowCapture.Location = new System.Drawing.Point(16, 176);
            this.cbShapeForceWindowCapture.Name = "cbShapeForceWindowCapture";
            this.cbShapeForceWindowCapture.Size = new System.Drawing.Size(287, 17);
            this.cbShapeForceWindowCapture.TabIndex = 10;
            this.cbShapeForceWindowCapture.Text = "Use window capture mode for all rectangle type shapes";
            this.cbShapeForceWindowCapture.UseVisualStyleBackColor = true;
            this.cbShapeForceWindowCapture.CheckedChanged += new System.EventHandler(this.cbShapeForceWindowCapture_CheckedChanged);
            // 
            // cbShapeIncludeControls
            // 
            this.cbShapeIncludeControls.AutoSize = true;
            this.cbShapeIncludeControls.Location = new System.Drawing.Point(16, 152);
            this.cbShapeIncludeControls.Name = "cbShapeIncludeControls";
            this.cbShapeIncludeControls.Size = new System.Drawing.Size(329, 17);
            this.cbShapeIncludeControls.TabIndex = 9;
            this.cbShapeIncludeControls.Text = "Allow capturing controls in window capture (buttons, panels etc.)";
            this.cbShapeIncludeControls.UseVisualStyleBackColor = true;
            this.cbShapeIncludeControls.CheckedChanged += new System.EventHandler(this.cbShapeIncludeControls_CheckedChanged);
            // 
            // lblFixedShapeSizeHeight
            // 
            this.lblFixedShapeSizeHeight.AutoSize = true;
            this.lblFixedShapeSizeHeight.Location = new System.Drawing.Point(160, 120);
            this.lblFixedShapeSizeHeight.Name = "lblFixedShapeSizeHeight";
            this.lblFixedShapeSizeHeight.Size = new System.Drawing.Size(41, 13);
            this.lblFixedShapeSizeHeight.TabIndex = 7;
            this.lblFixedShapeSizeHeight.Text = "Height:";
            // 
            // cbDrawBorder
            // 
            this.cbDrawBorder.AutoSize = true;
            this.cbDrawBorder.Location = new System.Drawing.Point(16, 64);
            this.cbDrawBorder.Name = "cbDrawBorder";
            this.cbDrawBorder.Size = new System.Drawing.Size(170, 17);
            this.cbDrawBorder.TabIndex = 3;
            this.cbDrawBorder.Text = "Draw border around the shape";
            this.cbDrawBorder.UseVisualStyleBackColor = true;
            this.cbDrawBorder.CheckedChanged += new System.EventHandler(this.cbDrawBorder_CheckedChanged);
            // 
            // lblFixedShapeSizeWidth
            // 
            this.lblFixedShapeSizeWidth.AutoSize = true;
            this.lblFixedShapeSizeWidth.Location = new System.Drawing.Point(44, 120);
            this.lblFixedShapeSizeWidth.Name = "lblFixedShapeSizeWidth";
            this.lblFixedShapeSizeWidth.Size = new System.Drawing.Size(38, 13);
            this.lblFixedShapeSizeWidth.TabIndex = 5;
            this.lblFixedShapeSizeWidth.Text = "Width:";
            // 
            // cbCaptureMultipleShapes
            // 
            this.cbCaptureMultipleShapes.AutoSize = true;
            this.cbCaptureMultipleShapes.Location = new System.Drawing.Point(16, 16);
            this.cbCaptureMultipleShapes.Name = "cbCaptureMultipleShapes";
            this.cbCaptureMultipleShapes.Size = new System.Drawing.Size(190, 17);
            this.cbCaptureMultipleShapes.TabIndex = 1;
            this.cbCaptureMultipleShapes.Text = "Allow moving and resizing shape(s)";
            this.cbCaptureMultipleShapes.UseVisualStyleBackColor = true;
            this.cbCaptureMultipleShapes.CheckedChanged += new System.EventHandler(this.cbQuickCrop_CheckedChanged);
            // 
            // nudFixedShapeSizeHeight
            // 
            this.nudFixedShapeSizeHeight.Location = new System.Drawing.Point(208, 116);
            this.nudFixedShapeSizeHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudFixedShapeSizeHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFixedShapeSizeHeight.Name = "nudFixedShapeSizeHeight";
            this.nudFixedShapeSizeHeight.Size = new System.Drawing.Size(56, 20);
            this.nudFixedShapeSizeHeight.TabIndex = 8;
            this.nudFixedShapeSizeHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFixedShapeSizeHeight.ValueChanged += new System.EventHandler(this.nudFixedShapeSizeHeight_ValueChanged);
            // 
            // cbDrawCheckerboard
            // 
            this.cbDrawCheckerboard.AutoSize = true;
            this.cbDrawCheckerboard.Location = new System.Drawing.Point(16, 40);
            this.cbDrawCheckerboard.Name = "cbDrawCheckerboard";
            this.cbDrawCheckerboard.Size = new System.Drawing.Size(290, 17);
            this.cbDrawCheckerboard.TabIndex = 2;
            this.cbDrawCheckerboard.Text = "Draw checkerboard pattern instead of transparent areas";
            this.cbDrawCheckerboard.UseVisualStyleBackColor = true;
            this.cbDrawCheckerboard.CheckedChanged += new System.EventHandler(this.cbDrawCheckerboard_CheckedChanged);
            // 
            // nudFixedShapeSizeWidth
            // 
            this.nudFixedShapeSizeWidth.Location = new System.Drawing.Point(88, 116);
            this.nudFixedShapeSizeWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudFixedShapeSizeWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFixedShapeSizeWidth.Name = "nudFixedShapeSizeWidth";
            this.nudFixedShapeSizeWidth.Size = new System.Drawing.Size(56, 20);
            this.nudFixedShapeSizeWidth.TabIndex = 6;
            this.nudFixedShapeSizeWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFixedShapeSizeWidth.ValueChanged += new System.EventHandler(this.nudFixedShapeSizeWidth_ValueChanged);
            // 
            // cbFixedShapeSize
            // 
            this.cbFixedShapeSize.AutoSize = true;
            this.cbFixedShapeSize.Location = new System.Drawing.Point(16, 88);
            this.cbFixedShapeSize.Name = "cbFixedShapeSize";
            this.cbFixedShapeSize.Size = new System.Drawing.Size(107, 17);
            this.cbFixedShapeSize.TabIndex = 4;
            this.cbFixedShapeSize.Text = "Fixed shape size:";
            this.cbFixedShapeSize.UseVisualStyleBackColor = true;
            this.cbFixedShapeSize.CheckedChanged += new System.EventHandler(this.cbFixedShapeSize_CheckedChanged);
            // 
            // tpScreenRecorder
            // 
            this.tpScreenRecorder.Controls.Add(this.cbOutput);
            this.tpScreenRecorder.Controls.Add(this.lblOutput);
            this.tpScreenRecorder.Controls.Add(this.cbFixedDuration);
            this.tpScreenRecorder.Controls.Add(this.nudFPS);
            this.tpScreenRecorder.Controls.Add(this.nudDuration);
            this.tpScreenRecorder.Controls.Add(this.lblDuration);
            this.tpScreenRecorder.Controls.Add(this.lblFPS);
            this.tpScreenRecorder.Controls.Add(this.gbCommandLineEncoderSettings);
            this.tpScreenRecorder.Location = new System.Drawing.Point(4, 22);
            this.tpScreenRecorder.Name = "tpScreenRecorder";
            this.tpScreenRecorder.Padding = new System.Windows.Forms.Padding(3);
            this.tpScreenRecorder.Size = new System.Drawing.Size(506, 301);
            this.tpScreenRecorder.TabIndex = 2;
            this.tpScreenRecorder.Text = "Screen recorder";
            this.tpScreenRecorder.UseVisualStyleBackColor = true;
            // 
            // cbOutput
            // 
            this.cbOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutput.FormattingEnabled = true;
            this.cbOutput.Location = new System.Drawing.Point(64, 8);
            this.cbOutput.Name = "cbOutput";
            this.cbOutput.Size = new System.Drawing.Size(126, 21);
            this.cbOutput.TabIndex = 1;
            this.cbOutput.SelectedIndexChanged += new System.EventHandler(this.cbOutput_SelectedIndexChanged);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(16, 12);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(42, 13);
            this.lblOutput.TabIndex = 0;
            this.lblOutput.Text = "Output:";
            // 
            // cbFixedDuration
            // 
            this.cbFixedDuration.AutoSize = true;
            this.cbFixedDuration.Location = new System.Drawing.Point(16, 72);
            this.cbFixedDuration.Name = "cbFixedDuration";
            this.cbFixedDuration.Size = new System.Drawing.Size(92, 17);
            this.cbFixedDuration.TabIndex = 4;
            this.cbFixedDuration.Text = "Fixed duration";
            this.cbFixedDuration.UseVisualStyleBackColor = true;
            this.cbFixedDuration.CheckedChanged += new System.EventHandler(this.cbFixedDuration_CheckedChanged);
            // 
            // nudFPS
            // 
            this.nudFPS.Location = new System.Drawing.Point(56, 40);
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
            this.nudFPS.TabIndex = 3;
            this.nudFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFPS.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudFPS.ValueChanged += new System.EventHandler(this.nudFPS_ValueChanged);
            // 
            // nudDuration
            // 
            this.nudDuration.DecimalPlaces = 1;
            this.nudDuration.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudDuration.Location = new System.Drawing.Point(120, 92);
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
            this.nudDuration.TabIndex = 6;
            this.nudDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDuration.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudDuration.ValueChanged += new System.EventHandler(this.nudDuration_ValueChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(16, 96);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(99, 13);
            this.lblDuration.TabIndex = 5;
            this.lblDuration.Text = "Duration (seconds):";
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Location = new System.Drawing.Point(16, 44);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(30, 13);
            this.lblFPS.TabIndex = 2;
            this.lblFPS.Text = "FPS:";
            // 
            // gbCommandLineEncoderSettings
            // 
            this.gbCommandLineEncoderSettings.Controls.Add(this.btnBrowseCommandLinePath);
            this.gbCommandLineEncoderSettings.Controls.Add(this.lblCommandLineOutputExtension);
            this.gbCommandLineEncoderSettings.Controls.Add(this.lblCommandLineArgs);
            this.gbCommandLineEncoderSettings.Controls.Add(this.lblCommandLinePath);
            this.gbCommandLineEncoderSettings.Controls.Add(this.tbCommandLineArgs);
            this.gbCommandLineEncoderSettings.Controls.Add(this.tbCommandLineOutputExtension);
            this.gbCommandLineEncoderSettings.Controls.Add(this.tbCommandLinePath);
            this.gbCommandLineEncoderSettings.Location = new System.Drawing.Point(16, 128);
            this.gbCommandLineEncoderSettings.Name = "gbCommandLineEncoderSettings";
            this.gbCommandLineEncoderSettings.Size = new System.Drawing.Size(360, 112);
            this.gbCommandLineEncoderSettings.TabIndex = 7;
            this.gbCommandLineEncoderSettings.TabStop = false;
            this.gbCommandLineEncoderSettings.Text = "Command line encoder settings";
            // 
            // btnBrowseCommandLinePath
            // 
            this.btnBrowseCommandLinePath.Location = new System.Drawing.Point(309, 16);
            this.btnBrowseCommandLinePath.Name = "btnBrowseCommandLinePath";
            this.btnBrowseCommandLinePath.Size = new System.Drawing.Size(32, 24);
            this.btnBrowseCommandLinePath.TabIndex = 2;
            this.btnBrowseCommandLinePath.Text = "...";
            this.btnBrowseCommandLinePath.UseVisualStyleBackColor = true;
            this.btnBrowseCommandLinePath.Click += new System.EventHandler(this.btnBrowseCommandLinePath_Click);
            // 
            // lblCommandLineOutputExtension
            // 
            this.lblCommandLineOutputExtension.AutoSize = true;
            this.lblCommandLineOutputExtension.Location = new System.Drawing.Point(21, 86);
            this.lblCommandLineOutputExtension.Name = "lblCommandLineOutputExtension";
            this.lblCommandLineOutputExtension.Size = new System.Drawing.Size(90, 13);
            this.lblCommandLineOutputExtension.TabIndex = 5;
            this.lblCommandLineOutputExtension.Text = "Output extension:";
            // 
            // lblCommandLineArgs
            // 
            this.lblCommandLineArgs.AutoSize = true;
            this.lblCommandLineArgs.Location = new System.Drawing.Point(21, 54);
            this.lblCommandLineArgs.Name = "lblCommandLineArgs";
            this.lblCommandLineArgs.Size = new System.Drawing.Size(60, 13);
            this.lblCommandLineArgs.TabIndex = 3;
            this.lblCommandLineArgs.Text = "Arguments:";
            // 
            // lblCommandLinePath
            // 
            this.lblCommandLinePath.AutoSize = true;
            this.lblCommandLinePath.Location = new System.Drawing.Point(21, 22);
            this.lblCommandLinePath.Name = "lblCommandLinePath";
            this.lblCommandLinePath.Size = new System.Drawing.Size(74, 13);
            this.lblCommandLinePath.TabIndex = 0;
            this.lblCommandLinePath.Text = "Encoder path:";
            // 
            // tbCommandLineArgs
            // 
            this.tbCommandLineArgs.Location = new System.Drawing.Point(117, 50);
            this.tbCommandLineArgs.Name = "tbCommandLineArgs";
            this.tbCommandLineArgs.Size = new System.Drawing.Size(224, 20);
            this.tbCommandLineArgs.TabIndex = 4;
            this.tbCommandLineArgs.TextChanged += new System.EventHandler(this.tbCommandLineArgs_TextChanged);
            // 
            // tbCommandLineOutputExtension
            // 
            this.tbCommandLineOutputExtension.Location = new System.Drawing.Point(117, 82);
            this.tbCommandLineOutputExtension.Name = "tbCommandLineOutputExtension";
            this.tbCommandLineOutputExtension.Size = new System.Drawing.Size(224, 20);
            this.tbCommandLineOutputExtension.TabIndex = 6;
            this.tbCommandLineOutputExtension.TextChanged += new System.EventHandler(this.tbCommandLineOutputExtension_TextChanged);
            // 
            // tbCommandLinePath
            // 
            this.tbCommandLinePath.Location = new System.Drawing.Point(117, 18);
            this.tbCommandLinePath.Name = "tbCommandLinePath";
            this.tbCommandLinePath.Size = new System.Drawing.Size(184, 20);
            this.tbCommandLinePath.TabIndex = 1;
            // 
            // chkUseDefaultCaptureSettings
            // 
            this.chkUseDefaultCaptureSettings.AutoSize = true;
            this.chkUseDefaultCaptureSettings.Checked = true;
            this.chkUseDefaultCaptureSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultCaptureSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkUseDefaultCaptureSettings.Location = new System.Drawing.Point(3, 3);
            this.chkUseDefaultCaptureSettings.Name = "chkUseDefaultCaptureSettings";
            this.chkUseDefaultCaptureSettings.Padding = new System.Windows.Forms.Padding(5);
            this.chkUseDefaultCaptureSettings.Size = new System.Drawing.Size(514, 27);
            this.chkUseDefaultCaptureSettings.TabIndex = 0;
            this.chkUseDefaultCaptureSettings.Text = "Use default capture settings";
            this.chkUseDefaultCaptureSettings.UseVisualStyleBackColor = true;
            this.chkUseDefaultCaptureSettings.CheckedChanged += new System.EventHandler(this.chkUseDefaultCaptureSettings_CheckedChanged);
            // 
            // tpActions
            // 
            this.tpActions.Controls.Add(this.pActions);
            this.tpActions.Controls.Add(this.chkUseDefaultActions);
            this.tpActions.Location = new System.Drawing.Point(4, 22);
            this.tpActions.Name = "tpActions";
            this.tpActions.Padding = new System.Windows.Forms.Padding(3);
            this.tpActions.Size = new System.Drawing.Size(520, 360);
            this.tpActions.TabIndex = 3;
            this.tpActions.Text = "Actions";
            this.tpActions.UseVisualStyleBackColor = true;
            // 
            // pActions
            // 
            this.pActions.Controls.Add(this.btnActionsAdd);
            this.pActions.Controls.Add(this.lvActions);
            this.pActions.Controls.Add(this.btnActionsEdit);
            this.pActions.Controls.Add(this.btnActionsRemove);
            this.pActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pActions.Location = new System.Drawing.Point(3, 30);
            this.pActions.Margin = new System.Windows.Forms.Padding(0);
            this.pActions.Name = "pActions";
            this.pActions.Size = new System.Drawing.Size(514, 327);
            this.pActions.TabIndex = 1;
            // 
            // btnActionsAdd
            // 
            this.btnActionsAdd.Location = new System.Drawing.Point(8, 8);
            this.btnActionsAdd.Name = "btnActionsAdd";
            this.btnActionsAdd.Size = new System.Drawing.Size(75, 23);
            this.btnActionsAdd.TabIndex = 0;
            this.btnActionsAdd.Text = "Add";
            this.btnActionsAdd.UseVisualStyleBackColor = true;
            this.btnActionsAdd.Click += new System.EventHandler(this.btnActionsAdd_Click);
            // 
            // lvActions
            // 
            this.lvActions.CheckBoxes = true;
            this.lvActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chActionsName,
            this.chActionsPath,
            this.chActionsArgs});
            this.lvActions.FullRowSelect = true;
            this.lvActions.Location = new System.Drawing.Point(8, 40);
            this.lvActions.MultiSelect = false;
            this.lvActions.Name = "lvActions";
            this.lvActions.Size = new System.Drawing.Size(496, 280);
            this.lvActions.TabIndex = 3;
            this.lvActions.UseCompatibleStateImageBehavior = false;
            this.lvActions.View = System.Windows.Forms.View.Details;
            this.lvActions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvActions_ItemChecked);
            // 
            // chActionsName
            // 
            this.chActionsName.Text = "Name";
            this.chActionsName.Width = 100;
            // 
            // chActionsPath
            // 
            this.chActionsPath.Text = "Path";
            this.chActionsPath.Width = 250;
            // 
            // chActionsArgs
            // 
            this.chActionsArgs.Text = "Args";
            this.chActionsArgs.Width = 134;
            // 
            // btnActionsEdit
            // 
            this.btnActionsEdit.Location = new System.Drawing.Point(88, 8);
            this.btnActionsEdit.Name = "btnActionsEdit";
            this.btnActionsEdit.Size = new System.Drawing.Size(75, 23);
            this.btnActionsEdit.TabIndex = 1;
            this.btnActionsEdit.Text = "Edit";
            this.btnActionsEdit.UseVisualStyleBackColor = true;
            this.btnActionsEdit.Click += new System.EventHandler(this.btnActionsEdit_Click);
            // 
            // btnActionsRemove
            // 
            this.btnActionsRemove.Location = new System.Drawing.Point(168, 8);
            this.btnActionsRemove.Name = "btnActionsRemove";
            this.btnActionsRemove.Size = new System.Drawing.Size(75, 23);
            this.btnActionsRemove.TabIndex = 2;
            this.btnActionsRemove.Text = "Remove";
            this.btnActionsRemove.UseVisualStyleBackColor = true;
            this.btnActionsRemove.Click += new System.EventHandler(this.btnActionsRemove_Click);
            // 
            // chkUseDefaultActions
            // 
            this.chkUseDefaultActions.AutoSize = true;
            this.chkUseDefaultActions.Checked = true;
            this.chkUseDefaultActions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkUseDefaultActions.Location = new System.Drawing.Point(3, 3);
            this.chkUseDefaultActions.Name = "chkUseDefaultActions";
            this.chkUseDefaultActions.Padding = new System.Windows.Forms.Padding(5);
            this.chkUseDefaultActions.Size = new System.Drawing.Size(514, 27);
            this.chkUseDefaultActions.TabIndex = 0;
            this.chkUseDefaultActions.Text = "Use default actions";
            this.chkUseDefaultActions.UseVisualStyleBackColor = true;
            this.chkUseDefaultActions.CheckedChanged += new System.EventHandler(this.chkUseDefaultActions_CheckedChanged);
            // 
            // tpUpload
            // 
            this.tpUpload.Controls.Add(this.tcUpload);
            this.tpUpload.Controls.Add(this.chkUseDefaultUploadSettings);
            this.tpUpload.Location = new System.Drawing.Point(4, 22);
            this.tpUpload.Name = "tpUpload";
            this.tpUpload.Padding = new System.Windows.Forms.Padding(3);
            this.tpUpload.Size = new System.Drawing.Size(520, 360);
            this.tpUpload.TabIndex = 4;
            this.tpUpload.Text = "Upload";
            this.tpUpload.UseVisualStyleBackColor = true;
            // 
            // tcUpload
            // 
            this.tcUpload.Controls.Add(this.tpUploadNamePattern);
            this.tcUpload.Controls.Add(this.tpUploadClipboard);
            this.tcUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUpload.Location = new System.Drawing.Point(3, 30);
            this.tcUpload.Name = "tcUpload";
            this.tcUpload.SelectedIndex = 0;
            this.tcUpload.Size = new System.Drawing.Size(514, 327);
            this.tcUpload.TabIndex = 1;
            // 
            // tpUploadNamePattern
            // 
            this.tpUploadNamePattern.Controls.Add(this.cbFileUploadUseNamePattern);
            this.tpUploadNamePattern.Controls.Add(this.lblNameFormatPattern);
            this.tpUploadNamePattern.Controls.Add(this.txtNameFormatPatternActiveWindow);
            this.tpUploadNamePattern.Controls.Add(this.btnResetAutoIncrementNumber);
            this.tpUploadNamePattern.Controls.Add(this.lblNameFormatPatternActiveWindow);
            this.tpUploadNamePattern.Controls.Add(this.txtNameFormatPattern);
            this.tpUploadNamePattern.Controls.Add(this.lblNameFormatPatternPreview);
            this.tpUploadNamePattern.Controls.Add(this.lblNameFormatPatternPreviewActiveWindow);
            this.tpUploadNamePattern.Location = new System.Drawing.Point(4, 22);
            this.tpUploadNamePattern.Name = "tpUploadNamePattern";
            this.tpUploadNamePattern.Padding = new System.Windows.Forms.Padding(3);
            this.tpUploadNamePattern.Size = new System.Drawing.Size(506, 301);
            this.tpUploadNamePattern.TabIndex = 0;
            this.tpUploadNamePattern.Text = "Name pattern";
            this.tpUploadNamePattern.UseVisualStyleBackColor = true;
            // 
            // cbFileUploadUseNamePattern
            // 
            this.cbFileUploadUseNamePattern.AutoSize = true;
            this.cbFileUploadUseNamePattern.Location = new System.Drawing.Point(16, 193);
            this.cbFileUploadUseNamePattern.Name = "cbFileUploadUseNamePattern";
            this.cbFileUploadUseNamePattern.Size = new System.Drawing.Size(295, 17);
            this.cbFileUploadUseNamePattern.TabIndex = 7;
            this.cbFileUploadUseNamePattern.Text = "Use name pattern for file uploads instead actual file name";
            this.cbFileUploadUseNamePattern.UseVisualStyleBackColor = true;
            this.cbFileUploadUseNamePattern.CheckedChanged += new System.EventHandler(this.cbFileUploadUseNamePattern_CheckedChanged);
            // 
            // lblNameFormatPattern
            // 
            this.lblNameFormatPattern.AutoSize = true;
            this.lblNameFormatPattern.Location = new System.Drawing.Point(16, 20);
            this.lblNameFormatPattern.Name = "lblNameFormatPattern";
            this.lblNameFormatPattern.Size = new System.Drawing.Size(221, 13);
            this.lblNameFormatPattern.TabIndex = 0;
            this.lblNameFormatPattern.Text = "Name pattern for capture or clipboard upload:";
            // 
            // txtNameFormatPatternActiveWindow
            // 
            this.txtNameFormatPatternActiveWindow.Location = new System.Drawing.Point(16, 129);
            this.txtNameFormatPatternActiveWindow.Name = "txtNameFormatPatternActiveWindow";
            this.txtNameFormatPatternActiveWindow.Size = new System.Drawing.Size(448, 20);
            this.txtNameFormatPatternActiveWindow.TabIndex = 5;
            this.txtNameFormatPatternActiveWindow.TextChanged += new System.EventHandler(this.txtNameFormatPatternActiveWindow_TextChanged);
            // 
            // btnResetAutoIncrementNumber
            // 
            this.btnResetAutoIncrementNumber.Location = new System.Drawing.Point(296, 17);
            this.btnResetAutoIncrementNumber.Name = "btnResetAutoIncrementNumber";
            this.btnResetAutoIncrementNumber.Size = new System.Drawing.Size(168, 23);
            this.btnResetAutoIncrementNumber.TabIndex = 1;
            this.btnResetAutoIncrementNumber.Text = "Reset auto increment number";
            this.btnResetAutoIncrementNumber.UseVisualStyleBackColor = true;
            this.btnResetAutoIncrementNumber.Click += new System.EventHandler(this.btnResetAutoIncrementNumber_Click);
            // 
            // lblNameFormatPatternActiveWindow
            // 
            this.lblNameFormatPatternActiveWindow.AutoSize = true;
            this.lblNameFormatPatternActiveWindow.Location = new System.Drawing.Point(16, 105);
            this.lblNameFormatPatternActiveWindow.Name = "lblNameFormatPatternActiveWindow";
            this.lblNameFormatPatternActiveWindow.Size = new System.Drawing.Size(199, 13);
            this.lblNameFormatPatternActiveWindow.TabIndex = 4;
            this.lblNameFormatPatternActiveWindow.Text = "Name pattern for active window capture:";
            // 
            // txtNameFormatPattern
            // 
            this.txtNameFormatPattern.Location = new System.Drawing.Point(16, 44);
            this.txtNameFormatPattern.Name = "txtNameFormatPattern";
            this.txtNameFormatPattern.Size = new System.Drawing.Size(448, 20);
            this.txtNameFormatPattern.TabIndex = 2;
            this.txtNameFormatPattern.TextChanged += new System.EventHandler(this.txtNameFormatPattern_TextChanged);
            // 
            // lblNameFormatPatternPreview
            // 
            this.lblNameFormatPatternPreview.AutoSize = true;
            this.lblNameFormatPatternPreview.Location = new System.Drawing.Point(16, 76);
            this.lblNameFormatPatternPreview.Name = "lblNameFormatPatternPreview";
            this.lblNameFormatPatternPreview.Size = new System.Drawing.Size(48, 13);
            this.lblNameFormatPatternPreview.TabIndex = 3;
            this.lblNameFormatPatternPreview.Text = "Preview:";
            // 
            // lblNameFormatPatternPreviewActiveWindow
            // 
            this.lblNameFormatPatternPreviewActiveWindow.AutoSize = true;
            this.lblNameFormatPatternPreviewActiveWindow.Location = new System.Drawing.Point(16, 161);
            this.lblNameFormatPatternPreviewActiveWindow.Name = "lblNameFormatPatternPreviewActiveWindow";
            this.lblNameFormatPatternPreviewActiveWindow.Size = new System.Drawing.Size(48, 13);
            this.lblNameFormatPatternPreviewActiveWindow.TabIndex = 6;
            this.lblNameFormatPatternPreviewActiveWindow.Text = "Preview:";
            // 
            // tpUploadClipboard
            // 
            this.tpUploadClipboard.Controls.Add(this.cbShowClipboardContentViewer);
            this.tpUploadClipboard.Controls.Add(this.cbClipboardUploadAutoDetectURL);
            this.tpUploadClipboard.Location = new System.Drawing.Point(4, 22);
            this.tpUploadClipboard.Name = "tpUploadClipboard";
            this.tpUploadClipboard.Padding = new System.Windows.Forms.Padding(3);
            this.tpUploadClipboard.Size = new System.Drawing.Size(506, 301);
            this.tpUploadClipboard.TabIndex = 1;
            this.tpUploadClipboard.Text = "Clipboard upload";
            this.tpUploadClipboard.UseVisualStyleBackColor = true;
            // 
            // cbShowClipboardContentViewer
            // 
            this.cbShowClipboardContentViewer.AutoSize = true;
            this.cbShowClipboardContentViewer.Location = new System.Drawing.Point(16, 16);
            this.cbShowClipboardContentViewer.Name = "cbShowClipboardContentViewer";
            this.cbShowClipboardContentViewer.Size = new System.Drawing.Size(418, 17);
            this.cbShowClipboardContentViewer.TabIndex = 0;
            this.cbShowClipboardContentViewer.Text = "Show clipboard content viewer when using clipboard upload button in main window";
            this.cbShowClipboardContentViewer.UseVisualStyleBackColor = true;
            this.cbShowClipboardContentViewer.CheckedChanged += new System.EventHandler(this.cbShowClipboardContentViewer_CheckedChanged);
            // 
            // cbClipboardUploadAutoDetectURL
            // 
            this.cbClipboardUploadAutoDetectURL.AutoSize = true;
            this.cbClipboardUploadAutoDetectURL.Location = new System.Drawing.Point(16, 40);
            this.cbClipboardUploadAutoDetectURL.Name = "cbClipboardUploadAutoDetectURL";
            this.cbClipboardUploadAutoDetectURL.Size = new System.Drawing.Size(418, 17);
            this.cbClipboardUploadAutoDetectURL.TabIndex = 1;
            this.cbClipboardUploadAutoDetectURL.Text = "Automatically detect URL when doing clipboard text upload and use URL shortener";
            this.cbClipboardUploadAutoDetectURL.UseVisualStyleBackColor = true;
            this.cbClipboardUploadAutoDetectURL.CheckedChanged += new System.EventHandler(this.cbClipboardUploadAutoDetectURL_CheckedChanged);
            // 
            // chkUseDefaultUploadSettings
            // 
            this.chkUseDefaultUploadSettings.AutoSize = true;
            this.chkUseDefaultUploadSettings.Checked = true;
            this.chkUseDefaultUploadSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultUploadSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkUseDefaultUploadSettings.Location = new System.Drawing.Point(3, 3);
            this.chkUseDefaultUploadSettings.Name = "chkUseDefaultUploadSettings";
            this.chkUseDefaultUploadSettings.Padding = new System.Windows.Forms.Padding(5);
            this.chkUseDefaultUploadSettings.Size = new System.Drawing.Size(514, 27);
            this.chkUseDefaultUploadSettings.TabIndex = 0;
            this.chkUseDefaultUploadSettings.Text = "Use default upload settings";
            this.chkUseDefaultUploadSettings.UseVisualStyleBackColor = true;
            this.chkUseDefaultUploadSettings.CheckedChanged += new System.EventHandler(this.chkUseDefaultUploadSettings_CheckedChanged);
            // 
            // tpWatchFolders
            // 
            this.tpWatchFolders.Controls.Add(this.cbWatchFolderEnabled);
            this.tpWatchFolders.Controls.Add(this.lvWatchFolderList);
            this.tpWatchFolders.Controls.Add(this.btnWatchFolderRemove);
            this.tpWatchFolders.Controls.Add(this.btnWatchFolderAdd);
            this.tpWatchFolders.Location = new System.Drawing.Point(4, 22);
            this.tpWatchFolders.Name = "tpWatchFolders";
            this.tpWatchFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tpWatchFolders.Size = new System.Drawing.Size(520, 360);
            this.tpWatchFolders.TabIndex = 5;
            this.tpWatchFolders.Text = "Watch folders";
            this.tpWatchFolders.UseVisualStyleBackColor = true;
            // 
            // cbWatchFolderEnabled
            // 
            this.cbWatchFolderEnabled.AutoSize = true;
            this.cbWatchFolderEnabled.Location = new System.Drawing.Point(8, 8);
            this.cbWatchFolderEnabled.Name = "cbWatchFolderEnabled";
            this.cbWatchFolderEnabled.Size = new System.Drawing.Size(266, 17);
            this.cbWatchFolderEnabled.TabIndex = 0;
            this.cbWatchFolderEnabled.Text = "Watch folders and if new file created then upload it";
            this.cbWatchFolderEnabled.UseVisualStyleBackColor = true;
            this.cbWatchFolderEnabled.CheckedChanged += new System.EventHandler(this.cbWatchFolderEnabled_CheckedChanged);
            // 
            // lvWatchFolderList
            // 
            this.lvWatchFolderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chWatchFolderFolderPath,
            this.chWatchFolderFilter,
            this.chWatchFolderIncludeSubdirectories});
            this.lvWatchFolderList.FullRowSelect = true;
            this.lvWatchFolderList.Location = new System.Drawing.Point(8, 64);
            this.lvWatchFolderList.Name = "lvWatchFolderList";
            this.lvWatchFolderList.Size = new System.Drawing.Size(504, 288);
            this.lvWatchFolderList.TabIndex = 3;
            this.lvWatchFolderList.UseCompatibleStateImageBehavior = false;
            this.lvWatchFolderList.View = System.Windows.Forms.View.Details;
            // 
            // chWatchFolderFolderPath
            // 
            this.chWatchFolderFolderPath.Text = "Folder path";
            this.chWatchFolderFolderPath.Width = 323;
            // 
            // chWatchFolderFilter
            // 
            this.chWatchFolderFilter.Text = "Filter";
            this.chWatchFolderFilter.Width = 43;
            // 
            // chWatchFolderIncludeSubdirectories
            // 
            this.chWatchFolderIncludeSubdirectories.Text = "Include subdirectories";
            this.chWatchFolderIncludeSubdirectories.Width = 124;
            // 
            // btnWatchFolderRemove
            // 
            this.btnWatchFolderRemove.Location = new System.Drawing.Point(88, 32);
            this.btnWatchFolderRemove.Name = "btnWatchFolderRemove";
            this.btnWatchFolderRemove.Size = new System.Drawing.Size(75, 23);
            this.btnWatchFolderRemove.TabIndex = 2;
            this.btnWatchFolderRemove.Text = "Remove";
            this.btnWatchFolderRemove.UseVisualStyleBackColor = true;
            this.btnWatchFolderRemove.Click += new System.EventHandler(this.btnWatchFolderRemove_Click);
            // 
            // btnWatchFolderAdd
            // 
            this.btnWatchFolderAdd.Location = new System.Drawing.Point(8, 32);
            this.btnWatchFolderAdd.Name = "btnWatchFolderAdd";
            this.btnWatchFolderAdd.Size = new System.Drawing.Size(75, 23);
            this.btnWatchFolderAdd.TabIndex = 1;
            this.btnWatchFolderAdd.Text = "Add...";
            this.btnWatchFolderAdd.UseVisualStyleBackColor = true;
            this.btnWatchFolderAdd.Click += new System.EventHandler(this.btnWatchFolderAdd_Click);
            // 
            // tpAdvanced
            // 
            this.tpAdvanced.Controls.Add(this.pgTaskSettings);
            this.tpAdvanced.Controls.Add(this.chkUseDefaultAdvancedSettings);
            this.tpAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tpAdvanced.Name = "tpAdvanced";
            this.tpAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdvanced.Size = new System.Drawing.Size(520, 360);
            this.tpAdvanced.TabIndex = 6;
            this.tpAdvanced.Text = "Advanced";
            this.tpAdvanced.UseVisualStyleBackColor = true;
            // 
            // pgTaskSettings
            // 
            this.pgTaskSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgTaskSettings.Location = new System.Drawing.Point(3, 30);
            this.pgTaskSettings.Name = "pgTaskSettings";
            this.pgTaskSettings.Size = new System.Drawing.Size(514, 327);
            this.pgTaskSettings.TabIndex = 1;
            this.pgTaskSettings.ToolbarVisible = false;
            // 
            // chkUseDefaultAdvancedSettings
            // 
            this.chkUseDefaultAdvancedSettings.AutoSize = true;
            this.chkUseDefaultAdvancedSettings.Checked = true;
            this.chkUseDefaultAdvancedSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultAdvancedSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkUseDefaultAdvancedSettings.Location = new System.Drawing.Point(3, 3);
            this.chkUseDefaultAdvancedSettings.Name = "chkUseDefaultAdvancedSettings";
            this.chkUseDefaultAdvancedSettings.Padding = new System.Windows.Forms.Padding(5);
            this.chkUseDefaultAdvancedSettings.Size = new System.Drawing.Size(514, 27);
            this.chkUseDefaultAdvancedSettings.TabIndex = 0;
            this.chkUseDefaultAdvancedSettings.Text = "Use default advanced settings";
            this.chkUseDefaultAdvancedSettings.UseVisualStyleBackColor = true;
            this.chkUseDefaultAdvancedSettings.CheckedChanged += new System.EventHandler(this.chkUseDefaultAdvancedSettings_CheckedChanged);
            // 
            // TaskSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 392);
            this.Controls.Add(this.tcHotkeySettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(550, 430);
            this.Name = "TaskSettingsForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - Task settings";
            this.tcHotkeySettings.ResumeLayout(false);
            this.tpTask.ResumeLayout(false);
            this.tpTask.PerformLayout();
            this.tpImage.ResumeLayout(false);
            this.tpImage.PerformLayout();
            this.tcImage.ResumeLayout(false);
            this.tpQuality.ResumeLayout(false);
            this.tpQuality.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageJPEGQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUseImageFormat2After)).EndInit();
            this.tpResize.ResumeLayout(false);
            this.tpResize.PerformLayout();
            this.gbImageScaleSettings.ResumeLayout(false);
            this.gbImageScaleSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScalePercentageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScaleToHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScalePercentageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScaleToWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScaleSpecificHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageScaleSpecificWidth)).EndInit();
            this.tpEffects.ResumeLayout(false);
            this.tpEffects.PerformLayout();
            this.gbImageShadow.ResumeLayout(false);
            this.gbImageShadow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageShadowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageShadowDarkness)).EndInit();
            this.gbBorder.ResumeLayout(false);
            this.gbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderSize)).EndInit();
            this.tpCapture.ResumeLayout(false);
            this.tpCapture.PerformLayout();
            this.tcCapture.ResumeLayout(false);
            this.tpCaptureGeneral.ResumeLayout(false);
            this.tpCaptureGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenshotDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaptureShadowOffset)).EndInit();
            this.tpCaptureShape.ResumeLayout(false);
            this.tpCaptureShape.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedShapeSizeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedShapeSizeWidth)).EndInit();
            this.tpScreenRecorder.ResumeLayout(false);
            this.tpScreenRecorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.gbCommandLineEncoderSettings.ResumeLayout(false);
            this.gbCommandLineEncoderSettings.PerformLayout();
            this.tpActions.ResumeLayout(false);
            this.tpActions.PerformLayout();
            this.pActions.ResumeLayout(false);
            this.tpUpload.ResumeLayout(false);
            this.tpUpload.PerformLayout();
            this.tcUpload.ResumeLayout(false);
            this.tpUploadNamePattern.ResumeLayout(false);
            this.tpUploadNamePattern.PerformLayout();
            this.tpUploadClipboard.ResumeLayout(false);
            this.tpUploadClipboard.PerformLayout();
            this.tpWatchFolders.ResumeLayout(false);
            this.tpWatchFolders.PerformLayout();
            this.tpAdvanced.ResumeLayout(false);
            this.tpAdvanced.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAfterCapture;
        private System.Windows.Forms.ContextMenuStrip cmsAfterCapture;
        private System.Windows.Forms.Button btnAfterUpload;
        private System.Windows.Forms.Button btnImageUploaders;
        private System.Windows.Forms.Button btnTextUploaders;
        private System.Windows.Forms.Button btnFileUploaders;
        private System.Windows.Forms.Button btnURLShorteners;
        private System.Windows.Forms.Button btnSocialNetworkingServices;
        private System.Windows.Forms.ContextMenuStrip cmsAfterUpload;
        private System.Windows.Forms.ContextMenuStrip cmsImageUploaders;
        private System.Windows.Forms.ContextMenuStrip cmsTextUploaders;
        private System.Windows.Forms.ContextMenuStrip cmsFileUploaders;
        private System.Windows.Forms.ContextMenuStrip cmsURLShorteners;
        private System.Windows.Forms.ContextMenuStrip cmsSocialNetworkingServices;
        private System.Windows.Forms.CheckBox cbUseDefaultAfterCaptureSettings;
        private System.Windows.Forms.CheckBox cbUseDefaultAfterUploadSettings;
        private System.Windows.Forms.CheckBox cbUseDefaultDestinationSettings;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.ContextMenuStrip cmsTask;
        private System.Windows.Forms.TabControl tcHotkeySettings;
        private System.Windows.Forms.TabPage tpImage;
        private System.Windows.Forms.TabPage tpCapture;
        private System.Windows.Forms.TabControl tcImage;
        private System.Windows.Forms.TabPage tpQuality;
        private System.Windows.Forms.CheckBox chkProcessImagesDuringFileUpload;
        private System.Windows.Forms.Label lblImageFormat;
        private System.Windows.Forms.Label lblUseImageFormat2AfterHint;
        private System.Windows.Forms.ComboBox cbImageFormat;
        private System.Windows.Forms.Label lblImageJPEGQualityHint;
        private System.Windows.Forms.Label lblImageJPEGQuality;
        private System.Windows.Forms.ComboBox cbImageGIFQuality;
        private System.Windows.Forms.Label lblImageGIFQuality;
        private System.Windows.Forms.ComboBox cbImageFormat2;
        private System.Windows.Forms.NumericUpDown nudImageJPEGQuality;
        private System.Windows.Forms.Label lblImageFormat2;
        private System.Windows.Forms.NumericUpDown nudUseImageFormat2After;
        private System.Windows.Forms.Label lblUseImageFormat2After;
        private System.Windows.Forms.TabPage tpResize;
        private System.Windows.Forms.CheckBox cbImageUseSmoothScaling;
        private System.Windows.Forms.CheckBox cbImageKeepAspectRatio;
        private System.Windows.Forms.CheckBox cbImageAutoResize;
        private System.Windows.Forms.GroupBox gbImageScaleSettings;
        private System.Windows.Forms.RadioButton rbImageScaleTypePercentage;
        private System.Windows.Forms.Label lblImageScaleToHeight2;
        private System.Windows.Forms.RadioButton rbImageScaleTypeToWidth;
        private System.Windows.Forms.Label lblImageScaleSpecificWidth2;
        private System.Windows.Forms.RadioButton rbImageScaleTypeToHeight;
        private System.Windows.Forms.Label lblImageScaleSpecificHeight2;
        private System.Windows.Forms.RadioButton rbImageScaleTypeSpecific;
        private System.Windows.Forms.Label lblImageScaleToWidth2;
        private System.Windows.Forms.Label lblImageScalePercentageWidth;
        private System.Windows.Forms.Label lblImageScalePercentageHeight2;
        private System.Windows.Forms.NumericUpDown nudImageScalePercentageWidth;
        private System.Windows.Forms.Label lblImageScalePercentageWidth2;
        private System.Windows.Forms.Label lblImageScalePercentageHeight;
        private System.Windows.Forms.NumericUpDown nudImageScaleToHeight;
        private System.Windows.Forms.NumericUpDown nudImageScalePercentageHeight;
        private System.Windows.Forms.NumericUpDown nudImageScaleToWidth;
        private System.Windows.Forms.Label lblImageScaleToWidth;
        private System.Windows.Forms.NumericUpDown nudImageScaleSpecificHeight;
        private System.Windows.Forms.Label lblImageScaleToHeight;
        private System.Windows.Forms.Label lblImageScaleSpecificHeight;
        private System.Windows.Forms.Label lblImageScaleSpecificWidth;
        private System.Windows.Forms.NumericUpDown nudImageScaleSpecificWidth;
        private System.Windows.Forms.TabPage tpEffects;
        private System.Windows.Forms.GroupBox gbImageShadow;
        private System.Windows.Forms.Label lblImageShadowSize;
        private System.Windows.Forms.Label lblImageShadowDarkness;
        private System.Windows.Forms.NumericUpDown nudImageShadowSize;
        private System.Windows.Forms.NumericUpDown nudImageShadowDarkness;
        private System.Windows.Forms.CheckBox cbImageEffectOnlyRegionCapture;
        private System.Windows.Forms.Button btnWatermarkSettings;
        private System.Windows.Forms.GroupBox gbBorder;
        private System.Windows.Forms.NumericUpDown nudBorderSize;
        private System.Windows.Forms.Button btnBorderColor;
        private System.Windows.Forms.Label lblBorderSize;
        private System.Windows.Forms.Label lblBorderColor;
        private System.Windows.Forms.TabControl tcCapture;
        private System.Windows.Forms.TabPage tpCaptureGeneral;
        private System.Windows.Forms.CheckBox cbCaptureAutoHideTaskbar;
        private System.Windows.Forms.Label lblScreenshotDelayInfo;
        private System.Windows.Forms.NumericUpDown nudScreenshotDelay;
        private System.Windows.Forms.CheckBox cbScreenshotDelay;
        private System.Windows.Forms.NumericUpDown nudCaptureShadowOffset;
        private System.Windows.Forms.CheckBox cbCaptureClientArea;
        private System.Windows.Forms.CheckBox cbCaptureShadow;
        private System.Windows.Forms.CheckBox cbShowCursor;
        private System.Windows.Forms.CheckBox cbCaptureTransparent;
        private System.Windows.Forms.TabPage tpCaptureShape;
        private System.Windows.Forms.Button btnOpenCapturingShapesWiki;
        private System.Windows.Forms.CheckBox cbShapeForceWindowCapture;
        private System.Windows.Forms.CheckBox cbShapeIncludeControls;
        private System.Windows.Forms.Label lblFixedShapeSizeHeight;
        private System.Windows.Forms.CheckBox cbDrawBorder;
        private System.Windows.Forms.Label lblFixedShapeSizeWidth;
        private System.Windows.Forms.CheckBox cbCaptureMultipleShapes;
        private System.Windows.Forms.NumericUpDown nudFixedShapeSizeHeight;
        private System.Windows.Forms.CheckBox cbDrawCheckerboard;
        private System.Windows.Forms.NumericUpDown nudFixedShapeSizeWidth;
        private System.Windows.Forms.CheckBox cbFixedShapeSize;
        private System.Windows.Forms.TabPage tpScreenRecorder;
        private System.Windows.Forms.TabPage tpTask;
        private System.Windows.Forms.TabPage tpActions;
        private System.Windows.Forms.Button btnActionsEdit;
        private System.Windows.Forms.Button btnActionsRemove;
        private System.Windows.Forms.Button btnActionsAdd;
        private HelpersLib.MyListView lvActions;
        private System.Windows.Forms.ColumnHeader chActionsName;
        private System.Windows.Forms.ColumnHeader chActionsPath;
        private System.Windows.Forms.ColumnHeader chActionsArgs;
        private System.Windows.Forms.TabPage tpUpload;
        private System.Windows.Forms.TabControl tcUpload;
        private System.Windows.Forms.TabPage tpUploadNamePattern;
        private System.Windows.Forms.CheckBox cbFileUploadUseNamePattern;
        private System.Windows.Forms.Label lblNameFormatPattern;
        private System.Windows.Forms.TextBox txtNameFormatPatternActiveWindow;
        private System.Windows.Forms.Button btnResetAutoIncrementNumber;
        private System.Windows.Forms.Label lblNameFormatPatternActiveWindow;
        private System.Windows.Forms.TextBox txtNameFormatPattern;
        private System.Windows.Forms.Label lblNameFormatPatternPreview;
        private System.Windows.Forms.Label lblNameFormatPatternPreviewActiveWindow;
        private System.Windows.Forms.TabPage tpUploadClipboard;
        private System.Windows.Forms.CheckBox cbShowClipboardContentViewer;
        private System.Windows.Forms.CheckBox cbClipboardUploadAutoDetectURL;
        private System.Windows.Forms.TabPage tpAdvanced;
        private System.Windows.Forms.PropertyGrid pgTaskSettings;
        private System.Windows.Forms.CheckBox chkUseDefaultImageSettings;
        private System.Windows.Forms.CheckBox chkUseDefaultCaptureSettings;
        private System.Windows.Forms.CheckBox chkUseDefaultActions;
        private System.Windows.Forms.CheckBox chkUseDefaultUploadSettings;
        private System.Windows.Forms.Panel pActions;
        private System.Windows.Forms.CheckBox chkUseDefaultAdvancedSettings;
        private System.Windows.Forms.Button btnBrowseCommandLinePath;
        private System.Windows.Forms.Label lblCommandLineOutputExtension;
        private System.Windows.Forms.Label lblCommandLineArgs;
        private System.Windows.Forms.Label lblCommandLinePath;
        private System.Windows.Forms.TextBox tbCommandLineArgs;
        private System.Windows.Forms.TextBox tbCommandLineOutputExtension;
        private System.Windows.Forms.TextBox tbCommandLinePath;
        private System.Windows.Forms.GroupBox gbCommandLineEncoderSettings;
        private System.Windows.Forms.CheckBox cbFixedDuration;
        private System.Windows.Forms.NumericUpDown nudFPS;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.ComboBox cbOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TabPage tpWatchFolders;
        private System.Windows.Forms.CheckBox cbWatchFolderEnabled;
        private System.Windows.Forms.ListView lvWatchFolderList;
        private System.Windows.Forms.ColumnHeader chWatchFolderFolderPath;
        private System.Windows.Forms.ColumnHeader chWatchFolderFilter;
        private System.Windows.Forms.ColumnHeader chWatchFolderIncludeSubdirectories;
        private System.Windows.Forms.Button btnWatchFolderRemove;
        private System.Windows.Forms.Button btnWatchFolderAdd;



    }
}