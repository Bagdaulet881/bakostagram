using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("Thread 1");
            MyThread t2 = new MyThread("Thread 2");
            MyThread t3 = new MyThread("Thread 3");

            t1.startThread();
            t2.startThread();
            t3.startThread();

        }
    }
    class MyThread
    {
        Thread threadField = Thread.CurrentThread;
        public  MyThread( string str)
        {

            threadField.Name =  str;

        }
        public void startThread()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(threadField.Name + " выводит " + i);
            }
            

        }
    }
}
