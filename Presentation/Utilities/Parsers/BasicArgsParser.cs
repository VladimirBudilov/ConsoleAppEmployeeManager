namespace Presentation.Utilities.Parsers;

public class BasicArgsParser
{
    public Dictionary<string, string> ArgsToDictionary(string[] args)
    {
        return args.Skip(1)
            .Select(arg => arg.Split(':'))
            .Where(split => split.Length == 2)
            .ToDictionary(split => split[0], split => split[1], StringComparer.OrdinalIgnoreCase);
    }
}