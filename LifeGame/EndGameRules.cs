using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class EndGameRules
    {
        public bool endAllDead(char[,] Map, int Yline, int Xline)
        {
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    if (Map[i, j] == '*')
                    {
                        return false;
                    }
                    else if (Map[i, j] == 'O')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Вселенная в точности (без сдвигов и поворотов) повторяет себя на одном из более ранних шагов (образуется цикличность жизни).
        public bool EndRepeatTurns(List<char[,]> Turns, char[,] Map, int Yline, int Xline)
        {
            //int count = Turns.Count;
            int timer = 0;

            int a = 0;

            foreach (char[,] item in Turns)
            {
                for (int i = 0; i < Yline; i++)
                {
                    for (int j = 0; j < Xline; j++)
                    {
                        if (Map[i, j] != item[i, j])
                        {
                            timer = -9999;
                        }
                        else if (Map[i, j] == item[i, j])
                        {
                            timer++;
                        }
                    }
                }
            

            if (timer > 0)
            {
                return true;
            }

            timer = 0;
            }
            return false;
        }
    }
}