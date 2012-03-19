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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ZSS.IndexersLib.Helpers;

namespace ZSS.IndexersLib
{
    public class IndexerConfig
    {
        //Default to Tree.NET
        [Category("Engines / General"), Description("Adjust CPU indexing priority level")]
        public System.Threading.ThreadPriority ProcessPriority { get; set; }

        // Config > Engine > Tree
        [Category("Engines / Tree Walk Utility"), DefaultValue(true), Description("Display the names of the files in each folder.")]
        public bool TreeShowFiles { get; set; }
        [Category("Engines / Tree Walk Utility"), DefaultValue(true), Description("Use ASCII instead of extended characters")]
        public bool TreeUseAscii { get; set; }
        [Category("Engines / Tree Walk Utility"), DefaultValue(false), Description("Remove tree branches")]
        public bool RemoveTreeBranches { get; set; }

        // Engine > TreeNet
        public const string DefaultCssFileName = "Default.css";
        [Category("Engines / Tree.NET"), DefaultValue(true), Description("Display files")]
        public bool ShowFilesTreeNet { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue(true), Description("Display file sizes")]
        public bool ShowFileSize { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue(true), Description("Display folder sizes")]
        public bool ShowDirSize { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue(false), Description("Show full file path in the index")]
        public bool ShowFilePath { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue(false), Description("Show full folder path in the index")]
        public bool ShowFolderPath { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue(false), Description("Hide Extension in files")]
        public bool HideExtension { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue(false), Description("Show virtual folders")]
        public bool ShowVirtualFolders { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue(false), Description("Show folder paths in the browser's status bar")]
        public bool ShowFolderPathOnStatusBar { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue("~*"), Description("Folder heading style")]
        public string FolderHeadingStyle { get; set; }

        // Zip Operations
        public bool ZipAfterIndexed = false;
        public bool ZipAndDeleteFile = false;
        public bool ZipMergedFile = false;
        public bool ZipFilesInEachDir = true;
        public bool ZipFilesInOutputDir = false;

        // Filter
        [Category("General / Filter"), DefaultValue(false), Description("File files and folders according to filtering rules")]
        public bool EnabledFiltering = true;
        [Category("General / Filter"), DefaultValue(false), Description("Ignore protected Operating System files and folders when indexing")]
        public bool HideProtectedOperatingSystemFilesFolders { get; set; }
        [Category("General / Filter"), DefaultValue(false), Description("Ignore hidden files when indexing")]
        public bool IgnoreHiddenFiles { get; set; }
        [Category("General / Filter"), DefaultValue(false), Description("Ignore system files when indexing")]
        public bool IgnoreSystemFiles { get; set; }
        public bool IgnoreFollowingFiles = true;
        [Category("General / Filter"), Description("Ignore the following user files")]
        public string IgnoreFilesList { get; set; }
        [Category("General / Filter"), DefaultValue(false), Description("Ignore system folders when indexing")]
        public bool IgnoreHiddenFolders { get; set; }
        [Category("General / Filter"), DefaultValue(false), Description("Ignore system folders when indexing")]
        public bool IgnoreSystemFolders { get; set; }
        [Category("General / Filter"), DefaultValue(false), Description("Ignore empty folders when indexing")]
        public bool IgnoreEmptyFolders { get; set; }
        //war59312

        // Misc
        [Category("Engines / Tree.NET / XHTML"), Description("Merged XHTML Title")]
        public string MergedHtmlTitle = string.Empty;
        [Category("Engines / Tree.NET / XHTML"), Description("Server information e.g. ftp://domain:port")]
        public string ServerInfo = string.Empty;
        [Category("Engines / Tree.NET / XHTML"), DefaultValue(true), Description("To show your readers that you have taken the care to create an interoperable Web page, you may display this icon on any page that validates")]
        public bool ShowValidXhtmlIcons { get; set; }

        [Category("General / Display"), DefaultValue(false), Description("Display files in reverse")]
        public bool RevereFileOrder { get; set; }
        [Category("General / Display"), DefaultValue(false), Description("Display file count")]
        public bool ShowFileCount { get; set; }
        [Category("General / Tree.NET / Display"), DefaultValue(false), Description("Display file count")]
        public bool SortBySize { get; set; }
        [Category("General / Tree.NET / Display"), DefaultValue(FileSortMode.Ascending), Description("Sort files by Size")]
        public FileSortMode SortBySizeMode { get; set; }

        [Category("General / Audio"), DefaultValue(false), Description("Enable Quick Audio scan to index faster. Bitrate information will not be precise.")]
        public bool AudioQuickScan { get; set; }
        [Category("General / Audio"), DefaultValue(false), Description("Enable Audio file scan.")]
        public bool AudioInfo { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue(2), Description("Folder expand level")]
        public int FolderExpandLevel { get; set; }
        [Category("Engines / Tree.NET"), DefaultValue(false), Description("Collapse folders")]
        public bool CollapseFolders { get; set; }
        [Category("Engines / Tree.NET"), Description("Path for an image logo")]
        public string LogoPath = string.Empty; // { get; set; }

        public IndexerConfig()
        {
            IndexingEngineType = IndexingEngine.TreeNetLib;

            TreeShowFiles = true;
            TreeUseAscii = true;

            AudioInfo = true;
            ShowFilesTreeNet = true;
            ShowFileSize = true;
            ShowDirSize = true;
            ShowValidXhtmlIcons = true;

            IgnoreFilesList = ".DS_Store|*.db|index.html|*.ini";

            CssFilePath = Path.Combine(Application.StartupPath, DefaultCssFileName);
            AudioQuickScan = true;
            IndexFileExt = ".html";
            FolderExpandLevel = 2;
            FolderHeadingStyle = "*~";
            IndexListType = XHTMLFileListMode.Bullets;
            ServerInfo = "ftp://127.0.0.1:21";
            MergedHtmlTitle = "Site Index";
            VirtualFolderList = new List<string>();
            FolderList = new List<string>();
        }

        [Category("Engines / Tree.NET / XHTML"), Description("Cascading Style Sheet file path")]
        [EditorAttribute(typeof(CssFileNameEditor), typeof(UITypeEditor))]
        public string CssFilePath { get; set; }

        [Category("Engines / Tree.NET / XHTML"), Description("Virtual folders list")]
        public List<string> VirtualFolderList = null;

        // Engine > TreeNet > XHTML Output
        [Category("Engines / Tree.NET / XHTML"), DefaultValue(XHTMLFileListMode.Bullets), Description("Display the files as a numbered list or a bulletted list")]
        public XHTMLFileListMode IndexListType { get; set; }

        public List<string> FolderList = null;

        [Category("Engines / General"), DefaultValue(false), Description("Show footer message showing project page")]
        public bool AddFooter { get; set; }
        [Category("Engines / General"), Description("Index file name without extension")]
        public string IndexFileNameWitoutExt { get; set; }
        [Category("Engines / General"), Description("Index file extension")]
        public string IndexFileExt { get; set; }

        [Category("Engines / General"), DefaultValue(false), Description("Merge index file")]
        public bool MergeFiles = false;
        [Category("Engines / General"), Description("Output directory for merge index file")]
        [EditorAttribute(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string OutputDir { get; set; }
        [Category("Engines / General"), Description("Indexing Engine")]
        public IndexingEngine IndexingEngineType { get; set; }

        #region "Methods"

        public string GetIndexFileName()
        {
            return this.IndexFileNameWitoutExt + IndexFileExt;
        }

        public string[] GetIndexFilePaths()
        {
            string[] paths = new string[FolderList.Count];

            for (int i = 0; i <= FolderList.Count - 1; i++)
            {
                paths[i] = FolderList[i] + Path.DirectorySeparatorChar + this.GetIndexFileName();
            }

            return paths;
        }

        public void SetIndexPath(string fpath)
        {
            IndexFileNameWitoutExt = Path.GetFileNameWithoutExtension(fpath);
            IndexFileExt = Path.GetExtension(fpath);
        }

        public void SetSingleIndexPath(string fpath)
        {
            OutputDir = Path.GetDirectoryName(fpath);
            IndexFileNameWitoutExt = Path.GetFileNameWithoutExtension(fpath);
            IndexFileExt = Path.GetExtension(fpath);

            MergeFiles = true;
        }

        public string GetIndexFilePath()
        {
            return this.OutputDir + Path.DirectorySeparatorChar + this.GetIndexFileName();
        }

        #endregion "Methods"
    }
}