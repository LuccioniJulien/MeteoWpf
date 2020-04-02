using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Helper
{
    public struct Location
    {
        public Location(string longitude, string latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
