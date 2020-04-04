namespace Meteo.Model
{
    using Newtonsoft.Json;
    using System;
    public class WeatherCurrent
    {
        private string _icon;
        public string Icon
        {
            get => $"/Asset/{_icon}.png";
            set => _icon = value;
        }
        public string Temperature { get; set; }
        public string Summary { get; set; }
        public double WindSpeed { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public string UvIndex { get; set; }
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

        public void Deconstruct(out string summary, out string icon, out string dayOfWeek)
        {
            summary = Summary;
            icon = Icon;
            dayOfWeek = DayOfWeek;
        }
    }
}
