using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public interface IQuery<in TCriteria, out TResult>
        where TCriteria : IQueryCriteria
    {
        TResult Execute(IDbContext dbContext, TCriteria criteria);

        int GetTotalCount(IDbContext dbContext, TCriteria criteria);
    }
}
