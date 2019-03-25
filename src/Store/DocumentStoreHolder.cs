using Raven.Client.Documents;
using Raven.Embedded;
using System;

namespace Store
{
    public static class DocumentStoreHolder
    {
        public static bool Embedded = false;
        public static string DatabaseName = "Northwind";

        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                IDocumentStore store;

                if (Embedded)
                {
                    store = EmbeddedServer.Instance.GetDocumentStore(new DatabaseOptions(DatabaseName));
                }
                else
                {
                    store = new DocumentStore
                    {
                        Urls = new[] { "http://localhost:8080" },
                        Database = DatabaseName
                    };
                }

                return store.Initialize();
            });

        public static IDocumentStore Store =>
            LazyStore.Value;
    }
}
