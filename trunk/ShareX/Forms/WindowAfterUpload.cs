using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelpersLib;
using UploadersLib;

namespace ShareX
{
    public partial class WindowAfterUpload : Form
    {
        private UploadInfo mUploadInfo { get; set; }

        public WindowAfterUpload(UploadInfo info)
        {
            InitializeComponent();

            mUploadInfo = info;

            pbPreview.LoadingImage = ShareX.Properties.Resources.Loading;
            pbPreview.LoadImage(info.FilePath, info.Result.URL);

            this.Text = info.FileName;

            foreach (LinkFormatEnum type in Enum.GetValues(typeof(LinkFormatEnum)))
            {
                string url = info.Result.GetUrlByType(type, info.Result.URL);
                if (!string.IsNullOrEmpty(url))
                {
                    TreeNode tviUrlType = new TreeNode();
                    tviUrlType.Text = type.GetDescription();

                    TreeNode tviUrl = new TreeNode();
                    tviUrl.Text = url;

                    tviUrlType.Nodes.Add(tviUrl);
                    tvMain.Nodes.Add(tviUrlType);
                }
            }

            tvMain.ExpandAll();
        }

        private void tvMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
                Helpers.CopyTextSafely(e.Node.FirstNode.Text);
            else
                Helpers.CopyTextSafely(e.Node.Text);
        }
    }
}