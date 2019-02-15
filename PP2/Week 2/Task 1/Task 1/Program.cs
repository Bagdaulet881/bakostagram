using System;
using System.IO;

namespace ReadFromFile
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int cnt = 0;
            FileStream fileStream = new FileStream(@"C:\csh\PP2\Week 2\Task 1\Task 1\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fileStream);

            String str = sr.ReadLine();


            
            
                int i = 0;
                int j = str.Length - 1;

                while (i < j)
                {
                if (str[i] != str[j])
                {
                    cnt++;
                    i++;
                    j--;
                }
                else
                {
                    i++;
                    j--;
                }
                
                }
            if (cnt > 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }

                   
            sr.Close();
            fileStream.Close();

        }
    }
}
