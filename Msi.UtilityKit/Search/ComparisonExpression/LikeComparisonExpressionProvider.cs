using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Msi.UtilityKit.Search
{
    public class LikeComparisonExpressionProvider : IComparisonExpressionProvider
    {

        private static MethodInfo containsMethod = typeof(string).GetMethods().First(x => x.Name == "Contains" && x.GetParameters().Length == 1);

        public Expression GetExpression(Expression left, Expression right)
        {
            var containsMethodExpression = Expression.Call(left, containsMethod, new Expression[] { right });
            return Expression.Equal(containsMethodExpression, Expression.Constant(true));
        }
    }
}
