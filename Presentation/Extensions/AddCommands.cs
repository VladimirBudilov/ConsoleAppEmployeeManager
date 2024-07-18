using Microsoft.Extensions.DependencyInjection;
using Presentation.Commands;

namespace Presentation.Extensions;

public static class AddCommands
{
    public static void AddCrudCommands(this IServiceCollection services)
    {
        services.AddTransient<IExecutable, AddEmployee>();
        services.AddTransient<IExecutable, DeleteEmployee>();
        services.AddTransient<IExecutable, GetAllEmployees>();
        services.AddTransient<IExecutable, GetEmployee>();
        services.AddTransient<IExecutable, UpdateEmployee>();
    }
}