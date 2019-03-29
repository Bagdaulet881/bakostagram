using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
         static Thread[] threadarray = new Thread[3];

        static void Main(string[] args)
        {

            for (int i = 0; i < 3; i++)
            {
                int x = i;
                x++;
                threadarray[i] = new Thread(() => k());
                threadarray[i].Name = $"threadarray[{x}]";
            }
          
            for (int i = 0; i < 3; i++)
            {
                threadarray[i].Start();
                threadarray[i].Join();

            }
        }
        static void k()
        {
            Thread thr = Thread.CurrentThread;
            for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(thr.Name);
                }
            
        }
    }
}
