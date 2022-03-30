using System;
using Autofac;
using STVMatrimony.ViewModels;

namespace STVMatrimony.BootStrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            ContainerBuilder _builder = new ContainerBuilder();

            //ViewModels
            _builder.RegisterType<AboutViewModel>();
            _builder.RegisterType<ItemDetailViewModel>();
            _builder.RegisterType<ItemsViewModel>();
            _builder.RegisterType<LoginViewModel>();
            _builder.RegisterType<RegisterViewModel>();

           

            _container = _builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
