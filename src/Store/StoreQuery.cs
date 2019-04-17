using GraphQL;

namespace GraphQL.Entity
{
    public class StoreQuery : Relay.CompositeObjectGraphType
    {
        public StoreQuery(IDependencyResolver resolver)
        {
            Name = "StoreQuery";

            // Extend(resolver.Resolve<Auth.AuthQuery>());
            // Extend(resolver.Resolve<Orb.OrbQuery>());
        }
    }
}
