using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsayeshMessenger.Core
{ 
    class ParametrizedRelayCommand: ICommand
    {
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        //private Action _action;
        private Action<object> _action;

        public ParametrizedRelayCommand(Action<object> a)
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
