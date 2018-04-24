using System;
using System.Globalization;
using System.Threading;

namespace LifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Universe();
            game.tempgenerate();
            game.pregame();
            do
            {
                Thread.Sleep(1000);
                game.update();
                game.show();
            } while (true);

        }
    }
}
