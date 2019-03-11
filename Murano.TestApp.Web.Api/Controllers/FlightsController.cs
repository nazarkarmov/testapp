using Murano.TestApp.Domain.Services.External.FlightsModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Murano.TestApp.Web.Api.Controllers
{
    public class FlightsController : ApiController
    {
        private readonly IFlightsService _flightService;

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
