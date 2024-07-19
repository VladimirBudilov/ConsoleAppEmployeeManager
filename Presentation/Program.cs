// See https://aka.ms/new-console-template for more information

using Application.DI;
using Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Presentation.Extensions;

var services = new ServiceCollection();
services.RegisterApplicationServices();
services.RegisterPresentationServices();
services.RegisterInfrastructureServices();
var serviceProvider = services.BuildServiceProvider();

try
{
    var runner = serviceProvider.GetRequiredService<ApplicationRunner>();
    await runner.Run(args, serviceProvider);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
