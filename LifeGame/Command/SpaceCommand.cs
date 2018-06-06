using System;

namespace LifeGame.Command
{
    class SpaceCommand : ICommand
    {
        Map map = new Map();

        public SpaceCommand(Map map)
        {
            this.map = map;
        }

        public bool CanExecute(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Spacebar)
            {
                return true;
            }
            else return false;
        }

        public void Execute()
        {
            map.Start = true;
        }
    }
}