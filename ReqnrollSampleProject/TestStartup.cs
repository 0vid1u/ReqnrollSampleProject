using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Reqnroll.Autofac;
using ReqnrollSampleProject.Settings;
using ReqnrollSampleProject.Steps;

namespace ReqnrollSampleProject;

public static class TestStartup
{
    private const string Environment = "ENVIRONMENT";
    
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterConfiguration();
        builder.RegisterAppSettings();
        builder.RegisterSteps();
    }
    
    private static void RegisterSteps(this ContainerBuilder builder)
    {
        builder.RegisterType<StepDefinitions>().InstancePerDependency();
        builder.RegisterType<Hooks>().InstancePerDependency();
    }
    
    private static void RegisterConfiguration(this ContainerBuilder builder)
    {
        // Read the environment variable (default to "Production" if not set)
        var environment = System.Environment.GetEnvironmentVariable(Environment) ?? "default";

        var configuration = new ConfigurationBuilder()
            .AddJsonFile($"Settings/AppSettings.{environment}.json", false, true)
            .Build();

        builder.RegisterInstance(configuration)
            .As<IConfiguration>()
            .SingleInstance();
    }
    
    private static void RegisterAppSettings(this ContainerBuilder builder)
    {
        builder.Register(c =>
        {
            var configuration = c.Resolve<IConfiguration>();
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            return Options.Create(appSettings);
        }).As<IOptions<AppSettings>>();
    }
}