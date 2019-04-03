using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public interface IUserService
    {
        Task<IEnumerable<Role>> GetRolesAsync(User user);

        Task<User> AddUserAsync(User user);

        Task<User> AddUserToRoleAsync(string user, string role);

        Task<User> GetUserByIdAsync(string id);

        Task<IEnumerable<User>> GetUsersAsync();
    }
}
