using GraphQL;

namespace GraphQL.Entity
{
    public class StoreMutation : CompositeObjectGraphType
    {
        public StoreMutation(IDependencyResolver resolver)
        {
            Name = "StoreMutation";

            // Extend(resolver.Resolve<Auth.AuthMutation>());
            // Extend(resolver.Resolve<Orb.OrbMutation>());
        }
    }
}
