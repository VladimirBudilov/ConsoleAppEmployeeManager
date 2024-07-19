namespace Domain.ValueObjects;

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