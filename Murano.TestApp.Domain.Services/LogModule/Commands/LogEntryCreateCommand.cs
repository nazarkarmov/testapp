using Murano.TestApp.Data.Entities.LogModule;
using Murano.TestApp.Data.Repositories;
using Murano.TestApp.Domain.Services.LogModule.Dtos;
using Murano.TestApp.Domain.Services.LogModule.MapProfile;
using Murano.TestApp.Domain.Services.LogModule.Requests;
using Murano.TestApp.Domain.Services.LogModule.Responses;
using Murano.TestApp.Infrastructure.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.LogModule.Commands
{
    public class LogEntryCreateCommand : InternalCommandBase<IUnitOfWork, LogEntryCreateRequest, LogEntryCreateResponse>
    {
        public LogEntryCreateCommand(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override void Execute(CancellationToken cancellationToken)
        {
            Request.LogEntry.CreatedAt = DateTime.UtcNow;

            var logEntry = LogEntryMapProfile.MapToEntity(Request.LogEntry);

            UnitOfWork.Add(logEntry);

            Response.LogEntry = LogEntryMapProfile.MapToDto(logEntry);
        }
    }
}
