using System;

namespace GraphQL.Entity
{
    public class WhereExpression
    {
        public string Path { get; set; }
        public Comparison? Comparison { get; set; }
        public StringComparison? Case { get; set; }
        public string[] Value { get; set; }
    }
}