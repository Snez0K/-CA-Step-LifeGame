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
                Console.Write("Ход: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(game.GetTimer());
                game.show();
                Thread.Sleep(1000);
                Console.Clear();
            } while (game.update());

            Thread.Sleep(100000000);
        }
    }
}