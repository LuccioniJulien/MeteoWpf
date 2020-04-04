namespace Meteo.Helper.Dependency
{
    using System;
    using System.Windows.Input;

    public interface ICommandProvider
    {
        ICommand Get(Action cmd);
        ICommand Get(Action cmd, Func<bool> cmdCanExecute);

    }
}
