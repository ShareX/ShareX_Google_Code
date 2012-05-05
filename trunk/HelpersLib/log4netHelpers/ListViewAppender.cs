using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelpersLib;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace HelpersLib
{
    /// <summary>
    /// Description of RichTextBoxAppender.
    /// </summary>
    public class ListViewAppender : AppenderSkeleton
    {
        #region Private Instance Fields

        private MyListView _listView = null;
        private LevelMapping levelMapping = new LevelMapping();
        private int maxTextLength = 100000;

        #endregion Private Instance Fields

        private delegate void UpdateControlDelegate(LoggingEvent loggingEvent);

        #region Constructor

        public ListViewAppender(MyListView myListView)
            : base()
        {
            _listView = myListView;
        }

        #endregion Constructor

        private void UpdateControl(LoggingEvent loggingEvent)
        {
            if (_listView.IsDisposed)
                return;

            // There may be performance issues if the buffer gets too long
            // So periodically clear the buffer
            if (_listView.Items.Count > maxTextLength)
            {
                _listView.Items.Clear();
            }

            ListViewItem lvi = new ListViewItem();

            switch (loggingEvent.Level.ToString())
            {
                case "INFO":
                    lvi.ForeColor = System.Drawing.Color.Blue;
                    break;
                case "WARN":
                    lvi.ForeColor = System.Drawing.Color.Orange;
                    break;
                case "ERROR":
                    lvi.ForeColor = System.Drawing.Color.Red;
                    break;
                case "FATAL":
                    lvi.ForeColor = System.Drawing.Color.DarkOrange;
                    break;
                case "DEBUG":
                    lvi.ForeColor = System.Drawing.Color.DarkGreen;
                    break;
                default:
                    lvi.ForeColor = System.Drawing.Color.Black;
                    break;
            }

            lvi.Text = loggingEvent.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss");
            // lvi.SubItems.Add(loggingEvent.UserName);
            lvi.SubItems.Add(loggingEvent.Level.DisplayName);
            lvi.SubItems.Add(loggingEvent.LoggerName);
            // lvi.SubItems.Add(string.Format("{0}.{1}.{2}", loggingEvent.LocationInformation.ClassName, loggingEvent.LocationInformation.MethodName, loggingEvent.LocationInformation.LineNumber));
            lvi.SubItems.Add(loggingEvent.RenderedMessage);
            _listView.Items.Add(lvi);
            lvi.EnsureVisible();
            _listView.FillLastColumn();
        }

        protected override void Append(LoggingEvent LoggingEvent)
        {
            if (_listView.InvokeRequired)
            {
                _listView.Invoke(
                    new UpdateControlDelegate(UpdateControl),
                    new object[] { LoggingEvent });
            }
            else
            {
                UpdateControl(LoggingEvent);
            }
        }

        public void AddMapping(LevelTextStyle mapping)
        {
            levelMapping.Add(mapping);
        }

        public override void ActivateOptions()
        {
            base.ActivateOptions();
            levelMapping.ActivateOptions();
        }

        protected override bool RequiresLayout { get { return true; } }
    }
}