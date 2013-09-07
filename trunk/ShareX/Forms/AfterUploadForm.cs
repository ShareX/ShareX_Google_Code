using HelpersLib;
using ShareX.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UploadersLib;

namespace ShareX
{
    public partial class AfterUploadForm : Form
    {
        private TaskInfo Info { get; set; }
        private UploadInfoParser parser;

        public AfterUploadForm(TaskInfo info)
        {
            InitializeComponent();
            tmrClose.Start();
            Info = info;
            parser = new UploadInfoParser();

            if (info.DataType == EDataType.Image)
            {
                if (File.Exists(info.FilePath))
                    pbPreview.LoadImageFromFile(info.FilePath);
                else
                    pbPreview.LoadImageFromURL(info.Result.URL);
            }
            else
            {
                // pbPreview.LoadImage(Resources.folder);
            }

            this.Text = File.Exists(info.FilePath) ? info.FilePath : info.FileName;

            foreach (LinkFormatEnum type in Enum.GetValues(typeof(LinkFormatEnum)))
            {
                string txt = GetUrlByType(type);
                if (!string.IsNullOrEmpty(txt))
                {
                    TreeNode tviUrlType = new TreeNode();
                    tviUrlType.Text = type.GetDescription();

                    TreeNode tviUrl = new TreeNode();
                    tviUrl.Text = txt;

                    tviUrlType.Nodes.Add(tviUrl);
                    tvMain.Nodes.Add(tviUrlType);
                }
            }

            foreach (ClipboardFormat cf in Program.Settings.ClipboardContentFormats)
            {
                string txt = parser.Parse(Info, cf.Format);
                if (!string.IsNullOrEmpty(txt))
                {
                    TreeNode tviUrlType = new TreeNode();
                    tviUrlType.Text = cf.Description;

                    TreeNode tviUrl = new TreeNode();
                    tviUrl.Text = txt;

                    tviUrlType.Nodes.Add(tviUrl);
                    tvMain.Nodes.Add(tviUrlType);
                }
            }

            tvMain.ExpandAll();
        }

        private void tvMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
                ClipboardHelper.CopyText(e.Node.FirstNode.Text);
            else
                ClipboardHelper.CopyText(e.Node.Text);
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFolderOpen_Click(object sender, EventArgs e)
        {
            if (File.Exists(Info.FilePath))
                Helpers.OpenFolderWithFile(Info.FilePath);
        }

        private void btnCopyImage_Click(object sender, EventArgs e)
        {
            if (File.Exists(Info.FilePath))
                ClipboardHelper.CopyImageFromFile(Info.FilePath);
        }

        private void btnOpenLink_Click(object sender, EventArgs e)
        {
            string url = Info.Result.URL;
            if (!string.IsNullOrEmpty(url))
                Helpers.LoadBrowserAsync(url);
        }

        private void btnCopyLink_Click(object sender, EventArgs e)
        {
            string url = string.Empty;
            if (tvMain.SelectedNode != null)
            {
                url = tvMain.SelectedNode.Text;
            }
            else
            {
                url = tvMain.Nodes[0].Nodes[0].Text;
            }
            if (!string.IsNullOrEmpty(url))
                ClipboardHelper.CopyText(url);
        }

        #region TaskInfo helper methods

        public string GetUrlByType(LinkFormatEnum type)
        {
            switch (type)
            {
                case LinkFormatEnum.URL:
                    return Info.Result.URL;
                case LinkFormatEnum.ShortenedURL:
                    return Info.Result.ShortenedURL;
                case LinkFormatEnum.ForumImage:
                    return parser.Parse(Info, UploadInfoParser.ForumImage);
                case LinkFormatEnum.HTMLImage:
                    return parser.Parse(Info, UploadInfoParser.HTMLImage);
                case LinkFormatEnum.WikiImage:
                    return GetWikiImage();
                case LinkFormatEnum.WikiImage2:
                    return GetWikiImage2();
                case LinkFormatEnum.ForumLinkedImage:
                    return parser.Parse(Info, UploadInfoParser.ForumLinkedImage);
                case LinkFormatEnum.HTMLLinkedImage:
                    return parser.Parse(Info, UploadInfoParser.HTMLLinkedImage);
                case LinkFormatEnum.WikiLinkedImage:
                    return GetWikiLinkedImage();
                case LinkFormatEnum.ThumbnailURL:
                    return Info.Result.ThumbnailURL;
                case LinkFormatEnum.LocalFilePath:
                    return Info.FilePath;
                case LinkFormatEnum.LocalFilePathUri:
                    return GetLocalFilePathAsUri(Info.FilePath);
            }

            return Info.Result.URL;
        }

        public string GetWikiImage()
        {
            if (!string.IsNullOrEmpty(Info.Result.URL) && Helpers.IsImageFile(Info.Result.URL))
            {
                return string.Format("[{0}]", Info.Result.URL);
            }
            return string.Empty;
        }

        public string GetWikiImage2()
        {
            if (string.IsNullOrEmpty(Info.Result.URL))
                return string.Empty;
            int index = Info.Result.URL.IndexOf("Image:");
            if (index < 0)
                return string.Empty;
            string name = Info.Result.URL.Substring(index + "Image:".Length);
            return string.Format("[[Image:{0}]]", name);
        }

        public string GetWikiLinkedImage()
        {
            // e.g. [http://code.google.com http://code.google.com/images/code_sm.png]
            if (!string.IsNullOrEmpty(Info.Result.URL) && !string.IsNullOrEmpty(Info.Result.ThumbnailURL))
            {
                return string.Format("[{0} {1}]", Info.Result.URL, Info.Result.ThumbnailURL);
            }
            return string.Empty;
        }

        public string GetLocalFilePathAsUri(string fp)
        {
            if (File.Exists(fp))
            {
                try
                {
                    return new Uri(fp).AbsoluteUri;
                }
                catch (Exception ex)
                {
                    DebugHelper.WriteException(ex);
                }
            }
            return string.Empty;
        }

        #endregion TaskInfo helper methods
    }
}