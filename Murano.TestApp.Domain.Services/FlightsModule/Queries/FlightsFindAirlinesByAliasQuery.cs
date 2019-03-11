using Murano.TestApp.Data.Repositories;
using Murano.TestApp.Domain.Services.FlightsModule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.Queries
{
    public class FlightsFindAirlinesByAliasQuery : IQuery<FlightsFindAirlinesByAliasQuery.Criteria, IEnumerable<AirlineDto>>
    {
        public class Criteria : IQueryCriteria
        {
            public string Alias { get; set; }
        }

        public IEnumerable<AirlineDto> Execute(IDbContext dbContext, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public int GetTotalCount(IDbContext dbContext, Criteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
