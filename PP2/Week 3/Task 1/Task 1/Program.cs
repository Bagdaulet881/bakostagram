using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
    class Folder
    {
        FileSystemInfo[] contents;
        int selectedIndex;

        public Folder(FileSystemInfo[] fileSystemInfos)
        {
            selectedIndex = 0;
            contents = fileSystemInfos; //getting all files
        }

        public void PrintFolder()
        {
            Console.Clear();

            for (int i = 0; i < contents.Length; i++)
            {
                // Setup colors for foreground and background colors
                if (i != 0)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                if (contents[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; //if this is file
                }
                else // FileInfo
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; //if this is folder
                }

                Console.WriteLine(contents[i].Name);
            }
        }
        public void Up()
        {
            if (selectedIndex == 0)
            {
                // note: arrays start at 0, not 1
                selectedIndex = contents.Length - 1;
            }
            else
            {
                selectedIndex--;
            }
        }

        public void Down()
        {
            if (selectedIndex == contents.Length - 1)
            {
                selectedIndex = 0;
            }
            else
            {
                selectedIndex++;
            }
        }
        public FileSystemInfo GetSelectedObj()
        {
            return contents[selectedIndex]; //gets folder(contents) which is placed at index
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\csh\PP2\Week 3\Task 1\Task 1\Filefortest";
            DirectoryInfo dir = new DirectoryInfo(@path);
            Folder folder = new Folder(dir.GetFileSystemInfos()); //'dir.GetFileSystemInfos()' representing all the files and subdirectories in a path


            Stack<Folder> dirs = new Stack<Folder>(); //creating stack ;)
            dirs.Push(folder);
            bool run = true; //flag for 'while' loop
            bool directoryMode = true; // true = directory, false = file

            while (run)
            {
                if (directoryMode)
                {
                    dirs.Peek().PrintFolder();
                }

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        dirs.Peek().Up();
                        break;
                    case ConsoleKey.DownArrow:
                        dirs.Peek().Down();
                        break;

                    case ConsoleKey.Enter:

                        FileSystemInfo selected = dirs.Peek().GetSelectedObj();

                        if (selected.GetType() == typeof(DirectoryInfo))
                        {
                            var fInfos = (selected as DirectoryInfo).GetFileSystemInfos();
                            dirs.Push(new Folder(fInfos));
                        }
                        else
                        {
                            string fullPath = (selected as FileInfo).FullName; //getting new directory of new file
                            FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read); //Getting access to read a file which placed in 'fullPat'
                            StreamReader sr = new StreamReader(fileStream);//reading a file

                            Console.BackgroundColor = ConsoleColor.White; //colours for file reading window
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.Clear();
                            Console.Write(sr.ReadToEnd());

                            directoryMode = false; //if we entered a file, then 'directoryMode' will be false and PrintFolder() won't print any new directories

                            sr.Close();
                            fileStream.Close();
                        }

                        break;

                    case ConsoleKey.Escape:
                        if (directoryMode)
                        {
                            run = false; //if run is false main loop will be paused and it's means that run of code is stopped
                        }
                        else
                        {
                            directoryMode = true; //if directoryMode was false
                        }
                        break;

                    case ConsoleKey.Backspace:
                        if (dirs.Count > 1)
                        {
                            dirs.Pop();
                        }
                        break;
                    case ConsoleKey.Delete:
                        FileSystemInfo selected2 = dirs.Peek().GetSelectedObj();

                        if (selected2.GetType() == typeof(DirectoryInfo))
                        {
                            var dirs1 = (selected2 as DirectoryInfo);
                            //dirs.Push(new Folder(fInfos));
                            // DirectoryInfo dirs2 = new DirectoryInfo(dirs1);
                            foreach (DirectoryInfo dir3 in dirs1.GetDirectories())
                            {
                                dir3.Delete(true);
                            }
                        }

                        break;
                            default:
                        break;
                }
            }
        }
    }
}

