using Murano.TestApp.Domain.Services.FlightsModule.Requests;
using Murano.TestApp.Domain.Services.FlightsModule.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.External.FlightsModule
{
    public interface IFlightsService
    {
        FlightsFindAirlinesByAliasResponse GetAirlines(FlightsFindAirlinesByAliasRequest request);

        FlightsSearchAirportsByPatternResponse SearchAirports(FlightsSearchAirportsByPatternRequest request);

        FlightsSearchRoutesByAirportResponse SearchRoutes(FlightsSearchRoutesByAirportRequest request);
    }
}
