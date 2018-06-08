using System;

namespace LifeGame.Command
{
    internal class UpCommand : ICommand
    {
        private Cursor cursor;

        public UpCommand(Cursor cursor)
        {
            this.cursor = cursor;
        }

        public void Execute()
        {
            cursor.Y--;
            if (cursor.Y < 2)
            {
                cursor.Y++;
            }
        }

        bool ICommand.CanExecute(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}