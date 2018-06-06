using System;

namespace LifeGame.Command
{
    interface ICommand
    {
        void Execute();

        bool CanExecute(ConsoleKeyInfo key);
    }
}