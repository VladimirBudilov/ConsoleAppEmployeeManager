
using Application.Base;
using Infrastructure.EventSourcing;

namespace Core.Domain.Aggregates;

public class Employee : AggregateRoot
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public decimal SalaryPerHour { get; private set; }

    private Employee() { }

    public Employee(int id, string firstName, string lastName, decimal salaryPerHour)
    {
        ApplyChange(new EmployeeCreatedEvent(id, firstName, lastName, salaryPerHour));
    }

    public void UpdateEmployee(string firstName)
    {
        ApplyChange(new EmployeeDataUpdatedEvent(Id, firstName));
    }

    private void Apply(EmployeeCreatedEvent @event)
    {
        Id = @event.Id;
        FirstName = @event.FirstName;
        LastName = @event.LastName;
        SalaryPerHour = @event.SalaryPerHour;
    }

    private void Apply(EmployeeDataUpdatedEvent @event)
    {
        FirstName = @event.FirstName;
    }
}