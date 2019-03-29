using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_1
{
    public class ComplexNumbers
    {
        public int a;
        public int b;
        public ComplexNumbers()
        {

        }
        public void PrintInfo()
        {
            Console.WriteLine(a + " + " + b + "i");
        }
    }

    class Program
    {
        private static void Serialize()
        {
            ComplexNumbers cmplx = new ComplexNumbers();
            cmplx.a = Convert.ToInt32(Console.ReadLine());
            cmplx.b = Convert.ToInt32(Console.ReadLine());
            FileStream fs = new FileStream("complex.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumbers));
            xs.Serialize(fs, cmplx);
            fs.Close();
        }
        private static void DeSerialize()
        {
            FileStream fss = new FileStream("complex.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumbers));
            ComplexNumbers cmplx = xs.Deserialize(fss) as ComplexNumbers;
            cmplx.PrintInfo();
            fss.Close();
        }
            static void Main(string[] args)
        {
            Serialize();
            DeSerialize();
        }
    }
}
