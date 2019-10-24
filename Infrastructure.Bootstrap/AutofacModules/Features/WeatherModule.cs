using Autofac;
using Domain.Prediction.Queries;
using Infrastructure.Features.Prediccion.Repository;

namespace Infrastructure.Bootstrap.AutofacModules.Features
{
    public class WeatherModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PredictionRepository>()
             .As<IPredictionRepository>()
             .InstancePerLifetimeScope();
        }
    }
}
