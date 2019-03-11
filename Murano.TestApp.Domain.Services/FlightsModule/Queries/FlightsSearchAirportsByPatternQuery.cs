using Murano.TestApp.Data.Repositories;
using Murano.TestApp.Domain.Services.FlightsModule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.Queries
{
    public class FlightsSearchAirportsByPatternQuery : IQuery<FlightsSearchAirportsByPatternQuery.Criteria, IEnumerable<AirportDto>>
    {
        public class Criteria : IQueryCriteria
        {
            public string Pattern { get; set; }
        }

        public IEnumerable<AirportDto> Execute(IDbContext dbContext, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public int GetTotalCount(IDbContext dbContext, Criteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
