using Application.Behaviors;
using Application.Features.Prediction.Queries;
using Autofac;
using MediatR;

namespace Infrastructure.Bootstrap.AutofacModules
{
    internal class MediatorModule : Module
    {
        private readonly bool enableCommandLogging;

        public MediatorModule(bool enableCommandLogging)
        {
            this.enableCommandLogging = enableCommandLogging;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GetPredictionByDayQuery).Assembly)
                .AsImplementedInterfaces();

            if (this.enableCommandLogging)
            {
                builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            }

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
