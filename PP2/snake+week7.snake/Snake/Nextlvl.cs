using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Snake
{
    public class Constr
    {
        public int lvl1;
        public string login;
        public int xx, yy, cnt, score;
    }

    class Nextlvl
    {
        public static void Serialize(int lvl, string username, int x, int y, int count, int score)
        {
            File.Delete("xexe.xml");
            Constr cnstr = new Constr();
            cnstr.lvl1 = lvl;
            cnstr.login = username;
            cnstr.xx = x;
            cnstr.yy = y;
            cnstr.cnt = count;
            cnstr.score = score;
            FileStream fs = new FileStream("xexe.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Constr));
            xs.Serialize(fs, cnstr);
            fs.Close();
        }

       
        public static void Deserialize()
        {

            FileStream fss = new FileStream("xexe.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Constr));
            Constr cnstr2 = xs.Deserialize(fss) as Constr;
            Returnlvl.Uroven = cnstr2.lvl1;
            Returnlvl.coordinatexx = cnstr2.xx;
            Returnlvl.coordinateyy = cnstr2.yy;
            Returnlvl.count = cnstr2.cnt;
            Returnlvl.login = cnstr2.login;
            Returnlvl.score = cnstr2.score;
            fss.Close();
        }
    }
    class Returnlvl
    {
        public static int Uroven;
        public static int coordinatexx;
        public static int coordinateyy;
        public static int count;
        public static string login;
        public static int score;
    }
}
