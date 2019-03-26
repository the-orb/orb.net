using GraphQL.Types;

namespace Auth
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(IRoleService data)
        {
            Name = "User";

            Field(h => h.Id).Description("The id of the user.");
            Field(h => h.Name, nullable: true).Description("The name of the user.");

            Field<ListGraphType<RoleType>>(
                "roles",
                resolve: context => data.GetRoles(context.Source)
            );

            // Interface<CharacterInterface>();
        }
    }
}
