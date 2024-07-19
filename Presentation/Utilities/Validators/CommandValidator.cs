using FluentValidation;
using Presentation.Utilities.Parsers;

namespace Presentation.Utilities.Validators;

public class CommandValidator(
    BasicArgsParser parser,
    BasicArgsValidator keysValidator,
    ArgsCountValidator argsCountValidator,
    IValidator<Dictionary<string, string>> contentValidator)
{
    public Task<bool> IsValidInput(string[] args, int validArgsAmount, out Dictionary<string, string> parsedArgs,
        bool withId = true)
    {
        parsedArgs = parser.ArgsToDictionary(args);
        if (!argsCountValidator.Validate(args, validArgsAmount)) return Task.FromResult(false);

        var isValidKeys = withId
            ? keysValidator.IsValidKeysWithId(parsedArgs)
            : keysValidator.IsValidKeysWithoutId(parsedArgs);
        if (!keysValidator.IsValidRequiredKeys(parsedArgs) || !isValidKeys)
            return Task.FromResult(false);
        var validationResult = contentValidator.ValidateAsync(parsedArgs).Result;
        if (!validationResult.IsValid)
        {
            WriteLineHelper.ShowErrors(validationResult);
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }
}