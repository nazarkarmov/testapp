using Murano.TestApp.Domain.Services.External.FlightsModule.Commands;
using Murano.TestApp.Domain.Services.FlightsModule.Requests;
using Murano.TestApp.Domain.Services.FlightsModule.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.External.FlightsModule
{
    public class FlightsService : IFlightsService
    {
        private readonly ExternalCommandFactory _factory;

        public FlightsService(ExternalCommandFactory factory)
        {
            _factory = factory;
        }

        public FlightsFindAirlinesByAliasResponse GetAirlines(FlightsFindAirlinesByAliasRequest request)
        {
            var command = _factory.Create<FlightsFindAirlinesByAliasCommand>();
            return command.Execute(request, CancellationToken.None);
        }

        public FlightsSearchAirportsByPatternResponse SearchAirports(FlightsSearchAirportsByPatternRequest request)
        {
            var command = _factory.Create<FlightsSearchAirportsByPatternCommand>();
            return command.Execute(request, CancellationToken.None);
        }

        public FlightsSearchRoutesByAirportResponse SearchRoutes(FlightsSearchRoutesByAirportRequest request)
        {
            var command = _factory.Create<FlightsSearchRoutesByAirportCommand>();
            return command.Execute(request, CancellationToken.None);
        }
    }
}
