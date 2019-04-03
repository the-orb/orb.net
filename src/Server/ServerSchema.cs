using GraphQL;
using GraphQL.Types;

namespace Store
{
    public class StoreSchema : Schema
    {
        public StoreSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<StoreQuery>();
            Mutation = resolver.Resolve<StoreMutation>();
        }
    }
}
