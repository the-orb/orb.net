using GraphQL;
using GraphQL.Http;
using Raven.Client.Documents;
using Raven.Client.ServerWide;
using Raven.Embedded;
using System;
using Unity;
using Unity.Lifetime;

namespace Server
{
    public static class Bootstrapper
    {
        private static readonly Lazy<IUnityContainer> LazyContainer =
            new Lazy<IUnityContainer>(() =>
            {
                IUnityContainer container = new UnityContainer();

                container.RegisterInstance<IDocumentExecuter>(new DocumentExecuter());
                container.RegisterInstance<IDocumentWriter>(new DocumentWriter(true));

                container.RegisterType(typeof(GraphQL.Types.Relay.ConnectionType<>), new TransientLifetimeManager());
                container.RegisterType(typeof(GraphQL.Types.Relay.EdgeType<>), new TransientLifetimeManager());
                container.RegisterType<GraphQL.Types.Relay.PageInfoType>(new TransientLifetimeManager());

                // container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());

                var resolver = new FuncDependencyResolver(type => container.Resolve(type));

                container.RegisterInstance<IDependencyResolver>(resolver);

                // Auth.Bootstrapper.Setup(container);
                // Life.Bootstrapper.Setup(container);
                // Orb.Bootstrapper.Setup(container);
                StarWars.Bootstrapper.Setup(container);

                return container;
            });

        private static readonly Lazy<EmbeddedServer> LazyEmbeddedStoreServer =
            new Lazy<EmbeddedServer>(() =>
            {
                var server = EmbeddedServer.Instance;

                server.StartServer();

                server.OpenStudioInBrowser();

                return server;
            });

        public static IDocumentStore ResolveStore(string name, params string[] urls)
        {
            var store  = Container.Resolve<IDocumentStore>(name);

            if (store != null)
            {
                return store;
            }

            if (urls.Length > 0)
            {
                store = new DocumentStore
                {
                    Database = name,
                    Urls = urls
                };

                return store;
            }

            var server = EmbededStoreServer;

            var record = new DatabaseRecord(name);

            var options = new DatabaseOptions(record);

            store = server.GetDocumentStore(options);

            return store;
        }

        public static IUnityContainer Container => LazyContainer.Value;

        public static EmbeddedServer EmbededStoreServer => LazyEmbeddedStoreServer.Value;
    }
}