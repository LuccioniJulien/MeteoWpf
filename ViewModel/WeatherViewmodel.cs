using Meteo.Helper;
using Meteo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        public ICommand CmdInit
        {
            get => _cmdInit ?? (_cmdInit = new Command(Init));
        }
        #endregion

        public WeatherViewModel()
        {

        }

        public void Init()
        {
            var dailyInfosList = new List<WeatherDailyInfo> { new WeatherDailyInfo { Temperature = 10 }, new WeatherDailyInfo { Temperature = 20 } };
            dailyInfosList.ForEach(DailyInfo.Add);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(name, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
