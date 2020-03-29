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

        public Task<Weather> GetWeatherForLocation(string latitude = "37.7749", string longitute = "-122.4194")
        {
            var url = $"{_url}{latitude},{longitute}?lang=en&units=si";
            return url.GetJsonAsync<Weather>();
        }
    }
}