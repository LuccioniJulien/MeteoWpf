namespace Meteo.Extension
{
    using Meteo.Model;

    public static class WeatherDailyInfoExtension
    {
        public static WeatherDailyInfo SetDailyDayToZone(this WeatherDailyInfo dailyInfo, string dayOfWeek)
        {
            dailyInfo.DayOfWeek = dayOfWeek;
            return dailyInfo;
        }
    }
}
