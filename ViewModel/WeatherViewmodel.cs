﻿using Meteo.Helper;
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
    public class WeatherViewModel : BaseViewModel<WeatherCurrent>
    {
        #region Getter Setter

        private string _summary;
        public string Summary
        {
            get => _summary;
            set => SetProperty(ref _summary, value);
        }

        private string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private string _dayOfWeek;
        public string DayOfWeek
        {
            get => _dayOfWeek;
            set => SetProperty(ref _dayOfWeek, value);
        }
        public List<string> Towns { get; } = Constant.GeoPositionDictionnary.Select(geolocation => geolocation.Key).ToList();
        public string SelectedTown { get; set; }

        public Location _getLocation { get => Constant.GeoPositionDictionnary[SelectedTown]; }
        public ObservableCollection<WeatherDailyInfo> DailyInfo { get; } = new ObservableCollection<WeatherDailyInfo>();
        public ObservableCollection<WeatherHourlyInfo> HourlyInfo { get; } = new ObservableCollection<WeatherHourlyInfo>();

        private ICommand _cmdInit;
        public ICommand CmdInit => _cmdInit ?? (_cmdInit = new Command(SetWeather));

        private IWeatherApi ApiRepo { get; set; }
        #endregion

        #region Constructor
        public WeatherViewModel() { }

        public WeatherViewModel(IWeatherApi apiRepo)
        {
            ApiRepo = apiRepo;
            SetWeather();
        }

        #endregion
        private async void SetWeather()
        {
            var (weather, dailyInfo, hourlyInfo) = await ApiRepo.GetWeatherForLocation();

            (Summary, Icon, DayOfWeek) = weather;
            Icon = weather.Icon;

            dailyInfo.Skip(1)
                     .ToList()
                     .ForEach(DailyInfo.Add);

            hourlyInfo.Take(12)
                      .ToList()
                      .ForEach(HourlyInfo.Add);
        }
    }
}