using Application.Commands;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class AddEmployeeCommandHandler(IEmployeeRepository repository) : IRequestHandler<AddEmployeeCommand, EmployeeIdDto>
{
    public async Task<EmployeeIdDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
            var identifier = new Identifier(0);
            var personalInfo = new PersonalInfo(request.FirstName, request.LastName);
            var salary = new Salary(request.SalaryPerHour);
            var employee = new Employee(identifier, personalInfo, salary);
            var id= await repository.AddAsync(employee);
            return new EmployeeIdDto { Id = id, Success = true, Message = "Employee added successfully."};
    }
}