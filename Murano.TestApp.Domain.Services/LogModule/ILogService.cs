using Murano.TestApp.Domain.Services.LogModule.Requests;
using Murano.TestApp.Domain.Services.LogModule.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.LogModule
{
    public interface ILogService
    {
        LogEntryCreateResponse Create(LogEntryCreateRequest request);
    }
}
