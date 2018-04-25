using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class Universe
    {
        public const int Xline = 10;
        public const int Yline = 40;
        public char[,] Map = new char[Xline, Yline];
        public List<char[,]> turns = new List<char[,]>();
        public char dead = ' ';
        public char alive = 'O';
        public char willDie = 'o';
        public char willBorn = '*';
        UpdateGameRules var = new UpdateGameRules();

        public void tempgenerate()
        {
            for (int i = 0; i < Xline; i++)
            {
                for (int j = 0; j < Yline; j++)
                {
                    Map[i, j] = dead;
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
            Map = var.preUpdate(Map, Xline, Yline, alive, willDie);
        }

    } 
}
