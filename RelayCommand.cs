using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Grafika4
{
    public class RelayCommand : ICommand
    {
        private readonly Action _action;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action)
        {
            _action = action;
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

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _action;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is T typedParameter)
            {
                _action(typedParameter);
            }
        }
    }

}
