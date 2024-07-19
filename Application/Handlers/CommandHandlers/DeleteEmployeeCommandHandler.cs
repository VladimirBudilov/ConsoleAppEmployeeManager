using Application.Commands;
using Application.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class DeleteEmployeeCommandHandler(IEmployeeRepository repository) : IRequestHandler<DeleteEmployeeCommand,EmployeeResultDto>
{
    public async Task<EmployeeResultDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(request.Id);
        if (employee == null)
        {
            return new EmployeeResultDto { Id = request.Id, Success = false, Message = "Employee not found." };
        }
        
        await repository.DeleteAsync(request.Id);
        return new EmployeeResultDto { Id = request.Id, Success = true, Message = "Employee deleted successfully." };
    }
}