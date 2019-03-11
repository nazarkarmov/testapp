using Microsoft.Practices.TransientFaultHandling;
using Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient.Dtos;
using Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient.Responses;
using Murano.TestApp.Infrastructure.ExternalApi;
using Murano.TestApp.Infrastructure.ExternalApi.Responses;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient
{
    public class FlightsApiClient : ApiClientBase
    {
        public FlightsApiClient() : base("https://homework.appulate.com/api/")
        {
        }

        public GetAirlinesResponse GetAirlines(string alias)
        {
            var request = InitRequest($"Airline/{alias}", Method.GET);

            return GetResponse(request, 
                CancellationToken.None,
                (content) => new GetAirlinesResponse { Airlines = DeserializeArray<List<AirlineDto>>(content)
             });
        }

        public SearchAirportsResponse SearchAirports(string pattern)
        {
            var request = InitRequest("Airport/search", Method.GET);
            request.AddQueryParameter("pattern", pattern);

            return  GetResponse(request, CancellationToken.None, 
                (content) => new SearchAirportsResponse { Airports = DeserializeArray<List<AirportDto>>(content)
                });
        }

        public SearchRoutesResponse GetRoutes(CancellationToken cancellationToken, string airport)
        {
            var request = InitRequest("Route/outgoing", Method.GET);
            request.AddQueryParameter("airport", airport);

            return GetResponse(request,
                cancellationToken,
                (content) => new SearchRoutesResponse { Routes = DeserializeArray<List<RouteDto>>(content)
           });
        }

        public T DeserializeArray<T>(IRestResponse response)
        {
            return Deserializer.Deserialize<T>(response);
        }
    }
}
