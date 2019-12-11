using System;
using System.IO;

namespace ProcessCreate
{
    public class Class1
    {
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
    }
}
