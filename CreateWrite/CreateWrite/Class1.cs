using System;
using System.IO;
using System.Text;

namespace CreateWrite
{
    public class Class1
    {
        public static void code(string command1, string command2)
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
    }
}
