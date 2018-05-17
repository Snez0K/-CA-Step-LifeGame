using System;
using System.Threading;

namespace LifeGame
{
    public class Program
    {
        public static void Main()
        {
            int runTime = 300;
            var game = new Universe();
            game.tempgenerate();
            game.pregame();
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Generation: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(game.GetTimer());
                game.show();
                Thread.Sleep(runTime);
            } while (game.update());
        }
    }
}