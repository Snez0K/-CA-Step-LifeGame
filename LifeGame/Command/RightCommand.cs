using System;

namespace LifeGame.Command
{
    internal class RightCommand : ICommand
    {
        private Cursor cursor;

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
            return key.Key == ConsoleKey.RightArrow;
        }
    }
}