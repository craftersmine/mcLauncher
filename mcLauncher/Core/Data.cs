using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using craftersmine.Launcher.Properties;

namespace craftersmine.Launcher.Core
{
    public sealed class Data
    {
        public static string   Session        { get; set; }
        public static string   Folder         { get { return ClientFolder.GetClientsFolder(); } }
        public static string   SelectedClient { get; set; }
        public static string   JavaBinDir     { get { return System.IO.Path.Combine(JavaPath.GetJavaHome(), "bin"); } }
        public static string   Memory         { get; set; }
        public static string   Username       { get; set; }
        internal static Settings SettingsMngr   { get; set; }
        public static bool     IsOffline      { get; set; }
        public static string   News { get; set; }
    }
}
