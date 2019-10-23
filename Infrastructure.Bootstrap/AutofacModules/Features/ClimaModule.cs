using Autofac;
using Domain.Prediccion.Queries;
using Infrastructure.Features.Prediccion.Repository;

namespace Infrastructure.Bootstrap.AutofacModules.Features
{
    public class ClimaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PrediccionRepository>()
             .As<IPrediccionRepository>()
             .InstancePerLifetimeScope();
        }
    }
}
