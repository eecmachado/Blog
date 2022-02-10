using Blog.Api.Resources;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ExceptionApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder, ILoggerFactory logger)
        {
            return builder.UseExceptionHandler(app =>
            {
                app.Run(async context =>
                {
                    var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();
                    var httpRequestIdentifier = context.Features.Get<IHttpRequestIdentifierFeature>();

                    var log = logger.CreateLogger("GlobalExceptionHandler");

                    log.LogError(exceptionHandler.Error, httpRequestIdentifier.TraceIdentifier, Messages.InternalServerError);

                    await Task.CompletedTask;
                });
            });
        }
    }
}
