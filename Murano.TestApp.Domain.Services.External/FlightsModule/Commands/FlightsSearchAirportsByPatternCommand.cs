using Murano.TestApp.Domain.Services.FlightsModule.Requests;
using Murano.TestApp.Domain.Services.FlightsModule.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.External.FlightsModule.Commands
{
    public class FlightsSearchAirportsByPatternCommand : AnonymousExternalCommandBase<FlightsSearchAirportsByPatternRequest, FlightsSearchAirportsByPatternResponse>
    {
        private readonly Services.FlightsModule.IFlightsService _flightsService;

        protected override bool Authenticate()
        {
            return true;
        }

        protected override FlightsSearchAirportsByPatternResponse ExecuteInternal(FlightsSearchAirportsByPatternRequest request)
        {
            return _flightsService.SearchAirports(request);
        }
    }
}
