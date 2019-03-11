using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Murano.TestApp.Domain.Services.LogModule.Commands;
using Murano.TestApp.Domain.Services.LogModule.Requests;
using Murano.TestApp.Domain.Services.LogModule.Responses;

namespace Murano.TestApp.Domain.Services.LogModule
{
    public class LogService : ILogService
    {
        private readonly InternalCommandFactory _factory;

        public LogService(InternalCommandFactory factory)
        {
            _factory = factory;
        }

        public LogEntryCreateResponse Create(LogEntryCreateRequest request)
        {
            var command = _factory.Create<LogEntryCreateCommand>();
            return command.Execute(request, CancellationToken.None);
        }
    }
}
