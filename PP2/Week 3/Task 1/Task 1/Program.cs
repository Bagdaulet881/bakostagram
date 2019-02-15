using System;
using System.IO;

namespace FarManager
{
    class FarManager
    {
        public int cursor;                                                  //class global variable declaration, cursor for strings
        public int size;                                                    
        public string path;                                                 



        public FarManager(string path)                                      //constructor for creating a new object for a class
        {
            this.path = path;                                            
            cursor = 0;                                                     
            DirectoryInfo directory = new DirectoryInfo(path);              
            size = directory.GetFileSystemInfos().Length;                   
        }




        public void Up()                                                     
        {
            cursor--;
            if (cursor < 0)
                cursor = size - 1;
        }



        public void Down()                                                 
        {
            cursor++;
            if (cursor == size)
                cursor = 0;
        }

        public void Color(FileSystemInfo fs, int index)                     
        {


            if (index == cursor)                                            //cursor color
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
            }


            else if (fs.GetType() == typeof(FileInfo))                   //files will be displayed in yellow
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }


            else                                                         //directories will be presented in white
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Show()                                                   //Print
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(6, 0);
            Console.WriteLine(path);                                         //Heading with path
            Console.WriteLine();
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();            //Get all files and folders
            size = fs.Length;                                                //Length
            for (int i = 0; i < fs.Length; i++)                              //Output
            {
                Color(fs[i], i);                                           
                Console.WriteLine(i + 1 + ". " + fs[i].Name);                
            }
        }

        public void Start()                                                  
        {
            DirectoryInfo directory = new DirectoryInfo(path);               //getting information about a specific directory
            ConsoleKeyInfo consoleKey = Console.ReadKey();                   //ConsoleKey
            FileSystemInfo fs = null;                                        //Empty FileSystem
            while (true)                                                    
            {
                Show();                                                      //PrintOut
                consoleKey = Console.ReadKey();                              //reading keys
                int k = 0;
                for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)// run through the main directory
                {
                    if (cursor == k)
                    {
                        fs = directory.GetFileSystemInfos()[i];                //assigning the file or directory FS in which the cursor is located
                        break;
                    }
                    k++;
                }
                if (consoleKey.Key == ConsoleKey.Escape)                       //press Escape to return to the parent folder
                {
                    cursor = 0;
                    directory = directory.Parent;
                    path = directory.FullName;
                }
                if (consoleKey.Key == ConsoleKey.UpArrow)                      
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)                   
                    Down();
                if (consoleKey.Key == ConsoleKey.Enter)                        //press Enter to open a directory or text file
                {
                    if (fs.GetType() == typeof(DirectoryInfo))                
                    {
                        cursor = 0;
                        directory = new DirectoryInfo(fs.FullName);
                        path = fs.FullName;
                    }
                    if (fs.GetType() == typeof(FileInfo))                      //open txt file
                    {
                        Console.BackgroundColor = ConsoleColor.White;          
                        Console.ForegroundColor = ConsoleColor.Black;          
                        Console.Clear();
                        StreamReader sr = new StreamReader(fs.FullName);       
                        string s = sr.ReadToEnd();                             
                        Console.WriteLine(s);                                  
                        sr.Close();                                            
                        Console.ReadKey();
                    }
                }
                if (consoleKey.Key == ConsoleKey.Delete)                       //Delete files and directories
                {
                    if (fs.GetType() == typeof(FileInfo))                      //file check
                        File.Delete(fs.FullName);                              
                    else if (fs.GetType() == typeof(DirectoryInfo))            //folder check
                        Directory.Delete(fs.FullName, true);                   
                }
                if (consoleKey.Key == ConsoleKey.R)                           //pressing the R key to rename files and directories
                {
                    if (fs.GetType() == typeof(FileInfo))                      //file check
                    {
                        Console.BackgroundColor = ConsoleColor.Red;           
                        Console.Clear(); //clearing it
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Type in new file name:");
                        string newFileName = Console.ReadLine();               //reading new file name
                        string sourceFile = fs.FullName;                       //sourcefile
                        string destFile = path + "/" + newFileName;           
                        File.Move(sourceFile, destFile);                       //rename method by move
                    }
                    if (fs.GetType() == typeof(DirectoryInfo))                  //folder check
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;           
                        Console.Clear();                                       
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Type in new directory name:");
                        string newDirectoryName = Console.ReadLine();          //reading new directory name
                        string sourceDirectory = fs.FullName;                  //sourceDirectory
                        string destDirectory = path + "/" + newDirectoryName;  
                        Directory.Move(sourceDirectory, destDirectory);        //rename method by move
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\csh\PP2\Week 3\Task 1\Task 1\Filefortest";                  //Main Path
            FarManager farManager = new FarManager(path);                      //create new object in class
            farManager.Show();                                                 //print files, directories and headers
            farManager.Start();                                                //call the main function to manage directories
        }
    }
}