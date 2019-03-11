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
    [Table(nameof(Route), Schema = "Flights")]
    public class Route : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(3)]
        public string AirlineCode { get; set; }

        [Required, MaxLength(4)]
        public string SourceAirportCode { get; set;}

        [Required, MaxLength(4)]
        public string DestinationAirportCode { get; set; }
    }
}
