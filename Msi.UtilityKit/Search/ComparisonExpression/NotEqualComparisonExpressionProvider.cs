using System.Linq.Expressions;

namespace Msi.UtilityKit.Search
{
    public class NotEqualComparisonExpressionProvider : IComparisonExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }
    }
}
