namespace Meteo.Model
{
    using Newtonsoft.Json;
    using System;
    public class WeatherHourlyInfo
    {
        public double Temperature { get; set; }
        public long Time { get; set; }

        [JsonIgnore]
        public string HourOfDay { get; set; }

        private string _icon;
        public string Icon
        {
            get => $"/Asset/{_icon}.png";
            set => _icon = value;
        }
        [JsonIgnore]
        public string HourlyTemperature { get => $"{(int)Temperature}°"; }

    }
}