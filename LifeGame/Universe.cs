using System;
using System.Collections.Generic;
using LifeGame.Command;

namespace LifeGame
{
    public class Universe
    {
        private Map map = new Map();
        private Cursor cursor = new Cursor();
        private Style style = new Style();
        private List<char[,]> turns = new List<char[,]>();
        private int Timer = 0;
        private UpdateGameRules CheckUpdate = new UpdateGameRules();
        private EndGameRules CheckEnd = new EndGameRules();

        public int GetTimer() {
            return Timer;
        }

        public void Tempgenerate()
        {
            for (int i = 0; i < Map.Yline; i++)
            {
                for (int j = 0; j < Map.Xline; j++)
                {
                    map.Field[i, j] = style.Dead;
                }
            }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Map.Yline; i++)
            {
                Console.Write(style.Border);
                for (int j = 0; j < Map.Xline; j++)
                {
                    if (i == 0 || i == Map.Yline - 1)
                    {
                        Console.Write(style.Border);
                    }
                    else
                    {
                        if (map.Field[i, j] == style.Alive)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write("{0}", map.Field[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.Write(style.Border);
                Console.WriteLine();
            }
        }

        public void Pregame()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo k;
            CommandFactory factory = new CommandFactory(cursor, map);
            List<ICommand> list = factory.Factory() ;        
            do
            {  
                Console.Write("Generation: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(GetTimer());
                Console.ForegroundColor = ConsoleColor.Gray;
                Show();
                Console.SetCursorPosition(cursor.X, cursor.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(style.Cursor);
                Console.ForegroundColor = ConsoleColor.Gray;
                k = Console.ReadKey(true);
                foreach (ICommand i in list)
                {
                   if (i.CanExecute(k))
                    {
                        i.Execute();
                    }
                } 
                Console.Clear();
            } while (map.Start == false);
        }

        public bool Update()
        {
            bool result = true;
            map.Field = CheckUpdate.PreUpdate(map.Field, Map.Yline, Map.Xline, style.Alive, style.WillDie);
            char[,] Map2 = new char[Map.Yline, Map.Xline];
            for (int i = 0; i < Map.Yline; i++)
            {
                for (int j = 0; j < Map.Xline; j++)
                {
                    Map2[i, j] = map.Field[i, j];
                }
            }
            if (CheckEnd.EndRepeatTurns(turns, Map2, Map.Yline, Map.Xline) || CheckEnd.EndAllDead(Map2, Map.Yline, Map.Xline))
            {
                result = false;
            }
            Timer++;
            turns.Add(Map2);
            return result;
        }
    } 
}