using Murano.TestApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Entities.UserModule
{
    public class AirbnbUser : ILogicallyDeletable, IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        [Required]
        public int? UserId { get; set; }

        public string Firsrtname { get; set; }

        public string LastName { get; set; }

        public string PhotoUrl { get; set; }

        public string Location { get; set; }
    }
}

