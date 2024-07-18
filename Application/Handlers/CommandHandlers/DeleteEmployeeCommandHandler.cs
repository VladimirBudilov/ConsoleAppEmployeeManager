using Application.Commands;
using Application.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class DeleteEmployeeCommandHandler(IEmployeeRepository repository) : IRequestHandler<DeleteEmployeeCommand,EmployeeIdDto>
{
    public async Task<EmployeeIdDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(request.Id);
        if (employee == null)
        {
            return new EmployeeIdDto { Id = request.Id, Success = false, Message = "Employee not found." };
        }
        
        await repository.DeleteAsync(request.Id);
        return new EmployeeIdDto { Id = request.Id, Success = true, Message = "Employee deleted successfully." };
    }
}