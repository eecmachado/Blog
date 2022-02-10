using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Blog.Infra.EntityFramework;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EntityFrameworkServiceExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Test"));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
