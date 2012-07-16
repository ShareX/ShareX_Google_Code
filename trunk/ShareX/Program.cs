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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using HelpersLib;
using SingleInstanceApplication;
using UploadersLib;

namespace ShareX
{
    internal static class Program
    {
        public static readonly string ApplicationName = Application.ProductName;
        public static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        #region Paths

        private static readonly string DefaultPersonalPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ApplicationName);
        private static readonly string PortablePersonalPath = Path.Combine(Application.StartupPath, ApplicationName);
        private static readonly string SettingsFileName = ApplicationName + "Settings.json";
        private static readonly string UploadersConfigFileName = "UploadersConfig.json";
        private static readonly string LogFileName = ApplicationName + "-Log-{0}-{1}.txt";

        public static string PersonalPath
        {
            get
            {
                if (IsPortable)
                {
                    return PortablePersonalPath;
                }

                return DefaultPersonalPath;
            }
        }

        public static string SettingsFilePath
        {
            get
            {
                if (!IsSandbox)
                {
                    return Path.Combine(PersonalPath, SettingsFileName);
                }

                return null;
            }
        }

        public static string UploadersConfigFilePath
        {
            get
            {
                if (!IsSandbox)
                {
                    if (Settings != null && Settings.UseCustomUploadersConfigPath && !string.IsNullOrEmpty(Settings.CustomUploadersConfigPath))
                    {
                        return Settings.CustomUploadersConfigPath;
                    }

                    return Path.Combine(PersonalPath, UploadersConfigFileName);
                }

                return null;
            }
        }

        public static string HistoryFilePath
        {
            get
            {
                if (Settings != null && Settings.UseCustomHistoryPath && !string.IsNullOrEmpty(Settings.CustomHistoryPath))
                {
                    return Settings.CustomHistoryPath;
                }

                return Path.Combine(PersonalPath, "History.xml");
            }
        }

        public static string OldHistoryFilePath
        {
            get
            {
                if (Settings != null && Settings.UseCustomHistoryPath && !string.IsNullOrEmpty(Settings.CustomHistoryPath))
                {
                    return Settings.CustomHistoryPath;
                }

                return Path.Combine(PersonalPath, "UploadersHistory.xml");
            }
        }

        private static string LogParentFolder
        {
            get
            {
                return Path.Combine(PersonalPath, "Logs"); ;
            }
        }

        public static string LogFilePath
        {
            get
            {
                DateTime now = FastDateTime.Now;
                return Path.Combine(LogParentFolder, string.Format(LogFileName, now.Year, now.Month));
            }
        }

        private static string ScreenshotsParentFolder
        {
            get
            {
                if (Settings != null && Settings.UseCustomScreenshotsPath && !string.IsNullOrEmpty(Settings.CustomScreenshotsPath))
                {
                    return Settings.CustomScreenshotsPath;
                }

                return Path.Combine(PersonalPath, "Screenshots");
            }
        }

        public static string ScreenshotsPath
        {
            get
            {
                string subFolderName = new NameParser(NameParserType.FolderPath).Convert(Settings.SaveImageSubFolderPattern);
                return Path.Combine(ScreenshotsParentFolder, subFolderName);
            }
        }

        #endregion Paths

        public static Settings Settings { get; private set; }
        public static UploadersConfig UploadersConfig { get; private set; }
        public static bool IsMultiInstance { get; private set; }
        public static bool IsPortable { get; private set; }
        public static bool IsSilentRun { get; private set; }
        public static bool IsDebug { get; private set; }
        public static bool IsHotkeysAllowed { get; private set; }
        public static bool IsSandbox { get; private set; }
        public static Stopwatch StartTimer { get; private set; }
        public static Logger MyLogger { get; private set; }

        public static string Title
        {
            get
            {
                string title = string.Format("{0} {1}.{2}", ApplicationName, AssemblyVersion.Major, AssemblyVersion.Minor);
                if (IsPortable) title += " Portable";
                return title;
            }
        }

        public static string FullTitle
        {
            get
            {
                string title = string.Format("{0} {1}.{2}.{3}.{4}", ApplicationName, AssemblyVersion.Major, AssemblyVersion.Minor, AssemblyVersion.Build, AssemblyVersion.Revision);
                if (IsPortable) title += " Portable";
                return title;
            }
        }

        public static MainForm mainForm;
        public static ManualResetEvent SettingsResetEvent;
        public static ManualResetEvent UploaderSettingsResetEvent;

        [STAThread]
        private static void Main(string[] args)
        {
            StartTimer = Stopwatch.StartNew();

            IsMultiInstance = CLIHelper.CheckArgs(args, "multi", "m");

            if (!IsMultiInstance && !ApplicationInstanceManager.CreateSingleInstance(SingleInstanceCallback))
            {
                return;
            }

            Mutex mutex = null;

            try
            {
                mutex = new Mutex(false, @"Global\82E6AC09-0FEF-4390-AD9F-0DD3F5561EFC"); // Required for installer

                IsSilentRun = CLIHelper.CheckArgs(args, "silent", "s");
                IsPortable = CLIHelper.CheckArgs(args, "portable", "p");

                if (IsPortable && !Directory.Exists(PortablePersonalPath))
                {
                    Directory.CreateDirectory(PortablePersonalPath);
                }

                IsDebug = CLIHelper.CheckArgs(args, "debug", "d");
                IsHotkeysAllowed = !CLIHelper.CheckArgs(args, "nohotkeys");
                IsSandbox = CLIHelper.CheckArgs(args, "sandbox");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                MyLogger = new Logger();
                DebugHelper.MyLogger = MyLogger;
                MyLogger.WriteLine("{0} started", Title);
                MyLogger.WriteLine("Operating system: " + Environment.OSVersion.VersionString);
                MyLogger.WriteLine("CommandLine: " + Environment.CommandLine);

                SettingsResetEvent = new ManualResetEvent(false);
                UploaderSettingsResetEvent = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(state => LoadSettings());

                MyLogger.WriteLine("new MainForm() started");
                mainForm = new MainForm();
                MyLogger.WriteLine("new MainForm() finished");

                if (Settings == null)
                {
                    SettingsResetEvent.WaitOne();
                }

                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.Run(mainForm);

                Settings.Save();

                MyLogger.WriteLine("ShareX closing");
                MyLogger.SaveLog(LogFilePath);
            }
            finally
            {
                if (mutex != null)
                {
                    mutex.Close();
                }
            }
        }

        public static void LoadSettings()
        {
            Settings = Settings.Load(SettingsFilePath);
            SettingsResetEvent.Set();
            LoadUploadersConfig();
            UploaderSettingsResetEvent.Set();
        }

        public static void LoadUploadersConfig()
        {
            UploadersConfig = UploadersConfig.Load(UploadersConfigFilePath);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            OnError(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            OnError((Exception)e.ExceptionObject);
        }

        private static void OnError(Exception e)
        {
            new ErrorForm(Application.ProductName, e, MyLogger, LogFilePath, Links.URL_ISSUES).ShowDialog();
        }

        private static void SingleInstanceCallback(object sender, InstanceCallbackEventArgs args)
        {
            if (WaitFormLoad(5000))
            {
                Action d = () =>
                {
                    if (mainForm.Visible)
                    {
                        mainForm.ShowActivate();
                    }

                    mainForm.UseCommandLineArgs(args.CommandLineArgs);
                };

                mainForm.Invoke(d);
            }
        }

        private static bool WaitFormLoad(int wait)
        {
            Stopwatch timer = Stopwatch.StartNew();

            while (timer.ElapsedMilliseconds < wait)
            {
                if (mainForm != null && mainForm.IsReady) return true;

                Thread.Sleep(10);
            }

            return false;
        }
    }
}