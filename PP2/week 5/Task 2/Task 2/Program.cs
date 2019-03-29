using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_2
{
    public class MarkList   
    {
        public List<Mark> Marks;
        public MarkList()
        {
            Marks = new List<Mark>();
        }

        public void Serialize(MarkList MRK)
        {
            FileStream fs = new FileStream("marks.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(MarkList));
            xs.Serialize(fs, MRK);
            fs.Close();
        }
        public void DeSerialize()
        {
            FileStream fs = new FileStream("marks.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(MarkList));
            MarkList MRK = xs.Deserialize(fs) as MarkList;
           for (int i = 0; i < MRK.Marks.Count; i++)
            {
                Console.WriteLine(MRK.Marks[i]);
            }
            fs.Close();
        }
    }
    public class Mark
    {
        public int Points;

        public Mark() { }
        public Mark(int Points)
        {
            this.Points = Points;
        }

        public string GetLetter()
        {
            if (Points >= 95)
                return "A";
            if (Points >= 90 && Points < 95)
                return "A-";
            if (Points >= 85 && Points < 90)
                return "B+";
            if (Points >= 80 && Points < 85)
                return "B";
            if (Points >= 75 && Points < 80)
                return "B-";
            if (Points >= 70 && Points < 75)
                return "C+";
            if (Points >= 65 && Points < 70)
                return "C";
            if (Points >= 60 && Points < 65)
                return "C-";
            if (Points >= 55 && Points < 60)
                return "D+";
            if (Points >= 50 && Points < 55)
                return "D";
            return "F";
        }
        public override string ToString()
        {
            return GetLetter();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mark m1 = new Mark(95);
            Mark m2 = new Mark(85);
            Mark m3 = new Mark(57);
            MarkList MRK = new MarkList();
            MRK.Marks.Add(m1);
            MRK.Marks.Add(m2);
            MRK.Marks.Add(m3);
            MRK.Serialize(MRK);
            MRK.DeSerialize();
            Console.ReadKey();
        }
    }
}
