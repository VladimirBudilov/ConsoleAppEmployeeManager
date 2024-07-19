namespace Domain.ValueObjects;

public class PersonalInfo
{
    public string FirstName { get; set; }
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

    public void UpdateFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name must not be empty.");
        }

        FirstName = firstName;
    }

    public void UpdateLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name must not be empty.");
        }

        LastName = lastName;
    }
}
