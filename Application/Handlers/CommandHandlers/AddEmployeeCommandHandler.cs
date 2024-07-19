using Application.Commands;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class AddEmployeeCommandHandler(IEmployeeRepository repository) : IRequestHandler<AddEmployeeCommand, ResultDto>
{
    public async Task<ResultDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee(0, request.FirstName, request.LastName, request.SalaryPerHour);
        var id = await repository.AddAsync(employee);
        return id >= 0
        ? new ResultDto { Id = id, Success = true, Message = "added successfully." }
        : new ResultDto { Id = id, Success = false, Message = "not added.(you have got invalid Id in response)" };
    }
}