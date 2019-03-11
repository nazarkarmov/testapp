using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Context
{
    public interface IContextStorage
    {
        T Get<T>(string propertyName);
        void Store<T>(string propertyName, T value);
        void Clear(string propertyName);
        bool Contains(string propertyName);
    }
}
