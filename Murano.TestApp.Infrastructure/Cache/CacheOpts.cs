using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Cache
{
    public class CacheOpts
    {
        public CacheOpts()
        {
            ExpireAt = null;
            ExpireIn = null;
            IsSlidingExpireIn = true;
        }

        public DateTime? ExpireAt { get; set; }
        public TimeSpan? ExpireIn { get; set; }
        public bool IsSlidingExpireIn { get; set; }
    }
}
