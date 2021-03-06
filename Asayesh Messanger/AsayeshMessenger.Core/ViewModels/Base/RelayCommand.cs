
using System;
using System.Windows.Input;

namespace AsayeshMessenger.Core
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        //private Action _action;
        private Action _action;

        public RelayCommand(Action a)
        {
            _action = a;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
