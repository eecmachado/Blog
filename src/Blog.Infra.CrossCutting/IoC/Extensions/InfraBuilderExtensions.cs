using Autofac;
using Blog.Infra.EntityFramework.Base;

namespace Blog.Infra.CrossCutting.IoC.Extensions
{
    public static class InfraBuilderExtensions
    {
        public static void RegisterInfraDependencies(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(Repository<,,>).Assembly)
                .Where(w => w.BaseType.IsGenericType &&
                   (w.BaseType.GetGenericTypeDefinition().IsAssignableFrom(typeof(Repository<,,>)) ||
                   (w.BaseType.GetGenericTypeDefinition().IsAssignableFrom(typeof(Repository<,,,>)))))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
