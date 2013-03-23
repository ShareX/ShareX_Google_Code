using System;

namespace GreenshotPlugin
{
    // Workaround for removing log4net
    public static class LOG
    {
        public static bool IsDebugEnabled { get { return false; } }

        public static void Warn(string text)
        {
        }

        public static void WarnFormat(string format, params object[] args)
        {
        }

        public static void Warn(Exception e)
        {
        }

        public static void Warn(string text, Exception e)
        {
        }

        public static void Error(string text)
        {
        }

        public static void ErrorFormat(string format, params object[] args)
        {
        }

        public static void Error(Exception e)
        {
        }

        public static void Error(string text, Exception e)
        {
        }

        public static void Info(string text)
        {
        }

        public static void InfoFormat(string format, params object[] args)
        {
        }

        public static void Debug(string text)
        {
        }

        public static void DebugFormat(string text, params object[] args)
        {
        }

        public static void Debug(string text, Exception e)
        {
        }
    }
}