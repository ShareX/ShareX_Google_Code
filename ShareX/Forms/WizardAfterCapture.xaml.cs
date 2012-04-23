using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShareX
{
    /// <summary>
    /// Interaction logic for WizardAfterCapture.xaml
    /// </summary>
    public partial class WizardAfterCapture
    {
        public WizardAfterCaptureConfig Config { get; set; }

        public WizardAfterCapture(WizardAfterCaptureConfig config)
        {
            InitializeComponent();
            Config = config;

            chkAnnotateImage.IsChecked = Config.AnnotateImage;
            chkCopyImageToClipboard.IsChecked = Config.CopyImageToClipboard;
            chkSaveImageToFile.IsChecked = Config.SaveImageToFile;
            chkUploadImageToHost.IsChecked = Config.UploadImageToHost;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Config.AnnotateImage = chkAnnotateImage.IsChecked;
            Config.CopyImageToClipboard = chkCopyImageToClipboard.IsChecked;
            Config.SaveImageToFile = chkSaveImageToFile.IsChecked;
            Config.UploadImageToHost = chkUploadImageToHost.IsChecked;
        }
    }

    public class WizardAfterCaptureConfig
    {
        public bool? AnnotateImage { get; set; }
        public bool? CopyImageToClipboard { get; set; }
        public bool? SaveImageToFile { get; set; }
        public bool? UploadImageToHost { get; set; }
    }
}