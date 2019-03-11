using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient.Dtos
{
    public class AirportDto
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "alias")]
        public string Alias { get; set; }

        [DeserializeAs(Name = "city")]
        public string City { get; set; }

        [DeserializeAs(Name = "county")]
        public string Country { get; set; }

        [DeserializeAs(Name = "latitude")]
        public double Latitude { get; set; }

        [DeserializeAs(Name = "longitude")]
        public double Longitude { get; set; }

        [DeserializeAs(Name = "altitude")]
        public int Altitude { get; set; }
    }
}
