using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2_NullableTypes
{
    public static class Demo2
    {
        public static IOrderedQueryable<T> OrderingHelperWhere<T>(this IQueryable<T> source, string columnName, object value)
        {
            ParameterExpression table = Expression.Parameter(typeof(T), "");
            Expression column = Expression.PropertyOrField(table, columnName);
            Expression where = Expression.GreaterThanOrEqual(column, Expression.Constant(value));
            Expression lambda = Expression.Lambda(where, new ParameterExpression[] { table });

            Type[] exprArgTypes = { source.ElementType };

            MethodCallExpression methodCall = Expression.Call(typeof(Queryable),
                                                              "Where",
                                                              exprArgTypes,
                                                              source.Expression,
                                                              lambda);

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(methodCall);
        }
    }
}
