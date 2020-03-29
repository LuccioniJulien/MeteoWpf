using System.Collections.Generic;

namespace Meteo.Model
{
    public class Weather
    {
        public WeatherCurrent Currently { get; set; }
        public WeatherDaily Daily { get; set; }
        public WeatherHourly Hourly { get; set; }

        public void Deconstruct(out WeatherCurrent currently, out List<WeatherDailyInfo> dailyInfo, out List<WeatherHourlyInfo> hourlyInfo)
        {
            currently = Currently;
            dailyInfo = Daily.Data;
            hourlyInfo = Hourly.Data;
        }
    }
}