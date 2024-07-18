using Application.DTOs;
using MediatR;

namespace Application.Queries;

public class GetEmployeesQuery : IRequest<List<EmployeeDto>>
{
}