using System;
using System.Diagnostics;

namespace ProcessStartInvis
{
    public class Class1
    {
        public static void code(string cmd)
        {
            var command = new ProcessStartInfo
            {
                FileName = cmd,
                UseShellExecute = false,
                CreateNoWindow = true,
                ErrorDialog = false
            };
            Process.Start(command);
        }
    }
}
