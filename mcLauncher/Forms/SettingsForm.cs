using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using craftersmine.Launcher.Core;

namespace craftersmine.Launcher.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            mem.Text = Data.SettingsMngr.Memory;
            reDwnld.Checked = Data.SettingsMngr.RedownloadClient;
        }

        private void mem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.SettingsMngr.Memory = mem.Text;
            Data.SettingsMngr.RedownloadClient = reDwnld.Checked;
            Data.SettingsMngr.Save();
            Data.Memory = mem.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
