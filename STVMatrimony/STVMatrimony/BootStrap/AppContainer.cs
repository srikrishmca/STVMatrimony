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
            ContainerBuilder builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<AboutViewModel>();
            builder.RegisterType<ItemDetailViewModel>();
            builder.RegisterType<ItemsViewModel>();
            builder.RegisterType<LoginViewModel>();

            // MockDataSource
            builder.RegisterType<Services.MockDataStore>();

            _container = builder.Build();
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
