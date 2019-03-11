using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Services.Requests
{
    public abstract class RequestBase : IRequest
    {
        public virtual string UserToken { get; set; }

        public virtual string PartnerToken { get; set; }
    }
}
