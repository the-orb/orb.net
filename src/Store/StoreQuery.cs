using GraphQL;

namespace Store
{
    public class StoreQuery : Relay.CompositeObjectGraphType
    {
        public StoreQuery(IDependencyResolver resolver)
        {
            Name = "StoreQuery";

            Extend(resolver.Resolve<Auth.AuthQuery>());
            Extend(resolver.Resolve<Orb.OrbQuery>());
        }
    }
}
