#region License Information (GPL v3)

/*
    ShareX - A program that allows to you take screenshots and share any file type
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

using System.IO;
using System.Linq;
using System.Windows.Forms;
using UploadersLib.FileUploaders;
using UploadersLib.HelperClasses;

namespace UploadersLib.Forms
{
    public partial class DropboxFilesForm : Form
    {
        public string CurrentFolderPath { get; private set; }

        private Dropbox dropbox;
        private ImageListManager ilm;

        public DropboxFilesForm(OAuthInfo oauth, string path = null)
        {
            InitializeComponent();
            dropbox = new Dropbox(oauth);
            ilm = new ImageListManager(lvDropboxFiles);

            if (path != null)
            {
                Shown += (sender, e) => OpenDirectory(path);
            }
        }

        public void OpenDirectory(string path)
        {
            lvDropboxFiles.Items.Clear();

            DropboxDirectoryInfo directory = null;

            AsyncHelper.AsyncJob(() =>
            {
                directory = dropbox.GetFilesList(path);
            },
            () =>
            {
                if (directory != null)
                {
                    lvDropboxFiles.Tag = directory;

                    ListViewItem lvi = GetParentFolder(directory.Path);

                    if (lvi != null)
                    {
                        lvDropboxFiles.Items.Add(lvi);
                    }

                    foreach (DropboxContentInfo content in directory.Contents.OrderBy(x => !x.Is_dir))
                    {
                        string filename = Path.GetFileName(content.Path);
                        lvi = new ListViewItem(filename);
                        lvi.SubItems.Add(content.Size);
                        lvi.SubItems.Add(content.Modified);
                        lvi.ImageKey = ilm.AddImage(content.Icon);
                        lvi.Tag = content;
                        lvDropboxFiles.Items.Add(lvi);
                    }

                    CurrentFolderPath = directory.Path.Trim('/');
                    Text = "Dropbox - " + CurrentFolderPath;
                }
                else
                {
                    MessageBox.Show("Path not exist: " + path, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        public ListViewItem GetParentFolder(string currentPath)
        {
            if (!string.IsNullOrEmpty(currentPath))
            {
                string parentFolder = currentPath.Remove(currentPath.LastIndexOf('/'));

                DropboxContentInfo content = new DropboxContentInfo() { Icon = "folder", Is_dir = true, Path = parentFolder };

                ListViewItem lvi = new ListViewItem("..");
                lvi.ImageKey = ilm.AddImage(content.Icon);
                lvi.Tag = content;
                return lvi;
            }

            return null;
        }

        private void lvDropboxFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvDropboxFiles.SelectedItems.Count > 0)
            {
                DropboxContentInfo content = lvDropboxFiles.SelectedItems[0].Tag as DropboxContentInfo;

                if (content != null && content.Is_dir)
                {
                    OpenDirectory(content.Path);
                }
            }
        }

        private void tsbSelectFolder_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}