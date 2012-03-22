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
        private static readonly string ApplicationName = Application.ProductName;

        #region Paths

        private static readonly string DefaultPersonalPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ApplicationName);
        private static readonly string PortablePersonalPath = Path.Combine(Application.StartupPath, ApplicationName);

        private static readonly string SettingsFileName = ApplicationName + "Settings.xml";
        private static readonly string HistoryFileName = "UploadersHistory.xml";
        private static readonly string UploadersConfigFileName = "UploadersConfig.xml";
        private static readonly string LogFileName = ApplicationName + "Log-{0}-{1}.txt";

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
                return Path.Combine(PersonalPath, SettingsFileName);
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

                return Path.Combine(PersonalPath, HistoryFileName);
            }
        }

        public static string UploadersConfigFilePath
        {
            get
            {
                if (Settings != null && Settings.UseCustomUploadersConfigPath && !string.IsNullOrEmpty(Settings.CustomUploadersConfigPath))
                {
                    return Settings.CustomUploadersConfigPath;
                }

                return Path.Combine(PersonalPath, UploadersConfigFileName);
            }
        }

        public static string LogFilePath
        {
            get
            {
                DateTime now = FastDateTime.Now;
                return Path.Combine(PersonalPath, string.Format(LogFileName, now.Year, now.Month));
            }
        }

        public static string ScreenshotsPath
        {
            get
            {
                string parentFolderPath = Path.Combine(PersonalPath, "Screenshots");
                string subFolderName = new NameParser(NameParserType.SaveFolder).Convert(Settings.SaveImageSubFolderPattern);
                return Path.Combine(parentFolderPath, subFolderName);
            }
        }

        #endregion Paths

        public static Settings Settings { get; private set; }

        public static UploadersConfig UploadersConfig { get; private set; }

        public static bool IsMultiInstance { get; private set; }

        public static bool IsPortable { get; private set; }

        public static bool IsSilentRun { get; private set; }

        public static Stopwatch StartTimer { get; private set; }

        public static Logger MyLogger { get; private set; }

        public static string Title
        {
            get
            {
                string title = string.Format("{0} {1} r{2}", ApplicationName, Application.ProductVersion, AppRevision);
                if (IsPortable) title += " Portable";
                return title;
            }
        }

        public static string AppRevision
        {
            get
            {
                return AssemblyVersion.Split('.')[3];
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static MainForm mainForm;

        public static ManualResetEvent SettingsResetEvent;
        public static ManualResetEvent UploaderSettingsResetEvent;

        [STAThread]
        private static void Main(string[] args)
        {
            StartTimer = Stopwatch.StartNew();

            IsMultiInstance = CLIHelper.CheckArgs(args, "m", "multi");

            if (!IsMultiInstance && !ApplicationInstanceManager.CreateSingleInstance(SingleInstanceCallback))
            {
                return;
            }

            IsSilentRun = CLIHelper.CheckArgs(args, "s", "silent");

            if (CLIHelper.CheckArgs(args, "p", "portable") && !Directory.Exists(PortablePersonalPath))
            {
                Directory.CreateDirectory(PortablePersonalPath);
            }

            IsPortable = Directory.Exists(PortablePersonalPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MyLogger = new Logger();
            DebugHelper.MyLogger = MyLogger;
            MyLogger.WriteLine("{0} {1} r{2} started", Application.ProductName, Application.ProductVersion, AppRevision);
            MyLogger.WriteLine("Operating system: " + Environment.OSVersion.VersionString);
            MyLogger.WriteLine("CommandLine: " + Environment.CommandLine);
            MyLogger.WriteLine("IsMultiInstance: " + IsMultiInstance);
            MyLogger.WriteLine("IsSilentRun: " + IsSilentRun);
            MyLogger.WriteLine("IsPortable: " + IsPortable);

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
            new ErrorForm(Application.ProductName, e, MyLogger, LogFilePath, ZLinks.URL_ISSUES).ShowDialog();
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