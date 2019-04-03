using GraphQL.Types;

namespace Auth
{
    class RoleQuery : ObjectGraphType
    {
        public RoleQuery(IRoleService service)
        {
            Name = "RoleQuery";

            Field<RoleGraphType>(
                "role",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "mame", Description = "name of the role" }
                ),
                resolve: context => service.GeRoleByNameAsync(context.GetArgument<string>("name"))
            );
        }
    }
}
