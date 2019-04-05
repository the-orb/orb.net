using GraphQL;
using GraphQL.Types;

namespace Auth
{
    /// <example>
    /// This is an example JSON request for a mutation
    /// {
    ///   "query": "mutation ($user:UserInput!){ createUser(user: $user) { id name } }",
    ///   "variables": {
    ///     "user": {
    ///       "name": "Boba Fett"
    ///     }
    ///   }
    /// }
    /// </example>
    internal class AuthMutation : CompositeObjectGraphType
    {
        public AuthMutation(IDependencyResolver resolver)
        {
            Name = "AuthMutation";

            Extend(resolver.Resolve<RoleMutation>());
            Extend(resolver.Resolve<UserMutation>());
        }
    }
}
