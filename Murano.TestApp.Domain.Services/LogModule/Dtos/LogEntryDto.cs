﻿using Murano.TestApp.Common.LogModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.LogModule.Dtos
{

    public class LogEntryDto
    {
        public int? Id { get; set; }

        public LogEntryType LogEntryType { get; set; }

        public LogEntryLevel LogEntryLevel { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}