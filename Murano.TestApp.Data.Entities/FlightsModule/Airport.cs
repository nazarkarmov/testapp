using Murano.TestApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Entities.FlightsModule
{
    [Table(nameof(Airline), Schema = "Flights")]
    public class Airport : IEntityWithId, IEntityWithName
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        public string City { get; set; }

        public double Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Altitude { get; set; }
    }
}
