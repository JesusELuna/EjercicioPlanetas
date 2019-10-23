using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class HealthChecksServiceCollectionExtensions
    {
        public static void AddApiHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }
    }
}
