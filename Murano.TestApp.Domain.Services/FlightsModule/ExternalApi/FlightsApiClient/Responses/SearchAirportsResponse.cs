using Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient.Dtos;
using Murano.TestApp.Infrastructure.ExternalApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient.Responses
{
    public class SearchAirportsResponse : ResponseBase
    {
        public List<AirportDto> Airports { get; set; }
    }
}
