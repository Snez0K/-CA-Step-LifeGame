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
            return key.Key == ConsoleKey.LeftArrow;
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