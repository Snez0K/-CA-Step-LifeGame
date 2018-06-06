namespace LifeGame
{
    public class UpdateGameRules
    {
        private Style style = new Style();
        public char[,] PreUpdate(char[,] Map, int Yline, int Xline, char alive, char willDie)
        {
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    int liveCount = 0;
                    for (int q = i - 1; q < i + 2; q++)
                    {
                        for (int w = j - 1; w < j + 2; w++)
                        {
                            if (q > 0 && w > 0 && q < Yline && w < Xline)
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
                    Map = ReplaceUpdate(Map, liveCount, i, j);
                }
            }
            return FinalUpdate(Map, Yline, Xline);
        }

        public char[,] ReplaceUpdate(char[,] Map, int liveCount, int i, int j)
        {
            if (liveCount < 2 && Map[i, j] == style.Alive || liveCount > 3 && Map[i, j] == style.Alive)
            {
                Map[i, j] = style.WillDie;
            }
            else if (liveCount == 3 && Map[i, j] == ' ')
            {
                Map[i, j] = style.WillBorn;
            }
            return Map;
        }

        public char[,] FinalUpdate(char[,] Map, int Yline, int Xline)
        {
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    if (Map[i, j] == style.WillDie)
                    {
                        Map[i, j] = style.Dead;
                    }
                    else if (Map[i, j] == style.WillBorn)
                    {
                        Map[i, j] = style.Alive;
                    }
                }
            }
            return Map;
        }
    }
}