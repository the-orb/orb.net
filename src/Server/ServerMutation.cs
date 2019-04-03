using GraphQL;

namespace Store
{
    public class StoreMutation : Relay.CompositeObjectGraphType
    {
        public StoreMutation(IDependencyResolver resolver)
        {
            Name = "StoreMutation";

            Extend(resolver.Resolve<Auth.AuthMutation>());
            Extend(resolver.Resolve<Orb.OrbMutation>());
        }
    }
}
