using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFramework
{
    public class RelayCommand : ICommand
    {
        private Action<object> _action;

        private Predicate<object> _canExecute;

        public RelayCommand(Action<object> action)
        {
            _action = action;
            _canExecute = new Predicate<object>((parameter) => { return true; });
        }

        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
