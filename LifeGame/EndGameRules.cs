using System.Collections.Generic;

namespace LifeGame
{
    public class EndGameRules
    {
        private Style st = new Style();
        private bool result = true;
        public bool EndAllDead(char[,] Map, int Yline, int Xline)
        {
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    if (Map[i, j] == st.GetWillBorn())
                    {
                        result = false;
                    }
                    else if (Map[i, j] == st.GetAlive())
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