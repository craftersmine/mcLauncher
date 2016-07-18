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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(LauncherSettings.RegisterPage);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(LauncherSettings.LostPassPage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Enabled)
            {
                var dlg = MessageBox.Show("Прервать вход и выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                switch (dlg)
                {
                    case DialogResult.Yes:
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((loginbox.Text == string.Empty && pwdbox.Text == string.Empty) || (loginbox.Text == null && pwdbox.Text == null))
            {
                MessageBox.Show("Вы не ввели логин или пароль. Введите логин и пароль который вы использовали при регистрации на данном проекте", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            loginbox.Enabled = false;
            pwdbox.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Session sess = Login.LoginSession(loginbox.Text, pwdbox.Text);
            if (sess.UserSession == "Bad Login")
            {
                MessageBox.Show("Неверный логин или пароль! Проверьте ввод данных, не нажат ли Caps Lock и повторите попытку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loginbox.Enabled = true;
                pwdbox.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                linkLabel1.Enabled = true;
                linkLabel2.Enabled = true;
                Cursor = Cursors.Default;
            }
            else
            {
                Data.Session = sess.UserSession;
                Cursor = Cursors.Default;
                this.Hide();
                Data.SettingsMngr.Login = loginbox.Text;
                Data.SettingsMngr.Password = pwdbox.Text;
                Data.SettingsMngr.Save();
                this.Enabled = false;
                new MainForm().Show();
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(null, null);
        }
    }
}
