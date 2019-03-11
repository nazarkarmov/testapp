using Murano.TestApp.Data.Repositories;
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
    public class FlightsSearchAirportsByPatternCommand : InternalCommandBase<IUnitOfWork, FlightsSearchAirportsByPatternRequest, FlightsSearchAirportsByPatternResponse>
    {
        public FlightsSearchAirportsByPatternCommand(IUnitOfWork unitOfWork) : base(unitOfWork)
        {         
        }

        protected override void Execute(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
