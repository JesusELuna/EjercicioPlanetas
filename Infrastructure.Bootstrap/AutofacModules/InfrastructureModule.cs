using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Bootstrap.AutofacModules
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment env;

        public InfrastructureModule(IConfiguration configuration, IHostingEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (env.IsDevelopment())
            {
                //builder.RegisterType<AspNetCoreConfigurationProvider>()
                //    .As<ICredentialProvider>()
                //    .WithParameter("configuration", configuration)
                //    .WithParameter("userKey", "Database:UserName")
                //    .WithParameter("passwordKey", "Database:Password")
                //    .SingleInstance();
            }
            else
            {
                //builder.RegisterType<BaseDeClavesProvider>()
                //    .As<ICredentialProvider>()
                //    .WithParameter("baseDeClavesProviderSettings", new BaseDeClavesProviderSettings(
                //        configuration.GetSection("Database:BaseDeClaves:ApplicationId")?.Value,
                //        configuration.GetConnectionString("BaseDeClaves"),
                //        configuration.GetSection("Database:BaseDeClaves:Schema").Value))
                //    .SingleInstance();
            }

            //builder.RegisterType<SqlProviderSettings>()
            //        .As<ISqlProviderSettings>()
            //        .WithParameter("connectionString", configuration.GetConnectionString("RIO226"))
            //        .WithParameter("schema", configuration.GetSection("Database:RIO226:Schema")?.Value)
            //        .WithParameter("sqlTimeout", Convert.ToInt32(configuration.GetSection("Database:RIO226:SqlTimeout")?.Value))
            //        .SingleInstance();

            //builder.RegisterType<SqlProvider>()
            //        .As<ISqlProvider>().SingleInstance();
        }
    }
}
