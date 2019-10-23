using Autofac;

namespace Infrastructure.Bootstrap.AutofacModules.Features
{
    public class ClimaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<BranchRepository>()
            // .As<IBranchRepository>()
            // .InstancePerLifetimeScope();
        }
    }
}
