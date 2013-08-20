using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelpersLib
{
    public partial class DebugForm : Form
    {
        public DebugForm(string appName, Logger MyLogger)
        {
            InitializeComponent();

            this.Text = appName + " - Debug log";
            txtDebugLog.Text = MyLogger.Messages.ToString();
            txtDebugLog.ScrollToCaret();
        }
    }
}