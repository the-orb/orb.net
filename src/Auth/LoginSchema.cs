using GraphQL;
using GraphQL.Types;

namespace Auth
{
    class LoginSchema : Schema
    {
        public LoginSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<LoginQuery>();
            Mutation = resolver.Resolve<LoginMutation>();
        }
    }
}
