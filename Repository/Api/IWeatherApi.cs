using System.Threading.Tasks;
using Meteo.Model;

namespace Meteo.Repository.Api
{
    public interface IWeatherApi
    {
        Task<Weather> GetWeatherForLocation(string latitude, string longitute);
    }
}