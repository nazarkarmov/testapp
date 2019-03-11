using Murano.TestApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public class InMemoryDbSet<T> : IDbSet<T> where T : class, IEntity
    {
        readonly ObservableCollection<T> _data;
        readonly IQueryable _query;
        private int _seed;

        public InMemoryDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
            _seed = 1;
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from InMemoryDbSet<T> and override Find");
        }

        public T Add(T item)
        {
            SetId(item);

            _data.Add(item);

            return item;
        }

        public T AddWithId(T item)
        {
            _data.Add(item);

            return item;
        }

        private void SetId(T item)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                idProperty.SetValue(item, _seed, null);
                _seed++;
            }
        }

        public T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Detach(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local
        {
            get { return _data; }
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}
