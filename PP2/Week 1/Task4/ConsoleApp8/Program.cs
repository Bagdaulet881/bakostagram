using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; //size of array or future figure
            n = Convert.ToInt32(Console.ReadLine()); //Input
            int[] arr = new int[n]; //Createing a array

            for(int i=0; i<n; i++) //'for' loop
            {
                for (int j = 0; j <= i; j++) // second 'for' loop
                {
                    Console.Write("[*] "); //output part of figure
                }
                Console.WriteLine(""); //New line

            }
        }
    }
}
