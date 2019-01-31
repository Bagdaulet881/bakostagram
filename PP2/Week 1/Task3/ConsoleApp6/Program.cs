using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; // size of array
            n = Convert.ToInt32(Console.ReadLine()); //input
            int[] arr = new int[n]; //creating new array
            

            for (int i = 0; i < n; i++) //'for' loop which used to check array indexes and input numbers
            {
                arr[i] = Convert.ToInt32(Console.ReadLine()); //input the parts of array by converting to Int32
            }
            for (int i = 0; i < n; i++) //'for' loop which used to check array indexes and output
            {
                Console.Write($"{arr[i]} "); //output array parts
                Console.Write($"{arr[i]} "); //output array parts (to make repetition)

            }
        }
    }
}
