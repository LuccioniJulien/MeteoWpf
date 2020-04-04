namespace Meteo.Repository.Api
{
    using System.Threading.Tasks;
    using Meteo.Helper;
    using Meteo.Model;

    public interface IWeatherApi
    {
        Task<Weather> GetWeatherForLocation(Location location);
    }
}