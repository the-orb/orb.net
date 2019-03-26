using Raven.Client.Documents;
using Raven.Client.ServerWide;
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
                    EmbeddedServer.Instance.StartServer();

                    EmbeddedServer.Instance.OpenStudioInBrowser();

                    var record = new DatabaseRecord(DatabaseName);

                    var options = new DatabaseOptions(record);

                    store = EmbeddedServer.Instance.GetDocumentStore(options);
                }
                else
                {
                    store = new DocumentStore
                    {
                        Urls = new[] { "http://localhost:8080" },
                        Database = DatabaseName
                    };
                }

                // store.OnAfterSaveChanges

                return store.Initialize();
            });

        public static IDocumentStore Store =>
            LazyStore.Value;
    }
}
