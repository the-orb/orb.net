using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public interface IRoleService
    {
        Task<Role> AddRoleAsync(Role role);

        Task<IEnumerable<Role>> GetRolesAsync();

        Task<IEnumerable<Role>> GetRolesAsync(User user);

        Task<Role> GeRoleByNameAsync(string name);
    }
}
