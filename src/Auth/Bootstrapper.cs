namespace Auth
{
    internal static class Bootstrapper
    {
        public static void Setup(IoC.ISimpleContainer container)
        {
            container.Register<IAuthData>();
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
