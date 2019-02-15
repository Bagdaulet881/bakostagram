using System;
using System.IO;

class Test
{
    public static void Main()
    {
        string file = "input.txt";
        string path = @"C:\csh\PP2\Week 2\Task 4\Task 4\path\" + file;
        string path1 = @"C:\csh\PP2\Week 2\Task 4\Task 4\path1\" + file;
        
        //CREATE
        FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        //COPY
        fs.Close();
        File.Copy(path,path1);
        //DELETE
        File.Delete(path);
    }
}