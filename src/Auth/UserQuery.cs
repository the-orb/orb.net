using GraphQL.Types;
using System;

namespace Auth
{
    class UserQuery : ObjectGraphType
    {
        public UserQuery(IAuthData data)
        {
            Name = "UserQuery";

            Func<ResolveFieldContext, string, object> func = (context, id) => data.GetUserByIdAsync(id);

            FieldDelegate<UserType>(
                "user",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the user" }
                ),
                resolve: func
            );
        }
    }
}
