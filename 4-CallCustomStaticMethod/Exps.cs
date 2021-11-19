using System.Linq.Expressions;
using System.Reflection;

namespace _4_CallCustomStaticMethod
{
    internal class Exps
    {
        public static Expression<Func<Person, bool>> GetBoolExpression(Filter filter)
        {
            //p
            ParameterExpression param = Expression.Parameter(typeof(Person), "p");
            //p.Name
            MemberExpression member = Expression.Property(param, filter.Id);
            //Value
            ConstantExpression constant = Expression.Constant(filter.Value);

            MethodInfo miContain;
            MethodCallExpression exp;
            switch (filter.Operator)
            {
                case Operator.NewContains:
                    miContain = typeof(StringExts).GetMethod("NewContains", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)!;
                    exp = Expression.Call(miContain, member, constant, Expression.Constant(StringComparison.OrdinalIgnoreCase));
                    return Expression.Lambda<Func<Person, bool>>(exp, param);
                default:
                    return default;
            }
        }

        public static Expression<Func<Person, string>> GetStrExpression(Filter filter)
        {
            //p
            ParameterExpression param = Expression.Parameter(typeof(Person), "p");
            //p.Age
            MemberExpression member = Expression.Property(param, filter.Id);

            MethodInfo miContain;
            MethodCallExpression exp;
            switch (filter.Operator)
            {
                case Operator.ToString:
                    miContain = typeof(StringExts).GetMethod("ToString", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)!;
                    exp = Expression.Call(miContain, member);
                    return Expression.Lambda<Func<Person, string>>(exp, param);
                default:
                    return default;
            }
        }

    }
}