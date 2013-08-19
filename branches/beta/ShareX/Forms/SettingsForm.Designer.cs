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
            this.cbPlaySoundAfterUpload = new System.Windows.Forms.CheckBox();
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.btnDefaultHotkeySettings = new System.Windows.Forms.Button();
            this.cbShellContextMenu = new System.Windows.Forms.CheckBox();
            this.cbShowAfterCaptureTasksForm = new System.Windows.Forms.CheckBox();
            this.cbTrayBalloonTipAfterUpload = new System.Windows.Forms.CheckBox();
            this.cbHistorySave = new System.Windows.Forms.CheckBox();
            this.cbPlaySoundAfterCapture = new System.Windows.Forms.CheckBox();
            this.cbCheckUpdates = new System.Windows.Forms.CheckBox();
            this.lblGeneralSeparator = new System.Windows.Forms.Label();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.cbShowTray = new System.Windows.Forms.CheckBox();
            this.cbSendToMenu = new System.Windows.Forms.CheckBox();
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
            this.hmHotkeys = new ShareX.HotkeyManagerControl();
            this.tpProxy = new System.Windows.Forms.TabPage();
            this.lblProxyNote = new System.Windows.Forms.Label();
            this.cbProxyMethod = new System.Windows.Forms.ComboBox();
            this.lblProxyMethod = new System.Windows.Forms.Label();
            this.cbProxyType = new System.Windows.Forms.ComboBox();
            this.lblProxyType = new System.Windows.Forms.Label();
            this.lblProxyHost = new System.Windows.Forms.Label();
            this.txtProxyHost = new System.Windows.Forms.TextBox();
            this.nudProxyPort = new System.Windows.Forms.NumericUpDown();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.lblProxyPassword = new System.Windows.Forms.Label();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.lblProxyUsername = new System.Windows.Forms.Label();
            this.txtProxyUsername = new System.Windows.Forms.TextBox();
            this.tpDebug = new System.Windows.Forms.TabPage();
            this.txtDebugLog = new System.Windows.Forms.TextBox();
            this.tpUpload = new System.Windows.Forms.TabPage();
            this.cbIfUploadFailRetryOnce = new System.Windows.Forms.CheckBox();
            this.lblUploadLimit = new System.Windows.Forms.Label();
            this.cbBufferSize = new System.Windows.Forms.ComboBox();
            this.lblUploadLimitHint = new System.Windows.Forms.Label();
            this.lblBufferSize = new System.Windows.Forms.Label();
            this.nudUploadLimit = new System.Windows.Forms.NumericUpDown();
            this.tpWatchFolder = new System.Windows.Forms.TabPage();
            this.cbWatchFolderEnabled = new System.Windows.Forms.CheckBox();
            this.lvWatchFolderList = new System.Windows.Forms.ListView();
            this.btnWatchFolderRemove = new System.Windows.Forms.Button();
            this.btnWatchFolderAdd = new System.Windows.Forms.Button();
            this.tcSettings.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpPaths.SuspendLayout();
            this.tpHotkeys.SuspendLayout();
            this.tpProxy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).BeginInit();
            this.tpDebug.SuspendLayout();
            this.tpUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUploadLimit)).BeginInit();
            this.tpWatchFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPlaySoundAfterUpload
            // 
            this.cbPlaySoundAfterUpload.AutoSize = true;
            this.cbPlaySoundAfterUpload.Location = new System.Drawing.Point(16, 208);
            this.cbPlaySoundAfterUpload.Name = "cbPlaySoundAfterUpload";
            this.cbPlaySoundAfterUpload.Size = new System.Drawing.Size(187, 17);
            this.cbPlaySoundAfterUpload.TabIndex = 8;
            this.cbPlaySoundAfterUpload.Text = "Play sound after task is completed";
            this.cbPlaySoundAfterUpload.UseVisualStyleBackColor = true;
            this.cbPlaySoundAfterUpload.CheckedChanged += new System.EventHandler(this.cbPlaySoundAfterUpload_CheckedChanged);
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpGeneral);
            this.tcSettings.Controls.Add(this.tpPaths);
            this.tcSettings.Controls.Add(this.tpHotkeys);
            this.tcSettings.Controls.Add(this.tpProxy);
            this.tcSettings.Controls.Add(this.tpDebug);
            this.tcSettings.Controls.Add(this.tpUpload);
            this.tcSettings.Controls.Add(this.tpWatchFolder);
            this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettings.Location = new System.Drawing.Point(3, 3);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(530, 507);
            this.tcSettings.TabIndex = 0;
            this.tcSettings.SelectedIndexChanged += new System.EventHandler(this.tcSettings_SelectedIndexChanged);
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.btnDefaultHotkeySettings);
            this.tpGeneral.Controls.Add(this.cbShellContextMenu);
            this.tpGeneral.Controls.Add(this.cbShowAfterCaptureTasksForm);
            this.tpGeneral.Controls.Add(this.cbTrayBalloonTipAfterUpload);
            this.tpGeneral.Controls.Add(this.cbHistorySave);
            this.tpGeneral.Controls.Add(this.cbPlaySoundAfterCapture);
            this.tpGeneral.Controls.Add(this.cbCheckUpdates);
            this.tpGeneral.Controls.Add(this.lblGeneralSeparator);
            this.tpGeneral.Controls.Add(this.cbStartWithWindows);
            this.tpGeneral.Controls.Add(this.cbShowTray);
            this.tpGeneral.Controls.Add(this.cbSendToMenu);
            this.tpGeneral.Controls.Add(this.cbPlaySoundAfterUpload);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(522, 481);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // btnDefaultHotkeySettings
            // 
            this.btnDefaultHotkeySettings.Location = new System.Drawing.Point(16, 280);
            this.btnDefaultHotkeySettings.Name = "btnDefaultHotkeySettings";
            this.btnDefaultHotkeySettings.Size = new System.Drawing.Size(107, 23);
            this.btnDefaultHotkeySettings.TabIndex = 2;
            this.btnDefaultHotkeySettings.Text = "Default Settings...";
            this.btnDefaultHotkeySettings.UseVisualStyleBackColor = true;
            this.btnDefaultHotkeySettings.Click += new System.EventHandler(this.btnDefaultHotkeySettings_Click);
            // 
            // cbShellContextMenu
            // 
            this.cbShellContextMenu.AutoSize = true;
            this.cbShellContextMenu.Location = new System.Drawing.Point(16, 88);
            this.cbShellContextMenu.Name = "cbShellContextMenu";
            this.cbShellContextMenu.Size = new System.Drawing.Size(301, 17);
            this.cbShellContextMenu.TabIndex = 3;
            this.cbShellContextMenu.Text = "Show \"Upload using ShareX\" button in shell context menu";
            this.cbShellContextMenu.UseVisualStyleBackColor = true;
            this.cbShellContextMenu.CheckedChanged += new System.EventHandler(this.cbShellContextMenu_CheckedChanged);
            // 
            // cbShowAfterCaptureTasksForm
            // 
            this.cbShowAfterCaptureTasksForm.AutoSize = true;
            this.cbShowAfterCaptureTasksForm.Location = new System.Drawing.Point(16, 160);
            this.cbShowAfterCaptureTasksForm.Name = "cbShowAfterCaptureTasksForm";
            this.cbShowAfterCaptureTasksForm.Size = new System.Drawing.Size(295, 17);
            this.cbShowAfterCaptureTasksForm.TabIndex = 6;
            this.cbShowAfterCaptureTasksForm.Text = "Show \"Post capture tasks\" window after capture is made";
            this.cbShowAfterCaptureTasksForm.UseVisualStyleBackColor = true;
            this.cbShowAfterCaptureTasksForm.CheckedChanged += new System.EventHandler(this.cbShowAfterCaptureTasksForm_CheckedChanged);
            // 
            // cbTrayBalloonTipAfterUpload
            // 
            this.cbTrayBalloonTipAfterUpload.AutoSize = true;
            this.cbTrayBalloonTipAfterUpload.Location = new System.Drawing.Point(16, 232);
            this.cbTrayBalloonTipAfterUpload.Name = "cbTrayBalloonTipAfterUpload";
            this.cbTrayBalloonTipAfterUpload.Size = new System.Drawing.Size(233, 17);
            this.cbTrayBalloonTipAfterUpload.TabIndex = 9;
            this.cbTrayBalloonTipAfterUpload.Text = "Show tray balloon tip after task is completed";
            this.cbTrayBalloonTipAfterUpload.UseVisualStyleBackColor = true;
            this.cbTrayBalloonTipAfterUpload.CheckedChanged += new System.EventHandler(this.cbTrayBalloonTipAfterUpload_CheckedChanged);
            // 
            // cbHistorySave
            // 
            this.cbHistorySave.AutoSize = true;
            this.cbHistorySave.Location = new System.Drawing.Point(16, 256);
            this.cbHistorySave.Name = "cbHistorySave";
            this.cbHistorySave.Size = new System.Drawing.Size(139, 17);
            this.cbHistorySave.TabIndex = 10;
            this.cbHistorySave.Text = "Save task info to history";
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
            this.cbCheckUpdates.Location = new System.Drawing.Point(16, 112);
            this.cbCheckUpdates.Name = "cbCheckUpdates";
            this.cbCheckUpdates.Size = new System.Drawing.Size(209, 17);
            this.cbCheckUpdates.TabIndex = 4;
            this.cbCheckUpdates.Text = "Automatically check updates at startup";
            this.cbCheckUpdates.UseVisualStyleBackColor = true;
            this.cbCheckUpdates.CheckedChanged += new System.EventHandler(this.cbCheckUpdates_CheckedChanged);
            // 
            // lblGeneralSeparator
            // 
            this.lblGeneralSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGeneralSeparator.Location = new System.Drawing.Point(16, 144);
            this.lblGeneralSeparator.Name = "lblGeneralSeparator";
            this.lblGeneralSeparator.Size = new System.Drawing.Size(475, 2);
            this.lblGeneralSeparator.TabIndex = 5;
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
            // cbSendToMenu
            // 
            this.cbSendToMenu.AutoSize = true;
            this.cbSendToMenu.Location = new System.Drawing.Point(16, 64);
            this.cbSendToMenu.Name = "cbSendToMenu";
            this.cbSendToMenu.Size = new System.Drawing.Size(181, 17);
            this.cbSendToMenu.TabIndex = 2;
            this.cbSendToMenu.Text = "Show ShareX in \"Send to\" menu";
            this.cbSendToMenu.UseVisualStyleBackColor = true;
            this.cbSendToMenu.CheckedChanged += new System.EventHandler(this.cbSendToMenu_CheckedChanged);
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
            this.tpPaths.Size = new System.Drawing.Size(522, 481);
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
            this.tpHotkeys.Size = new System.Drawing.Size(522, 481);
            this.tpHotkeys.TabIndex = 2;
            this.tpHotkeys.Text = "Hotkeys";
            this.tpHotkeys.UseVisualStyleBackColor = true;
            // 
            // hmHotkeys
            // 
            this.hmHotkeys.AutoScroll = true;
            this.hmHotkeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmHotkeys.Location = new System.Drawing.Point(0, 0);
            this.hmHotkeys.Name = "hmHotkeys";
            this.hmHotkeys.Size = new System.Drawing.Size(522, 481);
            this.hmHotkeys.TabIndex = 0;
            // 
            // tpProxy
            // 
            this.tpProxy.Controls.Add(this.lblProxyNote);
            this.tpProxy.Controls.Add(this.cbProxyMethod);
            this.tpProxy.Controls.Add(this.lblProxyMethod);
            this.tpProxy.Controls.Add(this.cbProxyType);
            this.tpProxy.Controls.Add(this.lblProxyType);
            this.tpProxy.Controls.Add(this.lblProxyHost);
            this.tpProxy.Controls.Add(this.txtProxyHost);
            this.tpProxy.Controls.Add(this.nudProxyPort);
            this.tpProxy.Controls.Add(this.lblProxyPort);
            this.tpProxy.Controls.Add(this.lblProxyPassword);
            this.tpProxy.Controls.Add(this.txtProxyPassword);
            this.tpProxy.Controls.Add(this.lblProxyUsername);
            this.tpProxy.Controls.Add(this.txtProxyUsername);
            this.tpProxy.Location = new System.Drawing.Point(4, 22);
            this.tpProxy.Name = "tpProxy";
            this.tpProxy.Padding = new System.Windows.Forms.Padding(5);
            this.tpProxy.Size = new System.Drawing.Size(522, 481);
            this.tpProxy.TabIndex = 7;
            this.tpProxy.Text = "Proxy";
            this.tpProxy.UseVisualStyleBackColor = true;
            // 
            // lblProxyNote
            // 
            this.lblProxyNote.AutoSize = true;
            this.lblProxyNote.Location = new System.Drawing.Point(256, 144);
            this.lblProxyNote.Name = "lblProxyNote";
            this.lblProxyNote.Size = new System.Drawing.Size(196, 13);
            this.lblProxyNote.TabIndex = 12;
            this.lblProxyNote.Text = "SOCKS proxy is only supported by FTP. ";
            // 
            // cbProxyMethod
            // 
            this.cbProxyMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProxyMethod.FormattingEnabled = true;
            this.cbProxyMethod.Location = new System.Drawing.Point(120, 12);
            this.cbProxyMethod.Name = "cbProxyMethod";
            this.cbProxyMethod.Size = new System.Drawing.Size(128, 21);
            this.cbProxyMethod.TabIndex = 1;
            this.cbProxyMethod.SelectedIndexChanged += new System.EventHandler(this.cbProxyMethod_SelectedIndexChanged);
            // 
            // lblProxyMethod
            // 
            this.lblProxyMethod.AutoSize = true;
            this.lblProxyMethod.Location = new System.Drawing.Point(16, 16);
            this.lblProxyMethod.Name = "lblProxyMethod";
            this.lblProxyMethod.Size = new System.Drawing.Size(100, 13);
            this.lblProxyMethod.TabIndex = 0;
            this.lblProxyMethod.Text = "Proxy configuration:";
            // 
            // cbProxyType
            // 
            this.cbProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProxyType.FormattingEnabled = true;
            this.cbProxyType.Location = new System.Drawing.Point(88, 140);
            this.cbProxyType.Name = "cbProxyType";
            this.cbProxyType.Size = new System.Drawing.Size(160, 21);
            this.cbProxyType.TabIndex = 11;
            this.cbProxyType.SelectedIndexChanged += new System.EventHandler(this.cboProxyType_SelectedIndexChanged);
            // 
            // lblProxyType
            // 
            this.lblProxyType.AutoSize = true;
            this.lblProxyType.Location = new System.Drawing.Point(16, 144);
            this.lblProxyType.Name = "lblProxyType";
            this.lblProxyType.Size = new System.Drawing.Size(34, 13);
            this.lblProxyType.TabIndex = 10;
            this.lblProxyType.Text = "Type:";
            // 
            // lblProxyHost
            // 
            this.lblProxyHost.AutoSize = true;
            this.lblProxyHost.Location = new System.Drawing.Point(16, 112);
            this.lblProxyHost.Name = "lblProxyHost";
            this.lblProxyHost.Size = new System.Drawing.Size(32, 13);
            this.lblProxyHost.TabIndex = 6;
            this.lblProxyHost.Text = "Host:";
            // 
            // txtProxyHost
            // 
            this.txtProxyHost.Location = new System.Drawing.Point(88, 108);
            this.txtProxyHost.Name = "txtProxyHost";
            this.txtProxyHost.Size = new System.Drawing.Size(232, 20);
            this.txtProxyHost.TabIndex = 7;
            this.txtProxyHost.TextChanged += new System.EventHandler(this.txtProxyHost_TextChanged);
            // 
            // nudProxyPort
            // 
            this.nudProxyPort.Location = new System.Drawing.Point(360, 108);
            this.nudProxyPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudProxyPort.Name = "nudProxyPort";
            this.nudProxyPort.Size = new System.Drawing.Size(64, 20);
            this.nudProxyPort.TabIndex = 9;
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
            this.lblProxyPort.Location = new System.Drawing.Point(328, 112);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProxyPort.Size = new System.Drawing.Size(26, 13);
            this.lblProxyPort.TabIndex = 8;
            this.lblProxyPort.Text = "Port";
            // 
            // lblProxyPassword
            // 
            this.lblProxyPassword.AutoSize = true;
            this.lblProxyPassword.Location = new System.Drawing.Point(16, 80);
            this.lblProxyPassword.Name = "lblProxyPassword";
            this.lblProxyPassword.Size = new System.Drawing.Size(56, 13);
            this.lblProxyPassword.TabIndex = 4;
            this.lblProxyPassword.Text = "Password:";
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Location = new System.Drawing.Point(88, 76);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.PasswordChar = '●';
            this.txtProxyPassword.Size = new System.Drawing.Size(232, 20);
            this.txtProxyPassword.TabIndex = 5;
            this.txtProxyPassword.TextChanged += new System.EventHandler(this.txtProxyPassword_TextChanged);
            // 
            // lblProxyUsername
            // 
            this.lblProxyUsername.AutoSize = true;
            this.lblProxyUsername.Location = new System.Drawing.Point(16, 48);
            this.lblProxyUsername.Name = "lblProxyUsername";
            this.lblProxyUsername.Size = new System.Drawing.Size(58, 13);
            this.lblProxyUsername.TabIndex = 2;
            this.lblProxyUsername.Text = "Username:";
            // 
            // txtProxyUsername
            // 
            this.txtProxyUsername.Location = new System.Drawing.Point(88, 44);
            this.txtProxyUsername.Name = "txtProxyUsername";
            this.txtProxyUsername.Size = new System.Drawing.Size(232, 20);
            this.txtProxyUsername.TabIndex = 3;
            this.txtProxyUsername.TextChanged += new System.EventHandler(this.txtProxyUsername_TextChanged);
            // 
            // tpDebug
            // 
            this.tpDebug.Controls.Add(this.txtDebugLog);
            this.tpDebug.Location = new System.Drawing.Point(4, 22);
            this.tpDebug.Name = "tpDebug";
            this.tpDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tpDebug.Size = new System.Drawing.Size(522, 481);
            this.tpDebug.TabIndex = 8;
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
            this.txtDebugLog.Size = new System.Drawing.Size(516, 475);
            this.txtDebugLog.TabIndex = 0;
            this.txtDebugLog.WordWrap = false;
            // 
            // tpUpload
            // 
            this.tpUpload.Controls.Add(this.lblUploadLimit);
            this.tpUpload.Controls.Add(this.cbIfUploadFailRetryOnce);
            this.tpUpload.Controls.Add(this.nudUploadLimit);
            this.tpUpload.Controls.Add(this.lblUploadLimitHint);
            this.tpUpload.Controls.Add(this.lblBufferSize);
            this.tpUpload.Controls.Add(this.cbBufferSize);
            this.tpUpload.Location = new System.Drawing.Point(4, 22);
            this.tpUpload.Name = "tpUpload";
            this.tpUpload.Padding = new System.Windows.Forms.Padding(3);
            this.tpUpload.Size = new System.Drawing.Size(522, 481);
            this.tpUpload.TabIndex = 9;
            this.tpUpload.Text = "Upload";
            this.tpUpload.UseVisualStyleBackColor = true;
            // 
            // cbIfUploadFailRetryOnce
            // 
            this.cbIfUploadFailRetryOnce.AutoSize = true;
            this.cbIfUploadFailRetryOnce.Location = new System.Drawing.Point(16, 80);
            this.cbIfUploadFailRetryOnce.Name = "cbIfUploadFailRetryOnce";
            this.cbIfUploadFailRetryOnce.Size = new System.Drawing.Size(192, 17);
            this.cbIfUploadFailRetryOnce.TabIndex = 11;
            this.cbIfUploadFailRetryOnce.Text = "If upload fail then retry upload once";
            this.cbIfUploadFailRetryOnce.UseVisualStyleBackColor = true;
            // 
            // lblUploadLimit
            // 
            this.lblUploadLimit.AutoSize = true;
            this.lblUploadLimit.Location = new System.Drawing.Point(16, 16);
            this.lblUploadLimit.Name = "lblUploadLimit";
            this.lblUploadLimit.Size = new System.Drawing.Size(128, 13);
            this.lblUploadLimit.TabIndex = 6;
            this.lblUploadLimit.Text = "Simultaneous upload limit:";
            // 
            // cbBufferSize
            // 
            this.cbBufferSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBufferSize.FormattingEnabled = true;
            this.cbBufferSize.Location = new System.Drawing.Point(76, 44);
            this.cbBufferSize.Name = "cbBufferSize";
            this.cbBufferSize.Size = new System.Drawing.Size(76, 21);
            this.cbBufferSize.TabIndex = 10;
            // 
            // lblUploadLimitHint
            // 
            this.lblUploadLimitHint.AutoSize = true;
            this.lblUploadLimitHint.Location = new System.Drawing.Point(212, 16);
            this.lblUploadLimitHint.Name = "lblUploadLimitHint";
            this.lblUploadLimitHint.Size = new System.Drawing.Size(90, 13);
            this.lblUploadLimitHint.TabIndex = 8;
            this.lblUploadLimitHint.Text = "0 - 25 (0 disables)";
            // 
            // lblBufferSize
            // 
            this.lblBufferSize.AutoSize = true;
            this.lblBufferSize.Location = new System.Drawing.Point(16, 48);
            this.lblBufferSize.Name = "lblBufferSize";
            this.lblBufferSize.Size = new System.Drawing.Size(59, 13);
            this.lblBufferSize.TabIndex = 9;
            this.lblBufferSize.Text = "Buffer size:";
            // 
            // nudUploadLimit
            // 
            this.nudUploadLimit.Location = new System.Drawing.Point(148, 12);
            this.nudUploadLimit.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudUploadLimit.Name = "nudUploadLimit";
            this.nudUploadLimit.Size = new System.Drawing.Size(56, 20);
            this.nudUploadLimit.TabIndex = 7;
            this.nudUploadLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudUploadLimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // tpWatchFolder
            // 
            this.tpWatchFolder.Controls.Add(this.cbWatchFolderEnabled);
            this.tpWatchFolder.Controls.Add(this.lvWatchFolderList);
            this.tpWatchFolder.Controls.Add(this.btnWatchFolderRemove);
            this.tpWatchFolder.Controls.Add(this.btnWatchFolderAdd);
            this.tpWatchFolder.Location = new System.Drawing.Point(4, 22);
            this.tpWatchFolder.Name = "tpWatchFolder";
            this.tpWatchFolder.Padding = new System.Windows.Forms.Padding(3);
            this.tpWatchFolder.Size = new System.Drawing.Size(522, 481);
            this.tpWatchFolder.TabIndex = 10;
            this.tpWatchFolder.Text = "Watch folders";
            this.tpWatchFolder.UseVisualStyleBackColor = true;
            // 
            // cbWatchFolderEnabled
            // 
            this.cbWatchFolderEnabled.AutoSize = true;
            this.cbWatchFolderEnabled.Location = new System.Drawing.Point(16, 16);
            this.cbWatchFolderEnabled.Name = "cbWatchFolderEnabled";
            this.cbWatchFolderEnabled.Size = new System.Drawing.Size(266, 17);
            this.cbWatchFolderEnabled.TabIndex = 4;
            this.cbWatchFolderEnabled.Text = "Watch folders and if new file created then upload it";
            this.cbWatchFolderEnabled.UseVisualStyleBackColor = true;
            this.cbWatchFolderEnabled.CheckedChanged += new System.EventHandler(this.cbWatchFolderEnabled_CheckedChanged);
            // 
            // lvWatchFolderList
            // 
            this.lvWatchFolderList.FullRowSelect = true;
            this.lvWatchFolderList.Location = new System.Drawing.Point(16, 72);
            this.lvWatchFolderList.Name = "lvWatchFolderList";
            this.lvWatchFolderList.Size = new System.Drawing.Size(472, 208);
            this.lvWatchFolderList.TabIndex = 7;
            this.lvWatchFolderList.UseCompatibleStateImageBehavior = false;
            this.lvWatchFolderList.View = System.Windows.Forms.View.Details;
            // 
            // btnWatchFolderRemove
            // 
            this.btnWatchFolderRemove.Location = new System.Drawing.Point(96, 40);
            this.btnWatchFolderRemove.Name = "btnWatchFolderRemove";
            this.btnWatchFolderRemove.Size = new System.Drawing.Size(75, 23);
            this.btnWatchFolderRemove.TabIndex = 6;
            this.btnWatchFolderRemove.Text = "Remove";
            this.btnWatchFolderRemove.UseVisualStyleBackColor = true;
            this.btnWatchFolderRemove.Click += new System.EventHandler(this.btnWatchFolderRemove_Click);
            // 
            // btnWatchFolderAdd
            // 
            this.btnWatchFolderAdd.Location = new System.Drawing.Point(16, 40);
            this.btnWatchFolderAdd.Name = "btnWatchFolderAdd";
            this.btnWatchFolderAdd.Size = new System.Drawing.Size(75, 23);
            this.btnWatchFolderAdd.TabIndex = 5;
            this.btnWatchFolderAdd.Text = "Add";
            this.btnWatchFolderAdd.UseVisualStyleBackColor = true;
            this.btnWatchFolderAdd.Click += new System.EventHandler(this.btnWatchFolderAdd_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 513);
            this.Controls.Add(this.tcSettings);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(552, 552);
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
            this.tpProxy.ResumeLayout(false);
            this.tpProxy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).EndInit();
            this.tpDebug.ResumeLayout(false);
            this.tpDebug.PerformLayout();
            this.tpUpload.ResumeLayout(false);
            this.tpUpload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUploadLimit)).EndInit();
            this.tpWatchFolder.ResumeLayout(false);
            this.tpWatchFolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.CheckBox cbPlaySoundAfterUpload;
        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpProxy;
        private System.Windows.Forms.CheckBox cbSendToMenu;
        private System.Windows.Forms.TextBox txtCustomHistoryPath;
        private System.Windows.Forms.CheckBox cbUseCustomHistoryPath;
        private System.Windows.Forms.CheckBox cbHistorySave;
        private System.Windows.Forms.Button btnBrowseCustomHistoryPath;
        private System.Windows.Forms.TabPage tpDebug;
        private System.Windows.Forms.TextBox txtDebugLog;
        private System.Windows.Forms.Button btnOpenPersonalFolder;
        private System.Windows.Forms.Button btnBrowseCustomUploadersConfigPath;
        private System.Windows.Forms.TextBox txtCustomUploadersConfigPath;
        private System.Windows.Forms.CheckBox cbUseCustomUploadersConfigPath;
        private System.Windows.Forms.Button btnLoadUploadersConfig;
        private System.Windows.Forms.CheckBox cbShowTray;
        private System.Windows.Forms.TabPage tpHotkeys;
        private HotkeyManagerControl hmHotkeys;
        private System.Windows.Forms.Label lblGeneralSeparator;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.Label lblSaveImageSubFolderPatternPreview;
        private System.Windows.Forms.TextBox txtSaveImageSubFolderPattern;
        private System.Windows.Forms.Label lblSaveImageSubFolderPattern;
        private System.Windows.Forms.CheckBox cbCheckUpdates;
        private System.Windows.Forms.CheckBox cbPlaySoundAfterCapture;
        private System.Windows.Forms.CheckBox cbUseCustomScreenshotsPath;
        private System.Windows.Forms.TabPage tpPaths;
        private System.Windows.Forms.Button btnBrowseCustomScreenshotsPath;
        private System.Windows.Forms.TextBox txtCustomScreenshotsPath;
        private System.Windows.Forms.Label lblProxyHost;
        private System.Windows.Forms.TextBox txtProxyHost;
        private System.Windows.Forms.NumericUpDown nudProxyPort;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.Label lblProxyPassword;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.Label lblProxyUsername;
        private System.Windows.Forms.TextBox txtProxyUsername;
        private System.Windows.Forms.ComboBox cbProxyType;
        private System.Windows.Forms.Label lblProxyType;
        private System.Windows.Forms.CheckBox cbTrayBalloonTipAfterUpload;
        private System.Windows.Forms.CheckBox cbShowAfterCaptureTasksForm;
        private System.Windows.Forms.CheckBox cbShellContextMenu;
        private System.Windows.Forms.ComboBox cbProxyMethod;
        private System.Windows.Forms.Label lblProxyMethod;
        private System.Windows.Forms.Label lblProxyNote;
        private System.Windows.Forms.TabPage tpUpload;
        private System.Windows.Forms.CheckBox cbIfUploadFailRetryOnce;
        private System.Windows.Forms.Label lblUploadLimit;
        private System.Windows.Forms.ComboBox cbBufferSize;
        private System.Windows.Forms.Label lblUploadLimitHint;
        private System.Windows.Forms.Label lblBufferSize;
        private System.Windows.Forms.NumericUpDown nudUploadLimit;
        private System.Windows.Forms.Button btnDefaultHotkeySettings;
        private System.Windows.Forms.TabPage tpWatchFolder;
        private System.Windows.Forms.CheckBox cbWatchFolderEnabled;
        private System.Windows.Forms.ListView lvWatchFolderList;
        private System.Windows.Forms.Button btnWatchFolderRemove;
        private System.Windows.Forms.Button btnWatchFolderAdd;
    }
}