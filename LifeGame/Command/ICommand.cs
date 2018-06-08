using System;

namespace LifeGame.Command
{
    internal interface ICommand
    {
        void Execute();

        bool CanExecute(ConsoleKeyInfo key);
    }
}