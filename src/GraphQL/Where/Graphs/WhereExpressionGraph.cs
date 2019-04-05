using GraphQL.Types;

namespace GraphQL.Entity
{
    public class WhereExpressionGraph :
        InputObjectGraphType<WhereExpression>
    {
        public WhereExpressionGraph()
        {
            Field(x => x.Path);
            Field(x => x.Comparison, true);
            Field(x => x.Case, true);
            Field(x => x.Value, true);
        }
    }
}