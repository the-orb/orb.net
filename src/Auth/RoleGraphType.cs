using GraphQL.Types;

namespace Auth
{
    public class RoleGraphType : ObjectGraphType<Role>
    {
        public RoleGraphType(IRoleService data)
        {
            Name = "Role";

            Field(h => h.Name, nullable: true).Description("The name of the role.");
            
            Field(h => h.Description, nullable: true).Description("The role description.");

            // Interface<CharacterInterface>();
        }
    }
}
