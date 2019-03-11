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
    public interface IInternalCommand
    {

    }
    public interface IInternalCommand<in TInternalRequest, out TInternalResponse> : IInternalCommand
        where TInternalRequest : class, IRequest
        where TInternalResponse : class, IResponse
    {

        TInternalResponse Execute(TInternalRequest request, CancellationToken cancellationToken);
    }
}
