﻿using Murano.TestApp.Infrastructure.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.Requests
{
    public class FlightsSearchAirportsByPatternRequest : RequestBase
    {
        public string Pattern { get; set; }
    }
}
