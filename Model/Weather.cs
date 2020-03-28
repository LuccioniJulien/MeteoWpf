using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Model
{
    public class Weather
    {
        public string Icon { get; set; }
        public string Temperature { get; set; }
        public string Summary { get; set; }
        public double WindSpeed { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public string UvIndex { get; set; }

        public List<WeatherDailyInfo> WeatherDailyInfo { get; set; }
    }
}
