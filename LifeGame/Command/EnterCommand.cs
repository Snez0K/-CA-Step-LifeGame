using System;

namespace LifeGame.Command
{
    internal class EnterCommand : ICommand
    {
        Style style = new Style();
        Map map;

        Cursor cursor;

        public EnterCommand(Cursor cursor, Map map)
        {
            this.cursor = cursor;
            this.map = map;
        }

        public bool CanExecute(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else return false;
        }

        public void Execute()
        {
            if (map.Field[cursor.Y - 1, cursor.X - 1] == style.Dead)
            {
                map.Field[cursor.Y - 1, cursor.X - 1] = style.Alive;
            }
            else map.Field[cursor.Y - 1, cursor.X - 1] = style.Dead;
        }
    }
}