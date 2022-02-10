using CorrelationId.DependencyInjection;
using Blog.Api.Configurations;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CorrelationServiceExtensions
    {
        public static IServiceCollection AddCorrelationId(this IServiceCollection services, IConfiguration configuration)
        {
            var correlationConfiguration = configuration.GetSection(CorrelationConfiguration.Correlation)
                .Get<CorrelationConfiguration>();

            services.AddDefaultCorrelationId(opt =>
            {
                opt.RequestHeader = correlationConfiguration.RequestHeader;
                opt.AddToLoggingScope = correlationConfiguration.AddToLoggingScope;
                opt.UpdateTraceIdentifier = correlationConfiguration.UpdateTraceIdentifier;
            });

            return services;
        }
    }
}
