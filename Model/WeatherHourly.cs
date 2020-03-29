using System.Collections.Generic;

namespace Meteo.Model
{
    public class WeatherHourly
    {
        public string Summary { get; set; }
        public List<WeatherHourlyInfo> Data { set; get; }
    }
}