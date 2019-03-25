using GraphQL;
using GraphQL.Http;
using GraphQL.Types;

namespace Store
{
    public class Bootstrapper
    {
        public static void Setup(IoC.ISimpleContainer container)
        {
            container.Singleton<IDocumentExecuter>(new DocumentExecuter());
            container.Singleton<IDocumentWriter>(new DocumentWriter(true));

            Auth.Bootstrapper.Setup(container);
            Life.Bootstrapper.Setup(container);
            Orb.Bootstrapper.Setup(container);
            StarWars.Bootstrapper.Setup(container);

            var resolver = new FuncDependencyResolver(type => container.Get(type));

            container.Singleton<IDependencyResolver>(resolver);
            container.Register<StoreQuery>();
            container.Register<StoreMutation>();
            container.Singleton<ISchema>(new StoreSchema(resolver));
        }
    }
}
