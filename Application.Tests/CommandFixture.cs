using Application.DI;
using Domain.Repositories;
using Infrastructure.DI;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;


namespace Application.Tests;

public class CommandFixture
{
    public Mock<IEmployeeRepository> employeeRepositoryMock;
    private IMediator _mediator;
    
    public CommandFixture()
    {
        employeeRepositoryMock = new Mock<IEmployeeRepository>();
        var services = new ServiceCollection();
        services.AddMediatR(opt=> 
            opt.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
        services.AddSingleton(employeeRepositoryMock.Object);
        var serviceProvider = services.BuildServiceProvider();
        
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }
    
    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        return await _mediator.Send(request);
    }
}   