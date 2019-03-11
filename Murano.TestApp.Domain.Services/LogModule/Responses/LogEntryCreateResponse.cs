using Murano.TestApp.Domain.Services.LogModule.Dtos;
using Murano.TestApp.Infrastructure.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.LogModule.Responses
{
    public class LogEntryCreateResponse : Response
    {
        public LogEntryDto LogEntry { get; set; }
    }
}
