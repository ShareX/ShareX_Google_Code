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
using HelpersLib;
using UploadersLib;

namespace ShareX
{
    /// <summary>
    /// Interaction logic for WizardClipboardOptions.xaml
    /// </summary>
    public partial class WizardClipboardOptions
    {
        private UploadInfo mUploadInfo { get; set; }

        public WizardClipboardOptions(UploadInfo info)
        {
            InitializeComponent();
            mUploadInfo = info;

            this.Title = info.FileName;

            foreach (LinkFormatEnum type in Enum.GetValues(typeof(LinkFormatEnum)))
            {
                string url = info.Result.GetUrlByType(type, info.Result.URL);
                if (!string.IsNullOrEmpty(url))
                {
                    TreeViewItem tviUrlType = new TreeViewItem();
                    tviUrlType.Header = type.GetDescription();

                    TreeViewItem tviUrl = new TreeViewItem();
                    tviUrl.Header = url;
                    tviUrl.MouseDoubleClick += new MouseButtonEventHandler(tviUrl_MouseDoubleClick);

                    tviUrlType.Items.Add(tviUrl);
                    tvMain.Items.Add(tviUrlType);
                }
            }
        }

        private void tviUrl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem tvi = e.Source as TreeViewItem;
            Clipboard.SetText(tvi.Header.ToString());
        }
    }
}