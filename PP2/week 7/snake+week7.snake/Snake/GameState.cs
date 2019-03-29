using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    class GameState
    {
        Worm worm = new Worm('O');
        Food food = new Food('@');
        Wall wall = new Wall('#');
        public static Wall wall2 = new Wall('#');
        Timer timer = new Timer();
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }
        
        public void DrawScore()
        {
            if (Butter.gameOver)
            {
                gameover();
            }
            else {
                Console.SetCursorPosition(0, 30);
                Console.WriteLine("-------SNAKE GAME BY @BAKOSTAGRAM-------");
                Console.Write("Score: " + Butter.score);
            }
        }
        public void Run()
        {
            worm.Draw();
            timer.Elapsed += elapsed;
            timer.Interval = 300;
            timer.Start();
            food.Draw();
            wall.Draw();

        }
        public void Run2()
        {
            worm.Draw();
            
            food.Draw();
            wall.Draw();
            worm.dx = -1;
            worm.dy = 0;
            timer.Elapsed += elapsed;
            timer.Interval = Butter.score*100-(Butter.score * 100-100);
            timer.Start();
        }

        public void elapsed(object sender, ElapsedEventArgs e)
        {


            if (Butter.gameOver)
            {
                gameover();
            }
            else
            {
               
                if (Butter.score == 2)
                {
                    timer.Enabled = !timer.Enabled;
                    Nextlvl.Serialize(2, Butter.username, 20, 20, 1, 3);
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                }
                else
                if (Butter.score == 5)
                {
                    timer.Enabled = !timer.Enabled;
                    Nextlvl.Serialize(3, Butter.username, 20, 20, 1, 6);
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                }
                worm.Clear();
                worm.Move();
                worm.Draw();
                CheckCollision();

            }
           

        }

      
        public static void gameover()
        {
            if (Butter.gameOver)
            {
                Nextlvl.Serialize(1, "n", 20, 20, 0, -1);
                Console.SetCursorPosition(15, 34);
                Console.WriteLine("Game over!");
                Console.WriteLine(Butter.username + " your score: " + Butter.score);
                Console.WriteLine("Press R to reset the game!");
                Console.WriteLine("Press ESC to save your record and close the game!");
            }
        }
        
        public void ProcessKeyEvent(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.dx = 0;
                    worm.dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    worm.dx = 0;
                    worm.dy = 1;
                    break;
                case ConsoleKey.RightArrow:
                    worm.dx = 1;
                    worm.dy = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    worm.dx = -1;
                    worm.dy = 0;
                    break;
                case ConsoleKey.Escape:
                    timer.Enabled = !timer.Enabled;
                    Savescore.Serialize();
                    Nextlvl.Serialize(1,"n" , 20, 20, 0, -1);
                    Environment.Exit(0);
                    break;
                case ConsoleKey.R:
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                    break;
            }

        }

        private void CheckCollision()
        {
            if (worm.IsIntersected2()) /////////WORM BODY COLLISION
            {
                Butter.gameOver = true;
                gameover();

            }
            else
            if (worm.IsIntersected(wall.body))/////////WORM WALL COLLISION
            {
                Butter.gameOver = true;
                gameover();
            }
            else if (worm.IsIntersected(food.body))
            {
                worm.Eat(food.body);
                food.GenerateLocation();
                food.Draw();

            }
        }
        
    }
}
