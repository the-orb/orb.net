using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using System;
using Unity;

namespace Auth
{
    internal static class Bootstrapper
    {
        public static void Setup(IUnityContainer container)
        {
            var baseUri = new Uri("https://YOUR_AUTH0_DOMAIN/api/v2");

            container.RegisterInstance(new AuthenticationApiClient(baseUri));
            container.RegisterInstance(new ManagementApiClient("your token", baseUri));
            container.RegisterType<IAuthenticationService, Auth0AuthenticationService>();
            container.RegisterType<ILoginService, Auth0LoginService>();
            container.RegisterType<IRoleService, Auth0RoleService>();
            container.RegisterType<IUserService, Auth0UserService>();
            container.RegisterType<AuthMutation>();
            container.RegisterType<AuthQuery>();
            container.RegisterType<AuthSchema>();
            container.RegisterType<Role>();
            container.RegisterType<InputRoleGraphType>();
            container.RegisterType<RoleMutation>();
            container.RegisterType<RoleQuery>();
            container.RegisterType<RoleGraphType>();
            container.RegisterType<User>();
            container.RegisterType<InputUserGraphType>();
            container.RegisterType<UserMutation>();
            container.RegisterType<UserQuery>();
            container.RegisterType<UserGraphType>();
        }
    }
}
