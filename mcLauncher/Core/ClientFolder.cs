using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace craftersmine.Launcher.Core
{
    public sealed class ClientFolder
    {
        public static string GetClientsFolder()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(appdata, "." + LauncherSettings.ClientsFolder);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
    }
}
