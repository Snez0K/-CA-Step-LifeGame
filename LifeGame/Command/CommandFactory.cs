using System.Collections.Generic;

namespace LifeGame.Command
{
    internal class CommandFactory
    {
        private ICollection<ICommand> commandToCheck = new List<ICommand>();
        private Map map;
        private Cursor cursor;

        public CommandFactory(Cursor cursor, Map map)
        {
            this.cursor = cursor;
            this.map = map;
        }

        public IEnumerable<ICommand> CommandFiller()
        {
            SpaceCommand space = new SpaceCommand(map);
            EnterCommand enter = new EnterCommand(cursor, map);
            LeftCommand left = new LeftCommand(cursor);
            UpCommand up = new UpCommand(cursor);
            RightCommand right = new RightCommand(cursor);
            DownCommand down = new DownCommand(cursor);
            commandToCheck.Add(space);
            commandToCheck.Add(enter);
            commandToCheck.Add(left);
            commandToCheck.Add(up);
            commandToCheck.Add(right);
            commandToCheck.Add(down);
            return commandToCheck;
        }
    }
}