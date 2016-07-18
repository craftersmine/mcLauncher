using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.Launcher.Core
{
    public sealed class Logger
    {
        public static void Log(string contents, string prefix)
        {
            Console.WriteLine("{0} [{1}] {2}", DateTime.Now.ToString(), prefix, contents);
        }
    }
}
