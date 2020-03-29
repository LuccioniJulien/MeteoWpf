using System.Collections.Generic;

namespace Meteo.Model
{
    public class WeatherDaily
    {
        public string Summary { get; set; }
        public List<WeatherDailyInfo> Data { set; get; }
    }
}