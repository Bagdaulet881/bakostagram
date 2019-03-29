using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class GameObject
    {
       
        public  List<Point> body = new List<Point>();
        public static List<Point> nextbody = new List<Point>();
        protected char sign;
       

        public GameObject(char sign)
        {
            this.sign = sign;
        }
       
        public  void Draw()
        {
            if (Returnlvl.count == 1)
            { 
                int cnst = 20;
                
                    for (int i = 0; i < Returnlvl.score; i++)
                    {
                        body.Add(new Point(cnst, cnst++));

                    }
                    Console.WriteLine(cnst);
                Returnlvl.count = 0;

            }
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }

            Butter.snakesize = body.Count - 1;
            
        }
       
       
        public void Clear()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }
    }
}
