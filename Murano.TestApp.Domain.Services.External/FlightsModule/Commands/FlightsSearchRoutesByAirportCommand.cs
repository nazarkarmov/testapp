using Murano.TestApp.Domain.Services.FlightsModule.Requests;
using Murano.TestApp.Domain.Services.FlightsModule.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.External.FlightsModule.Commands
{
    public class FlightsSearchRoutesByAirportCommand : AnonymousExternalCommandBase<FlightsSearchRoutesByAirportRequest, FlightsSearchRoutesByAirportResponse>
    {
        private readonly Services.FlightsModule.IFlightsService _flightsService;

        protected override bool Authenticate()
        {
            return true;
        }

        protected override FlightsSearchRoutesByAirportResponse ExecuteInternal(FlightsSearchRoutesByAirportRequest request)
        {
            return _flightsService.SearchRoutes(request);
        }
    }
}
