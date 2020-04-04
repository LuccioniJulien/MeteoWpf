namespace Meteo.Model
{
    using Newtonsoft.Json;
    using System;
    public class WeatherDailyInfo
    {
        public double Temperature { get; set; }
        public long Time { get; set; }
        [JsonIgnore]
        public string DayOfWeek { get; set; }

        private string _icon;
        public string Icon
        {
            get => $"/Asset/{_icon}.png";
            set => _icon = value;
        }
        public double ApparentTemperatureLow { get; set; }
        [JsonIgnore]
        public int TemperatureLow { get => (int)ApparentTemperatureLow; }
        public double ApparentTemperatureHigh { get; set; }
        [JsonIgnore]
        public int TemperatureHigh { get => (int)ApparentTemperatureHigh; }
    }
}