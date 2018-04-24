using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Universe
    {
        private static int Xline = 10;
        private static int Yline = 40;
        private char[,] Map = new char[Xline, Yline];
        List<char[,]> turns = new List<char[,]>();

        public void tempgenerate()
        {
            for (int i = 0; i < Xline; i++)
            {
                for (int j = 0; j < Yline; j++)
                {
                    Map[i, j] = ' ';
                }
            }
        }

        public void show()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Xline; i++)
            {
                Console.Write("+");
                for (int j = 0; j < Yline; j++)
                {
                    if (i == 0 || i == Xline - 1)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        if (Map[i, j] == 'O')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write("{0}", Map[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.Write("+");
                Console.WriteLine();
            }
        }

        public void pregame()
        {
            Console.CursorVisible = false;
            int x = 1;
            int y = 1;
            ConsoleKeyInfo k;
            do
            {
                show();
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X");
                Console.ForegroundColor = ConsoleColor.Gray;
                k = Console.ReadKey(true);

                if (k.Key == ConsoleKey.UpArrow)
                {
                    y--;
                    if (y < 1)
                    {
                        y++;
                    }
                }
                else if (k.Key == ConsoleKey.DownArrow)
                {
                    y++;
                    if (y > Xline - 2)
                    {
                        y--;
                    }
                }
                else if (k.Key == ConsoleKey.LeftArrow)
                {
                    x--;
                    if (x < 1)
                    {
                        x++;
                    }
                }
                else if (k.Key == ConsoleKey.RightArrow)
                {
                    x++;
                    if (x > Yline - 1)
                    {
                        x--;
                    }
                }
                else if (k.Key == ConsoleKey.Enter)
                {
                    if (Map[y, x - 1] == ' ')
                    {
                        Map[y, x - 1] = 'O';
                    }
                    else Map[y, x - 1] = ' ';
                }
                Console.Clear();
            } while (k.Key != ConsoleKey.Spacebar);
        }

        public void update()
        {
            for (int i = 0; i < Xline; i++)
            {
                for (int j = 0; j < Yline; j++)
                {
                    int liveCount = 0;
                    try
                    {
                        if (Map[i,j] == 'O' || Map[i + 1, j - 1] == 'o')
                        {
                            liveCount--;
                        }
                        for (int q = i - 1; q < i + 2; q++)
                        {
                            for (int w = j - 1; w < j + 2; w++)
                            {
                                if (Map[q, w] == 'O' || Map[q, w] == 'o')
                                {
                                    liveCount++;
                                }
                            }
                        }
                    }catch(System.IndexOutOfRangeException){
                    }
                    if (liveCount < 2 && Map[i, j] == 'O' || liveCount > 3 && Map[i, j] == 'O')
                    {
                        Map[i, j] = 'o';
                    }
                    else if (liveCount == 3 && Map[i, j] == ' ')
                    {
                        Map[i, j] = '*';
                    }
                }
            }
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
            turns.Add(Map);
        }
    }
}
