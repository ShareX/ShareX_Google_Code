using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelpersLib.log4netHelpers
{
    public partial class log4netViewer_ListView : Form
    {
        public log4netViewer_ListView()
        {
            InitializeComponent();
            log4netHelper.ConfigureListView(myListViewLog);
        }
    }
}