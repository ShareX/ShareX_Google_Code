using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShareX
{
    public partial class WindowAfterCapture : Form
    {

        public WizardAfterCaptureConfig Config { get; set; }

        public WindowAfterCapture(WizardAfterCaptureConfig config)
        {
            InitializeComponent();

            Config = config;

            chkAnnotateImage.Checked = Config.AnnotateImage;
            chkCopyImageToClipboard.Checked = Config.CopyImageToClipboard;
            chkSaveImageToFile.Checked = Config.SaveImageToFile;
            chkUploadImageToHost.Checked = Config.UploadImageToHost;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void WindowAfterCapture_FormClosed(object sender, FormClosedEventArgs e)
        {
            Config.AnnotateImage = chkAnnotateImage.Checked;
            Config.CopyImageToClipboard = chkCopyImageToClipboard.Checked;
            Config.SaveImageToFile = chkSaveImageToFile.Checked;
            Config.UploadImageToHost = chkUploadImageToHost.Checked;
        }

    }

    public class WizardAfterCaptureConfig
    {
        public bool AnnotateImage { get; set; }
        public bool CopyImageToClipboard { get; set; }
        public bool SaveImageToFile { get; set; }
        public bool UploadImageToHost { get; set; }
    }
}
