using Murano.TestApp.Common.LogModule;
using Murano.TestApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Entities.LogModule
{
    public class LogEntry : IEntity
    {
        public int Id { get; set; }

        public LogEntryType LogEntryType { get; set; }

        public LogEntryLevel LogEntryLevel { get; set; }

        [MaxLength]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
