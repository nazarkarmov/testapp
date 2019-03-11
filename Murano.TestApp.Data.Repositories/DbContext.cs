using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murano.TestApp.Data.Entities.FlightsModule;
using Murano.TestApp.Data.Entities.LogModule;
using Murano.TestApp.Data.Repositories.Migrations;
using Murano.TestApp.Infrastructure.Cache;
using Murano.TestApp.Infrastructure.Entities;

namespace Murano.TestApp.Data.Repositories
{
    public class DbContext : System.Data.Entity.DbContext, IDbContext
    {
        public IFilterableDbSet<LogEntry> _logs;
        public IFilterableDbSet<Airline> _airlines;
        public IFilterableDbSet<Airport> _airports;
        public IFilterableDbSet<Route> _routes;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogEntry>().ToTable("LogEntry");
            modelBuilder.Entity<Airline>().ToTable("Airline");
            modelBuilder.Entity<Airport>().ToTable("Airport");
            modelBuilder.Entity<Route>().ToTable("Route");
        }

        public IFilterableDbSet<LogEntry> Logs
        {
            get
            {
                if (_logs == null)
                    _logs =
                        new Lazy<IFilterableDbSet<LogEntry>>(() => new FilterableDbSet<LogEntry>(this, _ => true)).Value;
                return _logs;
            }
            set { _logs = value; }
        }

        public IFilterableDbSet<Airline> Airlines
        {
            get
            {
                if (_airlines == null)
                    _airlines =
                        new Lazy<IFilterableDbSet<Airline>>(() => new FilterableDbSet<Airline>(this, _ => true)).Value;
                return _airlines;
            }
            set { _airlines = value; }
        }

        public IFilterableDbSet<Airport> Airports
        {
            get
            {
                if (_airports == null)
                    _airports =
                        new Lazy<IFilterableDbSet<Airport>>(() => new FilterableDbSet<Airport>(this, _ => true)).Value;
                return _airports;
            }
            set { _airports = value; }
        }

        public IFilterableDbSet<Route> Routes
        {
            get
            {
                if (_routes == null)
                    _routes =
                        new Lazy<IFilterableDbSet<Route>>(() => new FilterableDbSet<Route>(this, _ => true)).Value;
                return _routes;
            }
            set { _routes = value; }
        }

        public virtual void BeginTransaction()
        {
            _transaction = this.Database.BeginTransaction();
        }

        public virtual void CompleteTransaction()
        {
            if (_transaction == null) throw new InvalidOperationException("No Transaction");
            _transaction.Commit();
        }

        public virtual void RollbackTransaction()
        {
            if (_transaction == null) throw new InvalidOperationException("No Transaction");
            _transaction.Rollback();
        }

        private DbContextTransaction _transaction;

        public ILocalCache L2Cache { get; private set; }
        public IDistributedCache L3Cache { get; private set; }

        public DbContext() : base("DefaultConnection")
        {
        }

        public DbContext(ILocalCache l2Cache, IDistributedCache l3Cache)
            : this()
        {
            L2Cache = l2Cache;
            L3Cache = l3Cache;

            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContext, Configuration>());
        }

        public override int SaveChanges()
        {
            try
            {
                var entities = ChangeTracker.Entries().Where(x => x.Entity is ITrackCreateAndUpdate && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((ITrackCreateAndUpdate)entity.Entity).CreatedAt = DateTime.UtcNow;
                    }
                    if (entity.State == EntityState.Modified)
                    {
                        ((ITrackCreateAndUpdate)entity.Entity).LastUpdatedAt = DateTime.UtcNow;
                    }
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    sb.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors: {2}",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State, Environment.NewLine);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        sb.AppendFormat("- Property: \"{0}\", Error: \"{1}\"{2}",
                            ve.PropertyName, ve.ErrorMessage, Environment.NewLine);
                    }
                }
                throw new DbEntityValidationException(sb.ToString(), e);
            }
        }

        public IDbSet<TEntity> GetDbSet<TEntity>()
            where TEntity : class, IEntity
        {
            return Set<TEntity>();
        }

        protected override void Dispose(bool disposing)
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
            base.Dispose(disposing);
            IsDisposed = true;
        }

        public bool IsDisposed { get; internal set; }
    }
}
