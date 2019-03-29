using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Butter
    {
        public static string username;
        public static int score = -1;
        public static bool gameOver = false;
        public static int lvl = 1;
        public static int snakesize;
        public static bool flag=false;


        public static List<int> arrx = new List<int>();//coordinates of borders
        public static List<int> arry = new List<int>();
        public static List<int> arrxx = new List<int>();//coordinates of worm
        public static List<int> arryy = new List<int>();
    }
    class Wall:GameObject
    {

        public Wall(char sign) : base(sign)//////////////////////////////////////////////////////
        {
            if (Returnlvl.Uroven == 2)///////////////////////////////////////LEVEL
            {
                Butter.lvl = 2;//give path cnstr
            }
            else
            if (Returnlvl.Uroven == 3)
            {
                Butter.lvl = 3;
            }
            LoadLevel(Butter.lvl);
        }////////////////////////////////////////////////////////////////////////////////////////

        void LoadLevel(int level)
        { 
            string name = string.Format("Levels/lvl{0}.txt",level);/////22.03.2019
            using (StreamReader streamReader = new StreamReader(name))
            {
                int r = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    for(int c = 0; c < line.Length; ++c)
                    {
                        if(line[c] == '#')
                        {
                            Butter.arrx.Add(c);
                            Butter.arry.Add(r);
                            body.Add(new Point(c, r));
                        }
                    }
                    r++;
                }
                streamReader.Close();
            }
        }
    }
}
