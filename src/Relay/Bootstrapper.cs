using GraphQL;
using GraphQL.Http;
using GraphQL.Types;

namespace Relay
{
    public static class Bootstrapper
    {
        public static void Register()
        {
            var container = IoC.SimpleContainer.Instance;

            container.Singleton<IDocumentExecuter>(new DocumentExecuter());
            container.Singleton<IDocumentWriter>(new DocumentWriter(true));

            // container.Singleton<ISchema>(new StarWarsSchema(new FuncDependencyResolver(type => container.Get(type))));
        }

        public static void Register(ISchema schema)
        {
        }
    }
}
