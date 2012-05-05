using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace HelpersLib
{
    /// <summary>
    /// Description of RichTextBoxAppender.
    /// </summary>
    public class RichTextBoxAppender : AppenderSkeleton
    {
        #region Private Instance Fields

        private RichTextBox richTextBox = null;
        private LevelMapping levelMapping = new LevelMapping();
        private int maxTextLength = 100000;

        #endregion Private Instance Fields

        private delegate void UpdateControlDelegate(LoggingEvent loggingEvent);

        #region Constructor

        public RichTextBoxAppender(RichTextBox myRichTextBox)
            : base()
        {
            richTextBox = myRichTextBox;
        }

        #endregion Constructor

        private void UpdateControl(LoggingEvent loggingEvent)
        {
            if (richTextBox.IsDisposed)
                return;

            // There may be performance issues if the buffer gets too long
            // So periodically clear the buffer
            if (richTextBox.TextLength > maxTextLength)
            {
                richTextBox.Clear();
                richTextBox.AppendText(string.Format("(Cleared log length max: {0})\n", maxTextLength));
            }

            // look for a style mapping
            LevelTextStyle selectedStyle = levelMapping.Lookup(loggingEvent.Level) as LevelTextStyle;
            if (selectedStyle != null)
            {
                // set the colors of the text about to be appended
                richTextBox.SelectionBackColor = selectedStyle.BackColor;
                richTextBox.SelectionColor = selectedStyle.TextColor;

                // alter selection font as much as necessary
                // missing settings are replaced by the font settings on the control
                if (selectedStyle.Font != null)
                {
                    // set Font Family, size and styles
                    richTextBox.SelectionFont = selectedStyle.Font;
                }
                else if (selectedStyle.PointSize > 0 && richTextBox.Font.SizeInPoints != selectedStyle.PointSize)
                {
                    // use control's font family, set size and styles
                    float size = selectedStyle.PointSize > 0.0f ? selectedStyle.PointSize : richTextBox.Font.SizeInPoints;
                    richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily.Name, size, selectedStyle.FontStyle);
                }
                else if (richTextBox.Font.Style != selectedStyle.FontStyle)
                {
                    // use control's font family and size, set styles
                    richTextBox.SelectionFont = new Font(richTextBox.Font, selectedStyle.FontStyle);
                }
            }
            richTextBox.AppendText(RenderLoggingEvent(loggingEvent));
        }

        protected override void Append(LoggingEvent LoggingEvent)
        {
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(
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