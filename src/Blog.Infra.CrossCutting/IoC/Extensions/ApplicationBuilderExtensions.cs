using Autofac;
using Blog.Application.Interfaces;

namespace Blog.Infra.CrossCutting.IoC.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static ContainerBuilder RegisterApplicationDependencies(this ContainerBuilder builder)
        {
            builder
               .RegisterAssemblyTypes(typeof(ICommentUseCase).Assembly)
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder;
        }
    }
}
