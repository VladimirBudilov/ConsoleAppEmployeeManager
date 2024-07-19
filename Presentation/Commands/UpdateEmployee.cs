using Application.Commands;
using FluentValidation;
using MediatR;
using Presentation.Utilities;
using Presentation.Utilities.Validators;

namespace Presentation.Commands;

public class UpdateEmployee(
    IMediator mediator,
    ArgsParser parser,
    ArgsCountValidator argsCountValidator,
    IValidator<Dictionary<string, string>> argsValidator) : IExecutable
{
    public async Task Execute(string[] args)
    {
        if (!argsCountValidator.Validate(args, 3)) return;
        var parsedArgs = parser.ParseAndValidateBasic(args,out var id, out var firstName, out var lastName, out var salary);
        var validationResult = await argsValidator.ValidateAsync(parsedArgs);
        if (!validationResult.IsValid)
        {
            WriteLineHelper.ShowErrors(validationResult);
            return;
        }
        var command = new UpdateEmployeeCommand(id, firstName, lastName, salary);
        var result = await mediator.Send(command);
        WriteLineHelper.ShowResult(result);
    }
}