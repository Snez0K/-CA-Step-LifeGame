using System;

namespace LifeGame.Command
{
    internal class LeftCommand : ICommand
    {
        private Cursor cursor;

        public LeftCommand(Cursor cursor)
        {
            this.cursor = cursor;
        }

        public bool CanExecute(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Execute()
        {
            cursor.X--;
            if (cursor.X < 1)
            {
                cursor.X++;
            }
        }
    }
}