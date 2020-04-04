namespace Meteo.Model
{
    using System.Collections.Generic;

    public class Weather
    {


        public WeatherCurrent Currently { get; set; }
        public WeatherDaily Daily { get; set; }
        public WeatherHourly Hourly { get; set; }

        public string Timezone { get; set; }

        public void Deconstruct(out WeatherCurrent currently, out List<WeatherDailyInfo> dailyInfo, out List<WeatherHourlyInfo> hourlyInfo, out string timeZoneOlson)
        {
            currently = Currently;
            dailyInfo = Daily.Data;
            hourlyInfo = Hourly.Data;
            timeZoneOlson = Timezone;
        }
    }
}