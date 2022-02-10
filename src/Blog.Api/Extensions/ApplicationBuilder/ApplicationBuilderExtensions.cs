using CorrelationId;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static void AddBuilder(this IApplicationBuilder app,
            ILoggerFactory logger)
        {
            app.UseCustomExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseCorrelationId();
            app.UseSerilogRequestLogging();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
                endpoints.MapRazorPages();
            });
        }
    }
}
