using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Model
{
    public class WeatherHourlyInfo
    {
        public double Temperature { get; set; }
        public Int64 Time { get; set; }

        [JsonIgnore]
        public string HourOfDay
        {
            get
            {
                var date = DateTimeOffset.FromUnixTimeSeconds(Time).DateTime;
                return date.Hour.ToString();
            }
        }

        private string _icon;
        public string Icon
        {
            get => $"/Asset/{_icon}.png";
            set => _icon = value;
        }
        [JsonIgnore]
        public string HourlyTemperature { get => $"{Temperature}°"; }

    }
}