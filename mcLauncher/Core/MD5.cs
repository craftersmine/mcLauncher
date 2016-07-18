using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace craftersmine.Launcher.Core
{
    public sealed class MD5Compute
    {
        public static string ComputeSession(string sessionID)
        {
            Logger.Log("Computing session...", "INFO");
            MD5 _md5 = new MD5CryptoServiceProvider();

            byte[] returned = _md5.ComputeHash(Encoding.UTF8.GetBytes(sessionID));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < returned.Length; i++)
            {
                sb.Append(returned[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static string GetClientFileMD5(string clientFile)
        {
            FileStream file = new FileStream(clientFile, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static bool VerifyClientFileMD5(string hash, string clientFile)
        {
            Logger.Log("Checking file... " + clientFile, "INFO");
            string hashOfInput = GetClientFileMD5(clientFile);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ClientChecker()
        {
            Logger.Log("Checking client...", "INFO");
            Directory.CreateDirectory(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient);
            WebClient _wc = new WebClient();
            string link = "http://" + LauncherSettings.Domain + "/new_Launcher/launcherData/Clients/" + Data.SelectedClient + ".clientmd5";
            _wc.DownloadFile(link, ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient + @"\clnt.md5");
            string[] fileReaded = File.ReadAllLines(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient + @"\clnt.md5");
            File.Delete(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient + @"\clnt.md5");
            //CheckMods();
            try
            {
                foreach (var fileMd5 in fileReaded)
                {
                    string[] splittedLine = fileMd5.Split(':');
                    string path = Path.Combine(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient, splittedLine[1]);
                    if (!File.Exists(path))
                    {
                        break;
                    }
                    else
                    {
                        if (!VerifyClientFileMD5(splittedLine[0], path))
                        {
                            Logger.Log("Founded incorrect client file! " + splittedLine[0] + " Removing a client and redownloading client!", "WARN");
                            if (File.Exists(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient + @"\installed"))
                                DeleteDirectory(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient);
                            File.Delete(path);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static void CheckMods()
        {
            WebClient _wc = new WebClient();
            string link = "http://" + LauncherSettings.Domain + "/new_Launcher/launcherData/Clients/" + Data.SelectedClient + ".clientlist";
            _wc.DownloadFile(link, ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient + @"\clnt.list");
            string[] fileReaded = File.ReadAllLines(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient + @"\clnt.list");
            try
            {
                DirectoryInfo dimods = new DirectoryInfo(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient + @"\mods");
                FileInfo[] filesmods = dimods.GetFiles();
                foreach (var file in filesmods)
                {
                    foreach (var fileforcheck in fileReaded)
                    {
                        if (file.FullName != ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient + "\\" + fileforcheck)
                        {
                            Logger.Log("Found unknown file! It may be a cheat or invalid file! " + file.Name + " Removing a client and redownloading client!", "WARN");
                            File.Delete(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient + @"\installed");
                            DeleteDirectory(ClientFolder.GetClientsFolder() + @"\" + Data.SelectedClient);
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static void DeleteDirectory(string path)
        {
            string[] subdirs = Directory.GetDirectories(path);
            if (subdirs.Length != 0)
            {
                foreach (string subdir in subdirs)
                {
                    DeleteDirectory(subdir);
                    Console.WriteLine("Deleting " + subdir);
                }
            }

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                File.Delete(file);
                Console.WriteLine("Deleting " + file);
            }

            Directory.Delete(path);

        }
    }
}