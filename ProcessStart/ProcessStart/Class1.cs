﻿using System;
using System.Text;
using System.Diagnostics;

namespace ProcessStart
{
    public class Class1
    {
        public static void code(string command)
        {
            Process.Start(@command);
        }
    }
}
