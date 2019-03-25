using GraphQL;
using GraphQL.Types;

namespace Auth
{
    public class AuthSchema : Schema
    {
        public AuthSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<AuthQuery>();
            Mutation = resolver.Resolve<AuthMutation>();
        }
    }
}
