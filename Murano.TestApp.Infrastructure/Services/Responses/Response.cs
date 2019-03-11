using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Services.Responses
{
    public abstract class Response : IResponse
    {
        public bool IsSuccess { get; set; }

        public Error Error { get; set; }

        public virtual ArgumentErrorsCollection ArgumentErrors { get; set; }


        protected Response()
        {
            ArgumentErrors = new ArgumentErrorsCollection();
        }
    }
}
