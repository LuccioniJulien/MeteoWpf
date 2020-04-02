using System.Collections.Generic;

namespace Meteo.Helper
{
    public static class Constant
    {
        public const string BaseApi = "https://api.darksky.net/forecast/";
        public const string ApiKey = "7eaedb040777880ed9e876f46f5ee59e";
        public static Dictionary<string, Location> GeoPositionDictionnary { get; } = new Dictionary<string, Location>
        {
            { "Paris", new Location("2.3488","48.8534") }
        };
    }
}