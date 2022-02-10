using Blog.Infra.CrossCutting.Mappers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperServiceExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationProfile));
            return services;
        }
    }
}
