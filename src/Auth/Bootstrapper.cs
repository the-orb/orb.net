using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using System;

namespace Auth
{
    internal static class Bootstrapper
    {
        public static void Setup(IoC.ISimpleContainer container)
        {
            var baseUri = new Uri("https://YOUR_AUTH0_DOMAIN/api/v2");

            container.Singleton(new AuthenticationApiClient(baseUri));
            container.Singleton(new ManagementApiClient("your token", baseUri));
            container.Register<IAuthenticationService, Auth0AuthenticationService>();
            container.Register<ILoginService, Auth0LoginService>();
            container.Register<IRoleService, Auth0RoleService>();
            container.Register<IUserService, Auth0UserService>();
            container.Register<AuthMutation>();
            container.Register<AuthQuery>();
            container.Register<AuthSchema>();
            container.Register<Role>();
            container.Register<RoleInputType>();
            container.Register<RoleMutation>();
            container.Register<RoleQuery>();
            container.Register<RoleType>();
            container.Register<User>();
            container.Register<UserInputType>();
            container.Register<UserMutation>();
            container.Register<UserQuery>();
            container.Register<UserType>();
        }
    }
}
