using Murano.TestApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext DbContext { get; }

        void BeginTransaction();

        void CompleteTransaction();

        void RollbackTransaction();

        bool IsDisposed { get; }
        void SaveChanges();

        T Add<T>(T entity) where T : class, IEntity;

        void Delete<T>(T entity) where T : class, IEntity;

        void LogicallyDelete<T>(T entity) where T : class, ILogicallyDeletable;

        TResult Query<TResult, TCriteria>(IQuery<TCriteria, TResult> query, TCriteria criteria)
            where TCriteria : IQueryCriteria;

        int QueryTotalItems<TResult, TCriteria>(IQuery<TCriteria, TResult> query, TCriteria criteria)
            where TCriteria : IQueryCriteria;
    }
}
