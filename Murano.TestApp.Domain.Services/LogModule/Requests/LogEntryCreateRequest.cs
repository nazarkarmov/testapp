using Murano.TestApp.Domain.Services.LogModule.Dtos;
using Murano.TestApp.Infrastructure.Services.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.LogModule.Requests
{
    public class LogEntryCreateRequest : RequestBase
    {
        [Required]
        public LogEntryDto LogEntry { get; set; }
    }
}
