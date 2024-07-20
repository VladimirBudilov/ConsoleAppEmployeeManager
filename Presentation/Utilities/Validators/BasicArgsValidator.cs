namespace Presentation.Utilities.Validators;

public class BasicArgsValidator
{
    public bool IsValidRequiredKeys(Dictionary<string, string> parsedArgs)
    {
        var requiredKeys = new List<string> { "Id", "FirstName", "LastName", "Salary" };
        var invalidKeys = parsedArgs.Where(key => !requiredKeys.Contains(key.Key)).ToList();

        if (invalidKeys.Count != 0)
        {
            Console.WriteLine($"Invalid arguments: {string.Join(", ", invalidKeys)}.");
            return false;
        }

        return true;
    }

    public bool IsValidKeysWithoutId(Dictionary<string, string> parsedArgs)
    {
        if (!parsedArgs.ContainsKey("FirstName") || !parsedArgs.ContainsKey("LastName") ||
            !parsedArgs.ContainsKey("Salary"))
        {
            Console.WriteLine("Missing required arguments.");
            return false;
        }

        if (!decimal.TryParse(parsedArgs["Salary"], out _))
        {
            Console.WriteLine("Invalid salary format.");
            return false;
        }

        return true;
    }

    public bool IsValidKeysWithId(Dictionary<string, string> parsedArgs)
    {
        if (!parsedArgs.ContainsKey("Id"))
        {
            Console.WriteLine("Missing Id.");
            return false;
        }

        if (parsedArgs.ContainsKey("Salary") && !decimal.TryParse(parsedArgs["Salary"], out _))
        {
            Console.WriteLine("Invalid salary format.");
            return false;
        }

        if (parsedArgs.ContainsKey("Id") && !int.TryParse(parsedArgs["Id"], out _))
        {
            Console.WriteLine("Invalid id format.");
            return false;
        }

        return true;
    }
}