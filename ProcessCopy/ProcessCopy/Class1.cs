using System;
using System.IO;

namespace ProcessCopy
{
    public class Class1
    {
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
    }
}
