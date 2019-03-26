using GraphQL;
using GraphQL.Types;

namespace Auth
{
    class RoleSchema : Schema
    {
        public RoleSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<RoleQuery>();
            Mutation = resolver.Resolve<RoleMutation>();
        }
    }
}
