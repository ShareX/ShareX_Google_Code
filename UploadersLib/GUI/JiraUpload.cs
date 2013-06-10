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

// gpailler

using System;
using System.Windows.Forms;

namespace UploadersLib.GUI
{
    public partial class JiraUpload : Form
    {
        public delegate string GetSummaryHandler(string issueId);

        private readonly string _issuePrefix;
        private readonly GetSummaryHandler _getSummary;

        public JiraUpload()
        {
            InitializeComponent();
        }

        public string IssueId
        {
            get { return this.txtIssueId.Text; }
        }

        public JiraUpload(string issuePrefix, GetSummaryHandler getSummary)
            : this()
        {
            if (getSummary == null)
            {
                throw new ArgumentNullException("getSummary");
            }
            this._issuePrefix = issuePrefix;
            this._getSummary = getSummary;
        }

        private void JiraUpload_Load(object sender, EventArgs e)
        {
            this.txtIssueId.Text = this._issuePrefix;
            this.txtIssueId.SelectionStart = this.txtIssueId.Text.Length;

            this.ValidateIssueId(txtIssueId.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.ValidateIssueId(((TextBox)sender).Text);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ValidateIssueId(string issueId)
        {
            var res = this._getSummary(issueId);
            this.btnUpload.Enabled = (res != null);

            this.lblSummary.Text = res ?? "Issue not found";
            this.lblSummary.Enabled = res != null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}