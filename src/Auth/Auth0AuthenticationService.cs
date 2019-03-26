using Auth0.AuthenticationApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    class Auth0AuthenticationService : IAuthenticationService
    {
        readonly AuthenticationApiClient _client;

        public Auth0AuthenticationService(AuthenticationApiClient client)
        {
            _client = client;
        }
    }
}
