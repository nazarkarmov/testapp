using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.Dtos
{
    public class AirportDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string City { get; set; }

        public double Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Altitude { get; set; }
    }
}
