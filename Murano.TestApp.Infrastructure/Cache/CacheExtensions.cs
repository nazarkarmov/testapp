using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Cache
{
    public static class CacheExtensions
    {
        public static T GetOrSet<T>(this ICache cache, string key, Func<T> setter, TimeSpan? slidingExpiration = null, TimeSpan? absoluteExpiration = null)
        {
            object cached = null;
            if (cache.TryGet(key, ref cached))
            {
                if (cached is T)
                {
                    return (T)cached;
                }
            }
            var value = setter();

            var cacheOpts = new CacheOpts()
            {
                ExpireIn = slidingExpiration ?? absoluteExpiration,
                IsSlidingExpireIn = slidingExpiration.HasValue
            };

            cache.Set(key, value, cacheOpts);

            return value;
        }
    }
}
