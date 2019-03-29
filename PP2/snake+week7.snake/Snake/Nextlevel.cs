using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Nextlevel
    {
        private int lvl1;
        private string login;
        private int xx, yy;
        public Constr(int lvl, string username, int x, int y)
        {
            lvl1 = lvl;
            login = username;
            xx = x;
            yy = y;
        }
        public void Serialize()
        {
            Constr cnstr = new Constr(lvl, username, x, y);
            cnstr.lvl = lvl1;
            cnstr.username = login;
            cnstr.x = xx;
            cnstr.y = yy;
            FileStream fs = new FileStream("cnstr.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Constr));
            xs.Serialize(fs, cnstr);
            fs.Close();
        }
    }
}
