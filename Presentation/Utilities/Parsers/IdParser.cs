public class IdParser
{
    public int ParseId(string[] args)
    {
        var parsedArgs = args.Skip(1)
            .Select(arg => arg.Split(':'))
            .Where(split => split.Length == 2)
            .ToDictionary(split => split[0], split => split[1], StringComparer.OrdinalIgnoreCase);

        if (!parsedArgs.ContainsKey("Id"))
        {
            throw new ArgumentException("Missing required arguments.");
        }
        
        var isValidId = int.TryParse(parsedArgs["Id"], out var id);
        if (!isValidId)
        {
            throw new ArgumentException("Invalid id format.");
        }
        
        

        return id;
    }
}