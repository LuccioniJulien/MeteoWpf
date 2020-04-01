namespace Meteo.Model
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class WeatherDailyInfo
    {
        public double Temperature { get; set; }
        public Int64 Time { get; set; }
        [JsonIgnore]
        public string DayOfWeek
        {
            get
            {
                var date = DateTimeOffset.FromUnixTimeSeconds(Time).DateTime;
                return date.DayOfWeek.ToString();
            }
        }

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