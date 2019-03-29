using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Nextlvl.Deserialize();
            GameState game = new GameState();
            if (Returnlvl.count == 1)
            {

                Butter.username = Returnlvl.login;
                Butter.score = Returnlvl.score;
                Savescore.Deserialize();
                Console.Clear();

                game.Run2();

                while (true)
                {

                    if (Butter.gameOver)
                    {
                        GameState.gameover();
                    }
                    game.DrawScore();

                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                    game.ProcessKeyEvent(consoleKeyInfo);
                }

            }
            else
            {
                Console.WriteLine("Champions:");
                Savescore.Deserialize();
                DesOutput.PrintScore();
                Console.WriteLine("Enter username:");
                Butter.username = Console.ReadLine();
                Console.Clear();
                game.Run();


                while (true)
                {
                    if (Butter.gameOver)
                    {
                        GameState.gameover();
                    }
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                    game.ProcessKeyEvent(consoleKeyInfo);
                    game.DrawScore();

                }
            }
        }
    }
}
