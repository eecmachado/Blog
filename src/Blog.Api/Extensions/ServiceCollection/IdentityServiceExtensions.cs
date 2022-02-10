using Microsoft.AspNetCore.Identity;
using Blog.Infra.EntityFramework;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/Login");

            return services;
        }
    }
}
