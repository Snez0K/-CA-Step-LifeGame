using System;

namespace LifeGame.Command
{
    internal class RightCommand : ICommand
    {
        Cursor cursor;

        public RightCommand(Cursor cursor)
        {
            this.cursor = cursor;
        }

        public void Execute()
        {
            cursor.X++;
            if (cursor.X > Map.Xline - 1)
            {
                cursor.X--;
            }
        }

        bool ICommand.CanExecute(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.RightArrow)
            {
                return true;
            }
            else return false;
        }
    }
}