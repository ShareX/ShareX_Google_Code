#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (C) 2008-2013 ShareX Developers

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

using HelpersLib;
using ShareX.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UploadersLib;

namespace ShareX
{
    public partial class HotkeyTaskSettingsForm : Form
    {
        public HotkeySetting Setting { get; set; }

        public HotkeyTaskSettingsForm(HotkeySetting hotkeySetting)
        {
            InitializeComponent();
            Icon = Resources.ShareX;
            Setting = hotkeySetting;

            tbDescription.Text = hotkeySetting.Description;
            cbUseDefaultAfterCaptureSettings.Checked = hotkeySetting.TaskSettings.UseDefaultAfterCaptureJob;
            cbUseDefaultAfterUploadSettings.Checked = hotkeySetting.TaskSettings.UseDefaultAfterUploadJob;
            cbUseDefaultDestinationSettings.Checked = hotkeySetting.TaskSettings.UseDefaultDestinations;

            AddEnumItems<EHotkey>(x => Setting.Job = x, cmsTask);
            AddMultiEnumItems<AfterCaptureTasks>(x => Setting.TaskSettings.AfterCaptureJob = Setting.TaskSettings.AfterCaptureJob.Swap(x), cmsAfterCapture);
            AddMultiEnumItems<AfterUploadTasks>(x => Setting.TaskSettings.AfterUploadJob = Setting.TaskSettings.AfterUploadJob.Swap(x), cmsAfterUpload);
            AddEnumItems<ImageDestination>(x => Setting.TaskSettings.ImageDestination = x, cmsImageUploaders);
            AddEnumItems<TextDestination>(x => Setting.TaskSettings.TextDestination = x, cmsTextUploaders);
            AddEnumItems<FileDestination>(x => Setting.TaskSettings.FileDestination = x, cmsFileUploaders);
            AddEnumItems<UrlShortenerType>(x => Setting.TaskSettings.URLShortenerDestination = x, cmsURLShorteners);
            AddEnumItems<SocialNetworkingService>(x => Setting.TaskSettings.SocialNetworkingServiceDestination = x, cmsSocialNetworkingServices);

            SetMultiEnumChecked(Setting.TaskSettings.AfterCaptureJob, cmsAfterCapture);
            SetMultiEnumChecked(Setting.TaskSettings.AfterUploadJob, cmsAfterUpload);
            SetEnumChecked(Setting.TaskSettings.ImageDestination, cmsImageUploaders);
            SetEnumChecked(Setting.TaskSettings.TextDestination, cmsTextUploaders);
            SetEnumChecked(Setting.TaskSettings.FileDestination, cmsFileUploaders);
            SetEnumChecked(Setting.TaskSettings.URLShortenerDestination, cmsURLShorteners);
            SetEnumChecked(Setting.TaskSettings.SocialNetworkingServiceDestination, cmsSocialNetworkingServices);

            UpdateDestinationStates();
            UpdateUploaderMenuNames();
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            Setting.Description = tbDescription.Text;
        }

        private void btnTask_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsTask.Show(btnTask, e.Location);
            }
        }

        private void cbUseDefaultAfterCaptureSettings_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultAfterCaptureJob = cbUseDefaultAfterCaptureSettings.Checked;
            btnAfterCapture.Enabled = !Setting.TaskSettings.UseDefaultAfterCaptureJob;
        }

        private void btnAfterCapture_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsAfterCapture.Show(btnAfterCapture, e.Location);
            }
        }

        private void cbUseDefaultAfterUploadSettings_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultAfterUploadJob = cbUseDefaultAfterUploadSettings.Checked;
            btnAfterUpload.Enabled = !Setting.TaskSettings.UseDefaultAfterUploadJob;
        }

        private void btnAfterUpload_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsAfterUpload.Show(btnAfterUpload, e.Location);
            }
        }

        private void cbUseDefaultDestinationSettings_CheckedChanged(object sender, EventArgs e)
        {
            Setting.TaskSettings.UseDefaultDestinations = cbUseDefaultDestinationSettings.Checked;
            btnImageUploaders.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
            btnTextUploaders.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
            btnFileUploaders.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
            btnURLShorteners.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
            btnSocialNetworkingServices.Enabled = !Setting.TaskSettings.UseDefaultDestinations;
        }

        private void btnImageUploaders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsImageUploaders.Show(btnImageUploaders, e.Location);
            }
        }

        private void btnTextUploaders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsTextUploaders.Show(btnTextUploaders, e.Location);
            }
        }

        private void btnFileUploaders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsFileUploaders.Show(btnFileUploaders, e.Location);
            }
        }

        private void btnURLShorteners_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsURLShorteners.Show(btnURLShorteners, e.Location);
            }
        }

        private void btnSocialNetworkingServices_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmsSocialNetworkingServices.Show(btnSocialNetworkingServices, e.Location);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void UpdateDestinationStates()
        {
            if (Program.UploadersConfig != null)
            {
                EnableDisableToolStripMenuItems<ImageDestination>(cmsImageUploaders);
                EnableDisableToolStripMenuItems<TextDestination>(cmsTextUploaders);
                EnableDisableToolStripMenuItems<FileDestination>(cmsFileUploaders);
                EnableDisableToolStripMenuItems<UrlShortenerType>(cmsURLShorteners);
                EnableDisableToolStripMenuItems<SocialNetworkingService>(cmsSocialNetworkingServices);
            }
        }

        private void AddEnumItems<T>(Action<T> selectedEnum, params ToolStripDropDown[] parents)
        {
            string[] enums = Helpers.GetEnumDescriptions<T>();

            foreach (ToolStripDropDown parent in parents)
            {
                for (int i = 0; i < enums.Length; i++)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(enums[i]);

                    int index = i;

                    tsmi.Click += (sender, e) =>
                    {
                        foreach (ToolStripDropDown parent2 in parents)
                        {
                            for (int i2 = 0; i2 < enums.Length; i2++)
                            {
                                ToolStripMenuItem tsmi2 = (ToolStripMenuItem)parent2.Items[i2];
                                tsmi2.Checked = index == i2;
                            }
                        }

                        selectedEnum((T)Enum.ToObject(typeof(T), index));

                        UpdateUploaderMenuNames();
                    };

                    parent.Items.Add(tsmi);
                }
            }
        }

        private void SetEnumChecked<T>(T value, params ToolStripDropDown[] parents)
        {
            int index = Helpers.GetEnumMemberIndex(value);

            foreach (ToolStripDropDown parent in parents)
            {
                ((ToolStripMenuItem)parent.Items[index]).Checked = true;
            }
        }

        private void AddMultiEnumItems<T>(Action<T> selectedEnum, params ToolStripDropDown[] parents)
        {
            string[] enums = Enum.GetValues(typeof(T)).Cast<Enum>().Skip(1).Select(x => x.GetDescription()).ToArray();

            foreach (ToolStripDropDown parent in parents)
            {
                for (int i = 0; i < enums.Length; i++)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(enums[i]);

                    int index = i;

                    tsmi.Click += (sender, e) =>
                    {
                        foreach (ToolStripDropDown parent2 in parents)
                        {
                            ToolStripMenuItem tsmi2 = (ToolStripMenuItem)parent2.Items[index];
                            tsmi2.Checked = !tsmi2.Checked;
                        }

                        selectedEnum((T)Enum.ToObject(typeof(T), 1 << index));

                        UpdateUploaderMenuNames();
                    };

                    parent.Items.Add(tsmi);
                }
            }
        }

        private void SetMultiEnumChecked(Enum value, params ToolStripDropDown[] parents)
        {
            for (int i = 0; i < parents[0].Items.Count; i++)
            {
                foreach (ToolStripDropDown parent in parents)
                {
                    ToolStripMenuItem tsmi = (ToolStripMenuItem)parent.Items[i];
                    tsmi.Checked = value.HasFlag(1 << i);
                }
            }
        }

        private void EnableDisableToolStripMenuItems<T>(params ToolStripDropDown[] parents)
        {
            foreach (ToolStripDropDown parent in parents)
            {
                for (int i = 0; i < parent.Items.Count; i++)
                {
                    parent.Items[i].Enabled = Program.UploadersConfig.IsActive<T>(i);
                }
            }
        }

        private void UpdateUploaderMenuNames()
        {
            btnTask.Text = "Task: " + Setting.Job.GetDescription();

            string imageUploader = Setting.TaskSettings.ImageDestination == ImageDestination.FileUploader ?
                Setting.TaskSettings.FileDestination.GetDescription() : Setting.TaskSettings.ImageDestination.GetDescription();
            btnImageUploaders.Text = "Image uploader: " + imageUploader;

            string textUploader = Setting.TaskSettings.TextDestination == TextDestination.FileUploader ?
                Setting.TaskSettings.FileDestination.GetDescription() : Setting.TaskSettings.TextDestination.GetDescription();
            btnTextUploaders.Text = "Text uploader: " + textUploader;

            btnFileUploaders.Text = "File uploader: " + Setting.TaskSettings.FileDestination.GetDescription();

            btnURLShorteners.Text = "URL shortener: " + Setting.TaskSettings.URLShortenerDestination.GetDescription();

            btnSocialNetworkingServices.Text = "Social networking service: " + Setting.TaskSettings.SocialNetworkingServiceDestination.GetDescription();
        }
    }
}