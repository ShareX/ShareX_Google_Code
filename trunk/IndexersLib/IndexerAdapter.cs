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
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ZSS.IndexersLib
{
    //*******************************
    //* Reads .tgc files and returns
    //* a Config object with settings
    //*******************************
    public class IndexerAdapter
    {
        private const string MSG_INIT_SERVICE = "Initialized using McoreIndexer Service";
        private const string MSG_INIT_TREEGUI = "Initialized using TreeGUI";
        private const string MSG_DATETIME_BASED = "Date and Time based Schedule.";
        private const string MSG_MANUAL = "Manual Operation";

        private IndexerConfig mConfig = new IndexerConfig();
        private AppSettings mOptions = new AppSettings();
        private int m_Count = 0;
        private bool m_isUpgraded = false;

        public readonly string OPTIONS_DIR = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\TreeGUI";
        public const string OPTIONS_FILE_EXT = ".xml";
        private readonly string OPTIONS_FILENAME = "\\TreeGUI" + OPTIONS_FILE_EXT;

        public string LOG_PATH_ONSTART = Application.StartupPath + "\\log";
        public string LOG_PATH_READER = Application.StartupPath + "\\Reader.log";

        public string LogPathIndexer
        {
            get { return GetOptions().TasksFolderPath + "\\Indexer.log"; }
        }

        public string LogPathDebug
        {
            get { return GetOptions().TasksFolderPath + "\\Debug.log"; }
        }

        public string GetOptionsFilePath()
        {
            string strStandaloneOptionsPath = Application.StartupPath + OPTIONS_FILENAME;
            if (File.Exists(strStandaloneOptionsPath))
            {
                return strStandaloneOptionsPath;
            }
            else
            {
                Directory.CreateDirectory(OPTIONS_DIR);
                return OPTIONS_DIR + OPTIONS_FILENAME;
            }
        }

        public string CurrentConfigFilePath { get; set; }

        public InitializationMode mInitMode = InitializationMode.MANUAL;

        public string fGetIndexFilePath(int folderID, IndexingMode mode)
        {
            //Dim strDirPath As String = GetConfig().FolderList.Item(folderID)
            string lPath = string.Empty;
            // strDirPath + "\" + GetConfig().GetIndexFileName

            switch (mode)
            {
                case IndexingMode.IN_ONE_FOLDER_SEPERATE:
                    string strDirPath = GetConfig().FolderList[folderID];
                    string sDrive = Path.GetPathRoot(strDirPath).Substring(0, 1);
                    string sDirName = Path.GetFileName(strDirPath);
                    string sep = GetOptions().IndividualIndexFileWordSeperator;
                    if (Directory.Exists(GetConfig().OutputDir))
                    {
                        lPath = GetConfig().OutputDir + Path.DirectorySeparatorChar + sDirName + sep + sDrive + sep + GetConfig().GetIndexFileName();
                    }
                    break;
                case IndexingMode.IN_EACH_DIRECTORY:
                    // this is also what it is first initialized to
                    strDirPath = GetConfig().FolderList[folderID];
                    lPath = strDirPath + "\\" + GetConfig().GetIndexFileName();
                    break;
                default:
                    lPath = GetConfig().GetIndexFilePath();
                    break;
            }

            return lPath;
        }

        public void ZipAdminFile(string strFile, List<string> filesExtra)
        {
            if (File.Exists(strFile))
            {
                if (GetConfig().ZipAfterIndexed == true)
                {
                    try
                    {
                        string zipFilePath = Path.ChangeExtension(strFile, ".zip");
                        if (File.Exists(zipFilePath)) File.Delete(zipFilePath);

                        if (filesExtra == null)
                        {
                            filesExtra = new List<string>();
                        }
                        if (strFile != null)
                        {
                            filesExtra.Add(strFile);
                        }

                        ICSharpCode.SharpZipLib.Zip.ZipOutputStream strmZipOutputStream = default(ICSharpCode.SharpZipLib.Zip.ZipOutputStream);
                        strmZipOutputStream = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(File.Create(zipFilePath));

                        if (GetConfig().CollapseFolders)
                        {
                            // minus.gif
                            string f1 = Application.StartupPath + Path.DirectorySeparatorChar + "plus.gif";
                            if (File.Exists(f1)) filesExtra.Add(f1);
                            string f2 = Application.StartupPath + Path.DirectorySeparatorChar + "minus.gif";
                            if (File.Exists(f2)) filesExtra.Add(f2);
                        }

                        if (File.Exists(GetConfig().LogoPath))
                        {
                            filesExtra.Add(GetConfig().LogoPath);
                        }

                        foreach (string filePath in filesExtra)
                        {
                            FileStream strmFile = File.OpenRead(filePath);
                            byte[] abyBuffer = new byte[(int)strmFile.Length - 1 + 1];
                            strmFile.Read(abyBuffer, 0, abyBuffer.Length);

                            ICSharpCode.SharpZipLib.Zip.ZipEntry objZipEntry = new ICSharpCode.SharpZipLib.Zip.ZipEntry(Path.GetFileName(filePath));
                            objZipEntry.DateTime = DateTime.Now;
                            objZipEntry.Size = strmFile.Length;
                            strmFile.Close();

                            strmZipOutputStream.PutNextEntry(objZipEntry);

                            strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length);
                        }

                        ///'''''''''''''''''''''''''''''''''
                        // Finally Close strmZipOutputStream
                        ///'''''''''''''''''''''''''''''''''
                        strmZipOutputStream.Finish();
                        strmZipOutputStream.Close();

                        if (GetConfig().ZipAndDeleteFile == true)
                        {
                            File.Delete(strFile);
                        }
                    }
                    catch (System.UnauthorizedAccessException ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
            }
        }

        public Process StartHiddenProcess(string filePath, bool wait)
        {
            Process proc = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(filePath);
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo = psi;
            proc.Start();
            if (wait) proc.WaitForExit();
            return proc;
        }

        public bool IsConfigFileReadOnly(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileInfo fi = new FileInfo(filePath);
                bool isReadOnly = ((File.GetAttributes(filePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
                return isReadOnly;
            }
            else
            {
                return false;
            }
        }

        public bool Upgraded
        {
            get { return m_isUpgraded; }
        }

        public IndexerConfig GetConfig()
        {
            return mConfig;
        }

        public AppSettings GetOptions()
        {
            return mOptions;
        }

        private string RenameFile(string filePath, string oldFileName, int i)
        {
            try
            {
                //MessageBox.Show(oldFileName + i.ToString())
                File.Move(filePath, oldFileName + i.ToString());
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.ToString());
                m_Count = m_Count + 1;
                RenameFile(filePath, oldFileName, m_Count);
            }

            return oldFileName + m_Count.ToString();
        }

        public void WriteOptionsFile()
        {
            try
            {
                WriteOptionsFileXML(GetOptionsFilePath());
            }
            catch (UnauthorizedAccessException ex)
            {
                if ((MessageBox.Show(ex.Message + "\nDo you want to browse for the Options file to change Security Settings?",
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    Process.Start(Path.GetDirectoryName(GetOptionsFilePath()));
                }
            }
        }

        private void WriteOptionsFileBF(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, GetOptions());
            fs.Close();
        }

        private void WriteOptionsFileXML(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(GetOptions().GetType());
                xs.Serialize(fs, GetOptions());
            }
        }

        public void LoadOptionsFile(string filePath)
        {
            if (LoadOptionsFileXML(filePath) == false)
            {
                if (LoadOptionsFileBF(filePath) == false)
                {
                    mOptions = new AppSettings();
                }
            }

            // Since v2.4.0.3
            // Internal Logic to Determine if Date&Time Indexing is
            // Scheduled for Today
            // 2.4.0.3 IsScheduledForToday was determined from CheckBoxes rather than XML

            if (mOptions.OnMonday & DateTime.Now.DayOfWeek.ToString() == "Monday" |
                mOptions.OnTuesday & DateTime.Now.DayOfWeek.ToString() == "Tuesday" |
                mOptions.OnWednesday & DateTime.Now.DayOfWeek.ToString() == "Wednesday" |
                mOptions.OnThursday & DateTime.Now.DayOfWeek.ToString() == "Thursday" |
                mOptions.OnFriday & DateTime.Now.DayOfWeek.ToString() == "Friday" |
                mOptions.OnSaturday & DateTime.Now.DayOfWeek.ToString() == "Saturday" |
                mOptions.OnSunday & DateTime.Now.DayOfWeek.ToString() == "Sunday")
            {
                mOptions.IsScheduledForToday = true;
            }
            else
            {
                mOptions.IsScheduledForToday = false;
            }
        }

        private bool LoadOptionsFileXML(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xs = new XmlSerializer(GetOptions().GetType());
                    mOptions = xs.Deserialize(fs) as AppSettings;
                    fs.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        private bool LoadOptionsFileBF(string filePath)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                mOptions = bf.Deserialize(fs) as AppSettings;
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public void LoadNewConfig()
        {
            mConfig = new IndexerConfig();
        }

        public void LoadConfig(IndexerConfig config)
        {
            mConfig = config;
        }

        public void LoadConfigFile(string filePath)
        {
            this.CurrentConfigFilePath = filePath;

            if (mConfig.IndexingEngineType == IndexingEngine.TreeLib & mConfig.IndexFileExt.Contains("html"))
            {
                mConfig.IndexFileExt = ".txt";
            }
        }

        private bool LoadConfigFileBF(string filePath)
        {
            if (File.Exists(filePath))
            {
                Debug.WriteLine("Accessed BF TGC Reader...");

                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                try
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    mConfig = (IndexerConfig)bf.Deserialize(fs);
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    fs.Close();
                    return false;
                }
                finally
                {
                    fs.Close();
                }
            }
            return false;
        }

        public string GetFooterText(string myCurrentIndexFilePath, IndexingEngine myEngine, bool html)
        {
            string appName = string.Format("{0} v{1}", Application.ProductName, Application.ProductVersion);
            string appUrl = "http://code.google.com/p/zscreen";

            string strDateTime;

            if (mOptions.IndexedTimeInUTC)
            {
                strDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd 'at' HH:mm:ss 'UTC'");
            }
            else
            {
                strDateTime = DateTime.Now.ToString("yyyy-MM-dd 'at ' HH:mm:ss 'local time'");
            }

            if (html)
            {
                appName = Xhtml.MakeAnchor(appUrl, appName);
            }

            string footer = string.Format("Generated on {0} using {1}", strDateTime, appName);
            if (html)
            {
                if (mConfig.ShowValidXhtmlIcons)
                {
                    footer += GetText("valid_xhtml.txt");
                }
            }
            else
            {
                footer += "\r\nLatest version of can be downloaded from " + appUrl;
            }

            switch (myEngine)
            {
                case IndexingEngine.TreeLib:
                    return "ECHO " + footer + " >> " + (char)34 + myCurrentIndexFilePath + (char)34;
                default:
                    return footer;
            }
        }

        public string getBlankLine(string myCurrentIndexFilePath)
        {
            return string.Format("ECHO ____") + " >> " + (char)34 + myCurrentIndexFilePath + (char)34;
        }

        public string getNextScheduledRunTime()
        {
            return string.Format("Next Scheduled Run Time: {0}", DateTime.Now.AddMinutes(mOptions.IndexingInterval).ToString("yyyy-MM-dd 'at' HH:mm:ss"));
        }

        public double getIntervalInMilliseconds()
        {
            return this.GetOptions().IndexingInterval * 60 * 1000;
        }

        public void WriteEventLog(List<string> folderList, InitializationMode myInitMode)
        {
            try
            {
                EventLog MyLog = new EventLog(Application.ProductName);
                // create a new event log
                // Check if the the Event Log Exists
                if (!EventLog.SourceExists("TreeGUI"))
                {
                    // Create Log
                    EventLog.CreateEventSource("TreeGUI", "TreeGUI Log");
                }
                MyLog.Source = "TreeGUI";

                string log = null;
                for (int i = 0; i <= folderList.Count - 1; i++)
                {
                    log += "Indexed " + folderList[i] + "\n";
                }

                switch (myInitMode)
                {
                    case InitializationMode.MANUAL:
                        log += "\n" + MSG_MANUAL;
                        break;
                    case InitializationMode.INTERVAL_BASED_SERVICE:
                        log += "\n" + getNextScheduledRunTime();
                        log += "\n" + MSG_INIT_SERVICE;
                        break;
                    case InitializationMode.INTERVAL_BASED_GUI:
                        log += "\n" + getNextScheduledRunTime();
                        log += "\n" + MSG_INIT_TREEGUI;
                        break;
                    case InitializationMode.DATETIME_BASED_SERVICE:
                        log += "\n" + MSG_DATETIME_BASED;
                        log += "\n" + MSG_INIT_SERVICE;
                        break;
                    case InitializationMode.DATETIME_BASED_GUI:
                        log += "\n" + MSG_DATETIME_BASED;
                        log += "\n" + MSG_INIT_TREEGUI;
                        break;
                }

                // BUG: 2.2.3.3 Writing Event Log while logged on as Limited caused program crash

                EventLog.WriteEntry("TreeGUI Log", log, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public static string GetText(string name)
        {
            string text = "";
            try
            {
                System.Reflection.Assembly oAsm = System.Reflection.Assembly.GetExecutingAssembly();

                string fn = "";
                foreach (string n in oAsm.GetManifestResourceNames())
                {
                    if (n.EndsWith("." + name))
                    {
                        fn = n;
                        break;
                    }
                }
                Stream oStrm = oAsm.GetManifestResourceStream(fn);
                StreamReader oRdr = new StreamReader(oStrm);
                text = oRdr.ReadToEnd();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return text;
        }

        public static void CopyDefaultCss(string destDir)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(destDir, IndexerConfig.DefaultCssFileName)))
            {
                sw.WriteLine(GetText(IndexerConfig.DefaultCssFileName));
            }
        }
    }
}