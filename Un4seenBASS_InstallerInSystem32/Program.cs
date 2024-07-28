using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Un4seenBASS_InstallerInSystem32
{
    internal class Program
    {
        public static void ExtractFiles(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //This is Very Important Code... DON'T CHANGE THIS!!! 

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("[Un4Seen BASS Module Installer] This Is My First Installer For BASS Module In System32... \nEnjoy to use this!!!");
            ExtractFiles("Un4seenBASS_InstallerInSystem32", @"C:\Windows\System32", "Resources", "bass.dll");
            Console.WriteLine("[Un4Seen BASS Module Installer] Installed Successfully!!!");
            Thread.Sleep(3000);
            Environment.Exit(1223);
        }
    }
}
