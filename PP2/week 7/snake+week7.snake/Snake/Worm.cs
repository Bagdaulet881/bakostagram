using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Worm : GameObject
    {
        public Worm(char sign) : base(sign)
        {
            body.Add(new Point(20, 20));
            dx = dy = 0;
        }
      
        public int dx
        {
            get;
            set;
        }
        public int dy
        {
            get;
            set;
        }
        public void Move()
        {
            Clear();
            Butter.arrxx.Clear();//Clear old coordinates of snake
            Butter.arryy.Clear();
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            if (Butter.gameOver)
            {
                GameState.gameover();
            }
            body[0].X += dx;
            body[0].Y += dy;
            for (int i = body.Count - 1; i >= 0; --i)
            {
              Butter.arrxx.Add(body[i].X);//getting coordinates of snake's parts
              Butter.arryy.Add(body[i].Y);
            }
        }
        public bool IsIntersected(List<Point> points)/////////worm WALL COLLISION
        {
            bool res = false;                                           //Wall collision

            foreach(Point p in points)
            {
                if(p.X == body[0].X && p.Y == body[0].Y)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }
         public bool IsIntersected2() /////////worm BODY COLLISION
         {
             bool res = false;

              for (int i = body.Count - 1; i > 0; --i)
             {
                 if(body[0].X==body[i].X && body[0].Y == body[i].Y)
                {
                    res = true;
                    break;
                }
             }
            
             return res;
         }

        public void Eat(List<Point> body)
        {
            this.body.Add(new Point(body[0].X, body[0].Y));
        }
    }
}
