using Application.Commands;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class UpdateEmployeeCommandHandler(IEmployeeRepository repository) : IRequestHandler<UpdateEmployeeCommand,EmployeeResultDto>
{
    public async Task<EmployeeResultDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
            var employee = await repository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return new EmployeeResultDto { Id = request.Id, Success = false, Message = "Employee not found." };
            }
            employee.Update(request.FirstName, request.LastName, request.SalaryPerHour.GetValueOrDefault());
            await repository.UpdateAsync(employee);
            return new EmployeeResultDto { Id = request.Id, Success = true, Message = "Employee updated successfully."};
    }
}