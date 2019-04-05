using System.Linq.Expressions;
using System.Data.Entity;

static class ExpressionCache
{
    public static ConstantExpression NegativeOne = Expression.Constant(-1);
    public static ConstantExpression Null = Expression.Constant(null, typeof(object));
    public static ParameterExpression StringParam = Expression.Parameter(typeof(string));
}