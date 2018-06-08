using System.Collections.Generic;

namespace LifeGame
{
    public class EndGameRules
    {
        private Style style = new Style();
        private bool result = true;

        public bool EndAllDead(char[,] map, int yLine, int xLine)
        {
            for (int i = 0; i < yLine; i++)
            {
                for (int j = 0; j < xLine; j++)
                {
                    if (map[i, j] == style.WillBorn)
                    {
                        result = false;
                    }
                    else if (map[i, j] == style.Alive)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public bool EndRepeatTurns(List<char[,]> turns, char[,] map, int yLine, int xLine)
        {
            int timer = 0;
            bool result = false; //результат проверки
            const int fail = -9999; 

            foreach (char[,] item in turns)
            {
                for (int i = 0; i < yLine; i++)
                {
                    for (int j = 0; j < xLine; j++)
                    {
                        if (map[i, j] != item[i, j])
                        {
                            timer = fail;
                        }
                        else if (map[i, j] == item[i, j])
                        {
                            timer++;
                        }
                    }
                }
            

            if (timer > 0)
            {
                result = true;
            }
            timer = 0;
            }
            return result;
        }
    }
}