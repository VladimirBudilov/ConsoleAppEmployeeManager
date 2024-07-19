using Application.DTOs;
using Application.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers;

public class GetEmployeeQueryHandler(IEmployeeRepository repository, IMapper mapper)
    : IRequestHandler<GetEmployeeQuery, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(request.Id);
        return employee == null ? null : mapper.Map<EmployeeDto>(employee);
    }
}