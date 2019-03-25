namespace StarWars
{
    using Types;

    public static class Bootstrapper
    {
        public static void Setup(IoC.ISimpleContainer container)
        {
            container.Singleton(new StarWarsData());
            container.Register<StarWarsQuery>();
            container.Register<StarWarsMutation>();
            container.Register<HumanType>();
            container.Register<HumanInputType>();
            container.Register<DroidType>();
            container.Register<CharacterInterface>();
        }
    }
}
