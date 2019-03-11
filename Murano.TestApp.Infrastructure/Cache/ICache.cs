using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Cache
{
    public interface ICache
    {
        void Set(string key, object value, CacheOpts opts = null);

        bool Exists(string key);

        T Get<T>(string key) where T : class;

        bool TryGet<T>(string key, ref T value) where T : class;

        void Remove(string key);

        bool TryRemove(string key);

        void RemoveAll();

        IEnumerable<object> GetAll(string keyPrepend);
    }

    public interface ILocalCache : ICache
    {

    }

    public interface IDistributedCache : ICache
    {
        T Get<T>(string key, out IConcurrencyHandle handle) where T : class, new();
        void Set<T>(string key, T value, IConcurrencyHandle handle) where T : class;
        void Unlock(string key, IConcurrencyHandle handle);
    }

    public interface IConcurrencyHandle
    {
    }
}
