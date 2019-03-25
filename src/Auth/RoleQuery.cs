using GraphQL.Types;

namespace Auth
{
    class RoleQuery : ObjectGraphType
    {
        public RoleQuery(IAuthData data)
        {
            Name = "RoleQuery";

            Field<RoleType>(
                "role",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "mame", Description = "name of the role" }
                ),
                resolve: context => data.GeRoleByNameAsync(context.GetArgument<string>("name"))
            );
        }
    }
}
