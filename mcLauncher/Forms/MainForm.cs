using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.Launcher.Core;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace craftersmine.Launcher.Forms
{
    public partial class MainForm : Form
    {
        string currentVer;
        string newestVer;
        string _selClnt;

        public MainForm()
        {
            WebClient wc = new WebClient();
            InitializeComponent();
            if (LauncherSettings.LauncherTitle != "")
            {
                headerTitle.Text = LauncherSettings.LauncherTitle;
                if (LauncherSettings.IsLauncherTextsBlack)
                {
                    headerTitle.ForeColor = Color.Black;
                    welcomelab.ForeColor = Color.Black;
                    clntlab.ForeColor = Color.Black;
                }

                else
                {
                    headerTitle.ForeColor = Color.White;
                    welcomelab.ForeColor = Color.White;
                    clntlab.ForeColor = Color.White;
                }
            }
            news.ForeColor = LauncherSettings.NewsColor;
            string[] clients_s = wc.DownloadString(LauncherSettings.Protocol + "://" + LauncherSettings.Domain + "/" + LauncherSettings.DirOnServer + "/getClients.php").Split(new string[] { "<br/>" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var client in clients_s)
            {
                clients.Items.Add(client.Split('|')[0]);
            }
            if (Data.SettingsMngr.SelectedClient != string.Empty && Data.SettingsMngr.SelectedClient != null)
            {
                clients.SelectedItem = Data.SettingsMngr.SelectedClient;
                run.Enabled = true;
            }
            else
                run.Enabled = false;
            welcomelab.Text += Data.SettingsMngr.Login;
            news.Text = Data.News;
        }

        List<string> list = new List<string>();
        int i, percent;
        WebClient Downloader = new WebClient();

        void Download()
        {
            if (list != null)
                try
                {
                    Logger.Log("Downloading " + list[i] + "...", "INFO");
                    currFile.Text = list[i];
                    Downloader.DownloadFileAsync(new Uri(LauncherSettings.Protocol + "://" + LauncherSettings.Domain + "/" + LauncherSettings.DirOnServer + "/clients/" + Data.SelectedClient + list[i]), ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + list[i].Replace("/","\\"));
                }
                catch (Exception ex) { throw ex; }
        }

        private void run_Click(object sender, EventArgs e1)
        {
            _selClnt = clients.SelectedItem.ToString();
            progressBar.Visible = true;
            progressBar1.Visible = true;
            run.Visible = false;
            currFile.Visible = true;
            unlog.Visible = false;
            clients.Enabled = false;
            settings.Visible = false;
            Data.SettingsMngr.SelectedClient = _selClnt;
            Data.SettingsMngr.Save();
            try
            {
                WebClient wc = new WebClient();
                Logger.Log("Gathering filelist...", "INFO");
                string[] listed = wc.DownloadString(LauncherSettings.Protocol + "://" + LauncherSettings.Domain + "/" + LauncherSettings.DirOnServer + "/getClientFiles.php?client=" + _selClnt).Split(new string[] { "<br/>" }, StringSplitOptions.RemoveEmptyEntries);
                Logger.Log("Gathering latest client version...", "INFO");
                newestVer = wc.DownloadString(LauncherSettings.Protocol + "://" + LauncherSettings.Domain + "/" + LauncherSettings.DirOnServer + "/clients.php?client=" + _selClnt).Split('|')[0];
                string mcVer = wc.DownloadString(LauncherSettings.Protocol + "://" + LauncherSettings.Domain + "/" + LauncherSettings.DirOnServer + "/clients.php?client=" + _selClnt).Split('|')[1];
                Data.SelectedClient = _selClnt;
                list.AddRange(listed);
                if (File.Exists(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\version.build"))
                {
                    currentVer = File.ReadAllText(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\version.build");
                    if ((currentVer != newestVer) || Data.SettingsMngr.RedownloadClient)
                    {
                        Logger.Log("Found latest client update or client redownloading....", "INFO");
                        if (Directory.Exists(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient))
                            DeleteDirectory(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient);
                        Directory.CreateDirectory(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin");
                        Directory.CreateDirectory(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\coremods");
                        Directory.CreateDirectory(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\mods");
                        Download();
                        i = 0;
                        Downloader.DownloadProgressChanged += (args, e) =>
                        {
                            progressBar1.Value = percent + (int)(e.ProgressPercentage / list.Count);
                            progressBar.Value = e.ProgressPercentage;
                        };

                        Downloader.DownloadFileCompleted += (args, e) =>
                        {
                            percent = progressBar1.Value;
                            if (++i < list.Count) Download();
                            else
                            {
                                progressBar.Value = progressBar.Maximum;
                                progressBar1.Value = progressBar1.Maximum;
                                currFile.Text = "Загрузка завершена! Запуск...";

                                try
                                {
                                    Logger.Log("Extracting natives...", "INFO");
                                    new FastZip().ExtractZip(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin\\natives.zip", ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin\\", null);
                                    if (File.Exists(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin\\natives.zip"))
                                        File.Delete(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin\\natives.zip");
                                    Logger.Log("Extracting natives... Done!", "FINE");
                                    Logger.Log("Extracting package...", "INFO");
                                    new FastZip().ExtractZip(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\client.zip", ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\", null);
                                    if (File.Exists(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\client.zip"))
                                        File.Delete(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\client.zip");
                                    Logger.Log("Extracting package... Done!", "FINE");
                                    File.WriteAllText(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\version.build", newestVer);
                                    Logger.Log("Running Minecraft...", "INFO");
                                    Data.SettingsMngr.RedownloadClient = false;
                                    Data.SettingsMngr.Save();
                                    Login.RunMinecraft(Data.SelectedClient, new Version(mcVer));
                                }
                                catch
                                {
                                    progressBar.Visible = false;
                                    progressBar1.Visible = false;
                                    run.Visible = true;
                                    currFile.Visible = false;
                                    unlog.Visible = true;
                                    clients.Enabled = true;
                                    settings.Visible = true;
                                    currFile.Text = "";
                                    MessageBox.Show("Ошибка при распаковке архивов! Повторите загрузку или свяжитесь с администратором!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                        };
                    }
                    else
                    {
                        Login.RunMinecraft(Data.SelectedClient, new Version(mcVer));
                    }
                }
                else
                {
                    if (Directory.Exists(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient))
                        DeleteDirectory(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient);
                    Directory.CreateDirectory(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin");
                    Directory.CreateDirectory(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\coremods");
                    Directory.CreateDirectory(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\mods");
                    Download();
                    i = 0;
                    Downloader.DownloadProgressChanged += (args, e) =>
                    {
                        progressBar1.Value = percent + (int)(e.ProgressPercentage / list.Count);
                        progressBar.Value = e.ProgressPercentage;
                    };

                    Downloader.DownloadFileCompleted += (args, e) =>
                    {
                        percent = progressBar1.Value;
                        if (++i < list.Count) Download();
                        else
                        {
                            progressBar.Value = progressBar.Maximum;
                            progressBar1.Value = progressBar1.Maximum;
                            currFile.Text = "Загрузка завершена! Запуск...";

                            try
                            {
                                Logger.Log("Extracting natives...", "INFO");
                                new FastZip().ExtractZip(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin\\natives.zip", ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin\\", null);
                                if (File.Exists(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin\\natives.zip"))
                                    File.Delete(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\bin\\natives.zip");
                                Logger.Log("Extracting package...", "INFO");
                                new FastZip().ExtractZip(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\client.zip", ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\", null);
                                if (File.Exists(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\client.zip"))
                                    File.Delete(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\client.zip");
                                File.WriteAllText(ClientFolder.GetClientsFolder() + "\\" + Data.SelectedClient + "\\version.build", newestVer);
                                Logger.Log("Running Minecraft...", "INFO");
                                Data.SettingsMngr.RedownloadClient = false;
                                Data.SettingsMngr.Save();
                                Login.RunMinecraft(Data.SelectedClient, new Version(mcVer));
                            }
                            catch (Exception ex)
                            {
                                progressBar.Visible = false;
                                progressBar1.Visible = false;
                                run.Visible = true;
                                currFile.Visible = false;
                                unlog.Visible = true;
                                clients.Enabled = true;
                                settings.Visible = true;
                                currFile.Text = "";
                                MessageBox.Show("Ошибка при распаковке архивов! Повторите загрузку или свяжитесь с администратором!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };
                }
            }
            catch(Exception ex)
            {
                progressBar.Visible = false;
                progressBar1.Visible = false;
                run.Visible = true;
                currFile.Visible = false;
                unlog.Visible = true;
                clients.Enabled = true;
                settings.Visible = true;
                MessageBox.Show("Произошла неопознаная ошибка во время работы лаунчера! Отправьте данную информацию администраторам для диагностики ошибки: " + ex.Message + "\r\nТрассировка стека: \r\n" + ex.StackTrace);
            }
        }

        private void clients_MouseUp(object sender, EventArgs e)
        {
            if (/*clients.SelectedValue.ToString() == string.Empty || */clients.SelectedItem == null)
                run.Enabled = false;
            else run.Enabled = true;
        }

        private void site_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(LauncherSettings.Protocol + "://" + LauncherSettings.Domain + "/");
        }

        private void settings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public static void DeleteDirectory(string path)
        {
            string[] subdirs = Directory.GetDirectories(path);
            if (subdirs.Length != 0)
            {
                foreach (string subdir in subdirs)
                {
                    DeleteDirectory(subdir);
                    Logger.Log("Deleting " + subdir, "INFO");
                }
            }

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                File.Delete(file);
                Logger.Log("Deleting " + file, "INFO");
            }

            Directory.Delete(path);
        }

        private Point mouse_offset;

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void unlog_Click(object sender, EventArgs e)
        {
            Logger.Log("Unlogging user...", "INFO");
            Data.SettingsMngr.Login = "";
            Data.SettingsMngr.Password = "";
            Data.SettingsMngr.Save();
            Application.Restart();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button2, "Закрыть");
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button3, "Свернуть");
        }

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
            }
        }
    }
}
