using System;
using System.Threading.Tasks;
using Flurl.Http;
using Meteo.Helper;
using Meteo.Model;

namespace Meteo.Repository.Api
{
    public class WeatherApi : IWeatherApi
    {
        private readonly string _url = $"{Constant.BaseApi}{Constant.ApiKey}/";

        public Task<Weather> GetWeatherForLocation(Location location)
        {
            var url = $"{_url}{location.Latitude},{location.Longitude}?lang=en&units=si";
            return url.GetJsonAsync<Weather>();
        }
    }
}