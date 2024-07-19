using Application.Commands;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class AddEmployeeCommandHandler(IEmployeeRepository repository) : IRequestHandler<AddEmployeeCommand, EmployeeResultDto>
{
    public async Task<EmployeeResultDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
            
            var employee = new Employee(0, request.FirstName, request.LastName, request.SalaryPerHour);
            var id= await repository.AddAsync(employee);
            return new EmployeeResultDto { Id = id, Success = true, Message = "Employee added successfully."};
    }
}