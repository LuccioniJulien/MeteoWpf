namespace Meteo.Extension
{
    using Meteo.Model;
    public static class WeatherHourlyInfoExtension
    {
        public static WeatherHourlyInfo SetHourToZone(this WeatherHourlyInfo hourlyInfo, string hourOfDay)
        {
            hourlyInfo.HourOfDay = hourOfDay;
            return hourlyInfo;
        }
    }
}
