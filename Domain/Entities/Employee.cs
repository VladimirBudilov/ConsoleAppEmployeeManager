using Domain.ValueObjects;

namespace Domain.Entities;

public class Employee
{
    public Employee(int id, string firstName, string lastName, decimal salaryPerHour)
    {
        Id = new Identifier(id);
        PersonalInfo = new PersonalInfo(firstName, lastName);
        SalaryPerHour = new Salary(salaryPerHour);
    }

    public Identifier Id { get; private set; }
    public PersonalInfo PersonalInfo { get; private set; } 
    public Salary SalaryPerHour { get; private set; }

    public void Update(string firstName, string lastName, decimal? salaryPerHour)
    {
        if (firstName != null)
        {
            PersonalInfo.UpdateFirstName(firstName);
        }

        if (lastName != null)
        {
            PersonalInfo.UpdateLastName(lastName);
        }
        
        if (salaryPerHour != null)
        {
            SalaryPerHour = new Salary(salaryPerHour.Value);
        }
    }
}




