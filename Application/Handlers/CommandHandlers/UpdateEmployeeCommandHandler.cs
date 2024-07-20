using Application.Commands;
using Application.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class UpdateEmployeeCommandHandler(IEmployeeRepository repository)
    : IRequestHandler<UpdateEmployeeCommand, ResultDto>
{
    public async Task<ResultDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(request.Id);
        if (employee == null)
        {
            return new ResultDto { Id = request.Id, Success = false, Message = "not found." };
        }

        employee.Update(request.FirstName, request.LastName, request.SalaryPerHour);
        var isSuccess = await repository.UpdateAsync(employee);
        return isSuccess
            ? new ResultDto { Id = request.Id, Success = true, Message = "updated successfully." }
            : new ResultDto { Id = request.Id, Success = true, Message = "not updated." };
    }
}