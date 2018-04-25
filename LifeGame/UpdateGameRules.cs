using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LifeGame
{
    public class UpdateGameRules
    {
        public char[,] preUpdate(char[,] Map, int Xline, int Yline, char alive, char willDie)
        {
            for (int i = 0; i < Xline; i++)
            {
                for (int j = 0; j < Yline; j++)
                {
                    int liveCount = 0;
                    for (int q = i - 1; q < i + 2; q++)
                    {
                        for (int w = j - 1; w < j + 2; w++)
                        {
                            if (q > 0 && w > 0 && q < Xline && w < Yline)
                            {
                                if (Map[q, w] == alive || Map[q, w] == willDie)
                                {
                                    liveCount++;
                                    if (q == i && w == j)
                                    {
                                        liveCount--;
                                    }
                                }
                            }
                        }
                    }
                    //вызов
                    Map = replaceUpdate(Map, liveCount, i, j);
                }
            }
            return FinalUpdate(Map, Xline, Yline);
        }

        public char[,] replaceUpdate(char[,] Map, int liveCount, int i, int j)
        {
            if (liveCount < 2 && Map[i, j] == 'O' || liveCount > 3 && Map[i, j] == 'O')
            {
                Map[i, j] = 'o';
            }
            else if (liveCount == 3 && Map[i, j] == ' ')
            {
                Map[i, j] = '*';
            }
            return Map;
        }

        public char[,] FinalUpdate(char[,] Map, int Xline, int Yline)
        {
            
            for (int i = 0; i < Xline; i++)
            {
                for (int j = 0; j < Yline; j++)
                {
                    if (Map[i, j] == 'o')
                    {
                        Map[i, j] = ' ';
                    }
                    else if (Map[i, j] == '*')
                    {
                        Map[i, j] = 'O';
                    }
                }
            }
            return Map;
        }

    }
}
