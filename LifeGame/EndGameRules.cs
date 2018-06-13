using System;
using System.Collections.Generic;

namespace LifeGame
{
    public class EndGameRules
    {
        private Style style = new Style();
        private bool willWork = true;

        public bool EndAllDead(char[,] map, int yLine, int xLine)
        {
            for (int i = 0; i < yLine; i++)
            {
                for (int j = 0; j < xLine; j++)
                {
                    if (map[i, j] == style.WillBorn)
                    {
                        willWork = false;
                    }
                    else if (map[i, j] == style.Alive)
                    {
                        willWork = false;
                    }
                }
            }
            return willWork;
        }

        public bool EndRepeatTurns(List<char[,]> turns, char[,] map, int yLine, int xLine)
        {
            Console.Title = turns.Count.ToString();
            bool willWork = false; //результат проверки
            bool @continue = true;

            foreach (char[,] item in turns)
            {
                for (int i = 0; i < yLine && @continue; i++)
                {
                    for (int j = 0; j < xLine && @continue; j++)
                    {
                        if (map[i, j] != item[i, j])
                        {
                            @continue = false;
                            willWork = false;
                        }
                        else if (map[i, j] == item[i, j])
                        {
                            willWork = true;
                        }
                    }
                }
                if (!@continue)
                {
                    break;
                }
            }
            return !willWork;
        }
    }
}