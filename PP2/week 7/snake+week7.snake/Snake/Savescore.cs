using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class CanstrForsave
    {
        
        public List<string> list = new List<string>();
        public List<int> listint = new List<int>();
        public CanstrForsave()
        {
            list = DesOutput.list;//IF ITS FIRST START, COMMENT IT
            listint = DesOutput.listint;
        }
        public int counter=DesOutput.counter;
    }

    class Savescore
    {
        public static void Serialize()
        {
            File.Delete("champions.xml");

            CanstrForsave cnst = new CanstrForsave();
            cnst.list.Add(Butter.username);
            cnst.listint.Add(Butter.score);
            cnst.counter++;
            FileStream fs = new FileStream("champions.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(CanstrForsave));
            xs.Serialize(fs, cnst);
            fs.Close();

        }
        public static void Deserialize()
        {

            FileStream fss = new FileStream("champions.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(CanstrForsave));
            CanstrForsave cnst2 = xs.Deserialize(fss) as CanstrForsave;
            DesOutput.counter = cnst2.counter;
            DesOutput.list = cnst2.list;
            DesOutput.listint = cnst2.listint;


            fss.Close();
        }
        
    }
     class DesOutput
    {
        public static int counter;
        public static string username2;
        public static List<string> list;
        public static List<int> listint;

        public static void PrintScore()
        {
            for(int i=0; i<counter; i++)
            {
                Console.WriteLine(i+1 + ") " + list[i] + "---score -> " + listint[i]);

            }
        }

    }
}