namespace Meteo.Helper.Dependency
{
    using System;

    public class TimeProvider : ITimeProvider
    {
        public string GetHour(long timeStamp, string olsonZone)
        {
            return ConvertTimestampToDateTimeZone(timeStamp, olsonZone).Hour.ToString();
        }

        public string GetDay(long timeStamp, string olsonZone)
        {
            return ConvertTimestampToDateTimeZone(timeStamp, olsonZone).DayOfWeek.ToString();
        }

        private DateTime ConvertTimestampToDateTimeZone(long timeStamp, string olsonZone)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(Constant.OlsonToWindowsTimesDictionnary[olsonZone]);
            var date = DateTimeOffset.FromUnixTimeSeconds(timeStamp).DateTime;
            return TimeZoneInfo.ConvertTime(date, timeZone);
        }
    }
}
