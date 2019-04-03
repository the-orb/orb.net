using GraphQL.Types;

namespace Auth
{
    class RoleMutation : ObjectGraphType
    {
        public RoleMutation(IRoleService service)
        {
            Name = "RoleMutation";

            Field<UserGraphType>(
                "createRole",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<InputUserGraphType>> { Name = "role" }
                ),
                resolve: context =>
                {
                    var role = context.GetArgument<Role>("role");
                    return service.AddRoleAsync(role);
                });
        }
    }
}
