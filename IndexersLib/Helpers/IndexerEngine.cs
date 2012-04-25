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
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ZSS.IndexersLib
{
    public class Indexer
    {
        private int mProgress = 0;
        private string mCurrentDirMsg = "Analyzing...";

        private IndexerAdapter mSettings = new IndexerAdapter();

        public Indexer(IndexerAdapter settings)
        {
            mSettings = settings;
        }

        public IndexerAdapter GetSettings()
        {
            return mSettings;
        }

        public int Progress
        {
            get { return mProgress; }
            set { mProgress = value; }
        }

        public string CurrentDirMessage
        {
            get { return mCurrentDirMsg; }
            protected set { mCurrentDirMsg = value; }
        }

        public virtual string IndexNow(IndexingMode mIndexMode, bool bWriteToFile = true)
        {
            // Does not seem to reach here

            List<string> fixedFolderList = new List<string>();
            List<string> dneFolderList = new List<string>();

            foreach (string dirPath in mSettings.GetConfig().FolderList)
            {
                if (Directory.Exists(dirPath))
                {
                    fixedFolderList.Add(dirPath);
                }
                else
                {
                    dneFolderList.Add(dirPath);
                }
            }

            if (dneFolderList.Count > 0)
            {
                StringBuilder sb = new System.Text.StringBuilder();
                foreach (string dp in dneFolderList)
                {
                    sb.AppendLine(dp);
                }
                MessageBox.Show("Following Index folders do not exist:" + Environment.NewLine + Environment.NewLine + sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Overrides by Sub Classes

            mSettings.GetConfig().FolderList = fixedFolderList;
            return new StringBuilder().ToString();
        }
    }
}