using Application.Commands;
using Application.Queries;
using FluentValidation;
using MediatR;
using Presentation.Utilities;
using Presentation.Utilities.Parsers;
using Presentation.Utilities.Validators;

namespace Presentation.Commands;

public class GetEmployee(
    IMediator mediator,
    ContentParser parser,
    CommandValidator validator) : IExecutable
{
    public async Task Execute(string[] args)
    {
        var isValid = await validator.IsValidInput(args,(int)NumberOfArgs.GetEmployee, out var parsedArgs);
        if (!isValid) return;
        parser.GetContent(parsedArgs,out var id, out var _, out var _, out var _);

        var command = new GetEmployeeQuery(id);
        var result = await mediator.Send(command);
        WriteLineHelper.ShowResult(result);
    }
}