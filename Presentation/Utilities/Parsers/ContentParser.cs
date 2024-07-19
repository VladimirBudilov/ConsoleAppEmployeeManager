namespace Presentation.Utilities.Parsers;

public class ContentParser
{
    public void GetContent(Dictionary<string, string> parsedArgs,
        out string firstName,
        out string lastName,
        out decimal salary)
    {
        firstName = parsedArgs["FirstName"];
        lastName = parsedArgs["LastName"];
        salary = decimal.Parse(parsedArgs["Salary"]);
    }

    public void GetContent(Dictionary<string, string> parsedArgs,
        out int id,
        out string firstName,
        out string lastName,
        out decimal? salary)
    {
        id = parsedArgs.ContainsKey("Id") ? int.Parse(parsedArgs["Id"]) : 0;
        firstName = parsedArgs.ContainsKey("FirstName") ? parsedArgs["FirstName"] : null;
        lastName = parsedArgs.ContainsKey("LastName") ? parsedArgs["LastName"] : null;
        salary = parsedArgs.ContainsKey("Salary") ? decimal.Parse(parsedArgs["Salary"]) : null;
    }
    

}