using GraphQL;
using GraphQL.Types;

namespace Auth
{
    class UserSchema : Schema
    {
        public UserSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<UserQuery>();
            Mutation = resolver.Resolve<UserMutation>();
        }
    }
}
