using System.Threading.Tasks;
using Meteo.Model;

namespace Meteo.Repository.Api
{
    public interface IWeatherApi
    {
        Task<Weather> GetWeatherForLocation(string latitude = "37.7749", string longitute = "-122.4194");
    }
}