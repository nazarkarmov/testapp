using Murano.TestApp.Domain.Services.FlightsModule.Requests;
using Murano.TestApp.Domain.Services.FlightsModule.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.External.FlightsModule.Commands
{
    public class FlightsFindAirlinesByAliasCommand : AnonymousExternalCommandBase<FlightsFindAirlinesByAliasRequest, FlightsFindAirlinesByAliasResponse>
    {
        private readonly Services.FlightsModule.IFlightsService _flightsService;

        protected override bool Authenticate()
        {
            return true;
        }

        protected override FlightsFindAirlinesByAliasResponse ExecuteInternal(FlightsFindAirlinesByAliasRequest request)
        {
            return _flightsService.GetAirlines(request);
        }
    }
}
