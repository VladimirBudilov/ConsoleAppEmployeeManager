using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class AddEmployeeCommand(string firstName, string lastName, decimal salaryPerHour) : IRequest<EmployeeResultDto>
{
    public string FirstName { get; }= firstName;
    public string LastName { get; }= lastName;
    public decimal SalaryPerHour { get; }= salaryPerHour;
}
