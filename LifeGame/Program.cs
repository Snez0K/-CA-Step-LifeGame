using System;
using System.Threading;

namespace LifeGame
{
    public class Program
    {
        public static void Main()
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
                Thread.Sleep(300);
            } while (game.update());
        }
    }
}