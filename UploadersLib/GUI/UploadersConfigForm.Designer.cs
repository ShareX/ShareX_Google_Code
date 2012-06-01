namespace UploadersLib
{
    partial class UploadersConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadersConfigForm));
            this.tcUploaders = new System.Windows.Forms.TabControl();
            this.tpImageUploaders = new System.Windows.Forms.TabPage();
            this.tcImageUploaders = new System.Windows.Forms.TabControl();
            this.tpImageShack = new System.Windows.Forms.TabPage();
            this.atcImageShackAccountType = new UploadersLib.GUI.AccountTypeControl();
            this.btnImageShackOpenPublicProfile = new System.Windows.Forms.Button();
            this.cbImageShackIsPublic = new System.Windows.Forms.CheckBox();
            this.btnImageShackOpenMyImages = new System.Windows.Forms.Button();
            this.lblImageShackUsername = new System.Windows.Forms.Label();
            this.btnImageShackOpenRegistrationCode = new System.Windows.Forms.Button();
            this.txtImageShackUsername = new System.Windows.Forms.TextBox();
            this.txtImageShackRegistrationCode = new System.Windows.Forms.TextBox();
            this.lblImageShackRegistrationCode = new System.Windows.Forms.Label();
            this.tpTinyPic = new System.Windows.Forms.TabPage();
            this.atcTinyPicAccountType = new UploadersLib.GUI.AccountTypeControl();
            this.btnTinyPicLogin = new System.Windows.Forms.Button();
            this.txtTinyPicPassword = new System.Windows.Forms.TextBox();
            this.lblTinyPicPassword = new System.Windows.Forms.Label();
            this.txtTinyPicUsername = new System.Windows.Forms.TextBox();
            this.lblTinyPicUsername = new System.Windows.Forms.Label();
            this.btnTinyPicOpenMyImages = new System.Windows.Forms.Button();
            this.cbTinyPicRememberUsernamePassword = new System.Windows.Forms.CheckBox();
            this.lblTinyPicRegistrationCode = new System.Windows.Forms.Label();
            this.txtTinyPicRegistrationCode = new System.Windows.Forms.TextBox();
            this.tpImgur = new System.Windows.Forms.TabPage();
            this.cbImgurThumbnailType = new System.Windows.Forms.ComboBox();
            this.lblImgurThumbnailType = new System.Windows.Forms.Label();
            this.gbImgurUserAccount = new System.Windows.Forms.GroupBox();
            this.btnImgurOpenAuthorizePage = new System.Windows.Forms.Button();
            this.lblImgurVerificationCode = new System.Windows.Forms.Label();
            this.btnImgurEnterVerificationCode = new System.Windows.Forms.Button();
            this.txtImgurVerificationCode = new System.Windows.Forms.TextBox();
            this.lblImgurAccountStatus = new System.Windows.Forms.Label();
            this.atcImgurAccountType = new UploadersLib.GUI.AccountTypeControl();
            this.tpFlickr = new System.Windows.Forms.TabPage();
            this.btnFlickrOpenImages = new System.Windows.Forms.Button();
            this.pgFlickrAuthInfo = new System.Windows.Forms.PropertyGrid();
            this.pgFlickrSettings = new System.Windows.Forms.PropertyGrid();
            this.btnFlickrCheckToken = new System.Windows.Forms.Button();
            this.btnFlickrCompleteAuth = new System.Windows.Forms.Button();
            this.btnFlickrOpenAuthorize = new System.Windows.Forms.Button();
            this.tpPhotobucket = new System.Windows.Forms.TabPage();
            this.gbPhotobucketAlbumPath = new System.Windows.Forms.GroupBox();
            this.btnPhotobucketAddAlbum = new System.Windows.Forms.Button();
            this.btnPhotobucketRemoveAlbum = new System.Windows.Forms.Button();
            this.cboPhotobucketAlbumPaths = new System.Windows.Forms.ComboBox();
            this.gbPhotobucketAlbums = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPhotobucketParentAlbumPath = new System.Windows.Forms.Label();
            this.txtPhotobucketNewAlbumName = new System.Windows.Forms.TextBox();
            this.txtPhotobucketParentAlbumPath = new System.Windows.Forms.TextBox();
            this.btnPhotobucketCreateAlbum = new System.Windows.Forms.Button();
            this.gbPhotobucketUserAccount = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPhotobucketAuthOpen = new System.Windows.Forms.Button();
            this.txtPhotobucketDefaultAlbumName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPhotobucketAuthComplete = new System.Windows.Forms.Button();
            this.txtPhotobucketVerificationCode = new System.Windows.Forms.TextBox();
            this.lblPhotobucketAccountStatus = new System.Windows.Forms.Label();
            this.tpTwitPic = new System.Windows.Forms.TabPage();
            this.lblTwitPicTip = new System.Windows.Forms.Label();
            this.chkTwitPicShowFull = new System.Windows.Forms.CheckBox();
            this.cboTwitPicThumbnailMode = new System.Windows.Forms.ComboBox();
            this.lblTwitPicThumbnailMode = new System.Windows.Forms.Label();
            this.tpTwitSnaps = new System.Windows.Forms.TabPage();
            this.lblTwitSnapsTip = new System.Windows.Forms.Label();
            this.tpYFrog = new System.Windows.Forms.TabPage();
            this.lblYFrogPassword = new System.Windows.Forms.Label();
            this.lblYFrogUsername = new System.Windows.Forms.Label();
            this.txtYFrogPassword = new System.Windows.Forms.TextBox();
            this.txtYFrogUsername = new System.Windows.Forms.TextBox();
            this.tpTextUploaders = new System.Windows.Forms.TabPage();
            this.tcTextUploaders = new System.Windows.Forms.TabControl();
            this.tpPastebin = new System.Windows.Forms.TabPage();
            this.btnPastebinLogin = new System.Windows.Forms.Button();
            this.pgPastebinSettings = new System.Windows.Forms.PropertyGrid();
            this.tpFileUploaders = new System.Windows.Forms.TabPage();
            this.tcFileUploaders = new System.Windows.Forms.TabControl();
            this.tpDropbox = new System.Windows.Forms.TabPage();
            this.cbDropboxAutoCreateShareableLink = new System.Windows.Forms.CheckBox();
            this.btnDropboxShowFiles = new System.Windows.Forms.Button();
            this.btnDropboxCompleteAuth = new System.Windows.Forms.Button();
            this.pbDropboxLogo = new System.Windows.Forms.PictureBox();
            this.btnDropboxRegister = new System.Windows.Forms.Button();
            this.lblDropboxStatus = new System.Windows.Forms.Label();
            this.lblDropboxPathTip = new System.Windows.Forms.Label();
            this.lblDropboxPath = new System.Windows.Forms.Label();
            this.btnDropboxOpenAuthorize = new System.Windows.Forms.Button();
            this.txtDropboxPath = new System.Windows.Forms.TextBox();
            this.tpBox = new System.Windows.Forms.TabPage();
            this.txtBoxFolderID = new System.Windows.Forms.TextBox();
            this.lblBoxFolderID = new System.Windows.Forms.Label();
            this.btnBoxRefreshFolders = new System.Windows.Forms.Button();
            this.tvBoxFolders = new System.Windows.Forms.TreeView();
            this.btnBoxCompleteAuth = new System.Windows.Forms.Button();
            this.btnBoxOpenAuthorize = new System.Windows.Forms.Button();
            this.tpMinus = new System.Windows.Forms.TabPage();
            this.gbMinusUserPass = new System.Windows.Forms.GroupBox();
            this.btnAuthRefresh = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMinusPassword = new System.Windows.Forms.TextBox();
            this.txtMinusUsername = new System.Windows.Forms.TextBox();
            this.btnMinusAuth = new System.Windows.Forms.Button();
            this.gbMinusUpload = new System.Windows.Forms.GroupBox();
            this.btnMinusReadFolderList = new System.Windows.Forms.Button();
            this.chkMinusPublic = new System.Windows.Forms.CheckBox();
            this.btnMinusFolderAdd = new System.Windows.Forms.Button();
            this.btnMinusFolderRemove = new System.Windows.Forms.Button();
            this.cboMinusFolders = new System.Windows.Forms.ComboBox();
            this.lblMinusAuthStatus = new System.Windows.Forms.Label();
            this.tpFTP = new System.Windows.Forms.TabPage();
            this.tlpFtp = new System.Windows.Forms.TableLayoutPanel();
            this.panelFtp = new System.Windows.Forms.Panel();
            this.btnFTPExport = new System.Windows.Forms.Button();
            this.btnFTPImport = new System.Windows.Forms.Button();
            this.btnFtpHelp = new System.Windows.Forms.Button();
            this.ucFTPAccounts = new UploadersLib.AccountsControl();
            this.gbFtpSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFtpFiles = new System.Windows.Forms.ComboBox();
            this.cboFtpText = new System.Windows.Forms.ComboBox();
            this.cboFtpImages = new System.Windows.Forms.ComboBox();
            this.chkFTPThumbnailCheckSize = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFTPThumbWidth = new System.Windows.Forms.TextBox();
            this.tpRapidShare = new System.Windows.Forms.TabPage();
            this.txtRapidShareFolderID = new System.Windows.Forms.TextBox();
            this.lblRapidShareFolderID = new System.Windows.Forms.Label();
            this.btnRapidShareRefreshFolders = new System.Windows.Forms.Button();
            this.tvRapidShareFolders = new System.Windows.Forms.TreeView();
            this.lblRapidSharePassword = new System.Windows.Forms.Label();
            this.lblRapidSharePremiumUsername = new System.Windows.Forms.Label();
            this.txtRapidSharePassword = new System.Windows.Forms.TextBox();
            this.txtRapidShareUsername = new System.Windows.Forms.TextBox();
            this.tpSendSpace = new System.Windows.Forms.TabPage();
            this.btnSendSpaceRegister = new System.Windows.Forms.Button();
            this.lblSendSpacePassword = new System.Windows.Forms.Label();
            this.lblSendSpaceUsername = new System.Windows.Forms.Label();
            this.txtSendSpacePassword = new System.Windows.Forms.TextBox();
            this.txtSendSpaceUserName = new System.Windows.Forms.TextBox();
            this.atcSendSpaceAccountType = new UploadersLib.GUI.AccountTypeControl();
            this.tpCustomUploaders = new System.Windows.Forms.TabPage();
            this.txtCustomUploaderLog = new System.Windows.Forms.RichTextBox();
            this.btnCustomUploaderTest = new System.Windows.Forms.Button();
            this.txtCustomUploaderFullImage = new System.Windows.Forms.TextBox();
            this.txtCustomUploaderThumbnail = new System.Windows.Forms.TextBox();
            this.lblCustomUploaderFullImage = new System.Windows.Forms.Label();
            this.lblCustomUploaderThumbnail = new System.Windows.Forms.Label();
            this.gbCustomUploaders = new System.Windows.Forms.GroupBox();
            this.lbCustomUploaderList = new System.Windows.Forms.ListBox();
            this.btnCustomUploaderClear = new System.Windows.Forms.Button();
            this.btnCustomUploaderExport = new System.Windows.Forms.Button();
            this.btnCustomUploaderRemove = new System.Windows.Forms.Button();
            this.btnCustomUploaderImport = new System.Windows.Forms.Button();
            this.btnCustomUploaderUpdate = new System.Windows.Forms.Button();
            this.txtCustomUploaderName = new System.Windows.Forms.TextBox();
            this.btnCustomUploaderAdd = new System.Windows.Forms.Button();
            this.gbCustomUploaderRegexp = new System.Windows.Forms.GroupBox();
            this.btnCustomUploaderRegexpEdit = new System.Windows.Forms.Button();
            this.txtCustomUploaderRegexp = new System.Windows.Forms.TextBox();
            this.lvCustomUploaderRegexps = new System.Windows.Forms.ListView();
            this.lvRegexpsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCustomUploaderRegexpRemove = new System.Windows.Forms.Button();
            this.btnCustomUploaderRegexpAdd = new System.Windows.Forms.Button();
            this.txtCustomUploaderFileForm = new System.Windows.Forms.TextBox();
            this.lblCustomUploaderFileForm = new System.Windows.Forms.Label();
            this.lblCustomUploaderUploadURL = new System.Windows.Forms.Label();
            this.txtCustomUploaderURL = new System.Windows.Forms.TextBox();
            this.gbCustomUploaderArguments = new System.Windows.Forms.GroupBox();
            this.btnCustomUploaderArgEdit = new System.Windows.Forms.Button();
            this.txtCustomUploaderArgValue = new System.Windows.Forms.TextBox();
            this.btnCustomUploaderArgRemove = new System.Windows.Forms.Button();
            this.lvCustomUploaderArguments = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCustomUploaderArgAdd = new System.Windows.Forms.Button();
            this.txtCustomUploaderArgName = new System.Windows.Forms.TextBox();
            this.tpURLShorteners = new System.Windows.Forms.TabPage();
            this.tcURLShorteners = new System.Windows.Forms.TabControl();
            this.tpGoogleURLShortener = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGoogleURLShortenerAuthComplete = new System.Windows.Forms.Button();
            this.btnGoogleURLShortenerAuthOpen = new System.Windows.Forms.Button();
            this.lblGooglAccountStatus = new System.Windows.Forms.Label();
            this.atcGoogleURLShortenerAccountType = new UploadersLib.GUI.AccountTypeControl();
            this.tpOtherServices = new System.Windows.Forms.TabPage();
            this.tcOtherServices = new System.Windows.Forms.TabControl();
            this.tpTwitter = new System.Windows.Forms.TabPage();
            this.btnTwitterLogin = new System.Windows.Forms.Button();
            this.ucTwitterAccounts = new UploadersLib.AccountsControl();
            this.tbOutputs = new System.Windows.Forms.TabPage();
            this.tcOutputs = new System.Windows.Forms.TabControl();
            this.tpEmail = new System.Windows.Forms.TabPage();
            this.chkEmailConfirm = new System.Windows.Forms.CheckBox();
            this.cbEmailRememberLastTo = new System.Windows.Forms.CheckBox();
            this.txtEmailDefaultBody = new System.Windows.Forms.TextBox();
            this.lblEmailDefaultBody = new System.Windows.Forms.Label();
            this.txtEmailDefaultSubject = new System.Windows.Forms.TextBox();
            this.lblEmailDefaultSubject = new System.Windows.Forms.Label();
            this.txtEmailPassword = new System.Windows.Forms.TextBox();
            this.lblEmailPassword = new System.Windows.Forms.Label();
            this.txtEmailFrom = new System.Windows.Forms.TextBox();
            this.lblEmailFrom = new System.Windows.Forms.Label();
            this.nudEmailSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.lblEmailSmtpPort = new System.Windows.Forms.Label();
            this.txtEmailSmtpServer = new System.Windows.Forms.TextBox();
            this.lblEmailSmtpServer = new System.Windows.Forms.Label();
            this.tpSharedFolders = new System.Windows.Forms.TabPage();
            this.tlpSharedFolders = new System.Windows.Forms.TableLayoutPanel();
            this.ucLocalhostAccounts = new UploadersLib.AccountsControl();
            this.gbSharedFolder = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboSharedFolderFiles = new System.Windows.Forms.ComboBox();
            this.cboSharedFolderText = new System.Windows.Forms.ComboBox();
            this.cboSharedFolderImages = new System.Windows.Forms.ComboBox();
            this.txtRapidSharePremiumUserName = new System.Windows.Forms.TextBox();
            this.actRapidShareAccountType = new UploadersLib.GUI.AccountTypeControl();
            this.tcUploaders.SuspendLayout();
            this.tpImageUploaders.SuspendLayout();
            this.tcImageUploaders.SuspendLayout();
            this.tpImageShack.SuspendLayout();
            this.tpTinyPic.SuspendLayout();
            this.tpImgur.SuspendLayout();
            this.gbImgurUserAccount.SuspendLayout();
            this.tpFlickr.SuspendLayout();
            this.tpPhotobucket.SuspendLayout();
            this.gbPhotobucketAlbumPath.SuspendLayout();
            this.gbPhotobucketAlbums.SuspendLayout();
            this.gbPhotobucketUserAccount.SuspendLayout();
            this.tpTwitPic.SuspendLayout();
            this.tpTwitSnaps.SuspendLayout();
            this.tpYFrog.SuspendLayout();
            this.tpTextUploaders.SuspendLayout();
            this.tcTextUploaders.SuspendLayout();
            this.tpPastebin.SuspendLayout();
            this.tpFileUploaders.SuspendLayout();
            this.tcFileUploaders.SuspendLayout();
            this.tpDropbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDropboxLogo)).BeginInit();
            this.tpBox.SuspendLayout();
            this.tpMinus.SuspendLayout();
            this.gbMinusUserPass.SuspendLayout();
            this.gbMinusUpload.SuspendLayout();
            this.tpFTP.SuspendLayout();
            this.tlpFtp.SuspendLayout();
            this.panelFtp.SuspendLayout();
            this.gbFtpSettings.SuspendLayout();
            this.tpRapidShare.SuspendLayout();
            this.tpSendSpace.SuspendLayout();
            this.tpCustomUploaders.SuspendLayout();
            this.gbCustomUploaders.SuspendLayout();
            this.gbCustomUploaderRegexp.SuspendLayout();
            this.gbCustomUploaderArguments.SuspendLayout();
            this.tpURLShorteners.SuspendLayout();
            this.tcURLShorteners.SuspendLayout();
            this.tpGoogleURLShortener.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpOtherServices.SuspendLayout();
            this.tcOtherServices.SuspendLayout();
            this.tpTwitter.SuspendLayout();
            this.tbOutputs.SuspendLayout();
            this.tcOutputs.SuspendLayout();
            this.tpEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmailSmtpPort)).BeginInit();
            this.tpSharedFolders.SuspendLayout();
            this.tlpSharedFolders.SuspendLayout();
            this.gbSharedFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcUploaders
            // 
            this.tcUploaders.Controls.Add(this.tpImageUploaders);
            this.tcUploaders.Controls.Add(this.tpTextUploaders);
            this.tcUploaders.Controls.Add(this.tpFileUploaders);
            this.tcUploaders.Controls.Add(this.tpURLShorteners);
            this.tcUploaders.Controls.Add(this.tpOtherServices);
            this.tcUploaders.Controls.Add(this.tbOutputs);
            this.tcUploaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUploaders.Location = new System.Drawing.Point(3, 3);
            this.tcUploaders.Name = "tcUploaders";
            this.tcUploaders.SelectedIndex = 0;
            this.tcUploaders.Size = new System.Drawing.Size(826, 532);
            this.tcUploaders.TabIndex = 0;
            // 
            // tpImageUploaders
            // 
            this.tpImageUploaders.Controls.Add(this.tcImageUploaders);
            this.tpImageUploaders.Location = new System.Drawing.Point(4, 22);
            this.tpImageUploaders.Name = "tpImageUploaders";
            this.tpImageUploaders.Padding = new System.Windows.Forms.Padding(3);
            this.tpImageUploaders.Size = new System.Drawing.Size(818, 506);
            this.tpImageUploaders.TabIndex = 0;
            this.tpImageUploaders.Text = "Image uploaders";
            this.tpImageUploaders.UseVisualStyleBackColor = true;
            // 
            // tcImageUploaders
            // 
            this.tcImageUploaders.Controls.Add(this.tpImageShack);
            this.tcImageUploaders.Controls.Add(this.tpTinyPic);
            this.tcImageUploaders.Controls.Add(this.tpImgur);
            this.tcImageUploaders.Controls.Add(this.tpFlickr);
            this.tcImageUploaders.Controls.Add(this.tpPhotobucket);
            this.tcImageUploaders.Controls.Add(this.tpTwitPic);
            this.tcImageUploaders.Controls.Add(this.tpTwitSnaps);
            this.tcImageUploaders.Controls.Add(this.tpYFrog);
            this.tcImageUploaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcImageUploaders.Location = new System.Drawing.Point(3, 3);
            this.tcImageUploaders.MinimumSize = new System.Drawing.Size(780, 480);
            this.tcImageUploaders.Name = "tcImageUploaders";
            this.tcImageUploaders.SelectedIndex = 0;
            this.tcImageUploaders.Size = new System.Drawing.Size(812, 500);
            this.tcImageUploaders.TabIndex = 0;
            // 
            // tpImageShack
            // 
            this.tpImageShack.Controls.Add(this.atcImageShackAccountType);
            this.tpImageShack.Controls.Add(this.btnImageShackOpenPublicProfile);
            this.tpImageShack.Controls.Add(this.cbImageShackIsPublic);
            this.tpImageShack.Controls.Add(this.btnImageShackOpenMyImages);
            this.tpImageShack.Controls.Add(this.lblImageShackUsername);
            this.tpImageShack.Controls.Add(this.btnImageShackOpenRegistrationCode);
            this.tpImageShack.Controls.Add(this.txtImageShackUsername);
            this.tpImageShack.Controls.Add(this.txtImageShackRegistrationCode);
            this.tpImageShack.Controls.Add(this.lblImageShackRegistrationCode);
            this.tpImageShack.Location = new System.Drawing.Point(4, 22);
            this.tpImageShack.Name = "tpImageShack";
            this.tpImageShack.Padding = new System.Windows.Forms.Padding(3);
            this.tpImageShack.Size = new System.Drawing.Size(804, 474);
            this.tpImageShack.TabIndex = 0;
            this.tpImageShack.Text = "ImageShack";
            this.tpImageShack.UseVisualStyleBackColor = true;
            // 
            // atcImageShackAccountType
            // 
            this.atcImageShackAccountType.Location = new System.Drawing.Point(8, 16);
            this.atcImageShackAccountType.Name = "atcImageShackAccountType";
            this.atcImageShackAccountType.SelectedAccountType = UploadersLib.AccountType.Anonymous;
            this.atcImageShackAccountType.Size = new System.Drawing.Size(272, 29);
            this.atcImageShackAccountType.TabIndex = 0;
            this.atcImageShackAccountType.AccountTypeChanged += new UploadersLib.GUI.AccountTypeControl.AccountTypeChangedEventHandler(this.atcImageShackAccountType_AccountTypeChanged);
            // 
            // btnImageShackOpenPublicProfile
            // 
            this.btnImageShackOpenPublicProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageShackOpenPublicProfile.Location = new System.Drawing.Point(16, 232);
            this.btnImageShackOpenPublicProfile.Name = "btnImageShackOpenPublicProfile";
            this.btnImageShackOpenPublicProfile.Size = new System.Drawing.Size(200, 23);
            this.btnImageShackOpenPublicProfile.TabIndex = 7;
            this.btnImageShackOpenPublicProfile.Text = "Open public profile page...";
            this.btnImageShackOpenPublicProfile.UseVisualStyleBackColor = true;
            this.btnImageShackOpenPublicProfile.Click += new System.EventHandler(this.btnImageShackOpenPublicProfile_Click);
            // 
            // cbImageShackIsPublic
            // 
            this.cbImageShackIsPublic.AutoSize = true;
            this.cbImageShackIsPublic.Location = new System.Drawing.Point(16, 168);
            this.cbImageShackIsPublic.Name = "cbImageShackIsPublic";
            this.cbImageShackIsPublic.Size = new System.Drawing.Size(307, 17);
            this.cbImageShackIsPublic.TabIndex = 5;
            this.cbImageShackIsPublic.Text = "Show images uploaded to ImageShack in your public profile";
            this.cbImageShackIsPublic.UseVisualStyleBackColor = true;
            this.cbImageShackIsPublic.CheckedChanged += new System.EventHandler(this.cbImageShackIsPublic_CheckedChanged);
            // 
            // btnImageShackOpenMyImages
            // 
            this.btnImageShackOpenMyImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageShackOpenMyImages.Location = new System.Drawing.Point(16, 264);
            this.btnImageShackOpenMyImages.Name = "btnImageShackOpenMyImages";
            this.btnImageShackOpenMyImages.Size = new System.Drawing.Size(200, 23);
            this.btnImageShackOpenMyImages.TabIndex = 8;
            this.btnImageShackOpenMyImages.Text = "Open my images page...";
            this.btnImageShackOpenMyImages.UseVisualStyleBackColor = true;
            this.btnImageShackOpenMyImages.Click += new System.EventHandler(this.btnImageShackOpenMyImages_Click);
            // 
            // lblImageShackUsername
            // 
            this.lblImageShackUsername.AutoSize = true;
            this.lblImageShackUsername.Location = new System.Drawing.Point(16, 112);
            this.lblImageShackUsername.Name = "lblImageShackUsername";
            this.lblImageShackUsername.Size = new System.Drawing.Size(246, 13);
            this.lblImageShackUsername.TabIndex = 3;
            this.lblImageShackUsername.Text = "Username (To be able to open public profile page):";
            // 
            // btnImageShackOpenRegistrationCode
            // 
            this.btnImageShackOpenRegistrationCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageShackOpenRegistrationCode.Location = new System.Drawing.Point(16, 200);
            this.btnImageShackOpenRegistrationCode.Name = "btnImageShackOpenRegistrationCode";
            this.btnImageShackOpenRegistrationCode.Size = new System.Drawing.Size(200, 23);
            this.btnImageShackOpenRegistrationCode.TabIndex = 6;
            this.btnImageShackOpenRegistrationCode.Text = "Open registration code page...";
            this.btnImageShackOpenRegistrationCode.UseVisualStyleBackColor = true;
            this.btnImageShackOpenRegistrationCode.Click += new System.EventHandler(this.btnImageShackOpenRegistrationCode_Click);
            // 
            // txtImageShackUsername
            // 
            this.txtImageShackUsername.Location = new System.Drawing.Point(16, 136);
            this.txtImageShackUsername.Name = "txtImageShackUsername";
            this.txtImageShackUsername.Size = new System.Drawing.Size(360, 20);
            this.txtImageShackUsername.TabIndex = 4;
            this.txtImageShackUsername.TextChanged += new System.EventHandler(this.txtImageShackUsername_TextChanged);
            // 
            // txtImageShackRegistrationCode
            // 
            this.txtImageShackRegistrationCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageShackRegistrationCode.Location = new System.Drawing.Point(16, 80);
            this.txtImageShackRegistrationCode.Name = "txtImageShackRegistrationCode";
            this.txtImageShackRegistrationCode.Size = new System.Drawing.Size(392, 20);
            this.txtImageShackRegistrationCode.TabIndex = 2;
            this.txtImageShackRegistrationCode.TextChanged += new System.EventHandler(this.txtImageShackRegistrationCode_TextChanged);
            // 
            // lblImageShackRegistrationCode
            // 
            this.lblImageShackRegistrationCode.AutoSize = true;
            this.lblImageShackRegistrationCode.Location = new System.Drawing.Point(16, 56);
            this.lblImageShackRegistrationCode.Name = "lblImageShackRegistrationCode";
            this.lblImageShackRegistrationCode.Size = new System.Drawing.Size(93, 13);
            this.lblImageShackRegistrationCode.TabIndex = 1;
            this.lblImageShackRegistrationCode.Text = "Registration code:";
            // 
            // tpTinyPic
            // 
            this.tpTinyPic.Controls.Add(this.atcTinyPicAccountType);
            this.tpTinyPic.Controls.Add(this.btnTinyPicLogin);
            this.tpTinyPic.Controls.Add(this.txtTinyPicPassword);
            this.tpTinyPic.Controls.Add(this.lblTinyPicPassword);
            this.tpTinyPic.Controls.Add(this.txtTinyPicUsername);
            this.tpTinyPic.Controls.Add(this.lblTinyPicUsername);
            this.tpTinyPic.Controls.Add(this.btnTinyPicOpenMyImages);
            this.tpTinyPic.Controls.Add(this.cbTinyPicRememberUsernamePassword);
            this.tpTinyPic.Controls.Add(this.lblTinyPicRegistrationCode);
            this.tpTinyPic.Controls.Add(this.txtTinyPicRegistrationCode);
            this.tpTinyPic.Location = new System.Drawing.Point(4, 22);
            this.tpTinyPic.Name = "tpTinyPic";
            this.tpTinyPic.Padding = new System.Windows.Forms.Padding(3);
            this.tpTinyPic.Size = new System.Drawing.Size(804, 474);
            this.tpTinyPic.TabIndex = 1;
            this.tpTinyPic.Text = "TinyPic";
            this.tpTinyPic.UseVisualStyleBackColor = true;
            // 
            // atcTinyPicAccountType
            // 
            this.atcTinyPicAccountType.Location = new System.Drawing.Point(8, 16);
            this.atcTinyPicAccountType.Name = "atcTinyPicAccountType";
            this.atcTinyPicAccountType.SelectedAccountType = UploadersLib.AccountType.Anonymous;
            this.atcTinyPicAccountType.Size = new System.Drawing.Size(272, 29);
            this.atcTinyPicAccountType.TabIndex = 0;
            this.atcTinyPicAccountType.AccountTypeChanged += new UploadersLib.GUI.AccountTypeControl.AccountTypeChangedEventHandler(this.atcTinyPicAccountType_AccountTypeChanged);
            // 
            // btnTinyPicLogin
            // 
            this.btnTinyPicLogin.Location = new System.Drawing.Point(16, 168);
            this.btnTinyPicLogin.Name = "btnTinyPicLogin";
            this.btnTinyPicLogin.Size = new System.Drawing.Size(80, 23);
            this.btnTinyPicLogin.TabIndex = 5;
            this.btnTinyPicLogin.Text = "Login";
            this.btnTinyPicLogin.UseVisualStyleBackColor = true;
            this.btnTinyPicLogin.Click += new System.EventHandler(this.btnTinyPicLogin_Click);
            // 
            // txtTinyPicPassword
            // 
            this.txtTinyPicPassword.Location = new System.Drawing.Point(16, 136);
            this.txtTinyPicPassword.Name = "txtTinyPicPassword";
            this.txtTinyPicPassword.PasswordChar = '*';
            this.txtTinyPicPassword.Size = new System.Drawing.Size(360, 20);
            this.txtTinyPicPassword.TabIndex = 4;
            this.txtTinyPicPassword.TextChanged += new System.EventHandler(this.txtTinyPicPassword_TextChanged);
            // 
            // lblTinyPicPassword
            // 
            this.lblTinyPicPassword.AutoSize = true;
            this.lblTinyPicPassword.Location = new System.Drawing.Point(16, 112);
            this.lblTinyPicPassword.Name = "lblTinyPicPassword";
            this.lblTinyPicPassword.Size = new System.Drawing.Size(56, 13);
            this.lblTinyPicPassword.TabIndex = 3;
            this.lblTinyPicPassword.Text = "Password:";
            // 
            // txtTinyPicUsername
            // 
            this.txtTinyPicUsername.Location = new System.Drawing.Point(16, 80);
            this.txtTinyPicUsername.Name = "txtTinyPicUsername";
            this.txtTinyPicUsername.Size = new System.Drawing.Size(360, 20);
            this.txtTinyPicUsername.TabIndex = 2;
            this.txtTinyPicUsername.TextChanged += new System.EventHandler(this.txtTinyPicUsername_TextChanged);
            // 
            // lblTinyPicUsername
            // 
            this.lblTinyPicUsername.AutoSize = true;
            this.lblTinyPicUsername.Location = new System.Drawing.Point(16, 56);
            this.lblTinyPicUsername.Name = "lblTinyPicUsername";
            this.lblTinyPicUsername.Size = new System.Drawing.Size(58, 13);
            this.lblTinyPicUsername.TabIndex = 1;
            this.lblTinyPicUsername.Text = "Username:";
            // 
            // btnTinyPicOpenMyImages
            // 
            this.btnTinyPicOpenMyImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTinyPicOpenMyImages.Location = new System.Drawing.Point(16, 264);
            this.btnTinyPicOpenMyImages.Name = "btnTinyPicOpenMyImages";
            this.btnTinyPicOpenMyImages.Size = new System.Drawing.Size(200, 23);
            this.btnTinyPicOpenMyImages.TabIndex = 9;
            this.btnTinyPicOpenMyImages.Text = "Open my images page...";
            this.btnTinyPicOpenMyImages.UseVisualStyleBackColor = true;
            this.btnTinyPicOpenMyImages.Click += new System.EventHandler(this.btnTinyPicOpenMyImages_Click);
            // 
            // cbTinyPicRememberUsernamePassword
            // 
            this.cbTinyPicRememberUsernamePassword.AutoSize = true;
            this.cbTinyPicRememberUsernamePassword.Location = new System.Drawing.Point(112, 171);
            this.cbTinyPicRememberUsernamePassword.Name = "cbTinyPicRememberUsernamePassword";
            this.cbTinyPicRememberUsernamePassword.Size = new System.Drawing.Size(233, 17);
            this.cbTinyPicRememberUsernamePassword.TabIndex = 6;
            this.cbTinyPicRememberUsernamePassword.Text = "Remember TinyPic username and password";
            this.cbTinyPicRememberUsernamePassword.UseVisualStyleBackColor = true;
            this.cbTinyPicRememberUsernamePassword.CheckedChanged += new System.EventHandler(this.cbTinyPicRememberUsernamePassword_CheckedChanged);
            // 
            // lblTinyPicRegistrationCode
            // 
            this.lblTinyPicRegistrationCode.AutoSize = true;
            this.lblTinyPicRegistrationCode.Location = new System.Drawing.Point(16, 208);
            this.lblTinyPicRegistrationCode.Name = "lblTinyPicRegistrationCode";
            this.lblTinyPicRegistrationCode.Size = new System.Drawing.Size(335, 13);
            this.lblTinyPicRegistrationCode.TabIndex = 7;
            this.lblTinyPicRegistrationCode.Text = "Registration code (You must login for be able to get registration code):";
            // 
            // txtTinyPicRegistrationCode
            // 
            this.txtTinyPicRegistrationCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTinyPicRegistrationCode.BackColor = System.Drawing.Color.White;
            this.txtTinyPicRegistrationCode.Location = new System.Drawing.Point(16, 232);
            this.txtTinyPicRegistrationCode.Name = "txtTinyPicRegistrationCode";
            this.txtTinyPicRegistrationCode.ReadOnly = true;
            this.txtTinyPicRegistrationCode.Size = new System.Drawing.Size(392, 20);
            this.txtTinyPicRegistrationCode.TabIndex = 8;
            // 
            // tpImgur
            // 
            this.tpImgur.Controls.Add(this.cbImgurThumbnailType);
            this.tpImgur.Controls.Add(this.lblImgurThumbnailType);
            this.tpImgur.Controls.Add(this.gbImgurUserAccount);
            this.tpImgur.Controls.Add(this.atcImgurAccountType);
            this.tpImgur.Location = new System.Drawing.Point(4, 22);
            this.tpImgur.Name = "tpImgur";
            this.tpImgur.Padding = new System.Windows.Forms.Padding(3);
            this.tpImgur.Size = new System.Drawing.Size(804, 474);
            this.tpImgur.TabIndex = 2;
            this.tpImgur.Text = "Imgur";
            this.tpImgur.UseVisualStyleBackColor = true;
            // 
            // cbImgurThumbnailType
            // 
            this.cbImgurThumbnailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImgurThumbnailType.FormattingEnabled = true;
            this.cbImgurThumbnailType.Location = new System.Drawing.Point(104, 52);
            this.cbImgurThumbnailType.Name = "cbImgurThumbnailType";
            this.cbImgurThumbnailType.Size = new System.Drawing.Size(168, 21);
            this.cbImgurThumbnailType.TabIndex = 2;
            this.cbImgurThumbnailType.SelectedIndexChanged += new System.EventHandler(this.cbImgurThumbnailType_SelectedIndexChanged);
            // 
            // lblImgurThumbnailType
            // 
            this.lblImgurThumbnailType.AutoSize = true;
            this.lblImgurThumbnailType.Location = new System.Drawing.Point(16, 56);
            this.lblImgurThumbnailType.Name = "lblImgurThumbnailType";
            this.lblImgurThumbnailType.Size = new System.Drawing.Size(82, 13);
            this.lblImgurThumbnailType.TabIndex = 1;
            this.lblImgurThumbnailType.Text = "Thumbnail type:";
            // 
            // gbImgurUserAccount
            // 
            this.gbImgurUserAccount.Controls.Add(this.btnImgurOpenAuthorizePage);
            this.gbImgurUserAccount.Controls.Add(this.lblImgurVerificationCode);
            this.gbImgurUserAccount.Controls.Add(this.btnImgurEnterVerificationCode);
            this.gbImgurUserAccount.Controls.Add(this.txtImgurVerificationCode);
            this.gbImgurUserAccount.Controls.Add(this.lblImgurAccountStatus);
            this.gbImgurUserAccount.Location = new System.Drawing.Point(16, 88);
            this.gbImgurUserAccount.Name = "gbImgurUserAccount";
            this.gbImgurUserAccount.Size = new System.Drawing.Size(392, 192);
            this.gbImgurUserAccount.TabIndex = 3;
            this.gbImgurUserAccount.TabStop = false;
            this.gbImgurUserAccount.Text = "User account";
            // 
            // btnImgurOpenAuthorizePage
            // 
            this.btnImgurOpenAuthorizePage.Location = new System.Drawing.Point(16, 24);
            this.btnImgurOpenAuthorizePage.Name = "btnImgurOpenAuthorizePage";
            this.btnImgurOpenAuthorizePage.Size = new System.Drawing.Size(200, 23);
            this.btnImgurOpenAuthorizePage.TabIndex = 0;
            this.btnImgurOpenAuthorizePage.Text = "Open authorize page...";
            this.btnImgurOpenAuthorizePage.UseVisualStyleBackColor = true;
            this.btnImgurOpenAuthorizePage.Click += new System.EventHandler(this.btnImgurOpenAuthorizePage_Click);
            // 
            // lblImgurVerificationCode
            // 
            this.lblImgurVerificationCode.AutoSize = true;
            this.lblImgurVerificationCode.Location = new System.Drawing.Point(16, 64);
            this.lblImgurVerificationCode.Name = "lblImgurVerificationCode";
            this.lblImgurVerificationCode.Size = new System.Drawing.Size(292, 13);
            this.lblImgurVerificationCode.TabIndex = 1;
            this.lblImgurVerificationCode.Text = "Verification code (Get verification code from authorize page):";
            // 
            // btnImgurEnterVerificationCode
            // 
            this.btnImgurEnterVerificationCode.Location = new System.Drawing.Point(16, 120);
            this.btnImgurEnterVerificationCode.Name = "btnImgurEnterVerificationCode";
            this.btnImgurEnterVerificationCode.Size = new System.Drawing.Size(200, 23);
            this.btnImgurEnterVerificationCode.TabIndex = 3;
            this.btnImgurEnterVerificationCode.Text = "Complete authorization";
            this.btnImgurEnterVerificationCode.UseVisualStyleBackColor = true;
            this.btnImgurEnterVerificationCode.Click += new System.EventHandler(this.btnImgurEnterVerificationCode_Click);
            // 
            // txtImgurVerificationCode
            // 
            this.txtImgurVerificationCode.Location = new System.Drawing.Point(16, 88);
            this.txtImgurVerificationCode.Name = "txtImgurVerificationCode";
            this.txtImgurVerificationCode.Size = new System.Drawing.Size(360, 20);
            this.txtImgurVerificationCode.TabIndex = 2;
            // 
            // lblImgurAccountStatus
            // 
            this.lblImgurAccountStatus.AutoSize = true;
            this.lblImgurAccountStatus.Location = new System.Drawing.Point(16, 160);
            this.lblImgurAccountStatus.Name = "lblImgurAccountStatus";
            this.lblImgurAccountStatus.Size = new System.Drawing.Size(77, 13);
            this.lblImgurAccountStatus.TabIndex = 4;
            this.lblImgurAccountStatus.Text = "Login required.";
            // 
            // atcImgurAccountType
            // 
            this.atcImgurAccountType.Location = new System.Drawing.Point(8, 16);
            this.atcImgurAccountType.Name = "atcImgurAccountType";
            this.atcImgurAccountType.SelectedAccountType = UploadersLib.AccountType.Anonymous;
            this.atcImgurAccountType.Size = new System.Drawing.Size(272, 29);
            this.atcImgurAccountType.TabIndex = 0;
            this.atcImgurAccountType.AccountTypeChanged += new UploadersLib.GUI.AccountTypeControl.AccountTypeChangedEventHandler(this.atcImgurAccountType_AccountTypeChanged);
            // 
            // tpFlickr
            // 
            this.tpFlickr.Controls.Add(this.btnFlickrOpenImages);
            this.tpFlickr.Controls.Add(this.pgFlickrAuthInfo);
            this.tpFlickr.Controls.Add(this.pgFlickrSettings);
            this.tpFlickr.Controls.Add(this.btnFlickrCheckToken);
            this.tpFlickr.Controls.Add(this.btnFlickrCompleteAuth);
            this.tpFlickr.Controls.Add(this.btnFlickrOpenAuthorize);
            this.tpFlickr.Location = new System.Drawing.Point(4, 22);
            this.tpFlickr.Name = "tpFlickr";
            this.tpFlickr.Padding = new System.Windows.Forms.Padding(3);
            this.tpFlickr.Size = new System.Drawing.Size(804, 474);
            this.tpFlickr.TabIndex = 3;
            this.tpFlickr.Text = "Flickr";
            this.tpFlickr.UseVisualStyleBackColor = true;
            // 
            // btnFlickrOpenImages
            // 
            this.btnFlickrOpenImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFlickrOpenImages.Location = new System.Drawing.Point(624, 213);
            this.btnFlickrOpenImages.Name = "btnFlickrOpenImages";
            this.btnFlickrOpenImages.Size = new System.Drawing.Size(168, 23);
            this.btnFlickrOpenImages.TabIndex = 5;
            this.btnFlickrOpenImages.Text = "Your photostream...";
            this.btnFlickrOpenImages.UseVisualStyleBackColor = true;
            this.btnFlickrOpenImages.Click += new System.EventHandler(this.btnFlickrOpenImages_Click);
            // 
            // pgFlickrAuthInfo
            // 
            this.pgFlickrAuthInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgFlickrAuthInfo.CommandsVisibleIfAvailable = false;
            this.pgFlickrAuthInfo.Location = new System.Drawing.Point(16, 16);
            this.pgFlickrAuthInfo.Name = "pgFlickrAuthInfo";
            this.pgFlickrAuthInfo.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgFlickrAuthInfo.Size = new System.Drawing.Size(594, 160);
            this.pgFlickrAuthInfo.TabIndex = 0;
            this.pgFlickrAuthInfo.ToolbarVisible = false;
            // 
            // pgFlickrSettings
            // 
            this.pgFlickrSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgFlickrSettings.CommandsVisibleIfAvailable = false;
            this.pgFlickrSettings.Location = new System.Drawing.Point(16, 184);
            this.pgFlickrSettings.Name = "pgFlickrSettings";
            this.pgFlickrSettings.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgFlickrSettings.Size = new System.Drawing.Size(594, 274);
            this.pgFlickrSettings.TabIndex = 3;
            this.pgFlickrSettings.ToolbarVisible = false;
            // 
            // btnFlickrCheckToken
            // 
            this.btnFlickrCheckToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFlickrCheckToken.Location = new System.Drawing.Point(624, 184);
            this.btnFlickrCheckToken.Name = "btnFlickrCheckToken";
            this.btnFlickrCheckToken.Size = new System.Drawing.Size(168, 23);
            this.btnFlickrCheckToken.TabIndex = 4;
            this.btnFlickrCheckToken.Text = "Check Token...";
            this.btnFlickrCheckToken.UseVisualStyleBackColor = true;
            this.btnFlickrCheckToken.Click += new System.EventHandler(this.btnFlickrCheckToken_Click);
            // 
            // btnFlickrCompleteAuth
            // 
            this.btnFlickrCompleteAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFlickrCompleteAuth.Enabled = false;
            this.btnFlickrCompleteAuth.Location = new System.Drawing.Point(624, 47);
            this.btnFlickrCompleteAuth.Name = "btnFlickrCompleteAuth";
            this.btnFlickrCompleteAuth.Size = new System.Drawing.Size(168, 24);
            this.btnFlickrCompleteAuth.TabIndex = 2;
            this.btnFlickrCompleteAuth.Text = "Step 2. Complete authorization";
            this.btnFlickrCompleteAuth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlickrCompleteAuth.UseVisualStyleBackColor = true;
            this.btnFlickrCompleteAuth.Click += new System.EventHandler(this.btnFlickrCompleteAuth_Click);
            // 
            // btnFlickrOpenAuthorize
            // 
            this.btnFlickrOpenAuthorize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFlickrOpenAuthorize.Location = new System.Drawing.Point(624, 18);
            this.btnFlickrOpenAuthorize.Name = "btnFlickrOpenAuthorize";
            this.btnFlickrOpenAuthorize.Size = new System.Drawing.Size(168, 23);
            this.btnFlickrOpenAuthorize.TabIndex = 1;
            this.btnFlickrOpenAuthorize.Text = "Step 1. Open authorize page...";
            this.btnFlickrOpenAuthorize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlickrOpenAuthorize.UseVisualStyleBackColor = true;
            this.btnFlickrOpenAuthorize.Click += new System.EventHandler(this.btnFlickrOpenAuthorize_Click);
            // 
            // tpPhotobucket
            // 
            this.tpPhotobucket.Controls.Add(this.gbPhotobucketAlbumPath);
            this.tpPhotobucket.Controls.Add(this.gbPhotobucketAlbums);
            this.tpPhotobucket.Controls.Add(this.gbPhotobucketUserAccount);
            this.tpPhotobucket.Location = new System.Drawing.Point(4, 22);
            this.tpPhotobucket.Name = "tpPhotobucket";
            this.tpPhotobucket.Padding = new System.Windows.Forms.Padding(3);
            this.tpPhotobucket.Size = new System.Drawing.Size(804, 474);
            this.tpPhotobucket.TabIndex = 4;
            this.tpPhotobucket.Text = "Photobucket";
            this.tpPhotobucket.UseVisualStyleBackColor = true;
            // 
            // gbPhotobucketAlbumPath
            // 
            this.gbPhotobucketAlbumPath.Controls.Add(this.btnPhotobucketAddAlbum);
            this.gbPhotobucketAlbumPath.Controls.Add(this.btnPhotobucketRemoveAlbum);
            this.gbPhotobucketAlbumPath.Controls.Add(this.cboPhotobucketAlbumPaths);
            this.gbPhotobucketAlbumPath.Location = new System.Drawing.Point(16, 208);
            this.gbPhotobucketAlbumPath.Name = "gbPhotobucketAlbumPath";
            this.gbPhotobucketAlbumPath.Size = new System.Drawing.Size(712, 64);
            this.gbPhotobucketAlbumPath.TabIndex = 1;
            this.gbPhotobucketAlbumPath.TabStop = false;
            this.gbPhotobucketAlbumPath.Text = "Upload images to";
            // 
            // btnPhotobucketAddAlbum
            // 
            this.btnPhotobucketAddAlbum.Location = new System.Drawing.Point(488, 24);
            this.btnPhotobucketAddAlbum.Name = "btnPhotobucketAddAlbum";
            this.btnPhotobucketAddAlbum.Size = new System.Drawing.Size(75, 23);
            this.btnPhotobucketAddAlbum.TabIndex = 1;
            this.btnPhotobucketAddAlbum.Text = "Add album";
            this.btnPhotobucketAddAlbum.UseVisualStyleBackColor = true;
            this.btnPhotobucketAddAlbum.Click += new System.EventHandler(this.btnPhotobucketAddAlbum_Click);
            // 
            // btnPhotobucketRemoveAlbum
            // 
            this.btnPhotobucketRemoveAlbum.AutoSize = true;
            this.btnPhotobucketRemoveAlbum.Location = new System.Drawing.Point(568, 24);
            this.btnPhotobucketRemoveAlbum.Name = "btnPhotobucketRemoveAlbum";
            this.btnPhotobucketRemoveAlbum.Size = new System.Drawing.Size(104, 23);
            this.btnPhotobucketRemoveAlbum.TabIndex = 2;
            this.btnPhotobucketRemoveAlbum.Text = "Remove album";
            this.btnPhotobucketRemoveAlbum.UseVisualStyleBackColor = true;
            this.btnPhotobucketRemoveAlbum.Click += new System.EventHandler(this.btnPhotobucketRemoveAlbum_Click);
            // 
            // cboPhotobucketAlbumPaths
            // 
            this.cboPhotobucketAlbumPaths.FormattingEnabled = true;
            this.cboPhotobucketAlbumPaths.Location = new System.Drawing.Point(16, 24);
            this.cboPhotobucketAlbumPaths.Name = "cboPhotobucketAlbumPaths";
            this.cboPhotobucketAlbumPaths.Size = new System.Drawing.Size(456, 21);
            this.cboPhotobucketAlbumPaths.TabIndex = 0;
            this.cboPhotobucketAlbumPaths.SelectedIndexChanged += new System.EventHandler(this.cboPhotobucketAlbumPaths_SelectedIndexChanged);
            // 
            // gbPhotobucketAlbums
            // 
            this.gbPhotobucketAlbums.Controls.Add(this.label8);
            this.gbPhotobucketAlbums.Controls.Add(this.lblPhotobucketParentAlbumPath);
            this.gbPhotobucketAlbums.Controls.Add(this.txtPhotobucketNewAlbumName);
            this.gbPhotobucketAlbums.Controls.Add(this.txtPhotobucketParentAlbumPath);
            this.gbPhotobucketAlbums.Controls.Add(this.btnPhotobucketCreateAlbum);
            this.gbPhotobucketAlbums.Location = new System.Drawing.Point(16, 280);
            this.gbPhotobucketAlbums.Name = "gbPhotobucketAlbums";
            this.gbPhotobucketAlbums.Size = new System.Drawing.Size(712, 128);
            this.gbPhotobucketAlbums.TabIndex = 2;
            this.gbPhotobucketAlbums.TabStop = false;
            this.gbPhotobucketAlbums.Text = "Create new album";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(649, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "New album name ( must be between 2 and 50 characters. Valid characters are letter" +
    "s, numbers, underscore ( _ ), hyphen (-), and space )";
            // 
            // lblPhotobucketParentAlbumPath
            // 
            this.lblPhotobucketParentAlbumPath.AutoSize = true;
            this.lblPhotobucketParentAlbumPath.Location = new System.Drawing.Point(16, 24);
            this.lblPhotobucketParentAlbumPath.Name = "lblPhotobucketParentAlbumPath";
            this.lblPhotobucketParentAlbumPath.Size = new System.Drawing.Size(93, 13);
            this.lblPhotobucketParentAlbumPath.TabIndex = 0;
            this.lblPhotobucketParentAlbumPath.Text = "Parent album path";
            // 
            // txtPhotobucketNewAlbumName
            // 
            this.txtPhotobucketNewAlbumName.Location = new System.Drawing.Point(16, 88);
            this.txtPhotobucketNewAlbumName.Name = "txtPhotobucketNewAlbumName";
            this.txtPhotobucketNewAlbumName.Size = new System.Drawing.Size(216, 20);
            this.txtPhotobucketNewAlbumName.TabIndex = 3;
            // 
            // txtPhotobucketParentAlbumPath
            // 
            this.txtPhotobucketParentAlbumPath.Location = new System.Drawing.Point(16, 40);
            this.txtPhotobucketParentAlbumPath.Name = "txtPhotobucketParentAlbumPath";
            this.txtPhotobucketParentAlbumPath.Size = new System.Drawing.Size(448, 20);
            this.txtPhotobucketParentAlbumPath.TabIndex = 1;
            // 
            // btnPhotobucketCreateAlbum
            // 
            this.btnPhotobucketCreateAlbum.Location = new System.Drawing.Point(240, 88);
            this.btnPhotobucketCreateAlbum.Name = "btnPhotobucketCreateAlbum";
            this.btnPhotobucketCreateAlbum.Size = new System.Drawing.Size(128, 23);
            this.btnPhotobucketCreateAlbum.TabIndex = 4;
            this.btnPhotobucketCreateAlbum.Text = "Create album";
            this.btnPhotobucketCreateAlbum.UseVisualStyleBackColor = true;
            this.btnPhotobucketCreateAlbum.Click += new System.EventHandler(this.btnPhotobucketCreateAlbum_Click);
            // 
            // gbPhotobucketUserAccount
            // 
            this.gbPhotobucketUserAccount.Controls.Add(this.label6);
            this.gbPhotobucketUserAccount.Controls.Add(this.btnPhotobucketAuthOpen);
            this.gbPhotobucketUserAccount.Controls.Add(this.txtPhotobucketDefaultAlbumName);
            this.gbPhotobucketUserAccount.Controls.Add(this.label5);
            this.gbPhotobucketUserAccount.Controls.Add(this.btnPhotobucketAuthComplete);
            this.gbPhotobucketUserAccount.Controls.Add(this.txtPhotobucketVerificationCode);
            this.gbPhotobucketUserAccount.Controls.Add(this.lblPhotobucketAccountStatus);
            this.gbPhotobucketUserAccount.Location = new System.Drawing.Point(16, 16);
            this.gbPhotobucketUserAccount.Name = "gbPhotobucketUserAccount";
            this.gbPhotobucketUserAccount.Size = new System.Drawing.Size(712, 184);
            this.gbPhotobucketUserAccount.TabIndex = 0;
            this.gbPhotobucketUserAccount.TabStop = false;
            this.gbPhotobucketUserAccount.Text = "User account";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Default Album Name";
            // 
            // btnPhotobucketAuthOpen
            // 
            this.btnPhotobucketAuthOpen.Location = new System.Drawing.Point(16, 24);
            this.btnPhotobucketAuthOpen.Name = "btnPhotobucketAuthOpen";
            this.btnPhotobucketAuthOpen.Size = new System.Drawing.Size(200, 23);
            this.btnPhotobucketAuthOpen.TabIndex = 0;
            this.btnPhotobucketAuthOpen.Text = "Step 1: Open authorize page...";
            this.btnPhotobucketAuthOpen.UseVisualStyleBackColor = true;
            this.btnPhotobucketAuthOpen.Click += new System.EventHandler(this.btnPhotobucketAuthOpen_Click);
            // 
            // txtPhotobucketDefaultAlbumName
            // 
            this.txtPhotobucketDefaultAlbumName.Location = new System.Drawing.Point(496, 144);
            this.txtPhotobucketDefaultAlbumName.Name = "txtPhotobucketDefaultAlbumName";
            this.txtPhotobucketDefaultAlbumName.ReadOnly = true;
            this.txtPhotobucketDefaultAlbumName.Size = new System.Drawing.Size(200, 20);
            this.txtPhotobucketDefaultAlbumName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(292, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Verification code (Get verification code from authorize page):";
            // 
            // btnPhotobucketAuthComplete
            // 
            this.btnPhotobucketAuthComplete.Location = new System.Drawing.Point(16, 112);
            this.btnPhotobucketAuthComplete.Name = "btnPhotobucketAuthComplete";
            this.btnPhotobucketAuthComplete.Size = new System.Drawing.Size(200, 23);
            this.btnPhotobucketAuthComplete.TabIndex = 3;
            this.btnPhotobucketAuthComplete.Text = "Step 2: Complete authorization";
            this.btnPhotobucketAuthComplete.UseVisualStyleBackColor = true;
            this.btnPhotobucketAuthComplete.Click += new System.EventHandler(this.btnPhotobucketAuthComplete_Click);
            // 
            // txtPhotobucketVerificationCode
            // 
            this.txtPhotobucketVerificationCode.Location = new System.Drawing.Point(16, 80);
            this.txtPhotobucketVerificationCode.Name = "txtPhotobucketVerificationCode";
            this.txtPhotobucketVerificationCode.Size = new System.Drawing.Size(360, 20);
            this.txtPhotobucketVerificationCode.TabIndex = 2;
            // 
            // lblPhotobucketAccountStatus
            // 
            this.lblPhotobucketAccountStatus.AutoSize = true;
            this.lblPhotobucketAccountStatus.Location = new System.Drawing.Point(24, 152);
            this.lblPhotobucketAccountStatus.Name = "lblPhotobucketAccountStatus";
            this.lblPhotobucketAccountStatus.Size = new System.Drawing.Size(77, 13);
            this.lblPhotobucketAccountStatus.TabIndex = 6;
            this.lblPhotobucketAccountStatus.Text = "Login required.";
            // 
            // tpTwitPic
            // 
            this.tpTwitPic.Controls.Add(this.lblTwitPicTip);
            this.tpTwitPic.Controls.Add(this.chkTwitPicShowFull);
            this.tpTwitPic.Controls.Add(this.cboTwitPicThumbnailMode);
            this.tpTwitPic.Controls.Add(this.lblTwitPicThumbnailMode);
            this.tpTwitPic.Location = new System.Drawing.Point(4, 22);
            this.tpTwitPic.Name = "tpTwitPic";
            this.tpTwitPic.Padding = new System.Windows.Forms.Padding(3);
            this.tpTwitPic.Size = new System.Drawing.Size(804, 474);
            this.tpTwitPic.TabIndex = 5;
            this.tpTwitPic.Text = "TwitPic";
            this.tpTwitPic.UseVisualStyleBackColor = true;
            // 
            // lblTwitPicTip
            // 
            this.lblTwitPicTip.AutoSize = true;
            this.lblTwitPicTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTwitPicTip.Location = new System.Drawing.Point(16, 16);
            this.lblTwitPicTip.Name = "lblTwitPicTip";
            this.lblTwitPicTip.Size = new System.Drawing.Size(343, 40);
            this.lblTwitPicTip.TabIndex = 7;
            this.lblTwitPicTip.Text = "TwitPic using Twitter settings for authentication.\r\nOther Services -> Twitter";
            // 
            // chkTwitPicShowFull
            // 
            this.chkTwitPicShowFull.AutoSize = true;
            this.chkTwitPicShowFull.Location = new System.Drawing.Point(24, 104);
            this.chkTwitPicShowFull.Name = "chkTwitPicShowFull";
            this.chkTwitPicShowFull.Size = new System.Drawing.Size(94, 17);
            this.chkTwitPicShowFull.TabIndex = 6;
            this.chkTwitPicShowFull.Text = "Show full URL";
            this.chkTwitPicShowFull.UseVisualStyleBackColor = true;
            this.chkTwitPicShowFull.CheckedChanged += new System.EventHandler(this.chkTwitPicShowFull_CheckedChanged);
            // 
            // cboTwitPicThumbnailMode
            // 
            this.cboTwitPicThumbnailMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTwitPicThumbnailMode.FormattingEnabled = true;
            this.cboTwitPicThumbnailMode.Location = new System.Drawing.Point(112, 68);
            this.cboTwitPicThumbnailMode.Name = "cboTwitPicThumbnailMode";
            this.cboTwitPicThumbnailMode.Size = new System.Drawing.Size(144, 21);
            this.cboTwitPicThumbnailMode.TabIndex = 5;
            this.cboTwitPicThumbnailMode.SelectedIndexChanged += new System.EventHandler(this.cboTwitPicThumbnailMode_SelectedIndexChanged);
            // 
            // lblTwitPicThumbnailMode
            // 
            this.lblTwitPicThumbnailMode.AutoSize = true;
            this.lblTwitPicThumbnailMode.Location = new System.Drawing.Point(24, 72);
            this.lblTwitPicThumbnailMode.Name = "lblTwitPicThumbnailMode";
            this.lblTwitPicThumbnailMode.Size = new System.Drawing.Size(82, 13);
            this.lblTwitPicThumbnailMode.TabIndex = 4;
            this.lblTwitPicThumbnailMode.Text = "Thumbnail type:";
            // 
            // tpTwitSnaps
            // 
            this.tpTwitSnaps.Controls.Add(this.lblTwitSnapsTip);
            this.tpTwitSnaps.Location = new System.Drawing.Point(4, 22);
            this.tpTwitSnaps.Name = "tpTwitSnaps";
            this.tpTwitSnaps.Padding = new System.Windows.Forms.Padding(3);
            this.tpTwitSnaps.Size = new System.Drawing.Size(804, 474);
            this.tpTwitSnaps.TabIndex = 6;
            this.tpTwitSnaps.Text = "TwitSnaps";
            this.tpTwitSnaps.UseVisualStyleBackColor = true;
            // 
            // lblTwitSnapsTip
            // 
            this.lblTwitSnapsTip.AutoSize = true;
            this.lblTwitSnapsTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTwitSnapsTip.Location = new System.Drawing.Point(16, 16);
            this.lblTwitSnapsTip.Name = "lblTwitSnapsTip";
            this.lblTwitSnapsTip.Size = new System.Drawing.Size(368, 40);
            this.lblTwitSnapsTip.TabIndex = 0;
            this.lblTwitSnapsTip.Text = "TwitSnaps using Twitter settings for authentication.\r\nOther Services -> Twitter";
            // 
            // tpYFrog
            // 
            this.tpYFrog.Controls.Add(this.lblYFrogPassword);
            this.tpYFrog.Controls.Add(this.lblYFrogUsername);
            this.tpYFrog.Controls.Add(this.txtYFrogPassword);
            this.tpYFrog.Controls.Add(this.txtYFrogUsername);
            this.tpYFrog.Location = new System.Drawing.Point(4, 22);
            this.tpYFrog.Name = "tpYFrog";
            this.tpYFrog.Padding = new System.Windows.Forms.Padding(3);
            this.tpYFrog.Size = new System.Drawing.Size(804, 474);
            this.tpYFrog.TabIndex = 7;
            this.tpYFrog.Text = "YFrog";
            this.tpYFrog.UseVisualStyleBackColor = true;
            // 
            // lblYFrogPassword
            // 
            this.lblYFrogPassword.AutoSize = true;
            this.lblYFrogPassword.Location = new System.Drawing.Point(24, 56);
            this.lblYFrogPassword.Name = "lblYFrogPassword";
            this.lblYFrogPassword.Size = new System.Drawing.Size(56, 13);
            this.lblYFrogPassword.TabIndex = 2;
            this.lblYFrogPassword.Text = "Password:";
            // 
            // lblYFrogUsername
            // 
            this.lblYFrogUsername.AutoSize = true;
            this.lblYFrogUsername.Location = new System.Drawing.Point(24, 24);
            this.lblYFrogUsername.Name = "lblYFrogUsername";
            this.lblYFrogUsername.Size = new System.Drawing.Size(58, 13);
            this.lblYFrogUsername.TabIndex = 0;
            this.lblYFrogUsername.Text = "Username:";
            // 
            // txtYFrogPassword
            // 
            this.txtYFrogPassword.Location = new System.Drawing.Point(88, 52);
            this.txtYFrogPassword.Name = "txtYFrogPassword";
            this.txtYFrogPassword.PasswordChar = '*';
            this.txtYFrogPassword.Size = new System.Drawing.Size(160, 20);
            this.txtYFrogPassword.TabIndex = 3;
            this.txtYFrogPassword.TextChanged += new System.EventHandler(this.txtYFrogPassword_TextChanged);
            // 
            // txtYFrogUsername
            // 
            this.txtYFrogUsername.Location = new System.Drawing.Point(88, 20);
            this.txtYFrogUsername.Name = "txtYFrogUsername";
            this.txtYFrogUsername.Size = new System.Drawing.Size(160, 20);
            this.txtYFrogUsername.TabIndex = 1;
            this.txtYFrogUsername.TextChanged += new System.EventHandler(this.txtYFrogUsername_TextChanged);
            // 
            // tpTextUploaders
            // 
            this.tpTextUploaders.Controls.Add(this.tcTextUploaders);
            this.tpTextUploaders.Location = new System.Drawing.Point(4, 22);
            this.tpTextUploaders.Name = "tpTextUploaders";
            this.tpTextUploaders.Padding = new System.Windows.Forms.Padding(3);
            this.tpTextUploaders.Size = new System.Drawing.Size(818, 506);
            this.tpTextUploaders.TabIndex = 1;
            this.tpTextUploaders.Text = "Text uploaders";
            this.tpTextUploaders.UseVisualStyleBackColor = true;
            // 
            // tcTextUploaders
            // 
            this.tcTextUploaders.Controls.Add(this.tpPastebin);
            this.tcTextUploaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTextUploaders.Location = new System.Drawing.Point(3, 3);
            this.tcTextUploaders.Name = "tcTextUploaders";
            this.tcTextUploaders.SelectedIndex = 0;
            this.tcTextUploaders.Size = new System.Drawing.Size(812, 500);
            this.tcTextUploaders.TabIndex = 0;
            // 
            // tpPastebin
            // 
            this.tpPastebin.Controls.Add(this.btnPastebinLogin);
            this.tpPastebin.Controls.Add(this.pgPastebinSettings);
            this.tpPastebin.Location = new System.Drawing.Point(4, 22);
            this.tpPastebin.Name = "tpPastebin";
            this.tpPastebin.Padding = new System.Windows.Forms.Padding(3);
            this.tpPastebin.Size = new System.Drawing.Size(804, 474);
            this.tpPastebin.TabIndex = 0;
            this.tpPastebin.Text = "Pastebin";
            this.tpPastebin.UseVisualStyleBackColor = true;
            // 
            // btnPastebinLogin
            // 
            this.btnPastebinLogin.Location = new System.Drawing.Point(520, 8);
            this.btnPastebinLogin.Name = "btnPastebinLogin";
            this.btnPastebinLogin.Size = new System.Drawing.Size(88, 23);
            this.btnPastebinLogin.TabIndex = 1;
            this.btnPastebinLogin.Text = "Login";
            this.btnPastebinLogin.UseVisualStyleBackColor = true;
            this.btnPastebinLogin.Click += new System.EventHandler(this.btnPastebinLogin_Click);
            // 
            // pgPastebinSettings
            // 
            this.pgPastebinSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.pgPastebinSettings.Location = new System.Drawing.Point(3, 3);
            this.pgPastebinSettings.Name = "pgPastebinSettings";
            this.pgPastebinSettings.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgPastebinSettings.Size = new System.Drawing.Size(504, 468);
            this.pgPastebinSettings.TabIndex = 0;
            // 
            // tpFileUploaders
            // 
            this.tpFileUploaders.Controls.Add(this.tcFileUploaders);
            this.tpFileUploaders.Location = new System.Drawing.Point(4, 22);
            this.tpFileUploaders.Name = "tpFileUploaders";
            this.tpFileUploaders.Padding = new System.Windows.Forms.Padding(3);
            this.tpFileUploaders.Size = new System.Drawing.Size(818, 506);
            this.tpFileUploaders.TabIndex = 2;
            this.tpFileUploaders.Text = "File uploaders";
            this.tpFileUploaders.UseVisualStyleBackColor = true;
            // 
            // tcFileUploaders
            // 
            this.tcFileUploaders.Controls.Add(this.tpDropbox);
            this.tcFileUploaders.Controls.Add(this.tpBox);
            this.tcFileUploaders.Controls.Add(this.tpMinus);
            this.tcFileUploaders.Controls.Add(this.tpFTP);
            this.tcFileUploaders.Controls.Add(this.tpRapidShare);
            this.tcFileUploaders.Controls.Add(this.tpSendSpace);
            this.tcFileUploaders.Controls.Add(this.tpCustomUploaders);
            this.tcFileUploaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFileUploaders.Location = new System.Drawing.Point(3, 3);
            this.tcFileUploaders.Name = "tcFileUploaders";
            this.tcFileUploaders.SelectedIndex = 0;
            this.tcFileUploaders.Size = new System.Drawing.Size(812, 500);
            this.tcFileUploaders.TabIndex = 0;
            // 
            // tpDropbox
            // 
            this.tpDropbox.Controls.Add(this.cbDropboxAutoCreateShareableLink);
            this.tpDropbox.Controls.Add(this.btnDropboxShowFiles);
            this.tpDropbox.Controls.Add(this.btnDropboxCompleteAuth);
            this.tpDropbox.Controls.Add(this.pbDropboxLogo);
            this.tpDropbox.Controls.Add(this.btnDropboxRegister);
            this.tpDropbox.Controls.Add(this.lblDropboxStatus);
            this.tpDropbox.Controls.Add(this.lblDropboxPathTip);
            this.tpDropbox.Controls.Add(this.lblDropboxPath);
            this.tpDropbox.Controls.Add(this.btnDropboxOpenAuthorize);
            this.tpDropbox.Controls.Add(this.txtDropboxPath);
            this.tpDropbox.Location = new System.Drawing.Point(4, 22);
            this.tpDropbox.Name = "tpDropbox";
            this.tpDropbox.Padding = new System.Windows.Forms.Padding(3);
            this.tpDropbox.Size = new System.Drawing.Size(804, 474);
            this.tpDropbox.TabIndex = 0;
            this.tpDropbox.Text = "Dropbox";
            this.tpDropbox.UseVisualStyleBackColor = true;
            // 
            // cbDropboxAutoCreateShareableLink
            // 
            this.cbDropboxAutoCreateShareableLink.AutoSize = true;
            this.cbDropboxAutoCreateShareableLink.Location = new System.Drawing.Point(18, 152);
            this.cbDropboxAutoCreateShareableLink.Name = "cbDropboxAutoCreateShareableLink";
            this.cbDropboxAutoCreateShareableLink.Size = new System.Drawing.Size(299, 17);
            this.cbDropboxAutoCreateShareableLink.TabIndex = 7;
            this.cbDropboxAutoCreateShareableLink.Text = "Create shortened shareable URL (will expire after 30 days)";
            this.cbDropboxAutoCreateShareableLink.UseVisualStyleBackColor = true;
            this.cbDropboxAutoCreateShareableLink.CheckedChanged += new System.EventHandler(this.cbDropboxAutoCreateShareableLink_CheckedChanged);
            // 
            // btnDropboxShowFiles
            // 
            this.btnDropboxShowFiles.Enabled = false;
            this.btnDropboxShowFiles.Location = new System.Drawing.Point(344, 120);
            this.btnDropboxShowFiles.Name = "btnDropboxShowFiles";
            this.btnDropboxShowFiles.Size = new System.Drawing.Size(64, 24);
            this.btnDropboxShowFiles.TabIndex = 5;
            this.btnDropboxShowFiles.Text = "Select...";
            this.btnDropboxShowFiles.UseVisualStyleBackColor = true;
            this.btnDropboxShowFiles.Click += new System.EventHandler(this.btnDropboxShowFiles_Click);
            // 
            // btnDropboxCompleteAuth
            // 
            this.btnDropboxCompleteAuth.Enabled = false;
            this.btnDropboxCompleteAuth.Location = new System.Drawing.Point(176, 88);
            this.btnDropboxCompleteAuth.Name = "btnDropboxCompleteAuth";
            this.btnDropboxCompleteAuth.Size = new System.Drawing.Size(152, 24);
            this.btnDropboxCompleteAuth.TabIndex = 2;
            this.btnDropboxCompleteAuth.Text = "2. Complete authorization";
            this.btnDropboxCompleteAuth.UseVisualStyleBackColor = true;
            this.btnDropboxCompleteAuth.Click += new System.EventHandler(this.btnDropboxAuthComplete_Click);
            // 
            // pbDropboxLogo
            // 
            this.pbDropboxLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDropboxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbDropboxLogo.Image")));
            this.pbDropboxLogo.Location = new System.Drawing.Point(16, 16);
            this.pbDropboxLogo.Name = "pbDropboxLogo";
            this.pbDropboxLogo.Size = new System.Drawing.Size(248, 64);
            this.pbDropboxLogo.TabIndex = 19;
            this.pbDropboxLogo.TabStop = false;
            this.pbDropboxLogo.Click += new System.EventHandler(this.pbDropboxLogo_Click);
            // 
            // btnDropboxRegister
            // 
            this.btnDropboxRegister.Location = new System.Drawing.Point(272, 16);
            this.btnDropboxRegister.Name = "btnDropboxRegister";
            this.btnDropboxRegister.Size = new System.Drawing.Size(96, 24);
            this.btnDropboxRegister.TabIndex = 0;
            this.btnDropboxRegister.Text = "Register...";
            this.btnDropboxRegister.UseVisualStyleBackColor = true;
            this.btnDropboxRegister.Click += new System.EventHandler(this.btnDropboxRegister_Click);
            // 
            // lblDropboxStatus
            // 
            this.lblDropboxStatus.AutoSize = true;
            this.lblDropboxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDropboxStatus.Location = new System.Drawing.Point(16, 176);
            this.lblDropboxStatus.Name = "lblDropboxStatus";
            this.lblDropboxStatus.Size = new System.Drawing.Size(82, 16);
            this.lblDropboxStatus.TabIndex = 8;
            this.lblDropboxStatus.Text = "Login status:";
            // 
            // lblDropboxPathTip
            // 
            this.lblDropboxPathTip.AutoSize = true;
            this.lblDropboxPathTip.Location = new System.Drawing.Point(416, 126);
            this.lblDropboxPathTip.Name = "lblDropboxPathTip";
            this.lblDropboxPathTip.Size = new System.Drawing.Size(208, 13);
            this.lblDropboxPathTip.TabIndex = 6;
            this.lblDropboxPathTip.Text = "Use \"Public\" folder for be able to get URL.";
            // 
            // lblDropboxPath
            // 
            this.lblDropboxPath.AutoSize = true;
            this.lblDropboxPath.Location = new System.Drawing.Point(16, 126);
            this.lblDropboxPath.Name = "lblDropboxPath";
            this.lblDropboxPath.Size = new System.Drawing.Size(68, 13);
            this.lblDropboxPath.TabIndex = 3;
            this.lblDropboxPath.Text = "Upload path:";
            // 
            // btnDropboxOpenAuthorize
            // 
            this.btnDropboxOpenAuthorize.Location = new System.Drawing.Point(16, 88);
            this.btnDropboxOpenAuthorize.Name = "btnDropboxOpenAuthorize";
            this.btnDropboxOpenAuthorize.Size = new System.Drawing.Size(152, 24);
            this.btnDropboxOpenAuthorize.TabIndex = 1;
            this.btnDropboxOpenAuthorize.Text = "1. Open authorize page...";
            this.btnDropboxOpenAuthorize.UseVisualStyleBackColor = true;
            this.btnDropboxOpenAuthorize.Click += new System.EventHandler(this.btnDropboxAuthOpen_Click);
            // 
            // txtDropboxPath
            // 
            this.txtDropboxPath.Location = new System.Drawing.Point(88, 122);
            this.txtDropboxPath.Name = "txtDropboxPath";
            this.txtDropboxPath.Size = new System.Drawing.Size(248, 20);
            this.txtDropboxPath.TabIndex = 4;
            this.txtDropboxPath.TextChanged += new System.EventHandler(this.txtDropboxPath_TextChanged);
            // 
            // tpBox
            // 
            this.tpBox.Controls.Add(this.txtBoxFolderID);
            this.tpBox.Controls.Add(this.lblBoxFolderID);
            this.tpBox.Controls.Add(this.btnBoxRefreshFolders);
            this.tpBox.Controls.Add(this.tvBoxFolders);
            this.tpBox.Controls.Add(this.btnBoxCompleteAuth);
            this.tpBox.Controls.Add(this.btnBoxOpenAuthorize);
            this.tpBox.Location = new System.Drawing.Point(4, 22);
            this.tpBox.Name = "tpBox";
            this.tpBox.Padding = new System.Windows.Forms.Padding(3);
            this.tpBox.Size = new System.Drawing.Size(804, 474);
            this.tpBox.TabIndex = 6;
            this.tpBox.Text = "Box";
            this.tpBox.UseVisualStyleBackColor = true;
            // 
            // txtBoxFolderID
            // 
            this.txtBoxFolderID.Location = new System.Drawing.Point(128, 52);
            this.txtBoxFolderID.Name = "txtBoxFolderID";
            this.txtBoxFolderID.Size = new System.Drawing.Size(88, 20);
            this.txtBoxFolderID.TabIndex = 12;
            this.txtBoxFolderID.TextChanged += new System.EventHandler(this.txtBoxFolderID_TextChanged);
            // 
            // lblBoxFolderID
            // 
            this.lblBoxFolderID.AutoSize = true;
            this.lblBoxFolderID.Location = new System.Drawing.Point(16, 56);
            this.lblBoxFolderID.Name = "lblBoxFolderID";
            this.lblBoxFolderID.Size = new System.Drawing.Size(103, 13);
            this.lblBoxFolderID.TabIndex = 11;
            this.lblBoxFolderID.Text = "Folder ID for upload:";
            // 
            // btnBoxRefreshFolders
            // 
            this.btnBoxRefreshFolders.Location = new System.Drawing.Point(16, 80);
            this.btnBoxRefreshFolders.Name = "btnBoxRefreshFolders";
            this.btnBoxRefreshFolders.Size = new System.Drawing.Size(128, 23);
            this.btnBoxRefreshFolders.TabIndex = 10;
            this.btnBoxRefreshFolders.Text = "Refresh folders list";
            this.btnBoxRefreshFolders.UseVisualStyleBackColor = true;
            this.btnBoxRefreshFolders.Click += new System.EventHandler(this.btnBoxRefreshFolders_Click);
            // 
            // tvBoxFolders
            // 
            this.tvBoxFolders.Location = new System.Drawing.Point(16, 112);
            this.tvBoxFolders.Name = "tvBoxFolders";
            this.tvBoxFolders.Size = new System.Drawing.Size(440, 312);
            this.tvBoxFolders.TabIndex = 9;
            this.tvBoxFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBoxFolders_AfterSelect);
            // 
            // btnBoxCompleteAuth
            // 
            this.btnBoxCompleteAuth.Enabled = false;
            this.btnBoxCompleteAuth.Location = new System.Drawing.Point(192, 16);
            this.btnBoxCompleteAuth.Name = "btnBoxCompleteAuth";
            this.btnBoxCompleteAuth.Size = new System.Drawing.Size(168, 23);
            this.btnBoxCompleteAuth.TabIndex = 1;
            this.btnBoxCompleteAuth.Text = "2. Complete authorization";
            this.btnBoxCompleteAuth.UseVisualStyleBackColor = true;
            this.btnBoxCompleteAuth.Click += new System.EventHandler(this.btnBoxCompleteAuth_Click);
            // 
            // btnBoxOpenAuthorize
            // 
            this.btnBoxOpenAuthorize.Location = new System.Drawing.Point(16, 16);
            this.btnBoxOpenAuthorize.Name = "btnBoxOpenAuthorize";
            this.btnBoxOpenAuthorize.Size = new System.Drawing.Size(168, 23);
            this.btnBoxOpenAuthorize.TabIndex = 0;
            this.btnBoxOpenAuthorize.Text = "1. Open authorize page...";
            this.btnBoxOpenAuthorize.UseVisualStyleBackColor = true;
            this.btnBoxOpenAuthorize.Click += new System.EventHandler(this.btnBoxOpenAuthorize_Click);
            // 
            // tpMinus
            // 
            this.tpMinus.Controls.Add(this.gbMinusUserPass);
            this.tpMinus.Controls.Add(this.gbMinusUpload);
            this.tpMinus.Controls.Add(this.lblMinusAuthStatus);
            this.tpMinus.Location = new System.Drawing.Point(4, 22);
            this.tpMinus.Name = "tpMinus";
            this.tpMinus.Padding = new System.Windows.Forms.Padding(3);
            this.tpMinus.Size = new System.Drawing.Size(804, 474);
            this.tpMinus.TabIndex = 1;
            this.tpMinus.Text = "Minus";
            this.tpMinus.UseVisualStyleBackColor = true;
            // 
            // gbMinusUserPass
            // 
            this.gbMinusUserPass.Controls.Add(this.btnAuthRefresh);
            this.gbMinusUserPass.Controls.Add(this.label7);
            this.gbMinusUserPass.Controls.Add(this.label9);
            this.gbMinusUserPass.Controls.Add(this.txtMinusPassword);
            this.gbMinusUserPass.Controls.Add(this.txtMinusUsername);
            this.gbMinusUserPass.Controls.Add(this.btnMinusAuth);
            this.gbMinusUserPass.Location = new System.Drawing.Point(16, 16);
            this.gbMinusUserPass.Name = "gbMinusUserPass";
            this.gbMinusUserPass.Size = new System.Drawing.Size(712, 96);
            this.gbMinusUserPass.TabIndex = 0;
            this.gbMinusUserPass.TabStop = false;
            this.gbMinusUserPass.Text = "Authentication";
            // 
            // btnAuthRefresh
            // 
            this.btnAuthRefresh.Location = new System.Drawing.Point(528, 48);
            this.btnAuthRefresh.Name = "btnAuthRefresh";
            this.btnAuthRefresh.Size = new System.Drawing.Size(144, 24);
            this.btnAuthRefresh.TabIndex = 4;
            this.btnAuthRefresh.Text = "Refresh Authorization";
            this.btnAuthRefresh.UseVisualStyleBackColor = true;
            this.btnAuthRefresh.Click += new System.EventHandler(this.btnAuthRefresh_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Username:";
            // 
            // txtMinusPassword
            // 
            this.txtMinusPassword.Location = new System.Drawing.Point(72, 56);
            this.txtMinusPassword.Name = "txtMinusPassword";
            this.txtMinusPassword.PasswordChar = '*';
            this.txtMinusPassword.Size = new System.Drawing.Size(136, 20);
            this.txtMinusPassword.TabIndex = 5;
            // 
            // txtMinusUsername
            // 
            this.txtMinusUsername.Location = new System.Drawing.Point(72, 24);
            this.txtMinusUsername.Name = "txtMinusUsername";
            this.txtMinusUsername.Size = new System.Drawing.Size(136, 20);
            this.txtMinusUsername.TabIndex = 2;
            // 
            // btnMinusAuth
            // 
            this.btnMinusAuth.Location = new System.Drawing.Point(528, 16);
            this.btnMinusAuth.Name = "btnMinusAuth";
            this.btnMinusAuth.Size = new System.Drawing.Size(144, 24);
            this.btnMinusAuth.TabIndex = 1;
            this.btnMinusAuth.Text = "Authorize";
            this.btnMinusAuth.UseVisualStyleBackColor = true;
            this.btnMinusAuth.Click += new System.EventHandler(this.btnMinusAuth_Click);
            // 
            // gbMinusUpload
            // 
            this.gbMinusUpload.Controls.Add(this.btnMinusReadFolderList);
            this.gbMinusUpload.Controls.Add(this.chkMinusPublic);
            this.gbMinusUpload.Controls.Add(this.btnMinusFolderAdd);
            this.gbMinusUpload.Controls.Add(this.btnMinusFolderRemove);
            this.gbMinusUpload.Controls.Add(this.cboMinusFolders);
            this.gbMinusUpload.Location = new System.Drawing.Point(16, 128);
            this.gbMinusUpload.Name = "gbMinusUpload";
            this.gbMinusUpload.Size = new System.Drawing.Size(712, 96);
            this.gbMinusUpload.TabIndex = 1;
            this.gbMinusUpload.TabStop = false;
            this.gbMinusUpload.Text = "Upload images to";
            // 
            // btnMinusReadFolderList
            // 
            this.btnMinusReadFolderList.AutoSize = true;
            this.btnMinusReadFolderList.Location = new System.Drawing.Point(488, 56);
            this.btnMinusReadFolderList.Name = "btnMinusReadFolderList";
            this.btnMinusReadFolderList.Size = new System.Drawing.Size(184, 23);
            this.btnMinusReadFolderList.TabIndex = 4;
            this.btnMinusReadFolderList.Text = "Reload folder list";
            this.btnMinusReadFolderList.UseVisualStyleBackColor = true;
            this.btnMinusReadFolderList.Click += new System.EventHandler(this.btnMinusReadFolderList_Click);
            // 
            // chkMinusPublic
            // 
            this.chkMinusPublic.AutoSize = true;
            this.chkMinusPublic.Location = new System.Drawing.Point(416, 24);
            this.chkMinusPublic.Name = "chkMinusPublic";
            this.chkMinusPublic.Size = new System.Drawing.Size(55, 17);
            this.chkMinusPublic.TabIndex = 1;
            this.chkMinusPublic.Text = "Public";
            this.chkMinusPublic.UseVisualStyleBackColor = true;
            // 
            // btnMinusFolderAdd
            // 
            this.btnMinusFolderAdd.Location = new System.Drawing.Point(488, 24);
            this.btnMinusFolderAdd.Name = "btnMinusFolderAdd";
            this.btnMinusFolderAdd.Size = new System.Drawing.Size(75, 23);
            this.btnMinusFolderAdd.TabIndex = 2;
            this.btnMinusFolderAdd.Text = "Add folder";
            this.btnMinusFolderAdd.UseVisualStyleBackColor = true;
            this.btnMinusFolderAdd.Click += new System.EventHandler(this.btnMinusFolderAdd_Click);
            // 
            // btnMinusFolderRemove
            // 
            this.btnMinusFolderRemove.AutoSize = true;
            this.btnMinusFolderRemove.Location = new System.Drawing.Point(568, 24);
            this.btnMinusFolderRemove.Name = "btnMinusFolderRemove";
            this.btnMinusFolderRemove.Size = new System.Drawing.Size(104, 23);
            this.btnMinusFolderRemove.TabIndex = 3;
            this.btnMinusFolderRemove.Text = "Remove folder";
            this.btnMinusFolderRemove.UseVisualStyleBackColor = true;
            this.btnMinusFolderRemove.Click += new System.EventHandler(this.btnMinusFolderRemove_Click);
            // 
            // cboMinusFolders
            // 
            this.cboMinusFolders.FormattingEnabled = true;
            this.cboMinusFolders.Location = new System.Drawing.Point(16, 24);
            this.cboMinusFolders.Name = "cboMinusFolders";
            this.cboMinusFolders.Size = new System.Drawing.Size(392, 21);
            this.cboMinusFolders.TabIndex = 0;
            this.cboMinusFolders.SelectedIndexChanged += new System.EventHandler(this.cboMinusFolders_SelectedIndexChanged);
            // 
            // lblMinusAuthStatus
            // 
            this.lblMinusAuthStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMinusAuthStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinusAuthStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMinusAuthStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMinusAuthStatus.Location = new System.Drawing.Point(3, 452);
            this.lblMinusAuthStatus.Name = "lblMinusAuthStatus";
            this.lblMinusAuthStatus.Size = new System.Drawing.Size(798, 19);
            this.lblMinusAuthStatus.TabIndex = 2;
            this.lblMinusAuthStatus.Text = "Login status:";
            // 
            // tpFTP
            // 
            this.tpFTP.Controls.Add(this.tlpFtp);
            this.tpFTP.Location = new System.Drawing.Point(4, 22);
            this.tpFTP.Name = "tpFTP";
            this.tpFTP.Padding = new System.Windows.Forms.Padding(3);
            this.tpFTP.Size = new System.Drawing.Size(804, 474);
            this.tpFTP.TabIndex = 2;
            this.tpFTP.Text = "FTP";
            this.tpFTP.UseVisualStyleBackColor = true;
            // 
            // tlpFtp
            // 
            this.tlpFtp.ColumnCount = 1;
            this.tlpFtp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFtp.Controls.Add(this.panelFtp, 0, 0);
            this.tlpFtp.Controls.Add(this.gbFtpSettings, 0, 1);
            this.tlpFtp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFtp.Location = new System.Drawing.Point(3, 3);
            this.tlpFtp.Name = "tlpFtp";
            this.tlpFtp.RowCount = 2;
            this.tlpFtp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpFtp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpFtp.Size = new System.Drawing.Size(798, 468);
            this.tlpFtp.TabIndex = 0;
            // 
            // panelFtp
            // 
            this.panelFtp.Controls.Add(this.btnFTPExport);
            this.panelFtp.Controls.Add(this.btnFTPImport);
            this.panelFtp.Controls.Add(this.btnFtpHelp);
            this.panelFtp.Controls.Add(this.ucFTPAccounts);
            this.panelFtp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFtp.Location = new System.Drawing.Point(3, 3);
            this.panelFtp.Name = "panelFtp";
            this.panelFtp.Size = new System.Drawing.Size(792, 345);
            this.panelFtp.TabIndex = 0;
            // 
            // btnFTPExport
            // 
            this.btnFTPExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFTPExport.AutoSize = true;
            this.btnFTPExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFTPExport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFTPExport.Location = new System.Drawing.Point(650, 8);
            this.btnFTPExport.Name = "btnFTPExport";
            this.btnFTPExport.Size = new System.Drawing.Size(127, 23);
            this.btnFTPExport.TabIndex = 3;
            this.btnFTPExport.Text = "Export FTP Accounts...";
            this.btnFTPExport.UseVisualStyleBackColor = true;
            this.btnFTPExport.Click += new System.EventHandler(this.btnFTPExport_Click);
            // 
            // btnFTPImport
            // 
            this.btnFTPImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFTPImport.AutoSize = true;
            this.btnFTPImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFTPImport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFTPImport.Location = new System.Drawing.Point(514, 8);
            this.btnFTPImport.Name = "btnFTPImport";
            this.btnFTPImport.Size = new System.Drawing.Size(126, 23);
            this.btnFTPImport.TabIndex = 2;
            this.btnFTPImport.Text = "Import FTP Accounts...";
            this.btnFTPImport.UseVisualStyleBackColor = true;
            this.btnFTPImport.Click += new System.EventHandler(this.btnFTPImport_Click);
            // 
            // btnFtpHelp
            // 
            this.btnFtpHelp.Location = new System.Drawing.Point(304, 8);
            this.btnFtpHelp.Name = "btnFtpHelp";
            this.btnFtpHelp.Size = new System.Drawing.Size(64, 24);
            this.btnFtpHelp.TabIndex = 1;
            this.btnFtpHelp.Text = "&Help...";
            this.btnFtpHelp.UseVisualStyleBackColor = true;
            this.btnFtpHelp.Click += new System.EventHandler(this.btnFtpHelp_Click);
            // 
            // ucFTPAccounts
            // 
            this.ucFTPAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFTPAccounts.Location = new System.Drawing.Point(0, 0);
            this.ucFTPAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.ucFTPAccounts.Name = "ucFTPAccounts";
            this.ucFTPAccounts.Size = new System.Drawing.Size(792, 345);
            this.ucFTPAccounts.TabIndex = 0;
            // 
            // gbFtpSettings
            // 
            this.gbFtpSettings.Controls.Add(this.label1);
            this.gbFtpSettings.Controls.Add(this.label2);
            this.gbFtpSettings.Controls.Add(this.label3);
            this.gbFtpSettings.Controls.Add(this.cboFtpFiles);
            this.gbFtpSettings.Controls.Add(this.cboFtpText);
            this.gbFtpSettings.Controls.Add(this.cboFtpImages);
            this.gbFtpSettings.Controls.Add(this.chkFTPThumbnailCheckSize);
            this.gbFtpSettings.Controls.Add(this.label4);
            this.gbFtpSettings.Controls.Add(this.txtFTPThumbWidth);
            this.gbFtpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFtpSettings.Location = new System.Drawing.Point(3, 354);
            this.gbFtpSettings.Name = "gbFtpSettings";
            this.gbFtpSettings.Size = new System.Drawing.Size(792, 111);
            this.gbFtpSettings.TabIndex = 1;
            this.gbFtpSettings.TabStop = false;
            this.gbFtpSettings.Text = "FTP Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Images";
            // 
            // cboFtpFiles
            // 
            this.cboFtpFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFtpFiles.FormattingEnabled = true;
            this.cboFtpFiles.Location = new System.Drawing.Point(472, 64);
            this.cboFtpFiles.Name = "cboFtpFiles";
            this.cboFtpFiles.Size = new System.Drawing.Size(272, 21);
            this.cboFtpFiles.TabIndex = 8;
            this.cboFtpFiles.SelectedIndexChanged += new System.EventHandler(this.cboFtpFiles_SelectedIndexChanged);
            // 
            // cboFtpText
            // 
            this.cboFtpText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFtpText.FormattingEnabled = true;
            this.cboFtpText.Location = new System.Drawing.Point(472, 40);
            this.cboFtpText.Name = "cboFtpText";
            this.cboFtpText.Size = new System.Drawing.Size(272, 21);
            this.cboFtpText.TabIndex = 5;
            this.cboFtpText.SelectedIndexChanged += new System.EventHandler(this.cboFtpText_SelectedIndexChanged);
            // 
            // cboFtpImages
            // 
            this.cboFtpImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFtpImages.FormattingEnabled = true;
            this.cboFtpImages.Location = new System.Drawing.Point(472, 16);
            this.cboFtpImages.Name = "cboFtpImages";
            this.cboFtpImages.Size = new System.Drawing.Size(272, 21);
            this.cboFtpImages.TabIndex = 1;
            this.cboFtpImages.SelectedIndexChanged += new System.EventHandler(this.cboFtpImages_SelectedIndexChanged);
            // 
            // chkFTPThumbnailCheckSize
            // 
            this.chkFTPThumbnailCheckSize.AutoSize = true;
            this.chkFTPThumbnailCheckSize.Location = new System.Drawing.Point(16, 48);
            this.chkFTPThumbnailCheckSize.Name = "chkFTPThumbnailCheckSize";
            this.chkFTPThumbnailCheckSize.Size = new System.Drawing.Size(331, 17);
            this.chkFTPThumbnailCheckSize.TabIndex = 6;
            this.chkFTPThumbnailCheckSize.Text = "If image size smaller than thumbnail size then not make thumbnail";
            this.chkFTPThumbnailCheckSize.UseVisualStyleBackColor = true;
            this.chkFTPThumbnailCheckSize.CheckedChanged += new System.EventHandler(this.chkFTPThumbnailCheckSize_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thumbnail width (px):";
            // 
            // txtFTPThumbWidth
            // 
            this.txtFTPThumbWidth.Location = new System.Drawing.Point(128, 22);
            this.txtFTPThumbWidth.Name = "txtFTPThumbWidth";
            this.txtFTPThumbWidth.Size = new System.Drawing.Size(40, 20);
            this.txtFTPThumbWidth.TabIndex = 3;
            this.txtFTPThumbWidth.Text = "2500";
            this.txtFTPThumbWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFTPThumbWidth.TextChanged += new System.EventHandler(this.txtFTPThumbWidth_TextChanged);
            // 
            // tpRapidShare
            // 
            this.tpRapidShare.Controls.Add(this.txtRapidShareFolderID);
            this.tpRapidShare.Controls.Add(this.lblRapidShareFolderID);
            this.tpRapidShare.Controls.Add(this.btnRapidShareRefreshFolders);
            this.tpRapidShare.Controls.Add(this.tvRapidShareFolders);
            this.tpRapidShare.Controls.Add(this.lblRapidSharePassword);
            this.tpRapidShare.Controls.Add(this.lblRapidSharePremiumUsername);
            this.tpRapidShare.Controls.Add(this.txtRapidSharePassword);
            this.tpRapidShare.Controls.Add(this.txtRapidShareUsername);
            this.tpRapidShare.Location = new System.Drawing.Point(4, 22);
            this.tpRapidShare.Name = "tpRapidShare";
            this.tpRapidShare.Padding = new System.Windows.Forms.Padding(3);
            this.tpRapidShare.Size = new System.Drawing.Size(804, 474);
            this.tpRapidShare.TabIndex = 3;
            this.tpRapidShare.Text = "RapidShare";
            this.tpRapidShare.UseVisualStyleBackColor = true;
            // 
            // txtRapidShareFolderID
            // 
            this.txtRapidShareFolderID.Location = new System.Drawing.Point(128, 84);
            this.txtRapidShareFolderID.Name = "txtRapidShareFolderID";
            this.txtRapidShareFolderID.Size = new System.Drawing.Size(88, 20);
            this.txtRapidShareFolderID.TabIndex = 8;
            this.txtRapidShareFolderID.TextChanged += new System.EventHandler(this.txtRapidShareFolderID_TextChanged);
            // 
            // lblRapidShareFolderID
            // 
            this.lblRapidShareFolderID.AutoSize = true;
            this.lblRapidShareFolderID.Location = new System.Drawing.Point(16, 88);
            this.lblRapidShareFolderID.Name = "lblRapidShareFolderID";
            this.lblRapidShareFolderID.Size = new System.Drawing.Size(103, 13);
            this.lblRapidShareFolderID.TabIndex = 7;
            this.lblRapidShareFolderID.Text = "Folder ID for upload:";
            // 
            // btnRapidShareRefreshFolders
            // 
            this.btnRapidShareRefreshFolders.Location = new System.Drawing.Point(16, 112);
            this.btnRapidShareRefreshFolders.Name = "btnRapidShareRefreshFolders";
            this.btnRapidShareRefreshFolders.Size = new System.Drawing.Size(128, 23);
            this.btnRapidShareRefreshFolders.TabIndex = 6;
            this.btnRapidShareRefreshFolders.Text = "Refresh folders list";
            this.btnRapidShareRefreshFolders.UseVisualStyleBackColor = true;
            this.btnRapidShareRefreshFolders.Click += new System.EventHandler(this.btnRapidShareRefreshFolders_Click);
            // 
            // tvRapidShareFolders
            // 
            this.tvRapidShareFolders.Location = new System.Drawing.Point(16, 144);
            this.tvRapidShareFolders.Name = "tvRapidShareFolders";
            this.tvRapidShareFolders.Size = new System.Drawing.Size(440, 312);
            this.tvRapidShareFolders.TabIndex = 5;
            this.tvRapidShareFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRapidShareFolders_AfterSelect);
            // 
            // lblRapidSharePassword
            // 
            this.lblRapidSharePassword.AutoSize = true;
            this.lblRapidSharePassword.Location = new System.Drawing.Point(16, 56);
            this.lblRapidSharePassword.Name = "lblRapidSharePassword";
            this.lblRapidSharePassword.Size = new System.Drawing.Size(56, 13);
            this.lblRapidSharePassword.TabIndex = 3;
            this.lblRapidSharePassword.Text = "Password:";
            // 
            // lblRapidSharePremiumUsername
            // 
            this.lblRapidSharePremiumUsername.AutoSize = true;
            this.lblRapidSharePremiumUsername.Location = new System.Drawing.Point(16, 24);
            this.lblRapidSharePremiumUsername.Name = "lblRapidSharePremiumUsername";
            this.lblRapidSharePremiumUsername.Size = new System.Drawing.Size(58, 13);
            this.lblRapidSharePremiumUsername.TabIndex = 1;
            this.lblRapidSharePremiumUsername.Text = "Username:";
            // 
            // txtRapidSharePassword
            // 
            this.txtRapidSharePassword.Location = new System.Drawing.Point(80, 52);
            this.txtRapidSharePassword.Name = "txtRapidSharePassword";
            this.txtRapidSharePassword.PasswordChar = '*';
            this.txtRapidSharePassword.Size = new System.Drawing.Size(136, 20);
            this.txtRapidSharePassword.TabIndex = 4;
            this.txtRapidSharePassword.TextChanged += new System.EventHandler(this.txtRapidSharePassword_TextChanged);
            // 
            // txtRapidShareUsername
            // 
            this.txtRapidShareUsername.Location = new System.Drawing.Point(80, 20);
            this.txtRapidShareUsername.Name = "txtRapidShareUsername";
            this.txtRapidShareUsername.Size = new System.Drawing.Size(136, 20);
            this.txtRapidShareUsername.TabIndex = 2;
            this.txtRapidShareUsername.TextChanged += new System.EventHandler(this.txtRapidShareUsername_TextChanged);
            // 
            // tpSendSpace
            // 
            this.tpSendSpace.Controls.Add(this.btnSendSpaceRegister);
            this.tpSendSpace.Controls.Add(this.lblSendSpacePassword);
            this.tpSendSpace.Controls.Add(this.lblSendSpaceUsername);
            this.tpSendSpace.Controls.Add(this.txtSendSpacePassword);
            this.tpSendSpace.Controls.Add(this.txtSendSpaceUserName);
            this.tpSendSpace.Controls.Add(this.atcSendSpaceAccountType);
            this.tpSendSpace.Location = new System.Drawing.Point(4, 22);
            this.tpSendSpace.Name = "tpSendSpace";
            this.tpSendSpace.Padding = new System.Windows.Forms.Padding(3);
            this.tpSendSpace.Size = new System.Drawing.Size(804, 474);
            this.tpSendSpace.TabIndex = 4;
            this.tpSendSpace.Text = "SendSpace";
            this.tpSendSpace.UseVisualStyleBackColor = true;
            // 
            // btnSendSpaceRegister
            // 
            this.btnSendSpaceRegister.Location = new System.Drawing.Point(232, 19);
            this.btnSendSpaceRegister.Name = "btnSendSpaceRegister";
            this.btnSendSpaceRegister.Size = new System.Drawing.Size(75, 23);
            this.btnSendSpaceRegister.TabIndex = 1;
            this.btnSendSpaceRegister.Text = "&Register...";
            this.btnSendSpaceRegister.UseVisualStyleBackColor = true;
            this.btnSendSpaceRegister.Click += new System.EventHandler(this.btnSendSpaceRegister_Click);
            // 
            // lblSendSpacePassword
            // 
            this.lblSendSpacePassword.AutoSize = true;
            this.lblSendSpacePassword.Location = new System.Drawing.Point(16, 88);
            this.lblSendSpacePassword.Name = "lblSendSpacePassword";
            this.lblSendSpacePassword.Size = new System.Drawing.Size(53, 13);
            this.lblSendSpacePassword.TabIndex = 4;
            this.lblSendSpacePassword.Text = "Password";
            // 
            // lblSendSpaceUsername
            // 
            this.lblSendSpaceUsername.AutoSize = true;
            this.lblSendSpaceUsername.Location = new System.Drawing.Point(16, 56);
            this.lblSendSpaceUsername.Name = "lblSendSpaceUsername";
            this.lblSendSpaceUsername.Size = new System.Drawing.Size(55, 13);
            this.lblSendSpaceUsername.TabIndex = 2;
            this.lblSendSpaceUsername.Text = "Username";
            // 
            // txtSendSpacePassword
            // 
            this.txtSendSpacePassword.Location = new System.Drawing.Point(80, 84);
            this.txtSendSpacePassword.Name = "txtSendSpacePassword";
            this.txtSendSpacePassword.PasswordChar = '*';
            this.txtSendSpacePassword.Size = new System.Drawing.Size(136, 20);
            this.txtSendSpacePassword.TabIndex = 5;
            this.txtSendSpacePassword.TextChanged += new System.EventHandler(this.txtSendSpacePassword_TextChanged);
            // 
            // txtSendSpaceUserName
            // 
            this.txtSendSpaceUserName.Location = new System.Drawing.Point(80, 52);
            this.txtSendSpaceUserName.Name = "txtSendSpaceUserName";
            this.txtSendSpaceUserName.Size = new System.Drawing.Size(136, 20);
            this.txtSendSpaceUserName.TabIndex = 3;
            this.txtSendSpaceUserName.TextChanged += new System.EventHandler(this.txtSendSpaceUserName_TextChanged);
            // 
            // atcSendSpaceAccountType
            // 
            this.atcSendSpaceAccountType.Location = new System.Drawing.Point(8, 16);
            this.atcSendSpaceAccountType.Name = "atcSendSpaceAccountType";
            this.atcSendSpaceAccountType.SelectedAccountType = UploadersLib.AccountType.Anonymous;
            this.atcSendSpaceAccountType.Size = new System.Drawing.Size(214, 29);
            this.atcSendSpaceAccountType.TabIndex = 0;
            this.atcSendSpaceAccountType.AccountTypeChanged += new UploadersLib.GUI.AccountTypeControl.AccountTypeChangedEventHandler(this.atcSendSpaceAccountType_AccountTypeChanged);
            // 
            // tpCustomUploaders
            // 
            this.tpCustomUploaders.Controls.Add(this.txtCustomUploaderLog);
            this.tpCustomUploaders.Controls.Add(this.btnCustomUploaderTest);
            this.tpCustomUploaders.Controls.Add(this.txtCustomUploaderFullImage);
            this.tpCustomUploaders.Controls.Add(this.txtCustomUploaderThumbnail);
            this.tpCustomUploaders.Controls.Add(this.lblCustomUploaderFullImage);
            this.tpCustomUploaders.Controls.Add(this.lblCustomUploaderThumbnail);
            this.tpCustomUploaders.Controls.Add(this.gbCustomUploaders);
            this.tpCustomUploaders.Controls.Add(this.gbCustomUploaderRegexp);
            this.tpCustomUploaders.Controls.Add(this.txtCustomUploaderFileForm);
            this.tpCustomUploaders.Controls.Add(this.lblCustomUploaderFileForm);
            this.tpCustomUploaders.Controls.Add(this.lblCustomUploaderUploadURL);
            this.tpCustomUploaders.Controls.Add(this.txtCustomUploaderURL);
            this.tpCustomUploaders.Controls.Add(this.gbCustomUploaderArguments);
            this.tpCustomUploaders.Location = new System.Drawing.Point(4, 22);
            this.tpCustomUploaders.Name = "tpCustomUploaders";
            this.tpCustomUploaders.Padding = new System.Windows.Forms.Padding(3);
            this.tpCustomUploaders.Size = new System.Drawing.Size(804, 474);
            this.tpCustomUploaders.TabIndex = 5;
            this.tpCustomUploaders.Text = "Custom uploader";
            this.tpCustomUploaders.UseVisualStyleBackColor = true;
            // 
            // txtCustomUploaderLog
            // 
            this.txtCustomUploaderLog.Location = new System.Drawing.Point(8, 280);
            this.txtCustomUploaderLog.Name = "txtCustomUploaderLog";
            this.txtCustomUploaderLog.Size = new System.Drawing.Size(424, 104);
            this.txtCustomUploaderLog.TabIndex = 7;
            this.txtCustomUploaderLog.Text = "";
            this.txtCustomUploaderLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtCustomUploaderLog_LinkClicked);
            // 
            // btnCustomUploaderTest
            // 
            this.btnCustomUploaderTest.Location = new System.Drawing.Point(448, 360);
            this.btnCustomUploaderTest.Name = "btnCustomUploaderTest";
            this.btnCustomUploaderTest.Size = new System.Drawing.Size(312, 24);
            this.btnCustomUploaderTest.TabIndex = 12;
            this.btnCustomUploaderTest.Text = "Test Upload";
            this.btnCustomUploaderTest.UseVisualStyleBackColor = true;
            this.btnCustomUploaderTest.Click += new System.EventHandler(this.btnCustomUploaderTest_Click);
            // 
            // txtCustomUploaderFullImage
            // 
            this.txtCustomUploaderFullImage.Location = new System.Drawing.Point(448, 296);
            this.txtCustomUploaderFullImage.Name = "txtCustomUploaderFullImage";
            this.txtCustomUploaderFullImage.Size = new System.Drawing.Size(312, 20);
            this.txtCustomUploaderFullImage.TabIndex = 9;
            // 
            // txtCustomUploaderThumbnail
            // 
            this.txtCustomUploaderThumbnail.Location = new System.Drawing.Point(448, 336);
            this.txtCustomUploaderThumbnail.Name = "txtCustomUploaderThumbnail";
            this.txtCustomUploaderThumbnail.Size = new System.Drawing.Size(312, 20);
            this.txtCustomUploaderThumbnail.TabIndex = 11;
            // 
            // lblCustomUploaderFullImage
            // 
            this.lblCustomUploaderFullImage.AutoSize = true;
            this.lblCustomUploaderFullImage.Location = new System.Drawing.Point(448, 280);
            this.lblCustomUploaderFullImage.Name = "lblCustomUploaderFullImage";
            this.lblCustomUploaderFullImage.Size = new System.Drawing.Size(55, 13);
            this.lblCustomUploaderFullImage.TabIndex = 8;
            this.lblCustomUploaderFullImage.Text = "Full Image";
            // 
            // lblCustomUploaderThumbnail
            // 
            this.lblCustomUploaderThumbnail.AutoSize = true;
            this.lblCustomUploaderThumbnail.Location = new System.Drawing.Point(448, 320);
            this.lblCustomUploaderThumbnail.Name = "lblCustomUploaderThumbnail";
            this.lblCustomUploaderThumbnail.Size = new System.Drawing.Size(56, 13);
            this.lblCustomUploaderThumbnail.TabIndex = 10;
            this.lblCustomUploaderThumbnail.Text = "Thumbnail";
            // 
            // gbCustomUploaders
            // 
            this.gbCustomUploaders.Controls.Add(this.lbCustomUploaderList);
            this.gbCustomUploaders.Controls.Add(this.btnCustomUploaderClear);
            this.gbCustomUploaders.Controls.Add(this.btnCustomUploaderExport);
            this.gbCustomUploaders.Controls.Add(this.btnCustomUploaderRemove);
            this.gbCustomUploaders.Controls.Add(this.btnCustomUploaderImport);
            this.gbCustomUploaders.Controls.Add(this.btnCustomUploaderUpdate);
            this.gbCustomUploaders.Controls.Add(this.txtCustomUploaderName);
            this.gbCustomUploaders.Controls.Add(this.btnCustomUploaderAdd);
            this.gbCustomUploaders.Location = new System.Drawing.Point(8, 8);
            this.gbCustomUploaders.Name = "gbCustomUploaders";
            this.gbCustomUploaders.Size = new System.Drawing.Size(248, 264);
            this.gbCustomUploaders.TabIndex = 0;
            this.gbCustomUploaders.TabStop = false;
            this.gbCustomUploaders.Text = "Image Hosting Services";
            // 
            // lbCustomUploaderList
            // 
            this.lbCustomUploaderList.FormattingEnabled = true;
            this.lbCustomUploaderList.IntegralHeight = false;
            this.lbCustomUploaderList.Location = new System.Drawing.Point(8, 72);
            this.lbCustomUploaderList.Name = "lbCustomUploaderList";
            this.lbCustomUploaderList.Size = new System.Drawing.Size(232, 152);
            this.lbCustomUploaderList.TabIndex = 4;
            this.lbCustomUploaderList.SelectedIndexChanged += new System.EventHandler(this.lbCustomUploaderList_SelectedIndexChanged);
            // 
            // btnCustomUploaderClear
            // 
            this.btnCustomUploaderClear.Location = new System.Drawing.Point(168, 232);
            this.btnCustomUploaderClear.Name = "btnCustomUploaderClear";
            this.btnCustomUploaderClear.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderClear.TabIndex = 7;
            this.btnCustomUploaderClear.Text = "Clear";
            this.btnCustomUploaderClear.UseVisualStyleBackColor = true;
            this.btnCustomUploaderClear.Click += new System.EventHandler(this.btnCustomUploaderClear_Click);
            // 
            // btnCustomUploaderExport
            // 
            this.btnCustomUploaderExport.Location = new System.Drawing.Point(88, 232);
            this.btnCustomUploaderExport.Name = "btnCustomUploaderExport";
            this.btnCustomUploaderExport.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderExport.TabIndex = 6;
            this.btnCustomUploaderExport.Text = "Export...";
            this.btnCustomUploaderExport.UseVisualStyleBackColor = true;
            this.btnCustomUploaderExport.Click += new System.EventHandler(this.btnCustomUploaderExport_Click);
            // 
            // btnCustomUploaderRemove
            // 
            this.btnCustomUploaderRemove.Location = new System.Drawing.Point(88, 40);
            this.btnCustomUploaderRemove.Name = "btnCustomUploaderRemove";
            this.btnCustomUploaderRemove.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderRemove.TabIndex = 2;
            this.btnCustomUploaderRemove.Text = "Remove";
            this.btnCustomUploaderRemove.UseVisualStyleBackColor = true;
            this.btnCustomUploaderRemove.Click += new System.EventHandler(this.btnCustomUploaderRemove_Click);
            // 
            // btnCustomUploaderImport
            // 
            this.btnCustomUploaderImport.Location = new System.Drawing.Point(8, 232);
            this.btnCustomUploaderImport.Name = "btnCustomUploaderImport";
            this.btnCustomUploaderImport.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderImport.TabIndex = 5;
            this.btnCustomUploaderImport.Text = "Import...";
            this.btnCustomUploaderImport.UseVisualStyleBackColor = true;
            this.btnCustomUploaderImport.Click += new System.EventHandler(this.btnCustomUploaderImport_Click);
            // 
            // btnCustomUploaderUpdate
            // 
            this.btnCustomUploaderUpdate.Location = new System.Drawing.Point(168, 40);
            this.btnCustomUploaderUpdate.Name = "btnCustomUploaderUpdate";
            this.btnCustomUploaderUpdate.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderUpdate.TabIndex = 3;
            this.btnCustomUploaderUpdate.Text = "Update";
            this.btnCustomUploaderUpdate.UseVisualStyleBackColor = true;
            this.btnCustomUploaderUpdate.Click += new System.EventHandler(this.btnCustomUploaderUpdate_Click);
            // 
            // txtCustomUploaderName
            // 
            this.txtCustomUploaderName.Location = new System.Drawing.Point(8, 16);
            this.txtCustomUploaderName.Name = "txtCustomUploaderName";
            this.txtCustomUploaderName.Size = new System.Drawing.Size(232, 20);
            this.txtCustomUploaderName.TabIndex = 0;
            // 
            // btnCustomUploaderAdd
            // 
            this.btnCustomUploaderAdd.Location = new System.Drawing.Point(8, 40);
            this.btnCustomUploaderAdd.Name = "btnCustomUploaderAdd";
            this.btnCustomUploaderAdd.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderAdd.TabIndex = 1;
            this.btnCustomUploaderAdd.Text = "Add";
            this.btnCustomUploaderAdd.UseVisualStyleBackColor = true;
            this.btnCustomUploaderAdd.Click += new System.EventHandler(this.btnCustomUploaderAdd_Click);
            // 
            // gbCustomUploaderRegexp
            // 
            this.gbCustomUploaderRegexp.Controls.Add(this.btnCustomUploaderRegexpEdit);
            this.gbCustomUploaderRegexp.Controls.Add(this.txtCustomUploaderRegexp);
            this.gbCustomUploaderRegexp.Controls.Add(this.lvCustomUploaderRegexps);
            this.gbCustomUploaderRegexp.Controls.Add(this.btnCustomUploaderRegexpRemove);
            this.gbCustomUploaderRegexp.Controls.Add(this.btnCustomUploaderRegexpAdd);
            this.gbCustomUploaderRegexp.Location = new System.Drawing.Point(264, 88);
            this.gbCustomUploaderRegexp.Name = "gbCustomUploaderRegexp";
            this.gbCustomUploaderRegexp.Size = new System.Drawing.Size(240, 184);
            this.gbCustomUploaderRegexp.TabIndex = 5;
            this.gbCustomUploaderRegexp.TabStop = false;
            this.gbCustomUploaderRegexp.Text = "Regexp from Source";
            // 
            // btnCustomUploaderRegexpEdit
            // 
            this.btnCustomUploaderRegexpEdit.Location = new System.Drawing.Point(160, 40);
            this.btnCustomUploaderRegexpEdit.Name = "btnCustomUploaderRegexpEdit";
            this.btnCustomUploaderRegexpEdit.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderRegexpEdit.TabIndex = 3;
            this.btnCustomUploaderRegexpEdit.Text = "Edit";
            this.btnCustomUploaderRegexpEdit.UseVisualStyleBackColor = true;
            this.btnCustomUploaderRegexpEdit.Click += new System.EventHandler(this.btnCustomUploaderRegexpEdit_Click);
            // 
            // txtCustomUploaderRegexp
            // 
            this.txtCustomUploaderRegexp.Location = new System.Drawing.Point(8, 16);
            this.txtCustomUploaderRegexp.Name = "txtCustomUploaderRegexp";
            this.txtCustomUploaderRegexp.Size = new System.Drawing.Size(224, 20);
            this.txtCustomUploaderRegexp.TabIndex = 0;
            // 
            // lvCustomUploaderRegexps
            // 
            this.lvCustomUploaderRegexps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvRegexpsColumn});
            this.lvCustomUploaderRegexps.FullRowSelect = true;
            this.lvCustomUploaderRegexps.GridLines = true;
            this.lvCustomUploaderRegexps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvCustomUploaderRegexps.HideSelection = false;
            this.lvCustomUploaderRegexps.Location = new System.Drawing.Point(8, 72);
            this.lvCustomUploaderRegexps.MultiSelect = false;
            this.lvCustomUploaderRegexps.Name = "lvCustomUploaderRegexps";
            this.lvCustomUploaderRegexps.Scrollable = false;
            this.lvCustomUploaderRegexps.Size = new System.Drawing.Size(226, 104);
            this.lvCustomUploaderRegexps.TabIndex = 4;
            this.lvCustomUploaderRegexps.UseCompatibleStateImageBehavior = false;
            this.lvCustomUploaderRegexps.View = System.Windows.Forms.View.Details;
            this.lvCustomUploaderRegexps.SelectedIndexChanged += new System.EventHandler(this.lvCustomUploaderRegexps_SelectedIndexChanged);
            // 
            // lvRegexpsColumn
            // 
            this.lvRegexpsColumn.Width = 227;
            // 
            // btnCustomUploaderRegexpRemove
            // 
            this.btnCustomUploaderRegexpRemove.Location = new System.Drawing.Point(84, 40);
            this.btnCustomUploaderRegexpRemove.Name = "btnCustomUploaderRegexpRemove";
            this.btnCustomUploaderRegexpRemove.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderRegexpRemove.TabIndex = 2;
            this.btnCustomUploaderRegexpRemove.Text = "Remove";
            this.btnCustomUploaderRegexpRemove.UseVisualStyleBackColor = true;
            this.btnCustomUploaderRegexpRemove.Click += new System.EventHandler(this.btnCustomUploaderRegexpRemove_Click);
            // 
            // btnCustomUploaderRegexpAdd
            // 
            this.btnCustomUploaderRegexpAdd.Location = new System.Drawing.Point(8, 40);
            this.btnCustomUploaderRegexpAdd.Name = "btnCustomUploaderRegexpAdd";
            this.btnCustomUploaderRegexpAdd.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderRegexpAdd.TabIndex = 1;
            this.btnCustomUploaderRegexpAdd.Text = "Add";
            this.btnCustomUploaderRegexpAdd.UseVisualStyleBackColor = true;
            this.btnCustomUploaderRegexpAdd.Click += new System.EventHandler(this.btnCustomUploaderRegexpAdd_Click);
            // 
            // txtCustomUploaderFileForm
            // 
            this.txtCustomUploaderFileForm.Location = new System.Drawing.Point(272, 64);
            this.txtCustomUploaderFileForm.Name = "txtCustomUploaderFileForm";
            this.txtCustomUploaderFileForm.Size = new System.Drawing.Size(224, 20);
            this.txtCustomUploaderFileForm.TabIndex = 4;
            // 
            // lblCustomUploaderFileForm
            // 
            this.lblCustomUploaderFileForm.AutoSize = true;
            this.lblCustomUploaderFileForm.Location = new System.Drawing.Point(272, 48);
            this.lblCustomUploaderFileForm.Name = "lblCustomUploaderFileForm";
            this.lblCustomUploaderFileForm.Size = new System.Drawing.Size(83, 13);
            this.lblCustomUploaderFileForm.TabIndex = 3;
            this.lblCustomUploaderFileForm.Text = "File Form Name:";
            // 
            // lblCustomUploaderUploadURL
            // 
            this.lblCustomUploaderUploadURL.AutoSize = true;
            this.lblCustomUploaderUploadURL.Location = new System.Drawing.Point(272, 8);
            this.lblCustomUploaderUploadURL.Name = "lblCustomUploaderUploadURL";
            this.lblCustomUploaderUploadURL.Size = new System.Drawing.Size(69, 13);
            this.lblCustomUploaderUploadURL.TabIndex = 1;
            this.lblCustomUploaderUploadURL.Text = "Upload URL:";
            // 
            // txtCustomUploaderURL
            // 
            this.txtCustomUploaderURL.Location = new System.Drawing.Point(272, 24);
            this.txtCustomUploaderURL.Name = "txtCustomUploaderURL";
            this.txtCustomUploaderURL.Size = new System.Drawing.Size(224, 20);
            this.txtCustomUploaderURL.TabIndex = 2;
            // 
            // gbCustomUploaderArguments
            // 
            this.gbCustomUploaderArguments.Controls.Add(this.btnCustomUploaderArgEdit);
            this.gbCustomUploaderArguments.Controls.Add(this.txtCustomUploaderArgValue);
            this.gbCustomUploaderArguments.Controls.Add(this.btnCustomUploaderArgRemove);
            this.gbCustomUploaderArguments.Controls.Add(this.lvCustomUploaderArguments);
            this.gbCustomUploaderArguments.Controls.Add(this.btnCustomUploaderArgAdd);
            this.gbCustomUploaderArguments.Controls.Add(this.txtCustomUploaderArgName);
            this.gbCustomUploaderArguments.Location = new System.Drawing.Point(512, 8);
            this.gbCustomUploaderArguments.Name = "gbCustomUploaderArguments";
            this.gbCustomUploaderArguments.Size = new System.Drawing.Size(248, 264);
            this.gbCustomUploaderArguments.TabIndex = 6;
            this.gbCustomUploaderArguments.TabStop = false;
            this.gbCustomUploaderArguments.Text = "Arguments";
            // 
            // btnCustomUploaderArgEdit
            // 
            this.btnCustomUploaderArgEdit.Location = new System.Drawing.Point(168, 40);
            this.btnCustomUploaderArgEdit.Name = "btnCustomUploaderArgEdit";
            this.btnCustomUploaderArgEdit.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderArgEdit.TabIndex = 4;
            this.btnCustomUploaderArgEdit.Text = "Edit";
            this.btnCustomUploaderArgEdit.UseVisualStyleBackColor = true;
            this.btnCustomUploaderArgEdit.Click += new System.EventHandler(this.btnCustomUploaderArgEdit_Click);
            // 
            // txtCustomUploaderArgValue
            // 
            this.txtCustomUploaderArgValue.Location = new System.Drawing.Point(128, 16);
            this.txtCustomUploaderArgValue.Name = "txtCustomUploaderArgValue";
            this.txtCustomUploaderArgValue.Size = new System.Drawing.Size(112, 20);
            this.txtCustomUploaderArgValue.TabIndex = 1;
            // 
            // btnCustomUploaderArgRemove
            // 
            this.btnCustomUploaderArgRemove.Location = new System.Drawing.Point(88, 40);
            this.btnCustomUploaderArgRemove.Name = "btnCustomUploaderArgRemove";
            this.btnCustomUploaderArgRemove.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderArgRemove.TabIndex = 3;
            this.btnCustomUploaderArgRemove.Text = "Remove";
            this.btnCustomUploaderArgRemove.UseVisualStyleBackColor = true;
            this.btnCustomUploaderArgRemove.Click += new System.EventHandler(this.btnCustomUploaderArgRemove_Click);
            // 
            // lvCustomUploaderArguments
            // 
            this.lvCustomUploaderArguments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvCustomUploaderArguments.FullRowSelect = true;
            this.lvCustomUploaderArguments.GridLines = true;
            this.lvCustomUploaderArguments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvCustomUploaderArguments.HideSelection = false;
            this.lvCustomUploaderArguments.Location = new System.Drawing.Point(8, 72);
            this.lvCustomUploaderArguments.MultiSelect = false;
            this.lvCustomUploaderArguments.Name = "lvCustomUploaderArguments";
            this.lvCustomUploaderArguments.Size = new System.Drawing.Size(232, 184);
            this.lvCustomUploaderArguments.TabIndex = 5;
            this.lvCustomUploaderArguments.UseCompatibleStateImageBehavior = false;
            this.lvCustomUploaderArguments.View = System.Windows.Forms.View.Details;
            this.lvCustomUploaderArguments.SelectedIndexChanged += new System.EventHandler(this.lvCustomUploaderArguments_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 113;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 113;
            // 
            // btnCustomUploaderArgAdd
            // 
            this.btnCustomUploaderArgAdd.Location = new System.Drawing.Point(8, 40);
            this.btnCustomUploaderArgAdd.Name = "btnCustomUploaderArgAdd";
            this.btnCustomUploaderArgAdd.Size = new System.Drawing.Size(72, 24);
            this.btnCustomUploaderArgAdd.TabIndex = 2;
            this.btnCustomUploaderArgAdd.Text = "Add";
            this.btnCustomUploaderArgAdd.UseVisualStyleBackColor = true;
            this.btnCustomUploaderArgAdd.Click += new System.EventHandler(this.btnCustomUploaderArgAdd_Click);
            // 
            // txtCustomUploaderArgName
            // 
            this.txtCustomUploaderArgName.Location = new System.Drawing.Point(8, 16);
            this.txtCustomUploaderArgName.Name = "txtCustomUploaderArgName";
            this.txtCustomUploaderArgName.Size = new System.Drawing.Size(112, 20);
            this.txtCustomUploaderArgName.TabIndex = 0;
            // 
            // tpURLShorteners
            // 
            this.tpURLShorteners.Controls.Add(this.tcURLShorteners);
            this.tpURLShorteners.Location = new System.Drawing.Point(4, 22);
            this.tpURLShorteners.Name = "tpURLShorteners";
            this.tpURLShorteners.Padding = new System.Windows.Forms.Padding(3);
            this.tpURLShorteners.Size = new System.Drawing.Size(818, 506);
            this.tpURLShorteners.TabIndex = 3;
            this.tpURLShorteners.Text = "URL Shorteners";
            this.tpURLShorteners.UseVisualStyleBackColor = true;
            // 
            // tcURLShorteners
            // 
            this.tcURLShorteners.Controls.Add(this.tpGoogleURLShortener);
            this.tcURLShorteners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcURLShorteners.Location = new System.Drawing.Point(3, 3);
            this.tcURLShorteners.Name = "tcURLShorteners";
            this.tcURLShorteners.SelectedIndex = 0;
            this.tcURLShorteners.Size = new System.Drawing.Size(812, 500);
            this.tcURLShorteners.TabIndex = 0;
            // 
            // tpGoogleURLShortener
            // 
            this.tpGoogleURLShortener.Controls.Add(this.groupBox1);
            this.tpGoogleURLShortener.Controls.Add(this.atcGoogleURLShortenerAccountType);
            this.tpGoogleURLShortener.Location = new System.Drawing.Point(4, 22);
            this.tpGoogleURLShortener.Name = "tpGoogleURLShortener";
            this.tpGoogleURLShortener.Padding = new System.Windows.Forms.Padding(3);
            this.tpGoogleURLShortener.Size = new System.Drawing.Size(804, 474);
            this.tpGoogleURLShortener.TabIndex = 0;
            this.tpGoogleURLShortener.Text = "Google";
            this.tpGoogleURLShortener.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGoogleURLShortenerAuthComplete);
            this.groupBox1.Controls.Add(this.btnGoogleURLShortenerAuthOpen);
            this.groupBox1.Controls.Add(this.lblGooglAccountStatus);
            this.groupBox1.Location = new System.Drawing.Point(16, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 128);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User account";
            // 
            // btnGoogleURLShortenerAuthComplete
            // 
            this.btnGoogleURLShortenerAuthComplete.Enabled = false;
            this.btnGoogleURLShortenerAuthComplete.Location = new System.Drawing.Point(16, 56);
            this.btnGoogleURLShortenerAuthComplete.Name = "btnGoogleURLShortenerAuthComplete";
            this.btnGoogleURLShortenerAuthComplete.Size = new System.Drawing.Size(152, 24);
            this.btnGoogleURLShortenerAuthComplete.TabIndex = 1;
            this.btnGoogleURLShortenerAuthComplete.Text = "2. Complete authorization";
            this.btnGoogleURLShortenerAuthComplete.UseVisualStyleBackColor = true;
            this.btnGoogleURLShortenerAuthComplete.Click += new System.EventHandler(this.btnGoogleURLShortenerAuthComplete_Click);
            // 
            // btnGoogleURLShortenerAuthOpen
            // 
            this.btnGoogleURLShortenerAuthOpen.Location = new System.Drawing.Point(16, 24);
            this.btnGoogleURLShortenerAuthOpen.Name = "btnGoogleURLShortenerAuthOpen";
            this.btnGoogleURLShortenerAuthOpen.Size = new System.Drawing.Size(152, 24);
            this.btnGoogleURLShortenerAuthOpen.TabIndex = 0;
            this.btnGoogleURLShortenerAuthOpen.Text = "1. Open authorize page...";
            this.btnGoogleURLShortenerAuthOpen.UseVisualStyleBackColor = true;
            this.btnGoogleURLShortenerAuthOpen.Click += new System.EventHandler(this.btnGoogleURLShortenerAuthOpen_Click);
            // 
            // lblGooglAccountStatus
            // 
            this.lblGooglAccountStatus.AutoSize = true;
            this.lblGooglAccountStatus.Location = new System.Drawing.Point(24, 96);
            this.lblGooglAccountStatus.Name = "lblGooglAccountStatus";
            this.lblGooglAccountStatus.Size = new System.Drawing.Size(77, 13);
            this.lblGooglAccountStatus.TabIndex = 2;
            this.lblGooglAccountStatus.Text = "Login required.";
            // 
            // atcGoogleURLShortenerAccountType
            // 
            this.atcGoogleURLShortenerAccountType.Location = new System.Drawing.Point(8, 16);
            this.atcGoogleURLShortenerAccountType.Name = "atcGoogleURLShortenerAccountType";
            this.atcGoogleURLShortenerAccountType.SelectedAccountType = UploadersLib.AccountType.Anonymous;
            this.atcGoogleURLShortenerAccountType.Size = new System.Drawing.Size(214, 29);
            this.atcGoogleURLShortenerAccountType.TabIndex = 0;
            this.atcGoogleURLShortenerAccountType.AccountTypeChanged += new UploadersLib.GUI.AccountTypeControl.AccountTypeChangedEventHandler(this.atcGoogleURLShortenerAccountType_AccountTypeChanged);
            // 
            // tpOtherServices
            // 
            this.tpOtherServices.Controls.Add(this.tcOtherServices);
            this.tpOtherServices.Location = new System.Drawing.Point(4, 22);
            this.tpOtherServices.Name = "tpOtherServices";
            this.tpOtherServices.Padding = new System.Windows.Forms.Padding(3);
            this.tpOtherServices.Size = new System.Drawing.Size(818, 506);
            this.tpOtherServices.TabIndex = 4;
            this.tpOtherServices.Text = "Other Services";
            this.tpOtherServices.UseVisualStyleBackColor = true;
            // 
            // tcOtherServices
            // 
            this.tcOtherServices.Controls.Add(this.tpTwitter);
            this.tcOtherServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOtherServices.Location = new System.Drawing.Point(3, 3);
            this.tcOtherServices.Name = "tcOtherServices";
            this.tcOtherServices.SelectedIndex = 0;
            this.tcOtherServices.Size = new System.Drawing.Size(812, 500);
            this.tcOtherServices.TabIndex = 0;
            // 
            // tpTwitter
            // 
            this.tpTwitter.Controls.Add(this.btnTwitterLogin);
            this.tpTwitter.Controls.Add(this.ucTwitterAccounts);
            this.tpTwitter.Location = new System.Drawing.Point(4, 22);
            this.tpTwitter.Name = "tpTwitter";
            this.tpTwitter.Padding = new System.Windows.Forms.Padding(3);
            this.tpTwitter.Size = new System.Drawing.Size(804, 474);
            this.tpTwitter.TabIndex = 0;
            this.tpTwitter.Text = "Twitter";
            this.tpTwitter.UseVisualStyleBackColor = true;
            // 
            // btnTwitterLogin
            // 
            this.btnTwitterLogin.Location = new System.Drawing.Point(224, 11);
            this.btnTwitterLogin.Name = "btnTwitterLogin";
            this.btnTwitterLogin.Size = new System.Drawing.Size(60, 24);
            this.btnTwitterLogin.TabIndex = 1;
            this.btnTwitterLogin.Text = "Login";
            this.btnTwitterLogin.UseVisualStyleBackColor = true;
            this.btnTwitterLogin.Click += new System.EventHandler(this.btnTwitterLogin_Click);
            // 
            // ucTwitterAccounts
            // 
            this.ucTwitterAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTwitterAccounts.Location = new System.Drawing.Point(3, 3);
            this.ucTwitterAccounts.Name = "ucTwitterAccounts";
            this.ucTwitterAccounts.Size = new System.Drawing.Size(798, 468);
            this.ucTwitterAccounts.TabIndex = 0;
            // 
            // tbOutputs
            // 
            this.tbOutputs.Controls.Add(this.tcOutputs);
            this.tbOutputs.Location = new System.Drawing.Point(4, 22);
            this.tbOutputs.Name = "tbOutputs";
            this.tbOutputs.Padding = new System.Windows.Forms.Padding(3);
            this.tbOutputs.Size = new System.Drawing.Size(818, 506);
            this.tbOutputs.TabIndex = 5;
            this.tbOutputs.Text = "Outputs";
            this.tbOutputs.UseVisualStyleBackColor = true;
            // 
            // tcOutputs
            // 
            this.tcOutputs.Controls.Add(this.tpEmail);
            this.tcOutputs.Controls.Add(this.tpSharedFolders);
            this.tcOutputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOutputs.Location = new System.Drawing.Point(3, 3);
            this.tcOutputs.Name = "tcOutputs";
            this.tcOutputs.SelectedIndex = 0;
            this.tcOutputs.Size = new System.Drawing.Size(812, 500);
            this.tcOutputs.TabIndex = 0;
            // 
            // tpEmail
            // 
            this.tpEmail.Controls.Add(this.chkEmailConfirm);
            this.tpEmail.Controls.Add(this.cbEmailRememberLastTo);
            this.tpEmail.Controls.Add(this.txtEmailDefaultBody);
            this.tpEmail.Controls.Add(this.lblEmailDefaultBody);
            this.tpEmail.Controls.Add(this.txtEmailDefaultSubject);
            this.tpEmail.Controls.Add(this.lblEmailDefaultSubject);
            this.tpEmail.Controls.Add(this.txtEmailPassword);
            this.tpEmail.Controls.Add(this.lblEmailPassword);
            this.tpEmail.Controls.Add(this.txtEmailFrom);
            this.tpEmail.Controls.Add(this.lblEmailFrom);
            this.tpEmail.Controls.Add(this.nudEmailSmtpPort);
            this.tpEmail.Controls.Add(this.lblEmailSmtpPort);
            this.tpEmail.Controls.Add(this.txtEmailSmtpServer);
            this.tpEmail.Controls.Add(this.lblEmailSmtpServer);
            this.tpEmail.Location = new System.Drawing.Point(4, 22);
            this.tpEmail.Name = "tpEmail";
            this.tpEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmail.Size = new System.Drawing.Size(804, 474);
            this.tpEmail.TabIndex = 0;
            this.tpEmail.Text = "Email";
            this.tpEmail.UseVisualStyleBackColor = true;
            // 
            // chkEmailConfirm
            // 
            this.chkEmailConfirm.AutoSize = true;
            this.chkEmailConfirm.Location = new System.Drawing.Point(224, 104);
            this.chkEmailConfirm.Name = "chkEmailConfirm";
            this.chkEmailConfirm.Size = new System.Drawing.Size(134, 17);
            this.chkEmailConfirm.TabIndex = 10;
            this.chkEmailConfirm.Text = "Confirm before sending";
            this.chkEmailConfirm.UseVisualStyleBackColor = true;
            this.chkEmailConfirm.CheckedChanged += new System.EventHandler(this.chkEmailConfirm_CheckedChanged);
            // 
            // cbEmailRememberLastTo
            // 
            this.cbEmailRememberLastTo.AutoSize = true;
            this.cbEmailRememberLastTo.Location = new System.Drawing.Point(24, 104);
            this.cbEmailRememberLastTo.Name = "cbEmailRememberLastTo";
            this.cbEmailRememberLastTo.Size = new System.Drawing.Size(179, 17);
            this.cbEmailRememberLastTo.TabIndex = 9;
            this.cbEmailRememberLastTo.Text = "Remember last recipient address";
            this.cbEmailRememberLastTo.UseVisualStyleBackColor = true;
            this.cbEmailRememberLastTo.CheckedChanged += new System.EventHandler(this.cbRememberLastToEmail_CheckedChanged);
            // 
            // txtEmailDefaultBody
            // 
            this.txtEmailDefaultBody.Location = new System.Drawing.Point(24, 200);
            this.txtEmailDefaultBody.Multiline = true;
            this.txtEmailDefaultBody.Name = "txtEmailDefaultBody";
            this.txtEmailDefaultBody.Size = new System.Drawing.Size(400, 128);
            this.txtEmailDefaultBody.TabIndex = 14;
            this.txtEmailDefaultBody.TextChanged += new System.EventHandler(this.txtDefaultBody_TextChanged);
            // 
            // lblEmailDefaultBody
            // 
            this.lblEmailDefaultBody.AutoSize = true;
            this.lblEmailDefaultBody.Location = new System.Drawing.Point(24, 182);
            this.lblEmailDefaultBody.Name = "lblEmailDefaultBody";
            this.lblEmailDefaultBody.Size = new System.Drawing.Size(89, 13);
            this.lblEmailDefaultBody.TabIndex = 13;
            this.lblEmailDefaultBody.Text = "Default message:";
            // 
            // txtEmailDefaultSubject
            // 
            this.txtEmailDefaultSubject.Location = new System.Drawing.Point(24, 152);
            this.txtEmailDefaultSubject.Name = "txtEmailDefaultSubject";
            this.txtEmailDefaultSubject.Size = new System.Drawing.Size(400, 20);
            this.txtEmailDefaultSubject.TabIndex = 12;
            this.txtEmailDefaultSubject.TextChanged += new System.EventHandler(this.txtDefaultSubject_TextChanged);
            // 
            // lblEmailDefaultSubject
            // 
            this.lblEmailDefaultSubject.AutoSize = true;
            this.lblEmailDefaultSubject.Location = new System.Drawing.Point(24, 134);
            this.lblEmailDefaultSubject.Name = "lblEmailDefaultSubject";
            this.lblEmailDefaultSubject.Size = new System.Drawing.Size(81, 13);
            this.lblEmailDefaultSubject.TabIndex = 11;
            this.lblEmailDefaultSubject.Text = "Default subject:";
            // 
            // txtEmailPassword
            // 
            this.txtEmailPassword.Location = new System.Drawing.Point(104, 68);
            this.txtEmailPassword.Name = "txtEmailPassword";
            this.txtEmailPassword.PasswordChar = '*';
            this.txtEmailPassword.Size = new System.Drawing.Size(200, 20);
            this.txtEmailPassword.TabIndex = 8;
            this.txtEmailPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblEmailPassword
            // 
            this.lblEmailPassword.AutoSize = true;
            this.lblEmailPassword.Location = new System.Drawing.Point(24, 72);
            this.lblEmailPassword.Name = "lblEmailPassword";
            this.lblEmailPassword.Size = new System.Drawing.Size(56, 13);
            this.lblEmailPassword.TabIndex = 7;
            this.lblEmailPassword.Text = "Password:";
            // 
            // txtEmailFrom
            // 
            this.txtEmailFrom.Location = new System.Drawing.Point(104, 44);
            this.txtEmailFrom.Name = "txtEmailFrom";
            this.txtEmailFrom.Size = new System.Drawing.Size(200, 20);
            this.txtEmailFrom.TabIndex = 6;
            this.txtEmailFrom.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblEmailFrom
            // 
            this.lblEmailFrom.AutoSize = true;
            this.lblEmailFrom.Location = new System.Drawing.Point(24, 48);
            this.lblEmailFrom.Name = "lblEmailFrom";
            this.lblEmailFrom.Size = new System.Drawing.Size(35, 13);
            this.lblEmailFrom.TabIndex = 5;
            this.lblEmailFrom.Text = "Email:";
            // 
            // nudEmailSmtpPort
            // 
            this.nudEmailSmtpPort.Location = new System.Drawing.Point(352, 20);
            this.nudEmailSmtpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudEmailSmtpPort.Name = "nudEmailSmtpPort";
            this.nudEmailSmtpPort.Size = new System.Drawing.Size(64, 20);
            this.nudEmailSmtpPort.TabIndex = 4;
            this.nudEmailSmtpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudEmailSmtpPort.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudEmailSmtpPort.ValueChanged += new System.EventHandler(this.nudSmtpPort_ValueChanged);
            // 
            // lblEmailSmtpPort
            // 
            this.lblEmailSmtpPort.AutoSize = true;
            this.lblEmailSmtpPort.Location = new System.Drawing.Point(312, 24);
            this.lblEmailSmtpPort.Name = "lblEmailSmtpPort";
            this.lblEmailSmtpPort.Size = new System.Drawing.Size(29, 13);
            this.lblEmailSmtpPort.TabIndex = 1;
            this.lblEmailSmtpPort.Text = "Port:";
            // 
            // txtEmailSmtpServer
            // 
            this.txtEmailSmtpServer.Location = new System.Drawing.Point(104, 20);
            this.txtEmailSmtpServer.Name = "txtEmailSmtpServer";
            this.txtEmailSmtpServer.Size = new System.Drawing.Size(200, 20);
            this.txtEmailSmtpServer.TabIndex = 3;
            this.txtEmailSmtpServer.TextChanged += new System.EventHandler(this.txtSmtpServer_TextChanged);
            // 
            // lblEmailSmtpServer
            // 
            this.lblEmailSmtpServer.AutoSize = true;
            this.lblEmailSmtpServer.Location = new System.Drawing.Point(24, 24);
            this.lblEmailSmtpServer.Name = "lblEmailSmtpServer";
            this.lblEmailSmtpServer.Size = new System.Drawing.Size(72, 13);
            this.lblEmailSmtpServer.TabIndex = 0;
            this.lblEmailSmtpServer.Text = "SMTP server:";
            // 
            // tpSharedFolders
            // 
            this.tpSharedFolders.Controls.Add(this.tlpSharedFolders);
            this.tpSharedFolders.Location = new System.Drawing.Point(4, 22);
            this.tpSharedFolders.Name = "tpSharedFolders";
            this.tpSharedFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tpSharedFolders.Size = new System.Drawing.Size(804, 474);
            this.tpSharedFolders.TabIndex = 1;
            this.tpSharedFolders.Text = "Shared Folders or Web Servers";
            this.tpSharedFolders.UseVisualStyleBackColor = true;
            // 
            // tlpSharedFolders
            // 
            this.tlpSharedFolders.ColumnCount = 1;
            this.tlpSharedFolders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSharedFolders.Controls.Add(this.ucLocalhostAccounts, 0, 0);
            this.tlpSharedFolders.Controls.Add(this.gbSharedFolder, 0, 1);
            this.tlpSharedFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSharedFolders.Location = new System.Drawing.Point(3, 3);
            this.tlpSharedFolders.Name = "tlpSharedFolders";
            this.tlpSharedFolders.RowCount = 2;
            this.tlpSharedFolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpSharedFolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSharedFolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSharedFolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSharedFolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSharedFolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSharedFolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSharedFolders.Size = new System.Drawing.Size(798, 468);
            this.tlpSharedFolders.TabIndex = 0;
            // 
            // ucLocalhostAccounts
            // 
            this.ucLocalhostAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLocalhostAccounts.Location = new System.Drawing.Point(4, 4);
            this.ucLocalhostAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.ucLocalhostAccounts.Name = "ucLocalhostAccounts";
            this.ucLocalhostAccounts.Size = new System.Drawing.Size(790, 343);
            this.ucLocalhostAccounts.TabIndex = 0;
            // 
            // gbSharedFolder
            // 
            this.gbSharedFolder.Controls.Add(this.label10);
            this.gbSharedFolder.Controls.Add(this.label11);
            this.gbSharedFolder.Controls.Add(this.label12);
            this.gbSharedFolder.Controls.Add(this.cboSharedFolderFiles);
            this.gbSharedFolder.Controls.Add(this.cboSharedFolderText);
            this.gbSharedFolder.Controls.Add(this.cboSharedFolderImages);
            this.gbSharedFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSharedFolder.Location = new System.Drawing.Point(3, 354);
            this.gbSharedFolder.Name = "gbSharedFolder";
            this.gbSharedFolder.Size = new System.Drawing.Size(792, 111);
            this.gbSharedFolder.TabIndex = 1;
            this.gbSharedFolder.TabStop = false;
            this.gbSharedFolder.Text = "Settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Files";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Text";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Images";
            // 
            // cboSharedFolderFiles
            // 
            this.cboSharedFolderFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSharedFolderFiles.FormattingEnabled = true;
            this.cboSharedFolderFiles.Location = new System.Drawing.Point(64, 72);
            this.cboSharedFolderFiles.Name = "cboSharedFolderFiles";
            this.cboSharedFolderFiles.Size = new System.Drawing.Size(472, 21);
            this.cboSharedFolderFiles.TabIndex = 5;
            this.cboSharedFolderFiles.SelectedIndexChanged += new System.EventHandler(this.cboSharedFolderFiles_SelectedIndexChanged);
            // 
            // cboSharedFolderText
            // 
            this.cboSharedFolderText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSharedFolderText.FormattingEnabled = true;
            this.cboSharedFolderText.Location = new System.Drawing.Point(64, 48);
            this.cboSharedFolderText.Name = "cboSharedFolderText";
            this.cboSharedFolderText.Size = new System.Drawing.Size(472, 21);
            this.cboSharedFolderText.TabIndex = 3;
            this.cboSharedFolderText.SelectedIndexChanged += new System.EventHandler(this.cboSharedFolderText_SelectedIndexChanged);
            // 
            // cboSharedFolderImages
            // 
            this.cboSharedFolderImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSharedFolderImages.FormattingEnabled = true;
            this.cboSharedFolderImages.Location = new System.Drawing.Point(64, 24);
            this.cboSharedFolderImages.Name = "cboSharedFolderImages";
            this.cboSharedFolderImages.Size = new System.Drawing.Size(472, 21);
            this.cboSharedFolderImages.TabIndex = 1;
            this.cboSharedFolderImages.SelectedIndexChanged += new System.EventHandler(this.cboSharedFolderImages_SelectedIndexChanged);
            // 
            // txtRapidSharePremiumUserName
            // 
            this.txtRapidSharePremiumUserName.Location = new System.Drawing.Point(88, 84);
            this.txtRapidSharePremiumUserName.Name = "txtRapidSharePremiumUserName";
            this.txtRapidSharePremiumUserName.Size = new System.Drawing.Size(120, 20);
            this.txtRapidSharePremiumUserName.TabIndex = 11;
            // 
            // actRapidShareAccountType
            // 
            this.actRapidShareAccountType.Location = new System.Drawing.Point(8, 16);
            this.actRapidShareAccountType.Name = "actRapidShareAccountType";
            this.actRapidShareAccountType.SelectedAccountType = UploadersLib.AccountType.Anonymous;
            this.actRapidShareAccountType.Size = new System.Drawing.Size(214, 29);
            this.actRapidShareAccountType.TabIndex = 16;
            // 
            // UploadersConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 538);
            this.Controls.Add(this.tcUploaders);
            this.MinimumSize = new System.Drawing.Size(840, 572);
            this.Name = "UploadersConfigForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outputs Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploadersConfigForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UploadersConfigForm_FormClosed);
            this.Resize += new System.EventHandler(this.UploadersConfigForm_Resize);
            this.tcUploaders.ResumeLayout(false);
            this.tpImageUploaders.ResumeLayout(false);
            this.tcImageUploaders.ResumeLayout(false);
            this.tpImageShack.ResumeLayout(false);
            this.tpImageShack.PerformLayout();
            this.tpTinyPic.ResumeLayout(false);
            this.tpTinyPic.PerformLayout();
            this.tpImgur.ResumeLayout(false);
            this.tpImgur.PerformLayout();
            this.gbImgurUserAccount.ResumeLayout(false);
            this.gbImgurUserAccount.PerformLayout();
            this.tpFlickr.ResumeLayout(false);
            this.tpPhotobucket.ResumeLayout(false);
            this.gbPhotobucketAlbumPath.ResumeLayout(false);
            this.gbPhotobucketAlbumPath.PerformLayout();
            this.gbPhotobucketAlbums.ResumeLayout(false);
            this.gbPhotobucketAlbums.PerformLayout();
            this.gbPhotobucketUserAccount.ResumeLayout(false);
            this.gbPhotobucketUserAccount.PerformLayout();
            this.tpTwitPic.ResumeLayout(false);
            this.tpTwitPic.PerformLayout();
            this.tpTwitSnaps.ResumeLayout(false);
            this.tpTwitSnaps.PerformLayout();
            this.tpYFrog.ResumeLayout(false);
            this.tpYFrog.PerformLayout();
            this.tpTextUploaders.ResumeLayout(false);
            this.tcTextUploaders.ResumeLayout(false);
            this.tpPastebin.ResumeLayout(false);
            this.tpFileUploaders.ResumeLayout(false);
            this.tcFileUploaders.ResumeLayout(false);
            this.tpDropbox.ResumeLayout(false);
            this.tpDropbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDropboxLogo)).EndInit();
            this.tpBox.ResumeLayout(false);
            this.tpBox.PerformLayout();
            this.tpMinus.ResumeLayout(false);
            this.gbMinusUserPass.ResumeLayout(false);
            this.gbMinusUserPass.PerformLayout();
            this.gbMinusUpload.ResumeLayout(false);
            this.gbMinusUpload.PerformLayout();
            this.tpFTP.ResumeLayout(false);
            this.tlpFtp.ResumeLayout(false);
            this.panelFtp.ResumeLayout(false);
            this.panelFtp.PerformLayout();
            this.gbFtpSettings.ResumeLayout(false);
            this.gbFtpSettings.PerformLayout();
            this.tpRapidShare.ResumeLayout(false);
            this.tpRapidShare.PerformLayout();
            this.tpSendSpace.ResumeLayout(false);
            this.tpSendSpace.PerformLayout();
            this.tpCustomUploaders.ResumeLayout(false);
            this.tpCustomUploaders.PerformLayout();
            this.gbCustomUploaders.ResumeLayout(false);
            this.gbCustomUploaders.PerformLayout();
            this.gbCustomUploaderRegexp.ResumeLayout(false);
            this.gbCustomUploaderRegexp.PerformLayout();
            this.gbCustomUploaderArguments.ResumeLayout(false);
            this.gbCustomUploaderArguments.PerformLayout();
            this.tpURLShorteners.ResumeLayout(false);
            this.tcURLShorteners.ResumeLayout(false);
            this.tpGoogleURLShortener.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpOtherServices.ResumeLayout(false);
            this.tcOtherServices.ResumeLayout(false);
            this.tpTwitter.ResumeLayout(false);
            this.tbOutputs.ResumeLayout(false);
            this.tcOutputs.ResumeLayout(false);
            this.tpEmail.ResumeLayout(false);
            this.tpEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmailSmtpPort)).EndInit();
            this.tpSharedFolders.ResumeLayout(false);
            this.tlpSharedFolders.ResumeLayout(false);
            this.gbSharedFolder.ResumeLayout(false);
            this.gbSharedFolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpImageUploaders;
        private System.Windows.Forms.TabPage tpTextUploaders;
        private System.Windows.Forms.TabPage tpURLShorteners;
        private System.Windows.Forms.TabPage tpOtherServices;
        private System.Windows.Forms.TabControl tcImageUploaders;
        private System.Windows.Forms.TabPage tpImageShack;
        private System.Windows.Forms.TabPage tpTinyPic;
        private System.Windows.Forms.TabPage tpImgur;
        private System.Windows.Forms.TabPage tpFlickr;
        private System.Windows.Forms.TabPage tpTwitPic;
        private System.Windows.Forms.TabPage tpTwitSnaps;
        private System.Windows.Forms.Label lblTwitSnapsTip;
        private System.Windows.Forms.TabPage tpYFrog;
        private System.Windows.Forms.TabPage tpRapidShare;
        private System.Windows.Forms.TabPage tpDropbox;
        private System.Windows.Forms.TabPage tpSendSpace;
        private System.Windows.Forms.TabPage tpCustomUploaders;
        private System.Windows.Forms.TabControl tcTextUploaders;
        private System.Windows.Forms.TabPage tpPastebin;
        private System.Windows.Forms.TabControl tcURLShorteners;
        private System.Windows.Forms.TabPage tpGoogleURLShortener;
        private System.Windows.Forms.TabControl tcOtherServices;
        private System.Windows.Forms.TabPage tpTwitter;
        internal System.Windows.Forms.Button btnImageShackOpenPublicProfile;
        internal System.Windows.Forms.CheckBox cbImageShackIsPublic;
        internal System.Windows.Forms.Button btnImageShackOpenMyImages;
        internal System.Windows.Forms.Label lblImageShackUsername;
        internal System.Windows.Forms.Button btnImageShackOpenRegistrationCode;
        internal System.Windows.Forms.TextBox txtImageShackUsername;
        internal System.Windows.Forms.TextBox txtImageShackRegistrationCode;
        internal System.Windows.Forms.Label lblImageShackRegistrationCode;
        internal System.Windows.Forms.Button btnTinyPicOpenMyImages;
        internal System.Windows.Forms.CheckBox cbTinyPicRememberUsernamePassword;
        internal System.Windows.Forms.Label lblTinyPicRegistrationCode;
        internal System.Windows.Forms.TextBox txtTinyPicRegistrationCode;
        private System.Windows.Forms.TextBox txtTinyPicPassword;
        private System.Windows.Forms.Label lblTinyPicPassword;
        private System.Windows.Forms.TextBox txtTinyPicUsername;
        private System.Windows.Forms.Label lblTinyPicUsername;
        private System.Windows.Forms.Button btnTinyPicLogin;
        private System.Windows.Forms.Button btnImgurOpenAuthorizePage;
        private System.Windows.Forms.Label lblImgurAccountStatus;
        private System.Windows.Forms.Button btnImgurEnterVerificationCode;
        private System.Windows.Forms.TextBox txtImgurVerificationCode;
        private System.Windows.Forms.GroupBox gbImgurUserAccount;
        private System.Windows.Forms.Label lblImgurVerificationCode;
        private System.Windows.Forms.Button btnDropboxCompleteAuth;
        private System.Windows.Forms.PictureBox pbDropboxLogo;
        private System.Windows.Forms.Button btnDropboxRegister;
        private System.Windows.Forms.Label lblDropboxPathTip;
        private System.Windows.Forms.Label lblDropboxPath;
        private System.Windows.Forms.Button btnDropboxOpenAuthorize;
        private System.Windows.Forms.TextBox txtDropboxPath;
        private System.Windows.Forms.TableLayoutPanel tlpFtp;
        private System.Windows.Forms.GroupBox gbFtpSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFtpFiles;
        private System.Windows.Forms.ComboBox cboFtpText;
        private System.Windows.Forms.ComboBox cboFtpImages;
        private System.Windows.Forms.CheckBox chkFTPThumbnailCheckSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFTPThumbWidth;
        private System.Windows.Forms.Panel panelFtp;
        private AccountsControl ucFTPAccounts;
        private System.Windows.Forms.Button btnFtpHelp;
        internal System.Windows.Forms.Button btnFTPExport;
        internal System.Windows.Forms.Button btnFTPImport;
        private System.Windows.Forms.Label lblRapidSharePassword;
        private System.Windows.Forms.Label lblRapidSharePremiumUsername;
        private System.Windows.Forms.TextBox txtRapidSharePassword;
        private System.Windows.Forms.TextBox txtRapidShareUsername;
        private System.Windows.Forms.Button btnSendSpaceRegister;
        private System.Windows.Forms.Label lblSendSpacePassword;
        private System.Windows.Forms.Label lblSendSpaceUsername;
        private System.Windows.Forms.TextBox txtSendSpacePassword;
        private System.Windows.Forms.TextBox txtSendSpaceUserName;
        private System.Windows.Forms.PropertyGrid pgPastebinSettings;
        private System.Windows.Forms.Button btnPastebinLogin;
        private System.Windows.Forms.TabPage tpSharedFolders;
        internal AccountsControl ucLocalhostAccounts;
        private System.Windows.Forms.Button btnFlickrOpenImages;
        private System.Windows.Forms.PropertyGrid pgFlickrAuthInfo;
        private System.Windows.Forms.PropertyGrid pgFlickrSettings;
        private System.Windows.Forms.Button btnFlickrCheckToken;
        private System.Windows.Forms.Button btnFlickrCompleteAuth;
        private System.Windows.Forms.Button btnFlickrOpenAuthorize;
        private System.Windows.Forms.Button btnTwitterLogin;
        private AccountsControl ucTwitterAccounts;
        internal System.Windows.Forms.RichTextBox txtCustomUploaderLog;
        internal System.Windows.Forms.Button btnCustomUploaderTest;
        internal System.Windows.Forms.TextBox txtCustomUploaderFullImage;
        internal System.Windows.Forms.TextBox txtCustomUploaderThumbnail;
        internal System.Windows.Forms.Label lblCustomUploaderFullImage;
        internal System.Windows.Forms.Label lblCustomUploaderThumbnail;
        internal System.Windows.Forms.GroupBox gbCustomUploaders;
        internal System.Windows.Forms.ListBox lbCustomUploaderList;
        internal System.Windows.Forms.Button btnCustomUploaderClear;
        internal System.Windows.Forms.Button btnCustomUploaderExport;
        internal System.Windows.Forms.Button btnCustomUploaderRemove;
        internal System.Windows.Forms.Button btnCustomUploaderImport;
        internal System.Windows.Forms.Button btnCustomUploaderUpdate;
        internal System.Windows.Forms.TextBox txtCustomUploaderName;
        internal System.Windows.Forms.Button btnCustomUploaderAdd;
        internal System.Windows.Forms.GroupBox gbCustomUploaderRegexp;
        internal System.Windows.Forms.Button btnCustomUploaderRegexpEdit;
        internal System.Windows.Forms.TextBox txtCustomUploaderRegexp;
        internal System.Windows.Forms.ListView lvCustomUploaderRegexps;
        internal System.Windows.Forms.ColumnHeader lvRegexpsColumn;
        internal System.Windows.Forms.Button btnCustomUploaderRegexpRemove;
        internal System.Windows.Forms.Button btnCustomUploaderRegexpAdd;
        internal System.Windows.Forms.TextBox txtCustomUploaderFileForm;
        internal System.Windows.Forms.Label lblCustomUploaderFileForm;
        internal System.Windows.Forms.Label lblCustomUploaderUploadURL;
        internal System.Windows.Forms.TextBox txtCustomUploaderURL;
        internal System.Windows.Forms.GroupBox gbCustomUploaderArguments;
        internal System.Windows.Forms.Button btnCustomUploaderArgEdit;
        internal System.Windows.Forms.TextBox txtCustomUploaderArgValue;
        internal System.Windows.Forms.Button btnCustomUploaderArgRemove;
        internal System.Windows.Forms.ListView lvCustomUploaderArguments;
        internal System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.ColumnHeader columnHeader2;
        internal System.Windows.Forms.Button btnCustomUploaderArgAdd;
        internal System.Windows.Forms.TextBox txtCustomUploaderArgName;
        private System.Windows.Forms.CheckBox chkTwitPicShowFull;
        private System.Windows.Forms.ComboBox cboTwitPicThumbnailMode;
        private System.Windows.Forms.Label lblTwitPicThumbnailMode;
        private System.Windows.Forms.Button btnDropboxShowFiles;
        private System.Windows.Forms.Label lblDropboxStatus;
        private System.Windows.Forms.Label lblYFrogPassword;
        private System.Windows.Forms.Label lblYFrogUsername;
        private System.Windows.Forms.TextBox txtYFrogPassword;
        private System.Windows.Forms.TextBox txtYFrogUsername;
        private GUI.AccountTypeControl atcImageShackAccountType;
        private GUI.AccountTypeControl atcTinyPicAccountType;
        private GUI.AccountTypeControl atcImgurAccountType;
        private GUI.AccountTypeControl atcSendSpaceAccountType;
        private System.Windows.Forms.TextBox txtRapidSharePremiumUserName;
        private GUI.AccountTypeControl actRapidShareAccountType;
        private System.Windows.Forms.TabPage tpEmail;
        private System.Windows.Forms.TextBox txtEmailPassword;
        private System.Windows.Forms.Label lblEmailPassword;
        private System.Windows.Forms.TextBox txtEmailFrom;
        private System.Windows.Forms.Label lblEmailFrom;
        private System.Windows.Forms.NumericUpDown nudEmailSmtpPort;
        private System.Windows.Forms.Label lblEmailSmtpPort;
        private System.Windows.Forms.TextBox txtEmailSmtpServer;
        private System.Windows.Forms.Label lblEmailSmtpServer;
        private System.Windows.Forms.TextBox txtEmailDefaultBody;
        private System.Windows.Forms.Label lblEmailDefaultBody;
        private System.Windows.Forms.TextBox txtEmailDefaultSubject;
        private System.Windows.Forms.Label lblEmailDefaultSubject;
        private System.Windows.Forms.CheckBox cbEmailRememberLastTo;
        private System.Windows.Forms.TabPage tbOutputs;
        private System.Windows.Forms.TabControl tcOutputs;
        public System.Windows.Forms.TabControl tcUploaders;
        public System.Windows.Forms.TabControl tcFileUploaders;
        public System.Windows.Forms.TabPage tpFTP;
        public System.Windows.Forms.TabPage tpFileUploaders;
        private System.Windows.Forms.ComboBox cbImgurThumbnailType;
        private System.Windows.Forms.Label lblImgurThumbnailType;
        private GUI.AccountTypeControl atcGoogleURLShortenerAccountType;
        private System.Windows.Forms.Button btnGoogleURLShortenerAuthComplete;
        private System.Windows.Forms.Button btnGoogleURLShortenerAuthOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblGooglAccountStatus;
        private System.Windows.Forms.TabPage tpPhotobucket;
        private System.Windows.Forms.GroupBox gbPhotobucketUserAccount;
        private System.Windows.Forms.Button btnPhotobucketAuthOpen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPhotobucketAuthComplete;
        private System.Windows.Forms.TextBox txtPhotobucketVerificationCode;
        private System.Windows.Forms.Label lblPhotobucketAccountStatus;
        private System.Windows.Forms.GroupBox gbPhotobucketAlbums;
        private System.Windows.Forms.TextBox txtPhotobucketDefaultAlbumName;
        private System.Windows.Forms.Button btnPhotobucketCreateAlbum;
        private System.Windows.Forms.GroupBox gbPhotobucketAlbumPath;
        private System.Windows.Forms.ComboBox cboPhotobucketAlbumPaths;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPhotobucketParentAlbumPath;
        private System.Windows.Forms.TextBox txtPhotobucketNewAlbumName;
        private System.Windows.Forms.TextBox txtPhotobucketParentAlbumPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPhotobucketRemoveAlbum;
        private System.Windows.Forms.Button btnPhotobucketAddAlbum;
        private System.Windows.Forms.TabPage tpMinus;
        private System.Windows.Forms.Label lblMinusAuthStatus;
        private System.Windows.Forms.Button btnMinusAuth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMinusPassword;
        private System.Windows.Forms.TextBox txtMinusUsername;
        private System.Windows.Forms.GroupBox gbMinusUpload;
        private System.Windows.Forms.Button btnMinusFolderAdd;
        private System.Windows.Forms.Button btnMinusFolderRemove;
        private System.Windows.Forms.ComboBox cboMinusFolders;
        private System.Windows.Forms.CheckBox chkMinusPublic;
        private System.Windows.Forms.Button btnMinusReadFolderList;
        private System.Windows.Forms.Button btnAuthRefresh;
        private System.Windows.Forms.GroupBox gbMinusUserPass;
        private System.Windows.Forms.CheckBox chkEmailConfirm;
        private System.Windows.Forms.TableLayoutPanel tlpSharedFolders;
        private System.Windows.Forms.GroupBox gbSharedFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboSharedFolderFiles;
        private System.Windows.Forms.ComboBox cboSharedFolderText;
        private System.Windows.Forms.ComboBox cboSharedFolderImages;
        private System.Windows.Forms.Button btnRapidShareRefreshFolders;
        private System.Windows.Forms.TreeView tvRapidShareFolders;
        private System.Windows.Forms.TextBox txtRapidShareFolderID;
        private System.Windows.Forms.Label lblRapidShareFolderID;
        private System.Windows.Forms.TabPage tpBox;
        private System.Windows.Forms.Button btnBoxCompleteAuth;
        private System.Windows.Forms.Button btnBoxOpenAuthorize;
        private System.Windows.Forms.TextBox txtBoxFolderID;
        private System.Windows.Forms.Label lblBoxFolderID;
        private System.Windows.Forms.Button btnBoxRefreshFolders;
        private System.Windows.Forms.TreeView tvBoxFolders;
        private System.Windows.Forms.CheckBox cbDropboxAutoCreateShareableLink;
        private System.Windows.Forms.Label lblTwitPicTip;
    }
}