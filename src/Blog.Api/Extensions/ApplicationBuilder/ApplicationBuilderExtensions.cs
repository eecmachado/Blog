using Serilog;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static void AddBuilder(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
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
