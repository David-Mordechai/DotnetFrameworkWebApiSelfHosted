using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using Serilog;
using WebApi.Console.Services;

namespace WebApi.Console.Configurations;

public static class IocContainer
{
    public static IContainer ConfigureIocContainer(this IAppBuilder app, HttpConfiguration config)
    {
        var builder = new ContainerBuilder();
        builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        RegisterServices(builder);
        var container = builder.Build();

        config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        
        app.UseAutofacMiddleware(container);
        app.UseAutofacWebApi(config);

        return container;
    }

    private static void RegisterServices(ContainerBuilder builder)
    {
        builder.Register<ILogger>((_, _) => new LoggerConfiguration().WriteTo.Console().CreateLogger()).SingleInstance();
        
        builder.RegisterType<MyService>().As<IMyService>().InstancePerRequest();
    }
}