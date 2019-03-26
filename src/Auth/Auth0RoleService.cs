using Auth0.ManagementApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class Auth0RoleService : IRoleService
    {
        readonly ManagementApiClient _client;

        public Auth0RoleService(ManagementApiClient client)
        {
            _client = client;
        }

        public Task<Role> GeRoleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetRolesAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> AddRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
