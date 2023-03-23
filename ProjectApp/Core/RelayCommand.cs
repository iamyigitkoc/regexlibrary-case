using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectApp.Core
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecutePredicate;

        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecutePredicate)
        {
            _canExecutePredicate = canExecutePredicate;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecutePredicate(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
