namespace Meteo.Helper
{
    using System;
    using System.Windows.Input;

    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
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
