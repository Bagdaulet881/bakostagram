using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
   public class Student //Class Student
    {
       public String name; // details of Class
        public String Id;
       public int year;


        public Student(string Id, string name, int year) // Instance constructor
        {
            this.name = name; // details of constructor
            this.Id = Id;
            this.year = year;

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Student stud = new Student(" "," ",2); //Creating a new Student object
            stud.Id = Console.ReadLine(); //Input
            stud.name = Console.ReadLine();
            stud.year = Convert.ToInt32(Console.ReadLine());
            stud.year++;
           


            Console.WriteLine(stud.Id +" "+ stud.name + " " + stud.year); //output  
        }
    }
}
