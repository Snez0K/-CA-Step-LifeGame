using System.Collections.Generic;

namespace LifeGame
{
    public class EndGameRules
    {
        Style st = new Style();
        bool result = true;
        public bool endAllDead(char[,] Map, int Yline, int Xline)
        {
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    if (Map[i, j] == st.getWillBorn())
                    {
                        result = false;
                    }
                    else if (Map[i, j] == st.getAlive())
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        //Вселенная в точности (без сдвигов и поворотов) повторяет себя на одном из более ранних шагов (образуется цикличность жизни).
        public bool EndRepeatTurns(List<char[,]> Turns, char[,] Map, int Yline, int Xline)
        {
            //int count = Turns.Count;
            int timer = 0;
            bool result = false;
            const int fail = -9999; 

            int a = 0;

            foreach (char[,] item in Turns)
            {
                for (int i = 0; i < Yline; i++)
                {
                    for (int j = 0; j < Xline; j++)
                    {
                        if (Map[i, j] != item[i, j])
                        {
                            timer = fail;
                        }
                        else if (Map[i, j] == item[i, j])
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