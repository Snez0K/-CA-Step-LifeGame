using System.Collections.Generic;

namespace LifeGame.Command
{
    class CommandFactory
    {
        private List<ICommand> list = new List<ICommand>();
        Map map;
        Cursor cursor;

        public CommandFactory(Cursor cursor, Map map)
        {
            this.cursor = cursor;
            this.map = map;
        }

        public List<ICommand> Factory()
        {
            SpaceCommand space = new SpaceCommand(map);
            EnterCommand enter = new EnterCommand(cursor, map);
            LeftCommand left = new LeftCommand(cursor);
            UpCommand up = new UpCommand(cursor);
            RightCommand right = new RightCommand(cursor);
            DownCommand down = new DownCommand(cursor);
            list.Add(space);
            list.Add(enter);
            list.Add(left);
            list.Add(up);
            list.Add(right);
            list.Add(down);
            return list;
        }
    }
}