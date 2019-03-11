using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Murano.TestApp.Infrastructure.Web.Session
{
    public class SessionAccessor
    {
        private string _type;

        public static SessionAccessor Initialize<T>()
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("No HttpContext");

            var instance = new SessionAccessor();

            var type = HttpContext.Current.ApplicationInstance.GetType().BaseType;
            instance._type = (type != null ? (type.Namespace ?? "").Split('.').Last() : "") + typeof(T).Name;
            return instance;
        }

        public void Set(string key, object value)
        {
            HttpContext.Current.Session[GetKey(key)] = value;
        }

        public T1 Get<T1>(string key)
        {
            return
                (T1)
                ((HttpContext.Current != null && HttpContext.Current.Session != null)
                     ? HttpContext.Current.Session[GetKey(key)]
                     : null);
        }

        private string GetKey(string key)
        {
            return string.Format("{0}.{1}", _type, key);
        }
    }
}
