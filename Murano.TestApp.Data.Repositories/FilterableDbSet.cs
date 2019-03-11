using Murano.TestApp.Infrastructure.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public class FilterableDbSet<TEntity> : IFilterableDbSet<TEntity>, IOrderedQueryable<TEntity>, IListSource where TEntity : class, IEntity
    {
        private readonly IDbSet<TEntity> _set;
        private Expression<Func<TEntity, bool>> _filter;

        public FilterableDbSet(DbContext context)
            : this(context, _ => true)
        {
        }

        public FilterableDbSet(DbContext context, Expression<Func<TEntity, bool>> filter)
            : this(context.Set<TEntity>(), filter)
        {
        }

        private FilterableDbSet(DbSet<TEntity> set, Expression<Func<TEntity, bool>> filter)
        {
            _set = set;
            _filter = filter;
        }

        public IQueryable<TEntity> Include(string path)
        {
            return _set.Include(path).Where(_filter).AsQueryable();
        }

        public TEntity Add(TEntity entity)
        {
            return _set.Add(entity);
        }

        public void AddOrUpdate(TEntity entity)
        {
            _set.AddOrUpdate(entity);
        }

        public TEntity Attach(TEntity entity)
        {
            return _set.Attach(entity);
        }

        public TEntity Create()
        {
            var entity = _set.Create();
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity
        {
            var entity = _set.Create<TDerivedEntity>();
            return entity;
        }

        [Obsolete("Using is denied", true)]
        public TEntity Find(params object[] keyValues)
        {
            throw new InvalidOperationException();
        }

        public TEntity Remove(TEntity entity)
        {
            if (!_set.Local.Contains(entity))
            {
                _set.Attach(entity);
            }
            return _set.Remove(entity);
        }

        public ObservableCollection<TEntity> Local
        {
            get { return _set.Local; }
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _set.Where(_filter).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _set.Where(_filter).GetEnumerator();
        }

        Type IQueryable.ElementType
        {
            get { return typeof(TEntity); }
        }

        Expression IQueryable.Expression
        {
            get { return _set.Where(_filter).Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _set.Where(_filter).AsQueryable().Provider; }
        }

        bool IListSource.ContainsListCollection
        {
            get { return false; }
        }

        [Obsolete("Using is denied", true)]
        IList IListSource.GetList()
        {
            throw new InvalidOperationException();
        }

        public void ApplyFilter(Expression<Func<TEntity, bool>> filter)
        {
            _filter = FilterableDbSetHelper.AttachFilter(_filter, filter);
        }
    }
}
