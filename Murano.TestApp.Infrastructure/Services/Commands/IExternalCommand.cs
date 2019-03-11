using Murano.TestApp.Infrastructure.Services.Requests;
using Murano.TestApp.Infrastructure.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Services.Commands
{
    public interface IExternalCommand
    {

    }
    public interface IExternalCommand<in TRequest, out TResponse> : IExternalCommand
        where TRequest : class, IRequest
        where TResponse : Response
    {
        TResponse Execute(TRequest request, CancellationToken cancellationToken);
    }
}
