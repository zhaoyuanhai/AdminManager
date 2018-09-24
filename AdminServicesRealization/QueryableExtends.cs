using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminServicesRealization
{
    public static class QueryableExtends
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> expression, bool isTrue)
        {
            if (isTrue)
                return queryable.Where(expression);
            return queryable;
        }
    }
}
