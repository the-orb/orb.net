using GraphQL.Types;

namespace Auth
{
    class UserMutation : ObjectGraphType
    {
        public UserMutation(IAuthData data)
        {
            Name = "UserMutation";

            Field<UserType>(
                "createUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return data.AddUserAsync(user);
                });

            Field<UserType>(
                "addUserToRole",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "user" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "role" }
                ),
                resolve: context =>
                {
                    var role = context.GetArgument<string>("role");
                    var user = context.GetArgument<string>("user");
                    return data.AddUserToRoleAsync(user: user, role: role);
                });
        }
    }
}
