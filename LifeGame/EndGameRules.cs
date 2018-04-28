using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class EndGameRules
    {
        public bool endAllDead(char[,] Map, int Yline, int Xline)
        {
            for (int i = 0; i < Yline; i++)
            {
                for (int j = 0; j < Xline; j++)
                {
                    if (Map[i, j] == '*')
                    {
                        return false;
                    }
                    else if (Map[i, j] == 'O')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Вселенная в точности (без сдвигов и поворотов) повторяет себя на одном из более ранних шагов (образуется цикличность жизни).
        public bool EndRepeatTurns(List<char[,]> Turns, char[,] Map, int Yline, int Xline)
        {
            //int count = Turns.Count;
            int timer = 0;

            int a = 0;

            foreach (char[,] item in Turns)
            {
                Console.WriteLine("№" + a);
                Console.ForegroundColor = ConsoleColor.Green;
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
                    a++;
                }
            }



            foreach (char[,] item in Turns)
            {
                //temp
                Console.WriteLine("MAP:");
                Console.ForegroundColor = ConsoleColor.Green;
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


                for (int i = 0; i < Yline; i++)
                {
                    for (int j = 0; j < Xline; j++)
                    {
                        if (Map[i, j] != item[i, j])
                        {
                            timer = -9999;
                        }
                        else if (Map[i, j] == item[i, j])
                        {
                            timer++;
                            Console.Write(timer + " ");
                        }
                    }
                }
            }

            if (timer > 0)
            {
                Console.Write("Final timer: " +timer);
                return true;
            }

            timer = 0;
            return false;
        }
    }
}
