using LifeGame.Command;
using System;
using System.Collections.Generic;

namespace LifeGame
{
    public class Universe
    {
        private Map map = new Map();
        private Cursor cursor = new Cursor();
        private Style style = new Style();
        private List<char[,]> turns = new List<char[,]>();
        internal int Timer { get; set; } = 0;
        private UpdateGameRules сheckUpdate = new UpdateGameRules();
        private EndGameRules сheckEnd = new EndGameRules();

        public void EmptyMapGenerate()
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
            ConsoleKeyInfo key;
            CommandFactory factory = new CommandFactory(cursor, map);
            IEnumerable<ICommand> commandList = factory.CommandFiller() ;        
            do
            {  
                Console.Write("Generation: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(Timer);
                Console.ForegroundColor = ConsoleColor.Gray;
                Show();
                Console.SetCursorPosition(cursor.X, cursor.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(style.Cursor);
                Console.ForegroundColor = ConsoleColor.Gray;
                key = Console.ReadKey(true);
                foreach (ICommand command in commandList)
                {
                   if (command.CanExecute(key))
                    {
                        command.Execute();
                    }
                }
                Console.Clear();
            } while (map.Start == false);
        }

        public bool Update()
        {
            bool @continue = true;
            map.Field = сheckUpdate.PreUpdate(map.Field, Map.Yline, Map.Xline, style.Alive, style.WillDie);
            char[,] cloneMap = new char[Map.Yline, Map.Xline];
            for (int i = 0; i < Map.Yline; i++)
            {
                for (int j = 0; j < Map.Xline; j++)
                {
                    cloneMap[i, j] = map.Field[i, j];
                }
            }
            if (сheckEnd.EndRepeatTurns(turns, cloneMap, Map.Yline, Map.Xline) || сheckEnd.EndAllDead(cloneMap, Map.Yline, Map.Xline))
            {
                @continue = false;
            }
            Timer++;
            turns.Add(cloneMap);
            return @continue;
        }
    } 
}