using Application.Commands;
using MediatR;
using Presentation.Utilities;
using Presentation.Utilities.Parsers;
using Presentation.Utilities.Validators;

namespace Presentation.Commands;

public class UpdateEmployee(
    IMediator mediator,
    ContentParser parser,
    CommandValidator validator) : IExecutable
{
    public async Task Execute(string[] args)
    {
        var isValid = await validator.IsValidInput(args, (int)NumberOfArgs.UpdateEmployee, out var parsedArgs);
        if (!isValid) return;
        parser.GetContent(parsedArgs, out var id, out var firstName, out var lastName, out var salary);
        var command = new UpdateEmployeeCommand(id, firstName, lastName, salary);
        var result = await mediator.Send(command);
        WriteLineHelper.ShowResult(result);
    }
}