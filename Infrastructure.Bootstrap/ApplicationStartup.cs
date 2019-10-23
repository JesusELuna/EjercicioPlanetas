using Application.Features.Clima.Queries;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Bootstrap.Extensions.ApplicationBuilder;
using Infrastructure.Bootstrap.Extensions.ServiceCollection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.Bootstrap
{
    public class ApplicationStartup
    {
        public IConfiguration Configuration { get; }

        public ApplicationStartup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public IServiceProvider ConfigureServices(IServiceCollection services, IHostingEnvironment env = null)
        {
            
            services.AddMvc(o =>
            {
                o.Filters.Add(new ProducesResponseTypeAttribute(400));
                o.Filters.Add(new ProducesResponseTypeAttribute(500));
                o.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiHealthChecks();
            services.AddSwagger("v1", "Challenge", "v1");
            services.ConfigureResponseCompression();
            services.AddHttpContextAccessor();
            services.AddCorsConfiguration();
            services.AddMediatR(typeof(GetClimaByDiaQuery).Assembly);

            var container = services.AddConfigurationAutofac(this.Configuration, env);
            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseApiHealthChecks();
            app.UseResponseCompression();
            app.UseMicroserviceExampleSwagger();
            app.UseExceptionHandler(errorPipeline =>
            {
                errorPipeline.UseExceptionHandlerMiddleware();
            });
            app.UseMvc();
        }
    }
}
