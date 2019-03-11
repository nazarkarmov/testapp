using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.Dtos
{
    public class RouteDto
    {
        public string AirlineCode { get; set; }

        public string SourceAirportCode { get; set; }

        public string DestinationAirportCode { get; set; }
    }
}
