namespace Domain.ValueObjects;

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