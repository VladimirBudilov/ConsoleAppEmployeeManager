using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class UpdateEmployeeCommand(int id, string firstName, string lastName, decimal? salaryPerHour) : IRequest<EmployeeResultDto>
{
    public int Id { get; }= id;
    public string? FirstName { get; }= firstName;
    public string? LastName { get; }= lastName;
    public decimal? SalaryPerHour { get; }= salaryPerHour;
}