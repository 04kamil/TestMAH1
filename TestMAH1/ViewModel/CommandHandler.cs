using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMAH1.ViewModel
{
    public class CommandHandler : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _action;
        private Func<bool> _canExecute;

        public CommandHandler(Action action,Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
