using Murano.TestApp.Data.Entities.LogModule;
using Murano.TestApp.Domain.Services.LogModule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.LogModule.MapProfile
{
    public class LogEntryMapProfile
    {
        public static LogEntryDto MapToDto(LogEntry entity)
        {
            return new LogEntryDto
            {
                Id = entity.Id,
                LogEntryType = entity.LogEntryType,
                LogEntryLevel = entity.LogEntryLevel,
                CreatedAt = entity.CreatedAt,
                Description = entity.Description
            };
        }

        public static LogEntry MapToEntity(LogEntryDto dto)
        {
            return new LogEntry
            {
                LogEntryType = dto.LogEntryType,
                LogEntryLevel = dto.LogEntryLevel,
                Description = dto.Description
            };
        }
    }
}
