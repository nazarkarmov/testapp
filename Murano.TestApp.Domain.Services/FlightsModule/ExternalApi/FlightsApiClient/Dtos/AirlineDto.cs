using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient.Dtos
{
    public class AirlineDto
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "alias")]
        public string Alias { get; set; }

        [DeserializeAs(Name = "active")]
        public bool IsActive { get; set; }
    }
}
