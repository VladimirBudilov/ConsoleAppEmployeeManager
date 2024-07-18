using Application.Base;

namespace Infrastructure.EventSourcing;

public class EmployeeCreatedEvent : Event
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public decimal SalaryPerHour { get; }

    public EmployeeCreatedEvent(int id, string firstName, string lastName, decimal salaryPerHour)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        SalaryPerHour = salaryPerHour;
    }
}

public class EmployeeDataUpdatedEvent : Event
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public decimal SalaryPerHour { get; }

    public EmployeeDataUpdatedEvent(int id, string firstName, string lastName, decimal salaryPerHour)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        SalaryPerHour = salaryPerHour;
    }
}
