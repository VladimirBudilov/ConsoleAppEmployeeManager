﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Commands;
using Presentation.Utilities.Validators;

namespace Presentation.Extensions;

public static class PresentationServiceExtension
{
    public static void RegisterPresentationServices(this IServiceCollection services)
    {
        services.RegisterCommands();
        services.RegisterParsersAndValidators();
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
        services.AddTransient<ArgsParser>();
        services.AddTransient<IdParser>();
        services.AddTransient<ArgsCountValidator>();
        services.AddTransient<IValidator<Dictionary<string, string>>,ArgsValidator>();
        services.AddTransient<IValidator<int>,IdValidator>();
    }
}