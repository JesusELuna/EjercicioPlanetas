using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Bootstrap.AutofacModules;
using Infrastructure.Bootstrap.AutofacModules.Features;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class AutofacConfigurationServiceCollectionExtensions
    {
        public static IContainer AddConfigurationAutofac(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
        {
            ContainerBuilder builder = new ContainerBuilder();
            
            builder.RegisterModule<WeatherModule>();
            builder.RegisterModule(new MediatorModule(configuration.GetValue("CommandLoggingEnabled", false)));

            builder.Populate(services);

            return builder.Build();
        }
    }
}
