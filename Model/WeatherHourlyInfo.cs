using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Model
{
    public class WeatherHourlyInfo
    {
        public double Time { get; set; }
        public string Icon { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
    }
}