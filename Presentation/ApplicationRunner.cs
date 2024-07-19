using Microsoft.Extensions.DependencyInjection;
using Presentation.Commands;

namespace Presentation;

public class ApplicationRunner
{
    public async Task Run(string[] args, IServiceProvider provider)
    {
        if (!ValidateArgs(args)) return;
        
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
    
    private static bool ValidateArgs(string[] args)
    {
        if (args.Length != 0) return true;
        Console.WriteLine("No command provided");
        return false;
    }
    
    
}