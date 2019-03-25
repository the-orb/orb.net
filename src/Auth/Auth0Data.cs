using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth
{
    public class Auth0Data : IAuthData
    {
        readonly ManagementApiClient _client;

        public Auth0Data()
        {
            _client = new ManagementApiClient("your token", new Uri("https://YOUR_AUTH0_DOMAIN/api/v2"));
        }

        Task<Role> IAuthData.GeRoleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Role>> IAuthData.GetRolesAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Role>> IAuthData.GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<User>> IAuthData.GetUsersAsync()
        {
            var req = new GetUsersRequest
            {
                Connection = null,
                Fields = null,
                IncludeFields = null,
                Query = null,
                SearchEngine = null,
                Sort = null,
            };

            var pag = new PaginationInfo(pageNo: 0, perPage: 20, includeTotals: true);

            var res = await _client.Users.GetAllAsync(req, pag);

            return res.Select(u => new User
            {
                Id = u.UserId,
                Name = u.UserName
            });
        }

        Task<User> IAuthData.GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Role> IAuthData.AddRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }

        Task<User> IAuthData.AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<User> IAuthData.AddUserToRoleAsync(string user, string role)
        {
            throw new NotImplementedException();
        }
    }
}
