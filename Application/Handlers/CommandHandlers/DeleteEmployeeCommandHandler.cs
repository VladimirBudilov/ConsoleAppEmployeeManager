using Application.Commands;
using Application.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class DeleteEmployeeCommandHandler(IEmployeeRepository repository)
    : IRequestHandler<DeleteEmployeeCommand, ResultDto>
{
    public async Task<ResultDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(request.Id);
        if (employee == null)
        {
            return new ResultDto { Id = request.Id, Success = false, Message = "not found." };
        }

        var isSuccess = await repository.DeleteAsync(request.Id);
        return isSuccess
            ? new ResultDto { Id = request.Id, Success = true, Message = "deleted successfully." }
            : new ResultDto { Id = request.Id, Success = false, Message = "not deleted." };
    }
}