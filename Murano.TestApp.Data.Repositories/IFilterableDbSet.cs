using Murano.TestApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public interface IFilterableDbSet<TEntity> : IDbSet<TEntity> where TEntity : class, IEntity
    {
        void ApplyFilter(Expression<Func<TEntity, bool>> filter);
    }
}
