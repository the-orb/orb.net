using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    class LoginQuery : ObjectGraphType
    {
        public LoginQuery(ILoginService service)
        {
            Name = "LoginQuery";
            /*
            Field<RoleType>(
                "login",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "mame", Description = "name of the role" }
                ),
                resolve: context => service.LoginAsync(context.GetArgument<string>("name"))
            );
            */
        }
    }
}
