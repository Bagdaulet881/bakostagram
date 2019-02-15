using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string path = @"C:\csh\PP2\Week 1\Task1\ConsoleApp5";
            DirectoryInfo file = new DirectoryInfo(path);
            PrintInfo(file, 0);
        }

        private static void PrintInfo(FileSystemInfo file, int k)
        {
            if (file.GetType() == typeof(DirectoryInfo))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(new string(' ', k) + file.Name);
            if (file.GetType() == typeof(DirectoryInfo))
            {
                var y = file as DirectoryInfo;
                foreach (var x in y.EnumerateFileSystemInfos())
                {
                    PrintInfo(x, k + 3);
                }
            }
        }
    }
}