using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace DnD4e
{
    public class DelegatingCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Func<object, bool> _canExecute;

        public DelegatingCommand(Action action)
            : this((o) => action())
        {
        }

        public DelegatingCommand(Action<object> action)
            : this(action, (o) => true)
        {
        }

        public DelegatingCommand(Action<object> action, Func<object, bool> canExecute)
        {
            _action = action;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object paramater)
        {
            return _canExecute(paramater);
        }

        public void Execute(object paramater)
        {
            this._action(paramater);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}