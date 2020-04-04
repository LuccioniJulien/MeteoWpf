
namespace Meteo.Model
{
    using System.Collections.Generic;

    public class WeatherDaily
    {
        public string Summary { get; set; }
        public List<WeatherDailyInfo> Data { set; get; }
    }
}