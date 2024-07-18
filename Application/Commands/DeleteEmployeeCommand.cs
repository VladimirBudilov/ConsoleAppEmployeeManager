using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class DeleteEmployeeCommand(int id) : IRequest<EmployeeIdDto>
{ 
    public int Id { get; } = id;
}