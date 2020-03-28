using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meteo.Helper
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action _cmd;
        private readonly Func<bool> _cmdCanExecute;
        public Command(Action cmd)
        {
            _cmd = cmd;
            _cmdCanExecute = () => true;
        }

        public Command(Action cmd, Func<bool> cmdCanExecute)
        {
            _cmd = cmd;
            _cmdCanExecute = cmdCanExecute;
        }

        public bool CanExecute(object parameter) => _cmdCanExecute.Invoke();

        public void Execute(object parameter) => _cmd.Invoke();
    }
}
