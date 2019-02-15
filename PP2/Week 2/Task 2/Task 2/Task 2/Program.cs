using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //read from file(START)
            FileStream fileStream = new FileStream(@"C:\csh\PP2\Week 2\Task 2\Task 2\Task 2\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fileStream);

            String str = sr.ReadLine();
            //read from file(END)

            String[] string1 = str.Split(" ");//2 5 9

            int n = string1.Length;//3
            int[] arr = new int[n];
            int[] prm = new int[n];

            
           

            for (int i = 0; i < n; ++i)
            {

                
                arr[i] = Convert.ToInt32(string1[i]);// input to array

            }
            //PRIME NUMBERS
           
            FileStream fs = new FileStream(@"C:\csh\PP2\Week 2\Task 2\Task 2\Task 2\output.txt", FileMode.Create, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);


            int flag = 0;
            int l = 0;
            for (int i = 0; i < n; i++)
            { 
                for (int j = 2; j <= arr[i]/2; j++)
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
            for (int i = 0; i < l; i++)
            {
           
              
                sw.Write(prm[i] + " ");
                
            }

            sw.Close();
            fs.Close();


        }
    }
}
