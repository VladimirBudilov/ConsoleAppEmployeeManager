namespace Domain.Entities;

public class Employee(Identifier id, PersonalInfo personalInfo, Salary salaryPerHour)
{
    public Identifier Id { get; private set; } = id;
    public PersonalInfo PersonalInfo { get; private set; } = personalInfo;
    public Salary SalaryPerHour { get; private set; } = salaryPerHour;
    
    public bool TryUpdate(PersonalInfo personalInfo, Salary salaryPerHour)
    {
        if (personalInfo == null || salaryPerHour == null)
        {
            return false;
        }

        PersonalInfo = personalInfo;
        SalaryPerHour = salaryPerHour;

        return true;
    }
}

public class PersonalInfo
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    public PersonalInfo(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("First name and last name must not be empty.");
        }

        FirstName = firstName;
        LastName = lastName;
    }
}

public class Salary
{
    public decimal Value { get; private set; }

    public Salary(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Salary must be greater than zero.");
        }

        Value = value;
    }
}

public class Identifier
{
    public int Value { get; private set; }

    public Identifier(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Identifier must be greater than zero.");
        }

        Value = value;
    }
}