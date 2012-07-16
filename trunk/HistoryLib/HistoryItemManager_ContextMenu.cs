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

namespace HistoryLib
{
    public partial class HistoryItemManager
    {
        public System.Windows.Forms.ContextMenuStrip cmsHistory;

        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenURL;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenShortenedURL;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenThumbnailURL;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenDeletionURL;
        private System.Windows.Forms.ToolStripSeparator tssOpen1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyURL;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyShortenedURL;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyThumbnailURL;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyDeletionURL;
        private System.Windows.Forms.ToolStripSeparator tssCopy1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyText;
        private System.Windows.Forms.ToolStripSeparator tssCopy2;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyHTMLLink;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyHTMLImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyHTMLLinkedImage;
        private System.Windows.Forms.ToolStripSeparator tssCopy3;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyForumLink;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyForumImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyForumLinkedImage;
        private System.Windows.Forms.ToolStripSeparator tssCopy4;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyFilePath;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyFileName;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyFileNameWithExtension;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowImagePreview;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowMoreInfo;

        private void InitializeComponent()
        {
            this.cmsHistory = new System.Windows.Forms.ContextMenuStrip();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenURL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenShortenedURL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenThumbnailURL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenDeletionURL = new System.Windows.Forms.ToolStripMenuItem();
            this.tssOpen1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyURL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyShortenedURL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyThumbnailURL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyDeletionURL = new System.Windows.Forms.ToolStripMenuItem();
            this.tssCopy1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCopyFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyText = new System.Windows.Forms.ToolStripMenuItem();
            this.tssCopy2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCopyHTMLLink = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyHTMLImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyHTMLLinkedImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tssCopy3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCopyForumLink = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyForumImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyForumLinkedImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tssCopy4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCopyFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyFileName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyFileNameWithExtension = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowImagePreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowMoreInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsHistory.SuspendLayout();

            //
            // cmsHistory
            //
            this.cmsHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiCopy,
            this.tsmiShow});
            this.cmsHistory.Name = "cmsHistory";
            this.cmsHistory.ShowImageMargin = false;
            this.cmsHistory.Size = new System.Drawing.Size(128, 92);
            this.cmsHistory.Enabled = false;
            //
            // tsmiOpen
            //
            this.tsmiOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenURL,
            this.tsmiOpenShortenedURL,
            this.tsmiOpenThumbnailURL,
            this.tsmiOpenDeletionURL,
            this.tssOpen1,
            this.tsmiOpenFile,
            this.tsmiOpenFolder});
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(127, 22);
            this.tsmiOpen.Text = "Open";
            //
            // tsmiOpenURL
            //
            this.tsmiOpenURL.Name = "tsmiOpenURL";
            this.tsmiOpenURL.Size = new System.Drawing.Size(156, 22);
            this.tsmiOpenURL.Text = "URL";
            this.tsmiOpenURL.Click += new EventHandler(this.tsmiOpenURL_Click);
            //
            // tsmiOpenShortenedURL
            //
            this.tsmiOpenShortenedURL.Name = "tsmiOpenShortenedURL";
            this.tsmiOpenShortenedURL.Size = new System.Drawing.Size(156, 22);
            this.tsmiOpenShortenedURL.Text = "Shortened URL";
            this.tsmiOpenShortenedURL.Click += new EventHandler(this.tsmiOpenShortenedURL_Click);
            //
            // tsmiOpenThumbnailURL
            //
            this.tsmiOpenThumbnailURL.Name = "tsmiOpenThumbnailURL";
            this.tsmiOpenThumbnailURL.Size = new System.Drawing.Size(156, 22);
            this.tsmiOpenThumbnailURL.Text = "Thumbnail URL";
            this.tsmiOpenThumbnailURL.Click += new EventHandler(this.tsmiOpenThumbnailURL_Click);
            //
            // tsmiOpenDeletionURL
            //
            this.tsmiOpenDeletionURL.Name = "tsmiOpenDeletionURL";
            this.tsmiOpenDeletionURL.Size = new System.Drawing.Size(156, 22);
            this.tsmiOpenDeletionURL.Text = "Deletion URL";
            this.tsmiOpenDeletionURL.Click += new EventHandler(this.tsmiOpenDeletionURL_Click);
            //
            // tssOpen1
            //
            this.tssOpen1.Name = "tssOpen1";
            this.tssOpen1.Size = new System.Drawing.Size(153, 6);
            //
            // tsmiOpenFile
            //
            this.tsmiOpenFile.Name = "tsmiOpenFile";
            this.tsmiOpenFile.Size = new System.Drawing.Size(156, 22);
            this.tsmiOpenFile.Text = "File";
            this.tsmiOpenFile.Click += new EventHandler(this.tsmiOpenFile_Click);
            //
            // tsmiOpenFolder
            //
            this.tsmiOpenFolder.Name = "tsmiOpenFolder";
            this.tsmiOpenFolder.Size = new System.Drawing.Size(156, 22);
            this.tsmiOpenFolder.Text = "Folder";
            this.tsmiOpenFolder.Click += new EventHandler(this.tsmiOpenFolder_Click);
            //
            // tsmiCopy
            //
            this.tsmiCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopyURL,
            this.tsmiCopyShortenedURL,
            this.tsmiCopyThumbnailURL,
            this.tsmiCopyDeletionURL,
            this.tssCopy1,
            this.tsmiCopyFile,
            this.tsmiCopyImage,
            this.tsmiCopyText,
            this.tssCopy2,
            this.tsmiCopyHTMLLink,
            this.tsmiCopyHTMLImage,
            this.tsmiCopyHTMLLinkedImage,
            this.tssCopy3,
            this.tsmiCopyForumLink,
            this.tsmiCopyForumImage,
            this.tsmiCopyForumLinkedImage,
            this.tssCopy4,
            this.tsmiCopyFilePath,
            this.tsmiCopyFileName,
            this.tsmiCopyFileNameWithExtension,
            this.tsmiCopyFolder});
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(127, 22);
            this.tsmiCopy.Text = "Copy";
            //
            // tsmiCopyURL
            //
            this.tsmiCopyURL.Name = "tsmiCopyURL";
            this.tsmiCopyURL.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyURL.Text = "URL";
            this.tsmiCopyURL.Click += new System.EventHandler(this.tsmiCopyURL_Click);
            //
            // tsmiCopyShortenedURL
            //
            this.tsmiCopyShortenedURL.Name = "tsmiCopyShortenedURL";
            this.tsmiCopyShortenedURL.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyShortenedURL.Text = "Shortened URL";
            this.tsmiCopyShortenedURL.Click += new System.EventHandler(this.tsmiCopyShortenedURL_Click);
            //
            // tsmiCopyThumbnailURL
            //
            this.tsmiCopyThumbnailURL.Name = "tsmiCopyThumbnailURL";
            this.tsmiCopyThumbnailURL.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyThumbnailURL.Text = "Thumbnail URL";
            this.tsmiCopyThumbnailURL.Click += new System.EventHandler(this.tsmiCopyThumbnailURL_Click);
            //
            // tsmiCopyDeletionURL
            //
            this.tsmiCopyDeletionURL.Name = "tsmiCopyDeletionURL";
            this.tsmiCopyDeletionURL.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyDeletionURL.Text = "Deletion URL";
            this.tsmiCopyDeletionURL.Click += new System.EventHandler(this.tsmiCopyDeletionURL_Click);
            //
            // tssCopy1
            //
            this.tssCopy1.Name = "tssCopy1";
            this.tssCopy1.Size = new System.Drawing.Size(230, 6);
            //
            // tsmiCopyFile
            //
            this.tsmiCopyFile.Name = "tsmiCopyFile";
            this.tsmiCopyFile.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyFile.Text = "File";
            this.tsmiCopyFile.Click += new System.EventHandler(this.tsmiCopyFile_Click);
            //
            // tsmiCopyImage
            //
            this.tsmiCopyImage.Name = "tsmiCopyImage";
            this.tsmiCopyImage.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyImage.Text = "Image (Bitmap)";
            this.tsmiCopyImage.Click += new System.EventHandler(this.tsmiCopyImage_Click);
            //
            // tsmiCopyText
            //
            this.tsmiCopyText.Name = "tsmiCopyText";
            this.tsmiCopyText.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyText.Text = "Text";
            this.tsmiCopyText.Click += new System.EventHandler(this.tsmiCopyText_Click);
            //
            // tssCopy2
            //
            this.tssCopy2.Name = "tssCopy2";
            this.tssCopy2.Size = new System.Drawing.Size(230, 6);
            //
            // tsmiCopyHTMLLink
            //
            this.tsmiCopyHTMLLink.Name = "tsmiCopyHTMLLink";
            this.tsmiCopyHTMLLink.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyHTMLLink.Text = "HTML link";
            this.tsmiCopyHTMLLink.Click += new System.EventHandler(this.tsmiCopyHTMLLink_Click);
            //
            // tsmiCopyHTMLImage
            //
            this.tsmiCopyHTMLImage.Name = "tsmiCopyHTMLImage";
            this.tsmiCopyHTMLImage.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyHTMLImage.Text = "HTML image";
            this.tsmiCopyHTMLImage.Click += new System.EventHandler(this.tsmiCopyHTMLImage_Click);
            //
            // tsmiCopyHTMLLinkedImage
            //
            this.tsmiCopyHTMLLinkedImage.Name = "tsmiCopyHTMLLinkedImage";
            this.tsmiCopyHTMLLinkedImage.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyHTMLLinkedImage.Text = "HTML linked image";
            this.tsmiCopyHTMLLinkedImage.Click += new System.EventHandler(this.tsmiCopyHTMLLinkedImage_Click);
            //
            // tssCopy3
            //
            this.tssCopy3.Name = "tssCopy3";
            this.tssCopy3.Size = new System.Drawing.Size(230, 6);
            //
            // tsmiCopyForumLink
            //
            this.tsmiCopyForumLink.Name = "tsmiCopyForumLink";
            this.tsmiCopyForumLink.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyForumLink.Text = "Forum (BBCode) link";
            this.tsmiCopyForumLink.Click += new System.EventHandler(this.tsmiCopyForumLink_Click);
            //
            // tsmiCopyForumImage
            //
            this.tsmiCopyForumImage.Name = "tsmiCopyForumImage";
            this.tsmiCopyForumImage.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyForumImage.Text = "Forum (BBCode) image";
            this.tsmiCopyForumImage.Click += new System.EventHandler(this.tsmiCopyForumImage_Click);
            //
            // tsmiCopyForumLinkedImage
            //
            this.tsmiCopyForumLinkedImage.Name = "tsmiCopyForumLinkedImage";
            this.tsmiCopyForumLinkedImage.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyForumLinkedImage.Text = "Forum (BBCode) linked image";
            this.tsmiCopyForumLinkedImage.Click += new System.EventHandler(this.tsmiCopyForumLinkedImage_Click);
            //
            // tssCopy4
            //
            this.tssCopy4.Name = "tssCopy4";
            this.tssCopy4.Size = new System.Drawing.Size(230, 6);
            //
            // tsmiCopyFilePath
            //
            this.tsmiCopyFilePath.Name = "tsmiCopyFilePath";
            this.tsmiCopyFilePath.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyFilePath.Text = "File path";
            this.tsmiCopyFilePath.Click += new System.EventHandler(this.tsmiCopyFilePath_Click);
            //
            // tsmiCopyFileName
            //
            this.tsmiCopyFileName.Name = "tsmiCopyFileName";
            this.tsmiCopyFileName.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyFileName.Text = "File name";
            this.tsmiCopyFileName.Click += new System.EventHandler(this.tsmiCopyFileName_Click);
            //
            // tsmiCopyFileNameWithExtension
            //
            this.tsmiCopyFileNameWithExtension.Name = "tsmiCopyFileNameWithExtension";
            this.tsmiCopyFileNameWithExtension.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyFileNameWithExtension.Text = "File name with extension";
            this.tsmiCopyFileNameWithExtension.Click += new System.EventHandler(this.tsmiCopyFileNameWithExtension_Click);
            //
            // tsmiCopyFolder
            //
            this.tsmiCopyFolder.Name = "tsmiCopyFolder";
            this.tsmiCopyFolder.Size = new System.Drawing.Size(233, 22);
            this.tsmiCopyFolder.Text = "Folder";
            this.tsmiCopyFolder.Click += new System.EventHandler(this.tsmiCopyFolder_Click);
            //
            // tsmiShow
            //
            this.tsmiShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowImagePreview,
            this.tsmiShowMoreInfo});
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(127, 22);
            this.tsmiShow.Text = "Show";
            //
            // tsmiShowImagePreview
            //
            this.tsmiShowImagePreview.Name = "tsmiShowImagePreview";
            this.tsmiShowImagePreview.Size = new System.Drawing.Size(127, 22);
            this.tsmiShowImagePreview.Text = "Image preview";
            this.tsmiShowImagePreview.Click += new EventHandler(tsmiShowImagePreview_Click);
            //
            // tsmiShowMoreInfo
            //
            this.tsmiShowMoreInfo.Name = "tsmiShowMoreInfo";
            this.tsmiShowMoreInfo.Size = new System.Drawing.Size(127, 22);
            this.tsmiShowMoreInfo.Text = "More info";
            this.tsmiShowMoreInfo.Click += new System.EventHandler(this.tsmiShowMoreInfo_Click);

            this.cmsHistory.ResumeLayout(false);
        }

        public void UpdateTexts(int itemsCount)
        {
            if (itemsCount > 1)
            {
                tsmiCopyURL.Text = string.Format("URLs ({0})", itemsCount);
            }
            else
            {
                tsmiCopyURL.Text = "URL";
            }
        }

        public void UpdateButtons()
        {
            cmsHistory.SuspendLayout();
            cmsHistory.Enabled = true;

            // Open
            tsmiOpenURL.Enabled = IsURLExist;
            tsmiOpenShortenedURL.Enabled = IsShortenedURLExist;
            tsmiOpenThumbnailURL.Enabled = IsThumbnailURLExist;
            tsmiOpenDeletionURL.Enabled = IsDeletionURLExist;

            tsmiOpenFile.Enabled = IsFileExist;
            tsmiOpenFolder.Enabled = IsFileExist;

            // Copy
            tsmiCopyURL.Enabled = IsURLExist;
            tsmiCopyShortenedURL.Enabled = IsShortenedURLExist;
            tsmiCopyThumbnailURL.Enabled = IsThumbnailURLExist;
            tsmiCopyDeletionURL.Enabled = IsDeletionURLExist;

            tsmiCopyFile.Enabled = IsFileExist;
            tsmiCopyImage.Enabled = IsImageFile;
            tsmiCopyText.Enabled = IsTextFile;

            tsmiCopyHTMLLink.Enabled = IsURLExist;
            tsmiCopyHTMLImage.Enabled = IsImageURL;
            tsmiCopyHTMLLinkedImage.Enabled = IsImageURL && IsThumbnailURLExist;

            tsmiCopyForumLink.Enabled = IsURLExist;
            tsmiCopyForumImage.Enabled = IsImageURL && IsURLExist;
            tsmiCopyForumLinkedImage.Enabled = IsImageURL && IsThumbnailURLExist;

            tsmiCopyFilePath.Enabled = IsFilePathValid;
            tsmiCopyFileName.Enabled = IsFilePathValid;
            tsmiCopyFileNameWithExtension.Enabled = IsFilePathValid;
            tsmiCopyFolder.Enabled = IsFilePathValid;

            // Show
            tsmiShowImagePreview.Enabled = IsImageFile;

            cmsHistory.ResumeLayout();
        }

        private void tsmiOpenURL_Click(object sender, EventArgs e)
        {
            OpenURL();
        }

        private void tsmiOpenShortenedURL_Click(object sender, EventArgs e)
        {
            OpenShortenedURL();
        }

        private void tsmiOpenThumbnailURL_Click(object sender, EventArgs e)
        {
            OpenThumbnailURL();
        }

        private void tsmiOpenDeletionURL_Click(object sender, EventArgs e)
        {
            OpenDeletionURL();
        }

        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void tsmiOpenFolder_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private void tsmiCopyURL_Click(object sender, EventArgs e)
        {
            CopyURL();
        }

        private void tsmiCopyShortenedURL_Click(object sender, EventArgs e)
        {
            CopyShortenedURL();
        }

        private void tsmiCopyThumbnailURL_Click(object sender, EventArgs e)
        {
            CopyThumbnailURL();
        }

        private void tsmiCopyDeletionURL_Click(object sender, EventArgs e)
        {
            CopyDeletionURL();
        }

        private void tsmiCopyFile_Click(object sender, EventArgs e)
        {
            CopyFile();
        }

        private void tsmiCopyImage_Click(object sender, EventArgs e)
        {
            CopyImage();
        }

        private void tsmiCopyText_Click(object sender, EventArgs e)
        {
            CopyText();
        }

        private void tsmiCopyHTMLLink_Click(object sender, EventArgs e)
        {
            CopyHTMLLink();
        }

        private void tsmiCopyHTMLImage_Click(object sender, EventArgs e)
        {
            CopyHTMLImage();
        }

        private void tsmiCopyHTMLLinkedImage_Click(object sender, EventArgs e)
        {
            CopyHTMLLinkedImage();
        }

        private void tsmiCopyForumLink_Click(object sender, EventArgs e)
        {
            CopyForumLink();
        }

        private void tsmiCopyForumImage_Click(object sender, EventArgs e)
        {
            CopyForumImage();
        }

        private void tsmiCopyForumLinkedImage_Click(object sender, EventArgs e)
        {
            CopyForumLinkedImage();
        }

        private void tsmiCopyFilePath_Click(object sender, EventArgs e)
        {
            CopyFilePath();
        }

        private void tsmiCopyFileName_Click(object sender, EventArgs e)
        {
            CopyFileName();
        }

        private void tsmiCopyFileNameWithExtension_Click(object sender, EventArgs e)
        {
            CopyFileNameWithExtension();
        }

        private void tsmiCopyFolder_Click(object sender, EventArgs e)
        {
            CopyFolder();
        }

        private void tsmiShowImagePreview_Click(object sender, EventArgs e)
        {
            ShowImagePreview();
        }

        private void tsmiShowMoreInfo_Click(object sender, EventArgs e)
        {
            ShowMoreInfo();
        }
    }
}