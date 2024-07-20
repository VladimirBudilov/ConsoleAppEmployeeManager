using Application.Commands;
using MediatR;
using Presentation.Utilities;
using Presentation.Utilities.Parsers;
using Presentation.Utilities.Validators;

namespace Presentation.Commands;

public class AddEmployee(
    IMediator mediator,
    ContentParser parser,
    CommandValidator validator) : IExecutable
{
    public async Task Execute(string[] args)
    {
        var isValid = await validator.IsValidInput(args, (int)NumberOfArgs.AddEmployee, out var parsedArgs, false);
        if (!isValid) return;
        parser.GetContent(parsedArgs, out var firstName, out var lastName, out var salary);
        var command = new AddEmployeeCommand(firstName, lastName, salary);
        var result = await mediator.Send(command);
        WriteLineHelper.ShowResult(result);
    }
}