namespace Application.DTOs;

public record EmployeeDto
{
    public int Id { get;  init; }
    public string FirstName { get;  init; }
    public string LastName { get;  init; }
    public decimal SalaryPerHour { get;  init; }
}