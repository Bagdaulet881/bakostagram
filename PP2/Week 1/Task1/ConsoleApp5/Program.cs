using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; //size of array
            int count=0;
            n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            int[] prm = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());// input to array
            }

            int flag = 0;
            int l = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 2; j <= arr[i] / 2; j++)
                {
                    if (arr[i] % j == 0)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    prm[l] = arr[i];
                    l++;
                    flag = 0;
                }
                else
                {
                    flag = 0;
                }
            }
            //OUTPUT
            Console.WriteLine(l); //shows how many primes found
            for (int w = 0; w < l; w++)
            {
               Console.Write($"{prm[w]} "); //outputs prime numbers
            }
        }

    }
}