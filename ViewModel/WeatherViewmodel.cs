namespace Meteo.ViewModel
{
    using Meteo.Helper;
    using Meteo.Model;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Meteo.Repository.Api;
    using Meteo.Helper.Dependency;
    using Meteo.Extension;

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
        public List<string> Towns { get; } = Constant.GeoPositionDictionnary.Select(geolocation => geolocation.Key)
                                                                            .ToList();

        private string _selectedTown = Constant.GeoPositionDictionnary.First().Key;
        public string SelectedTown
        {
            get => _selectedTown;
            set
            {
                _selectedTown = value;
                SetWeatherForLocation();
            }
        }

        public Location _location { get => Constant.GeoPositionDictionnary[SelectedTown]; }
        public ObservableCollection<WeatherDailyInfo> DailyInfo { get; } = new ObservableCollection<WeatherDailyInfo>();
        public ObservableCollection<WeatherHourlyInfo> HourlyInfo { get; } = new ObservableCollection<WeatherHourlyInfo>();

        private ICommand _cmdInit;
        public ICommand CmdInit => _cmdInit ?? (_cmdInit = CommandProvider.Get(SetInitialWeather));

        #region Dependency
        private IWeatherApi ApiRepo { get; set; }
        private ICommandProvider CommandProvider { get; set; }
        private ITimeProvider TimeProvider { get; set; }
        #endregion

        #endregion

        #region Constructor
        public WeatherViewModel() { }

        public WeatherViewModel(IWeatherApi apiRepo, ICommandProvider commandProvider, ITimeProvider timeProvider)
        {
            ApiRepo = apiRepo;
            CommandProvider = commandProvider;
            TimeProvider = timeProvider;
            SetInitialWeather();
        }

        #endregion
        private async void SetInitialWeather()
        {
            var (weather, dailyInfo, hourlyInfo, timZoneOlson) = await ApiRepo.GetWeatherForLocation(_location);

            (Summary, Icon, DayOfWeek) = weather;
            Icon = weather.Icon;

            SetWeatherListInfo(dailyInfo, hourlyInfo, timZoneOlson);
        }

        private async void SetWeatherForLocation()
        {
            var (weather, dailyInfo, hourlyInfo, timZoneOlson) = await ApiRepo.GetWeatherForLocation(_location);
            (Summary, Icon, DayOfWeek) = weather;
            Icon = weather.Icon;

            DailyInfo.Clear();
            HourlyInfo.Clear();

            SetWeatherListInfo(dailyInfo, hourlyInfo, timZoneOlson);
        }

        private void SetWeatherListInfo(List<WeatherDailyInfo> dailyInfo, List<WeatherHourlyInfo> hourlyInfo, string timZoneOlson)
        {
            dailyInfo.Skip(1)
                     .Select(info => info.SetDailyDayToZone(TimeProvider.GetDay(info.Time, timZoneOlson)))
                     .ToList()
                     .ForEach(DailyInfo.Add);

            var hinfo = hourlyInfo.Take(12)
                      .Select(info => info.SetHourToZone(TimeProvider.GetHour(info.Time, timZoneOlson)))
                      .ToList();
            hinfo[0].HourOfDay = "Now";
            hinfo.ForEach(HourlyInfo.Add);
        }


    }
}