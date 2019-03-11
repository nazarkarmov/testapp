using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public static class FilterableDbSetHelper
    {
        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression newValue, Expression oldValue)
            {
                _newValue = newValue;
                _oldValue = oldValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                    return _newValue;
                return base.Visit(node);
            }
        }

        public static Expression<Func<TEntity, bool>> AttachFilter<TEntity>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, bool>> filterToAttach)
        {
            var argument = Expression.Parameter(typeof(TEntity));
            var leftVisitor = new ReplaceExpressionVisitor(argument, filter.Parameters[0]);
            var left = leftVisitor.Visit(filter.Body);

            var rightVisitor = new ReplaceExpressionVisitor(argument, filterToAttach.Parameters[0]);
            var right = rightVisitor.Visit(filterToAttach.Body);

            var temp = Expression.Lambda<Func<TEntity, bool>>(
                Expression.AndAlso(left, right), argument);

            return temp;
        }
    }
}
