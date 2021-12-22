
using System;
using System.Windows.Input;

namespace Asayesh_Messanger
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        //private Action _action;
        private Action<object> _action;

        public RelayCommand(Action<object> a)
        {
            _action = a;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
