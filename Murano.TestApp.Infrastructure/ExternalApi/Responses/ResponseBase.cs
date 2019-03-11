using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.ExternalApi.Responses
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }

        [DeserializeAs(Name = "error_code")]
        public int? ErrorCode { get; set; }

        [DeserializeAs(Name = "error_type")]
        public string ErrorType { get; set; }

        [DeserializeAs(Name = "error_message")]
        public string ErrorMessage { get; set; }
    }
}
