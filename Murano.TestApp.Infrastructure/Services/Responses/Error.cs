using Murano.TestApp.Infrastructure.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Services.Responses
{
    public class Error
    {
        public Error(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public Error()
        {
        }

        public Error(int errorCode)
        {
            ErrorCode = errorCode;
            ErrorMessage = RequestValidatorErrorMessagesDictionary.Instance[errorCode];
        }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
