using GraphQL;
using Unity;

namespace StarWars
{   
    using Types;

    internal static class Bootstrapper
    {
        public static void Setup(IUnityContainer container)
        {
            container.RegisterInstance(new StarWarsData());
            container.RegisterType<StarWarsQuery>();
            container.RegisterType<StarWarsMutation>();
            container.RegisterType<StarWarsSubscription>();
            container.RegisterType<HumanType>();
            container.RegisterType<HumanInputType>();
            container.RegisterType<DroidType>();
            container.RegisterType<CharacterInterface>();
            container.RegisterInstance(new StarWarsSchema(new FuncDependencyResolver(type => container.Resolve(type))));
        }
    }
}
