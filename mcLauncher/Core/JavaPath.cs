using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace craftersmine.Launcher.Core
{
    public sealed class JavaPath
    {
        public static string GetJavaBinaryPath()
        {
            object objectValue = GetJavaRegistry().OpenSubKey(GetJavaVersion());
            if (objectValue == null)
            {
                throw new FileNotFoundException();
            }
            objectValue = RuntimeHelpers.GetObjectValue(((RegistryKey)objectValue).GetValue("JavaHome", null));
            if (objectValue == null)
            {
                throw new FileNotFoundException();
            }
            objectValue = Path.Combine(objectValue.ToString(), "bin");
            if (!Directory.Exists(objectValue.ToString()))
            {
                throw new FileNotFoundException();
            }
            return objectValue.ToString();
        }

        public static string GetJavaHome()
        {
            object objectValue = GetJavaRegistry().OpenSubKey(GetJavaVersion());
            if (objectValue == null)
            {
                throw new FileNotFoundException();
            }
            objectValue = RuntimeHelpers.GetObjectValue(((RegistryKey)objectValue).GetValue("JavaHome", null));
            if (objectValue == null)
            {
                throw new FileNotFoundException();
            }
            return objectValue.ToString();
        }

        public static RegistryKey GetJavaRegistry()
        {
            RegistryKey key = null;
            if (key == null)
            {
                key = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("JavaSoft").OpenSubKey("Java Runtime Environment");
            }
            if (Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Wow6432Node") != null)
            {
                if (key == null)
                {
                    key = null;
                }
                if (key == null)
                {
                    key = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Wow6432Node").OpenSubKey("JavaSoft").OpenSubKey("Java Runtime Environment");
                }
            }
            if (key == null)
            {
                throw new FileNotFoundException();
            }
            return key;
        }

        public static string GetJavaVersion()
        {
            object objectValue = RuntimeHelpers.GetObjectValue(GetJavaRegistry().GetValue("CurrentVersion", null));
            if (objectValue == null)
            {
                throw new FileNotFoundException();
            }
            return objectValue.ToString();
        }
    }
}
