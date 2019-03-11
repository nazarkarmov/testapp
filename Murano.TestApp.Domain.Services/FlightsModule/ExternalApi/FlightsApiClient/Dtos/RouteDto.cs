using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient.Dtos
{
    public class RouteDto
    {
        [DeserializeAs(Name = "airline")]
        public string AirlineCode { get; set; }

        [DeserializeAs(Name = "srcAirport")]
        public string SourceAirportCode { get; set; }

        [DeserializeAs(Name = "destAirport")]
        public string DestinationAirportCode { get; set; }
    }
}
