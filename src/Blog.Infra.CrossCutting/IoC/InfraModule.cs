using Autofac;
using Blog.Infra.CrossCutting.IoC.Extensions;

namespace Blog.Infra.CrossCutting.IoC
{
    public class InfraModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInfraDependencies();
        }
    }
}
