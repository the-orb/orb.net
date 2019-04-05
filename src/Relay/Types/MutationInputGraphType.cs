namespace GraphQL.Types
{
    public class MutationInputGraphType : InputObjectGraphType
    {
        public MutationInputGraphType()
        {
            Field<StringGraphType>("clientMutationId");
        }
    }
}