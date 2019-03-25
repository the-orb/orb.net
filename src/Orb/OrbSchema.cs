using GraphQL;
using GraphQL.Types;

namespace Orb
{
    class OrbSchema : Schema
    {
        public OrbSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<OrbQuery>();
            Mutation = resolver.Resolve<OrbMutation>();
        }
    }
}
