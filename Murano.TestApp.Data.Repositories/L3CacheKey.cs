using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public static class L3CacheKey
    {
        public static string Gen(L3CacheDataType dataType, string key)
        {
            return dataType + "_" + key;
        }
    }

    public enum L3CacheDataType
    {
        Airports,
        Airlines,
        Routes
    }
}
