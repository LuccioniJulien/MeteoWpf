namespace Meteo.Helper.Dependency
{
    using System;
    using System.Windows.Input;

    public class CommandProvider : ICommandProvider
    {
        public ICommand Get(Action cmd) => new Command(cmd);

        public ICommand Get(Action cmd, Func<bool> cmdCanExecute)
        {
            return new Command(cmd, cmdCanExecute);
        }
    }
}
