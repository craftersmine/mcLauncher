using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.Launcher.Forms;
using craftersmine.Launcher.Core;
using System.Net;

namespace craftersmine.Launcher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Log("Starting bootstrap...", "INFO");
            Data.SettingsMngr = new Properties.Settings();
            Data.SettingsMngr.Save();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Logger.Log("Gathering info from server...", "INFO");
                WebClient wc = new WebClient();
                Logger.Log("Loading news...", "INFO");
                Data.News = wc.DownloadString(LauncherSettings.Protocol + "://" + LauncherSettings.Domain + "/" + LauncherSettings.DirOnServer + "/news.txt");
                LoginForm lf = new LoginForm();
                MainForm mf = new MainForm();
                Logger.Log("Checking launcher updates...", "INFO");
                string lv = wc.DownloadString(LauncherSettings.Protocol + "://" + LauncherSettings.Domain + "/" + LauncherSettings.DirOnServer + "/getVersion.php");
                if (LauncherSettings.Version != lv)
                {
                    var dlg = MessageBox.Show("Обнаружена более новая версия лаунчера! Для продолжения обновите лаунчер! Открыть страницу обновления?");
                    switch (dlg)
                    {
                        case DialogResult.Yes:
                            System.Diagnostics.Process.Start(LauncherSettings.UpdatePage);
                            break;
                        default: Environment.Exit(0); break;
                    }
                }
                Logger.Log("Logging in...", "INFO");
                if (string.IsNullOrEmpty(Data.SettingsMngr.Login) || string.IsNullOrEmpty(Data.SettingsMngr.Password))
                    Application.Run(lf);
                else { Data.Session = Login.LoginSession(Data.SettingsMngr.Login, Data.SettingsMngr.Password).UserSession; Application.Run(mf); }
            }
            catch (WebException ex)
            {
                Logger.Log("Unable to connect server!", "ERROR");
                MessageBox.Show("Произошла ошибка подключения к серверу! Проверьте соединение и повторите снова. " + ex.Message , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
    }
}
