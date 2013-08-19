using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShareX
{
    public partial class WorkflowsForm : Form
    {
        public WorkflowsForm()
        {
            InitializeComponent();

            if (Program.IsHotkeysAllowed && Program.MainForm.HotkeyManager != null)
            {
                hmHotkeys.PrepareHotkeys(Program.MainForm.HotkeyManager);
            }
        }
    }
}
