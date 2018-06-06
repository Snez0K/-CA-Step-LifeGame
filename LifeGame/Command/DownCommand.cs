using System;

namespace LifeGame.Command
{
    class DownCommand : ICommand
    {
        Cursor cursor;

        public DownCommand(Cursor cursor)
        {
            this.cursor = cursor;
        }

        public void Execute()
        {
            cursor.Y++;
            if (cursor.Y > Map.Yline -1)
            {
                cursor.Y--;
            }

        }

        bool ICommand.CanExecute(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
            {
                return true;
            }
            else return false;
        }
    }
}