using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Queries;

public class GetEmployeeQuery(int id) : IRequest<EmployeeDto>
{
    public int Id { get; } = id;
}