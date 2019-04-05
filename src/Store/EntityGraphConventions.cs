using GraphQL.Types.Relay;
using System;
using System.Data.Entity.Core.Metadata.Edm;
using Unity;
using Unity.Lifetime;

namespace GraphQL.Entity
{
    public static class EntityGraphConventions
    {
        #region RegisterInContainerAction
        public static void RegisterInContainer(Action<Type, object> register, EdmModel model, GlobalFilters filters = null)
        #endregion
        {
            Guard.AgainstNull(nameof(register), register);
            Guard.AgainstNull(nameof(model), model);
            Scalars.RegisterInContainer(register);
            ArgumentGraphs.RegisterInContainer(register);

            if (filters == null)
            {
                filters = new GlobalFilters();
            }

            var service = new EntityGraphAdapter(model, filters);
            register(typeof(IEntityGraphAdapter), service);
        }

        #region RegisterInContainerServiceCollection
        public static void RegisterInContainer(IUnityContainer container, EdmModel model, GlobalFilters filters = null)
        #endregion
        {
            Guard.AgainstNull(nameof(container), container);
            Guard.AgainstNull(nameof(model), model);
            container.RegisterType(typeof(ConnectionType<>), new TransientLifetimeManager());
            container.RegisterType(typeof(EdgeType<>), new TransientLifetimeManager());
            container.RegisterSingleton<PageInfoType>();
            RegisterInContainer((type, instance) => { container.RegisterInstance(type, instance); }, model, filters);
        }

        public static void RegisterConnectionTypesInContainer(IUnityContainer container)
        {
            Guard.AgainstNull(nameof(container), container);
            container.RegisterType(typeof(ConnectionType<>), new TransientLifetimeManager());
            container.RegisterType(typeof(EdgeType<>), new TransientLifetimeManager());
            container.RegisterSingleton<PageInfoType>();
        }

        public static void RegisterConnectionTypesInContainer(Action<Type> register)
        {
            Guard.AgainstNull(nameof(register), register);
            register(typeof(ConnectionType<>));
            register(typeof(EdgeType<>));
            register(typeof(PageInfoType));
        }
    }
}