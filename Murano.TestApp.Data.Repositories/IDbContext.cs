using Murano.TestApp.Data.Entities.FlightsModule;
using Murano.TestApp.Data.Entities.LogModule;
using Murano.TestApp.Infrastructure.Cache;
using Murano.TestApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public interface IDbContext : IDisposable
    {
        IFilterableDbSet<LogEntry> Logs { get; set; }

        IFilterableDbSet<Airline> Airlines { get; set; }

        IFilterableDbSet<Airport> Airports { get; set; }

        IFilterableDbSet<Route> Routes { get; set; }

        void BeginTransaction();
        void CompleteTransaction();
        void RollbackTransaction();
        int SaveChanges();

        IDbSet<T> GetDbSet<T>() where T : class, IEntity;

        bool IsDisposed { get; }

        ILocalCache L2Cache { get; }
        IDistributedCache L3Cache { get; }

    }
}
