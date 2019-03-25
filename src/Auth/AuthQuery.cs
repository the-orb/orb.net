using GraphQL;

namespace Auth
{
    internal class AuthQuery : Relay.CompositeObjectGraphType
    {
        public AuthQuery(IDependencyResolver resolver)
        {
            Name = "AuthQuery";

            Extend(resolver.Resolve<RoleQuery>());
            Extend(resolver.Resolve<UserQuery>());
        }
    }
}
