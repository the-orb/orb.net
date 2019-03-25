using GraphQL.Types;

namespace Auth
{
    class RoleMutation : ObjectGraphType
    {
        public RoleMutation(IAuthData data)
        {
            Name = "RoleMutation";

            Field<UserType>(
                "createRole",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "role" }
                ),
                resolve: context =>
                {
                    var role = context.GetArgument<Role>("role");
                    return data.AddRoleAsync(role);
                });
        }
    }
}
