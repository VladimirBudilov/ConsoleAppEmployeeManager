// See https://aka.ms/new-console-template for more information

//add DI to the project

using System.Reflection;
using Application.ServiceCollection;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Commands;
using Presentation.Extensions;

var services = new ServiceCollection();

services.RegisterMediatrCommands();
services.RegisterCommands();
services.RegisterParsersAndValidators();
var serviceProvider = services.BuildServiceProvider();


try
{
    await RunApplication(args, serviceProvider);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


async Task RunApplication(string[] args, IServiceProvider serviceProvider)
{
    switch (args[0])
    {
        case "-add":
            await serviceProvider.GetRequiredService<AddEmployee>().Execute(args);
            break;
        case "-update":
            await serviceProvider.GetRequiredService<UpdateEmployee>().Execute(args);
            break;
        case "-delete":
            await serviceProvider.GetRequiredService<DeleteEmployee>().Execute(args);
            break;
        case "-get":
            await serviceProvider.GetRequiredService<GetEmployee>().Execute(args);
            break;
        case "-getall":
            await serviceProvider.GetRequiredService<GetAllEmployees>().Execute(args);
            break;
        default:
            Console.WriteLine("Unknown command");
            break;
    }
}