using Application.Commands;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class UpdateEmployeeCommandHandler(IEmployeeRepository repository) : IRequestHandler<UpdateEmployeeCommand,EmployeeIdDto>
{
    public async Task<EmployeeIdDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
            var employee = await repository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return new EmployeeIdDto { Id = request.Id, Success = false, Message = "Employee not found." };
            }
            employee.TryUpdate(new PersonalInfo(request.FirstName, request.LastName), new Salary(request.SalaryPerHour));
            await repository.UpdateAsync(employee);
            return new EmployeeIdDto { Id = request.Id, Success = true, Message = "Employee updated successfully."};
    }
}