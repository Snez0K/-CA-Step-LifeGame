using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class EndGameRules
    {
        public bool endAllDead(char[,] Map, int Xline, int Yline)
        {
            for (int i = 0; i < Xline; i++)
            {
                for (int j = 0; j < Yline; j++)
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
        public bool EndRepeatTurns(List<char[,]> Turns, int Xline, int Yline)
        {
            int count = Turns.Count;
            for (int i = 0; i < Xline; i++)
            {
                for (int j = 0; j < Yline; j++)
                {

                }
            }

            return true;
        }
    }
}
