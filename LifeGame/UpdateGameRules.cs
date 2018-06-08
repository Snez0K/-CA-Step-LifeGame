namespace LifeGame
{
    public class UpdateGameRules
    {
        private Style style = new Style();
        public char[,] PreUpdate(char[,] map, int yLine, int xLine, char alive, char willDie)
        {
            for (int i = 1; i < yLine-1; i++)
            {
                for (int j = 1; j < xLine-1; j++)
                {
                    int liveCount = 0;
                    for (int q = i - 1; q < i + 2; q++)
                    {
                        for (int w = j - 1; w < j + 2; w++)
                        {
                            if (q > 1 && w > 1 && q < yLine-1 && w < xLine-1)
                            {
                                if (map[q, w] == alive || map[q, w] == willDie)
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
                    map = ReplaceUpdate(map, liveCount, i, j);
                }
            }
            return FinalUpdate(map, yLine, xLine);
        }

        public char[,] ReplaceUpdate(char[,] map, int liveCount, int i, int j)
        {
            if (liveCount < 2 && map[i, j] == style.Alive || liveCount > 3 && map[i, j] == style.Alive)
            {
                map[i, j] = style.WillDie;
            }
            else if (liveCount == 3 && map[i, j] == ' ')
            {
                map[i, j] = style.WillBorn;
            }
            return map;
        }

        public char[,] FinalUpdate(char[,] map, int yLine, int xLine)
        {
            for (int i = 0; i < yLine; i++)
            {
                for (int j = 0; j < xLine; j++)
                {
                    if (map[i, j] == style.WillDie)
                    {
                        map[i, j] = style.Dead;
                    }
                    else if (map[i, j] == style.WillBorn)
                    {
                        map[i, j] = style.Alive;
                    }
                }
            }
            return map;
        }
    }
}