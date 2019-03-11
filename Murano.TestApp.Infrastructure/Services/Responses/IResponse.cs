using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Services.Responses
{
    public interface IResponse
    {
        bool IsSuccess { get; set; }

        Error Error { get; set; }

        ArgumentErrorsCollection ArgumentErrors { get; set; }
    }
}
