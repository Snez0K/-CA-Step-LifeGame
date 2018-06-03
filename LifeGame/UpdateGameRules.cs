namespace LifeGame
{
    public class UpdateGameRules
    {
        private Style st = new Style();
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
            if (liveCount < 2 && Map[i, j] == st.GetAlive() || liveCount > 3 && Map[i, j] == st.GetAlive())
            {
                Map[i, j] = st.GetWillDie();
            }
            else if (liveCount == 3 && Map[i, j] == ' ')
            {
                Map[i, j] = st.GetWillBorn();
            }
            return Map;
        }

        public char[,] FinalUpdate(char[,] Map, int Yline, int Xline)
        {
            
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    if (Map[i, j] == st.GetWillDie())
                    {
                        Map[i, j] = st.GetDead();
                    }
                    else if (Map[i, j] == st.GetWillBorn())
                    {
                        Map[i, j] = st.GetAlive();
                    }
                }
            }
            return Map;
        }

    }
}