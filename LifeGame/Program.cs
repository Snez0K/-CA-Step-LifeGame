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
            game.EmptyMapGenerate();
            game.Pregame();
            do
            {
                Console.Clear();
                game.Update();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Generation: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(game.Timer);
                game.Show();
                Thread.Sleep(runTime);
            } while (game.end == false);
        }
    }
}