using Autofac;

namespace ASAPMethodology.Business.DependencyResolvers.Autofac
{
    public class InstanceFactory
    {
        private static ContainerBuilder _container;
        private static IContainer container;

        public static T GetInstance<T>()
        {
            _container = new ContainerBuilder();
            container = _container.Build();
            return container.Resolve<T>();
        }
    }
}
