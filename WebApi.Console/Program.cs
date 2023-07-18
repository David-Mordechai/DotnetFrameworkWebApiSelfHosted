using System;
using System.Web.Http;
using Autofac;
using Microsoft.Owin.Hosting;
using Owin;
using Serilog;
using WebApi.Console.Configurations;

ILogger logger = null;

var port = args.Length > 0 ? int.Parse(args[0]) : 8080;
var baseAddress = $"http://localhost:{port}/";

using (WebApp.Start(baseAddress, app =>
{
    var config = new HttpConfiguration();
    config.ConfigureMediaTypesFormatters();
    config.ConfigureRoutes();
    var container = app.ConfigureIocContainer(config);
    app.UseWebApi(config);
    logger = container.Resolve<ILogger>();
}))
{
    logger.Information("Web API self-hosted on " + baseAddress);
    Console.ReadLine();
}
