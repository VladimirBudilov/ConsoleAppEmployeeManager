using System;
using System.Collections.Generic;
using System.Linq;

public class ArgsParser
{
    public Dictionary<string, string> ParseAndValidateBasic(string[] args, out string firstName, out string lastName,
        out decimal salary)
    {
        var parsedArgs = args.Skip(1)
            .Select(arg => arg.Split(':'))
            .Where(split => split.Length == 2)
            .ToDictionary(split => split[0], split => split[1], StringComparer.OrdinalIgnoreCase);

        if (!parsedArgs.ContainsKey("FirstName") || !parsedArgs.ContainsKey("LastName") ||
            !parsedArgs.ContainsKey("Salary"))
        {
            throw new ArgumentException("Missing required arguments.");
        }

        var isValidSalary = decimal.TryParse(parsedArgs["Salary"], out salary);
        if (!isValidSalary)
        {
            throw new ArgumentException("Invalid salary format.");
        }

        firstName = parsedArgs["FirstName"];
        lastName = parsedArgs["LastName"];
        return parsedArgs;
    }

    public Dictionary<string, string> ParseAndValidateBasic(string[] args, out int id, out string firstName,
        out string lastName, out decimal? salary)
    {
        var parsedArgs = args.Skip(1)
            .Select(arg => arg.Split(':'))
            .Where(split => split.Length == 2)
            .ToDictionary(split => split[0], split => split[1], StringComparer.OrdinalIgnoreCase);

        //TODO fix for adding employee
        if (!parsedArgs.ContainsKey("Id"))
        {
            throw new ArgumentException("Missing required arguments.");
        }

        if (parsedArgs.ContainsKey("Salary") && !decimal.TryParse(parsedArgs["Salary"], out _))
            throw new ArgumentException("Invalid salary format.");

        if(parsedArgs.ContainsKey("Id") && !int.TryParse(parsedArgs["Id"], out _))
            throw new ArgumentException("Invalid id format.");

        id = parsedArgs.ContainsKey("Id") ? int.Parse(parsedArgs["Id"]) : 0;
        firstName = parsedArgs.ContainsKey("FirstName") ? parsedArgs["FirstName"] : null;
        lastName = parsedArgs.ContainsKey("LastName") ? parsedArgs["LastName"] : null;
        salary = parsedArgs.ContainsKey("Salary") ? decimal.Parse(parsedArgs["Salary"]) : null;

        return parsedArgs;
    }
}