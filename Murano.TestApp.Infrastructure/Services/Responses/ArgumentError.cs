using Murano.TestApp.Infrastructure.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Services.Responses
{
    public class ArgumentError : Error
    {
        public string ArgumentName { get; set; }

        [JsonConstructor]
        public ArgumentError()
        {
        }

        internal ArgumentError(string argumentName, int errorCode, string errorMessage)
            : base(errorCode, errorMessage)
        {
            ArgumentName = argumentName;
        }

        public static ArgumentError For<TObj>(Expression<Func<TObj, object>> expression, string errorMessage)
        {
            return new ArgumentError(PropertyHelper.GetName(expression), 0, errorMessage);
        }
    }
}
