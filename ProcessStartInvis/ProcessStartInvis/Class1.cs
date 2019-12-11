using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ProcessStartInvis
{
    public class Class1
    {
        public static void code6(string cmd)
        {
            var command = new ProcessStartInfo
            {
                FileName = cmd,
                ErrorDialog = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process.Start(command);
            
        }
    }
}
