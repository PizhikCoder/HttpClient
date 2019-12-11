using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SendOrGetFile
{
    public class Class1
    {
        public static byte[] codeToSend(string path)
        {
            var bytearray = File.ReadAllBytes(path);
            return bytearray;
        }
        public static void codeToGet(byte[] file, string path)
        {
            File.Create(path).Write(file, 0, file.Length);
        }
    }
}
