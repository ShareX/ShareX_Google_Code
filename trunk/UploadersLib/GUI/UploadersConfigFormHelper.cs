#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (C) 2012 ShareX Developers

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HelpersLib;
using UploadersLib.FileUploaders;
using UploadersLib.Forms;
using UploadersLib.HelperClasses;
using UploadersLib.ImageUploaders;
using UploadersLib.OtherServices;
using UploadersLib.Properties;
using UploadersLib.TextUploaders;
using UploadersLib.URLShorteners;

namespace UploadersLib
{
    public partial class UploadersConfigForm : Form
    {
        #region Imgur

        public void ImgurAuthOpen()
        {
            try
            {
                OAuthInfo oauth = new OAuthInfo(APIKeys.ImgurConsumerKey, APIKeys.ImgurConsumerSecret);

                string url = new Imgur(oauth).GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    Config.ImgurOAuthInfo = oauth;
                    Helpers.LoadBrowserAsync(url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImgurAuthComplete()
        {
            try
            {
                string verification = txtImgurVerificationCode.Text;

                if (!string.IsNullOrEmpty(verification) && Config.ImgurOAuthInfo != null &&
                    !string.IsNullOrEmpty(Config.ImgurOAuthInfo.AuthToken) && !string.IsNullOrEmpty(Config.ImgurOAuthInfo.AuthSecret))
                {
                    bool result = new Imgur(Config.ImgurOAuthInfo).GetAccessToken(verification);

                    if (result)
                    {
                        lblImgurAccountStatus.Text = "Login successful: " + Config.ImgurOAuthInfo.UserToken;
                        MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblImgurAccountStatus.Text = "Login failed.";
                        MessageBox.Show("Login failed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        atcImgurAccountType.SelectedAccountType = AccountType.Anonymous;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Imgur

        #region Flickr

        public void FlickrAuthOpen()
        {
            try
            {
                FlickrUploader flickr = new FlickrUploader(APIKeys.FlickrKey, APIKeys.FlickrSecret);
                btnFlickrOpenAuthorize.Tag = flickr.GetFrob();
                string url = flickr.GetAuthLink(FlickrPermission.Write);
                if (!string.IsNullOrEmpty(url))
                {
                    Helpers.LoadBrowserAsync(url);
                    btnFlickrCompleteAuth.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FlickrAuthComplete()
        {
            try
            {
                string token = btnFlickrOpenAuthorize.Tag as string;
                if (!string.IsNullOrEmpty(token))
                {
                    FlickrUploader flickr = new FlickrUploader(APIKeys.FlickrKey, APIKeys.FlickrSecret);
                    Config.FlickrAuthInfo = flickr.GetToken(token);
                    pgFlickrAuthInfo.SelectedObject = Config.FlickrAuthInfo;
                    // btnFlickrOpenImages.Text = string.Format("{0}'s photostream", Config.FlickrAuthInfo.Username);
                    MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FlickrCheckToken()
        {
            try
            {
                if (Config.FlickrAuthInfo != null)
                {
                    string token = Config.FlickrAuthInfo.Token;
                    if (!string.IsNullOrEmpty(token))
                    {
                        FlickrUploader flickr = new FlickrUploader(APIKeys.FlickrKey, APIKeys.FlickrSecret);
                        Config.FlickrAuthInfo = flickr.CheckToken(token);
                        pgFlickrAuthInfo.SelectedObject = Config.FlickrAuthInfo;
                        MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FlickrOpenImages()
        {
            if (Config.FlickrAuthInfo != null)
            {
                string userID = Config.FlickrAuthInfo.UserID;
                if (!string.IsNullOrEmpty(userID))
                {
                    FlickrUploader flickr = new FlickrUploader(APIKeys.FlickrKey, APIKeys.FlickrSecret);
                    string url = flickr.GetPhotosLink(userID);
                    if (!string.IsNullOrEmpty(url))
                    {
                        Helpers.LoadBrowserAsync(url);
                    }
                }
            }
        }

        #endregion Flickr

        #region Photobucket

        public void PhotobucketAuthOpen()
        {
            try
            {
                OAuthInfo oauth = new OAuthInfo(APIKeys.PhotobucketConsumerKey, APIKeys.PhotobucketConsumerSecret);

                string url = new Photobucket(oauth).GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    Config.PhotobucketOAuthInfo = oauth;
                    Helpers.LoadBrowserAsync(url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PhotobucketAuthComplete()
        {
            try
            {
                string verification = txtPhotobucketVerificationCode.Text;

                if (!string.IsNullOrEmpty(verification) && Config.PhotobucketOAuthInfo != null &&
                    !string.IsNullOrEmpty(Config.PhotobucketOAuthInfo.AuthToken) && !string.IsNullOrEmpty(Config.PhotobucketOAuthInfo.AuthSecret))
                {
                    Photobucket pb = new Photobucket(Config.PhotobucketOAuthInfo);
                    bool result = pb.GetAccessToken(verification);

                    if (result)
                    {
                        Config.PhotobucketAccountInfo = pb.GetAccountInfo();
                        lblPhotobucketAccountStatus.Text = "Login successful: " + Config.PhotobucketOAuthInfo.UserToken;
                        txtPhotobucketDefaultAlbumName.Text = Config.PhotobucketAccountInfo.AlbumID;
                        Config.PhotobucketAccountInfo.AlbumList.Add(Config.PhotobucketAccountInfo.AlbumID);
                        cboPhotobucketAlbumPaths.Items.Add(Config.PhotobucketAccountInfo.AlbumID);
                        cboPhotobucketAlbumPaths.SelectedIndex = 0;
                        MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblPhotobucketAccountStatus.Text = "Login failed.";
                        MessageBox.Show("Login failed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PhotobucketCreateAlbum()
        {
            Photobucket pb = new Photobucket(Config.PhotobucketOAuthInfo, Config.PhotobucketAccountInfo);
            if (pb.CreateAlbum(txtPhotobucketParentAlbumPath.Text, txtPhotobucketNewAlbumName.Text))
            {
                string albumPath = txtPhotobucketParentAlbumPath.Text + "/" + txtPhotobucketNewAlbumName.Text;
                Config.PhotobucketAccountInfo.AlbumList.Add(albumPath);
                cboPhotobucketAlbumPaths.Items.Add(albumPath);
                MessageBox.Show(albumPath + " successfully created.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Photobucket

        #region Dropbox

        public void DropboxOpenFiles()
        {
            if (OAuthInfo.CheckOAuth(Config.DropboxOAuthInfo))
            {
                using (DropboxFilesForm filesForm = new DropboxFilesForm(Config.DropboxOAuthInfo, GetDropboxUploadPath(), Config.DropboxAccountInfo))
                {
                    if (filesForm.ShowDialog() == DialogResult.OK)
                    {
                        txtDropboxPath.Text = filesForm.CurrentFolderPath;
                    }
                }
            }
        }

        public void DropboxAuthOpen()
        {
            try
            {
                OAuthInfo oauth = new OAuthInfo(APIKeys.DropboxConsumerKey, APIKeys.DropboxConsumerSecret);

                string url = new Dropbox(oauth).GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    Config.DropboxOAuthInfo = oauth;
                    Helpers.LoadBrowserAsync(url);
                    btnDropboxCompleteAuth.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DropboxAuthComplete()
        {
            if (Config.DropboxOAuthInfo != null && !string.IsNullOrEmpty(Config.DropboxOAuthInfo.AuthToken) &&
                !string.IsNullOrEmpty(Config.DropboxOAuthInfo.AuthSecret))
            {
                Dropbox dropbox = new Dropbox(Config.DropboxOAuthInfo);
                bool result = dropbox.GetAccessToken();

                if (result)
                {
                    DropboxAccountInfo account = dropbox.GetAccountInfo();

                    if (account != null)
                    {
                        Config.DropboxAccountInfo = account;
                        Config.DropboxUploadPath = txtDropboxPath.Text;
                        UpdateDropboxStatus();
                        MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    MessageBox.Show("GetAccountInfo failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Login failed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You must give access from Authorize page first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Config.DropboxOAuthInfo = null;
            UpdateDropboxStatus();
        }

        private void UpdateDropboxStatus()
        {
            if (OAuthInfo.CheckOAuth(Config.DropboxOAuthInfo) && Config.DropboxAccountInfo != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Login status: Successful");
                sb.AppendLine("Email: " + Config.DropboxAccountInfo.Email);
                sb.AppendLine("Name: " + Config.DropboxAccountInfo.Display_name);
                sb.AppendLine("User ID: " + Config.DropboxAccountInfo.Uid.ToString());
                string uploadPath = GetDropboxUploadPath();
                sb.AppendLine("Upload path: " + uploadPath);
                sb.AppendLine("Download path: " + Dropbox.GetDropboxURL(Config.DropboxAccountInfo.Uid, uploadPath, "{Filename}"));
                lblDropboxStatus.Text = sb.ToString();
                btnDropboxShowFiles.Enabled = true;
            }
            else
            {
                lblDropboxStatus.Text = "Login status: Authorize required";
            }
        }

        private string GetDropboxUploadPath()
        {
            return new NameParser { IsFolderPath = true }.Convert(Dropbox.TidyUploadPath(Config.DropboxUploadPath));
        }

        #endregion Dropbox

        #region Box

        public void BoxAuthOpen()
        {
            try
            {
                Box box = new Box(APIKeys.BoxKey);

                string url = box.GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    Config.BoxTicket = box.Ticket;
                    Helpers.LoadBrowserAsync(url);
                    btnBoxCompleteAuth.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BoxAuthComplete()
        {
            if (!string.IsNullOrEmpty(Config.BoxTicket))
            {
                try
                {
                    Box box = new Box(APIKeys.BoxKey) { Ticket = Config.BoxTicket };
                    Config.BoxAuthToken = box.GetAuthToken();

                    if (!string.IsNullOrEmpty(Config.BoxAuthToken))
                    {
                        MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Login failed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void BoxListFolders()
        {
            if (string.IsNullOrEmpty(Config.BoxAuthToken))
            {
                MessageBox.Show("Authentication required.", "Box refresh folders list failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tvBoxFolders.Nodes.Clear();
                Box box = new Box(APIKeys.BoxKey) { AuthToken = Config.BoxAuthToken };
                BoxFolder root = box.GetFolderList();
                BoxRecursiveAddChilds(tvBoxFolders.Nodes, root);
                tvBoxFolders.ExpandAll();
            }
        }

        private void BoxRecursiveAddChilds(TreeNodeCollection treeNodes, BoxFolder folderInfo)
        {
            string folderName;

            if (folderInfo.ID == "0")
            {
                folderName = "root";
            }
            else
            {
                folderName = folderInfo.Name;
            }

            TreeNode treeNode = treeNodes.Add(folderName);
            treeNode.Tag = folderInfo;

            foreach (BoxFolder folderInfo2 in folderInfo.Folders)
            {
                BoxRecursiveAddChilds(treeNode.Nodes, folderInfo2);
            }
        }

        #endregion Box

        #region Minus

        public void MinusAuth()
        {
            if (!string.IsNullOrEmpty(txtMinusUsername.Text) && !string.IsNullOrEmpty(txtMinusPassword.Text))
            {
                btnMinusAuth.Enabled = false;
                try
                {
                    Minus minus = new Minus(Config.MinusConfig, new OAuthInfo(APIKeys.MinusConsumerKey, APIKeys.MinusConsumerSecret), txtMinusUsername.Text, txtMinusPassword.Text);
                    string url = minus.GetAuthorizationURL();

                    if (!string.IsNullOrEmpty(url))
                    {
                        if (minus.GetAccessToken())
                        {
                            minus.ReadFolderList(MinusScope.upload_new);
                            MinusUpdateControls();
                            MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login failed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnMinusAuth.Enabled = true;
                }
            }
        }

        public void MinusUpdateControls()
        {
            if (Config.MinusConfig != null && Config.MinusConfig.MinusUser != null)
            {
                lblMinusAuthStatus.Text = "Logged in: " + Config.MinusConfig.MinusUser.username;
                txtMinusUsername.Text = Config.MinusConfig.MinusUser.username;
                cboMinusFolders.Items.Clear();
                if (Config.MinusConfig.FolderList.Count > 0)
                {
                    cboMinusFolders.Items.AddRange(Config.MinusConfig.FolderList.ToArray());
                    cboMinusFolders.SelectedIndex = Config.MinusConfig.FolderID.BetweenOrDefault(0, cboMinusFolders.Items.Count - 1);
                }
            }
            else
            {
                lblMinusAuthStatus.Text = "Not logged in.";
                btnAuthRefresh.Enabled = false;
            }
        }

        #endregion Minus

        #region FTP

        public bool CheckFTPAccounts()
        {
            return Config.FTPAccountList.IsValidIndex(Config.FTPSelectedImage);
        }

        public void TestFTPAccountAsync(FTPAccount acc)
        {
            if (acc != null)
            {
                ucFTPAccounts.btnTest.Enabled = false;
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += new DoWorkEventHandler(bw_DoWorkTestFTPAccount);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompletedTestFTPAccount);
                bw.RunWorkerAsync(acc);
            }
        }

        private void bw_DoWorkTestFTPAccount(object sender, DoWorkEventArgs e)
        {
            TestFTPAccount((FTPAccount)e.Argument, false);
        }

        private void bw_RunWorkerCompletedTestFTPAccount(object sender, RunWorkerCompletedEventArgs e)
        {
            ucFTPAccounts.btnTest.Enabled = true;
        }

        private void FTPAccountsExport()
        {
            if (Config.FTPAccountList != null)
            {
                SaveFileDialog dlg = new SaveFileDialog
                {
                    FileName = string.Format("{0}-{1}-accounts", Application.ProductName, DateTime.Now.ToString("yyyyMMdd")),
                    Filter = "FTP Accounts(*.json)|*.json"
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FTPAccountManager fam = new FTPAccountManager(Config.FTPAccountList);
                    fam.Save(dlg.FileName);
                }
            }
        }

        private void FTPAccountsImport()
        {
            OpenFileDialog dlg = new OpenFileDialog { Filter = "FTP Accounts(*.json)|*.json" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FTPAccountManager fam = FTPAccountManager.Read(dlg.FileName);
                FTPSetup(fam.FTPAccounts);
            }
        }

        public static void TestFTPAccount(FTPAccount account, bool silent)
        {
            string msg = string.Empty;
            string sfp = account.GetSubFolderPath();

            switch (account.Protocol)
            {
                case FTPProtocol.SFTP:
                    try
                    {
                        using (SFTP sftp = new SFTP(account))
                        {
                            if (!sftp.IsValidAccount)
                            {
                                msg = "An SFTP client couldn't be instantiated, not enough information.\r\nCould be a missing key file.";
                            }
                            else if (sftp.Connect())
                            {
                                List<string> createddirs = new List<string>();

                                if (!sftp.DirectoryExists(sfp))
                                {
                                    createddirs = sftp.CreateMultiDirectory(sfp);
                                }

                                if (sftp.IsConnected)
                                {
                                    msg = (createddirs.Count == 0) ? "Connected!" : "Connected!\r\nCreated folders:\r\n";
                                    for (int x = 0; x <= createddirs.Count - 1; x++)
                                    {
                                        msg += createddirs[x] + "\r\n";
                                    }
                                    msg += "\r\n\r\nPing results:\r\n " + SendPing(account.Host, 3);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        msg = e.Message;
                    }
                    break;
                default:
                    try
                    {
                        using (FTP ftpClient = new FTP(account))
                        {
                            if (ftpClient.ChangeDirectory(sfp, true))
                            {
                                msg = "Connected!\r\n\r\nPing results:\r\n" + SendPing(account.Host, 3);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        msg = e.Message;
                    }

                    break;
            }

            if (silent)
            {
                DebugHelper.WriteLine(string.Format("Tested {0} sub-folder path in {1}", sfp, account.ToString()));
            }
            else
            {
                MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static string SendPing(string host)
        {
            return SendPing(host, 1);
        }

        public static string SendPing(string host, int count)
        {
            string[] status = new string[count];

            using (Ping ping = new Ping())
            {
                PingReply reply;
                //byte[] buffer = Encoding.ASCII.GetBytes(new string('a', 32));
                for (int i = 0; i < count; i++)
                {
                    reply = ping.Send(host, 3000);
                    if (reply.Status == IPStatus.Success)
                    {
                        status[i] = reply.RoundtripTime.ToString() + " ms";
                    }
                    else
                    {
                        status[i] = "Timeout";
                    }
                    Thread.Sleep(100);
                }
            }

            return string.Join(", ", status);
        }

        public FTPAccount GetFtpAcctActive()
        {
            FTPAccount acc = null;
            if (CheckFTPAccounts())
            {
                acc = Config.FTPAccountList[Config.FTPSelectedImage];
            }
            return acc;
        }

        #endregion FTP

        #region SendSpace

        public UserPassBox SendSpaceRegister()
        {
            UserPassBox upb = new UserPassBox("SendSpace Registration...", "John Doe", "john.doe@gmail.com", "JohnDoe", "");
            upb.ShowDialog();
            if (upb.DialogResult == DialogResult.OK)
            {
                SendSpace sendSpace = new SendSpace(APIKeys.SendSpaceKey);
                upb.Success = sendSpace.AuthRegister(upb.UserName, upb.FullName, upb.Email, upb.Password);
                if (!upb.Success && sendSpace.Errors.Count > 0)
                {
                    MessageBox.Show(sendSpace.ToErrorString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return upb;
        }

        #endregion SendSpace

        #region Pastebin

        public void PastebinLogin()
        {
            if (Config.PastebinSettings != null)
            {
                try
                {
                    PastebinUploader pastebin = new PastebinUploader(APIKeys.PastebinKey, Config.PastebinSettings);

                    if (pastebin.Login())
                    {
                        pgPastebinSettings.SelectedObject = Config.PastebinSettings;
                        MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Login failed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion Pastebin

        #region Twitter

        public bool CheckTwitterAccounts()
        {
            return Config.TwitterOAuthInfoList.IsValidIndex(Config.TwitterSelectedAccount);
        }

        /// <summary>
        /// Returns the active TwitterAuthInfo object; if nothing is active then a new TwitterAuthInfo object is returned
        /// </summary>
        /// <returns></returns>
        public OAuthInfo TwitterGetActiveAccount()
        {
            if (CheckTwitterAccounts())
            {
                return Config.TwitterOAuthInfoList[Config.TwitterSelectedAccount];
            }

            return new OAuthInfo(APIKeys.TwitterConsumerKey, APIKeys.TwitterConsumerSecret);
        }

        public void TwitterLogin()
        {
            OAuthInfo acc = TwitterGetActiveAccount();
            string verification = acc.AuthVerifier;

            if (!string.IsNullOrEmpty(verification) && acc != null &&
                !string.IsNullOrEmpty(acc.AuthToken) && !string.IsNullOrEmpty(acc.AuthSecret))
            {
                Twitter twitter = new Twitter(acc);
                bool result = twitter.GetAccessToken(acc.AuthVerifier);

                if (result)
                {
                    MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Login failed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion Twitter

        #region URL Shorteners

        #region goo.gl

        public void GooglAuthOpen()
        {
            try
            {
                OAuthInfo oauth = new OAuthInfo(APIKeys.GoogleConsumerKey, APIKeys.GoogleConsumerSecret);

                string url = new GoogleURLShortener(oauth).GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    Config.GoogleURLShortenerOAuthInfo = oauth;
                    Helpers.LoadBrowserAsync(url);
                    btnGoogleURLShortenerAuthComplete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GooglAuthComplete()
        {
            if (Config.GoogleURLShortenerOAuthInfo != null && !string.IsNullOrEmpty(Config.GoogleURLShortenerOAuthInfo.AuthToken) &&
                !string.IsNullOrEmpty(Config.GoogleURLShortenerOAuthInfo.AuthSecret))
            {
                GoogleURLShortener gus = new GoogleURLShortener(Config.GoogleURLShortenerOAuthInfo);
                bool result = gus.GetAccessToken();

                if (result)
                {
                    MessageBox.Show("Login successful.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblGooglAccountStatus.Text = "Login successful: " + Config.GoogleURLShortenerOAuthInfo.UserToken;
                    return;
                }

                MessageBox.Show("Login failed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                atcGoogleURLShortenerAccountType.SelectedAccountType = AccountType.Anonymous;
            }
            else
            {
                MessageBox.Show("You must give access from Authorize page first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Config.GoogleURLShortenerOAuthInfo = null;
        }

        #endregion goo.gl

        #endregion URL Shorteners

        #region Custom uploader

        private void UpdateCustomUploader()
        {
            if (lbCustomUploaderList.SelectedIndex != -1)
            {
                CustomUploaderInfo iUploader = GetCustomUploaderFromFields();
                iUploader.Name = lbCustomUploaderList.SelectedItem.ToString();
                Config.CustomUploadersList[lbCustomUploaderList.SelectedIndex] = iUploader;
            }
        }

        private void LoadCustomUploader(CustomUploaderInfo imageUploader)
        {
            txtCustomUploaderArgName.Text = string.Empty;
            txtCustomUploaderArgValue.Text = string.Empty;
            lvCustomUploaderArguments.Items.Clear();
            foreach (Argument arg in imageUploader.Arguments)
            {
                lvCustomUploaderArguments.Items.Add(arg.Name).SubItems.Add(arg.Value);
            }

            txtCustomUploaderURL.Text = imageUploader.UploadURL;
            txtCustomUploaderFileForm.Text = imageUploader.FileFormName;
            txtCustomUploaderRegexp.Text = string.Empty;
            lvCustomUploaderRegexps.Items.Clear();
            foreach (string regexp in imageUploader.RegexpList)
            {
                lvCustomUploaderRegexps.Items.Add(regexp);
            }

            txtCustomUploaderFullImage.Text = imageUploader.URL;
            txtCustomUploaderThumbnail.Text = imageUploader.ThumbnailURL;
        }

        private CustomUploaderInfo GetCustomUploaderFromFields()
        {
            CustomUploaderInfo iUploader = new CustomUploaderInfo(txtCustomUploaderName.Text);
            foreach (ListViewItem lvItem in lvCustomUploaderArguments.Items)
            {
                iUploader.Arguments.Add(new Argument(lvItem.Text, lvItem.SubItems[1].Text));
            }

            iUploader.UploadURL = txtCustomUploaderURL.Text;
            iUploader.FileFormName = txtCustomUploaderFileForm.Text;
            foreach (ListViewItem lvItem in lvCustomUploaderRegexps.Items)
            {
                iUploader.RegexpList.Add(lvItem.Text);
            }

            iUploader.URL = txtCustomUploaderFullImage.Text;
            iUploader.ThumbnailURL = txtCustomUploaderThumbnail.Text;

            return iUploader;
        }

        private void ImportCustomUploaders(string fp)
        {
            CustomUploaderManager um = CustomUploaderManager.Load(fp);

            if (um != null)
            {
                Config.CustomUploadersList = um.ImageHostingServices;

                foreach (CustomUploaderInfo cui in Config.CustomUploadersList)
                {
                    lbCustomUploaderList.Items.Add(cui.Name);
                }
            }
        }

        private void ExportCustomUploaders(string fp)
        {
            CustomUploaderManager um = new CustomUploaderManager(Config.CustomUploadersList);
            um.Save(fp);
        }

        private void TestCustomUploader(CustomUploaderInfo cui)
        {
            UploadResult ur = null;

            Helpers.AsyncJob(() =>
            {
                try
                {
                    using (Stream stream = Resources.ShareXLogo.GetStream())
                    {
                        CustomUploader cu = new CustomUploader(cui);
                        ur = cu.Upload(stream, "Test.png");
                        ur.Errors = cu.Errors;
                    }
                }
                catch { }
            },
            () =>
            {
                if (ur != null)
                {
                    if (!string.IsNullOrEmpty(ur.URL))
                    {
                        txtCustomUploaderLog.AppendText("URL: " + ur.URL + Environment.NewLine);
                    }
                    else if (ur.IsError)
                    {
                        txtCustomUploaderLog.AppendText("Error: " + ur.ErrorsToString() + Environment.NewLine);
                    }
                    else
                    {
                        txtCustomUploaderLog.AppendText("Error: Result is empty." + Environment.NewLine);
                    }

                    txtCustomUploaderLog.ScrollToCaret();
                }

                btnCustomUploaderTest.Enabled = true;
            });
        }

        #endregion Custom uploader
    }
}