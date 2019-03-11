using Murano.TestApp.Infrastructure.Context;
using Murano.TestApp.Infrastructure.Entities;
using Murano.TestApp.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContextScope _scope;

        public UnitOfWork()
        {
            var lazyScope = new Lazy<DbContextScope>(() =>
            {
                return new DbContextScope();
            });

            _scope = lazyScope.Value;
        }

        public IDbContext DbContext
        {
            get
            {
                if (IsDisposed) throw new ObjectDisposedException("This UnitOfWork instanse is disposed");

                return DbContextScope.CurrentDbContext;
            }
        }

        public void BeginTransaction()
        {
            DbContext.BeginTransaction();
        }

        public void CompleteTransaction()
        {
            DbContext.CompleteTransaction();
        }

        public void RollbackTransaction()
        {
            DbContext.RollbackTransaction();
        }

        public void Dispose()
        {
            if (_scope != null)
            {
                _scope.Dispose();
            }
            IsDisposed = true;
        }

        public bool IsDisposed { get; private set; }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public T Add<T>(T entity) where T : class, IEntity
        {
            return DbContext.GetDbSet<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class, IEntity
        {
            if (entity is ILogicallyDeletable)
                LogicallyDelete(entity as ILogicallyDeletable);
            else
                DbContext.GetDbSet<T>().Remove(entity);
        }

        public void LogicallyDelete<T>(T entity) where T : class, ILogicallyDeletable
        {
            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = true;
        }

        public TResult Query<TResult, TCriteria>(IQuery<TCriteria, TResult> query, TCriteria criteria)
            where TCriteria : IQueryCriteria
        {
            return query.Execute(DbContext, criteria);
        }

        public int QueryTotalItems<TResult, TCriteria>(IQuery<TCriteria, TResult> query, TCriteria criteria)
            where TCriteria : IQueryCriteria
        {
            return query.GetTotalCount(DbContext, criteria);
        }
    }

    public class DbContextScope : IDisposable
    {
        private const string OpenedCountPropertyName = "DbContextScope.OpenedCount";
        private const string DbContextPropertyName = "DbContextScope.CurrentDbContext";

        private static readonly IContextStorage ContextStorage = new Lazy<IContextStorage>(() => (IContextStorage) new CallContextStorage()).Value;
        private bool _isDbContextRegistrator;

        private static int OpenedCount
        {
            get
            {
                if (!ContextStorage.Contains(OpenedCountPropertyName)) return 0;
                return ContextStorage.Get<int>(OpenedCountPropertyName);
            }

            set { ContextStorage.Store(OpenedCountPropertyName, value); }
        }

        public static IDbContext CurrentDbContext
        {
            get
            {
                if (!ContextStorage.Contains(DbContextPropertyName)) return null;
                return ContextStorage.Get<IDbContext>(DbContextPropertyName);
            }

            set { ContextStorage.Store(DbContextPropertyName, value); }
        }

        public DbContextScope()
        {
            if (OpenedCount == 0)
            {
                CurrentDbContext = IoC.Resolve<IDbContext>();

                _isDbContextRegistrator = true;
            }

            OpenedCount++;
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            OpenedCount--;

            if (OpenedCount == 0 || _isDbContextRegistrator)
            {
                CurrentDbContext.Dispose();
                CurrentDbContext = null;
            }
        }

        #endregion
    }
}
