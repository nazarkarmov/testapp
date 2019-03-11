using Murano.TestApp.Data.Repositories;
using Murano.TestApp.Infrastructure.Services.Requests;
using Murano.TestApp.Infrastructure.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.External
{
    public abstract class AnonymousExternalCommandBase<TRequest, TResponse> :
        ExternalCommandBase<TRequest, TResponse>
        where TRequest : class, IRequest
        where TResponse : Response, new()
    {
        protected override bool Authenticate()
        {
            return true;
        }

        protected override void LimitDbContext(IDbContext dbContext)
        {
            //not applicable for anonymous users
        }
    }
}
