using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Commands;
using Presentation.Utilities.Parsers;
using Presentation.Utilities.Validators;

namespace Presentation.Extensions;

public static class PresentationServiceExtension
{
    public static void RegisterPresentationServices(this IServiceCollection services)
    {
        services.RegisterCommands();
        services.RegisterParsersAndValidators();
        services.AddSingleton<ApplicationRunner>();
    }

    private static void RegisterCommands(this IServiceCollection services)
    {
        services.AddTransient<AddEmployee>();
        services.AddTransient<DeleteEmployee>();
        services.AddTransient<GetAllEmployees>();
        services.AddTransient<GetEmployee>();
        services.AddTransient<UpdateEmployee>();
    }

    private static void RegisterParsersAndValidators(this IServiceCollection services)
    {
        services.AddTransient<BasicArgsParser>();
        services.AddTransient<ContentParser>();
        services.AddTransient<ArgsCountValidator>();
        services.AddTransient<BasicArgsValidator>();
        services.AddTransient<IValidator<Dictionary<string, string>>,ContentValidator>();
        services.AddTransient<CommandValidator>();
    }
}