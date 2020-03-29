using Meteo.Helper;
using Meteo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Meteo.Repository.Api;

namespace Meteo.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        #region Getter Setter

        private Weather _weatherForecast;

        public Weather WeatherForecast
        {
            get => _weatherForecast;
            set
            {
                _weatherForecast = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<WeatherDailyInfo> DailyInfo { get; } = new ObservableCollection<WeatherDailyInfo>();

        private ICommand _cmdInit;
        public ICommand CmdInit => _cmdInit ?? (_cmdInit = new Command(InitData));

        #endregion

        public WeatherViewModel()
        {
        }

        private async void InitData()
        {
            var ok = new WeatherApi();
            var (o, s, d) = await ok.GetWeatherForLocation();
            s.ForEach(DailyInfo.Add);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(name, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}