using Autofac;
using Reqnroll.Autofac;
using ReqnrollSampleProject.Steps;

namespace ReqnrollSampleProject;

public static class TestStartup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterSteps();
    }
    
    private static void RegisterSteps(this ContainerBuilder builder)
    {
        builder.RegisterType<StepDefinitions>().InstancePerDependency();
        builder.RegisterType<Hooks>().InstancePerDependency();
    }
}