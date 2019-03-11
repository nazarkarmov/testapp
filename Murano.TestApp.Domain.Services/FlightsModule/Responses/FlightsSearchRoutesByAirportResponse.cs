using Murano.TestApp.Domain.Services.FlightsModule.Dtos;
using Murano.TestApp.Infrastructure.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.Responses
{
    public class FlightsSearchRoutesByAirportResponse : Response
    {
        public RouteDto[] Routes { get; set; }
    }
}
