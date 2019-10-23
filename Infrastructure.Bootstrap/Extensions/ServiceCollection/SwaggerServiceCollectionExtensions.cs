using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services, string name, string titleDoc, string version)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name, new Info { Title = titleDoc, Version = version });
            });
        }
    }
}
