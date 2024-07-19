using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public class InfrastructureServiceRegistration
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
    }
}