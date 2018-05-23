using System;
using System.Collections.Generic;

namespace LifeGame
{
    public class Universe
    {
        private Style st = new Style();
        public const int Yline = 10;
        public const int Xline = 40;
        public char[,] Map = new char[Yline, Xline];
        public List<char[,]> turns = new List<char[,]>();
        public int Timer = 1;
        public UpdateGameRules CheckUpdate = new UpdateGameRules();
        public EndGameRules CheckEnd = new EndGameRules();

        public int GetTimer() {
            return Timer;
        }

        public void tempgenerate()
        {
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    Map[i, j] = st.getDead();
                }
            }
        }

        public void show()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Yline; i++)
            {
                Console.Write(st.getBorder());
                for (int j = 0; j < Xline; j++)
                {
                    if (i == 0 || i == Yline - 1)
                    {
                        Console.Write(st.getBorder());
                    }
                    else
                    {
                        if (Map[i, j] == st.getAlive())
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write("{0}", Map[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.Write(st.getBorder());
                Console.WriteLine();
            }
        }

        public void pregame()
        {

            Console.CursorVisible = false;
            int x = 1;
            int y = 2;
            ConsoleKeyInfo k;
            do
            {
                
                Console.Write("Generation: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(GetTimer());
                Console.ForegroundColor = ConsoleColor.Gray;
                show();
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(st.getCursor());
                Console.ForegroundColor = ConsoleColor.Gray;
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.UpArrow)
                {
                    y--;
                    if (y < 2)
                    {
                        y++;
                    }
                }
                else if (k.Key == ConsoleKey.DownArrow)
                {
                    y++;
                    if (y > Yline - 1)
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
                    if (x > Xline - 1)
                    {
                        x--;
                    }
                }
                else if (k.Key == ConsoleKey.Enter)
                {
                    if (Map[y-1, x - 1] == st.getDead())
                    {
                        Map[y-1, x - 1] = st.getAlive();
                    }
                    else Map[y-1, x - 1] = st.getDead();
                }
                Console.Clear();
            } while (k.Key != ConsoleKey.Spacebar);
        }

        public bool update()
        {
            bool result = true;
            Map = CheckUpdate.preUpdate(Map, Yline, Xline, st.getAlive(), st.getWillDie());
            char[,] Map2 = new char[Yline, Xline];
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    Map2[i, j] = Map[i, j];
                }
            }
            if (CheckEnd.EndRepeatTurns(turns, Map2, Yline, Xline) || CheckEnd.endAllDead(Map2, Yline, Xline))
            {
                result = false;
            }
            Timer++;
            turns.Add(Map2);
            return result;
        }
    } 
}