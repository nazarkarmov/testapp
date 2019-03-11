using Murano.TestApp.Infrastructure.Web.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Context
{
    public class SessionContextStorage : IContextStorage
    {
        private readonly SessionAccessor _sessionAccessor = new SessionAccessor();

        public void Store<T>(string propertyName, T value)
        {
            _sessionAccessor.Set(propertyName, value);
        }

        public void Clear(string propertyName)
        {
            _sessionAccessor.Set(propertyName, null);
        }

        public T Get<T>(string propertyName)
        {
            return _sessionAccessor.Get<T>(propertyName);
        }

        public bool Contains(string propertyName)
        {
            return _sessionAccessor.Get<object>(propertyName) != null;
        }
    }
}
