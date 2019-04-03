using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class InputRoleGraphType : InputObjectGraphType<Role>
    {
        public InputRoleGraphType()
        {
            Name = "RoleInput";
            Field(x => x.Name);
            Field(x => x.Description, nullable: true);
        }
    }
}
