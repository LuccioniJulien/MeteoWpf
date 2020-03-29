using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Model
{
    public class WeatherDailyInfo
    {
        public double Temperature { get; set; }
        public double Time { get; set; }
        private string _icon;

        public string Icon
        {
            get => $"/Asset/{_icon}.png";
            set => _icon = value;
        }

        public double ApparentTemperatureLow { get; set; }
        public double ApparentTemperatureHigh { get; set; }
    }
}