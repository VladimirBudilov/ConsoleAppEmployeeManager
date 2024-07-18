using Application.DTOs;
using Application.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers;

public class GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
{
    public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await employeeRepository.GetAllAsync();
        return mapper.Map<List<EmployeeDto>>(employees);
    }
}