using System;
using System.Threading;

namespace LifeGame
{
    class Program
    {
        static void Main()
        {
            var game = new Universe();
            game.tempgenerate();
            game.pregame();
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Generation: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(game.GetTimer());
                game.show();
                Thread.Sleep(1000);
            } while (game.update());
        }
    }
}