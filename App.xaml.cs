namespace Meteo
{
    using Meteo.Helper.Dependency;
    using Meteo.Repository.Api;
    using Meteo.View;
    using Meteo.ViewModel;
    using System.Windows;
    using Unity;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();
            container.RegisterType<IWeatherApi, WeatherApi>();
            container.RegisterType<ICommandProvider, CommandProvider>();
            container.RegisterType<ITimeProvider, TimeProvider>();

            var viewViewModel = container.Resolve<WeatherViewModel>();
            var window = new Weather { DataContext = viewViewModel };
            window.Show();
        }

    }
}
