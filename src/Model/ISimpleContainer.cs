using System;

namespace IoC
{
    public interface ISimpleContainer : IDisposable
    {
        object Get(Type serviceType);

        T Get<T>();

        void Register<TService>();

        void Register<TService>(Func<TService> instanceCreator);

        void Register<TService, TImpl>() where TImpl : TService;

        void Singleton<TService>(TService instance);

        void Singleton<TService>(Func<TService> instanceCreator);
    }
}
