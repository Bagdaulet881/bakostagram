using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food:GameObject
    {
        int xx;
        int yy;
        int cnt = 0;
        int cnt2 = 0;

        public Food(char sign) : base(sign)
        {
            GenerateLocation();
        }
        public void GenerateLocation()/////////////////////////////////TRUE RANDOM
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);
             xx = random.Next(0, 28);
             yy = random.Next(2, 38);
            Point p = new Point(yy, xx);

            while (!IsGoodPoint(p))
            {
                xx = random.Next(0, 27);
                yy = random.Next(2, 37);
                p = new Point(yy, xx);
            }
            Butter.score++;
            
            body.Add(p);/////////////////////////////////////////////TRUE RANDOM
        }
        public bool IsGoodPoint2(List<Point> points)/////////worm WALL COLLISION
        {

            foreach (Point p in points)
            {
                if (p.X == yy && p.Y == xx)
                {
                    return true;
                }
            }

            return false;


        }
        bool IsGoodPoint(Point p)/////////////////////////////////////////////PROCESS of CHECKING: TRUE RANDOM
        {

            for (int i = 0; i < Butter.arrxx.Count; i++)
            {
                if (xx != Butter.arrxx[i] || yy != Butter.arryy[i])// check for generate on snake
                {
                    cnt2++;
                }
            }
            if (!IsGoodPoint2(GameState.wall2.body) && cnt2 == Butter.arrxx.Count)
            {
                Butter.flag = false;                // if all ok then will generate food
                cnt2 = 0;
                return true;

            }
            else {
                Butter.flag = false;                // if all ok then will generate food
                cnt2 = 0;
                return false;
            }
        }/////////////////////////////////////////////////////////////////////PROCESS of CHECKING: TRUE RANDOM
    }
}
