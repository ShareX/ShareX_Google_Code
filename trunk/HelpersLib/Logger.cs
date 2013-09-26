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

using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace HelpersLib
{
    public class Logger
    {
        public delegate void MessageAddedEventHandler(string message);
        public event MessageAddedEventHandler MessageAdded;

        /// <summary>{0} = DateTime, {1} = Message</summary>
        public string MessageFormat { get; set; }

        /// <summary>{0} = Message, {1} = Exception</summary>
        public string ExceptionFormat { get; set; }

        /// <summary>{0} = Message, {1} = Elapsed miliseconds</summary>
        public string TimerMessageFormat { get; set; }

        private readonly object loggerLock = new object();
        private StringBuilder sbMessages;
        private int lastSaveIndex;

        public Logger()
        {
            sbMessages = new StringBuilder(4096);
            MessageFormat = "{0:yyyy-MM-dd HH:mm:ss.fff} - {1}";
            ExceptionFormat = "{0}:\r\n{1}";
            TimerMessageFormat = "{0} - {1} ms";
        }

        protected void OnMessageAdded(string message)
        {
            if (MessageAdded != null)
            {
                MessageAdded(message);
            }
        }

        public void WriteLine(string message = "")
        {
            lock (loggerLock)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    message = string.Format(MessageFormat, FastDateTime.Now, message);
                }

                sbMessages.AppendLine(message);
                Debug.WriteLine(message);
                OnMessageAdded(message);
            }
        }

        public void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }

        public void WriteException(string exception, string message = "Exception")
        {
            WriteLine(string.Format(ExceptionFormat, message, exception));
        }

        public void WriteException(Exception exception, string message = "Exception")
        {
            WriteException(exception.ToString(), message);
        }

        public LoggerTimer StartTimer(string startMessage = null)
        {
            if (!string.IsNullOrEmpty(startMessage))
            {
                WriteLine(startMessage);
            }

            return new LoggerTimer(this, TimerMessageFormat);
        }

        public void SaveLog(string filepath)
        {
            lock (loggerLock)
            {
                if (sbMessages != null && sbMessages.Length > 0 && !string.IsNullOrEmpty(filepath))
                {
                    string messages = sbMessages.ToString(lastSaveIndex, sbMessages.Length - lastSaveIndex);

                    if (!string.IsNullOrEmpty(messages))
                    {
                        Helpers.CreateDirectoryIfNotExist(filepath);

                        File.AppendAllText(filepath, messages, Encoding.UTF8);

                        lastSaveIndex = sbMessages.Length;
                    }
                }
            }
        }

        public void Clear()
        {
            lock (loggerLock)
            {
                sbMessages.Length = 0;
                lastSaveIndex = 0;
            }
        }

        public override string ToString()
        {
            lock (loggerLock)
            {
                if (sbMessages != null && sbMessages.Length > 0)
                {
                    return sbMessages.ToString();
                }

                return null;
            }
        }
    }

    public class LoggerTimer
    {
        private Logger logger;
        private string format;
        private Stopwatch timer;

        public LoggerTimer(Logger logger, string format)
        {
            this.logger = logger;
            this.format = format;
            timer = Stopwatch.StartNew();
        }

        public void WriteLineTime(string message = "Timer")
        {
            logger.WriteLine(format, message, timer.ElapsedMilliseconds);
        }
    }
}