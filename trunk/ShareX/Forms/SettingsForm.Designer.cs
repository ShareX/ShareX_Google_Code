namespace ShareX
{
    partial class SettingsForm
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
            this.cbClipboardAutoCopy = new System.Windows.Forms.CheckBox();
            this.cbPlaySoundAfterUpload = new System.Windows.Forms.CheckBox();
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.cbTrayBalloonTipAfterUpload = new System.Windows.Forms.CheckBox();
            this.lblGeneralSeparator2 = new System.Windows.Forms.Label();
            this.cbHistorySave = new System.Windows.Forms.CheckBox();
            this.cbPlaySoundAfterCapture = new System.Windows.Forms.CheckBox();
            this.cbCheckUpdates = new System.Windows.Forms.CheckBox();
            this.lblGeneralSeparator = new System.Windows.Forms.Label();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.cbShowTray = new System.Windows.Forms.CheckBox();
            this.cbURLShortenAfterUpload = new System.Windows.Forms.CheckBox();
            this.cbShellContextMenu = new System.Windows.Forms.CheckBox();
            this.tpPaths = new System.Windows.Forms.TabPage();
            this.btnBrowseCustomScreenshotsPath = new System.Windows.Forms.Button();
            this.btnOpenPersonalFolder = new System.Windows.Forms.Button();
            this.btnLoadUploadersConfig = new System.Windows.Forms.Button();
            this.txtCustomHistoryPath = new System.Windows.Forms.TextBox();
            this.txtCustomScreenshotsPath = new System.Windows.Forms.TextBox();
            this.cbUseCustomUploadersConfigPath = new System.Windows.Forms.CheckBox();
            this.cbUseCustomScreenshotsPath = new System.Windows.Forms.CheckBox();
            this.lblSaveImageSubFolderPattern = new System.Windows.Forms.Label();
            this.btnBrowseCustomHistoryPath = new System.Windows.Forms.Button();
            this.lblSaveImageSubFolderPatternPreview = new System.Windows.Forms.Label();
            this.txtCustomUploadersConfigPath = new System.Windows.Forms.TextBox();
            this.txtSaveImageSubFolderPattern = new System.Windows.Forms.TextBox();
            this.cbUseCustomHistoryPath = new System.Windows.Forms.CheckBox();
            this.btnBrowseCustomUploadersConfigPath = new System.Windows.Forms.Button();
            this.tpHotkeys = new System.Windows.Forms.TabPage();
            this.hmHotkeys = new HelpersLib.Hotkey.HotkeyManagerControl();
            this.tpImage = new System.Windows.Forms.TabPage();
            this.tcImage = new System.Windows.Forms.TabControl();
            this.tpQuality = new System.Windows.Forms.TabPage();
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
            this.tpCapture = new System.Windows.Forms.TabPage();
            this.tcCapture = new System.Windows.Forms.TabControl();
            this.tpCaptureGeneral = new System.Windows.Forms.TabPage();
            this.cbCaptureShadow = new System.Windows.Forms.CheckBox();
            this.gbCaptureAfter = new System.Windows.Forms.GroupBox();
            this.cbCapturePerformActions = new System.Windows.Forms.CheckBox();
            this.cbCaptureSaveImageWithDialog = new System.Windows.Forms.CheckBox();
            this.cbCaptureUploadImage = new System.Windows.Forms.CheckBox();
            this.cbCaptureSaveImage = new System.Windows.Forms.CheckBox();
            this.cbCaptureCopyImage = new System.Windows.Forms.CheckBox();
            this.cbShowCursor = new System.Windows.Forms.CheckBox();
            this.cbCaptureTransparent = new System.Windows.Forms.CheckBox();
            this.tpCaptureShape = new System.Windows.Forms.TabPage();
            this.btnOpenCapturingShapesWiki = new System.Windows.Forms.Button();
            this.cbShapeForceWindowCapture = new System.Windows.Forms.CheckBox();
            this.cbShapeIncludeControls = new System.Windows.Forms.CheckBox();
            this.lblFixedShapeSizeHeight = new System.Windows.Forms.Label();
            this.cbDrawBorder = new System.Windows.Forms.CheckBox();
            this.lblFixedShapeSizeWidth = new System.Windows.Forms.Label();
            this.cbQuickCrop = new System.Windows.Forms.CheckBox();
            this.nudFixedShapeSizeHeight = new System.Windows.Forms.NumericUpDown();
            this.cbDrawCheckerboard = new System.Windows.Forms.CheckBox();
            this.nudFixedShapeSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.cbFixedShapeSize = new System.Windows.Forms.CheckBox();
            this.tpActions = new System.Windows.Forms.TabPage();
            this.btnActionsEdit = new System.Windows.Forms.Button();
            this.btnActionsRemove = new System.Windows.Forms.Button();
            this.btnActionsAdd = new System.Windows.Forms.Button();
            this.lvActions = new HelpersLib.MyListView();
            this.chActionsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chActionsPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chActionsArgs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpUpload = new System.Windows.Forms.TabPage();
            this.gbClipboardUpload = new System.Windows.Forms.GroupBox();
            this.cbClipboardUploadAutoDetectURL = new System.Windows.Forms.CheckBox();
            this.btnNameFormatPatternHelp = new System.Windows.Forms.Button();
            this.lblNameFormatPatternPreview = new System.Windows.Forms.Label();
            this.txtNameFormatPattern = new System.Windows.Forms.TextBox();
            this.lblNameFormatPattern = new System.Windows.Forms.Label();
            this.lblUploadLimitHint = new System.Windows.Forms.Label();
            this.nudUploadLimit = new System.Windows.Forms.NumericUpDown();
            this.lblUploadLimit = new System.Windows.Forms.Label();
            this.lblBufferSize = new System.Windows.Forms.Label();
            this.lblBufferSizeInfo = new System.Windows.Forms.Label();
            this.cbBufferSize = new System.Windows.Forms.ComboBox();
            this.tpProxy = new System.Windows.Forms.TabPage();
            this.cboProxyType = new System.Windows.Forms.ComboBox();
            this.lblProxyType = new System.Windows.Forms.Label();
            this.lblProxyHost = new System.Windows.Forms.Label();
            this.txtProxyHost = new System.Windows.Forms.TextBox();
            this.nudProxyPort = new System.Windows.Forms.NumericUpDown();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.lblProxyPassword = new System.Windows.Forms.Label();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.lblProxyUsername = new System.Windows.Forms.Label();
            this.txtProxyUsername = new System.Windows.Forms.TextBox();
            this.btnAutofillProxy = new System.Windows.Forms.Button();
            this.tpDebug = new System.Windows.Forms.TabPage();
            this.txtDebugLog = new System.Windows.Forms.TextBox();
            this.tcSettings.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpPaths.SuspendLayout();
            this.tpHotkeys.SuspendLayout();
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
            this.tpCapture.SuspendLayout();
            this.tcCapture.SuspendLayout();
            this.tpCaptureGeneral.SuspendLayout();
            this.gbCaptureAfter.SuspendLayout();
            this.tpCaptureShape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedShapeSizeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedShapeSizeWidth)).BeginInit();
            this.tpActions.SuspendLayout();
            this.tpUpload.SuspendLayout();
            this.gbClipboardUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUploadLimit)).BeginInit();
            this.tpProxy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).BeginInit();
            this.tpDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbClipboardAutoCopy
            // 
            this.cbClipboardAutoCopy.AutoSize = true;
            this.cbClipboardAutoCopy.Location = new System.Drawing.Point(16, 136);
            this.cbClipboardAutoCopy.Name = "cbClipboardAutoCopy";
            this.cbClipboardAutoCopy.Size = new System.Drawing.Size(254, 17);
            this.cbClipboardAutoCopy.TabIndex = 5;
            this.cbClipboardAutoCopy.Text = "Copy URL to clipboard after upload is completed";
            this.cbClipboardAutoCopy.UseVisualStyleBackColor = true;
            this.cbClipboardAutoCopy.CheckedChanged += new System.EventHandler(this.cbClipboardAutoCopy_CheckedChanged);
            // 
            // cbPlaySoundAfterUpload
            // 
            this.cbPlaySoundAfterUpload.AutoSize = true;
            this.cbPlaySoundAfterUpload.Location = new System.Drawing.Point(16, 208);
            this.cbPlaySoundAfterUpload.Name = "cbPlaySoundAfterUpload";
            this.cbPlaySoundAfterUpload.Size = new System.Drawing.Size(199, 17);
            this.cbPlaySoundAfterUpload.TabIndex = 8;
            this.cbPlaySoundAfterUpload.Text = "Play sound after upload is completed";
            this.cbPlaySoundAfterUpload.UseVisualStyleBackColor = true;
            this.cbPlaySoundAfterUpload.CheckedChanged += new System.EventHandler(this.cbPlaySoundAfterUpload_CheckedChanged);
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpGeneral);
            this.tcSettings.Controls.Add(this.tpPaths);
            this.tcSettings.Controls.Add(this.tpHotkeys);
            this.tcSettings.Controls.Add(this.tpImage);
            this.tcSettings.Controls.Add(this.tpCapture);
            this.tcSettings.Controls.Add(this.tpActions);
            this.tcSettings.Controls.Add(this.tpUpload);
            this.tcSettings.Controls.Add(this.tpProxy);
            this.tcSettings.Controls.Add(this.tpDebug);
            this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettings.Location = new System.Drawing.Point(3, 3);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(530, 356);
            this.tcSettings.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.cbTrayBalloonTipAfterUpload);
            this.tpGeneral.Controls.Add(this.lblGeneralSeparator2);
            this.tpGeneral.Controls.Add(this.cbHistorySave);
            this.tpGeneral.Controls.Add(this.cbPlaySoundAfterCapture);
            this.tpGeneral.Controls.Add(this.cbCheckUpdates);
            this.tpGeneral.Controls.Add(this.lblGeneralSeparator);
            this.tpGeneral.Controls.Add(this.cbStartWithWindows);
            this.tpGeneral.Controls.Add(this.cbShowTray);
            this.tpGeneral.Controls.Add(this.cbURLShortenAfterUpload);
            this.tpGeneral.Controls.Add(this.cbShellContextMenu);
            this.tpGeneral.Controls.Add(this.cbClipboardAutoCopy);
            this.tpGeneral.Controls.Add(this.cbPlaySoundAfterUpload);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(522, 330);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // cbTrayBalloonTipAfterUpload
            // 
            this.cbTrayBalloonTipAfterUpload.AutoSize = true;
            this.cbTrayBalloonTipAfterUpload.Location = new System.Drawing.Point(16, 232);
            this.cbTrayBalloonTipAfterUpload.Name = "cbTrayBalloonTipAfterUpload";
            this.cbTrayBalloonTipAfterUpload.Size = new System.Drawing.Size(245, 17);
            this.cbTrayBalloonTipAfterUpload.TabIndex = 9;
            this.cbTrayBalloonTipAfterUpload.Text = "Show tray balloon tip after upload is completed";
            this.cbTrayBalloonTipAfterUpload.UseVisualStyleBackColor = true;
            this.cbTrayBalloonTipAfterUpload.CheckedChanged += new System.EventHandler(this.cbTrayBalloonTipAfterUpload_CheckedChanged);
            // 
            // lblGeneralSeparator2
            // 
            this.lblGeneralSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGeneralSeparator2.Location = new System.Drawing.Point(16, 264);
            this.lblGeneralSeparator2.Name = "lblGeneralSeparator2";
            this.lblGeneralSeparator2.Size = new System.Drawing.Size(475, 2);
            this.lblGeneralSeparator2.TabIndex = 10;
            this.lblGeneralSeparator2.Text = "label2";
            // 
            // cbHistorySave
            // 
            this.cbHistorySave.AutoSize = true;
            this.cbHistorySave.Location = new System.Drawing.Point(16, 280);
            this.cbHistorySave.Name = "cbHistorySave";
            this.cbHistorySave.Size = new System.Drawing.Size(118, 17);
            this.cbHistorySave.TabIndex = 11;
            this.cbHistorySave.Text = "Enable history save";
            this.cbHistorySave.UseVisualStyleBackColor = true;
            this.cbHistorySave.CheckedChanged += new System.EventHandler(this.cbHistorySave_CheckedChanged);
            // 
            // cbPlaySoundAfterCapture
            // 
            this.cbPlaySoundAfterCapture.AutoSize = true;
            this.cbPlaySoundAfterCapture.Location = new System.Drawing.Point(16, 184);
            this.cbPlaySoundAfterCapture.Name = "cbPlaySoundAfterCapture";
            this.cbPlaySoundAfterCapture.Size = new System.Drawing.Size(180, 17);
            this.cbPlaySoundAfterCapture.TabIndex = 7;
            this.cbPlaySoundAfterCapture.Text = "Play sound after capture is made";
            this.cbPlaySoundAfterCapture.UseVisualStyleBackColor = true;
            this.cbPlaySoundAfterCapture.CheckedChanged += new System.EventHandler(this.cbPlaySoundAfterCapture_CheckedChanged);
            // 
            // cbCheckUpdates
            // 
            this.cbCheckUpdates.AutoSize = true;
            this.cbCheckUpdates.Location = new System.Drawing.Point(16, 88);
            this.cbCheckUpdates.Name = "cbCheckUpdates";
            this.cbCheckUpdates.Size = new System.Drawing.Size(209, 17);
            this.cbCheckUpdates.TabIndex = 3;
            this.cbCheckUpdates.Text = "Automatically check updates at startup";
            this.cbCheckUpdates.UseVisualStyleBackColor = true;
            this.cbCheckUpdates.CheckedChanged += new System.EventHandler(this.cbCheckUpdates_CheckedChanged);
            // 
            // lblGeneralSeparator
            // 
            this.lblGeneralSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGeneralSeparator.Location = new System.Drawing.Point(16, 120);
            this.lblGeneralSeparator.Name = "lblGeneralSeparator";
            this.lblGeneralSeparator.Size = new System.Drawing.Size(475, 2);
            this.lblGeneralSeparator.TabIndex = 4;
            // 
            // cbStartWithWindows
            // 
            this.cbStartWithWindows.AutoSize = true;
            this.cbStartWithWindows.Location = new System.Drawing.Point(16, 40);
            this.cbStartWithWindows.Name = "cbStartWithWindows";
            this.cbStartWithWindows.Size = new System.Drawing.Size(183, 17);
            this.cbStartWithWindows.TabIndex = 1;
            this.cbStartWithWindows.Text = "Start ShareX on Windows startup";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            this.cbStartWithWindows.CheckedChanged += new System.EventHandler(this.cbStartWithWindows_CheckedChanged);
            // 
            // cbShowTray
            // 
            this.cbShowTray.AutoSize = true;
            this.cbShowTray.Location = new System.Drawing.Point(16, 16);
            this.cbShowTray.Name = "cbShowTray";
            this.cbShowTray.Size = new System.Drawing.Size(96, 17);
            this.cbShowTray.TabIndex = 0;
            this.cbShowTray.Text = "Show tray icon";
            this.cbShowTray.UseVisualStyleBackColor = true;
            this.cbShowTray.CheckedChanged += new System.EventHandler(this.cbShowTray_CheckedChanged);
            // 
            // cbURLShortenAfterUpload
            // 
            this.cbURLShortenAfterUpload.AutoSize = true;
            this.cbURLShortenAfterUpload.Location = new System.Drawing.Point(16, 160);
            this.cbURLShortenAfterUpload.Name = "cbURLShortenAfterUpload";
            this.cbURLShortenAfterUpload.Size = new System.Drawing.Size(240, 17);
            this.cbURLShortenAfterUpload.TabIndex = 6;
            this.cbURLShortenAfterUpload.Text = "Use URL Shortener after upload is completed";
            this.cbURLShortenAfterUpload.UseVisualStyleBackColor = true;
            this.cbURLShortenAfterUpload.CheckedChanged += new System.EventHandler(this.cbURLShortenAfterUpload_CheckedChanged);
            // 
            // cbShellContextMenu
            // 
            this.cbShellContextMenu.AutoSize = true;
            this.cbShellContextMenu.Location = new System.Drawing.Point(16, 64);
            this.cbShellContextMenu.Name = "cbShellContextMenu";
            this.cbShellContextMenu.Size = new System.Drawing.Size(181, 17);
            this.cbShellContextMenu.TabIndex = 2;
            this.cbShellContextMenu.Text = "Show ShareX in \"Send to\" menu";
            this.cbShellContextMenu.UseVisualStyleBackColor = true;
            this.cbShellContextMenu.CheckedChanged += new System.EventHandler(this.cbShellContextMenu_CheckedChanged);
            // 
            // tpPaths
            // 
            this.tpPaths.Controls.Add(this.btnBrowseCustomScreenshotsPath);
            this.tpPaths.Controls.Add(this.btnOpenPersonalFolder);
            this.tpPaths.Controls.Add(this.btnLoadUploadersConfig);
            this.tpPaths.Controls.Add(this.txtCustomHistoryPath);
            this.tpPaths.Controls.Add(this.txtCustomScreenshotsPath);
            this.tpPaths.Controls.Add(this.cbUseCustomUploadersConfigPath);
            this.tpPaths.Controls.Add(this.cbUseCustomScreenshotsPath);
            this.tpPaths.Controls.Add(this.lblSaveImageSubFolderPattern);
            this.tpPaths.Controls.Add(this.btnBrowseCustomHistoryPath);
            this.tpPaths.Controls.Add(this.lblSaveImageSubFolderPatternPreview);
            this.tpPaths.Controls.Add(this.txtCustomUploadersConfigPath);
            this.tpPaths.Controls.Add(this.txtSaveImageSubFolderPattern);
            this.tpPaths.Controls.Add(this.cbUseCustomHistoryPath);
            this.tpPaths.Controls.Add(this.btnBrowseCustomUploadersConfigPath);
            this.tpPaths.Location = new System.Drawing.Point(4, 22);
            this.tpPaths.Name = "tpPaths";
            this.tpPaths.Padding = new System.Windows.Forms.Padding(3);
            this.tpPaths.Size = new System.Drawing.Size(522, 330);
            this.tpPaths.TabIndex = 1;
            this.tpPaths.Text = "Paths";
            this.tpPaths.UseVisualStyleBackColor = true;
            // 
            // btnBrowseCustomScreenshotsPath
            // 
            this.btnBrowseCustomScreenshotsPath.Location = new System.Drawing.Point(432, 191);
            this.btnBrowseCustomScreenshotsPath.Name = "btnBrowseCustomScreenshotsPath";
            this.btnBrowseCustomScreenshotsPath.Size = new System.Drawing.Size(80, 23);
            this.btnBrowseCustomScreenshotsPath.TabIndex = 10;
            this.btnBrowseCustomScreenshotsPath.Text = "Browse...";
            this.btnBrowseCustomScreenshotsPath.UseVisualStyleBackColor = true;
            this.btnBrowseCustomScreenshotsPath.Click += new System.EventHandler(this.btnBrowseCustomScreenshotsPath_Click);
            // 
            // btnOpenPersonalFolder
            // 
            this.btnOpenPersonalFolder.Location = new System.Drawing.Point(16, 16);
            this.btnOpenPersonalFolder.Name = "btnOpenPersonalFolder";
            this.btnOpenPersonalFolder.Size = new System.Drawing.Size(176, 23);
            this.btnOpenPersonalFolder.TabIndex = 0;
            this.btnOpenPersonalFolder.Text = "Open ShareX personal folder";
            this.btnOpenPersonalFolder.UseVisualStyleBackColor = true;
            this.btnOpenPersonalFolder.Click += new System.EventHandler(this.btnOpenPersonalFolder_Click);
            // 
            // btnLoadUploadersConfig
            // 
            this.btnLoadUploadersConfig.Location = new System.Drawing.Point(432, 79);
            this.btnLoadUploadersConfig.Name = "btnLoadUploadersConfig";
            this.btnLoadUploadersConfig.Size = new System.Drawing.Size(80, 23);
            this.btnLoadUploadersConfig.TabIndex = 4;
            this.btnLoadUploadersConfig.Text = "Load";
            this.btnLoadUploadersConfig.UseVisualStyleBackColor = true;
            this.btnLoadUploadersConfig.Click += new System.EventHandler(this.btnLoadUploadersConfig_Click);
            // 
            // txtCustomHistoryPath
            // 
            this.txtCustomHistoryPath.Location = new System.Drawing.Point(16, 136);
            this.txtCustomHistoryPath.Name = "txtCustomHistoryPath";
            this.txtCustomHistoryPath.Size = new System.Drawing.Size(408, 20);
            this.txtCustomHistoryPath.TabIndex = 6;
            this.txtCustomHistoryPath.TextChanged += new System.EventHandler(this.txtCustomHistoryPath_TextChanged);
            // 
            // txtCustomScreenshotsPath
            // 
            this.txtCustomScreenshotsPath.Location = new System.Drawing.Point(16, 192);
            this.txtCustomScreenshotsPath.Name = "txtCustomScreenshotsPath";
            this.txtCustomScreenshotsPath.Size = new System.Drawing.Size(408, 20);
            this.txtCustomScreenshotsPath.TabIndex = 9;
            this.txtCustomScreenshotsPath.TextChanged += new System.EventHandler(this.txtCustomScreenshotsPath_TextChanged);
            // 
            // cbUseCustomUploadersConfigPath
            // 
            this.cbUseCustomUploadersConfigPath.AutoSize = true;
            this.cbUseCustomUploadersConfigPath.Location = new System.Drawing.Point(16, 56);
            this.cbUseCustomUploadersConfigPath.Name = "cbUseCustomUploadersConfigPath";
            this.cbUseCustomUploadersConfigPath.Size = new System.Drawing.Size(201, 17);
            this.cbUseCustomUploadersConfigPath.TabIndex = 1;
            this.cbUseCustomUploadersConfigPath.Text = "Use custom uploader config file path:";
            this.cbUseCustomUploadersConfigPath.UseVisualStyleBackColor = true;
            this.cbUseCustomUploadersConfigPath.CheckedChanged += new System.EventHandler(this.cbUseCustomUploadersConfigPath_CheckedChanged);
            // 
            // cbUseCustomScreenshotsPath
            // 
            this.cbUseCustomScreenshotsPath.AutoSize = true;
            this.cbUseCustomScreenshotsPath.Location = new System.Drawing.Point(16, 168);
            this.cbUseCustomScreenshotsPath.Name = "cbUseCustomScreenshotsPath";
            this.cbUseCustomScreenshotsPath.Size = new System.Drawing.Size(174, 17);
            this.cbUseCustomScreenshotsPath.TabIndex = 8;
            this.cbUseCustomScreenshotsPath.Text = "Use custom screenshots folder:";
            this.cbUseCustomScreenshotsPath.UseVisualStyleBackColor = true;
            this.cbUseCustomScreenshotsPath.CheckedChanged += new System.EventHandler(this.cbUseCustomScreenshotsPath_CheckedChanged);
            // 
            // lblSaveImageSubFolderPattern
            // 
            this.lblSaveImageSubFolderPattern.AutoSize = true;
            this.lblSaveImageSubFolderPattern.Location = new System.Drawing.Point(16, 224);
            this.lblSaveImageSubFolderPattern.Name = "lblSaveImageSubFolderPattern";
            this.lblSaveImageSubFolderPattern.Size = new System.Drawing.Size(94, 13);
            this.lblSaveImageSubFolderPattern.TabIndex = 11;
            this.lblSaveImageSubFolderPattern.Text = "Sub folder pattern:";
            // 
            // btnBrowseCustomHistoryPath
            // 
            this.btnBrowseCustomHistoryPath.Location = new System.Drawing.Point(432, 135);
            this.btnBrowseCustomHistoryPath.Name = "btnBrowseCustomHistoryPath";
            this.btnBrowseCustomHistoryPath.Size = new System.Drawing.Size(80, 23);
            this.btnBrowseCustomHistoryPath.TabIndex = 7;
            this.btnBrowseCustomHistoryPath.Text = "Browse...";
            this.btnBrowseCustomHistoryPath.UseVisualStyleBackColor = true;
            this.btnBrowseCustomHistoryPath.Click += new System.EventHandler(this.btnBrowseCustomHistoryPath_Click);
            // 
            // lblSaveImageSubFolderPatternPreview
            // 
            this.lblSaveImageSubFolderPatternPreview.AutoSize = true;
            this.lblSaveImageSubFolderPatternPreview.Location = new System.Drawing.Point(16, 248);
            this.lblSaveImageSubFolderPatternPreview.Name = "lblSaveImageSubFolderPatternPreview";
            this.lblSaveImageSubFolderPatternPreview.Size = new System.Drawing.Size(16, 13);
            this.lblSaveImageSubFolderPatternPreview.TabIndex = 13;
            this.lblSaveImageSubFolderPatternPreview.Text = "...";
            // 
            // txtCustomUploadersConfigPath
            // 
            this.txtCustomUploadersConfigPath.Location = new System.Drawing.Point(16, 80);
            this.txtCustomUploadersConfigPath.Name = "txtCustomUploadersConfigPath";
            this.txtCustomUploadersConfigPath.Size = new System.Drawing.Size(320, 20);
            this.txtCustomUploadersConfigPath.TabIndex = 2;
            this.txtCustomUploadersConfigPath.TextChanged += new System.EventHandler(this.txtCustomUploadersConfigPath_TextChanged);
            // 
            // txtSaveImageSubFolderPattern
            // 
            this.txtSaveImageSubFolderPattern.Location = new System.Drawing.Point(120, 220);
            this.txtSaveImageSubFolderPattern.Name = "txtSaveImageSubFolderPattern";
            this.txtSaveImageSubFolderPattern.Size = new System.Drawing.Size(304, 20);
            this.txtSaveImageSubFolderPattern.TabIndex = 12;
            this.txtSaveImageSubFolderPattern.TextChanged += new System.EventHandler(this.txtSaveImageSubFolderPattern_TextChanged);
            // 
            // cbUseCustomHistoryPath
            // 
            this.cbUseCustomHistoryPath.AutoSize = true;
            this.cbUseCustomHistoryPath.Location = new System.Drawing.Point(16, 112);
            this.cbUseCustomHistoryPath.Name = "cbUseCustomHistoryPath";
            this.cbUseCustomHistoryPath.Size = new System.Drawing.Size(158, 17);
            this.cbUseCustomHistoryPath.TabIndex = 5;
            this.cbUseCustomHistoryPath.Text = "Use custom history file path:";
            this.cbUseCustomHistoryPath.UseVisualStyleBackColor = true;
            this.cbUseCustomHistoryPath.CheckedChanged += new System.EventHandler(this.cbUseCustomHistoryPath_CheckedChanged);
            // 
            // btnBrowseCustomUploadersConfigPath
            // 
            this.btnBrowseCustomUploadersConfigPath.Location = new System.Drawing.Point(344, 79);
            this.btnBrowseCustomUploadersConfigPath.Name = "btnBrowseCustomUploadersConfigPath";
            this.btnBrowseCustomUploadersConfigPath.Size = new System.Drawing.Size(80, 23);
            this.btnBrowseCustomUploadersConfigPath.TabIndex = 3;
            this.btnBrowseCustomUploadersConfigPath.Text = "Browse...";
            this.btnBrowseCustomUploadersConfigPath.UseVisualStyleBackColor = true;
            this.btnBrowseCustomUploadersConfigPath.Click += new System.EventHandler(this.btnBrowseCustomUploadersConfigPath_Click);
            // 
            // tpHotkeys
            // 
            this.tpHotkeys.Controls.Add(this.hmHotkeys);
            this.tpHotkeys.Location = new System.Drawing.Point(4, 22);
            this.tpHotkeys.Name = "tpHotkeys";
            this.tpHotkeys.Size = new System.Drawing.Size(522, 330);
            this.tpHotkeys.TabIndex = 3;
            this.tpHotkeys.Text = "Hotkeys";
            this.tpHotkeys.UseVisualStyleBackColor = true;
            // 
            // hmHotkeys
            // 
            this.hmHotkeys.AutoScroll = true;
            this.hmHotkeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmHotkeys.Location = new System.Drawing.Point(0, 0);
            this.hmHotkeys.Name = "hmHotkeys";
            this.hmHotkeys.Size = new System.Drawing.Size(522, 330);
            this.hmHotkeys.TabIndex = 0;
            // 
            // tpImage
            // 
            this.tpImage.Controls.Add(this.tcImage);
            this.tpImage.Location = new System.Drawing.Point(4, 22);
            this.tpImage.Name = "tpImage";
            this.tpImage.Padding = new System.Windows.Forms.Padding(5);
            this.tpImage.Size = new System.Drawing.Size(522, 330);
            this.tpImage.TabIndex = 4;
            this.tpImage.Text = "Image";
            this.tpImage.UseVisualStyleBackColor = true;
            // 
            // tcImage
            // 
            this.tcImage.Controls.Add(this.tpQuality);
            this.tcImage.Controls.Add(this.tpResize);
            this.tcImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcImage.Location = new System.Drawing.Point(5, 5);
            this.tcImage.Name = "tcImage";
            this.tcImage.SelectedIndex = 0;
            this.tcImage.Size = new System.Drawing.Size(512, 320);
            this.tcImage.TabIndex = 0;
            // 
            // tpQuality
            // 
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
            this.tpQuality.Size = new System.Drawing.Size(504, 294);
            this.tpQuality.TabIndex = 0;
            this.tpQuality.Text = "Quality";
            this.tpQuality.UseVisualStyleBackColor = true;
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
            100,
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
            5000,
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
            this.tpResize.Size = new System.Drawing.Size(504, 294);
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
            // tpCapture
            // 
            this.tpCapture.Controls.Add(this.tcCapture);
            this.tpCapture.Location = new System.Drawing.Point(4, 22);
            this.tpCapture.Name = "tpCapture";
            this.tpCapture.Padding = new System.Windows.Forms.Padding(5);
            this.tpCapture.Size = new System.Drawing.Size(522, 330);
            this.tpCapture.TabIndex = 5;
            this.tpCapture.Text = "Capture";
            this.tpCapture.UseVisualStyleBackColor = true;
            // 
            // tcCapture
            // 
            this.tcCapture.Controls.Add(this.tpCaptureGeneral);
            this.tcCapture.Controls.Add(this.tpCaptureShape);
            this.tcCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCapture.Location = new System.Drawing.Point(5, 5);
            this.tcCapture.Name = "tcCapture";
            this.tcCapture.SelectedIndex = 0;
            this.tcCapture.Size = new System.Drawing.Size(512, 320);
            this.tcCapture.TabIndex = 0;
            // 
            // tpCaptureGeneral
            // 
            this.tpCaptureGeneral.Controls.Add(this.cbCaptureShadow);
            this.tpCaptureGeneral.Controls.Add(this.gbCaptureAfter);
            this.tpCaptureGeneral.Controls.Add(this.cbShowCursor);
            this.tpCaptureGeneral.Controls.Add(this.cbCaptureTransparent);
            this.tpCaptureGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpCaptureGeneral.Name = "tpCaptureGeneral";
            this.tpCaptureGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpCaptureGeneral.Size = new System.Drawing.Size(504, 294);
            this.tpCaptureGeneral.TabIndex = 0;
            this.tpCaptureGeneral.Text = "General";
            this.tpCaptureGeneral.UseVisualStyleBackColor = true;
            // 
            // cbCaptureShadow
            // 
            this.cbCaptureShadow.AutoSize = true;
            this.cbCaptureShadow.Location = new System.Drawing.Point(16, 64);
            this.cbCaptureShadow.Name = "cbCaptureShadow";
            this.cbCaptureShadow.Size = new System.Drawing.Size(274, 17);
            this.cbCaptureShadow.TabIndex = 2;
            this.cbCaptureShadow.Text = "Capture window with shadow (requires transparency)";
            this.cbCaptureShadow.UseVisualStyleBackColor = true;
            this.cbCaptureShadow.CheckedChanged += new System.EventHandler(this.cbCaptureShadow_CheckedChanged);
            // 
            // gbCaptureAfter
            // 
            this.gbCaptureAfter.Controls.Add(this.cbCapturePerformActions);
            this.gbCaptureAfter.Controls.Add(this.cbCaptureSaveImageWithDialog);
            this.gbCaptureAfter.Controls.Add(this.cbCaptureUploadImage);
            this.gbCaptureAfter.Controls.Add(this.cbCaptureSaveImage);
            this.gbCaptureAfter.Controls.Add(this.cbCaptureCopyImage);
            this.gbCaptureAfter.Location = new System.Drawing.Point(16, 96);
            this.gbCaptureAfter.Name = "gbCaptureAfter";
            this.gbCaptureAfter.Size = new System.Drawing.Size(472, 152);
            this.gbCaptureAfter.TabIndex = 3;
            this.gbCaptureAfter.TabStop = false;
            this.gbCaptureAfter.Text = "After capture tasks";
            // 
            // cbCapturePerformActions
            // 
            this.cbCapturePerformActions.AutoSize = true;
            this.cbCapturePerformActions.Location = new System.Drawing.Point(16, 96);
            this.cbCapturePerformActions.Name = "cbCapturePerformActions";
            this.cbCapturePerformActions.Size = new System.Drawing.Size(236, 17);
            this.cbCapturePerformActions.TabIndex = 4;
            this.cbCapturePerformActions.Text = "Perform actions (image must be saved to file)";
            this.cbCapturePerformActions.UseVisualStyleBackColor = true;
            this.cbCapturePerformActions.CheckedChanged += new System.EventHandler(this.cbCapturePerformActions_CheckedChanged);
            // 
            // cbCaptureSaveImageWithDialog
            // 
            this.cbCaptureSaveImageWithDialog.AutoSize = true;
            this.cbCaptureSaveImageWithDialog.Location = new System.Drawing.Point(16, 72);
            this.cbCaptureSaveImageWithDialog.Name = "cbCaptureSaveImageWithDialog";
            this.cbCaptureSaveImageWithDialog.Size = new System.Drawing.Size(163, 17);
            this.cbCaptureSaveImageWithDialog.TabIndex = 2;
            this.cbCaptureSaveImageWithDialog.Text = "Save image to file with dialog";
            this.cbCaptureSaveImageWithDialog.UseVisualStyleBackColor = true;
            this.cbCaptureSaveImageWithDialog.CheckedChanged += new System.EventHandler(this.cbCaptureSaveImageWithDialog_CheckedChanged);
            // 
            // cbCaptureUploadImage
            // 
            this.cbCaptureUploadImage.AutoSize = true;
            this.cbCaptureUploadImage.Location = new System.Drawing.Point(16, 120);
            this.cbCaptureUploadImage.Name = "cbCaptureUploadImage";
            this.cbCaptureUploadImage.Size = new System.Drawing.Size(161, 17);
            this.cbCaptureUploadImage.TabIndex = 3;
            this.cbCaptureUploadImage.Text = "Upload image to remote host";
            this.cbCaptureUploadImage.UseVisualStyleBackColor = true;
            this.cbCaptureUploadImage.CheckedChanged += new System.EventHandler(this.cbCaptureUploadImage_CheckedChanged);
            // 
            // cbCaptureSaveImage
            // 
            this.cbCaptureSaveImage.AutoSize = true;
            this.cbCaptureSaveImage.Location = new System.Drawing.Point(16, 48);
            this.cbCaptureSaveImage.Name = "cbCaptureSaveImage";
            this.cbCaptureSaveImage.Size = new System.Drawing.Size(110, 17);
            this.cbCaptureSaveImage.TabIndex = 1;
            this.cbCaptureSaveImage.Text = "Save image to file";
            this.cbCaptureSaveImage.UseVisualStyleBackColor = true;
            this.cbCaptureSaveImage.CheckedChanged += new System.EventHandler(this.cbCaptureSaveImage_CheckedChanged);
            // 
            // cbCaptureCopyImage
            // 
            this.cbCaptureCopyImage.AutoSize = true;
            this.cbCaptureCopyImage.Location = new System.Drawing.Point(16, 24);
            this.cbCaptureCopyImage.Name = "cbCaptureCopyImage";
            this.cbCaptureCopyImage.Size = new System.Drawing.Size(139, 17);
            this.cbCaptureCopyImage.TabIndex = 0;
            this.cbCaptureCopyImage.Text = "Copy image to clipboard\r\n";
            this.cbCaptureCopyImage.UseVisualStyleBackColor = true;
            this.cbCaptureCopyImage.CheckedChanged += new System.EventHandler(this.cbCaptureCopyImage_CheckedChanged);
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
            this.tpCaptureShape.Controls.Add(this.cbQuickCrop);
            this.tpCaptureShape.Controls.Add(this.nudFixedShapeSizeHeight);
            this.tpCaptureShape.Controls.Add(this.cbDrawCheckerboard);
            this.tpCaptureShape.Controls.Add(this.nudFixedShapeSizeWidth);
            this.tpCaptureShape.Controls.Add(this.cbFixedShapeSize);
            this.tpCaptureShape.Location = new System.Drawing.Point(4, 22);
            this.tpCaptureShape.Name = "tpCaptureShape";
            this.tpCaptureShape.Padding = new System.Windows.Forms.Padding(3);
            this.tpCaptureShape.Size = new System.Drawing.Size(504, 294);
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
            this.cbDrawBorder.Location = new System.Drawing.Point(16, 16);
            this.cbDrawBorder.Name = "cbDrawBorder";
            this.cbDrawBorder.Size = new System.Drawing.Size(170, 17);
            this.cbDrawBorder.TabIndex = 1;
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
            // cbQuickCrop
            // 
            this.cbQuickCrop.AutoSize = true;
            this.cbQuickCrop.Location = new System.Drawing.Point(16, 64);
            this.cbQuickCrop.Name = "cbQuickCrop";
            this.cbQuickCrop.Size = new System.Drawing.Size(455, 17);
            this.cbQuickCrop.TabIndex = 3;
            this.cbQuickCrop.Text = "Complete capture as soon as the mouse button is released, except when capturing p" +
    "olygon";
            this.cbQuickCrop.UseVisualStyleBackColor = true;
            this.cbQuickCrop.CheckedChanged += new System.EventHandler(this.cbQuickCrop_CheckedChanged);
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
            this.cbDrawCheckerboard.Size = new System.Drawing.Size(287, 17);
            this.cbDrawCheckerboard.TabIndex = 2;
            this.cbDrawCheckerboard.Text = "Draw checkerboard pattern replacing transparent areas";
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
            // tpActions
            // 
            this.tpActions.Controls.Add(this.btnActionsEdit);
            this.tpActions.Controls.Add(this.btnActionsRemove);
            this.tpActions.Controls.Add(this.btnActionsAdd);
            this.tpActions.Controls.Add(this.lvActions);
            this.tpActions.Location = new System.Drawing.Point(4, 22);
            this.tpActions.Name = "tpActions";
            this.tpActions.Padding = new System.Windows.Forms.Padding(3);
            this.tpActions.Size = new System.Drawing.Size(522, 330);
            this.tpActions.TabIndex = 8;
            this.tpActions.Text = "Actions";
            this.tpActions.UseVisualStyleBackColor = true;
            // 
            // btnActionsEdit
            // 
            this.btnActionsEdit.Location = new System.Drawing.Point(96, 16);
            this.btnActionsEdit.Name = "btnActionsEdit";
            this.btnActionsEdit.Size = new System.Drawing.Size(75, 23);
            this.btnActionsEdit.TabIndex = 4;
            this.btnActionsEdit.Text = "Edit";
            this.btnActionsEdit.UseVisualStyleBackColor = true;
            this.btnActionsEdit.Click += new System.EventHandler(this.btnActionsEdit_Click);
            // 
            // btnActionsRemove
            // 
            this.btnActionsRemove.Location = new System.Drawing.Point(176, 16);
            this.btnActionsRemove.Name = "btnActionsRemove";
            this.btnActionsRemove.Size = new System.Drawing.Size(75, 23);
            this.btnActionsRemove.TabIndex = 3;
            this.btnActionsRemove.Text = "Remove";
            this.btnActionsRemove.UseVisualStyleBackColor = true;
            this.btnActionsRemove.Click += new System.EventHandler(this.btnActionsRemove_Click);
            // 
            // btnActionsAdd
            // 
            this.btnActionsAdd.Location = new System.Drawing.Point(16, 16);
            this.btnActionsAdd.Name = "btnActionsAdd";
            this.btnActionsAdd.Size = new System.Drawing.Size(75, 23);
            this.btnActionsAdd.TabIndex = 2;
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
            this.lvActions.Location = new System.Drawing.Point(16, 48);
            this.lvActions.MultiSelect = false;
            this.lvActions.Name = "lvActions";
            this.lvActions.Size = new System.Drawing.Size(488, 264);
            this.lvActions.TabIndex = 1;
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
            // tpUpload
            // 
            this.tpUpload.Controls.Add(this.gbClipboardUpload);
            this.tpUpload.Controls.Add(this.lblUploadLimitHint);
            this.tpUpload.Controls.Add(this.nudUploadLimit);
            this.tpUpload.Controls.Add(this.lblUploadLimit);
            this.tpUpload.Controls.Add(this.lblBufferSize);
            this.tpUpload.Controls.Add(this.lblBufferSizeInfo);
            this.tpUpload.Controls.Add(this.cbBufferSize);
            this.tpUpload.Location = new System.Drawing.Point(4, 22);
            this.tpUpload.Name = "tpUpload";
            this.tpUpload.Size = new System.Drawing.Size(522, 330);
            this.tpUpload.TabIndex = 2;
            this.tpUpload.Text = "Upload";
            this.tpUpload.UseVisualStyleBackColor = true;
            // 
            // gbClipboardUpload
            // 
            this.gbClipboardUpload.Controls.Add(this.cbClipboardUploadAutoDetectURL);
            this.gbClipboardUpload.Controls.Add(this.btnNameFormatPatternHelp);
            this.gbClipboardUpload.Controls.Add(this.lblNameFormatPatternPreview);
            this.gbClipboardUpload.Controls.Add(this.txtNameFormatPattern);
            this.gbClipboardUpload.Controls.Add(this.lblNameFormatPattern);
            this.gbClipboardUpload.Location = new System.Drawing.Point(16, 80);
            this.gbClipboardUpload.Name = "gbClipboardUpload";
            this.gbClipboardUpload.Size = new System.Drawing.Size(488, 136);
            this.gbClipboardUpload.TabIndex = 6;
            this.gbClipboardUpload.TabStop = false;
            this.gbClipboardUpload.Text = "Clipboard upload";
            // 
            // cbClipboardUploadAutoDetectURL
            // 
            this.cbClipboardUploadAutoDetectURL.AutoSize = true;
            this.cbClipboardUploadAutoDetectURL.Location = new System.Drawing.Point(16, 24);
            this.cbClipboardUploadAutoDetectURL.Name = "cbClipboardUploadAutoDetectURL";
            this.cbClipboardUploadAutoDetectURL.Size = new System.Drawing.Size(401, 17);
            this.cbClipboardUploadAutoDetectURL.TabIndex = 0;
            this.cbClipboardUploadAutoDetectURL.Text = "Automatically detect URL when performing Text Upload and use URL shortener";
            this.cbClipboardUploadAutoDetectURL.UseVisualStyleBackColor = true;
            this.cbClipboardUploadAutoDetectURL.CheckedChanged += new System.EventHandler(this.cbClipboardUploadAutoDetectURL_CheckedChanged);
            // 
            // btnNameFormatPatternHelp
            // 
            this.btnNameFormatPatternHelp.Location = new System.Drawing.Point(440, 79);
            this.btnNameFormatPatternHelp.Name = "btnNameFormatPatternHelp";
            this.btnNameFormatPatternHelp.Size = new System.Drawing.Size(24, 23);
            this.btnNameFormatPatternHelp.TabIndex = 3;
            this.btnNameFormatPatternHelp.Text = "?";
            this.btnNameFormatPatternHelp.UseVisualStyleBackColor = true;
            this.btnNameFormatPatternHelp.Click += new System.EventHandler(this.btnNameFormatPatternHelp_Click);
            // 
            // lblNameFormatPatternPreview
            // 
            this.lblNameFormatPatternPreview.AutoSize = true;
            this.lblNameFormatPatternPreview.Location = new System.Drawing.Point(16, 112);
            this.lblNameFormatPatternPreview.Name = "lblNameFormatPatternPreview";
            this.lblNameFormatPatternPreview.Size = new System.Drawing.Size(48, 13);
            this.lblNameFormatPatternPreview.TabIndex = 4;
            this.lblNameFormatPatternPreview.Text = "Preview:";
            // 
            // txtNameFormatPattern
            // 
            this.txtNameFormatPattern.Location = new System.Drawing.Point(16, 80);
            this.txtNameFormatPattern.Name = "txtNameFormatPattern";
            this.txtNameFormatPattern.Size = new System.Drawing.Size(416, 20);
            this.txtNameFormatPattern.TabIndex = 2;
            this.txtNameFormatPattern.TextChanged += new System.EventHandler(this.txtNameFormatPattern_TextChanged);
            // 
            // lblNameFormatPattern
            // 
            this.lblNameFormatPattern.AutoSize = true;
            this.lblNameFormatPattern.Location = new System.Drawing.Point(16, 56);
            this.lblNameFormatPattern.Name = "lblNameFormatPattern";
            this.lblNameFormatPattern.Size = new System.Drawing.Size(362, 13);
            this.lblNameFormatPattern.TabIndex = 1;
            this.lblNameFormatPattern.Text = "Clipboard upload name pattern for image and text (Not image file or text file):";
            // 
            // lblUploadLimitHint
            // 
            this.lblUploadLimitHint.AutoSize = true;
            this.lblUploadLimitHint.Location = new System.Drawing.Point(216, 16);
            this.lblUploadLimitHint.Name = "lblUploadLimitHint";
            this.lblUploadLimitHint.Size = new System.Drawing.Size(90, 13);
            this.lblUploadLimitHint.TabIndex = 2;
            this.lblUploadLimitHint.Text = "0 - 25 (0 disables)";
            // 
            // nudUploadLimit
            // 
            this.nudUploadLimit.Location = new System.Drawing.Point(152, 12);
            this.nudUploadLimit.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudUploadLimit.Name = "nudUploadLimit";
            this.nudUploadLimit.Size = new System.Drawing.Size(56, 20);
            this.nudUploadLimit.TabIndex = 1;
            this.nudUploadLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudUploadLimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudUploadLimit.ValueChanged += new System.EventHandler(this.nudUploadLimit_ValueChanged);
            // 
            // lblUploadLimit
            // 
            this.lblUploadLimit.AutoSize = true;
            this.lblUploadLimit.Location = new System.Drawing.Point(16, 16);
            this.lblUploadLimit.Name = "lblUploadLimit";
            this.lblUploadLimit.Size = new System.Drawing.Size(128, 13);
            this.lblUploadLimit.TabIndex = 0;
            this.lblUploadLimit.Text = "Simultaneous upload limit:";
            // 
            // lblBufferSize
            // 
            this.lblBufferSize.AutoSize = true;
            this.lblBufferSize.Location = new System.Drawing.Point(16, 48);
            this.lblBufferSize.Name = "lblBufferSize";
            this.lblBufferSize.Size = new System.Drawing.Size(59, 13);
            this.lblBufferSize.TabIndex = 3;
            this.lblBufferSize.Text = "Buffer size:";
            // 
            // lblBufferSizeInfo
            // 
            this.lblBufferSizeInfo.AutoSize = true;
            this.lblBufferSizeInfo.Location = new System.Drawing.Point(152, 48);
            this.lblBufferSizeInfo.Name = "lblBufferSizeInfo";
            this.lblBufferSizeInfo.Size = new System.Drawing.Size(20, 13);
            this.lblBufferSizeInfo.TabIndex = 5;
            this.lblBufferSizeInfo.Text = "kB";
            // 
            // cbBufferSize
            // 
            this.cbBufferSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBufferSize.FormattingEnabled = true;
            this.cbBufferSize.Location = new System.Drawing.Point(80, 44);
            this.cbBufferSize.Name = "cbBufferSize";
            this.cbBufferSize.Size = new System.Drawing.Size(64, 21);
            this.cbBufferSize.TabIndex = 4;
            this.cbBufferSize.SelectedIndexChanged += new System.EventHandler(this.cbBufferSize_SelectedIndexChanged);
            // 
            // tpProxy
            // 
            this.tpProxy.Controls.Add(this.cboProxyType);
            this.tpProxy.Controls.Add(this.lblProxyType);
            this.tpProxy.Controls.Add(this.lblProxyHost);
            this.tpProxy.Controls.Add(this.txtProxyHost);
            this.tpProxy.Controls.Add(this.nudProxyPort);
            this.tpProxy.Controls.Add(this.lblProxyPort);
            this.tpProxy.Controls.Add(this.lblProxyPassword);
            this.tpProxy.Controls.Add(this.txtProxyPassword);
            this.tpProxy.Controls.Add(this.lblProxyUsername);
            this.tpProxy.Controls.Add(this.txtProxyUsername);
            this.tpProxy.Controls.Add(this.btnAutofillProxy);
            this.tpProxy.Location = new System.Drawing.Point(4, 22);
            this.tpProxy.Name = "tpProxy";
            this.tpProxy.Padding = new System.Windows.Forms.Padding(5);
            this.tpProxy.Size = new System.Drawing.Size(522, 330);
            this.tpProxy.TabIndex = 6;
            this.tpProxy.Text = "Proxy";
            this.tpProxy.UseVisualStyleBackColor = true;
            // 
            // cboProxyType
            // 
            this.cboProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProxyType.FormattingEnabled = true;
            this.cboProxyType.Location = new System.Drawing.Point(88, 108);
            this.cboProxyType.Name = "cboProxyType";
            this.cboProxyType.Size = new System.Drawing.Size(304, 21);
            this.cboProxyType.TabIndex = 9;
            this.cboProxyType.SelectedIndexChanged += new System.EventHandler(this.cboProxyType_SelectedIndexChanged);
            // 
            // lblProxyType
            // 
            this.lblProxyType.AutoSize = true;
            this.lblProxyType.Location = new System.Drawing.Point(16, 112);
            this.lblProxyType.Name = "lblProxyType";
            this.lblProxyType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProxyType.Size = new System.Drawing.Size(31, 13);
            this.lblProxyType.TabIndex = 8;
            this.lblProxyType.Text = "Type";
            // 
            // lblProxyHost
            // 
            this.lblProxyHost.AutoSize = true;
            this.lblProxyHost.Location = new System.Drawing.Point(16, 80);
            this.lblProxyHost.Name = "lblProxyHost";
            this.lblProxyHost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProxyHost.Size = new System.Drawing.Size(29, 13);
            this.lblProxyHost.TabIndex = 4;
            this.lblProxyHost.Text = "Host";
            // 
            // txtProxyHost
            // 
            this.txtProxyHost.Location = new System.Drawing.Point(88, 76);
            this.txtProxyHost.Name = "txtProxyHost";
            this.txtProxyHost.Size = new System.Drawing.Size(304, 20);
            this.txtProxyHost.TabIndex = 5;
            this.txtProxyHost.TextChanged += new System.EventHandler(this.txtProxyHost_TextChanged);
            // 
            // nudProxyPort
            // 
            this.nudProxyPort.Location = new System.Drawing.Point(432, 76);
            this.nudProxyPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudProxyPort.Minimum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.nudProxyPort.Name = "nudProxyPort";
            this.nudProxyPort.Size = new System.Drawing.Size(72, 20);
            this.nudProxyPort.TabIndex = 7;
            this.nudProxyPort.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.nudProxyPort.ValueChanged += new System.EventHandler(this.nudProxyPort_ValueChanged);
            // 
            // lblProxyPort
            // 
            this.lblProxyPort.AutoSize = true;
            this.lblProxyPort.Location = new System.Drawing.Point(400, 80);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProxyPort.Size = new System.Drawing.Size(26, 13);
            this.lblProxyPort.TabIndex = 6;
            this.lblProxyPort.Text = "Port";
            // 
            // lblProxyPassword
            // 
            this.lblProxyPassword.AutoSize = true;
            this.lblProxyPassword.Location = new System.Drawing.Point(16, 48);
            this.lblProxyPassword.Name = "lblProxyPassword";
            this.lblProxyPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProxyPassword.Size = new System.Drawing.Size(53, 13);
            this.lblProxyPassword.TabIndex = 2;
            this.lblProxyPassword.Text = "Password";
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Location = new System.Drawing.Point(88, 44);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.PasswordChar = '●';
            this.txtProxyPassword.Size = new System.Drawing.Size(416, 20);
            this.txtProxyPassword.TabIndex = 3;
            this.txtProxyPassword.TextChanged += new System.EventHandler(this.txtProxyPassword_TextChanged);
            // 
            // lblProxyUsername
            // 
            this.lblProxyUsername.AutoSize = true;
            this.lblProxyUsername.Location = new System.Drawing.Point(16, 16);
            this.lblProxyUsername.Name = "lblProxyUsername";
            this.lblProxyUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProxyUsername.Size = new System.Drawing.Size(58, 13);
            this.lblProxyUsername.TabIndex = 0;
            this.lblProxyUsername.Text = "User name";
            // 
            // txtProxyUsername
            // 
            this.txtProxyUsername.Location = new System.Drawing.Point(88, 12);
            this.txtProxyUsername.Name = "txtProxyUsername";
            this.txtProxyUsername.Size = new System.Drawing.Size(416, 20);
            this.txtProxyUsername.TabIndex = 1;
            this.txtProxyUsername.TextChanged += new System.EventHandler(this.txtProxyUsername_TextChanged);
            // 
            // btnAutofillProxy
            // 
            this.btnAutofillProxy.Location = new System.Drawing.Point(16, 144);
            this.btnAutofillProxy.Name = "btnAutofillProxy";
            this.btnAutofillProxy.Size = new System.Drawing.Size(75, 23);
            this.btnAutofillProxy.TabIndex = 10;
            this.btnAutofillProxy.Text = "Autofill";
            this.btnAutofillProxy.UseVisualStyleBackColor = true;
            this.btnAutofillProxy.Click += new System.EventHandler(this.btnAutofillProxy_Click);
            // 
            // tpDebug
            // 
            this.tpDebug.Controls.Add(this.txtDebugLog);
            this.tpDebug.Location = new System.Drawing.Point(4, 22);
            this.tpDebug.Name = "tpDebug";
            this.tpDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tpDebug.Size = new System.Drawing.Size(522, 330);
            this.tpDebug.TabIndex = 7;
            this.tpDebug.Text = "Debug";
            this.tpDebug.UseVisualStyleBackColor = true;
            // 
            // txtDebugLog
            // 
            this.txtDebugLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDebugLog.Location = new System.Drawing.Point(3, 3);
            this.txtDebugLog.Multiline = true;
            this.txtDebugLog.Name = "txtDebugLog";
            this.txtDebugLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebugLog.Size = new System.Drawing.Size(516, 324);
            this.txtDebugLog.TabIndex = 0;
            this.txtDebugLog.WordWrap = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 362);
            this.Controls.Add(this.tcSettings);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(552, 400);
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShareX - Settings";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.Resize += new System.EventHandler(this.SettingsForm_Resize);
            this.tcSettings.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tpPaths.ResumeLayout(false);
            this.tpPaths.PerformLayout();
            this.tpHotkeys.ResumeLayout(false);
            this.tpImage.ResumeLayout(false);
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
            this.tpCapture.ResumeLayout(false);
            this.tcCapture.ResumeLayout(false);
            this.tpCaptureGeneral.ResumeLayout(false);
            this.tpCaptureGeneral.PerformLayout();
            this.gbCaptureAfter.ResumeLayout(false);
            this.gbCaptureAfter.PerformLayout();
            this.tpCaptureShape.ResumeLayout(false);
            this.tpCaptureShape.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedShapeSizeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedShapeSizeWidth)).EndInit();
            this.tpActions.ResumeLayout(false);
            this.tpUpload.ResumeLayout(false);
            this.tpUpload.PerformLayout();
            this.gbClipboardUpload.ResumeLayout(false);
            this.gbClipboardUpload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUploadLimit)).EndInit();
            this.tpProxy.ResumeLayout(false);
            this.tpProxy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).EndInit();
            this.tpDebug.ResumeLayout(false);
            this.tpDebug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.CheckBox cbClipboardAutoCopy;
        private System.Windows.Forms.CheckBox cbPlaySoundAfterUpload;
        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpProxy;
        private System.Windows.Forms.CheckBox cbShellContextMenu;
        private System.Windows.Forms.TextBox txtCustomHistoryPath;
        private System.Windows.Forms.CheckBox cbUseCustomHistoryPath;
        private System.Windows.Forms.CheckBox cbHistorySave;
        private System.Windows.Forms.Button btnBrowseCustomHistoryPath;
        private System.Windows.Forms.TabPage tpImage;
        private System.Windows.Forms.ComboBox cbImageFormat;
        private System.Windows.Forms.Label lblImageFormat;
        private System.Windows.Forms.ComboBox cbImageGIFQuality;
        private System.Windows.Forms.ComboBox cbImageFormat2;
        private System.Windows.Forms.Label lblImageFormat2;
        private System.Windows.Forms.Label lblUseImageFormat2After;
        private System.Windows.Forms.NumericUpDown nudUseImageFormat2After;
        private System.Windows.Forms.NumericUpDown nudImageJPEGQuality;
        private System.Windows.Forms.Label lblImageGIFQuality;
        private System.Windows.Forms.Label lblImageJPEGQuality;
        private System.Windows.Forms.Label lblUseImageFormat2AfterHint;
        private System.Windows.Forms.Label lblImageJPEGQualityHint;
        private System.Windows.Forms.TabPage tpDebug;
        private System.Windows.Forms.TextBox txtDebugLog;
        private System.Windows.Forms.Button btnNameFormatPatternHelp;
        private System.Windows.Forms.TextBox txtNameFormatPattern;
        private System.Windows.Forms.Label lblNameFormatPattern;
        private System.Windows.Forms.Label lblNameFormatPatternPreview;
        private System.Windows.Forms.TabPage tpUpload;
        private System.Windows.Forms.ComboBox cbBufferSize;
        private System.Windows.Forms.Label lblBufferSize;
        private System.Windows.Forms.Label lblBufferSizeInfo;
        private System.Windows.Forms.Button btnOpenPersonalFolder;
        private System.Windows.Forms.Label lblUploadLimitHint;
        private System.Windows.Forms.NumericUpDown nudUploadLimit;
        private System.Windows.Forms.Label lblUploadLimit;
        private System.Windows.Forms.CheckBox cbURLShortenAfterUpload;
        private System.Windows.Forms.Button btnBrowseCustomUploadersConfigPath;
        private System.Windows.Forms.TextBox txtCustomUploadersConfigPath;
        private System.Windows.Forms.CheckBox cbUseCustomUploadersConfigPath;
        private System.Windows.Forms.Button btnLoadUploadersConfig;
        private System.Windows.Forms.Button btnAutofillProxy;
        private System.Windows.Forms.CheckBox cbShowTray;
        private System.Windows.Forms.TabPage tpCapture;
        private System.Windows.Forms.TabPage tpHotkeys;
        private HelpersLib.Hotkey.HotkeyManagerControl hmHotkeys;
        private System.Windows.Forms.CheckBox cbShowCursor;
        private System.Windows.Forms.CheckBox cbDrawBorder;
        private System.Windows.Forms.CheckBox cbDrawCheckerboard;
        private System.Windows.Forms.CheckBox cbQuickCrop;
        private System.Windows.Forms.CheckBox cbFixedShapeSize;
        private System.Windows.Forms.Label lblFixedShapeSizeWidth;
        private System.Windows.Forms.NumericUpDown nudFixedShapeSizeHeight;
        private System.Windows.Forms.NumericUpDown nudFixedShapeSizeWidth;
        private System.Windows.Forms.Label lblFixedShapeSizeHeight;
        private System.Windows.Forms.CheckBox cbCaptureTransparent;
        private System.Windows.Forms.Label lblGeneralSeparator;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.TabControl tcCapture;
        private System.Windows.Forms.TabPage tpCaptureGeneral;
        private System.Windows.Forms.TabPage tpCaptureShape;
        private System.Windows.Forms.GroupBox gbCaptureAfter;
        private System.Windows.Forms.CheckBox cbCaptureUploadImage;
        private System.Windows.Forms.CheckBox cbCaptureSaveImage;
        private System.Windows.Forms.CheckBox cbCaptureCopyImage;
        private System.Windows.Forms.CheckBox cbShapeIncludeControls;
        private System.Windows.Forms.CheckBox cbShapeForceWindowCapture;
        private System.Windows.Forms.TabControl tcImage;
        private System.Windows.Forms.TabPage tpQuality;
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
        private System.Windows.Forms.Label lblSaveImageSubFolderPatternPreview;
        private System.Windows.Forms.TextBox txtSaveImageSubFolderPattern;
        private System.Windows.Forms.Label lblSaveImageSubFolderPattern;
        private System.Windows.Forms.CheckBox cbCheckUpdates;
        private System.Windows.Forms.CheckBox cbCaptureShadow;
        private System.Windows.Forms.CheckBox cbClipboardUploadAutoDetectURL;
        private System.Windows.Forms.CheckBox cbPlaySoundAfterCapture;
        private System.Windows.Forms.CheckBox cbUseCustomScreenshotsPath;
        private System.Windows.Forms.Label lblGeneralSeparator2;
        private System.Windows.Forms.TabPage tpPaths;
        private System.Windows.Forms.Button btnBrowseCustomScreenshotsPath;
        private System.Windows.Forms.TextBox txtCustomScreenshotsPath;
        private System.Windows.Forms.GroupBox gbClipboardUpload;
        private System.Windows.Forms.Label lblProxyHost;
        private System.Windows.Forms.TextBox txtProxyHost;
        private System.Windows.Forms.NumericUpDown nudProxyPort;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.Label lblProxyPassword;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.Label lblProxyUsername;
        private System.Windows.Forms.TextBox txtProxyUsername;
        private System.Windows.Forms.ComboBox cboProxyType;
        private System.Windows.Forms.Label lblProxyType;
        private System.Windows.Forms.CheckBox cbCaptureSaveImageWithDialog;
        private System.Windows.Forms.CheckBox cbTrayBalloonTipAfterUpload;
        private System.Windows.Forms.Button btnOpenCapturingShapesWiki;
        private System.Windows.Forms.TabPage tpActions;
        private HelpersLib.MyListView lvActions;
        private System.Windows.Forms.ColumnHeader chActionsName;
        private System.Windows.Forms.ColumnHeader chActionsPath;
        private System.Windows.Forms.ColumnHeader chActionsArgs;
        private System.Windows.Forms.CheckBox cbCapturePerformActions;
        private System.Windows.Forms.Button btnActionsEdit;
        private System.Windows.Forms.Button btnActionsRemove;
        private System.Windows.Forms.Button btnActionsAdd;
    }
}