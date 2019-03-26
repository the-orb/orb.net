using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class Auth0UserService : IUserService
    {
        readonly ManagementApiClient _client;

        public Auth0UserService(ManagementApiClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
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

        public Task<User> GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddUserToRoleAsync(string user, string role)
        {
            throw new NotImplementedException();
        }
    }
}
