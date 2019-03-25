using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public interface IAuthData
    {
        Task<Role> AddRoleAsync(Role role);

        Task<User> AddUserAsync(User user);

        Task<User> AddUserToRoleAsync(string user, string role);

        Task<IEnumerable<Role>> GetRolesAsync();

        Task<IEnumerable<Role>> GetRolesAsync(User user);

        Task<Role> GeRoleByNameAsync(string name);

        Task<User> GetUserByIdAsync(string id);

        Task<IEnumerable<User>> GetUsersAsync();
    }
}
