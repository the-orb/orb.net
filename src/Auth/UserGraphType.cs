using GraphQL.Types;

namespace Auth
{
    public class UserGraphType : ObjectGraphType<User>
    {
        public UserGraphType(IUserService data)
        {
            Name = "User";

            Field(h => h.Id).Description("The id of the user.");
            Field(h => h.Name, nullable: true).Description("The name of the user.");

            Field<ListGraphType<RoleGraphType>>(
                "roles",
                resolve: context => data.GetRolesAsync(context.Source)
            );

            // Interface<CharacterInterface>();
        }
    }
}
