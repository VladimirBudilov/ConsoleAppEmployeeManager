// See https://aka.ms/new-console-template for more information

//add DI to the project

using Application.DI;
using Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Commands;
using Presentation.Extensions;

var services = new ServiceCollection();

services.RegisterApplicationServices();
services.RegisterPresentationServices();
services.RegisterInfrastructureServices();

var serviceProvider = services.BuildServiceProvider();


try
{
    await RunApplication(args, serviceProvider);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


async Task RunApplication(string[] args, IServiceProvider provider)
{
    switch (args[0])
    {
        case "-add":
            await provider.GetRequiredService<AddEmployee>().Execute(args);
            break;
        case "-update":
            await provider.GetRequiredService<UpdateEmployee>().Execute(args);
            break;
        case "-delete":
            await provider.GetRequiredService<DeleteEmployee>().Execute(args);
            break;
        case "-get":
            await provider.GetRequiredService<GetEmployee>().Execute(args);
            break;
        case "-getall":
            await provider.GetRequiredService<GetAllEmployees>().Execute(args);
            break;
        default:
            Console.WriteLine("Unknown command");
            break;
    }
}