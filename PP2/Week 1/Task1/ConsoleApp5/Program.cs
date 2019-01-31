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
            int l = 1;
            n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            int[] prm = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());// input to array
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n+1; j++) // numbering untill 'n'
                {
                    if (arr[i] % j == 0)// if one element divided to 'j'  then count++
                    {
                        count++;
                    }
                }

                if (count == 2) //if count=2 then it means that element of array is prime
                {
                    prm[l] = arr[i]; //'prm' is new array which will contain prime numbers
                    l++; //l++ it's size of new array which is increasing with number of prime numbers
                    count = 0; //count=0 to reset and start loop again
                }
                else count = 0; //count=0 to reset and start loop again
            }
            Console.WriteLine(l); //shows how many primes found
            for (int w = 1; w < l; w++)
            {
               Console.Write($"{prm[w]} "); //outputs prime numbers
            }
        }

    }
}