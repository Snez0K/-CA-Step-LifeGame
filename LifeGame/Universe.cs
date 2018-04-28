using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LifeGame
{
    public class Universe
    {
        public const int Yline = 10;
        public const int Xline = 40;
        public char[,] Map = new char[Yline, Xline];
        public List<char[,]> turns = new List<char[,]>();
        public char dead = ' ';
        public char alive = 'O';
        public char willDie = 'o';
        public char willBorn = '*';
        UpdateGameRules lol = new UpdateGameRules();
        EndGameRules kek = new EndGameRules();
        int turn = 0;

        public void tempgenerate()
        {
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    Map[i, j] = dead;
                }
            }
        }

        public void show()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Yline; i++)
            {
                Console.Write("+");
                for (int j = 0; j < Xline; j++)
                {
                    if (i == 0 || i == Yline - 1)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        if (Map[i, j] == alive)
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
                    if (y > Yline - 2)
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
                    if (Map[y, x - 1] == dead)
                    {
                        Map[y, x - 1] = alive;
                    }
                    else Map[y, x - 1] = dead;
                }
                Console.Clear();
            } while (k.Key != ConsoleKey.Spacebar);
        }

        public void update()
        {
            //temp
            foreach (var item in turns)
            {
                Console.WriteLine("item:");
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < Yline; i++)
                {
                    Console.Write("+");
                    for (int j = 0; j < Xline; j++)
                    {
                        if (i == 0 || i == Yline - 1)
                        {
                            Console.Write("+");
                        }
                        else
                        {
                            if (item[i, j] == 'O')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            Console.Write("{0}", item[i, j]);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    Console.Write("+");
                    Console.WriteLine();
                }
            }

            Map = lol.preUpdate(Map, Yline, Xline, alive, willDie);
            if (kek.EndRepeatTurns(turns, Map, Yline, Xline) && turn !=0 || kek.endAllDead(Map, Yline, Xline))
            {
                Console.WriteLine("Конец игры");
                Thread.Sleep(100000000);
            }
            turn++;
            turns.Add(Map);
        }
    } 
}
