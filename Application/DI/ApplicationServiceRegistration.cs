using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceCollection;

public static class ApplicationServiceRegistration
{public static void RegisterMediatrCommands(this IServiceCollection services)
    {
        services.AddMediatR(opt=> 
            opt.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
    }

}