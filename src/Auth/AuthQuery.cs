using GraphQL;
using GraphQL.Types;

namespace Auth
{
    internal class AuthQuery : CompositeObjectGraphType
    {
        public AuthQuery(IDependencyResolver resolver)
        {
            Name = "AuthQuery";

            Extend(resolver.Resolve<RoleQuery>());
            Extend(resolver.Resolve<UserQuery>());
        }
    }
}
