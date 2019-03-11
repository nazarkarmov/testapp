using Murano.TestApp.Infrastructure.Services.Validators;
using Murano.TestApp.Infrastructure.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Services
{
    public class CommonErrorCode : ErrorCodeBase
    {
        [StringValue("Internal server error")]
        public const int InternalServerError = 10000;

        [StringValue("User is not authorized to perform this action")]
        public const int UserNotAuthorized = 10001;

        [StringValue("User is not authenticated")]
        public const int UserNotAuthenticated = 10002;

        [StringValue("Token is not correct")]
        public const int InvalidToken = 10003;
    }
}
