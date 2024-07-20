using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Mapping;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public static class InfrastructureServiceRegistration
{
    public static void RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddSingleton<JsonDataContext>();
        services.AddAutoMapper(typeof(EmployeeDataModelProfile));
    }
}