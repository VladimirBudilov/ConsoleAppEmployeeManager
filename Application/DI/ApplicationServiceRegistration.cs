using Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DI;

public static class ApplicationServiceRegistration
{public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(opt=> 
            opt.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
        services.AddAutoMapper(typeof(EmployeeProfile));
    }
}