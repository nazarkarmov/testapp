using Murano.TestApp.Data.Repositories;
using Murano.TestApp.Domain.Services.FlightsModule.Dtos;
using Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient;
using Murano.TestApp.Domain.Services.FlightsModule.Queries;
using Murano.TestApp.Domain.Services.FlightsModule.Requests;
using Murano.TestApp.Domain.Services.FlightsModule.Responses;
using Murano.TestApp.Infrastructure.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.Commands
{
    public class FlightsFindAirlinesByAliasCommand : InternalCommandBase<IUnitOfWork, FlightsFindAirlinesByAliasRequest, FlightsFindAirlinesByAliasResponse>
    {
        private FlightsApiClient FlightsApiClient { get; set; } = new FlightsApiClient();

        public FlightsFindAirlinesByAliasCommand(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override void Execute(CancellationToken cancellationToken)
        {
            List<AirlineDto> result = null;

            var cacheKey = L3CacheKey.Gen(L3CacheDataType.Airlines, Request.Alias);

            if (Request.UseCache)
            {
                if (UnitOfWork.DbContext.L3Cache.Exists(cacheKey))
                {
                    result = UnitOfWork.DbContext.L3Cache.Get<List<AirlineDto>>(cacheKey);
                }
            }

            int totalCount = 0;

            if (result == null)
            {
                var query = new FlightsFindAirlinesByAliasQuery();

                var criteria = new FlightsFindAirlinesByAliasQuery.Criteria
                {
                    Alias = Request.Alias
                };

                var queryResult = UnitOfWork.Query(query, criteria);
                result = queryResult.ToList();

                if (result.Any() && Request.UseCache)
                {
                    UnitOfWork.DbContext.L3Cache.Set(cacheKey, result);
                }

                totalCount = UnitOfWork.QueryTotalItems(query, criteria);
            }

            if (totalCount == 0)
            {
                var getAirlinesResponse = FlightsApiClient.GetAirlines(Request.Alias);
                if (getAirlinesResponse.IsSuccess && getAirlinesResponse.Airlines.Any() && Request.UseCache)
                {
                    //result = getAirlinesResponse.Airlines

                    UnitOfWork.DbContext.L3Cache.Set(cacheKey, result);
                }
            }
        }
    }
}
