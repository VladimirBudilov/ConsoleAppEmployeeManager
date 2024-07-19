using Application.Commands;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Presentation.Utilities;
using Presentation.Utilities.Parsers;
using Presentation.Utilities.Validators;

namespace Presentation.Commands;

public class DeleteEmployee(
    IMediator mediator,
    ContentParser parser,
    CommandValidator validator) : IExecutable
{
    public async Task Execute(string[] args)
    {
        var isValid = await validator.IsValidInput(args,(int)NumberOfArgs.DeleteEmployee, out var parsedArgs);
        if (!isValid) return;
        parser.GetContent(parsedArgs,out var id, out var _, out var _, out var _);

        var command = new DeleteEmployeeCommand(id);
        var result = await mediator.Send(command);
        WriteLineHelper.ShowResult(result);
    }


}